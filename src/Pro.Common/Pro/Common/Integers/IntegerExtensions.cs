using Pro.Common.Mathematics;

namespace Pro.Common.Integers;

public static class IntegerExtensions
{
	public static string GetOrdinal(this int value)
	{
		int num = value.Abs() % 100;
		if (num < 11 || num > 13)
		{
			switch (num % 10)
			{
			case 1:
				return "st";
			case 2:
				return "nd";
			case 3:
				return "rd";
			}
		}
		return "th";
	}
}
