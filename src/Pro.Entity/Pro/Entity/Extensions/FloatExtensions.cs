using Pro.Loro;

namespace Pro.Entity.Extensions;

internal static class FloatExtensions
{
	public static LoroValue ToLoroValue(this float value)
	{
		return new LoroValue.Double(value);
	}

	public static LoroValue ToLoroValue(this float? value)
	{
		if (value.HasValue)
		{
			return new LoroValue.Double(value.Value);
		}
		return new LoroValue.Null();
	}

	public static LoroValueLike ToLoroValueLike(this float value)
	{
		return value.ToLoroValue().AsValueLike();
	}

	public static LoroValueLike ToLoroValueLike(this float? value)
	{
		return value.ToLoroValue().AsValueLike();
	}
}
