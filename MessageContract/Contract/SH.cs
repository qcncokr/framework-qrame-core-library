using System.ComponentModel;
using System.Runtime.Serialization;

namespace Qrame.Core.Library.MessageContract.Contract
{

    [DataContract(Namespace = "http://www.tempuri.com/types/")]
    public partial class SH
    {
        [DataMember]
        [Description("SH/TH를 제외한 구간암호여부")]
        public string TLM_ENCY_DSCD { get; set; }

        [DataMember]
        [Description("거래 추적을 위한 고유글로벌ID")]
        public string GLBL_ID { get; set; }

        [DataMember]
        [Description("글로벌ID 진행일련번호")]
        public int? GLBL_ID_PRG_SRNO { get; set; }

        [DataMember]
        [Description("IPv4/IPv6 기반 클라이언트IP주소")]
        public string CLNT_IPAD { get; set; }

        [DataMember]
        [Description("구분값이 없는 16진수 클라이언트MAC")]
        public string CLNT_MAC { get; set; }

        [DataMember]
        [Description("환경정보구분코드 (D:개발 P:운영 T:테스트)")]
        public string ENV_INF_DSCD { get; set; }

        [DataMember]
        [Description("최초전문을 만드는 시스템코드")]
        public string FST_TMS_SYS_CD { get; set; }

        [DataMember]
        [Description("최초전문요청일시")]
        public string FST_TLM_REQ_DTM { get; set; }

        [DataMember]
        [Description("문화권 약어 소문자 (ko,en,jp)")]
        public string LANG_DSCD { get; set; }

        [DataMember]
        [Description("전송전문을 만드는 시스템코드")]
        public string TMS_SYS_CD { get; set; }

        [DataMember]
        [Description("시스템 노드 식별코드")]
        public string TMS_SYS_NODE_ID { get; set; }

        [DataMember]
        [Description("WEB/WIN/SVC등 전송 매체 코드")]
        public string MD_KDCD { get; set; }

        [DataMember]
        [Description("요청/응답에 필요한 접속ID")]
        public string INTF_ID { get; set; }

        [DataMember]
        [Description("전문 요청일시")]
        public string TLM_REQ_DTM { get; set; }

        [DataMember]
        [Description("응답 시스템 코드")]
        public string RSP_SYS_CD { get; set; }

        [DataMember]
        [Description("전문 응답일시")]
        public string TLM_RSP_DTM { get; set; }

        [DataMember]
        [Description("시스템 응답 구분")]
        public string RSP_RST_DSCD { get; set; }

        [DataMember]
        [Description("시스템 메시지 코드")]
        public string MSG_OCC_SYS_CD { get; set; }
    }
}
