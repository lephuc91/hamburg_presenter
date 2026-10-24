using Pro.Loro;

namespace Pro.Entity.Extensions;

internal static class BoolExtensions
{
	public static LoroValue ToLoroValue(this bool value)
	{
		return new LoroValue.Bool(value);
	}

	public static LoroValue ToLoroValue(this bool? value)
	{
		if (value.HasValue)
		{
			return new LoroValue.Bool(value.Value);
		}
		return new LoroValue.Null();
	}

	public static LoroValueLike ToLoroValueLike(this bool value)
	{
		return value.ToLoroValue().AsValueLike();
	}

	public static LoroValueLike ToLoroValueLike(this bool? value)
	{
		return value.ToLoroValue().AsValueLike();
	}
}
