using Pro.Common.Operations;

namespace Pro.Common.Utility;

public static class NumberExtensions
{
	public static int CountBits<T>(this T value)
	{
		int num = 0;
		for (ulong num2 = value.Cast<ulong, T>(); num2 != 0; num2 >>= 1)
		{
			num += (int)(num2 & 1);
		}
		return num;
	}
}
