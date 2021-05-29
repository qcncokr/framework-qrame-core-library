using System;

using MessagePack;

namespace Qrame.Core.Library.MessageContract.DataObject
{
    /// <summary>
    /// RepositoryItems을 구성하는 객체입니다.
    /// </summary>
    [MessagePackObject]
    public class RepositoryItemsObject
    {
        /// <summary>
        /// ItemID를 가져오거나, 설정합니다.
        /// </summary>
        [Key(nameof(ItemID))]
        public string ItemID = "";

        /// <summary>
        /// FileName를 가져오거나, 설정합니다.
        /// </summary>
        [Key(nameof(FileName))]
        public string FileName = "";

        /// <summary>
        /// Sequence를 가져오거나, 설정합니다.
        /// </summary>
        [Key(nameof(Sequence))]
        public int Sequence = 0;

        /// <summary>
        /// ItemSummery를 가져오거나, 설정합니다.
        /// </summary>
        [Key(nameof(ItemSummery))]
        public string ItemSummery = "";

        /// <summary>
        /// AbsolutePath를 가져오거나, 설정합니다.
        /// </summary>
        [Key(nameof(AbsolutePath))]
        public string AbsolutePath = "";

        /// <summary>
        /// RelativePath를 가져오거나, 설정합니다.
        /// </summary>
        [Key(nameof(RelativePath))]
        public string RelativePath = "";

        /// <summary>
        /// Extension를 가져오거나, 설정합니다.
        /// </summary>
        [Key(nameof(Extension))]
        public string Extension = "";

        /// <summary>
        /// Size를 가져오거나, 설정합니다.
        /// </summary>
        [Key(nameof(Size))]
        public int Size = 0;

        /// <summary>
        /// RepositoryID를 가져오거나, 설정합니다.
        /// </summary>
        [Key(nameof(RepositoryID))]
        public string RepositoryID = "";

        /// <summary>
        /// DependencyID를 가져오거나, 설정합니다.
        /// </summary>
        [Key(nameof(DependencyID))]
        public string DependencyID = "";

        /// <summary>
        /// CustomID1를 가져오거나, 설정합니다.
        /// </summary>
        [Key(nameof(CustomID1))]
        public string CustomID1 = "";

        /// <summary>
        /// CustomID2를 가져오거나, 설정합니다.
        /// </summary>
        [Key(nameof(CustomID2))]
        public string CustomID2 = "";

        /// <summary>
        /// CustomID3를 가져오거나, 설정합니다.
        /// </summary>
        [Key(nameof(CustomID3))]
        public string CustomID3 = "";

        /// <summary>
        /// PolicyPath를 가져오거나, 설정합니다.
        /// </summary>
        [Key(nameof(PolicyPath))]
        public string PolicyPath = "";

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
    }
}
