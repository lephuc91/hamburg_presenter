using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace ProPresenter.UI.ErrorHandling;

public class ModificationWhileEnumerationReportingDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable where TKey : notnull
{
	private sealed class LockingEnumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable
	{
		private readonly IEnumerator<KeyValuePair<TKey, TValue>> _base;

		private readonly Action _unlock;

		public KeyValuePair<TKey, TValue> Current => _base.Current;

		object? IEnumerator.Current => ((IEnumerator)_base).Current;

		public LockingEnumerator(IEnumerator<KeyValuePair<TKey, TValue>> @base, Action @lock, Action unlock)
		{
			_base = @base;
			_unlock = unlock;
			@lock();
		}

		public void Dispose()
		{
			_base.Dispose();
			_unlock();
		}

		public bool MoveNext()
		{
			return _base.MoveNext();
		}

		public void Reset()
		{
			_base.Reset();
		}
	}

	private readonly IDictionary<TKey, TValue> _dict = new Dictionary<TKey, TValue>();

	private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();

	public TValue this[TKey key]
	{
		get
		{
			return _dict[key];
		}
		set
		{
			_dict[key] = value;
		}
	}

	public int Count => _dict.Count;

	public bool IsReadOnly => _dict.IsReadOnly;

	public ICollection<TKey> Keys => _dict.Keys;

	public ICollection<TValue> Values
	{
		get
		{
			using (new ReadLock(_lock))
			{
				return _dict.Values;
			}
		}
	}

	public bool Remove(KeyValuePair<TKey, TValue> item)
	{
		using (new WriteLock(_lock))
		{
			return _dict.Remove(item);
		}
	}

	public void Add(TKey key, TValue value)
	{
		using (new WriteLock(_lock))
		{
			_dict.Add(new KeyValuePair<TKey, TValue>(key, value));
		}
	}

	public void Add(KeyValuePair<TKey, TValue> item)
	{
		using (new WriteLock(_lock))
		{
			_dict.Add(item);
		}
	}

	public void Clear()
	{
		using (new WriteLock(_lock))
		{
			_dict.Clear();
		}
	}

	public bool Contains(KeyValuePair<TKey, TValue> item)
	{
		using (new ReadLock(_lock))
		{
			return _dict.Contains(item);
		}
	}

	public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
	{
		using (new WriteLock(_lock))
		{
			_dict.CopyTo(array, arrayIndex);
		}
	}

	public bool ContainsKey(TKey key)
	{
		using (new ReadLock(_lock))
		{
			return _dict.ContainsKey(key);
		}
	}

	public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
	{
		using (new ReadLock(_lock))
		{
			return _dict.TryGetValue(key, out value);
		}
	}

	public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
	{
		return new LockingEnumerator(_dict.GetEnumerator(), delegate
		{
			if (!_lock.TryEnterReadLock(0))
			{
				throw new Exception("Attempting to write to a list that is currently read from");
			}
		}, _lock.ExitReadLock);
	}

	public bool Remove(TKey key)
	{
		using (new WriteLock(_lock))
		{
			return _dict.Remove(key);
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
