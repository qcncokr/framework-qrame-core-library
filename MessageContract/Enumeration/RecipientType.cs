namespace Qrame.CoreFX.Library.MessageContract.Enumeration
{
    /// <summary>
    /// 메일 수신자 그룹입니다.
    /// </summary>
    public enum RecipientType
    {
        /// <summary>
        /// 일반 수신인입니다.
        /// </summary>
        To,

        /// <summary>
        /// 참조 수신인입니다.
        /// </summary>
        CC,

        /// <summary>
        /// 숨은 참조 수신인입니다.
        /// </summary>
        Bcc
    }
}
