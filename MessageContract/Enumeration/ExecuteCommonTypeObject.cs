namespace Qrame.CoreFX.Library.MessageContract.Enumeration
{
    /// <summary>
    /// ExecuteCommon 메서드의 결과 타입 열거자입니다.
    /// </summary>
    public enum ExecuteCommonTypeObject
    {
        /// <summary>
        /// 메모리내에 데이터 캐시를 나타내는 결과입니다.
        /// </summary>
        DataSet,

        /// <summary>
        /// JSON(Javascript Object Notation)을 표현하는 문자입니다.
        /// </summary>
        Json,

        /// <summary>
        /// 단일 값을 반환합니다.
        /// </summary>
        Scalar,

        /// <summary>
        /// 결과를 반환하지 않습니다.
        /// </summary>
        NonQuery,

        /// <summary>
        /// SQL 문자열을 반환합니다.
        /// </summary>
        SQLText,

        /// <summary>
        /// SQL 의 스키마를 반환합니다.
        /// </summary>
        SchemeOnly
    }
}
