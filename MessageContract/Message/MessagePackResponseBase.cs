using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using MessagePack;
using Qrame.CoreFX.Messages;

namespace Qrame.Core.Library.MessageContract.Message
{
	/// <summary>
	/// 응답에 대한 베이스 기능을 제공합니다.
	/// </summary>
	[MessagePackObject]
	[DataContract]
	public class MessagePackResponseBase
	{
		/// <summary>
		/// WCF 요청에 대한 기본적인 응답 여부에 대한 성공여부를 표현합니다.
		/// </summary>
		[Key(nameof(Acknowledge))]
		[DataMember]
		public AcknowledgeType Acknowledge = AcknowledgeType.Success;

		/// <summary>
		/// WCF 요청에 대한 식별자를 반환합니다.
		/// </summary>
		[Key(nameof(CorrelationID))]
		[DataMember]
		public string CorrelationID;

		/// <summary>
		/// WCF 응답에 대한 추가 메시지입니다.
		/// </summary>
		[Key(nameof(ExceptionText))]
		[DataMember]
		public string ExceptionText;

		/// <summary>
		/// WCF 응답에 대한 추가 정보입니다.
		/// </summary>
		[Key(nameof(Informations))]
		[DataMember]
		public string[] Informations;

		/// <summary>
		/// 개체에 대한 버전 번호의 부 버전 구성 요소 값을 가져옵니다.
		/// </summary>
		[Key(nameof(Version))]
		[DataMember]
		public string Version;

		/// <summary>
		/// 버전 번호의 빌드 버전 구성 요소 값을 가져옵니다.
		/// </summary>
		[Key(nameof(ResponseID))]
		[DataMember]
		public string ResponseID;

		/// <summary>
		/// 실행환경 정보입니다.
		/// </summary>
		[Key(nameof(Environment))]
		[DataMember]
		public string Environment;

		/// <summary>
		/// 영향을 받는 갯수를 표현합니다.
		/// </summary>
		[Key(nameof(RowsAffected))]
		[DataMember]
		public int RowsAffected;
	}
}
