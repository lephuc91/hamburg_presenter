using System;
using System.Collections.Generic;

namespace Pro.Common.ObjectBinding;

public static class CollectionHelper
{
	public static void SynchronizeTo<T, K>(this IEnumerable<T> source, IReadOnlyList<K> destination, Func<T, K, bool> equal, Action<T, int> createAndInsert, Action<int, int> move, Action<int> removeAt)
	{
		int num = 0;
		foreach (T item in source)
		{
			if (!FindAndMove(item, destination, num, equal, move))
			{
				createAndInsert(item, num);
			}
			num++;
		}
		for (int num2 = destination.Count - 1; num2 >= num; num2--)
		{
			removeAt(num2);
		}
	}

	private static bool FindAndMove<TSource, TDestination>(TSource source, IReadOnlyList<TDestination> destination, int startIndex, Func<TSource, TDestination, bool> equal, Action<int, int> move)
	{
		for (int i = startIndex; i < destination.Count; i++)
		{
			if (equal(source, destination[i]))
			{
				if (startIndex == i)
				{
					return true;
				}
				move(i, startIndex);
				return true;
			}
		}
		return false;
	}
}
