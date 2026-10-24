using System;

namespace Pro.Common.Utility;

public static class RandomNumber
{
	private static readonly Random _random = new Random(Guid.NewGuid().GetHashCode());

	public static int Generate()
	{
		lock (_random)
		{
			return _random.Next();
		}
	}

	public static int Generate(int max)
	{
		lock (_random)
		{
			return _random.Next(max);
		}
	}

	public static int Generate(int min, int max)
	{
		lock (_random)
		{
			return _random.Next(min, max);
		}
	}
}
