using System;
using Pro.Common.Concurrency;

namespace Pro.Common.Cache.AsyncCache;

public class CacheFactory : ICacheFactory
{
	private readonly IStopwatchFactory _stopwatchFactory;

	public CacheFactory(IStopwatchFactory stopwatchFactory)
	{
		_stopwatchFactory = stopwatchFactory;
	}

	public IAsyncCache<TKey, TValue> CreateAsyncCache<TKey, TValue>(int maximumCapacity, TimeSpan timeToLive) where TKey : notnull
	{
		return new AsyncCache<TKey, TValue>(maximumCapacity, timeToLive, _stopwatchFactory);
	}
}
