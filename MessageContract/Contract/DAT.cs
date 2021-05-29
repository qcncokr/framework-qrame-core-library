using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Qrame.Core.Library.MessageContract.Contract
{
    [DataContract(Namespace = "http://www.tempuri.com/types/")]
    public partial class INPUT_DAT
    {
        [DataMember]
        [Description("요청 거래ID (시스템 코드 3자리 + 업무 분류 3자리 + 화면 번호 4자리 + 명령 구분 1자리 + 순번 2자리)")]
        public string REQ_TX_MAP_ID { get; set; }

        [DataMember]
        [Description("거래 요청 항목갯수")]
        public List<int> REQ_INPUT_CNT { get; set; }

        [DataMember]
        [Description("거래 요청정보")]
        public List<List<REQ_INPUT>> REQ_INPUT { get; set; }

        [DataMember]
        [Description("거래 요청정보")]
        public List<string> REQ_INPUTDATA { get; set; }
    }

    [DataContract(Namespace = "http://www.tempuri.com/types/")]
    public partial class REQ_INPUT
    {
        [DataMember]
        [Description("필드 ID")]
        public string REQ_FIELD_ID { get; set; }

        [DataMember]
        [Description("필드 값")]
        public object REQ_FIELD_DAT { get; set; }
    }

    [DataContract(Namespace = "http://www.tempuri.com/types/")]
    public partial class OUTPUT_DAT
    {
        [DataMember]
        [Description("응답 거래ID == 요청 거래ID")]
        public string RES_TX_MAP_ID { get; set; }

        [DataMember]
        [Description("응답 거래 데이터 메타")]
        public List<string> RES_OUTPUT_META { get; set; }

        [DataMember]
        [Description("거래 응답정보")]
        public List<RES_OUTPUT> RES_OUTPUT { get; set; }
    }

    [DataContract(Namespace = "http://www.tempuri.com/types/")]
    public partial class RES_OUTPUT
    {
        [DataMember]
        [Description("필드 ID")]
        public string RES_FIELD_ID { get; set; }

        [DataMember]
        [Description("필드 값")]
        public object RES_DAT { get; set; }
    }

    public class FieldData
    {
        public string FieldID { get; set; }

        public object Value { get; set; }
    }
}
