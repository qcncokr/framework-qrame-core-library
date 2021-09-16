using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Qrame.CoreFX.Library.MessageContract.Contract;
using Qrame.CoreFX.Library.MessageContract.Message;

using RestSharp;

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Qrame.CoreFX.Library.ApiClient
{
    public class TransactionClient : IDisposable
	{
		private static Dictionary<string, JObject> apiServices = new Dictionary<string, JObject>();

		public TransactionClient()
		{

		}

		public bool AddFindService(string systemID, string serverType)
		{
			bool result = false;
			try
			{
				string findID = systemID + serverType;
				if (apiServices.ContainsKey(findID) == false)
				{
					Uri uri = new Uri(TransactionConfig.ApiFindUrl + $"?systemID={systemID}&serverType={serverType}");
					RestClient client = new RestClient(uri);
					// client.Proxy = BypassWebProxy.Default;
					RestRequest apiRequest = new RestRequest(Method.GET);
					apiRequest.AddHeader("Content-Type", "application/json");
					apiRequest.AddHeader("cache-control", "no-cache");
					apiRequest.AddHeader("X-Requested-With", "QAF ServiceClient");

					apiRequest.Timeout = TransactionConfig.TransactionTimeout;
					var apiResponse = client.Execute<TransactionResponse>(apiRequest, Method.GET);

					if (apiResponse.ResponseStatus == ResponseStatus.Completed)
					{
						JObject apiService = JObject.Parse(apiResponse.Content);
						string exceptionText = apiService["ExceptionText"].ToString();
						if (string.IsNullOrEmpty(exceptionText) == true)
						{
							result = true;
							apiServices.Add(systemID + serverType, apiService);
						}
					}
				}
				else
				{
					result = true;
				}
			}
			catch (Exception exception)
			{
				Serilog.Log.Error(exception, $"systemID: {systemID}, serverType: {serverType} AddFindService 오류");
			}

			return result;
		}

		public bool AddApiService(string systemID, string serverType, JObject apiService)
		{
			bool result = false;
			try
			{
				string findID = systemID + serverType;
				if (apiServices.ContainsKey(findID) == false)
				{
					apiServices.Add(systemID + serverType, apiService);
				}
				else
				{
					result = true;
				}
			}
			catch (Exception exception)
			{
				Serilog.Log.Error(exception, $"systemID: {systemID}, serverType: {serverType} AddApiService 오류");
			}

			return result;
		}

		public async Task<Dictionary<string, JToken>> ExecuteTransaction(TransactionClientObject transactionObject, dynamic definition = null)
		{
			string message = $"{transactionObject.TransactionID}|{transactionObject.FunctionID} 거래 요청 중...";
			string typeResult = "";
			string error = "";
			Dictionary<string, JToken> result = new Dictionary<string, JToken>();
			try
			{
				transactionObject.ReturnType = string.IsNullOrEmpty(transactionObject.ReturnType) == true ? "Json" : transactionObject.ReturnType;

				if (transactionObject.InputsItemCount.Count == 0)
				{
					transactionObject.InputsItemCount.Add(transactionObject.Inputs.Count);
				}

				JObject findService = null;
				if (apiServices.TryGetValue(transactionObject.SystemID + TransactionConfig.DomainServerType, out findService) == true)
				{
					var restFulUrl = "";
					if (string.IsNullOrEmpty(findService["Port"].ToString()) == false)
					{
						restFulUrl = $"{findService["Protocol"].ToString()}://{findService["IP"].ToString()}:{findService["Port"].ToString()}";
					}
					else
					{
						restFulUrl = $"{findService["Protocol"].ToString()}://{findService["IP"].ToString()}";
					}

					transactionObject.RequestID = string.IsNullOrEmpty(findService["RequestID"].ToString()) == true ? "" : findService["RequestID"].ToString();

					TransactionRequest transactionRequest = CreateTransactionRequest("REPLY", transactionObject);

					RestClient client = new RestClient(restFulUrl);
					// // client.Proxy = BypassWebProxy.Default;
					var restRequest = new RestRequest(findService["Path"].ToString(), Method.POST);
					restRequest.AddJsonBody(transactionRequest);

					restRequest.AddHeader("Content-Type", "qrame/json-transact");
					restRequest.AddHeader("cache-control", "no-cache");
					restRequest.AddHeader("X-Requested-With", "QAF ServiceClient");
					restRequest.AddHeader("ClientTag", "UUNOLkV4cGVydEFwcA==");

					CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

					var restResponse = await client.ExecuteAsync<TransactionResponse>(restRequest, cancellationTokenSource.Token);

					if (restResponse.ResponseStatus == ResponseStatus.Completed)
					{
						TransactionResponse transactionResponse = JsonConvert.DeserializeObject<TransactionResponse>(restResponse.Content);

						if (transactionResponse.Acknowledge == CoreFX.Messages.AcknowledgeType.Success)
						{
							if (transactionResponse.DAT.RES_OUTPUT != null && transactionResponse.DAT.RES_OUTPUT.Count > 0)
							{
								foreach (RES_OUTPUT item in transactionResponse.DAT.RES_OUTPUT)
								{
									try
									{
										result.Add(item.RES_FIELD_ID, item.RES_DAT as JToken);
									}
									catch (Exception exception)
									{
										result.Clear();
										result.Add("HasException", JObject.Parse(string.Concat("{", $"\"ErrorMessage\": \"Ok|Completed|{string.Concat(item.RES_FIELD_ID, " ", exception.Message)}\"", "}")));
										break;
									}
								}
							}
						}
						else
						{
							string errorMessage = string.Concat("응답 오류 - ", transactionResponse.ExceptionText);
							result.Add("HasException", JObject.Parse(string.Concat("{", $"\"ErrorMessage\": \"Ok|Completed|{errorMessage}\"", "}")));
						}
					}
					else
					{
						string errorMessage = restResponse.ErrorMessage;
						ResponseStatus responseStatus = restResponse.ResponseStatus;
						HttpStatusCode statusCode = restResponse.StatusCode;

						result.Add("HasException", JObject.Parse(string.Concat("{", $"\"ErrorMessage\": \"{statusCode.ToString()}|{responseStatus.ToString()}|{errorMessage}\"", "}")));
					}
				}
				else
				{
					string errorMessage = $"SystemID: {transactionObject.SystemID}, DomainServerType: {TransactionConfig.DomainServerType}에 대한 접속 정보를 확인할 수 없습니다";
					result.Add("HasException", JObject.Parse(string.Concat("{", $"\"ErrorMessage\": \"Ok|Completed|{errorMessage}\"", "}")));
				}
			}
			catch (Exception exception)
			{
				error = $"{exception.ToString()}, Result - {typeResult}";
				result.Add("HasException", JObject.Parse(string.Concat("{", $"\"ErrorMessage\": \"{HttpStatusCode.Gone.ToString()}|None|{exception.Message}\"", "}")));
			}

			return result;
		}

		public async Task<(string, DataSet)> ExecuteTransactionDataSet(string requestID, string businessServerUrl, TransactionClientObject transactionObject)
		{
			(string, DataSet) result = ("", null);
			try
			{
				transactionObject.ReturnType = string.IsNullOrEmpty(transactionObject.ReturnType) == true ? "Json" : transactionObject.ReturnType;

				if (transactionObject.InputsItemCount.Count == 0)
				{
					transactionObject.InputsItemCount.Add(transactionObject.Inputs.Count);
				}

				transactionObject.RequestID = requestID;

				TransactionRequest transactionRequest = CreateTransactionRequest("REPLY", transactionObject);

				RestClient client = new RestClient();
				// client.Proxy = BypassWebProxy.Default;
				var restRequest = new RestRequest(businessServerUrl, Method.POST);
				restRequest.AddJsonBody(transactionRequest);

				restRequest.AddHeader("Content-Type", "qrame/json-transact");
				restRequest.AddHeader("cache-control", "no-cache");
				restRequest.AddHeader("X-Requested-With", "QAF ServiceClient");
				restRequest.AddHeader("ClientTag", "UUNOLkV4cGVydEFwcA==");

				CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

				var restResponse = await client.ExecuteAsync<TransactionResponse>(restRequest, cancellationTokenSource.Token);

				if (restResponse.ResponseStatus == ResponseStatus.Completed)
				{
					using (MemoryStream stream = new MemoryStream(restResponse.RawBytes))
					{
						result.Item2 = new DataSet();
						result.Item2.ReadXml(stream, XmlReadMode.Auto);
					}
				}
				else
				{
					string errorMessage = restResponse.ErrorMessage;
					ResponseStatus responseStatus = restResponse.ResponseStatus;
					HttpStatusCode statusCode = restResponse.StatusCode;

					result.Item1 = $"{statusCode.ToString()}, {responseStatus.ToString()}, {errorMessage}";
				}
			}
			catch (Exception exception)
			{
				result.Item2 = null;
				result.Item1 = $"{HttpStatusCode.Gone.ToString()}, None, {exception.Message}";
			}

			return result;
		}

		public async Task<Dictionary<string, JToken>> ExecuteTransactionJson(string requestID, string businessServerUrl, TransactionClientObject transactionObject)
		{
			Dictionary<string, JToken> result = new Dictionary<string, JToken>();
			try
			{
				transactionObject.ReturnType = string.IsNullOrEmpty(transactionObject.ReturnType) == true ? "Json" : transactionObject.ReturnType;

				if (transactionObject.InputsItemCount.Count == 0)
				{
					transactionObject.InputsItemCount.Add(transactionObject.Inputs.Count);
				}

				transactionObject.RequestID = requestID;

				TransactionRequest transactionRequest = CreateTransactionRequest("REPLY", transactionObject);

				RestClient client = new RestClient();
				// client.Proxy = BypassWebProxy.Default;
				var restRequest = new RestRequest(businessServerUrl, Method.POST);
				restRequest.AddJsonBody(transactionRequest);

				restRequest.AddHeader("Content-Type", "qrame/json-transact");
				restRequest.AddHeader("cache-control", "no-cache");
				restRequest.AddHeader("X-Requested-With", "QAF ServiceClient");
				restRequest.AddHeader("ClientTag", "UUNOLkV4cGVydEFwcA==");

				CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

				var restResponse = await client.ExecuteAsync<TransactionResponse>(restRequest, cancellationTokenSource.Token);

				if (restResponse.ResponseStatus == ResponseStatus.Completed)
				{
					TransactionResponse transactionResponse = JsonConvert.DeserializeObject<TransactionResponse>(restResponse.Content);

					if (transactionResponse.Acknowledge == CoreFX.Messages.AcknowledgeType.Success)
					{
						if (transactionResponse.DAT.RES_OUTPUT != null && transactionResponse.DAT.RES_OUTPUT.Count > 0)
						{
							foreach (RES_OUTPUT item in transactionResponse.DAT.RES_OUTPUT)
							{
								try
								{
									result.Add(item.RES_FIELD_ID, item.RES_DAT as JToken);
								}
								catch (Exception exception)
								{
									result.Clear();
									result.Add("HasException", JObject.Parse(string.Concat("{", $"\"ErrorMessage\": \"Ok|Completed|{string.Concat(item.RES_FIELD_ID, " ", exception.Message)}\"", "}")));
									break;
								}
							}
						}
					}
					else
					{
						string errorMessage = string.Concat("응답 오류 - ", transactionResponse.ExceptionText);
						result.Add("HasException", JObject.Parse(string.Concat("{", $"\"ErrorMessage\": \"Ok|Completed|{errorMessage}\"", "}")));
					}
				}
				else
				{
					string errorMessage = restResponse.ErrorMessage;
					ResponseStatus responseStatus = restResponse.ResponseStatus;
					HttpStatusCode statusCode = restResponse.StatusCode;

					result.Add("HasException", JObject.Parse(string.Concat("{", $"\"ErrorMessage\": \"{statusCode.ToString()}|{responseStatus.ToString()}|{errorMessage}\"", "}")));
				}
			}
			catch (Exception exception)
			{
				result.Add("HasException", JObject.Parse(string.Concat("{", $"\"ErrorMessage\": \"{HttpStatusCode.Gone.ToString()}|None|{exception.Message}\"", "}")));
			}

			return result;
		}

		public async Task<string> ExecuteTransactionNone(string requestID, string businessServerUrl, TransactionClientObject transactionObject, int timeout = 10000)
		{
			string result = null;
			try
			{
				transactionObject.ReturnType = string.IsNullOrEmpty(transactionObject.ReturnType) == true ? "Json" : transactionObject.ReturnType;

				if (transactionObject.InputsItemCount.Count == 0)
				{
					transactionObject.InputsItemCount.Add(transactionObject.Inputs.Count);
				}

				transactionObject.RequestID = requestID;

				TransactionRequest transactionRequest = CreateTransactionRequest("REPLY", transactionObject);

				RestClient client = new RestClient();
				// client.Proxy = BypassWebProxy.Default;
				var restRequest = new RestRequest(businessServerUrl, Method.POST);
				restRequest.AddJsonBody(transactionRequest);

				restRequest.AddHeader("Content-Type", "qrame/json-transact");
				restRequest.AddHeader("cache-control", "no-cache");
				restRequest.AddHeader("X-Requested-With", "QAF ServiceClient");
				restRequest.AddHeader("ClientTag", "UUNOLkV4cGVydEFwcA==");

				CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
				cancellationTokenSource.CancelAfter(timeout);
				var restResponse = await client.ExecuteAsync<TransactionResponse>(restRequest, cancellationTokenSource.Token);

				if (restResponse.ResponseStatus == ResponseStatus.Completed)
				{
					Serilog.Log.Information($"ExecuteTransactionNone: {requestID}, Done");
				}
				else
				{
					result = restResponse.ErrorMessage;
					Serilog.Log.Warning($"ExecuteTransactionNone: {requestID}, ErrorMessage: {restResponse.ErrorMessage}, ResponseStatus: {restResponse.ResponseStatus}, StatusCode: {restResponse.StatusCode}");
				}
			}
			catch (Exception exception)
			{
				result = exception.ToString();
				Serilog.Log.Error(exception, $"ExecuteTransactionNone: {requestID}, message: {result}");
			}

			return result;
		}

		private TransactionRequest CreateTransactionRequest(string action, TransactionClientObject transactionObject)
		{
			TransactionRequest transactionRequest = new TransactionRequest();
			transactionRequest.AccessTokenID = "";
			transactionRequest.Action = action;
			transactionRequest.ClientTag = string.Concat(TransactionConfig.Transaction.SystemCode, "|", TransactionConfig.Transaction.MachineName, "|", TransactionConfig.Program.ProgramVersion);
			transactionRequest.LoadOptions = null;
			transactionRequest.RequestID = Guid.NewGuid().ToString();
			transactionRequest.Version = TransactionConfig.Transaction.ProtocolVersion;

			transactionRequest.SH.CLNT_IPAD = TransactionConfig.Program.IPAddress;
			transactionRequest.SH.CLNT_MAC = TransactionConfig.Program.MacAddress;
			transactionRequest.SH.ENV_INF_DSCD = TransactionConfig.Transaction.RunningEnvironment;
			transactionRequest.SH.FST_TLM_REQ_DTM = DateTime.Now.ToString("yyyyMMddHHmmssfff");
			transactionRequest.SH.FST_TMS_SYS_CD = TransactionConfig.Transaction.SystemCode;
			transactionRequest.SH.GLBL_ID = transactionObject.RequestID;
			transactionRequest.SH.GLBL_ID_PRG_SRNO = 1;
			transactionRequest.SH.INTF_ID = TransactionConfig.Transaction.SystemInterfaceID;
			transactionRequest.SH.LANG_DSCD = TransactionConfig.Program.LanguageID;
			transactionRequest.SH.MD_KDCD = TransactionConfig.Transaction.MachineTypeID;
			transactionRequest.SH.TLM_ENCY_DSCD = TransactionConfig.Transaction.DataEncryptionYN;
			transactionRequest.SH.TLM_REQ_DTM = DateTime.Now.ToString("yyyyMMddHHmmssfff");

			transactionRequest.TH.BIZ_ID = transactionObject.BusinessID;
			transactionRequest.TH.EXNK_DSCD = TransactionConfig.Program.NetworkInterfaceType;
			transactionRequest.TH.FUNC_CD = transactionObject.FunctionID;
			transactionRequest.TH.LQTY_DAT_PRC_DIS = "N";
			transactionRequest.TH.MSK_NTGT_TRN_YN = "Y";
			transactionRequest.TH.OPR_NO = TransactionConfig.OperatorUser.UserID;
			transactionRequest.TH.PGM_ID = transactionObject.ProgramID;
			transactionRequest.TH.RLPE_SQCN = 1;
			transactionRequest.TH.SMLT_TRN_DSCD = "N";
			transactionRequest.TH.TRM_BRNO = TransactionConfig.Program.TerminalBranchCode; // "AccessTokenID 발급 기준이 되며, 자산관리ID로 사용가능 [국가번호][지역번호][점번호][단말종류][순번]";
			transactionRequest.TH.TRN_CD = transactionObject.TransactionID;
			transactionRequest.TH.TRN_SCRN_CD = transactionObject.ScreenID;
			transactionRequest.TH.DAT_FMT = string.IsNullOrEmpty(TransactionConfig.Transaction.DataFormat) == true ? "J": TransactionConfig.Transaction.DataFormat;
			transactionRequest.TH.CRYPTO_DSCD = string.IsNullOrEmpty(TransactionConfig.Transaction.CryptoCode) == true ? "P" : TransactionConfig.Transaction.CryptoCode;
			transactionRequest.TH.CRYPTO_KEY = string.IsNullOrEmpty(TransactionConfig.Transaction.CryptoKey) == true ? "" : TransactionConfig.Transaction.CryptoKey;

			transactionRequest.DAT.REQ_TX_MAP_ID = transactionObject.TransactionMapID;
			transactionRequest.DAT.REQ_INPUT_CNT = transactionObject.InputsItemCount;
			transactionRequest.DAT.REQ_INPUT = new List<List<REQ_INPUT>>();

			foreach (var inputs in transactionObject.Inputs)
			{
				List<REQ_INPUT> reqInputs = new List<REQ_INPUT>();
				foreach (var item in inputs)
				{
					reqInputs.Add(new REQ_INPUT() { REQ_FIELD_ID = item.prop, REQ_FIELD_DAT = item.val });
				}
				transactionRequest.DAT.REQ_INPUT.Add(reqInputs);
			}

			return transactionRequest;
		}

		public void Dispose()
		{
		}
	}

	public class TransactionClientObject
	{
		[JsonProperty(Required = Required.DisallowNull)]
		public string ProgramID { get; set; }

		[JsonProperty(Required = Required.DisallowNull)]
		public string BusinessID { get; set; }

		[JsonProperty(Required = Required.DisallowNull)]
		public string SystemID { get; set; }

		[JsonProperty(Required = Required.DisallowNull)]
		public string TransactionID { get; set; }

		[JsonProperty(Required = Required.DisallowNull)]
		public string FunctionID { get; set; }

		[JsonProperty(Required = Required.DisallowNull)]
		public string ScreenID { get; set; }

		public string RequestID { get; set; }

		public string ReturnType { get; set; }

		public string TransactionMapID { get; set; }

		public List<int> InputsItemCount = new List<int>();

		public List<List<ServiceParameter>> Inputs = new List<List<ServiceParameter>>();
	}

	public class ServiceParameter
	{
		public string prop;
		public object val;
	}

	public static class TransactionClientExtensions
	{
		public static void Add(this List<ServiceParameter> parameters, string parameterName, object value)
		{
			parameters.Add(new ServiceParameter() { prop = parameterName, val = value });
		}
	}
}
