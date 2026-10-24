using System;

namespace Pro.Text;

[AttributeUsage(AttributeTargets.Property)]
public class TextDocumentAttribute : Attribute
{
	public TextAttributeType Type { get; }

	public TextDocumentAttribute(TextAttributeType attributeType = TextAttributeType.None)
	{
		Type = attributeType;
	}
}
