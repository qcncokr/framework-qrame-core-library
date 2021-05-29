using System.Collections.Generic;
using System.Runtime.Serialization;
using MessagePack;

using Qrame.CoreFX.Messages;
using Qrame.Core.Library.MessageContract.DataObject;

namespace Qrame.Core.Library.MessageContract.Message
{
    /// <summary>
    /// Repository 메시지에 필요한 구성 객체입니다.
    /// </summary>
    [MessagePackObject]
    [DataContract]
    public class RepositoryRequest : MessagePackRequestBase
    {
        /// <summary>
        /// Repository 요청 식별자입니다.
        /// </summary>
        [Key(nameof(GlobalID))]
        [DataMember]
        public string GlobalID = "";

        /// <summary>
        /// RepositoryID 입니다.
        /// </summary>
        [Key(nameof(RepositoryID))]
        [DataMember]
        public string RepositoryID = "";

        /// <summary>
        /// DependencyID 입니다.
        /// </summary>
        [Key(nameof(DependencyID))]
        [DataMember]
        public string DependencyID = "";

        /// <summary>
        /// TemporaryID 입니다.
        /// </summary>
        [Key(nameof(TemporaryID))]
        [DataMember]
        public string TemporaryID = "";

        /// <summary>
        /// ItemID 입니다.
        /// </summary>
        [Key(nameof(ItemID))]
        [DataMember]
        public string ItemID = "";

        /// <summary>
        /// UseYN 입니다.
        /// </summary>
        [Key(nameof(UseYN))]
        [DataMember]
        public bool UseYN = false;

        /// <summary>
        /// RepositoryObject 입니다.
        /// </summary>
        [Key(nameof(repositoryObject))]
        [DataMember]
        public RepositoryObject repositoryObject = null;

        /// <summary>
        /// RepositoryItemsObject 입니다.
        /// </summary>
        [Key(nameof(repositoryItemsObject))]
        [DataMember]
        public List<RepositoryItemsObject> repositoryItemsObject = null;
    }
}
