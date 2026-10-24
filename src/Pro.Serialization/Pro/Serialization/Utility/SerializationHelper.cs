using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;

namespace Pro.Serialization.Utility;

public static class SerializationHelper
{
	public static void DeserializeCollection<T, K>(this IEnumerable<T> source, IEnumerable<K> data, Func<T, K, bool> comparer, Func<K, T> constructor, Action<T> addAction, Action<T> removeAction, Action<T, K> deserializeAction)
	{
		List<T> list = new List<T>();
		T[] array = source.ToArray();
		foreach (T item in array)
		{
			if (data.None((K i) => comparer(item, i)))
			{
				removeAction(item);
			}
			else
			{
				list.Add(item);
			}
		}
		foreach (K itemNode in data ?? Enumerable.Empty<K>())
		{
			T val = list.FirstOrDefault((T i) => comparer(i, itemNode));
			if (object.Equals(val, default(T)))
			{
				val = constructor(itemNode);
				deserializeAction(val, itemNode);
				addAction(val);
			}
			else
			{
				deserializeAction(val, itemNode);
			}
		}
	}
}
