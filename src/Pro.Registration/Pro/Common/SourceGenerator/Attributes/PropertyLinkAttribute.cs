using System;

namespace Pro.Common.SourceGenerator.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
internal class PropertyLinkAttribute : Attribute
{
	public string SourcePropertyName { get; }

	public string DestinationPropertyName { get; }

	public PropertyLinkAttribute(string sourcePropertyName, string destinationPropertyName)
	{
		SourcePropertyName = sourcePropertyName;
		DestinationPropertyName = destinationPropertyName;
	}
}
