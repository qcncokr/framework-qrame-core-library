using MessagePack;

using Qrame.CoreFX.Library.MessageContract.DataObject;
using Qrame.CoreFX.Library.MessageContract.Enumeration;

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Qrame.CoreFX.Library.MessageContract.Message
{
    /// <summary>
    /// 거래 명령 메시지에 필요한 구성 객체입니다.
    /// </summary>
    [MessagePackObject]
    [DataContract]
    public class DynamicRequest : MessagePackRequestBase
    {
        /// <summary>
        ///  결과 타입 열거자입니다.
        /// </summary>
        [Key(nameof(ReturnType))]
        [DataMember]
        public ExecuteDynamicTypeObject ReturnType = ExecuteDynamicTypeObject.Json;

        /// <summary>
        /// 서비스 식별자입니다.
        /// </summary>
        [Key(nameof(GlobalID))]
        [DataMember]
        public string GlobalID;
        
        /// <summary>
        /// 트랜잭션 기반에서 요청을 수행하도록 지정합니다.
        /// </summary>
        [Key(nameof(IsTransaction))]
        [DataMember]
        public bool IsTransaction = false;

        /// <summary>
        /// 명령을 표현하는 단일 객체입니다.
        /// </summary>
        [Key(nameof(DynamicObjects))]
        [DataMember]
        public List<DynamicObject> DynamicObjects = null;
    }
}
