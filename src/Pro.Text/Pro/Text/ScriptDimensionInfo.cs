using Pro.Common.Mathematics;

namespace Pro.Text;

public struct ScriptDimensionInfo
{
	private const double SubscriptOffsetScalar = 1.0;

	private const double SubscriptScalarScalar = 0.95;

	private const double SuperscriptOffsetScalar = 0.84;

	private const double SuperscriptScalarScalar = 0.9;

	public Vector2<double> SubscriptOffset { get; }

	public Vector2<double> SubscriptScalar { get; }

	public Vector2<double> SuperscriptOffset { get; }

	public Vector2<double> SuperscriptScalar { get; }

	public ScriptDimensionInfo(double subscriptXOffset, double subscriptYOffset, double subscriptXScalar, double subscriptYScalar, double superscriptXOffset, double superscriptYOffset, double superscriptXScalar, double superscriptYScalar)
	{
		SubscriptOffset = new Vector2<double>(subscriptXOffset, subscriptYOffset) * 1.0;
		SubscriptScalar = new Vector2<double>(subscriptXScalar, subscriptYScalar) * 0.95;
		SuperscriptOffset = new Vector2<double>(superscriptXOffset, superscriptYOffset) * 0.84;
		SuperscriptScalar = new Vector2<double>(superscriptXScalar, superscriptYScalar) * 0.9;
	}

	public Vector2<double> GetBaselineOffset(int scriptLevel)
	{
		if (scriptLevel == 0)
		{
			return Vector2<double>.Zero;
		}
		Vector2<double> vector = ((scriptLevel < 0) ? SubscriptOffset : SuperscriptOffset);
		Vector2<double> result = vector;
		Vector2<double> vector2 = GetSizeScalar(scriptLevel.Sign());
		for (int i = 1; i < scriptLevel.Abs(); i++)
		{
			result += vector.ComponentwiseProduct(vector2);
			vector2 = vector2.ComponentwiseProduct(vector2);
		}
		return result;
	}

	public Vector2<double> GetSizeScalar(int scriptLevel)
	{
		if (scriptLevel != 0)
		{
			return ((scriptLevel < 0) ? SubscriptScalar : SuperscriptScalar).Pow(scriptLevel.Abs());
		}
		return Vector2<double>.One;
	}
}
