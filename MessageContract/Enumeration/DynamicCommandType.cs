namespace Qrame.CoreFX.Library.MessageContract.Enumeration
{
    /// <summary>
    /// 명령문에 대한 구분입니다.
    /// </summary>
    public enum DynamicCommandType
    {
        /// <summary>
        /// SQL Map ID입니다
        /// </summary>
        QueryID,

        /// <summary>
        /// SQL입니다.
        /// </summary>
        SQL,

        /// <summary>
        /// 스토어드 프로시저입니다
        /// </summary>
        StoredProcedure
    }
}
