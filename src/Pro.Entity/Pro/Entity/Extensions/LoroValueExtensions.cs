using System;
using System.Collections.Generic;
using Pro.Loro;

namespace Pro.Entity.Extensions;

internal static class LoroValueExtensions
{
	private sealed class ValueLike(LoroValue _value) : LoroValueLike
	{
		public LoroValue AsLoroValue()
		{
			return _value;
		}
	}

	public static bool ToBool(this LoroValue? value)
	{
		if (value is LoroValue.Bool @bool)
		{
			return @bool.value;
		}
		return false;
	}

	public static bool? ToNullableBool(this LoroValue? value)
	{
		if (value is LoroValue.Bool @bool)
		{
			return @bool.value;
		}
		return null;
	}

	public static byte[] ToByteArray(this LoroValue? value)
	{
		if (value is LoroValue.Binary binary)
		{
			return binary.value;
		}
		return Array.Empty<byte>();
	}

	public static byte[]? ToNullableByteArray(this LoroValue? value)
	{
		if (value is LoroValue.Binary binary)
		{
			return binary.value;
		}
		return null;
	}

	public static double ToDouble(this LoroValue? value)
	{
		if (value is LoroValue.Double @double)
		{
			return @double.value;
		}
		return 0.0;
	}

	public static double? ToNullableDouble(this LoroValue? value)
	{
		if (value is LoroValue.Double @double)
		{
			return @double.value;
		}
		return null;
	}

	public static TEnum ToEnum<TEnum>(this LoroValue? value) where TEnum : struct, Enum
	{
		if (value is LoroValue.I64 i)
		{
			return i.value.ToEnum<TEnum>();
		}
		return default(TEnum);
	}

	public static TEnum? ToNullableEnum<TEnum>(this LoroValue? value) where TEnum : struct, Enum
	{
		if (value is LoroValue.I64 i)
		{
			return i.value.ToEnum<TEnum>();
		}
		return null;
	}

	public static long ToLong(this LoroValue? value)
	{
		if (value is LoroValue.I64 i)
		{
			return i.value;
		}
		return 0L;
	}

	public static long? ToNullableLong(this LoroValue? value)
	{
		if (value is LoroValue.I64 i)
		{
			return i.value;
		}
		return null;
	}

	public static string ToStringValue(this LoroValue? value)
	{
		if (value is LoroValue.String @string)
		{
			return @string.value;
		}
		return string.Empty;
	}

	public static string? ToNullableStringValue(this LoroValue? value)
	{
		if (value is LoroValue.String @string)
		{
			return @string.value;
		}
		return null;
	}

	public static Guid ToGuidValue(this LoroValue? value)
	{
		if (value is LoroValue.String @string && Guid.TryParse(@string.value, out var result))
		{
			return result;
		}
		return Guid.Empty;
	}

	public static Guid? ToNullableGuidValue(this LoroValue? value)
	{
		if (value is LoroValue.String @string && Guid.TryParse(@string.value, out var result))
		{
			return result;
		}
		return null;
	}

	public static Dictionary<string, LoroValue> ToDictionary(this LoroValue? value)
	{
		if (value is LoroValue.Map map)
		{
			return map.value;
		}
		return new Dictionary<string, LoroValue>();
	}

	public static T? TryDeserialize<T>(this LoroValue? value, Func<Dictionary<string, LoroValue>, T> deserialize) where T : class
	{
		if (value is LoroValue.Map map)
		{
			return deserialize(map.value);
		}
		return null;
	}

	public static LoroValueLike AsValueLike(this LoroValue value)
	{
		return new ValueLike(value);
	}
}
