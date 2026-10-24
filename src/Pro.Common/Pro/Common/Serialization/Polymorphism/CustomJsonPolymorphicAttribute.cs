using System;

namespace Pro.Common.Serialization.Polymorphism;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
public sealed class CustomJsonPolymorphicAttribute : Attribute
{
	public string? TypeDiscriminatorPropertyName { get; set; }
}
