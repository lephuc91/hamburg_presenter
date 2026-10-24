using System;

namespace Pro.Common.Versioning;

[AttributeUsage(AttributeTargets.Assembly)]
public class DisplayVersionAttribute : Attribute
{
	public string Text { get; }

	public DisplayVersionAttribute(string text)
	{
		Text = text;
	}
}
