using System.Collections.Generic;

namespace Qrame.Core.Library.MessageContract.DataObject
{
    /// <summary>
    /// RESTful WCF 호출시 명령을 제어하기 위한 서비스 객체입니다.
    /// </summary>
    public class ServiceObject
    {
        /// <summary>
        /// 서비스 요청 ID입니다.
        /// </summary>
        public string RequestID { get; set; }

        /// <summary>
        /// RESTful 서비스 ID입니다.
        /// </summary>
        public string ServiceID { get; set; }

        /// <summary>
        /// 반환 형식을 가져오거나, 설정합니다.(예:json, xml, string)
        /// </summary>
        public string ReturnType { get; set; }

        /// <summary>
        /// RESTful ClientTag입니다.
        /// </summary>
        public string ClientTag { get; set; }

        /// <summary>
        /// RESTful DateTimeTicks입니다.
        /// </summary>
        public string DateTimeTicks { get; set; }

        /// <summary>
        /// RESTful 서비스에 대한 매개 변수 컬렉션입니다.
        /// </summary>
        public List<TransactField> NameValues { get; set; } // List<ServiceParameter>에 대응 하는 json
    }
}
