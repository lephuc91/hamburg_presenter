namespace Pro.Common.Mathematics;

public static class LineSegmentExtensions
{
	public static bool Intersects<T>(this LineSegment<T> a, LineSegment<T> b)
	{
		if (!b.A.Intersects(a) && !b.A.Intersects(a))
		{
			return b.A.RightSide(a) ^ b.B.RightSide(a);
		}
		return true;
	}
}
