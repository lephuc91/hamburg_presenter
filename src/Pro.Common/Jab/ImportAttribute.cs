using System;
using System.CodeDom.Compiler;

namespace Jab;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
[GeneratedCode("Jab", null)]
internal class ImportAttribute : Attribute
{
	public Type ModuleType { get; }

	public ImportAttribute(Type moduleType)
	{
		ModuleType = moduleType;
	}
}
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
[GeneratedCode("Jab", null)]
internal class ImportAttribute<TModule> : ImportAttribute
{
	public ImportAttribute()
		: base(typeof(TModule))
	{
	}
}
