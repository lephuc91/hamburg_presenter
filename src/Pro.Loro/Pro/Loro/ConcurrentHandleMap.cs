using System.Collections.Generic;

namespace Pro.Loro;

internal class ConcurrentHandleMap<T> where T : notnull
{
	private Dictionary<ulong, T> map = new Dictionary<ulong, T>();

	private object lock_ = new object();

	private ulong currentHandle;

	public ulong Insert(T obj)
	{
		lock (lock_)
		{
			currentHandle++;
			map[currentHandle] = obj;
			return currentHandle;
		}
	}

	public bool TryGet(ulong handle, out T result)
	{
		lock (lock_)
		{
			return map.TryGetValue(handle, out result);
		}
	}

	public T Get(ulong handle)
	{
		if (TryGet(handle, out var result))
		{
			return result;
		}
		throw new InternalException("ConcurrentHandleMap: Invalid handle");
	}

	public bool Remove(ulong handle)
	{
		T result;
		return Remove(handle, out result);
	}

	public bool Remove(ulong handle, out T result)
	{
		lock (lock_)
		{
			if (map.TryGetValue(handle, out result))
			{
				map.Remove(handle);
				return true;
			}
			return false;
		}
	}
}
