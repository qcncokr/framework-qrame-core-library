using System.Runtime.Serialization;

using MessagePack;

namespace Qrame.CoreFX.Library.MessageContract.DataObject
{
    /// <summary>
    /// 명령문의 매개변수 구조를 표현하는 객체입니다.
    /// </summary>
    [MessagePackObject]
    public class DynamicParameter
    {
        /// <summary>
        /// 명령문의 매개변수 명입니다.
        /// </summary>
        [Key(nameof(ParameterName))]
        public string ParameterName;

        /// <summary>
        /// 명령문의 매개변수 값입니다.
        /// </summary>
        [Key(nameof(Value))]
        public object Value;

        /// <summary>
        /// 명령문의 매개변수의 데이터 타입입니다.
        /// </summary>
        [Key(nameof(DbType))]
        public string DbType;

        /// <summary>
        /// 명령문의 매개변수의 데이터 길이입니다.
        /// </summary>
        [Key(nameof(Length))]
        public int Length;
    }
}
