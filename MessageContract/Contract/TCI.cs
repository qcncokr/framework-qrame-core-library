using System.ComponentModel;
using System.Runtime.Serialization;

namespace Qrame.CoreFX.Library.MessageContract.Contract
{
    [DataContract(Namespace = "http://www.tempuri.com/types/")]
    public partial class TCI
    {
        [DataMember]
        [Description("마스킹해제대상ID")]
        public string MSK_TGT_ID { get; set; }

        [DataMember]
        [Description("마스킹해제정보")]
        public string MSK_RVK_INF { get; set; }
    }
}
