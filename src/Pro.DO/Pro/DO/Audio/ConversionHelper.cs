using System;
using Pro.Common.Mathematics;

namespace Pro.DO.Audio;

public static class ConversionHelper
{
	public enum PowerLowerRange
	{
		Extended,
		Min
	}

	public enum PowerUpperRange
	{
		Unity,
		Max
	}

	private static readonly double PFRExtendedMin = DecibelsToPower(-100.0);

	private static readonly double PFRMin = DecibelsToPower(-60.0);

	private static readonly double PFRUnity = DecibelsToPower(0.0);

	private static readonly double PFRMax = DecibelsToPower(6.0);

	public static double DecibelsToPower(double decibels)
	{
		return LinearToPower(DecibelsToLinear(decibels));
	}

	public static double PowerToDecibels(double power)
	{
		return LinearToDecibels(PowerToLinear(power));
	}

	public static double DecibelsToPowerFeatureRange(double decibels, PowerLowerRange lowerRange = PowerLowerRange.Min, PowerUpperRange upperRange = PowerUpperRange.Max)
	{
		return LinearToPowerFeatureRange(DecibelsToLinear(decibels), lowerRange, upperRange);
	}

	public static double PowerFeatureRangeToDecibels(double powerFeatureRange, PowerLowerRange lowerRange = PowerLowerRange.Min, PowerUpperRange upperRange = PowerUpperRange.Max)
	{
		return LinearToDecibels(PowerFeatureRangeToLinear(powerFeatureRange, lowerRange, upperRange));
	}

	public static double DecibelsToLinear(double decibels)
	{
		return Math.Pow(10.0, decibels / 20.0);
	}

	public static double LinearToDecibels(double linear)
	{
		return 20.0 * Math.Log10(linear);
	}

	public static double LinearToPower(double linear)
	{
		return Math.Sqrt(linear);
	}

	public static double PowerToLinear(double power)
	{
		return power * power;
	}

	public static double LinearToPowerFeatureRange(double linear, PowerLowerRange lowerRange = PowerLowerRange.Min, PowerUpperRange upperRange = PowerUpperRange.Max)
	{
		GetPowerFeatureRangeCaps(lowerRange, upperRange, out var min, out var max);
		return LinearToPower(linear).ToFeatureRange(min, max);
	}

	public static double PowerFeatureRangeToLinear(double powerFeatureRange, PowerLowerRange lowerRange = PowerLowerRange.Min, PowerUpperRange upperRange = PowerUpperRange.Max)
	{
		GetPowerFeatureRangeCaps(lowerRange, upperRange, out var min, out var max);
		return PowerToLinear(powerFeatureRange.ToTargetRange(min, max));
	}

	private static void GetPowerFeatureRangeCaps(PowerLowerRange lowerRange, PowerUpperRange upperRange, out double min, out double max)
	{
		switch (lowerRange)
		{
		case PowerLowerRange.Extended:
			min = PFRExtendedMin;
			break;
		case PowerLowerRange.Min:
			min = PFRMin;
			break;
		default:
			throw new NotSupportedException();
		}
		switch (upperRange)
		{
		case PowerUpperRange.Unity:
			max = PFRUnity;
			break;
		case PowerUpperRange.Max:
			max = PFRMax;
			break;
		default:
			throw new NotSupportedException();
		}
	}
}
