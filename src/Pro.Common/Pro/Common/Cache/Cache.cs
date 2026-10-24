using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;

namespace Pro.Common.Cache;

public abstract class Cache<K, T, X, Y> where X : notnull
{
	private readonly Dictionary<X, Y> _cache = new Dictionary<X, Y>();

	protected abstract X GenerateKey(K target);

	protected abstract T GenerateValue(K target);

	protected abstract Y Pack(T value);

	protected abstract T Unpack(Y packedValue);

	protected abstract IEnumerable<KeyValuePair<X, Y>> GetOrphanedItems(IEnumerable<KeyValuePair<X, Y>> items);

	public virtual T Get(K target)
	{
		lock (_cache)
		{
			X key = GenerateKey(target);
			Y value = default(Y);
			if (_cache.TryGetValue(key, out value))
			{
				return Unpack(value);
			}
			T val = GenerateValue(target);
			TeardownValue(key);
			_cache[key] = Pack(val);
			RemoveOrphanedKeys();
			return val;
		}
	}

	public virtual bool TryGet(K target, out T? value)
	{
		lock (_cache)
		{
			X key = GenerateKey(target);
			Y value2 = default(Y);
			if (_cache.TryGetValue(key, out value2))
			{
				value = Unpack(value2);
				return true;
			}
			value = default(T);
			return false;
		}
	}

	public bool IsCached(K target)
	{
		lock (_cache)
		{
			return _cache.ContainsKey(GenerateKey(target));
		}
	}

	public void Set(K target, T value)
	{
		lock (_cache)
		{
			X key = GenerateKey(target);
			TeardownValue(key);
			_cache[key] = Pack(value);
		}
	}

	public void Remove(K target)
	{
		lock (_cache)
		{
			X key = GenerateKey(target);
			if (TeardownValue(key))
			{
				_cache.Remove(key);
			}
		}
	}

	public void Clear()
	{
		lock (_cache)
		{
			_cache.Keys.ForEach(delegate(X k)
			{
				TeardownValue(k);
			});
			_cache.Clear();
		}
	}

	protected void RemoveOrphanedKeys()
	{
		lock (_cache)
		{
			KeyValuePair<X, Y>[] array = GetOrphanedItems(_cache).ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				KeyValuePair<X, Y> keyValuePair = array[i];
				if (TeardownValue(keyValuePair.Key))
				{
					_cache.Remove(keyValuePair.Key);
				}
			}
		}
	}

	private bool TeardownValue(X key)
	{
		if (_cache.TryGetValue(key, out var value))
		{
			(value as IDisposable)?.Dispose();
			return true;
		}
		return false;
	}
}
public abstract class Cache<K, T> : Cache<K, T, K, T> where K : notnull
{
	protected override K GenerateKey(K target)
	{
		return target;
	}

	protected override T Pack(T value)
	{
		return value;
	}

	protected override T Unpack(T packedValue)
	{
		return packedValue;
	}

	protected override IEnumerable<KeyValuePair<K, T>> GetOrphanedItems(IEnumerable<KeyValuePair<K, T>> items)
	{
		return Array.Empty<KeyValuePair<K, T>>();
	}
}
