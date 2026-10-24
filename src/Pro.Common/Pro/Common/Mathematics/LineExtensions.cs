using Pro.Common.Operations;

namespace Pro.Common.Mathematics;

public static class LineExtensions
{
	public static bool Intersects<T>(this Line<T> a, Line<T> b, out Vector2<T> intersection)
	{
		intersection = Vector2<T>.Zero;
		T lhs = a.A.InvertedCartesianValue.Tan();
		T val = b.A.InvertedCartesianValue.Tan();
		if (lhs.Equal(val))
		{
			return false;
		}
		T rhs = a.P.Y.Subtract(lhs.Multiply(a.P.X));
		T val2 = b.P.Y.Subtract(val.Multiply(b.P.X));
		intersection = new Vector2<T>(val2.Subtract(rhs), lhs.Multiply(val2).Subtract(val.Multiply(rhs))).ComponentwiseQuotient(new Vector2<T>(lhs.Subtract(val)));
		return true;
	}
}
