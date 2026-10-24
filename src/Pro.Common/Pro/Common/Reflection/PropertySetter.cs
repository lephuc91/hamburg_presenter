using System;

namespace Pro.Common.Reflection;

public class PropertySetter
{
	public string Name { get; }

	public Type TargetType { get; }

	public PropertySetterDelegate Invoke { get; }

	internal PropertySetter(string name, Type targetType, PropertySetterDelegate invoke)
	{
		Name = name;
		TargetType = targetType;
		Invoke = invoke;
	}
}
