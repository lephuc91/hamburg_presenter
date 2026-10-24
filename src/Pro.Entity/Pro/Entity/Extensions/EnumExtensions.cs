using System;
using Pro.Common.Operations;
using Pro.Loro;

namespace Pro.Entity.Extensions;

internal static class EnumExtensions
{
	public static LoroValue ToLoroValue<TEnum>(this TEnum value) where TEnum : struct, Enum
	{
		return new LoroValue.I64(value.Cast<long, TEnum>());
	}

	public static LoroValue ToLoroValue<TEnum>(this TEnum? value) where TEnum : struct, Enum
	{
		if (value.HasValue)
		{
			return new LoroValue.I64(value.Value.Cast<long, TEnum>());
		}
		return new LoroValue.Null();
	}

	public static LoroValueLike ToLoroValueLike<TEnum>(this TEnum value) where TEnum : struct, Enum
	{
		return value.ToLoroValue().AsValueLike();
	}

	public static LoroValueLike ToLoroValueLike<TEnum>(this TEnum? value) where TEnum : struct, Enum
	{
		return value.ToLoroValue().AsValueLike();
	}
}
