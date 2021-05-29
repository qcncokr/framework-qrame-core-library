using System.Runtime.Serialization;
using MessagePack;

using Qrame.CoreFX.Messages;

namespace Qrame.Core.Library.MessageContract.Message
{
    /// <summary>
    /// Smtp 메일 발송 서비스 응답 메시지 객체입니다.
    /// </summary>
    [MessagePackObject]
    [DataContract]
    public class SmtpResponse : MessagePackResponseBase
    {
        /// <summary>
        /// 메일 발송 여부입니다. true면 성공 false면 실패입니다.
        /// </summary>
        [Key(nameof(IsSend))]
        [DataMember]
        public bool IsSend;
    }
}
