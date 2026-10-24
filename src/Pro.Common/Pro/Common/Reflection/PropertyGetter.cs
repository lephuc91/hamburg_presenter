using System;

namespace Pro.Common.Reflection;

public class PropertyGetter
{
	public string Name { get; }

	public Type TargetType { get; }

	public PropertyGetterDelegate Invoke { get; }

	internal PropertyGetter(string name, Type targetType, PropertyGetterDelegate invoke)
	{
		Name = name;
		TargetType = targetType;
		Invoke = invoke;
	}
}
