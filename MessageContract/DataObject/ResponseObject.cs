namespace Qrame.CoreFX.Library.MessageContract.DataObject
{
    /// <summary>
    /// RESTful WCF 호출시 응답 서비스 객체입니다.
    /// </summary>
    public class ResponseObject
    {
        /// <summary>
        /// 서비스 응답 ID입니다.
        /// </summary>
        public string ResponseID { get; set; }

        /// <summary>
        /// RESTful 서비스 ID입니다.
        /// </summary>
        public string ServiceID { get; set; }

        /// <summary>
        /// 반환 형식을 가져오거나, 설정합니다.(예:json, xml, string)
        /// </summary>
        public string ReturnType { get; set; }

        /// <summary>
        /// RESTful 서비스에 대한 결과입니다.
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// RESTful 서비스에 대한 예외결과입니다.
        /// </summary>
        public string ExceptionText { get; set; }
    }
}
