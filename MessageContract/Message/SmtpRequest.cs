
using System.Runtime.Serialization;
using MessagePack;

using Qrame.CoreFX.Messages;
using Qrame.CoreFX.Library.MessageContract.DataObject;

namespace Qrame.CoreFX.Library.MessageContract.Message
{
    /// <summary>
    /// Smtp 메일 발송 메시지에 필요한 구성 객체입니다.
    /// </summary>
    [MessagePackObject]
    [DataContract]
    public class SmtpRequest : MessagePackRequestBase
    {
        /// <summary>
        /// Smtp 메일 발송 요청 식별자입니다.
        /// </summary>
        [Key(nameof(GlobalID))]
        [DataMember]
        public string GlobalID = "";

        /// <summary>
        /// 메일 발송자 전자 메일 주소입니다.
        /// </summary>
        [Key(nameof(MailerAddress))]
        [DataMember]
        public string MailerAddress;

        /// <summary>
        /// MailerAddress와 연결된 표시 이름입니다.
        /// </summary>
        [Key(nameof(MailerName))]
        [DataMember]
        public string MailerName;

        /// <summary>
        /// 메일 제목입니다.
        /// </summary>
        [Key(nameof(Subject))]
        [DataMember]
        public string Subject;

        /// <summary>
        /// 메일 본문 내용입니다.
        /// </summary>
        [Key(nameof(Body))]
        [DataMember]
        public string Body;

        /// <summary>
        /// 기본 자격 증명이 사용되면 true이고, 그렇지 않으면 false입니다. 기본값은 true입니다.
        /// </summary>
        [Key(nameof(UseDefaultCredentials))]
        [DataMember]
        public bool UseDefaultCredentials = true;

        /// <summary>
        /// 메일 본문 내용이 true면 HTML, false면 일반 텍스트로 발송합니다. 기본값은 true입니다.
        /// </summary>
        [Key(nameof(IsBodyHtml))]
        [DataMember]
        public bool IsBodyHtml = true;

        /// <summary>
        /// SMTP 트랜잭션에 사용되는 호스트의 이름 또는 IP 주소를 가져오거나 설정합니다.
        /// </summary>
        [Key(nameof(SmtpHostServer))]
        [DataMember]
        public string SmtpHostServer;

        /// <summary>
        /// SMTP 트랜잭션에 사용되는 포트를 가져오거나 설정합니다.
        /// </summary>
        [Key(nameof(SmtpPort))]
        [DataMember]
        public int SmtpPort = 0;

        /// <summary>
        /// SMTP 프로토콜이 SSL을 사용하는지 구분합니다.
        /// </summary>
        [Key(nameof(EnableSsl))]
        [DataMember]
        public bool EnableSsl = false;

        /// <summary>
        /// 외부 SMTP 서버 사용시 서버 인증에 필요한 식별자입니다.
        /// </summary>
        [Key(nameof(UserName))]
        [DataMember]
        public string UserName = "";

        /// <summary>
        /// 외부 SMTP 서버 사용시 서버 인증에 필요한 비밀번호입니다.
        /// </summary>
        [Key(nameof(Password))]
        [DataMember]
        public string Password = "";

        /// <summary>
        /// 외부 SMTP 서버 사용시 서버 인증에 필요한 도메인입니다.
        /// </summary>
        [Key(nameof(Domain))]
        [DataMember]
        public string Domain = "";

        /// <summary>
        /// Smtp 메일 발송에 필요한 정보입니다.
        /// </summary>
        [Key(nameof(MailObject))]
        [DataMember]
        public SmtpObject MailObject = null;
    }
}
