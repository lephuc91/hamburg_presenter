using System;

namespace Pro.Common.Collections;

public static class ArrayExtensions
{
	private sealed class ArrayWalker
	{
		private readonly int[] _maxLengths;

		public int[] Position { get; set; }

		public ArrayWalker(Array array)
		{
			_maxLengths = new int[array.Rank];
			for (int i = 0; i < array.Rank; i++)
			{
				_maxLengths[i] = array.GetLength(i) - 1;
			}
			Position = new int[array.Rank];
		}

		public bool Step()
		{
			for (int i = 0; i < Position.Length; i++)
			{
				if (Position[i] < _maxLengths[i])
				{
					Position[i]++;
					for (int j = 0; j < i; j++)
					{
						Position[j] = 0;
					}
					return true;
				}
			}
			return false;
		}
	}

	public static int IndexOf<T>(this T[] array, T value)
	{
		return Array.IndexOf(array, value);
	}

	public static T[] MakeArray<T>(this T item)
	{
		return new T[1] { item };
	}

	public static void ForEach(this Array source, Action<Array, int[]> action)
	{
		if (source.LongLength != 0L)
		{
			ArrayWalker arrayWalker = new ArrayWalker(source);
			do
			{
				action(source, arrayWalker.Position);
			}
			while (arrayWalker.Step());
		}
	}
}
