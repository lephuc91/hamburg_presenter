using Pro.Loro;

namespace Pro.Entity.Extensions;

internal static class IntExtensions
{
	public static LoroValue ToLoroValue(this int value)
	{
		return new LoroValue.I64(value);
	}

	public static LoroValue ToLoroValue(this int? value)
	{
		if (value.HasValue)
		{
			return new LoroValue.I64(value.Value);
		}
		return new LoroValue.Null();
	}

	public static LoroValueLike ToLoroValueLike(this int value)
	{
		return value.ToLoroValue().AsValueLike();
	}

	public static LoroValueLike ToLoroValueLike(this int? value)
	{
		return value.ToLoroValue().AsValueLike();
	}
}
