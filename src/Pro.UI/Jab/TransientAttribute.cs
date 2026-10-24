using System;
using System.CodeDom.Compiler;

namespace Jab;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
[GeneratedCode("Jab", null)]
internal class TransientAttribute : Attribute
{
	public Type ServiceType { get; }

	public string? Name { get; set; }

	public Type? ImplementationType { get; }

	public string? Factory { get; set; }

	public TransientAttribute(Type serviceType)
	{
		ServiceType = serviceType;
	}

	public TransientAttribute(Type serviceType, Type implementationType)
	{
		ServiceType = serviceType;
		ImplementationType = implementationType;
	}
}
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
[GeneratedCode("Jab", null)]
internal class TransientAttribute<TService> : Jab.TransientAttribute
{
	public TransientAttribute()
		: base(typeof(TService))
	{
	}
}
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
[GeneratedCode("Jab", null)]
internal class TransientAttribute<TService, TImpl> : Jab.TransientAttribute where TImpl : TService
{
	public TransientAttribute()
		: base(typeof(TService), typeof(TImpl))
	{
	}
}
