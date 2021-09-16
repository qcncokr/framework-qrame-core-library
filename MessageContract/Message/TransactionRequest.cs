using Qrame.CoreFX.Library.MessageContract.Contract;
using Qrame.CoreFX.Library.MessageContract.DataObject;

using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Qrame.CoreFX.Library.MessageContract.Message
{
    [DataContract]
    public partial class TransactionRequest : MessagePackRequestBase
    {
        public TransactionRequest()
        {
            this.SH = new SH();
            this.TH = new TH();
            this.TCI = new List<TCI>();
            this.DTI = null;
            this.DAT = new INPUT_DAT();
            this.BusinessContract = new BusinessContract();
        }

        [DataMember]
        [Description("거래 메시지에 대한 시스템 정보")]
        public SH SH { get; set; }

        [DataMember]
        [Description("거래 메시지 헤더 정보")]
        public TH TH { get; set; }

        [DataMember]
        [Description("거래 메시지 입력 연동 정보")]
        public List<TCI> TCI { get; set; }

        [DataMember]
        [Description("거래 개별 정의데이터")]
        public string DTI { get; set; }

        [DataMember]
        [Description("입력 거래 정보")]
        public INPUT_DAT DAT { get; set; }
        
        public BusinessContract BusinessContract { get; set; }
    }
}
