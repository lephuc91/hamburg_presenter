using System;
using System.Threading;

namespace ProPresenter.UI.ErrorHandling;

public sealed class ReadLock : IDisposable
{
	private readonly ReaderWriterLockSlim _lock;

	public ReadLock(ReaderWriterLockSlim @lock)
	{
		_lock = @lock;
		if (!_lock.TryEnterReadLock(0))
		{
			throw new Exception("Cannot read from a list that is currently written to");
		}
	}

	public void Dispose()
	{
		_lock.ExitReadLock();
	}
}
