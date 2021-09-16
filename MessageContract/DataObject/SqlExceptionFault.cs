using MessagePack;

namespace Qrame.CoreFX.Library.MessageContract.DataObject
{
    /// <summary>
    /// SQL Server 가 경고나 오류에 대한 WCF Fault를 재 정의하는 클래스입니다.
    /// </summary>
    [MessagePackObject]
    public class SqlExceptionFault
    {
        /// <summary>
        /// 예외의 원인을 설명하는 오류 메시지 또는 빈 문자열("").입니다.
        /// </summary>
        [Key(nameof(Message))]
        public string Message { get; set; }

        /// <summary>
        /// 오류를 포함하는 Transact-SQL 명령 일괄이나 저장 프로시저의 줄 번호입니다.
        /// </summary>
        [Key(nameof(LineNumber))]
        public int LineNumber { get; set; }

        /// <summary>
        /// 오류의 형식을 식별하는 번호입니다.
        /// </summary>
        [Key(nameof(Number))]
        public int Number { get; set; }

        /// <summary>
        /// 저장 프로시저 또는 RPC의 이름입니다.
        /// </summary>
        [Key(nameof(Procedure))]
        public string Procedure { get; set; }

        /// <summary>
        /// SQL Server.인스턴스를 실행하는 컴퓨터의 이름입니다.
        /// </summary>
        [Key(nameof(Server))]
        public string Server { get; set; }

        /// <summary>
        /// 오류를 생성한 공급자의 이름입니다.
        /// </summary>
        [Key(nameof(Source))]
        public string Source { get; set; }
    }
}
