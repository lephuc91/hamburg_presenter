using Pro.Loro;

namespace Pro.Entity.Extensions;

internal static class ULongExtensions
{
	public static LoroValue ToLoroValue(this ulong value)
	{
		return new LoroValue.I64((long)value);
	}

	public static LoroValue ToLoroValue(this ulong? value)
	{
		if (value.HasValue)
		{
			return new LoroValue.I64((long)value.Value);
		}
		return new LoroValue.Null();
	}

	public static LoroValueLike ToLoroValueLike(this ulong value)
	{
		return value.ToLoroValue().AsValueLike();
	}

	public static LoroValueLike ToLoroValueLike(this ulong? value)
	{
		return value.ToLoroValue().AsValueLike();
	}
}
