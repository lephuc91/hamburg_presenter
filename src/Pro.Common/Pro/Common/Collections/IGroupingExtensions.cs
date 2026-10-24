using System.Collections.Generic;
using System.Linq;

namespace Pro.Common.Collections;

public static class IGroupingExtensions
{
	public static void Deconstruct<K, V>(this IGrouping<K, V> grouping, out K key, out IEnumerable<V> values)
	{
		key = grouping.Key;
		values = grouping;
	}
}
