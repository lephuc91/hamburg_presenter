using System;
using System.Reflection;

namespace Pro.Common.Extensions;

public static class TypeExtensions
{
	public static object? Default(this Type source)
	{
		if (!source.IsValueType)
		{
			return null;
		}
		return Activator.CreateInstance(source);
	}

	public static T? GetCustomAttribute<T>(this Type source)
	{
		return source.GetCustomAttribute(typeof(T), inherit: true).TypeConversionCast<T>();
	}

	public static bool IsPrimitiveValueType(this Type source)
	{
		if (source == typeof(string))
		{
			return true;
		}
		return source.IsValueType & source.IsPrimitive;
	}
}
