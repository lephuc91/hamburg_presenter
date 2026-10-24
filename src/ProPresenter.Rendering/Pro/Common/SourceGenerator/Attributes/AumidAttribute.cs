using System;

namespace Pro.Common.SourceGenerator.Attributes;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
internal class AumidAttribute : Attribute
{
	public string? FileName { get; }

	public AumidAttribute(string? fileName = null)
	{
		FileName = fileName;
	}
}
