using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using MessagePack;

namespace Qrame.Core.Library.MessageContract.DataObject
{
	[MessagePackObject]
	public class DynamicResult
	{
		[Key(nameof(ParseSQL))]
		public string ParseSQL;

		[Key(nameof(DynamicParameters))]
		public DynamicParameters DynamicParameters = null;

		[Key(nameof(ExceptionText))]
		public string ExceptionText;
	}
}
