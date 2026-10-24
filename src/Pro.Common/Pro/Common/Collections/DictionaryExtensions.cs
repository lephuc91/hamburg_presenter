using System.Collections.Generic;

namespace Pro.Common.Collections;

public static class DictionaryExtensions
{
	public static void Deconstruct<K, V>(this KeyValuePair<K, V> kvp, out K key, out V value)
	{
		key = kvp.Key;
		value = kvp.Value;
	}
}
