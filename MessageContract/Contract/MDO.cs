using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Qrame.CoreFX.Library.MessageContract.Contract
{
    [DataContract(Namespace = "http://www.tempuri.com/types/")]
    public partial class MDO
    {
        [DataMember]
        [Description("응답구분코드")]
        public string TRN_RET_DSCD { get; set; }

        [DataMember]
        [Description("메시지코드")]
        public string MSG_CD { get; set; }

        [DataMember]
        [Description("주메시지내용")]
        public string MAIN_MSG_TXT { get; set; }

        [DataMember]
        [Description("부가메시지반복수")]
        public List<ADI_MSG> ADI_MSG { get; set; }
    }

    [DataContract(Namespace = "http://www.tempuri.com/types/")]
    public partial class ADI_MSG
    {
        [DataMember]
        [Description("부가메시지코드")]
        public string ADI_MSG_CD { get; set; }

        [DataMember]
        [Description("부가메시지내용")]
        public string ADI_MSG_TXT { get; set; }
    }
}
