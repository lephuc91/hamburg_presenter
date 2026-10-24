using System;
using System.CodeDom.Compiler;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using Pro.Common.DataStore;
using Pro.Common.Operations;

namespace Pro.Common.Mathematics;

public static class Vector2Extensions
{
	[GeneratedRegex("^\\{(.+)\\,(.+)\\}$")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex DecodeRegex()
	{
		return _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__DecodeRegex_4.Instance;
	}

	public static Vector2<T> Rotate<T>(this Vector2<T> point, Vector2<T> origin, T a)
	{
		if (a.Equal(Constants<T>.Zero) || a.Modulo(360.Cast<T, int>()).Equal(Constants<T>.Zero))
		{
			return point;
		}
		Vector2<double> vector = point.Cast<double>();
		Vector2<double> vector2 = origin.Cast<double>();
		double a2 = a.Cast<double, T>();
		double num = a2.Cos();
		double num2 = a2.Sin();
		Vector2<double> vector3 = vector - vector2;
		return new Vector2<T>((num * vector3.X - num2 * vector3.Y + vector2.X).Cast<T, double>(), (num2 * vector3.X + num * vector3.Y + vector2.Y).Cast<T, double>());
	}

	public static Vector2<T> Project<T>(this Vector2<T> origin, T distance, T a)
	{
		return new Vector2<T>(distance, Constants<T>.Zero).Rotate(Vector2<T>.Zero, a) + origin;
	}

	public static Vector2<T> ComponentwiseProduct<T>(this Vector2<T> point, Vector2<T> scale)
	{
		return new Vector2<T>(point.X.Multiply(scale.X), point.Y.Multiply(scale.Y));
	}

	public static Vector2<T> ComponentwiseQuotient<T>(this Vector2<T> point, Vector2<T> scale)
	{
		return new Vector2<T>(point.X.Divide(scale.X), point.Y.Divide(scale.Y));
	}

	public static Vector2<T> Invert<T>(this Vector2<T> point)
	{
		return new Vector2<T>(point.X.Invert(), point.Y.Invert());
	}

	public static T DotProduct<T>(this Vector2<T> a, Vector2<T> b)
	{
		return a.X.Multiply(b.X).Add(a.Y.Multiply(b.Y));
	}

	public static T CrossProduct<T>(this Vector2<T> a, Vector2<T> b)
	{
		return a.X.Multiply(b.Y).Subtract(a.Y.Multiply(b.X));
	}

	public static Vector2<T> Pow<T>(this Vector2<T> point, double exponent)
	{
		return new Vector2<T>(Math.Pow(point.X.Cast<double, T>(), exponent).Cast<T, double>(), Math.Pow(point.Y.Cast<double, T>(), exponent).Cast<T, double>());
	}

	public static Vector2<T> Floor<T>(this Vector2<T> point)
	{
		return new Vector2<T>(Math.Floor(point.X.Cast<double, T>()).Cast<T, double>(), Math.Floor(point.Y.Cast<double, T>()).Cast<T, double>());
	}

	public static Vector2<T> Round<T>(this Vector2<T> point, int digits)
	{
		return new Vector2<T>(Math.Round(point.X.Cast<double, T>(), digits).Cast<T, double>(), Math.Round(point.Y.Cast<double, T>(), digits).Cast<T, double>());
	}

	public static Vector2<T> Ceiling<T>(this Vector2<T> point)
	{
		return new Vector2<T>(Math.Ceiling(point.X.Cast<double, T>()).Cast<T, double>(), Math.Ceiling(point.Y.Cast<double, T>()).Cast<T, double>());
	}

	public static Vector2<T> Mod<T>(this Vector2<T> point, T divisor)
	{
		return new Vector2<T>(point.X.Mod(divisor), point.Y.Mod(divisor));
	}

	public static Vector2<T> Reflect<T>(this Vector2<T> point)
	{
		return new Vector2<T>(point.Y, point.X);
	}

	public static Vector2<T> Negate<T>(this Vector2<T> point)
	{
		return new Vector2<T>(point.X.Negate(), point.Y.Negate());
	}

	public static Vector2<T> NegateX<T>(this Vector2<T> point)
	{
		return new Vector2<T>(point.X.Negate(), point.Y);
	}

	public static Vector2<T> NegateY<T>(this Vector2<T> point)
	{
		return new Vector2<T>(point.X, point.Y.Negate());
	}

	public static T AngleBetween<T>(this Vector2<T> origin, Vector2<T> a, Vector2<T> b)
	{
		a -= origin;
		b -= origin;
		return MathHelper.Atan2(a.CrossProduct(b).Cast<double, T>(), a.DotProduct(b).Cast<double, T>()).Cast<T, double>();
	}

	public static T Angle<T>(this Vector2<T> a, Vector2<T> b)
	{
		return MathHelper.Atan2(a.Y.Subtract(b.Y).Cast<double, T>(), a.X.Subtract(b.X).Cast<double, T>()).Cast<T, double>();
	}

	public static T Distance<T>(this Vector2<T> a, Vector2<T> b)
	{
		Vector2<double> vector = a.Cast<double>();
		Vector2<double> vector2 = b.Cast<double>();
		return Math.Sqrt((vector2.X - vector.X).Squared() + (vector2.Y - vector.Y).Squared()).Cast<T, double>();
	}

	public static Vector2<T> Midpoint<T>(this Vector2<T> a, Vector2<T> b)
	{
		return new Vector2<T>(a.X.Add(b.X).Halve(), a.Y.Add(b.Y).Halve());
	}

	public static T Length<T>(this Vector2<T> point)
	{
		Vector2<double> vector = point.Cast<double>();
		return Math.Sqrt(vector.X.Squared() + vector.Y.Squared()).Cast<T, double>();
	}

	public static Vector2<T> Normalize<T>(this Vector2<T> point)
	{
		return point / point.Length();
	}

	public static Vector2<T> Abs<T>(this Vector2<T> point)
	{
		return new Vector2<T>(point.X.Abs(), point.Y.Abs());
	}

	public static Vector2<T> Min<T>(this Vector2<T> a, T b)
	{
		return a.Min(new Vector2<T>(b));
	}

	public static Vector2<T> Min<T>(this Vector2<T> a, Vector2<T> b)
	{
		return new Vector2<T>(MathHelper.Min(b.X, a.X), MathHelper.Min(b.Y, a.Y));
	}

	public static Vector2<T> Max<T>(this Vector2<T> a, T b)
	{
		return a.Max(new Vector2<T>(b));
	}

	public static Vector2<T> Max<T>(this Vector2<T> a, Vector2<T> b)
	{
		return new Vector2<T>(MathHelper.Max(b.X, a.X), MathHelper.Max(b.Y, a.Y));
	}

	public static bool Intersects<T>(this Vector2<T> point, LineSegment<T> line)
	{
		return (line.B - line.A).CrossProduct(point - line.A).Abs().LessThan(Constants<T>.One);
	}

	public static bool RightSide<T>(this Vector2<T> point, LineSegment<T> line)
	{
		return (line.B - line.A).CrossProduct(point - line.A).LessThan(Constants<T>.Zero);
	}

	public static Vector2<T> ProjectIntoWorldSpace<T>(this Vector2<T> point, Rect<T> bounds, Angle<T> rotation)
	{
		return (point.ComponentwiseProduct(bounds.Size) + bounds.TopLeft).Rotate(bounds.Center, rotation.InvertedCartesianValue);
	}

	public static Vector2<T> ProjectIntoLocalSpace<T>(this Vector2<T> point, Rect<T> bounds, Angle<T> rotation)
	{
		return (point.Rotate(bounds.Center, rotation.CartesianValue) - bounds.Position).ComponentwiseQuotient(bounds.Size);
	}

	public static bool IsWithin<T>(this Vector2<T> start, Vector2<T> end, T horizontalThreshold, T verticalThreshold)
	{
		Vector2<T> vector = (start - end).Abs();
		T rhs = horizontalThreshold.Squared();
		T rhs2 = verticalThreshold.Squared();
		return vector.X.Squared().Divide(rhs).Add(vector.Y.Squared().Divide(rhs2))
			.LessThan(Constants<T>.One);
	}

	public static string Encode<T>(Vector2<T> point) where T : struct
	{
		EncoderDelegate encoder = typeof(T).GetEncoder();
		return $"{{{encoder(point.X)}, {encoder(point.Y)}}}";
	}

	public static Vector2<T> Decode<T>(string value) where T : struct
	{
		Match match = DecodeRegex().Match(value);
		if (!match.Success)
		{
			throw new InvalidOperationException("Invalid or malformed data");
		}
		DecoderDelegate decoder = typeof(T).GetDecoder();
		return new Vector2<T>((T)(decoder(match.Groups[1].Value.Trim()) ?? ((object)default(T))), (T)(decoder(match.Groups[2].Value.Trim()) ?? ((object)default(T))));
	}
}
