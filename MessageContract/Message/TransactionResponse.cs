using Qrame.CoreFX.Library.MessageContract.Contract;
using Qrame.CoreFX.Library.MessageContract.DataObject;

using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Qrame.CoreFX.Library.MessageContract.Message
{
    [DataContract]
    public class TransactionResponse : MessagePackResponseBase
    {
        public TransactionResponse()
        {
            this.SH = new SH();
            this.TH = new TH();
            this.MDO = new MDO();
            this.TCO = new List<TCO>();
            this.TMO = new TMO();
            this.DAT = new OUTPUT_DAT();
            this.BusinessContract = new BusinessContract();
        }

        [DataMember]
        [Description("거래 메시지에 대한 시스템 정보")]
        public SH SH { get; set; }

        [DataMember]
        [Description("거래 메시지 헤더 정보")]
        public TH TH { get; set; }

        [DataMember]
        [Description("메시지 출력 정보")]
        public MDO MDO { get; set; }

        [DataMember]
        [Description("거래 메시지 출력 연동 정보")]
        public List<TCO> TCO { get; set; }

        [DataMember]
        [Description("출력 거래정보 수신 단말 정보")]
        public TMO TMO { get; set; }

        [DataMember]
        [Description("출력 거래 정보")]
        public OUTPUT_DAT DAT { get; set; }

        public BusinessContract BusinessContract { get; set; }
    }
}
