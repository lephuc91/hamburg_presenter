using System;

namespace Pro.Common.SourceGenerator.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
internal class DisposableAttribute : Attribute
{
	public string[] DisposedItems { get; }

	public DisposableAttribute(params string[] disposedItems)
	{
		DisposedItems = disposedItems;
	}
}
