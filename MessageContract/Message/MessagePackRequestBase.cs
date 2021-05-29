using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using MessagePack;
using Qrame.CoreFX.Messages;

namespace Qrame.Core.Library.MessageContract.Message
{
	/// <summary>
	/// 요청에 대한 베이스 기능을 제공합니다.
	/// </summary>
	[MessagePackObject]
	[DataContract]
	public class MessagePackRequestBase
	{
		/// <summary>
		/// 클라이언트에 대한 태그 식별자입니다.
		/// </summary>
		[Key(nameof(ClientTag))]
		[DataMember]
		public string ClientTag;

		/// <summary>
		/// 보안 토큰 식별자입니다.
		/// </summary>
		[Key(nameof(AccessTokenID))]
		[DataMember]
		public string AccessTokenID;

		/// <summary>
		/// 버전 정보입니다.
		/// </summary>
		[Key(nameof(Version))]
		[DataMember]
		public string Version;

		/// <summary>
		/// 요청 식별자입니다.
		/// </summary>
		[Key(nameof(RequestID))]
		[DataMember]
		public string RequestID;

		/// <summary>
		/// 요청에 대한 부가 정보입니다.
		/// </summary>
		[Key(nameof(LoadOptions))]
		[DataMember]
		public List<LoadOption> LoadOptions;

		/// <summary>
		/// 요청에 대한 기본 정보입니다.
		/// </summary>
		[Key(nameof(Action))]
		[DataMember]
		public string Action;

		/// <summary>
		/// 실행환경 정보입니다.
		/// </summary>
		[Key(nameof(Environment))]
		[DataMember]
		public string Environment;

		/// <summary>
		/// WCF 요청의 유효성을 3가지 방식으로 검사합니다. ClientTag, AccessToken, User Credentials
		/// </summary>
		/// <param name="request">요청 메시지에 필요한 기본 구성 객체입니다.</param>
		/// <param name="response">응답 메시지에 필요한 기본 구성 객체입니다.</param>
		/// <returns>유효한 요청이면 true를 아니면 false를 반환합니다.</returns>
		public virtual bool ValidRequest(RequestBase request, MessagePackResponseBase response)
		{
			// string validClientTag = ""; // ConfigurationManager.AppSettings["validateClientTag"];
			// if (string.IsNullOrEmpty(validClientTag) == false)
			// {
			// 	if (request.ClientTag != validClientTag)
			// 	{
			// 		response.Acknowledge = AcknowledgeType.Failure;
			// 		response.ExceptionText = "알수 없는 WCF 요청입니다.";
			// 		return false;
			// 	}
			// }
			return true;
		}
	}

	public partial class LoadOption
	{
		public string Key { get; set; }

		public string Value { get; set; }
	}
}
