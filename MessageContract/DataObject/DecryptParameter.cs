using MessagePack;

namespace Qrame.Core.Library.MessageContract.DataObject
{
    [MessagePackObject]
    public class DecryptParameter
    {
        /// <summary>
        /// 복호화를 적용할 Data ResultSet 인덱스입니다.
        /// </summary>
        [Key(nameof(ResultSetIndex))]
        public string ResultSetIndex;

        /// <summary>
        /// 복호화를 적용할 컬럼명 목록입니다.
        /// </summary>
        [Key(nameof(ColumnNames))]
        public string[] ColumnNames;
    }
}
