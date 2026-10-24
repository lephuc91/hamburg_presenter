using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace ProPresenter.UI.ErrorHandling;

public class ModificationWhileEnumerationReportingList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
{
	private sealed class LockingEnumerator : IEnumerator<T>, IEnumerator, IDisposable
	{
		private readonly IEnumerator<T> _base;

		private readonly Action _unlock;

		public T Current => _base.Current;

		object? IEnumerator.Current => ((IEnumerator)_base).Current;

		public LockingEnumerator(IEnumerator<T> @base, Action @lock, Action unlock)
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

	private readonly IList<T> _list = new List<T>();

	private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();

	public T this[int index]
	{
		get
		{
			return _list[index];
		}
		set
		{
			_list[index] = value;
		}
	}

	public int Count => _list.Count;

	public bool IsReadOnly => _list.IsReadOnly;

	public void Add(T item)
	{
		using (new WriteLock(_lock))
		{
			_list.Add(item);
		}
	}

	public void Clear()
	{
		using (new WriteLock(_lock))
		{
			_list.Clear();
		}
	}

	public bool Contains(T item)
	{
		using (new ReadLock(_lock))
		{
			return _list.Contains(item);
		}
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		using (new ReadLock(_lock))
		{
			_list.CopyTo(array, arrayIndex);
		}
	}

	public IEnumerator<T> GetEnumerator()
	{
		return new LockingEnumerator(_list.GetEnumerator(), delegate
		{
			if (!_lock.TryEnterReadLock(0))
			{
				throw new Exception("Attempting to write to a list that is currently read from");
			}
		}, _lock.ExitReadLock);
	}

	public int IndexOf(T item)
	{
		using (new ReadLock(_lock))
		{
			return _list.IndexOf(item);
		}
	}

	public void Insert(int index, T item)
	{
		using (new WriteLock(_lock))
		{
			_list.Insert(index, item);
		}
	}

	public bool Remove(T item)
	{
		using (new WriteLock(_lock))
		{
			return _list.Remove(item);
		}
	}

	public void RemoveAt(int index)
	{
		using (new WriteLock(_lock))
		{
			_list.RemoveAt(index);
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
