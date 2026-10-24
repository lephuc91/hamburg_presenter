using Pro.Common.Mathematics;

namespace Pro.Entity;

public static class PointExtensions
{
	public static Vector2<double> ToVector2d(this IGraphics.Types.Point point)
	{
		return new Vector2<double>(point.X, point.Y);
	}

	public static Vector2<double> ToVector2d(this IGraphics.Types.Size size)
	{
		return new Vector2<double>(size.Width, size.Height);
	}

	public static IGraphics.Types.Point ToPoint(this Vector2<double> point)
	{
		return new IGraphics.Types.Point(point.X, point.Y);
	}

	public static IGraphics.Types.Size ToSize(this Vector2<double> point)
	{
		return new IGraphics.Types.Size(point.X, point.Y);
	}

	public static Rect<double> ToRectd(this IGraphics.Types.Rect rect)
	{
		return new Rect<double>(rect.Origin.ToVector2d(), rect.Size.ToVector2d());
	}

	public static IGraphics.Types.Rect ToRect(this Rect<double> rect)
	{
		return new IGraphics.Types.Rect(rect.Position.ToPoint(), rect.Size.ToSize());
	}
}
