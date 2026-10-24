using Pro.Common.Mathematics;
using Pro.Common.Operations;

namespace Pro.Common.Utility;

public static class ScaleHelper
{
	public static T ScaleToFitScalar<T>(this Vector2<T> originalSize, Vector2<T> targetSize)
	{
		Vector2<T> scalar = originalSize.GetScalar(targetSize);
		return MathHelper.Min(scalar.X, scalar.Y);
	}

	public static T ScaleToFillScalar<T>(this Vector2<T> originalSize, Vector2<T> targetSize)
	{
		Vector2<T> scalar = originalSize.GetScalar(targetSize);
		return MathHelper.Max(scalar.X, scalar.Y);
	}

	public static Vector2<T> ScaleToFitSize<T>(this Vector2<T> originalSize, Vector2<T> targetSize)
	{
		return new Vector2<T>(originalSize.ScaleToFitScalar(targetSize)).ComponentwiseProduct(originalSize);
	}

	public static Vector2<T> ScaleToFillSize<T>(this Vector2<T> originalSize, Vector2<T> targetSize)
	{
		return new Vector2<T>(originalSize.ScaleToFillScalar(targetSize)).ComponentwiseProduct(originalSize);
	}

	private static Vector2<T> GetScalar<T>(this Vector2<T> originalSize, Vector2<T> targetSize)
	{
		if (originalSize.X.Equal(Constants<T>.Zero) || originalSize.Y.Equal(Constants<T>.Zero))
		{
			return Vector2<T>.Zero;
		}
		return targetSize.ComponentwiseQuotient(originalSize).Abs();
	}
}
