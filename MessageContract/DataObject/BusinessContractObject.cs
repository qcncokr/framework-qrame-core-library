using Newtonsoft.Json;

using Qrame.CoreFX.Library.MessageContract.Converter;

using System;
using System.Collections.Generic;

//    using Qrame.CoreFX.Library.Contract;
//    var businessContract = BusinessContract.FromJson(jsonString);

namespace Qrame.CoreFX.Library.MessageContract.DataObject
{
    // 업무 프로토콜 (Transact Request / Response와 매핑 작업 필요)
    public class BusinessContract
    {
        [JsonProperty("ApplicationID")]
        public string ApplicationID { get; set; }

        [JsonProperty("ProjectID")]
        public string ProjectID { get; set; }

        [JsonProperty("TransactionProjectID")]
        public string TransactionProjectID { get; set; }

        [JsonProperty("TransactionID")]
        public string TransactionID { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("ModifiedDate")]
        public string ModifiedDate { get; set; }

        [JsonProperty("Services")]
        public List<TransactionInfo> Services { get; set; }

        [JsonProperty("Models")]
        public List<Model> Models { get; set; }

        public static BusinessContract FromJson(string json)
        {
            return JsonConvert.DeserializeObject<BusinessContract>(json, ConverterSetting.Settings);
        }
    }

    public class Model
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Owner")]
        public string Owner { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("ModifiedDate")]
        public DateTimeOffset ModifiedDate { get; set; }

        [JsonProperty("Columns")]
        public List<DbColumn> Columns { get; set; }
    }

    public class DbColumn
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("DataType")]
        public string DataType { get; set; }

        [JsonProperty("Length")]
        public int Length { get; set; }

        [JsonProperty("Require")]
        public bool Require { get; set; }

        [JsonProperty("Default")]
        public string Default { get; set; }
    }

    [Serializable]
    public class TransactionInfo
    {
        [JsonProperty("ServiceID")]
        public string ServiceID { get; set; }

        [JsonProperty("Authorize")]
        public bool Authorize { get; set; }

        [JsonProperty("TransactionType")]
        public string TransactionType { get; set; }

        [JsonProperty("TransactionScope")]
        public bool TransactionScope { get; set; }

        [JsonProperty("SequentialOption")]
        public List<SequentialOption> SequentialOptions { get; set; }

        [JsonProperty("ReturnType")]
        public string ReturnType { get; set; }

        [JsonProperty("AccessScreenID")]
        public List<string> AccessScreenID { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("TransactionLog")]
        public bool TransactionLog { get; set; }

        [JsonProperty("Inputs")]
        public List<ModelInputContract> Inputs { get; set; }

        [JsonProperty("Outputs")]
        public List<ModelOutputContract> Outputs { get; set; }
    }

    /*
	"SequentialOption": [
		{
			"TransactionProjectID": "ZZD",
			"TransactionID": "ZZA010",
			"ServiceID": "L01",
			"TransactionType": "D",
			"ServiceInputFields": [ 0 ],
			"ServiceOutputs": [
				{
					"ModelID": "Dynamic",
					"Fields": [
					],
					"Type": "Form"
				}
			],
			"ResultHandling": "FieldMapping", // ResultSet, FieldMapping
			"TargetInputFields": [ 0 ], // FieldMapping은 무조건 ServiceOutputs이 Form 이어야 한다
			"ResultOutputFields": [] // ResultSet은 ServiceOutputs와 Outputs 타입과 호환이 되어야 한다
		},
     */
    [Serializable]
    public partial class SequentialOption
    {
        [JsonProperty("TransactionProjectID")]
        public string TransactionProjectID { get; set; }

        [JsonProperty("TransactionID")]
        public string TransactionID { get; set; }

        [JsonProperty("ServiceID")]
        public string ServiceID { get; set; }

        [JsonProperty("TransactionType")]
        public string TransactionType { get; set; }

        [JsonProperty("ServiceInputFields")]
        public List<int> ServiceInputFields { get; set; }

        [JsonProperty("ServiceOutputs")]
        public List<ModelOutputContract> ServiceOutputs { get; set; }

        [JsonProperty("ResultHandling")]
        public string ResultHandling { get; set; }

        [JsonProperty("TargetInputFields")]
        public List<int> TargetInputFields { get; set; }

        [JsonProperty("ResultOutputFields")]
        public List<int> ResultOutputFields { get; set; }
    }

    [Serializable]
    public class BaseFieldMapping
    {
        [JsonProperty("BaseSequence")]
        public string BaseSequence { get; set; }

        [JsonProperty("SourceFieldID")]
        public string SourceFieldID { get; set; }

        [JsonProperty("TargetFieldID")]
        public string TargetFieldID { get; set; }
    }

    [Serializable]
    public class ModelInputContract
    {
        [JsonProperty("ModelID")]
        public string ModelID { get; set; }

        [JsonProperty("Fields")]
        public List<string> Fields { get; set; }

        [JsonProperty("BearerFields")]
        public List<string> BearerFields { get; set; }

        [JsonProperty("TestValues", NullValueHandling = NullValueHandling.Ignore)]
        public List<TestValue> TestValues { get; set; }

        [JsonProperty("DefaultValues", NullValueHandling = NullValueHandling.Ignore)]
        public List<DefaultValue> DefaultValues { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("BaseFieldMappings", NullValueHandling = NullValueHandling.Ignore)]
        public List<BaseFieldMapping> BaseFieldMappings { get; set; }

        [JsonProperty("ParameterHandling")]
        public string ParameterHandling { get; set; } // Rejected, ByPassing, DefaultValue

        [JsonProperty("IgnoreResult")]
        public bool IgnoreResult { get; set; }
    }

    [Serializable]
    public class ModelOutputContract
    {
        [JsonProperty("ModelID")]
        public string ModelID { get; set; }

        [JsonProperty("Fields")]
        public List<string> Fields { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }
    }

    [Serializable]
    public struct TestValue
    {
        public int? Integer;
        public string String;
        public bool? Boolean;

        public static implicit operator TestValue(int Integer) => new TestValue { Integer = Integer };
        public static implicit operator TestValue(string String) => new TestValue { String = String };
        public static implicit operator TestValue(bool Boolean) => new TestValue { Boolean = Boolean };
        public bool IsNull => Integer == null && String == null && Boolean == null;
    }

    [Serializable]
    public struct DefaultValue
    {
        public int? Integer;
        public string String;
        public bool? Boolean;

        public static implicit operator DefaultValue(int Integer) => new DefaultValue { Integer = Integer };
        public static implicit operator DefaultValue(string String) => new DefaultValue { String = String };
        public static implicit operator DefaultValue(bool Boolean) => new DefaultValue { Boolean = Boolean };
        public bool IsNull => Integer == null && String == null && Boolean == null;
    }

    public static class BusinessContractSerialize
    {
        public static string ToJson(this BusinessContract self)
        {
            return JsonConvert.SerializeObject(self, Formatting.Indented, ConverterSetting.Settings);
        }
    }
}
