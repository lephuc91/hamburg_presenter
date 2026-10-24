using System;
using Pro.Common.Operations;
using Pro.Loro;

namespace Pro.Entity.Extensions;

internal static class DoubleExtensions
{
	public static LoroValue ToLoroValue(this double value)
	{
		return new LoroValue.Double(value);
	}

	public static LoroValue ToLoroValue(this double? value)
	{
		if (value.HasValue)
		{
			return new LoroValue.Double(value.Value);
		}
		return new LoroValue.Null();
	}

	public static LoroValueLike ToLoroValueLike(this double value)
	{
		return value.ToLoroValue().AsValueLike();
	}

	public static LoroValueLike ToLoroValueLike(this double? value)
	{
		return value.ToLoroValue().AsValueLike();
	}

	public static float ToFloat(this double value)
	{
		if (!double.IsNaN(value))
		{
			if (value != double.NegativeInfinity)
			{
				if (value == double.PositiveInfinity)
				{
					return float.PositiveInfinity;
				}
				return Math.Min(3.4028234663852886E+38, Math.Max(-3.4028234663852886E+38, value)).Cast<float, double>();
			}
			return float.NegativeInfinity;
		}
		return float.NaN;
	}
}
