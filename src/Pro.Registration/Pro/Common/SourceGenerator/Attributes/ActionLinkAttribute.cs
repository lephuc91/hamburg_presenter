using System;

namespace Pro.Common.SourceGenerator.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
internal class ActionLinkAttribute : Attribute
{
	public string SourcePropertyName { get; }

	public string DestinationActionName { get; }

	public ActionLinkAttribute(string sourcePropertyName, string destinationActionName)
	{
		SourcePropertyName = sourcePropertyName;
		DestinationActionName = destinationActionName;
	}
}
