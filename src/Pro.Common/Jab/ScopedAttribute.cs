using System;
using System.CodeDom.Compiler;

namespace Jab;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
[GeneratedCode("Jab", null)]
internal class ScopedAttribute : Attribute
{
	public Type ServiceType { get; }

	public string? Name { get; set; }

	public Type? ImplementationType { get; }

	public string? Factory { get; set; }

	public ScopedAttribute(Type serviceType)
	{
		ServiceType = serviceType;
	}

	public ScopedAttribute(Type serviceType, Type implementationType)
	{
		ServiceType = serviceType;
		ImplementationType = implementationType;
	}
}
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
[GeneratedCode("Jab", null)]
internal class ScopedAttribute<TService> : ScopedAttribute
{
	public ScopedAttribute()
		: base(typeof(TService))
	{
	}
}
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
[GeneratedCode("Jab", null)]
internal class ScopedAttribute<TService, TImpl> : ScopedAttribute where TImpl : TService
{
	public ScopedAttribute()
		: base(typeof(TService), typeof(TImpl))
	{
	}
}
