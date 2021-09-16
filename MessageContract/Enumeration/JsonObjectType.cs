namespace Qrame.CoreFX.Library.MessageContract.Enumeration
{
    /// <summary>
    /// JSON 포맷 변환 열거자입니다.
    /// </summary>
    public enum JsonObjectType
    {
        /// <summary>
        /// 단일(마스터) 데이터 구조의 JSON 문자열 입니다.
        /// </summary>
        FormJson,

        /// <summary>
        /// 그리드 데이터 구조의 JSON 문자열 입니다.
        /// </summary>
        GridJson,

        /// <summary>
        /// 그리드 데이터 구조의 JSON 문자열 입니다.
        /// </summary>
        jqGridJson,

        /// <summary>
        /// Chart 데이터 구조의 JSON 문자열 입니다.
        /// </summary>
        ChartJson,

        /// <summary>
        /// DataSet 데이터 구조의 JSON 문자열 입니다.
        /// </summary>
        DataSetJson,

        /// <summary>
        /// Dynamic 데이터 구조의 JSON 문자열 입니다.
        /// </summary>
        DynamicJson,

        /// <summary>
        /// 추가 데이터 구조의 JSON 문자열 입니다.
        /// </summary>
        AdditionJson
    }
}
