using System;

namespace Pro.Localization.SourceGenerator.Attributes;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
internal class GenerateFormatDataAttribute : Attribute
{
	public string FormatDataFileName { get; }

	public GenerateFormatDataAttribute(string formatDataFileName)
	{
		FormatDataFileName = formatDataFileName;
	}
}
