using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using Pro.Common.DataStore;
using Pro.Common.Nullability;
using Pro.Common.Operations;

namespace Pro.Common.Mathematics;

public static class RectExtensions
{
	[GeneratedRegex("^\\{\\{(.+)\\,(.+)\\}.*\\,.*\\{(.+)\\,(.+)\\}\\}$")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex DecodeRegex()
	{
		return _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__DecodeRegex_3.Instance;
	}

	public static Rect<T> Abs<T>(this Rect<T> rect)
	{
		if (rect.Width.GreaterThanOrEqual(Constants<T>.Zero) && rect.Height.GreaterThanOrEqual(Constants<T>.Zero))
		{
			return rect;
		}
		Vector2<T> vector = new Vector2<T>((T)(rect.Width.LessThan(Constants<T>.Zero) ? ((object)rect.Width) : ((object)Constants<T>.Zero)), (T)(rect.Height.LessThan(Constants<T>.Zero) ? ((object)rect.Height) : ((object)Constants<T>.Zero)));
		return new Rect<T>(rect.Position + vector, rect.Size.Abs());
	}

	public static Rect<T> GetBoundingBox<T>(this IEnumerable<Rect<T>> rects)
	{
		if (!rects.Any())
		{
			return Rect<T>.Empty;
		}
		if (rects.Count() == 1)
		{
			return rects.First();
		}
		T val = rects.Min<Rect<T>, T>((Rect<T> e) => e.Left);
		T val2 = rects.Min<Rect<T>, T>((Rect<T> e) => e.Top);
		val.ThrowWhenNull("left");
		val2.ThrowWhenNull("top");
		Vector2<T> vector = new Vector2<T>(val, val2);
		T val3 = rects.Max<Rect<T>, T>((Rect<T> e) => e.Right);
		T val4 = rects.Max<Rect<T>, T>((Rect<T> e) => e.Bottom);
		val3.ThrowWhenNull("right");
		val4.ThrowWhenNull("bottom");
		Vector2<T> vector2 = new Vector2<T>(val3, val4);
		return new Rect<T>(vector, vector2 - vector);
	}

	public static Rect<T> GetBoundingBox<T>(this IEnumerable<Vector2<T>> points)
	{
		if (!points.Any())
		{
			return Rect<T>.Empty;
		}
		T val = points.Min<Vector2<T>, T>((Vector2<T> e) => e.X);
		T val2 = points.Min<Vector2<T>, T>((Vector2<T> e) => e.Y);
		val.ThrowWhenNull("left");
		val2.ThrowWhenNull("top");
		Vector2<T> vector = new Vector2<T>(val, val2);
		T val3 = points.Max<Vector2<T>, T>((Vector2<T> e) => e.X);
		T val4 = points.Max<Vector2<T>, T>((Vector2<T> e) => e.Y);
		val3.ThrowWhenNull("right");
		val4.ThrowWhenNull("bottom");
		Vector2<T> vector2 = new Vector2<T>(val3, val4);
		return new Rect<T>(vector, vector2 - vector);
	}

	public static T ClosestEdgeDistance<T>(this Rect<T> a, Rect<T> b, bool isHorizontal)
	{
		T lhs = (isHorizontal ? a.Center.Y : a.Center.X);
		T rhs = (isHorizontal ? b.Center.Y : b.Center.X);
		T lhs2 = (isHorizontal ? a.Height : a.Width);
		return OperatorExtensions.Subtract(rhs: lhs2.Add(isHorizontal ? b.Height : b.Width).Halve(), lhs: lhs.Subtract(rhs).Abs());
	}

	public static Rect<T> Rotate<T>(this Rect<T> rect, T a)
	{
		return rect.Rotate(rect.Center, a);
	}

	public static Rect<T> Rotate<T>(this Rect<T> rect, Vector2<T> center, T a)
	{
		return new Vector2<T>[4]
		{
			rect.TopLeft.Rotate(center, a),
			rect.TopRight.Rotate(center, a),
			rect.BottomRight.Rotate(center, a),
			rect.BottomLeft.Rotate(center, a)
		}.GetBoundingBox();
	}

	public static bool Contains<T>(this Rect<T> rect, Vector2<T> point)
	{
		T rhs = MathHelper.Min(rect.Left, rect.Right);
		T rhs2 = MathHelper.Max(rect.Left, rect.Right);
		T rhs3 = MathHelper.Min(rect.Top, rect.Bottom);
		T rhs4 = MathHelper.Max(rect.Top, rect.Bottom);
		if (point.X.GreaterThanOrEqual(rhs) && point.X.LessThanOrEqual(rhs2) && point.Y.GreaterThanOrEqual(rhs3))
		{
			return point.Y.LessThanOrEqual(rhs4);
		}
		return false;
	}

	public static bool Contains<T>(this Rect<T> sourceRect, Rect<T> targetRect)
	{
		if (sourceRect.Contains(targetRect.TopLeft) && sourceRect.Contains(targetRect.TopRight) && sourceRect.Contains(targetRect.BottomLeft))
		{
			return sourceRect.Contains(targetRect.BottomRight);
		}
		return false;
	}

	public static bool Intersects<T>(this Rect<T> sourceRect, Rect<T> targetRect)
	{
		if (MathHelper.Min(sourceRect.Left, sourceRect.Right).LessThan(MathHelper.Max(targetRect.Left, targetRect.Right)) && MathHelper.Max(sourceRect.Left, sourceRect.Right).GreaterThan(MathHelper.Min(targetRect.Left, targetRect.Right)) && MathHelper.Min(sourceRect.Top, sourceRect.Bottom).LessThan(MathHelper.Max(targetRect.Top, targetRect.Bottom)))
		{
			return MathHelper.Max(sourceRect.Top, sourceRect.Bottom).GreaterThan(MathHelper.Min(targetRect.Top, targetRect.Bottom));
		}
		return false;
	}

	public static bool Intersects<T>(this Rect<T> sourceRect, Rect<T> targetRect, out Rect<T> intersection)
	{
		sourceRect = sourceRect.Abs();
		targetRect = targetRect.Abs();
		T val = MathHelper.Max(sourceRect.Left, targetRect.Left);
		T val2 = MathHelper.Max(sourceRect.Top, targetRect.Top);
		T val3 = MathHelper.Min(sourceRect.Right, targetRect.Right);
		T val4 = MathHelper.Min(sourceRect.Bottom, targetRect.Bottom);
		if (val.LessThan(val3) && val2.LessThan(val4))
		{
			intersection = new Rect<T>(val, val2, val3.Subtract(val), val4.Subtract(val2));
			return true;
		}
		intersection = Rect<T>.Empty;
		return false;
	}

	public static Rect<T> Pad<T>(this Rect<T> rect, T padding)
	{
		return new Rect<T>(rect.Position - new Vector2<T>(padding), rect.Size + new Vector2<T>(padding.Double()));
	}

	public static Rect<T> Pad<T>(this Rect<T> rect, Vector2<T> padding)
	{
		return new Rect<T>(rect.Position - padding, rect.Size + padding * Constants<T>.Two);
	}

	public static Rect<T> Scale<T>(this Rect<T> rect, Vector2<T> scalar)
	{
		return rect.Scale(scalar, scalar);
	}

	public static Rect<T> Scale<T>(this Rect<T> rect, Vector2<T> positionScalar, Vector2<T> sizeScalar)
	{
		return new Rect<T>(rect.Position.ComponentwiseProduct(positionScalar), rect.Size.ComponentwiseProduct(sizeScalar));
	}

	public static Rect<T> MinPosition<T>(this Rect<T> rect, Vector2<T> min)
	{
		return new Rect<T>(rect.Position.Min(min), rect.Size);
	}

	public static Rect<T> MinSize<T>(this Rect<T> rect, Vector2<T> min)
	{
		return new Rect<T>(rect.Position, rect.Size.Min(min));
	}

	public static Rect<T> MaxPosition<T>(this Rect<T> rect, Vector2<T> max)
	{
		return new Rect<T>(rect.Position.Max(max), rect.Size);
	}

	public static Rect<T> MaxSize<T>(this Rect<T> rect, Vector2<T> max)
	{
		return new Rect<T>(rect.Position, rect.Size.Max(max));
	}

	public static Rect<T> Clamp<T>(this Rect<T> rect, Vector2<T> min, Vector2<T> max)
	{
		return rect.Clamp(min, max, min, max);
	}

	public static Rect<T> Clamp<T>(this Rect<T> rect, Vector2<T> minPosition, Vector2<T> maxPosition, Vector2<T> minSize, Vector2<T> maxSize)
	{
		return rect.MinPosition(maxPosition).MaxPosition(minPosition).MinSize(maxSize)
			.MaxSize(minSize);
	}

	public static string Encode<T>(Rect<T> rect) where T : struct
	{
		EncoderDelegate encoder = typeof(T).GetEncoder();
		global::_003C_003Ey__InlineArray4<object> buffer = default(global::_003C_003Ey__InlineArray4<object>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 0) = encoder(rect.Left);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 1) = encoder(rect.Top);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 2) = encoder(rect.Width);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 3) = encoder(rect.Height);
		return string.Format("{{{{{0}, {1}}}, {{{2}, {3}}}}}", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray4<object>, object>(in buffer, 4));
	}

	public static Rect<T> Decode<T>(string value) where T : struct
	{
		Match match = DecodeRegex().Match(value);
		if (!match.Success)
		{
			throw new InvalidOperationException("Invalid or malformed data");
		}
		DecoderDelegate decoder = typeof(T).GetDecoder();
		return new Rect<T>((T)(decoder(match.Groups[1].Value.Trim()) ?? ((object)default(T))), (T)(decoder(match.Groups[2].Value.Trim()) ?? ((object)default(T))), (T)(decoder(match.Groups[3].Value.Trim()) ?? ((object)default(T))), (T)(decoder(match.Groups[4].Value.Trim()) ?? ((object)default(T))));
	}
}
