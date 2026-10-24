using Pro.Loro;

namespace Pro.Entity.Extensions;

internal static class UIntExtensions
{
	public static LoroValue ToLoroValue(this uint value)
	{
		return new LoroValue.I64(value);
	}

	public static LoroValue ToLoroValue(this uint? value)
	{
		if (value.HasValue)
		{
			return new LoroValue.I64(value.Value);
		}
		return new LoroValue.Null();
	}

	public static LoroValueLike ToLoroValueLike(this uint value)
	{
		return value.ToLoroValue().AsValueLike();
	}

	public static LoroValueLike ToLoroValueLike(this uint? value)
	{
		return value.ToLoroValue().AsValueLike();
	}
}
