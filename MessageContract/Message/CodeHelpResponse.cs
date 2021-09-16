using System.Data;
using System.Runtime.Serialization;
using MessagePack;

using Qrame.CoreFX.Messages;

namespace Qrame.CoreFX.Library.MessageContract.Message
{
    /// <summary>
    /// 코드헬프 서비스 응답 메시지 객체입니다.
    /// </summary>
    [MessagePackObject]
    [DataContract]
    public class CodeHelpResponse : MessagePackResponseBase
    {
        /// <summary>
        /// 메모리내에 데이터 캐시를 나타내는 결과입니다.
        /// </summary>
        [Key(nameof(ResultDataSet))]
        [DataMember]
        public DataSet ResultDataSet;

        /// <summary>
        /// JSON(Javascript Object Notation)을 표현하는 문자입니다.
        /// </summary>
        [Key(nameof(ResultJson))]
        [DataMember]
        public string ResultJson;
    }
}
