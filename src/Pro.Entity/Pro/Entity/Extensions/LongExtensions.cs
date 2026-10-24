using System;
using System.Linq;
using Pro.Common.Operations;
using Pro.Loro;

namespace Pro.Entity.Extensions;

internal static class LongExtensions
{
	public static LoroValue ToLoroValue(this long value)
	{
		return new LoroValue.I64(value);
	}

	public static LoroValue ToLoroValue(this long? value)
	{
		if (value.HasValue)
		{
			return new LoroValue.I64(value.Value);
		}
		return new LoroValue.Null();
	}

	public static LoroValueLike ToLoroValueLike(this long value)
	{
		return value.ToLoroValue().AsValueLike();
	}

	public static LoroValueLike ToLoroValueLike(this long? value)
	{
		return value.ToLoroValue().AsValueLike();
	}

	public static uint ToUint(this long value)
	{
		return Math.Min(4294967295L, Math.Max(0L, value)).Cast<uint, long>();
	}

	public static int ToInt(this long value)
	{
		return Math.Min(2147483647L, Math.Max(-2147483648L, value)).Cast<int, long>();
	}

	public static ulong ToUlong(this long value)
	{
		return value.Cast<ulong, long>();
	}

	public static TEnum ToEnum<TEnum>(this long value) where TEnum : struct, Enum
	{
		TEnum[] values = Enum.GetValues<TEnum>();
		TEnum val = value.Cast<TEnum, long>();
		if (values.Contains(val))
		{
			return val;
		}
		return default(TEnum);
	}
}
