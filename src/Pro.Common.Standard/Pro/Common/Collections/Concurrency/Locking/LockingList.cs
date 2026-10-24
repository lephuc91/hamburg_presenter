using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Pro.Common.SourceGenerator.Attributes;

namespace Pro.Common.Collections.Concurrency.Locking;

[Disposable(new string[] { "_lock" })]
public class LockingList<T> : IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, IDisposable
{
	private sealed class SynchronizationContext : ISynchronizationContext, IDisposable
	{
		private readonly IDisposable _readLock;

		private IDisposable? _writeLock;

		public ReaderWriterLockSlim RwLock { get; }

		public SynchronizationContext(ReaderWriterLockSlim rwLock)
		{
			RwLock = rwLock;
			_readLock = new LockUtilities.UpgradableReaderLock(RwLock);
		}

		public void StartWrite()
		{
			if (_writeLock == null)
			{
				_writeLock = new LockUtilities.WriteLock(RwLock);
			}
		}

		public void Dispose()
		{
			_writeLock?.Dispose();
			_readLock.Dispose();
		}
	}

	private readonly List<T> _list = new List<T>();

	private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public T this[int index]
	{
		get
		{
			return ReadLocked((IReadOnlyList<T> list) => list[index]);
		}
		set
		{
			WriteLocked((List<T> list) => list[index] = value);
		}
	}

	public int Count => ReadLocked((IReadOnlyList<T> list) => list.Count);

	public LockingList()
	{
	}

	public LockingList(IEnumerable<T> items)
	{
		_list.AddRange(items);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private TResult ReadLocked<TResult>(Func<IReadOnlyList<T>, TResult> unsafeOperation)
	{
		if (_disposed)
		{
			return unsafeOperation(Array.Empty<T>());
		}
		using (new LockUtilities.ReaderLock(_lock))
		{
			return unsafeOperation(_list);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void WriteLocked(Action<List<T>> unsafeOperation)
	{
		using (new LockUtilities.WriteLock(_lock))
		{
			unsafeOperation(_list);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private TResult WriteLocked<TResult>(Func<List<T>, TResult> unsafeOperation)
	{
		using (new LockUtilities.WriteLock(_lock))
		{
			return unsafeOperation(_list);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private SynchronizationContext ValidateContext(ISynchronizationContext context, ReaderWriterLockSlim @lock)
	{
		SynchronizationContext obj = (context as SynchronizationContext) ?? throw new InvalidOperationException($"Invalid Synchronization context provided. Received {context.GetType()} but expected {typeof(SynchronizationContext)}");
		if (obj.RwLock != @lock)
		{
			throw new InvalidOperationException("SynchronizationContext does not belong to this LockingList instance.");
		}
		return obj;
	}

	public ISynchronizationContext EnterSyncContext()
	{
		return new SynchronizationContext(_lock);
	}

	public void Add(T item)
	{
		WriteLocked(delegate(List<T> list)
		{
			list.Add(item);
		});
	}

	public void Insert(int index, T item)
	{
		WriteLocked(delegate(List<T> list)
		{
			list.Insert(index, item);
		});
	}

	public void ScopedInsert(int index, T item, ISynchronizationContext context)
	{
		ValidateContext(context, _lock).StartWrite();
		_list.Insert(index, item);
	}

	public void Move(int fromIndex, int toIndex)
	{
		if (fromIndex != toIndex)
		{
			WriteLocked(delegate(List<T> list)
			{
				T item = list[fromIndex];
				list.RemoveAt(fromIndex);
				list.Insert(toIndex, item);
			});
		}
	}

	public void ScopedMove(int fromIndex, int toIndex, ISynchronizationContext context)
	{
		if (fromIndex != toIndex)
		{
			ValidateContext(context, _lock).StartWrite();
			T item = _list[fromIndex];
			_list.RemoveAt(fromIndex);
			_list.Insert(toIndex, item);
		}
	}

	public IEnumerator<T> GetEnumerator()
	{
		if (_disposed)
		{
			return Enumerable.Empty<T>().GetEnumerator();
		}
		return new LockingEnumerator<T>(_list, _lock);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public bool Remove(T itemToRemove)
	{
		using (new LockUtilities.UpgradableReaderLock(_lock))
		{
			int num = _list.IndexOf(itemToRemove);
			if (num >= 0)
			{
				using (new LockUtilities.WriteLock(_lock))
				{
					_list.RemoveAt(num);
					return true;
				}
			}
			return false;
		}
	}

	public T RemoveAtWithValue(int index)
	{
		return WriteLocked(delegate(List<T> list)
		{
			T result = list[index];
			list.RemoveAt(index);
			return result;
		});
	}

	public T ScopedRemoveAtWithValue(int index, ISynchronizationContext context)
	{
		ValidateContext(context, _lock).StartWrite();
		T result = _list[index];
		_list.RemoveAt(index);
		return result;
	}

	public T Replace(int index, T newValue)
	{
		return WriteLocked(delegate(List<T> list)
		{
			T result = list[index];
			list[index] = newValue;
			return result;
		});
	}

	public void RemoveAll(IList<T> itemsToRemove)
	{
		using (new LockUtilities.UpgradableReaderLock(_lock))
		{
			foreach (T item in itemsToRemove)
			{
				int num = _list.IndexOf(item);
				if (num >= 0)
				{
					using (new LockUtilities.WriteLock(_lock))
					{
						_list.RemoveAt(num);
					}
				}
			}
		}
	}

	public IEnumerable<T> RemoveAll(Predicate<T> predicate)
	{
		List<T> allRemovedItems = new List<T>();
		using (new LockUtilities.WriteLock(_lock))
		{
			_list.RemoveAll(delegate(T item)
			{
				if (predicate(item))
				{
					allRemovedItems.Add(item);
					return true;
				}
				return false;
			});
			return allRemovedItems;
		}
	}

	public void Reset(IReadOnlyList<T> items)
	{
		using (new LockUtilities.WriteLock(_lock))
		{
			_list.Clear();
			foreach (T item in items)
			{
				_list.Add(item);
			}
		}
	}

	public void AddOrUpdate(T newValue, Predicate<T> isMatch)
	{
		using (new LockUtilities.UpgradableReaderLock(_lock))
		{
			for (int i = 0; i < _list.Count; i++)
			{
				if (isMatch(_list[i]))
				{
					using (new LockUtilities.WriteLock(_lock))
					{
						_list[i] = newValue;
						return;
					}
				}
			}
			using (new LockUtilities.WriteLock(_lock))
			{
				_list.Add(newValue);
			}
		}
	}

	public bool TryGetOrAdd(Predicate<T> isMatch, Func<T> create, out T resolvedItem)
	{
		using (new LockUtilities.UpgradableReaderLock(_lock))
		{
			using (IEnumerator<T> enumerator = _list.Where((T item) => isMatch(item)).GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					T current = enumerator.Current;
					resolvedItem = current;
					return true;
				}
			}
			resolvedItem = create();
			using (new LockUtilities.WriteLock(_lock))
			{
				_list.Add(resolvedItem);
				return false;
			}
		}
	}

	public bool TryGet(Predicate<T> isMatch, [NotNullWhen(true)] out T? resolvedItem)
	{
		if (_disposed)
		{
			resolvedItem = default(T);
			return false;
		}
		using (new LockUtilities.ReaderLock(_lock))
		{
			using (IEnumerator<T> enumerator = _list.Where((T item) => isMatch(item)).GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					T current = enumerator.Current;
					resolvedItem = current;
					return true;
				}
			}
			resolvedItem = default(T);
			return false;
		}
	}

	public void SynchronizeFrom<TSource>(IEnumerable<TSource> source, Func<TSource, T, bool> equal, Func<TSource, T> create, Action<T, int> onInsert, Action<int, int> onMove, Action<T, int> onRemove)
	{
		using SynchronizationContext synchronizationContext = new SynchronizationContext(_lock);
		int num = 0;
		foreach (TSource item in source)
		{
			if (!FindAndMove(item, num, equal, synchronizationContext.StartWrite, onMove))
			{
				synchronizationContext.StartWrite();
				T val = create(item);
				_list.Insert(num, val);
				onInsert(val, num);
			}
			num++;
		}
		if (num < _list.Count)
		{
			synchronizationContext.StartWrite();
			int num2 = _list.Count - num;
			for (int num3 = num + num2 - 1; num3 >= num; num3--)
			{
				onRemove(_list[num3], num3);
			}
			_list.RemoveRange(num, num2);
		}
	}

	private bool FindAndMove<TSource>(TSource source, int startIndex, Func<TSource, T, bool> equal, Action writeLock, Action<int, int> onMove)
	{
		for (int i = startIndex; i < _list.Count; i++)
		{
			if (equal(source, _list[i]))
			{
				if (startIndex == i)
				{
					return true;
				}
				writeLock();
				T item = _list[i];
				_list.RemoveAt(i);
				_list.Insert(startIndex, item);
				onMove(i, startIndex);
				return true;
			}
		}
		return false;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			_lock.Dispose();
		}
	}
}
