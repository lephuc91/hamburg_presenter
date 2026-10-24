using System;
using Pro.Loro;

namespace Pro.Entity.Extensions;

internal static class GuidExtensions
{
	public static LoroValue ToLoroValue(this Guid value)
	{
		return new LoroValue.String(value.ToString("D"));
	}

	public static LoroValue ToLoroValue(this Guid? value)
	{
		if (value.HasValue)
		{
			return value.Value.ToLoroValue();
		}
		return new LoroValue.Null();
	}

	public static LoroValueLike ToLoroValueLike(this Guid value)
	{
		return value.ToLoroValue().AsValueLike();
	}

	public static LoroValueLike ToLoroValueLike(this Guid? value)
	{
		return value.ToLoroValue().AsValueLike();
	}
}
