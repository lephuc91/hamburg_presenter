namespace Pro.Common.Mathematics;

public static class DoubleExtensions
{
	public static bool IsReal(this double value)
	{
		if (!double.IsInfinity(value))
		{
			return !double.IsNaN(value);
		}
		return false;
	}
}
