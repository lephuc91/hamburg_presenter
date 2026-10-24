using System;

namespace Pro.Common.Cache.AsyncCache;

public interface ICacheFactory
{
	IAsyncCache<TKey, TValue> CreateAsyncCache<TKey, TValue>(int maximumCapacity, TimeSpan timeToLive) where TKey : notnull;
}
