using MessagePack;

using Qrame.CoreFX.Library.MessageContract.DataObject;
using Qrame.CoreFX.Library.MessageContract.Enumeration;

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Qrame.CoreFX.Library.MessageContract.Message
{
    /// <summary>
    /// 코드헬프 메시지에 필요한 구성 객체입니다.
    /// </summary>
    [MessagePackObject]
    [DataContract]
    public class CodeHelpRequest : MessagePackRequestBase
    {
        /// <summary>
        /// ExecuteCodeHelp 메서드의 결과 타입 열거자입니다.
        /// </summary>
        [Key(nameof(ReturnType))]
        [DataMember]
        public ExecuteCodeHelpTypeObject ReturnType = ExecuteCodeHelpTypeObject.DataSet;

        /// <summary>
        /// 데이터베이스 명령 서비스에서 연결할 식별자입니다.
        /// </summary>
        [Key(nameof(DataSourceID))]
        [DataMember]
        public string DataSourceID;

        /// <summary>
        /// 서비스 식별자입니다.
        /// </summary>
        [Key(nameof(GlobalID))]
        [DataMember]
        public string GlobalID;

        /// <summary>
        /// 업체 식별자입니다.
        /// </summary>
        [Key(nameof(BusinessID))]
        [DataMember]
        public string BusinessID = "";

        /// <summary>
        /// 어플리케이션 식별자입니다.
        /// </summary>
        [Key(nameof(ApplicationID))]
        [DataMember]
        public string ApplicationID = "";

        /// <summary>
        /// 언어권 식별자입니다.
        /// </summary>
        [Key(nameof(LocaleID))]
        [DataMember]
        public string LocaleID = "";

        /// <summary>
        /// 코드헬프 명령에 대한 결과를 스키마 정보만 조회하도록 지정합니다.
        /// </summary>
        [Key(nameof(IsFmtOnly))]
        [DataMember]
        public bool IsFmtOnly = false;

        /// <summary>
        /// 코드헬프 명령을 구성하는 객체입니다.
        /// </summary>
        [Key(nameof(CodeHelpObjects))]
        [DataMember]
        public List<CodeHelpObject> CodeHelpObjects = null;
    }
}
