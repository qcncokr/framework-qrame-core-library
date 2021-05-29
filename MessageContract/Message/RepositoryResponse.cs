using System.Collections.Generic;
using System.Runtime.Serialization;
using MessagePack;

using Qrame.CoreFX.Messages;
using Qrame.Core.Library.MessageContract.DataObject;

namespace Qrame.Core.Library.MessageContract.Message
{
    /// <summary>
    /// Repository 서비스 응답 메시지 객체입니다.
    /// </summary>
    [MessagePackObject]
    [DataContract]
    public class RepositoryResponse : MessagePackResponseBase
    {
        /// <summary>
        /// 데이터베이스에 영향 받는 행의 수입니다.
        /// </summary>
        [Key(nameof(affect))]
        [DataMember]
        public int affect = 0;

        /// <summary>
        /// RepositoryObject 입니다.
        /// </summary>
        [Key(nameof(repositoryObject))]
        [DataMember]
        public RepositoryObject repositoryObject = null;

        /// <summary>
        /// RepositoryObject 입니다.
        /// </summary>
        [Key(nameof(repositorysObject))]
        [DataMember]
        public List<RepositoryObject> repositorysObject = null;

        /// <summary>
        /// RepositoryItemObject 입니다.
        /// </summary>
        [Key(nameof(repositoryItemObject))]
        [DataMember]
        public RepositoryItemsObject repositoryItemObject = null;

        /// <summary>
        /// RepositoryItemsObject 입니다.
        /// </summary>
        [Key(nameof(repositoryItemsObject))]
        [DataMember]
        public List<RepositoryItemsObject> repositoryItemsObject = null;
    }
}
