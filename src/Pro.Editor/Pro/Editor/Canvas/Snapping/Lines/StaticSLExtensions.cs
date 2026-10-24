using Pro.Common.Mathematics;

namespace Pro.Editor.Canvas.Snapping.Lines;

public static class StaticSLExtensions
{
	public static void Scale(this StaticSL guideline, Vector2<double> oldSize, Vector2<double> newSize)
	{
		Vector2<double> vector = newSize.ComponentwiseQuotient(oldSize);
		guideline.Position *= (guideline.IsHorizontal ? vector.Y : vector.X);
	}
}
