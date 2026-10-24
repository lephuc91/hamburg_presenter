namespace Pro.Common.Operations;

public static class Constants<T>
{
	public static readonly T NegativeOne = (-1).Cast<T, int>();

	public static readonly T Zero = 0.Cast<T, int>();

	public static readonly T One = 1.Cast<T, int>();

	public static readonly T Two = 2.Cast<T, int>();
}
