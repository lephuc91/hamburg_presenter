using Pro.Common.Mathematics;

namespace Pro.ssAPI;

public static class ScaleAlignmentHelper
{
	public static Vector2<double> GetAlignedPosition(ScaleAlignment alignment, bool flipHorizontally, bool flipVertically, Vector2<double> bottomRightPosition)
	{
		Vector2<double> vector = bottomRightPosition;
		vector = alignment switch
		{
			ScaleAlignment.TopLeft => Vector2<double>.Zero, 
			ScaleAlignment.TopCenter => vector.ComponentwiseProduct(new Vector2<double>(0.5, 0.0)), 
			ScaleAlignment.TopRight => vector.ComponentwiseProduct(new Vector2<double>(1.0, 0.0)), 
			ScaleAlignment.MiddleLeft => vector.ComponentwiseProduct(new Vector2<double>(0.0, 0.5)), 
			ScaleAlignment.MiddleCenter => vector.ComponentwiseProduct(new Vector2<double>(0.5, 0.5)), 
			ScaleAlignment.MiddleRight => vector.ComponentwiseProduct(new Vector2<double>(1.0, 0.5)), 
			ScaleAlignment.BottomLeft => vector.ComponentwiseProduct(new Vector2<double>(0.0, 1.0)), 
			ScaleAlignment.BottomCenter => vector.ComponentwiseProduct(new Vector2<double>(0.5, 1.0)), 
			ScaleAlignment.BottomRight => vector, 
			_ => vector.ComponentwiseProduct(new Vector2<double>(0.5, 0.5)), 
		};
		if (flipHorizontally)
		{
			vector.X = bottomRightPosition.X - vector.X;
		}
		if (flipVertically)
		{
			vector.Y = bottomRightPosition.Y - vector.Y;
		}
		return vector;
	}
}
