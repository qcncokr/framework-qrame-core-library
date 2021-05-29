using MessagePack;

using Qrame.Core.Library.MessageContract.Enumeration;

using System.Collections.Generic;

namespace Qrame.Core.Library.MessageContract.DataObject
{
    /// <summary>
    /// Smtp 메일 발송을 위한 구성 객체입니다.
    /// </summary>
    [MessagePackObject]
    public class SmtpObject
    {
        /// <summary>
        /// 메일 수신자에 대한 매개 변수 컬렉션입니다.
        /// </summary>
        [Key(nameof(MailRecipients))]
        public List<MailRecipient> MailRecipients;

        /// <summary>
        /// 메일 첨부파일에 대한 매개 변수 컬렉션입니다.
        /// </summary>
        [Key(nameof(MailAttachments))]
        public List<string> MailAttachments;
    }

    /// <summary>
    /// 메일 수신자에 대한 구성 객체입니다.
    /// </summary>
    [MessagePackObject]
    public class MailRecipient
    {
        /// <summary>
        /// 메일 수신자 그룹입니다. (To : 일반수신, CC : 참조, Bcc : 숨은참조)
        /// </summary>
        [Key(nameof(RecipientType))]
        public RecipientType RecipientType = RecipientType.To;

        /// <summary>
        /// 전자 메일 주소입니다.
        /// </summary>
        [Key(nameof(MailAddress))]
        public string MailAddress;

        /// <summary>
        /// MailAddress와 연결된 표시 이름입니다.
        /// </summary>
        [Key(nameof(RecipientName))]
        public string RecipientName;
    }
}
