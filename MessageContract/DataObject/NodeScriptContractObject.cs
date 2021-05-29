using Newtonsoft.Json;

using Qrame.Core.Library.MessageContract.Converter;

using System;
using System.Collections.Generic;


//    using Qrame.Core.Library.Contract;
//    var nodeScriptContract = NodeScriptContract.FromJson(jsonString);

namespace Qrame.Core.Library.MessageContract.DataObject
{
    public partial class NodeScriptContract
    {
        [JsonProperty("Header")]
        public NodeHeader Header { get; set; }

        [JsonProperty("Commands")]
        public List<NodeCommand> Commands { get; set; }

        public static NodeScriptContract FromJson(string json) => JsonConvert.DeserializeObject<NodeScriptContract>(json, ConverterSetting.Settings);
    }

    public partial class NodeCommand
    {
        [JsonProperty("ID")]
        public string ID { get; set; }

        [JsonProperty("Seq")]
        public int Seq { get; set; }

        [JsonProperty("Use")]
        public bool Use { get; set; }

        [JsonProperty("Timeout")]
        public int Timeout { get; set; }

        [JsonProperty]
        public string BeforeTransaction { get; set; }

        [JsonProperty]
        public string AfterTransaction { get; set; }

        [JsonProperty]
        public string FallbackTransaction { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("ModifiedDateTime")]
        public DateTimeOffset ModifiedDateTime { get; set; }

        [JsonProperty("Params")]
        public List<NodeParam> Params { get; set; }
    }

    public partial class NodeParam
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("length")]
        public int Length { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public partial class NodeHeader
    {
        [JsonProperty("ApplicationID")]
        public string ApplicationID { get; set; }

        [JsonProperty("ProjectID")]
        public string ProjectID { get; set; }

        [JsonProperty("TransactionID")]
        public string TransactionID { get; set; }

        [JsonProperty("Use")]
        public bool Use { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }
    }

    public static class NodeScriptContractSerialize
    {
        public static string ToJson(this NodeScriptContract self) => JsonConvert.SerializeObject(self, ConverterSetting.Settings);
    }
}
