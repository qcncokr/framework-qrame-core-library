using Qrame.CoreFX.Library.MessageContract.Message;

using System;
using System.Collections.Generic;

namespace Qrame.CoreFX.Library.MessageContract.DataObject
{
    /// <summary>
    /// RESTful WCF 호출시 명령을 제어하기 위한 서비스 객체입니다.
    /// </summary>
    [Serializable]
    public class TransactionObject
    {
        public List<LoadOption> LoadOptions;

        /// <summary>
        /// 서비스 요청 ID입니다.
        /// </summary>
        public string RequestID { get; set; }

        /// <summary>
        /// 요청 거래의 전역ID입니다.
        /// </summary>
        public string GlobalID { get; set; }

        /// <summary>
        /// RESTful TransactionID입니다.
        /// </summary>
        public string TransactionID { get; set; }

        /// <summary>
        /// RESTful 서비스 ID입니다.
        /// </summary>
        public string ServiceID { get; set; }

        /// <summary>
        /// 트랜잭션 명령을 수행 여부를 가져오거나, 설정합니다
        /// </summary>
        public bool TransactionScope { get; set; }

        /// <summary>
        /// RESTful ClientTag입니다.
        /// </summary>
        public string ClientTag { get; set; }

        /// <summary>
        /// RESTful DateTimeTicks입니다.
        /// </summary>
        public string DateTimeTicks { get; set; }

        /// <summary>
        /// 반환 형식을 가져오거나, 설정합니다.(예:json, xml, string, fileid)
        /// </summary>
        public string ReturnType { get; set; }

        public List<int> InputsItemCount = new List<int>();

        /// <summary>
        /// RESTful 서비스에 대한 매개 변수 컬렉션입니다.
        /// </summary>
        public List<List<TransactField>> Inputs { get; set; }
    }
}
