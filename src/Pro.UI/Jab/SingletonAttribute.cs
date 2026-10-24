using System;
using System.CodeDom.Compiler;

namespace Jab;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
[GeneratedCode("Jab", null)]
internal class SingletonAttribute : Attribute
{
	public Type ServiceType { get; }

	public string? Name { get; set; }

	public Type? ImplementationType { get; }

	public string? Instance { get; set; }

	public string? Factory { get; set; }

	public SingletonAttribute(Type serviceType)
	{
		ServiceType = serviceType;
	}

	public SingletonAttribute(Type serviceType, Type implementationType)
	{
		ServiceType = serviceType;
		ImplementationType = implementationType;
	}
}
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
[GeneratedCode("Jab", null)]
internal class SingletonAttribute<TService> : Jab.SingletonAttribute
{
	public SingletonAttribute()
		: base(typeof(TService))
	{
	}
}
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
[GeneratedCode("Jab", null)]
internal class SingletonAttribute<TService, TImpl> : Jab.SingletonAttribute where TImpl : TService
{
	public SingletonAttribute()
		: base(typeof(TService), typeof(TImpl))
	{
	}
}
