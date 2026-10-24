using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using Pro.Common.Concurrency;

namespace Pro.Common.Cache.AsyncCache;

public class AsyncCache<TKey, TValue> : IAsyncCache<TKey, TValue> where TKey : notnull
{
	private readonly int _maximumCapacity;

	private readonly TimeSpan _timeToLive;

	private readonly IStopwatchFactory _stopwatchFactory;

	private readonly ConcurrentDictionary<TKey, AsyncCacheItem<TKey, TValue>> _cache = new ConcurrentDictionary<TKey, AsyncCacheItem<TKey, TValue>>();

	public AsyncCache(int maximumCapacity, TimeSpan timeToLive, IStopwatchFactory stopwatchFactory)
	{
		_maximumCapacity = maximumCapacity;
		_timeToLive = timeToLive;
		_stopwatchFactory = stopwatchFactory;
	}

	public void AddOrUpdate(TKey key, TValue value)
	{
		RemoveElapsedItems();
		_cache.AddOrUpdate(key, (TKey _) => new AsyncCacheItem<TKey, TValue>(value, _stopwatchFactory.Create()), delegate(TKey _, AsyncCacheItem<TKey, TValue> cacheItemToUpdate)
		{
			cacheItemToUpdate.SetValue(value);
			return cacheItemToUpdate;
		});
		EnsureCapacityLimitsAreMet();
	}

	public Task<TValue> GetOrAddAsync(TKey key, Func<TKey, Task<TValue>> factory)
	{
		RemoveElapsedItems();
		Task<TValue> result = _cache.GetOrAdd(key, (TKey createKey) => new AsyncCacheItem<TKey, TValue>(factory, createKey, _stopwatchFactory.Create())).Value.Take(1).ToTask();
		EnsureCapacityLimitsAreMet();
		return result;
	}

	private void RemoveElapsedItems()
	{
		if (_timeToLive == TimeSpan.Zero)
		{
			return;
		}
		foreach (KeyValuePair<TKey, AsyncCacheItem<TKey, TValue>> item in _cache.Where<KeyValuePair<TKey, AsyncCacheItem<TKey, TValue>>>((KeyValuePair<TKey, AsyncCacheItem<TKey, TValue>> pair) => pair.Value.GetItemTime() > _timeToLive))
		{
			_cache.TryRemove(item.Key, out AsyncCacheItem<TKey, TValue> _);
		}
	}

	private void EnsureCapacityLimitsAreMet()
	{
		foreach (KeyValuePair<TKey, AsyncCacheItem<TKey, TValue>> item in _cache.OrderBy<KeyValuePair<TKey, AsyncCacheItem<TKey, TValue>>, TimeSpan>((KeyValuePair<TKey, AsyncCacheItem<TKey, TValue>> pair) => pair.Value.GetItemTime()).Skip(_maximumCapacity))
		{
			_cache.TryRemove(item.Key, out AsyncCacheItem<TKey, TValue> _);
		}
	}
}
