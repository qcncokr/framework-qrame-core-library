using Microsoft.Extensions.CommandLineUtils;

using Newtonsoft.Json;

using Qrame.CoreFX.Library.MessageContract.DataObject;
using Qrame.CoreFX.Library.MessageContract.Message;
using Qrame.CoreFX.ExtensionMethod;

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Qrame.CoreFX.Library
{
    public class BaseConsole
    {
        protected DynamicRequest ConsoleRequest;
        private bool isMainExecute = false;
        private CommandLineApplication app = new CommandLineApplication();

        protected string HelpText
        {
            get
            {
                return app.ExtendedHelpText;
            }
            set
            {
                app.ExtendedHelpText = value;
            }
        }

        protected string Description
        {
            get
            {
                return app.Description;
            }
            set
            {
                app.Description = value;
            }
        }

        public BaseConsole()
        {
            app.Name = Assembly.GetEntryAssembly().GetName().Name;
            app.HelpOption("-?|-h|--help");
            app.ExtendedHelpText = "ExitCode가 0인 정상 표준 출력 결과는 DataSet 또는 DynamicResponse JSON" + Environment.NewLine + Environment.NewLine;
            app.VersionOption("-v|--version", () =>
            {
                return Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
            });

            var param = app.Option("-p|--param <value>", "b (base64 [기본값]), p (plain)", CommandOptionType.SingleValue);
            var format = app.Option("-f|--format <value>", "입력 값이 JSON 데이터이면 1 [기본값], 파일이면 0", CommandOptionType.SingleValue);
            var key = app.Option("-k|--key <value>", "실행 컨텍스트 식별키", CommandOptionType.SingleValue);

            app.Command("ECHO00", (command) =>
            {
                CommandOption bypass = command.Option("-r|--return <value>", "입력값 반환 매개변수", CommandOptionType.SingleValue);

                command.OnExecute(() =>
                {
                    string requestID = key.HasValue() == true ? key.Value() : "ECHO00-" + DateTime.Now.ToString("yyyyMMddhhmmssffffff");
                    DynamicResponse response = new DynamicResponse();
                    response.CorrelationID = requestID;

                    try
                    {
                        response.ResultObject = $"ServerDate: {DateTime.Now.ToString()}, ReturnValue: {bypass.Value()}, Description: {app.Description}";
                        Console.Out.WriteLine(JsonConvert.SerializeObject(response));
                    }
                    catch (Exception exception)
                    {
                        Console.Error.WriteLine(exception);
                    }

                    return 0;
                });
            });

            var argument = app.Argument("argument", "DynamicRequest JSON");

            /*
            exitCode = program.ExecDynamic(args, (request) =>
            {
                int result = 1;

                // DynamicRequest 거래
                if (request is DynamicRequest)
                {
                    string aiServiceID = args[0];
                    string trainDataFileName = configuration.GetSection("MLData")[args[0]];

                    if (string.IsNullOrEmpty(trainDataFileName) == true)
                    {
                        Log.Error("AIServiceID 또는 MLData 정보 필요");
                        Environment.Exit(-1);
                    }

                    string trainDataPath = configuration.GetSection("AppSettings")["TrainDataPath"];
                    string qcnConnectionString = configuration.GetSection("ConnectionStrings")["DYETEC_QCN"];
                    string homeConnectionString = configuration.GetSection("ConnectionStrings")["DYETEC_HOME"];

                    DataTable dataTableSQL = new DataTable();
                    using (DataSet dataSetSQL = new DataSet())
                    {
                        string sqlFilePath = Path.Combine(AppContext.BaseDirectory, "SQL.xml");
                        if (File.Exists(sqlFilePath) == true)
                        {
                            dataSetSQL.ReadXml(sqlFilePath);
                            dataTableSQL = dataSetSQL.Tables[0];
                        }
                        else
                        {
                            Log.Error("SqlFilePath 확인 필요");
                            return result;
                        }
                    }

                    // 학습 데이터 조회
                    string sqlG01 = dataTableSQL.AsEnumerable().Where(row => row.Field<string>("QueryID") == "G01").First().Field<string>("SQL");

                    // TrainDataStatus 상태를 변경
                    string sqlU01 = dataTableSQL.AsEnumerable().Where(row => row.Field<string>("QueryID") == "U01").First().Field<string>("SQL");

                    using (SqlServerClient sqlServerClient = new SqlServerClient(qcnConnectionString))
                    {
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        parameters.Add(sqlServerClient.CreateParameter(SqlDbType.VarChar, "@AIServiceID", aiServiceID));
                        using (DataSet dataSet = sqlServerClient.ExecuteDataSet(sqlG01, CommandType.Text, parameters))
                        using (DataTable dataTable = dataSet.Tables[0])
                        {
                            if (dataTable.Rows.Count > 0)
                            {
                                Log.Information("TrainDataStatus 상태를 '진행중'으로 변경");
                                // TrainDataStatus 상태를 "진행중"으로 변경
                                parameters.Clear();
                                parameters.Add(sqlServerClient.CreateParameter(SqlDbType.VarChar, "@TrainDataStatus", "2"));
                                parameters.Add(sqlServerClient.CreateParameter(SqlDbType.VarChar, "@AIServiceID", aiServiceID));
                                sqlServerClient.ExecuteNonQuery(sqlU01, CommandType.Text, parameters);

                                Log.Information("학습 데이터 쿼리 실행후 CSV 파일 생성");
                                string trainDataSQL = dataTable.Rows[0]["TrainDataSQL"].ToString();

                                using (SqlServerClient sqlServerClient1 = new SqlServerClient(homeConnectionString))
                                {
                                    using (DataSet dataSet1 = sqlServerClient.ExecuteDataSet(trainDataSQL, CommandType.Text))
                                    using (DataTable dataTable1 = dataSet1.Tables[0])
                                    {
                                        string trainDataFilePath = Path.Combine(trainDataPath, aiServiceID + ".csv");
                                        using (StreamWriter writer = new StreamWriter(trainDataFilePath, false, Encoding.UTF8))
                                        {
                                            CreateCSVFile(dataTable1, writer, true);
                                        }
                                    }
                                }

                                Log.Information("TrainDataStatus 상태를 '완료'으로 변경");
                                // TrainDataStatus 상태를 "완료"로 변경
                                parameters.Clear();
                                parameters.Add(sqlServerClient.CreateParameter(SqlDbType.VarChar, "@TrainDataStatus", "3"));
                                parameters.Add(sqlServerClient.CreateParameter(SqlDbType.VarChar, "@AIServiceID", aiServiceID));
                                sqlServerClient.ExecuteNonQuery(sqlU01, CommandType.Text, parameters);

                            }
                            else
                            {
                                Log.Error("AIServiceID에 대한 데이터 확인 필요");
                                return -1;
                            }
                        }
                    }

                    // 업무 로직
                    using (DataSet dataSet = new DataSet())
                    using (DataTable codeGroup = new DataTable("DataTable1"))
                    {
                        codeGroup.AddColumn("ReturnMessage", typeof(string));

                        DataRow row = codeGroup.NewRow();
                        row.ItemArray = new object[] { "ok" };
                        codeGroup.Rows.Add(row);
                        dataSet.Tables.Add(codeGroup);

                        Console.Out.WriteLine(JsonConvert.SerializeObject(dataSet));
                    }

                    result = 0;
                }
                return result;
            });
            */
            app.OnExecute(() =>
            {
                isMainExecute = true;

                if (param.HasValue() == false || param.HasValue() == false)
                {
                    return 1;
                }
                else
                {
                    string json = "";
                    bool isBase64Text = param.Value().Trim().ToLower() == "b";
                    bool isDataFormat = format.Value().Trim().ToLower() == "1";

                    try
                    {
                        if (isDataFormat == true)
                        {
                            json = argument.Value;
                        }
                        else
                        {
                            if (File.Exists(argument.Value) == true)
                            {
                                json = File.ReadAllText(argument.Value);
                            }
                            else
                            {
                                Console.Error.WriteLine($"{argument.Value} JSON 데이터 파일 없음");
                                return -1;
                            }
                        }

                        if (isBase64Text == true)
                        {
                            json = argument.Value.DecodeBase64();
                        }

                        ConsoleRequest = JsonConvert.DeserializeObject<DynamicRequest>(json);
                    }
                    catch (Exception exception)
                    {
                        Console.Error.WriteLine($"isPlainText: {isBase64Text}, argument: {argument}, exception: {exception.Message}");
                        return -1;
                    }
                }

                return 0;
            });
        }

        /*
                program.AddCommand("NC01", 0, $"{programName} NC0100 -p b <List<DynamicParameters> JSON>", (command) =>
                {
                    command.OnExecute(() =>
                    {
                        int result = 1;

                        var commandArguments = command.Arguments;
                        var commandOptions = command.GetOptions();
                        string param = commandOptions.FirstOrDefault(p => p.ShortName == "p")?.Value();
                        string format = commandOptions.FirstOrDefault(p => p.ShortName == "f")?.Value();
                        string key = commandOptions.FirstOrDefault(p => p.ShortName == "k")?.Value();
                        string argument = commandArguments[0].Value;

                        string jsonArgument = argument.DecodeBase64();
                        List<DynamicParameter> dynamicParameters = JsonConvert.DeserializeObject<List<DynamicParameter>>(jsonArgument);

                        string aiServiceID = program.ParameterValue(dynamicParameters, "AIServiceID").ToString();
                        string trainDataFileName = configuration.GetSection("MLData")[aiServiceID];

                        if (string.IsNullOrEmpty(trainDataFileName) == true)
                        {
                            Log.Error("AIServiceID 또는 MLData 정보 필요");
                            Environment.Exit(-1);
                        }

                        string trainDataPath = configuration.GetSection("AppSettings")["TrainDataPath"];
                        string qcnConnectionString = configuration.GetSection("ConnectionStrings")["DYETEC_QCN"];
                        string homeConnectionString = configuration.GetSection("ConnectionStrings")["DYETEC_HOME"];

                        DataTable dataTableSQL = new DataTable();
                        using (DataSet dataSetSQL = new DataSet())
                        {
                            string sqlFilePath = Path.Combine(AppContext.BaseDirectory, "SQL.xml");
                            if (File.Exists(sqlFilePath) == true)
                            {
                                dataSetSQL.ReadXml(sqlFilePath);
                                dataTableSQL = dataSetSQL.Tables[0];
                            }
                            else
                            {
                                Log.Error("SqlFilePath 확인 필요");
                                return Task.FromResult(result);
                            }
                        }

                        // 학습 데이터 조회
                        string sqlG01 = dataTableSQL.AsEnumerable().Where(row => row.Field<string>("QueryID") == "G01").First().Field<string>("SQL");

                        // TrainDataStatus 상태를 변경
                        string sqlU01 = dataTableSQL.AsEnumerable().Where(row => row.Field<string>("QueryID") == "U01").First().Field<string>("SQL");

                        using (SqlServerClient sqlServerClient = new SqlServerClient(qcnConnectionString))
                        {
                            List<SqlParameter> parameters = new List<SqlParameter>();
                            parameters.Add(sqlServerClient.CreateParameter(SqlDbType.VarChar, "@AIServiceID", aiServiceID));
                            using (DataSet dataSet = sqlServerClient.ExecuteDataSet(sqlG01, CommandType.Text, parameters))
                            using (DataTable dataTable = dataSet.Tables[0])
                            {
                                if (dataTable.Rows.Count > 0)
                                {
                                    Log.Information("TrainDataStatus 상태를 '진행중'으로 변경");
                                    // TrainDataStatus 상태를 "진행중"으로 변경
                                    parameters.Clear();
                                    parameters.Add(sqlServerClient.CreateParameter(SqlDbType.VarChar, "@TrainDataStatus", "2"));
                                    parameters.Add(sqlServerClient.CreateParameter(SqlDbType.VarChar, "@AIServiceID", aiServiceID));
                                    sqlServerClient.ExecuteNonQuery(sqlU01, CommandType.Text, parameters);

                                    Log.Information("학습 데이터 쿼리 실행후 CSV 파일 생성");
                                    string trainDataSQL = dataTable.Rows[0]["TrainDataSQL"].ToString();

                                    using (SqlServerClient sqlServerClient1 = new SqlServerClient(homeConnectionString))
                                    {
                                        using (DataSet dataSet1 = sqlServerClient.ExecuteDataSet(trainDataSQL, CommandType.Text))
                                        using (DataTable dataTable1 = dataSet1.Tables[0])
                                        {
                                            string trainDataFilePath = Path.Combine(trainDataPath, aiServiceID + ".csv");
                                            using (StreamWriter writer = new StreamWriter(trainDataFilePath, false, Encoding.UTF8))
                                            {
                                                CreateCSVFile(dataTable1, writer, true);
                                            }
                                        }
                                    }

                                    Log.Information("TrainDataStatus 상태를 '완료'으로 변경");
                                    // TrainDataStatus 상태를 "완료"로 변경
                                    parameters.Clear();
                                    parameters.Add(sqlServerClient.CreateParameter(SqlDbType.VarChar, "@TrainDataStatus", "3"));
                                    parameters.Add(sqlServerClient.CreateParameter(SqlDbType.VarChar, "@AIServiceID", aiServiceID));
                                    sqlServerClient.ExecuteNonQuery(sqlU01, CommandType.Text, parameters);

                                }
                                else
                                {
                                    Log.Error("AIServiceID에 대한 데이터 확인 필요");
                                    return Task.FromResult(-1);
                                }
                            }
                        }

                        // 업무 로직
                        using (DataSet dataSet = new DataSet())
                        using (DataTable codeGroup = new DataTable("DataTable1"))
                        {
                            codeGroup.AddColumn("ReturnMessage", typeof(string));

                            DataRow row = codeGroup.NewRow();
                            row.ItemArray = new object[] { "ok" };
                            codeGroup.Rows.Add(row);
                            dataSet.Tables.Add(codeGroup);

                            Console.Out.WriteLine(JsonConvert.SerializeObject(dataSet));
                        }

                        result = 0;
                        return Task.FromResult(result);
                    });
                });

                exitCode = program.ExecCommand(args);
         */
        protected void AddCommand(string name, int seq, string commandUsage, Action<CommandLineApplication> configuration, bool throwOnUnexpectedArg = true)
        {
            if (string.IsNullOrEmpty(commandUsage) == false)
            {
                HelpText = HelpText + commandUsage + Environment.NewLine;
            }

            var cli = app.Command($"{name}{seq.ToString().PadLeft(2, '0')}", configuration, throwOnUnexpectedArg);

            cli.Option("-p|--param <value>", "b (base64 [기본값]), p (plain)", CommandOptionType.SingleValue);
            cli.Option("-f|--format <value>", "입력 값이 JSON 데이터이면 1 [기본값], 파일이면 0", CommandOptionType.SingleValue);
            cli.Option("-k|--key <value>", "실행 컨텍스트 식별키", CommandOptionType.SingleValue);
            cli.Argument("argument", "ConsoleMap JSON");
        }

        protected int ExecCommand(string[] args)
        {
            int exitCode = -1;
            try
            {
                List<string> cleanArguments = new List<string>();

                foreach (string arg in args)
                {
                    if (string.IsNullOrEmpty(arg) == false && arg.IndexOf("-debug") == -1 && arg.IndexOf("-delay") == -1) {
                        cleanArguments.Add(arg);
                    }
                }

                exitCode = app.Execute(cleanArguments.ToArray());
            }
            catch (CommandParsingException ex)
            {
                Console.Error.WriteLine($"CommandParsingException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Exception: {0}", ex.Message);
            }

            return exitCode;
        }

        protected int ExecDynamic(string[] args, Func<dynamic, int> invoke)
        {
            int exitCode = -1;
            try
            {
                exitCode = app.Execute(args);
                if (isMainExecute == true && exitCode == 0)
                {
                    exitCode = invoke(ConsoleRequest);
                }
                else if(isMainExecute == true && exitCode == 1)
                {
                    exitCode = invoke(args);
                }
            }
            catch (CommandParsingException ex)
            {
                Console.Error.WriteLine($"CommandParsingException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Exception: {0}", ex.Message);
            }

            return exitCode;
        }

        protected object ParameterValue(List<DynamicParameter> parameters, string parameterName)
        {
            object result = null;
            foreach (DynamicParameter item in parameters)
            {
                if (item.ParameterName == parameterName)
                {
                    result = item.Value;
                    break;
                }
            }

            return result;
        }
    }
}
