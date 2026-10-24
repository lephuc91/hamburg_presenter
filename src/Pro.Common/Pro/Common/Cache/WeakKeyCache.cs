using System.Collections.Generic;
using System.Linq;
using Pro.Common.Utility;

namespace Pro.Common.Cache;

public abstract class WeakKeyCache<K, T, Y> : Cache<K, T, WeakKey<K>, Y> where K : class
{
	protected override WeakKey<K> GenerateKey(K target)
	{
		return new WeakKey<K>(target);
	}

	protected override IEnumerable<KeyValuePair<WeakKey<K>, Y>> GetOrphanedItems(IEnumerable<KeyValuePair<WeakKey<K>, Y>> items)
	{
		return items.Where<KeyValuePair<WeakKey<K>, Y>>((KeyValuePair<WeakKey<K>, Y> i) => !i.Key.IsValid);
	}
}
public abstract class WeakKeyCache<K, T> : WeakKeyCache<K, T, T> where K : class
{
	protected override T Pack(T value)
	{
		return value;
	}

	protected override T Unpack(T packedValue)
	{
		return packedValue;
	}
}
