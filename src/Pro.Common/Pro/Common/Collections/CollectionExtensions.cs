using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Mathematics;

namespace Pro.Common.Collections;

public static class CollectionExtensions
{
	public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items, bool ignoreDuplicates = true)
	{
		foreach (T item in items.Where((T i) => !ignoreDuplicates || !collection.Contains(i)))
		{
			collection.Add(item);
		}
	}

	public static void RemoveRange<T>(this ICollection<T> collection, IReadOnlyList<T> items)
	{
		foreach (T item in items)
		{
			collection.Remove(item);
		}
	}

	public static void RemoveIf<T>(this ICollection<T> collection, Predicate<T> removePredicate)
	{
		T[] items = collection.Where((T i) => removePredicate(i)).ToArray();
		collection.RemoveRange(items);
	}

	public static int ClampIndex<T>(this ICollection<T> collection, int index)
	{
		return index.Clamp(0, Math.Max(collection.Count - 1, 0));
	}

	public static int ClampIndexExclusive<T>(this ICollection<T> collection, int index)
	{
		return index.Clamp(0, collection.Count);
	}

	public static int ClampIndexToCount<T>(this ICollection<T> collection, int index)
	{
		if (index < 0)
		{
			return collection.Count;
		}
		return collection.ClampIndexExclusive(index);
	}

	public static int Count(this ICollectionView? collectionView)
	{
		if (collectionView == null)
		{
			return 0;
		}
		if (collectionView is ICollection collection)
		{
			return collection.Count;
		}
		return ((IEnumerable)collectionView).Cast<object>().Count();
	}
}
