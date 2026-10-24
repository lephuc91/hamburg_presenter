using System;
using System.Collections;
using System.Linq;

namespace Pro.Common.Utility;

public static class HashCodeHelper
{
	private const int NullHash = -1;

	public static int GenerateHashCode(params object?[] fields)
	{
		return GenerateHashCode(DefaultHashProvider, fields);
	}

	public static int GenerateHashCode(Func<object, int> hashProvider, params object?[] fields)
	{
		return GenerateHashCode(hashProvider, Array.Empty<IEnumerable>(), fields);
	}

	public static int GenerateHashCode(IEnumerable?[] collections, params object?[] fields)
	{
		return GenerateHashCode(DefaultHashProvider, collections, fields);
	}

	public static int GenerateHashCode(Func<object, int> hashProvider, IEnumerable?[] collections, params object?[] fields)
	{
		HashCode hashCode = default(HashCode);
		AddFields(hashProvider, fields, ref hashCode);
		IEnumerable[] array = collections ?? Array.Empty<IEnumerable>();
		foreach (IEnumerable fields2 in array)
		{
			AddFields(hashProvider, fields2, ref hashCode);
		}
		return hashCode.ToHashCode();
	}

	private static int DefaultHashProvider(object obj)
	{
		return obj.GetHashCode();
	}

	private static void AddFields(Func<object, int> hashProvider, IEnumerable? fields, ref HashCode hashCode)
	{
		foreach (object item in fields ?? Enumerable.Empty<object>())
		{
			hashCode.Add((item == null) ? (-1) : hashProvider(item));
		}
	}
}
