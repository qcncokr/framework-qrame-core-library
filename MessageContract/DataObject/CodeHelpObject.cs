using System.Collections.Generic;

using MessagePack;

namespace Qrame.Core.Library.MessageContract.DataObject
{
    /// <summary>
    /// 코드헬프 명령을 구성하는 객체입니다.
    /// </summary>
    [MessagePackObject]
    public class CodeHelpObject
    {
        /// <summary>
        /// SQL 명령문을 식별 하기위한 QueryID니다.
        /// </summary>
        [Key(nameof(QueryID))]
        public string QueryID;

        /// <summary>
        /// SQL 명령문에 조건 필터링을 적용하기위한 옵션입니다.
        /// </summary>
        [Key(nameof(NameValues))]
        public string NameValues;

        /// <summary>
        /// 암호화된 컬럼 데이터에 대한 매개 변수 컬렉션입니다.
        /// </summary>
        [Key(nameof(DecryptParameters))]
        public List<DecryptParameter> DecryptParameters;
    }
}
