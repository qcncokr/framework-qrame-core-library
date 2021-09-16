using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Qrame.CoreFX.Library.MessageContract.DataObject
{
    public class UIContractObject
    {
        [JsonProperty("ProgramID")]
        public string ProgramID { get; set; }

        [JsonProperty("BusinessID")]
        public string BusinessID { get; set; }

        [JsonProperty("SystemID")]
        public string SystemID { get; set; }

        [JsonProperty("TransactionID")]
        public string TransactionID { get; set; }

        [JsonProperty("Use")]
        public string Use { get; set; }

        [JsonProperty("ModifiedDate")]
        public string ModifiedDate { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("DataSource")]
        public Dictionary<string, JToken> DataSource { get; set; }

        [JsonProperty("Transactions")]
        public List<Transaction> Transactions { get; set; }

        public static UIContractObject FromJson(string json)
        {
            return JsonConvert.DeserializeObject<UIContractObject>(json, UIContractObjectConverter.Settings);
        }
    }

    public class Transaction
    {
        [JsonProperty("FunctionID")]
        public string FunctionID { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Inputs")]
        public List<UITransactionInput> Inputs { get; set; }

        [JsonProperty("Outputs")]
        public List<UITransactionOutput> Outputs { get; set; }
    }

    public class UITransactionInput
    {
        [JsonProperty("RequestType")]
        public string RequestType { get; set; }

        [JsonProperty("DataFieldID")]
        public string DataFieldID { get; set; }

        [JsonProperty("Items")]
        public Dictionary<string, FieldItem> Items { get; set; }
    }

    public class FieldItem
    {
        [JsonProperty("FieldID")]
        public string FieldID { get; set; }

        [JsonProperty("DataType")]
        public string DataType { get; set; }
    }

    public class UITransactionOutput
    {
        [JsonProperty("ResponseType")]
        public string ResponseType { get; set; }

        [JsonProperty("DataFieldID")]
        public string DataFieldID { get; set; }

        [JsonProperty("Items")]
        public Dictionary<string, FieldItem> Items { get; set; }
    }
    
    public static class UIContractObjectConverterSerialize
    {
        public static string ToJson(this UIContractObject self)
        {
            return JsonConvert.SerializeObject(self, Formatting.Indented, UIContractObjectConverter.Settings);
        }
    }

    internal static class UIContractObjectConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
