using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Threading;

namespace Pro.Entity.Persistence;

public class EntityFileLockFactory : IEntityFileLockFactory
{
	private sealed class RefCounted<T>(T value)
	{
		public T Value { get; } = value;

		public int RefCount { get; set; } = 1;
	}

	private readonly Dictionary<Guid, RefCounted<ReaderWriterLockSlim>> _locks = new Dictionary<Guid, RefCounted<ReaderWriterLockSlim>>();

	private readonly Lock _accessLock = new Lock();

	public IDisposable EnterRead(Guid fileId)
	{
		ReaderWriterLockSlim locker = GetLock(fileId);
		try
		{
			locker.EnterReadLock();
			return Disposable.Create(delegate
			{
				UnlockRead(locker, fileId);
			});
		}
		catch
		{
			ReleaseReference(fileId);
			throw;
		}
	}

	public IDisposable EnterWrite(Guid fileId)
	{
		ReaderWriterLockSlim locker = GetLock(fileId);
		try
		{
			locker.EnterWriteLock();
			return Disposable.Create(delegate
			{
				UnlockWrite(locker, fileId);
			});
		}
		catch
		{
			ReleaseReference(fileId);
			throw;
		}
	}

	private ReaderWriterLockSlim GetLock(Guid key)
	{
		ReaderWriterLockSlim readerWriterLockSlim;
		using (_accessLock.EnterScope())
		{
			if (_locks.TryGetValue(key, out RefCounted<ReaderWriterLockSlim> value))
			{
				value.RefCount++;
				readerWriterLockSlim = value.Value;
			}
			else
			{
				readerWriterLockSlim = new ReaderWriterLockSlim();
				_locks[key] = new RefCounted<ReaderWriterLockSlim>(readerWriterLockSlim);
			}
		}
		return readerWriterLockSlim;
	}

	private void UnlockRead(ReaderWriterLockSlim locker, Guid key)
	{
		locker.ExitReadLock();
		ReleaseReference(key);
	}

	private void UnlockWrite(ReaderWriterLockSlim locker, Guid key)
	{
		locker.ExitWriteLock();
		ReleaseReference(key);
	}

	private void ReleaseReference(Guid key)
	{
		using (_accessLock.EnterScope())
		{
			RefCounted<ReaderWriterLockSlim> refCounted = _locks[key];
			refCounted.RefCount--;
			if (refCounted.RefCount <= 0)
			{
				refCounted.Value.Dispose();
				_locks.Remove(key);
			}
		}
	}
}
