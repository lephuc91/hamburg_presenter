using System;

namespace Pro.Common.SourceGenerator.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
internal class NotifyCanExecuteChangedLinkAttribute : Attribute
{
	public string SourcePropertyName { get; }

	public string CommandName { get; }

	public NotifyCanExecuteChangedLinkAttribute(string sourcePropertyName, string commandName)
	{
		SourcePropertyName = sourcePropertyName;
		CommandName = commandName;
	}
}
