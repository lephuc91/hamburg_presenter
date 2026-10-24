using System;
using System.Reflection;

namespace Pro.Common.Utility;

public static class ReflectionHelper
{
	public static FieldInfo? GetField<T>(string name, BindingFlags flags)
	{
		return GetField(typeof(T), name, flags);
	}

	public static FieldInfo? GetField(Type type, string name, BindingFlags flags)
	{
		FieldInfo field = type.GetField(name, flags);
		if (!(field == null) || !(type.BaseType != null))
		{
			return field;
		}
		return GetField(type.BaseType, name, flags);
	}
}
