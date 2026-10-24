using System;

namespace Pro.Common.SourceGenerator.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
internal class AsyncDisposableAttribute : Attribute
{
	public string[] DisposedItems { get; }

	public string AsyncExedcutorFiledName { get; }

	public string DisposeCallbackMethodName { get; }

	public AsyncDisposableAttribute(string asyncExedcutorFiledName, string disposeCallbackMethodName, params string[] disposedItems)
	{
		DisposedItems = disposedItems;
		AsyncExedcutorFiledName = asyncExedcutorFiledName;
		DisposeCallbackMethodName = disposeCallbackMethodName;
	}
}
