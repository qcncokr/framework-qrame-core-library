using System;
using System.Collections.Generic;
using System.Data;

using Qrame.CoreFX.DataModel;
using Qrame.CoreFX.DataModel.Rules;
using Qrame.CoreFX.ExtensionMethod;

namespace Qrame.Core.Library.MessageContract.Entitie
{
    /// <summary>
    /// Repository을 표현하는 엔티티 모델입니다.
    /// </summary>
    public class Repository : EntityObject, IDataBinding
    {
        /// <summary>
        /// Repository 기본 생성자에서 엔티티 타입의 유효성 필드를 지정합니다.
        /// </summary>
        public Repository()
        {
            this.AddRule(new RequiredRule("RepositoryID", "RepositoryID은 반드시 입력해야 합니다."));
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
        /// RepositoryName 입니다.
        /// </summary>
        private string repositoryName = "";

        /// <summary>
        /// RepositoryName를 가져오거나, 설정합니다.
        /// </summary>
        public string RepositoryName
        {
            get { return repositoryName; }
            set { repositoryName = value; }
        }

        /// <summary>
        /// PhysicalPath 입니다.
        /// </summary>
        private string physicalPath = "";

        /// <summary>
        /// PhysicalPath를 가져오거나, 설정합니다.
        /// </summary>
        public string PhysicalPath
        {
            get { return physicalPath; }
            set { physicalPath = value; }
        }

        /// <summary>
        /// IsVirtualPath 입니다.
        /// </summary>
        private bool isVirtualPath = true;

        /// <summary>
        /// IsVirtualPath 가져오거나, 설정합니다.
        /// </summary>
        public bool IsVirtualPath
        {
            get { return isVirtualPath; }
            set { isVirtualPath = value; }
        }

        /// <summary>
        /// IsAutoPath 입니다.
        /// </summary>
        private bool isAutoPath = true;

        /// <summary>
        /// IsAutoPath를 가져오거나, 설정합니다.
        /// </summary>
        public bool IsAutoPath
        {
            get { return isAutoPath; }
            set { isAutoPath = value; }
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
        /// IsMultiUpload 입니다.
        /// </summary>
        private bool isMultiUpload = true;

        /// <summary>
        /// IsMultiUpload를 가져오거나, 설정합니다.
        /// </summary>
        public bool IsMultiUpload
        {
            get { return isMultiUpload; }
            set { isMultiUpload = value; }
        }

        /// <summary>
        /// UseCompress 입니다.
        /// </summary>
        private bool useCompress = true;

        /// <summary>
        /// UseCompress를 가져오거나, 설정합니다.
        /// </summary>
        public bool UseCompress
        {
            get { return useCompress; }
            set { useCompress = value; }
        }

        /// <summary>
        /// UploadExtensions 입니다.
        /// </summary>
        private string uploadExtensions = "";

        /// <summary>
        /// UploadExtensions를 가져오거나, 설정합니다.
        /// </summary>
        public string UploadExtensions
        {
            get { return uploadExtensions; }
            set { uploadExtensions = value; }
        }

        /// <summary>
        /// UploadCount 입니다.
        /// </summary>
        private Int16 uploadCount = 0;

        /// <summary>
        /// UploadCount를 가져오거나, 설정합니다.
        /// </summary>
        public Int16 UploadCount
        {
            get { return uploadCount; }
            set { uploadCount = value; }
        }

        /// <summary>
        /// UploadSizeLimit 입니다.
        /// </summary>
        private int uploadSizeLimit = 0;

        /// <summary>
        /// UploadSizeLimit를 가져오거나, 설정합니다.
        /// </summary>
        public int UploadSizeLimit
        {
            get { return uploadSizeLimit; }
            set { uploadSizeLimit = value; }
        }

        /// <summary>
        /// PolicyException 입니다.
        /// </summary>
        private string policyException = "";

        /// <summary>
        /// PolicyException를 가져오거나, 설정합니다.
        /// </summary>
        public string PolicyException
        {
            get { return policyException; }
            set { policyException = value; }
        }

        /// <summary>
        /// RedirectUrl 입니다.
        /// </summary>
        private string redirectUrl = "";

        /// <summary>
        /// RedirectUrl를 가져오거나, 설정합니다.
        /// </summary>
        public string RedirectUrl
        {
            get { return redirectUrl; }
            set { redirectUrl = value; }
        }

        /// <summary>
        /// UseYN 입니다.
        /// </summary>
        private bool useYN = true;

        /// <summary>
        /// UseYN를 가져오거나, 설정합니다.
        /// </summary>
        public bool UseYN
        {
            get { return useYN; }
            set { useYN = value; }
        }

        /// <summary>
        /// Description 입니다.
        /// </summary>
        private string description = "";

        /// <summary>
        /// Description를 가져오거나, 설정합니다.
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
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
        /// 결과 집합의 앞으로만 이동 가능한 스트림에서 Repository 제네릭 컬렉션을 반환합니다.
        /// </summary>
        /// <param name="dataReader">결과 집합의 앞으로만 이동 가능한 스트림입니다.</param>
        /// <returns>Repository 제네릭 컬렉션입니다.</returns>
        public dynamic BindingData(IDataReader dataReader)
        {
            return dataReader.ToObjectList<Repository>();
        }

        /// <summary>
        /// 결과 집합의 앞으로만 이동 가능한 스트림에서 Repository 엔티티를 반환합니다.
        /// </summary>
        /// <param name="dataReader">결과 집합의 앞으로만 이동 가능한 스트림입니다.</param>
        /// <returns>Repository을 표현하는 엔티티 모델입니다.</returns>
        public Repository GetRepository(IDataReader dataReader)
        {
            Repository result = null;
            List<Repository> items = dataReader.ToObjectList<Repository>();

            if (items.Count > 0)
            {
                result = items[0];
            }

            return result;
        }
    }

}
