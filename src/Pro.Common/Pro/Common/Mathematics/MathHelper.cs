using System;
using Pro.Common.Operations;

namespace Pro.Common.Mathematics;

public static class MathHelper
{
	private static double ToRad(double d)
	{
		return d * Math.PI / 180.0;
	}

	private static double ToDeg(double r)
	{
		return r / Math.PI * 180.0;
	}

	public static T Cos<T>(this T a)
	{
		return Math.Cos(ToRad(a.Cast<double, T>())).Cast<T, double>();
	}

	public static T Sin<T>(this T a)
	{
		return Math.Sin(ToRad(a.Cast<double, T>())).Cast<T, double>();
	}

	public static T Tan<T>(this T a)
	{
		return Math.Tan(ToRad(a.Cast<double, T>())).Cast<T, double>();
	}

	public static double Atan2(double y, double x)
	{
		return ToDeg(Math.Atan2(y, x));
	}

	public static Vector2<T> Orient<T>(this bool isHorizontal, T pos, T magnitude)
	{
		if (isHorizontal)
		{
			return new Vector2<T>(magnitude, pos);
		}
		return new Vector2<T>(pos, magnitude);
	}

	public static T Squared<T>(this T value)
	{
		return value.Multiply(value);
	}

	public static T Cubed<T>(this T value)
	{
		return value.Multiply(value).Multiply(value);
	}

	public static T Sqrt<T>(this T value)
	{
		return Math.Sqrt(value.Cast<double, T>()).Cast<T, double>();
	}

	public static T Cbrt<T>(this T value)
	{
		double v = value.Cast<double, T>();
		return (v.Sign() * Math.Pow(v.Abs(), 1.0 / 3.0)).Cast<T, double>();
	}

	public static T Mod<T>(this T v, T m)
	{
		return v.Modulo(m).Add(m).Modulo(m);
	}

	public static bool IsOdd<T>(this T v)
	{
		return !v.Mod(Constants<T>.Two).Equal(Constants<T>.Zero);
	}

	public static T Sign<T>(this T v)
	{
		if (!v.LessThan(Constants<T>.Zero))
		{
			return Constants<T>.One;
		}
		return Constants<T>.One.Negate();
	}

	public static T Abs<T>(this T v)
	{
		if (!v.LessThan(Constants<T>.Zero))
		{
			return v;
		}
		return v.Negate();
	}

	public static T Min<T>(T a, T b)
	{
		if (!a.LessThan(b))
		{
			return b;
		}
		return a;
	}

	public static T Max<T>(T a, T b)
	{
		if (!a.GreaterThan(b))
		{
			return b;
		}
		return a;
	}

	public static T Clamp<T>(this T a, T min, T max)
	{
		return Min(Max(a, min), max);
	}

	public static bool IsInRange<T>(this T value, T a, T b)
	{
		return FindRange(value, a, b, inclusive: false);
	}

	public static bool IsInRangeInclusive<T>(this T value, T a, T b)
	{
		return FindRange(value, a, b, inclusive: true);
	}

	private static bool FindRange<T>(T value, T a, T b, bool inclusive)
	{
		T lhs = (a.LessThan(b) ? a : b);
		T rhs = (a.GreaterThan(b) ? a : b);
		if (!inclusive)
		{
			if (lhs.LessThan(value))
			{
				return value.LessThan(rhs);
			}
			return false;
		}
		if (lhs.LessThanOrEqual(value))
		{
			return value.LessThanOrEqual(rhs);
		}
		return false;
	}

	public static T ToFeatureRange<T>(this T value, T min, T max) where T : notnull
	{
		if (min.Equals(max))
		{
			return Constants<T>.One;
		}
		return value.Subtract(min).Divide(max.Subtract(min));
	}

	public static T ToTargetRange<T>(this T value, T min, T max) where T : notnull
	{
		if (min.Equals(max))
		{
			return min;
		}
		return value.Multiply(max.Subtract(min)).Add(min);
	}

	public static double CeilingNearestMultipleOf(double value, double multiple)
	{
		value += multiple - 1.0;
		return value - value % multiple;
	}

	public static bool HasMinimalDifference(double value1, double value2, int units)
	{
		long num = BitConverter.DoubleToInt64Bits(value1);
		long num2 = BitConverter.DoubleToInt64Bits(value2);
		if (num >> 63 != num2 >> 63)
		{
			if (value1 == value2)
			{
				return true;
			}
			return false;
		}
		if (Math.Abs(num - num2) <= units)
		{
			return true;
		}
		return false;
	}
}
