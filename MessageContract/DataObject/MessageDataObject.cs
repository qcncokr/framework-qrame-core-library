using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Qrame.Core.Library.MessageContract.DataObject
{
    /// <summary>
    /// MDO 출력 구조를 표현하는 객체입니다.
    /// </summary>
    [DataContract(Name = "MessageDataObject", Namespace = "http://www.tempuri.com/types/")]
    public class MessageDataObject
    {
        [DataMember]
        public string ResponseCode;

        [DataMember]
        public string ResultType;

        [DataMember]
        public string Message;

        [DataMember]
        public List<string> Additional;
    }
}
