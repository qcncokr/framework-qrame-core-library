using System;
using System.Collections.Generic;

using MessagePack;

namespace Qrame.Core.Library.MessageContract.DataObject
{
    /// <summary>
    /// Repository 명령을 구성하는 객체입니다.
    /// </summary>
    [MessagePackObject]
    public class RepositoryObject
    {
        /// <summary>
        /// RepositoryID를 가져오거나, 설정합니다.
        /// </summary>
        [Key(nameof(RepositoryID))]
        public string RepositoryID = "";

        /// <summary>
        /// RepositoryName를 가져오거나, 설정합니다.
        /// </summary>
        [Key(nameof(RepositoryName))]
        public string RepositoryName = "";

        /// <summary>
        /// PhysicalPath를 가져오거나, 설정합니다.
        /// </summary>
        [Key(nameof(PhysicalPath))]
        public string PhysicalPath = "";

        /// <summary>
        /// IsVirtualPath를 가져오거나, 설정합니다.
        /// </summary>
        [Key(nameof(IsVirtualPath))]
        public bool IsVirtualPath = false;

        /// <summary>
        /// IsAutoPath를 가져오거나, 설정합니다.
        /// </summary>
        [Key(nameof(IsAutoPath))]
        public bool IsAutoPath = true;

        /// <summary>
        /// PolicyPath를 가져오거나, 설정합니다.
        /// </summary>
        [Key(nameof(PolicyPath))]
        public string PolicyPath = "";

        /// <summary>
        /// IsMultiUpload를 가져오거나, 설정합니다.
        /// </summary>
        [Key(nameof(IsMultiUpload))]
        public bool IsMultiUpload = true;

        /// <summary>
        /// UseCompress를 가져오거나, 설정합니다.
        /// </summary>
        [Key(nameof(UseCompress))]
        public bool UseCompress = true;

        /// <summary>
        /// UploadExtensions를 가져오거나, 설정합니다.
        /// </summary>
        [Key(nameof(UploadExtensions))]
        public string UploadExtensions = "";

        /// <summary>
        /// UploadCount를 가져오거나, 설정합니다.
        /// </summary>
        [Key(nameof(UploadCount))]
        public int UploadCount = 0;

        /// <summary>
        /// UploadSizeLimit를 가져오거나, 설정합니다.
        /// </summary>
        [Key(nameof(UploadSizeLimit))]
        public int UploadSizeLimit = 0;

        /// <summary>
        /// PolicyException를 가져오거나, 설정합니다.
        /// </summary>
        [Key(nameof(PolicyException))]
        public string PolicyException = "";

        /// <summary>
        /// RedirectUrl를 가져오거나, 설정합니다.
        /// </summary>
        [Key(nameof(RedirectUrl))]
        public string RedirectUrl = "";

        /// <summary>
        /// UseYN를 가져오거나, 설정합니다.
        /// </summary>
        [Key(nameof(UseYN))]
        public bool UseYN = true;

        /// <summary>
        /// Description를 가져오거나, 설정합니다.
        /// </summary>
        [Key(nameof(Description))]
        public string Description = "";

        /// <summary>
        /// CreatePersonID를 가져오거나, 설정합니다.
        /// </summary>
        [Key(nameof(CreatePersonID))]
        public int CreatePersonID = 0;

        /// <summary>
        /// CreateDate를 가져오거나, 설정합니다.
        /// </summary>
        [Key(nameof(CreateDate))]
        public DateTime CreateDate = DateTime.Now;

        /// <summary>
        /// RepositoryItems을 구성하는 객체 컬렉션입니다.
        /// </summary>
        [Key(nameof(RepositoryItems))]
        public List<RepositoryItemsObject> RepositoryItems;
    }
}
