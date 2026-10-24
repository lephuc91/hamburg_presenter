using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Pro.Common.Startup;

public class AfterStartupCompleteQueue : IAfterStartupCompleteQueue
{
	private sealed class SafeNonDisposableSemaphoreWrapper
	{
		private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

		public bool Wait(int millisecondsTimeout)
		{
			return _semaphore.Wait(millisecondsTimeout);
		}

		public void Release()
		{
			_semaphore.Release();
		}
	}

	private readonly Lock @lock = new Lock();

	private readonly ConcurrentQueue<Action> _startupQueue = new ConcurrentQueue<Action>();

	private int _completedStartups;

	private readonly SafeNonDisposableSemaphoreWrapper _runQueueSemaphore = new SafeNonDisposableSemaphoreWrapper();

	private int _expectedStartups = 1;

	private bool HasCompletedStartup => _completedStartups == _expectedStartups;

	public void AddStartup()
	{
		using (@lock.EnterScope())
		{
			if (HasCompletedStartup)
			{
				throw new Exception("Cannot add a startup completion after the startup has already completed.");
			}
			if (_expectedStartups < int.MaxValue)
			{
				_expectedStartups++;
			}
		}
	}

	public void CompleteStartup()
	{
		using (@lock.EnterScope())
		{
			_completedStartups++;
		}
		RunActions();
	}

	public void Enqueue(Action action)
	{
		_startupQueue.Enqueue(action);
		RunActions();
	}

	public void Cancel()
	{
		using (@lock.EnterScope())
		{
			_expectedStartups = int.MaxValue;
		}
	}

	private void RunActions()
	{
		using (@lock.EnterScope())
		{
			if (!HasCompletedStartup || !_runQueueSemaphore.Wait(0))
			{
				return;
			}
		}
		Action result;
		while (_startupQueue.TryDequeue(out result))
		{
			result();
		}
		_runQueueSemaphore.Release();
	}
}
