using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Pro.Common.Collections;

public static class ListExtensions
{
	public static void InsertRange<T>(this IList<T> list, int index, IEnumerable<T> items, bool ignoreDuplicates = true, bool capIndex = false)
	{
		if (list == null || items == null)
		{
			return;
		}
		foreach (T item in items.Where((T i) => !ignoreDuplicates || !list.Contains(i)))
		{
			if (capIndex && index > list.Count)
			{
				index = list.Count;
			}
			list.Insert(index++, item);
		}
	}

	public static void RemoveAtRange<T>(this IList<T> list, int index, int count)
	{
		if (list != null)
		{
			while (count > 0)
			{
				list.RemoveAt(index);
				count--;
			}
		}
	}

	public static void RemoveIf<T>(this IList<T> list, Predicate<T> removePredicate)
	{
		if (list == null || removePredicate == null)
		{
			return;
		}
		int num = 0;
		while (num < list.Count)
		{
			if (removePredicate(list[num]))
			{
				list.RemoveAt(num);
			}
			else
			{
				num++;
			}
		}
	}

	public static void RemoveIf(this IList list, Predicate<object?> removePredicate)
	{
		if (list == null || removePredicate == null)
		{
			return;
		}
		int num = 0;
		while (num < list.Count)
		{
			if (removePredicate(list[num]))
			{
				list.RemoveAt(num);
			}
			else
			{
				num++;
			}
		}
	}

	public static void MoveTo<T>(this IList<T> list, IEnumerable<T> items, int index)
	{
		list.MoveTo(items, index, delegate(int oldIndex, int newIndex, T item)
		{
			list.RemoveAt(oldIndex);
			list.Insert(newIndex, item);
		});
	}

	public static void MoveTo<T>(this IList<T> list, IEnumerable<T> items, int index, Action<int, int, T> moveAction)
	{
		foreach (T item in items)
		{
			int num = list.IndexOf(item);
			if (num >= 0)
			{
				if (num < index)
				{
					index--;
				}
				moveAction(num, index++, item);
			}
		}
	}

	public static void SelectionSort<T>(this IList<T> list, Func<T, T, bool> comparer, Action<int, int> moveAction)
	{
		if (comparer == null || moveAction == null)
		{
			return;
		}
		for (int i = 0; i < list.Count; i++)
		{
			int num = i;
			for (int j = i + 1; j < list.Count; j++)
			{
				if (comparer(list[num], list[j]))
				{
					num = j;
				}
			}
			if (num != i)
			{
				moveAction(num, i);
				moveAction(i + 1, num);
			}
		}
	}

	public static void AddRange(this IList list, IEnumerable items, bool ignoreDuplicates = true)
	{
		if (list == null || items == null)
		{
			return;
		}
		foreach (object item in from object i in items
			where !ignoreDuplicates || !list.Contains(i)
			select i)
		{
			list.Add(item);
		}
	}

	public static void RemoveRange(this IList list, IEnumerable items)
	{
		if (list == null || items == null)
		{
			return;
		}
		foreach (object item in items)
		{
			list.Remove(item);
		}
	}
}
