using MessagePack;

using Qrame.CoreFX.Library.MessageContract.Enumeration;

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Qrame.CoreFX.Library.MessageContract.DataObject
{
    /// <summary>
    /// 데이터베이스 명령을 표현하는 단일 객체입니다.
    /// </summary>
    [MessagePackObject]
    public class CommonObject
    {
        /// <summary>
        /// 데이터베이스 명령문 입니다.
        /// </summary>
        [Key(nameof(CommandText))]
        public string CommandText;

        /// <summary>
        /// 명령문에 대한 구분(SQL, StoredProcedure, QueryID)입니다.
        /// </summary>
        [Key(nameof(CommandType))]
        public string CommandType;

        /// <summary>
        /// ExecuteTypeObject가 Json일 경우 변환하는 형식이 단일인지, 멀티인지 지정합니다.
        /// </summary>
        [Key(nameof(JsonObject))]
        public JsonObjectType JsonObject = JsonObjectType.FormJson;

        /// <summary>
        /// ExecuteTypeObject가 Json이고 여러 데이터 테이블을 반환하는 프로시저일 경우 변환하는 형식이 단일인지, 멀티인지 지정합니다. 이 속성은 JsonObject 보다 우선 적용됩니다.
        /// </summary>
        [Key(nameof(JsonObjects))]
        public List<JsonObjectType> JsonObjects = new List<JsonObjectType>();

        /// <summary>
        /// System.Data.Common.DbCommand에 대한 매개 변수 컬렉션입니다.
        /// </summary>
        [Key(nameof(Parameters))]
        public List<CommonParameter> Parameters;

        /// <summary>
        /// 암호화된 컬럼 데이터에 대한 매개 변수 컬렉션입니다.
        /// </summary>
        [Key(nameof(DecryptParameters))]
        public List<DecryptParameter> DecryptParameters;
    }

    /// <summary>
    /// SQL명령문의 매개변수 구조를 표현하는 객체입니다.
    /// </summary>
    [DataContract(Name = "CommonParameter", Namespace = "http://www.tempuri.com/types/")]
    public class CommonParameter
    {
        /// <summary>
        /// SQL명령문의 매개변수 명입니다.
        /// </summary>
        [Key(nameof(ParameterName))]
        public string ParameterName;

        /// <summary>
        /// SQL명령문의 매개변수 값입니다.
        /// </summary>
        [Key(nameof(Value))]
        public object Value;

        /// <summary>
        /// SQL명령문의 매개변수의 데이터 타입입니다.
        /// </summary>
        [Key(nameof(SqlDbType))]
        public string SqlDbType;
    }
}
