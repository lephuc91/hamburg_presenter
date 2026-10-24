using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pro.Common.Concurrency;

public class Semaphore : ISemaphore
{
	private sealed class SemaphoreRelease : IDisposable
	{
		private readonly SemaphoreSlim _semaphore;

		public SemaphoreRelease(SemaphoreSlim semaphore)
		{
			_semaphore = semaphore;
		}

		public void Dispose()
		{
			_semaphore.Release();
		}
	}

	private readonly SemaphoreSlim _semaphore;

	public Semaphore(SemaphoreSlim semaphore)
	{
		_semaphore = semaphore;
	}

	public async Task<IDisposable> AquireAsync(CancellationToken token = default(CancellationToken))
	{
		await _semaphore.WaitAsync(token);
		return new SemaphoreRelease(_semaphore);
	}
}
