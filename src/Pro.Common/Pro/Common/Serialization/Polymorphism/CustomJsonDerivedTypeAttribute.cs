using System;

namespace Pro.Common.Serialization.Polymorphism;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = false)]
public class CustomJsonDerivedTypeAttribute : Attribute
{
	public Type DerivedType { get; }

	public string TypeDiscriminator { get; }

	public CustomJsonDerivedTypeAttribute(Type derivedType, string typeDiscriminator)
	{
		DerivedType = derivedType;
		TypeDiscriminator = typeDiscriminator;
	}
}
