using System;
using System.Threading.Tasks;

namespace Pro.Common.Cache.AsyncCache;

public interface IAsyncCache<TKey, TValue>
{
	void AddOrUpdate(TKey key, TValue value);

	Task<TValue> GetOrAddAsync(TKey key, Func<TKey, Task<TValue>> factory);
}
