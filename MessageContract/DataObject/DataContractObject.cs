using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace Qrame.CoreFX.Library.MessageContract.DataObject
{
	[XmlRoot(ElementName = "header", Namespace = "contract.xsd")]
	public class Header
	{
		[XmlElement(ElementName = "application", Namespace = "contract.xsd")]
		public string Application { get; set; }
		[XmlElement(ElementName = "project", Namespace = "contract.xsd")]
		public string Project { get; set; }
		[XmlElement(ElementName = "transaction", Namespace = "contract.xsd")]
		public string Transaction { get; set; }
		[XmlElement(ElementName = "datasource", Namespace = "contract.xsd")]
		public string DataSource { get; set; }
		[XmlElement(ElementName = "use", Namespace = "contract.xsd")]
		public string Use { get; set; }
		[XmlElement(ElementName = "desc", Namespace = "contract.xsd")]
		public string Desc { get; set; }
		[XmlElement(ElementName = "modifieddate", Namespace = "contract.xsd")]
		public string ModifiedDate { get; set; }
	}

	[XmlRoot(ElementName = "param", Namespace = "contract.xsd")]
	public class Param
	{
		[XmlAttribute(AttributeName = "id")]
		public string ID { get; set; }
		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
		[XmlAttribute(AttributeName = "length")]
		public string Length { get; set; }
		[XmlAttribute(AttributeName = "value")]
		public string Value { get; set; }
	}

	[XmlRoot(ElementName = "statement", Namespace = "contract.xsd")]
	public class Statement
	{
		[XmlIgnore]
		public string Content { get; set; }

		[XmlText]
		public XmlNode[] CDataContent
		{
			get
			{
				var dummy = new XmlDocument();
				return new XmlNode[] { dummy.CreateCDataSection(Content) };
			}
			set
			{
				if (value == null)
				{
					Content = null;
					return;
				}

				if (value.Length != 1)
				{
					throw new InvalidOperationException($"Invalid array length {value.Length}");
				}

				var node0 = value[0];
				var cdata = node0 as XmlCDataSection;
				if (cdata == null)
				{
					throw new InvalidOperationException($"Invalid node type {node0.NodeType}");
				}

				Content = cdata.Data;
			}
		}

		[XmlElement(ElementName = "param", Namespace = "contract.xsd")]
		public List<Param> Param { get; set; }
		[XmlAttribute(AttributeName = "id")]
		public string ID { get; set; }
		[XmlAttribute(AttributeName = "seq")]
		public string Seq { get; set; }
		[XmlAttribute(AttributeName = "use")]
		public string Use { get; set; }
		[XmlAttribute(AttributeName = "timeout")]
		public string Timeout { get; set; }
		[XmlAttribute(AttributeName = "desc")]
		public string Desc { get; set; }
		[XmlAttribute(AttributeName = "modified")]
		public string Modified { get; set; }
	}

	[XmlRoot(ElementName = "commands", Namespace = "contract.xsd")]
	public class Commands
	{
		[XmlElement(ElementName = "statement", Namespace = "contract.xsd")]
		public List<Statement> Statement { get; set; }
	}

	[XmlRoot(ElementName = "mapper", Namespace = "contract.xsd")]
	public class DataContractObject
	{
		[XmlElement(ElementName = "header", Namespace = "contract.xsd")]
		public Header Header { get; set; }
		[XmlElement(ElementName = "commands", Namespace = "contract.xsd")]
		public Commands Commands { get; set; }
		[XmlAttribute(AttributeName = "xmlns")]
		public string Xmlns { get; set; }
	}
}
