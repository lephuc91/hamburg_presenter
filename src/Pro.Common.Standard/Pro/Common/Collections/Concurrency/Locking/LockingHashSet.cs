using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Pro.Common.SourceGenerator.Attributes;

namespace Pro.Common.Collections.Concurrency.Locking;

[Disposable(new string[] { "_lock" })]
public class LockingHashSet<T> : IEnumerable<T>, IEnumerable, IDisposable
{
	private readonly HashSet<T> _hashSet;

	private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public int Count => ReadLocked((HashSet<T> set) => set.Count);

	public LockingHashSet()
	{
		_hashSet = new HashSet<T>();
	}

	public LockingHashSet(IEqualityComparer<T>? comparer)
	{
		_hashSet = new HashSet<T>(comparer);
	}

	public LockingHashSet(IEnumerable<T> items)
	{
		_hashSet = new HashSet<T>(items);
	}

	public LockingHashSet(IEnumerable<T> items, IEqualityComparer<T>? comparer)
	{
		_hashSet = new HashSet<T>(items, comparer);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private TResult ReadLocked<TResult>(Func<HashSet<T>, TResult> unsafeOperation)
	{
		if (_disposed)
		{
			return unsafeOperation(new HashSet<T>());
		}
		using (new LockUtilities.ReaderLock(_lock))
		{
			return unsafeOperation(_hashSet);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void WriteLocked(Action<HashSet<T>> unsafeOperation)
	{
		using (new LockUtilities.WriteLock(_lock))
		{
			unsafeOperation(_hashSet);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private TResult WriteLocked<TResult>(Func<HashSet<T>, TResult> unsafeOperation)
	{
		using (new LockUtilities.WriteLock(_lock))
		{
			return unsafeOperation(_hashSet);
		}
	}

	public bool Add(T item)
	{
		return WriteLocked((HashSet<T> set) => set.Add(item));
	}

	public bool Contains(T item)
	{
		return ReadLocked((HashSet<T> set) => set.Contains(item));
	}

	public bool Remove(T item)
	{
		return WriteLocked((HashSet<T> set) => set.Remove(item));
	}

	public void Clear()
	{
		WriteLocked(delegate(HashSet<T> set)
		{
			set.Clear();
		});
	}

	public bool Add(Func<T> getter)
	{
		return WriteLocked((HashSet<T> set) => set.Add(getter()));
	}

	public void AddMany(params T[] items)
	{
		WriteLocked(delegate(HashSet<T> set)
		{
			T[] array = items;
			foreach (T item in array)
			{
				set.Add(item);
			}
		});
	}

	public IEnumerator<T> GetEnumerator()
	{
		if (_disposed)
		{
			return Enumerable.Empty<T>().GetEnumerator();
		}
		return new LockingEnumerator<T>(_hashSet, _lock);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public bool IsProperSubsetOf(IEnumerable<T> other)
	{
		return ReadLocked((HashSet<T> set) => set.IsProperSubsetOf(other));
	}

	public bool IsProperSupersetOf(IEnumerable<T> other)
	{
		return ReadLocked((HashSet<T> set) => set.IsProperSupersetOf(other));
	}

	public bool IsSubsetOf(IEnumerable<T> other)
	{
		return ReadLocked((HashSet<T> set) => set.IsSubsetOf(other));
	}

	public bool IsSupersetOf(IEnumerable<T> other)
	{
		return ReadLocked((HashSet<T> set) => set.IsSupersetOf(other));
	}

	public bool Overlaps(IEnumerable<T> other)
	{
		return ReadLocked((HashSet<T> set) => set.Overlaps(other));
	}

	public bool SetEquals(IEnumerable<T> other)
	{
		return ReadLocked((HashSet<T> set) => set.SetEquals(other));
	}

	public IEnumerable<T> RemoveAll(Predicate<T> predicate)
	{
		List<T> list = new List<T>();
		using (new LockUtilities.WriteLock(_lock))
		{
			foreach (T item in _hashSet.Where((T item) => predicate(item)).ToList())
			{
				if (_hashSet.Remove(item))
				{
					list.Add(item);
				}
			}
			return list;
		}
	}

	public bool TryGetOrAdd(Predicate<T> isMatch, Func<T> create, out T resolvedItem)
	{
		using (new LockUtilities.UpgradableReaderLock(_lock))
		{
			using (IEnumerator<T> enumerator = _hashSet.Where((T item) => isMatch(item)).GetEnumerator())
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
				_hashSet.Add(resolvedItem);
				return false;
			}
		}
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
