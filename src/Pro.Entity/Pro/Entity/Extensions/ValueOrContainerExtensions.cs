using System;
using Pro.Loro;

namespace Pro.Entity.Extensions;

internal static class ValueOrContainerExtensions
{
	public static bool ToBool(this ValueOrContainer? value)
	{
		if (value?.AsValue() is LoroValue.Bool @bool)
		{
			return @bool.value;
		}
		return false;
	}

	public static bool? ToNullableBool(this ValueOrContainer? value)
	{
		if (value?.AsValue() is LoroValue.Bool @bool)
		{
			return @bool.value;
		}
		return null;
	}

	public static byte[] ToByteArray(this ValueOrContainer? value)
	{
		if (value?.AsValue() is LoroValue.Binary binary)
		{
			return binary.value;
		}
		return Array.Empty<byte>();
	}

	public static byte[]? ToNullableByteArray(this ValueOrContainer? value)
	{
		if (value?.AsValue() is LoroValue.Binary binary)
		{
			return binary.value;
		}
		return null;
	}

	public static double ToDouble(this ValueOrContainer? value)
	{
		if (value?.AsValue() is LoroValue.Double @double)
		{
			return @double.value;
		}
		return 0.0;
	}

	public static double? ToNullableDouble(this ValueOrContainer? value)
	{
		if (value?.AsValue() is LoroValue.Double @double)
		{
			return @double.value;
		}
		return null;
	}

	public static float? ToNullableFloat(this ValueOrContainer? value)
	{
		if (value?.AsValue() is LoroValue.Double @double)
		{
			return @double.value.ToFloat();
		}
		return null;
	}

	public static TEnum ToEnum<TEnum>(this ValueOrContainer? value) where TEnum : struct, Enum
	{
		if (value?.AsValue() is LoroValue.I64 i)
		{
			return i.value.ToEnum<TEnum>();
		}
		return default(TEnum);
	}

	public static TEnum? ToNullableEnum<TEnum>(this ValueOrContainer? value) where TEnum : struct, Enum
	{
		if (value?.AsValue() is LoroValue.I64 i)
		{
			return i.value.ToEnum<TEnum>();
		}
		return null;
	}

	public static long ToLong(this ValueOrContainer? value)
	{
		if (value?.AsValue() is LoroValue.I64 i)
		{
			return i.value;
		}
		return 0L;
	}

	public static long? ToNullableLong(this ValueOrContainer? value)
	{
		if (value?.AsValue() is LoroValue.I64 i)
		{
			return i.value;
		}
		return null;
	}

	public static ulong? ToNullableUlong(this ValueOrContainer? value)
	{
		if (value?.AsValue() is LoroValue.I64 i)
		{
			return i.value.ToUlong();
		}
		return null;
	}

	public static uint? ToNullableUint(this ValueOrContainer? value)
	{
		if (value?.AsValue() is LoroValue.I64 i)
		{
			return i.value.ToUint();
		}
		return null;
	}

	public static int? ToNullableInt(this ValueOrContainer? value)
	{
		if (value?.AsValue() is LoroValue.I64 i)
		{
			return i.value.ToInt();
		}
		return null;
	}

	public static string ToStringValue(this ValueOrContainer? value)
	{
		if (value?.AsValue() is LoroValue.String @string)
		{
			return @string.value;
		}
		return string.Empty;
	}

	public static string? ToNullableString(this ValueOrContainer? value)
	{
		if (value?.AsValue() is LoroValue.String @string)
		{
			return @string.value;
		}
		return null;
	}

	public static Guid ToGuidValue(this ValueOrContainer? value)
	{
		if (value?.AsValue() is LoroValue.String @string && Guid.TryParse(@string.value, out var result))
		{
			return result;
		}
		return Guid.Empty;
	}

	public static Guid? ToNullableGuid(this ValueOrContainer? value)
	{
		if (value?.AsValue() is LoroValue.String @string && Guid.TryParse(@string.value, out var result))
		{
			return result;
		}
		return null;
	}
}
