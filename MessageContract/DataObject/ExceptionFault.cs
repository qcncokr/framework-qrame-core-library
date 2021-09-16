using MessagePack;

namespace Qrame.CoreFX.Library.MessageContract.DataObject
{
    /// <summary>
    /// 응용 프로그램을 실행할 때 나타나는 오류에 대한 WCF Fault를 재 정의하는 클래스입니다.
    /// </summary>
    [MessagePackObject]
    public class ExceptionFault
    {
        /// <summary>
        /// 예외의 원인을 설명하는 오류 메시지 또는 빈 문자열("").입니다.
        /// </summary>
        [Key(nameof(Message))]
        public string Message { get; set; }

        /// <summary>
        /// 오류를 발생시키는 응용 프로그램 또는 개체의 이름입니다.
        /// </summary>
        [Key(nameof(Source))]
        public string Source { get; set; }

        /// <summary>
        /// 호출 스택의 직접 실행 프레임을 설명하는 문자열입니다.
        /// </summary>
        [Key(nameof(StackTrace))]
        public string StackTrace { get; set; }
    }
}
