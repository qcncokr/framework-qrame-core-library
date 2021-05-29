using MessagePack;

using Qrame.Core.Library.MessageContract.Enumeration;

using System.Collections.Generic;

namespace Qrame.Core.Library.MessageContract.DataObject
{
    /// <summary>
    /// 데이터베이스 명령을 표현하는 단일 객체입니다.
    /// </summary>
    [MessagePackObject]
    public class DynamicObject
    {
        /// <summary>
        /// 데이터베이스 식별자 입니다.
        /// </summary>
        [Key(nameof(QueryID))]
        public string QueryID;
        
        /// <summary>
        /// ExecuteTypeObject가 Json일 경우 변환하는 형식이 단일인지, 멀티인지 지정합니다.
        /// </summary>
        [Key(nameof(JsonObject))]
        public JsonObjectType JsonObject = JsonObjectType.FormJson;

        /// <summary>
        /// ExecuteTypeObject가 Json일 경우 반환하는 형식을 지정합니다.
        /// </summary>
        [Key(nameof(JsonObjects))]
        public List<JsonObjectType> JsonObjects = new List<JsonObjectType>();

        /// <summary>
        /// System.Data.Common.DbCommand에 대한 매개 변수 컬렉션입니다.
        /// </summary>
        [Key(nameof(Parameters))]
        public List<DynamicParameter> Parameters;

        /// <summary>
        /// 암호화된 컬럼 데이터에 대한 매개 변수 컬렉션입니다.
        /// </summary>
        [Key(nameof(DecryptParameters))]
        public List<DecryptParameter> DecryptParameters;

        /// <summary>
        /// 컬럼 데이터 매핑에 대한 매개 변수 컬렉션입니다.
        /// </summary>
        [Key(nameof(BaseFieldMappings))]
        public List<BaseFieldMapping> BaseFieldMappings { get; set; }

        /// <summary>
        /// 데이터 결과 반환를 무시할지 여부입니다
        /// </summary>
        [Key(nameof(IgnoreResult))]
        public bool IgnoreResult = false;
    }
}
