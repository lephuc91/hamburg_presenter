using System;
using System.Threading;

namespace ProPresenter.UI.ErrorHandling;

public sealed class WriteLock : IDisposable
{
	private readonly ReaderWriterLockSlim _lock;

	public WriteLock(ReaderWriterLockSlim @lock)
	{
		_lock = @lock;
		if (!_lock.TryEnterWriteLock(0))
		{
			throw new Exception("Attempting to write to a list that is currently read from");
		}
	}

	public void Dispose()
	{
		_lock.ExitWriteLock();
	}
}
