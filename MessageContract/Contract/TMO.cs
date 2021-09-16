using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Qrame.CoreFX.Library.MessageContract.Contract
{
    [DataContract(Namespace = "http://www.tempuri.com/types/")]
    public partial class TMO
    {
        [DataMember]
        [Description("출력화면구분코드")]
        public string OUP_SCRN_DSCD { get; set; }

        [DataMember]
        [Description("다음거래여부")]
        public string NXT_TRN_YN { get; set; }

        [DataMember]
        [Description("다음거래화면ID")]
        public string NXT_TRN_SCRN_ID { get; set; }

        [DataMember]
        [Description("다음거래코드")]
        public string NXT_TRN_CD { get; set; }

        [DataMember]
        [Description("보고서컨트롤명")]
        public string RPTD_CNRL_NM { get; set; }

        [DataMember]
        [Description("보고서구분명")]
        public string RPTD_DIS_NM { get; set; }

        [DataMember]
        [Description("출력화면ID 반복")]
        public List<OUP_SCRN> OUP_SCRN { get; set; }
    }

    public partial class OUP_SCRN
    {
        [DataMember]
        [Description("출력화면ID")]
        public string OUP_SCRN_ID { get; set; }
    }

}
