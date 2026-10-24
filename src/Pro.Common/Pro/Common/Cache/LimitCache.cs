using System.Collections.Generic;
using System.Linq;

namespace Pro.Common.Cache;

public abstract class LimitCache<K, T> : Cache<K, T, K, KeyValuePair<int, T>> where K : notnull
{
	private readonly int _capacity;

	private volatile int _counter;

	protected LimitCache(int capacity)
	{
		_capacity = capacity;
	}

	protected override K GenerateKey(K target)
	{
		return target;
	}

	protected override KeyValuePair<int, T> Pack(T value)
	{
		return new KeyValuePair<int, T>(_counter++, value);
	}

	protected override T Unpack(KeyValuePair<int, T> packedValue)
	{
		return packedValue.Value;
	}

	protected override IEnumerable<KeyValuePair<K, KeyValuePair<int, T>>> GetOrphanedItems(IEnumerable<KeyValuePair<K, KeyValuePair<int, T>>> items)
	{
		int dropPoint = _counter - _capacity;
		return items.Where<KeyValuePair<K, KeyValuePair<int, T>>>((KeyValuePair<K, KeyValuePair<int, T>> i) => i.Value.Key < dropPoint);
	}
}
