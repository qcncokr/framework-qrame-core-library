using System.Data;
using System.Runtime.Serialization;
using MessagePack;

using Qrame.CoreFX.Messages;

namespace Qrame.CoreFX.Library.MessageContract.Message
{
    /// <summary>
    /// 데이터베이스 명령 서비스 응답 메시지 객체입니다.
    /// </summary>
    [MessagePackObject]
    [DataContract]
    public class CommonResponse : MessagePackResponseBase
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

        /// <summary>
        /// .Net Framework 기본 클래스입니다.
        /// </summary>
        [Key(nameof(ResultString))]
        [DataMember]
        public string ResultString;

        /// <summary>
        /// .Net Framework 기본 클래스입니다.
        /// </summary>
        [Key(nameof(ResultObject))]
        [DataMember]
        public object ResultObject;

        /// <summary>
        /// 입력, 수정, 삭제 명령에 대한 반영 개수입니다.
        /// </summary>
        [Key(nameof(ResultInteger))]
        [DataMember]
        public int ResultInteger;
    }
}
