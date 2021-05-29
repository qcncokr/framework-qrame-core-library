using MessagePack;

using Qrame.Core.Library.MessageContract.DataObject;
using Qrame.Core.Library.MessageContract.Enumeration;
using Qrame.CoreFX.Messages;

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Qrame.Core.Library.MessageContract.Message
{
    /// <summary>
    /// 데이터베이스 명령 메시지에 필요한 구성 객체입니다.
    /// </summary>
    [MessagePackObject]
    [DataContract]
    public class CommonRequest : MessagePackRequestBase
    {
        /// <summary>
        /// ExecuteCommon 메서드의 결과 타입 열거자입니다.
        /// </summary>
        [Key(nameof(ReturnType))]
        [DataMember]
        public ExecuteCommonTypeObject ReturnType = ExecuteCommonTypeObject.DataSet;

        /// <summary>
        /// 서비스 식별자입니다.
        /// </summary>
        [Key(nameof(GlobalID))]
        [DataMember]
        public string GlobalID;

        /// <summary>
        /// 데이터베이스 명령수행시 트랜잭션 기반에서 동작 하도록 지정합니다.
        /// </summary>
        [Key(nameof(IsTransaction))]
        [DataMember]
        public bool IsTransaction = false;

        /// <summary>
        /// 데이터베이스 명령을 표현하는 단일 객체입니다.
        /// </summary>
        [Key(nameof(CommonObjects))]
        [DataMember]
        public List<CommonObject> CommonObjects = null;

        public override bool ValidRequest(RequestBase request, MessagePackResponseBase response)
        {


            return true;
        }
    }
}
