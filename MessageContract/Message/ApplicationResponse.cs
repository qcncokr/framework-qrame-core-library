using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using Qrame.CoreFX.Messages;

namespace Qrame.CoreFX.Library.MessageContract.Message
{
    [DataContract]
    public class ApplicationResponse
    {
        [DataMember]
        public AcknowledgeType Acknowledge;

        [DataMember]
        public string CorrelationID;

        [DataMember]
        public string ExceptionText;

        /// <summary>
        /// 메모리내에 데이터 캐시를 나타내는 결과입니다.
        /// </summary>
        [DataMember]
        public DataSet ResultDataSet;

        /// <summary>
        /// JSON(Javascript Object Notation)을 표현하는 문자입니다.
        /// </summary>
        [DataMember]
        public List<string> ResultMeta;

        /// <summary>
        /// JSON(Javascript Object Notation)을 표현하는 문자입니다.
        /// </summary>
        [DataMember]
        public string ResultJson;

        /// <summary>
        /// .Net Framework 기본 클래스입니다.
        /// </summary>
        [DataMember]
        public object ResultObject;

        /// <summary>
        /// 입력, 수정, 삭제 명령에 대한 반영 개수입니다.
        /// </summary>
        [DataMember]
        public int ResultInteger;
    }
}
