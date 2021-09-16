using System;
using System.Collections.Generic;
using System.Data;

using Qrame.CoreFX.DataModel;
using Qrame.CoreFX.DataModel.Rules;
using Qrame.CoreFX.ExtensionMethod;

namespace Qrame.CoreFX.Library.MessageContract.Entitie
{
    /// <summary>
    /// RepositoryItems을 표현하는 엔티티 모델입니다.
    /// </summary>
    public class RepositoryItems : EntityObject, IDataBinding
    {
        /// <summary>
        /// RepositoryItems 기본 생성자에서 엔티티 타입의 유효성 필드를 지정합니다.
        /// </summary>
        public RepositoryItems()
        {
            this.AddRule(new RequiredRule("RepositoryItemsID", "RepositoryItemsID은 반드시 입력해야 합니다."));
        }

        /// <summary>
        /// ItemID 입니다.
        /// </summary>
        private string itemID = "";

        /// <summary>
        /// ItemID를 가져오거나, 설정합니다.
        /// </summary>
        public string ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }

        /// <summary>
        /// FileName 입니다.
        /// </summary>
        private string fileName = "";

        /// <summary>
        /// FileName를 가져오거나, 설정합니다.
        /// </summary>
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        /// <summary>
        /// Sequence 입니다.
        /// </summary>
        private int sequence = 0;

        /// <summary>
        /// Sequence를 가져오거나, 설정합니다.
        /// </summary>
        public int Sequence
        {
            get { return sequence; }
            set { sequence = value; }
        }

        /// <summary>
        /// ItemSummery 입니다.
        /// </summary>
        private string itemSummery = "";

        /// <summary>
        /// ItemSummery를 가져오거나, 설정합니다.
        /// </summary>
        public string ItemSummery
        {
            get { return itemSummery; }
            set { itemSummery = value; }
        }

        /// <summary>
        /// AbsolutePath 입니다.
        /// </summary>
        private string absolutePath = "";

        /// <summary>
        /// AbsolutePath를 가져오거나, 설정합니다.
        /// </summary>
        public string AbsolutePath
        {
            get { return absolutePath; }
            set { absolutePath = value; }
        }

        /// <summary>
        /// RelativePath 입니다.
        /// </summary>
        private string relativePath = "";

        /// <summary>
        /// RelativePath를 가져오거나, 설정합니다.
        /// </summary>
        public string RelativePath
        {
            get { return relativePath; }
            set { relativePath = value; }
        }

        /// <summary>
        /// Extension 입니다.
        /// </summary>
        private string extension = "";

        /// <summary>
        /// Extension를 가져오거나, 설정합니다.
        /// </summary>
        public string Extension
        {
            get { return extension; }
            set { extension = value; }
        }

        /// <summary>
        /// Size 입니다.
        /// </summary>
        private int size = 0;

        /// <summary>
        /// Size를 가져오거나, 설정합니다.
        /// </summary>
        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        /// <summary>
        /// RepositoryID 입니다.
        /// </summary>
        private string repositoryID = "";

        /// <summary>
        /// RepositoryID를 가져오거나, 설정합니다.
        /// </summary>
        public string RepositoryID
        {
            get { return repositoryID; }
            set { repositoryID = value; }
        }

        /// <summary>
        /// DependencyID 입니다.
        /// </summary>
        private string dependencyID = "";

        /// <summary>
        /// DependencyID를 가져오거나, 설정합니다.
        /// </summary>
        public string DependencyID
        {
            get { return dependencyID; }
            set { dependencyID = value; }
        }

        /// <summary>
        /// CustomID1 입니다.
        /// </summary>
        private string customID1 = "";

        /// <summary>
        /// CustomID1를 가져오거나, 설정합니다.
        /// </summary>
        public string CustomID1
        {
            get { return customID1; }
            set { customID1 = value; }
        }

        /// <summary>
        /// CustomID2 입니다.
        /// </summary>
        private string customID2 = "";

        /// <summary>
        /// CustomID2를 가져오거나, 설정합니다.
        /// </summary>
        public string CustomID2
        {
            get { return customID2; }
            set { customID2 = value; }
        }

        /// <summary>
        /// CustomID3 입니다.
        /// </summary>
        private string customID3 = "";

        /// <summary>
        /// CustomID3를 가져오거나, 설정합니다.
        /// </summary>
        public string CustomID3
        {
            get { return customID3; }
            set { customID3 = value; }
        }


        /// <summary>
        /// PolicyPath 입니다.
        /// </summary>
        private string policyPath = "";

        /// <summary>
        /// PolicyPath를 가져오거나, 설정합니다.
        /// </summary>
        public string PolicyPath
        {
            get { return policyPath; }
            set { policyPath = value; }
        }

        /// <summary>
        /// CreatePersonID 입니다.
        /// </summary>
        private int createPersonID = 0;

        /// <summary>
        /// CreatePersonID를 가져오거나, 설정합니다.
        /// </summary>
        public int CreatePersonID
        {
            get { return createPersonID; }
            set { createPersonID = value; }
        }

        /// <summary>
        /// CreateDate 입니다.
        /// </summary>
        private DateTime createDate = DateTime.Now;

        /// <summary>
        /// CreateDate를 가져오거나, 설정합니다.
        /// </summary>
        public DateTime CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }

        /// <summary>
        /// 결과 집합의 앞으로만 이동 가능한 스트림에서 RepositoryItems 제네릭 컬렉션을 반환합니다.
        /// </summary>
        /// <param name="dataReader">결과 집합의 앞으로만 이동 가능한 스트림입니다.</param>
        /// <returns>RepositoryItems 제네릭 컬렉션입니다.</returns>
        public dynamic BindingData(IDataReader dataReader)
        {
            return dataReader.ToObjectList<RepositoryItems>();
        }

        /// <summary>
        /// 결과 집합의 앞으로만 이동 가능한 스트림에서 RepositoryItems 엔티티를 반환합니다.
        /// </summary>
        /// <param name="dataReader">결과 집합의 앞으로만 이동 가능한 스트림입니다.</param>
        /// <returns>RepositoryItems을 표현하는 엔티티 모델입니다.</returns>
        public RepositoryItems GetRepositoryItems(IDataReader dataReader)
        {
            RepositoryItems result = null;
            List<RepositoryItems> items = dataReader.ToObjectList<RepositoryItems>();

            if (items.Count > 0)
            {
                result = items[0];
            }

            return result;
        }
    }

}
