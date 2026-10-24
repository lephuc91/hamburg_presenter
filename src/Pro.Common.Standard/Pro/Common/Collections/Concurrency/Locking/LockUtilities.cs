using System;
using System.Threading;

namespace Pro.Common.Collections.Concurrency.Locking;

public static class LockUtilities
{
	public sealed class ReaderLock : IDisposable
	{
		private readonly ReaderWriterLockSlim _lock;

		public ReaderLock(ReaderWriterLockSlim @lock)
		{
			_lock = @lock;
			_lock.EnterReadLock();
		}

		public void Dispose()
		{
			_lock.ExitReadLock();
		}
	}

	public sealed class UpgradableReaderLock : IDisposable
	{
		private readonly ReaderWriterLockSlim _lock;

		public UpgradableReaderLock(ReaderWriterLockSlim @lock)
		{
			_lock = @lock;
			_lock.EnterUpgradeableReadLock();
		}

		public void Dispose()
		{
			_lock.ExitUpgradeableReadLock();
		}
	}

	public sealed class WriteLock : IDisposable
	{
		private readonly ReaderWriterLockSlim _lock;

		public WriteLock(ReaderWriterLockSlim @lock)
		{
			_lock = @lock;
			_lock.EnterWriteLock();
		}

		public void Dispose()
		{
			_lock.ExitWriteLock();
		}
	}
}
