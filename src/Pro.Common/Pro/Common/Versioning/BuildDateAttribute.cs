using System;

namespace Pro.Common.Versioning;

[AttributeUsage(AttributeTargets.Assembly)]
public class BuildDateAttribute : Attribute
{
	public string Date { get; }

	public bool WasEmpty { get; }

	public BuildDateAttribute(string value)
	{
		WasEmpty = string.IsNullOrWhiteSpace(value);
		string text = value;
		if (string.IsNullOrWhiteSpace(value))
		{
			text = DateTime.Now.ToString("MMM dd yyyy");
		}
		Date = text;
	}
}
