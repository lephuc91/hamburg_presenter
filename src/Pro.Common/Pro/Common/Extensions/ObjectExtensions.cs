using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using Pro.Common.Collections;

namespace Pro.Common.Extensions;

public static class ObjectExtensions
{
	private sealed class ReferenceEqualityComparer : EqualityComparer<object>
	{
		public override bool Equals(object? x, object? y)
		{
			return x == y;
		}

		public override int GetHashCode(object obj)
		{
			return obj?.GetHashCode() ?? 0;
		}
	}

	private static readonly MethodInfo? CLONE_METHOD = typeof(object).GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic);

	public static T? TypeConversionCast<T>(this object? source)
	{
		return (T)(source?.TypeConversionCast(typeof(T)));
	}

	public static object? TypeConversionCast(this object? source, Type targetType)
	{
		if (targetType == null)
		{
			throw new ArgumentNullException("targetType");
		}
		if (source == null)
		{
			return null;
		}
		Type type = source.GetType();
		if (targetType.IsAssignableFrom(type))
		{
			return source;
		}
		if (targetType == typeof(string))
		{
			return TypeDescriptor.GetConverter(type).ConvertToString(null, CultureInfo.InvariantCulture, source);
		}
		TypeConverter converter = TypeDescriptor.GetConverter(targetType);
		if (converter.CanConvertFrom(type))
		{
			return converter.ConvertFrom(null, CultureInfo.InvariantCulture, source);
		}
		if (targetType.IsEnum)
		{
			return Enum.Parse(targetType, source.ToString() ?? string.Empty);
		}
		return Convert.ChangeType(source, targetType, CultureInfo.InvariantCulture);
	}

	public static T? DeepCopy<T>(this T? source)
	{
		return (T)((object?)source).DeepCopy();
	}

	public static object? DeepCopy(this object? source)
	{
		return InternalCopy(source, new Dictionary<object, object>(new ReferenceEqualityComparer()));
	}

	public static bool IsNumericType(this object source)
	{
		TypeCode typeCode = Type.GetTypeCode(source.GetType());
		if ((uint)(typeCode - 5) <= 10u)
		{
			return true;
		}
		return false;
	}

	private static object? InternalCopy(object? originalObject, IDictionary<object, object> visited)
	{
		if (originalObject == null)
		{
			return null;
		}
		Type type = originalObject.GetType();
		if (type.IsPrimitiveValueType())
		{
			return originalObject;
		}
		if (visited.ContainsKey(originalObject))
		{
			return visited[originalObject];
		}
		if (typeof(Delegate).IsAssignableFrom(type))
		{
			return null;
		}
		object obj = CLONE_METHOD?.Invoke(originalObject, null);
		if (type.IsArray)
		{
			Type elementType = type.GetElementType();
			if (elementType != null && !elementType.IsPrimitiveValueType())
			{
				Array clonedArray = (Array)obj;
				clonedArray?.ForEach(delegate(Array array, int[] indices)
				{
					array.SetValue(InternalCopy(clonedArray.GetValue(indices), visited), indices);
				});
			}
		}
		if (obj != null)
		{
			visited.Add(originalObject, obj);
			CopyFields(originalObject, visited, obj, type);
			RecursiveCopyBaseTypePrivateFields(originalObject, visited, obj, type);
		}
		return obj;
	}

	private static void CopyFields(object originalObject, IDictionary<object, object> visited, object cloneObject, Type typeToReflect, BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy, Func<FieldInfo, bool>? filter = null)
	{
		FieldInfo[] fields = typeToReflect.GetFields(bindingFlags);
		foreach (FieldInfo fieldInfo in fields)
		{
			if ((filter == null || filter(fieldInfo)) && !fieldInfo.FieldType.IsPrimitiveValueType())
			{
				object value = InternalCopy(fieldInfo.GetValue(originalObject), visited);
				fieldInfo.SetValue(cloneObject, value);
			}
		}
	}

	private static void RecursiveCopyBaseTypePrivateFields(object originalObject, IDictionary<object, object> visited, object cloneObject, Type typeToReflect)
	{
		if (typeToReflect.BaseType != null)
		{
			RecursiveCopyBaseTypePrivateFields(originalObject, visited, cloneObject, typeToReflect.BaseType);
			CopyFields(originalObject, visited, cloneObject, typeToReflect.BaseType, BindingFlags.Instance | BindingFlags.NonPublic, (FieldInfo info) => info.IsPrivate);
		}
	}
}
