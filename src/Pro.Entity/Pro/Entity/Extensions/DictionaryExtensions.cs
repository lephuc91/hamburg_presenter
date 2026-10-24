using System;
using System.Collections.Generic;
using Pro.Loro;

namespace Pro.Entity.Extensions;

internal static class DictionaryExtensions
{
	public static Dictionary<string, LoroValue> GetMap(this Dictionary<string, LoroValue> value, string key)
	{
		if (value.TryGetValue(key, out LoroValue value2) && value2 is LoroValue.Map map)
		{
			return map.value;
		}
		return new Dictionary<string, LoroValue>();
	}

	public static string GetString(this Dictionary<string, LoroValue> value, string key)
	{
		if (value.TryGetValue(key, out LoroValue value2) && value2 is LoroValue.String @string)
		{
			return @string.value;
		}
		return string.Empty;
	}

	public static string? GetNullableString(this Dictionary<string, LoroValue> value, string key)
	{
		if (value.TryGetValue(key, out LoroValue value2) && value2 is LoroValue.String @string)
		{
			return @string.value;
		}
		return null;
	}

	public static Guid GetGuid(this Dictionary<string, LoroValue> value, string key)
	{
		if (value.TryGetValue(key, out LoroValue value2) && value2 is LoroValue.String @string && Guid.TryParse(@string.value, out var result))
		{
			return result;
		}
		return Guid.Empty;
	}

	public static Guid? GetNullableGuid(this Dictionary<string, LoroValue> value, string key)
	{
		if (value.TryGetValue(key, out LoroValue value2) && value2 is LoroValue.String @string && Guid.TryParse(@string.value, out var result))
		{
			return result;
		}
		return null;
	}

	public static double GetDouble(this Dictionary<string, LoroValue> value, string key)
	{
		if (value.TryGetValue(key, out LoroValue value2) && value2 is LoroValue.Double @double)
		{
			return @double.value;
		}
		return 0.0;
	}

	public static double? GetNullableDouble(this Dictionary<string, LoroValue> value, string key)
	{
		if (value.TryGetValue(key, out LoroValue value2) && value2 is LoroValue.Double @double)
		{
			return @double.value;
		}
		return null;
	}

	public static float GetFloat(this Dictionary<string, LoroValue> value, string key)
	{
		return value.GetDouble(key).ToFloat();
	}

	public static float? GetNullableFloat(this Dictionary<string, LoroValue> value, string key)
	{
		if (value.TryGetValue(key, out LoroValue value2) && value2 is LoroValue.Double @double)
		{
			return @double.value.ToFloat();
		}
		return null;
	}

	public static long GetLong(this Dictionary<string, LoroValue> value, string key)
	{
		if (value.TryGetValue(key, out LoroValue value2) && value2 is LoroValue.I64 i)
		{
			return i.value;
		}
		return 0L;
	}

	public static long? GetNullableLong(this Dictionary<string, LoroValue> value, string key)
	{
		if (value.TryGetValue(key, out LoroValue value2) && value2 is LoroValue.I64 i)
		{
			return i.value;
		}
		return null;
	}

	public static ulong GetUlong(this Dictionary<string, LoroValue> value, string key)
	{
		return value.GetLong(key).ToUlong();
	}

	public static ulong? GetNullableUlong(this Dictionary<string, LoroValue> value, string key)
	{
		if (value.TryGetValue(key, out LoroValue value2) && value2 is LoroValue.I64 i)
		{
			return i.value.ToUlong();
		}
		return null;
	}

	public static uint GetUint(this Dictionary<string, LoroValue> value, string key)
	{
		return value.GetLong(key).ToUint();
	}

	public static uint? GetNullableUint(this Dictionary<string, LoroValue> value, string key)
	{
		if (value.TryGetValue(key, out LoroValue value2) && value2 is LoroValue.I64 i)
		{
			return i.value.ToUint();
		}
		return null;
	}

	public static int GetInt(this Dictionary<string, LoroValue> value, string key)
	{
		return value.GetLong(key).ToInt();
	}

	public static int? GetNullableInt(this Dictionary<string, LoroValue> value, string key)
	{
		if (value.TryGetValue(key, out LoroValue value2) && value2 is LoroValue.I64 i)
		{
			return i.value.ToInt();
		}
		return null;
	}

	public static byte[] GetBytes(this Dictionary<string, LoroValue> value, string key)
	{
		if (value.TryGetValue(key, out LoroValue value2) && value2 is LoroValue.Binary binary)
		{
			return binary.value;
		}
		return Array.Empty<byte>();
	}

	public static byte[]? GetNullableBytes(this Dictionary<string, LoroValue> value, string key)
	{
		if (value.TryGetValue(key, out LoroValue value2) && value2 is LoroValue.Binary binary)
		{
			return binary.value;
		}
		return null;
	}

	public static T GetEnum<T>(this Dictionary<string, LoroValue> value, string key) where T : struct, Enum
	{
		if (value.TryGetValue(key, out LoroValue value2) && value2 is LoroValue.I64 i)
		{
			return i.value.ToEnum<T>();
		}
		return default(T);
	}

	public static T? GetNullableEnum<T>(this Dictionary<string, LoroValue> value, string key) where T : struct, Enum
	{
		if (value.TryGetValue(key, out LoroValue value2) && value2 is LoroValue.I64 i)
		{
			return i.value.ToEnum<T>();
		}
		return null;
	}

	public static bool GetBool(this Dictionary<string, LoroValue> value, string key)
	{
		if (value.TryGetValue(key, out LoroValue value2) && value2 is LoroValue.Bool @bool)
		{
			return @bool.value;
		}
		return false;
	}

	public static bool? GetNullableBool(this Dictionary<string, LoroValue> value, string key)
	{
		if (value.TryGetValue(key, out LoroValue value2) && value2 is LoroValue.Bool @bool)
		{
			return @bool.value;
		}
		return null;
	}

	public static List<LoroValue> GetList(this Dictionary<string, LoroValue> value, string key)
	{
		if (value.TryGetValue(key, out LoroValue value2) && value2 is LoroValue.List list)
		{
			return list.value;
		}
		return new List<LoroValue>();
	}

	public static T? TryDeserialize<T>(this Dictionary<string, LoroValue> value, string key, Func<Dictionary<string, LoroValue>, T> deserialize) where T : class
	{
		if (value.TryGetValue(key, out LoroValue value2) && value2 is LoroValue.Map map)
		{
			return deserialize(map.value);
		}
		return null;
	}

	public static T? TryDeserializeOrNull<T>(this Dictionary<string, LoroValue> value, string key, Func<Dictionary<string, LoroValue>, T?> deserialize) where T : class
	{
		if (value.TryGetValue(key, out LoroValue value2) && value2 is LoroValue.Map map)
		{
			return deserialize(map.value);
		}
		return null;
	}
}
