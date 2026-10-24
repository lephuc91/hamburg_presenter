using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Pro.Common.Time;
using ProPresenter.DO.Registration.Operations;

namespace ProPresenter.Registration.Operations.State;

public class RegistrationStateRefresher
{
	private sealed class CompletedAwaitableOperation : IAwaitableOperation
	{
		public TaskAwaiter GetAwaiter()
		{
			return Task.CompletedTask.GetAwaiter();
		}
	}

	private static TimeSpan MinimumTimeBetweenRefresh = TimeSpan.FromSeconds(5L);

	private readonly ICurrentTime _currentTimeProvider;

	private DateTime _lastRefreshRequest = DateTime.MinValue;

	private readonly object _lock = new object();

	public RegistrationStateRefresher(ICurrentTime currentTime)
	{
		_currentTimeProvider = currentTime;
	}

	public IAwaitableOperation Refresh(Func<IAwaitableOperation> enqueueRefreshOperation)
	{
		if (CheckForRefresh())
		{
			return enqueueRefreshOperation();
		}
		return new CompletedAwaitableOperation();
	}

	public bool CheckForRefresh()
	{
		DateTime now = _currentTimeProvider.Now;
		lock (_lock)
		{
			if (now - _lastRefreshRequest > MinimumTimeBetweenRefresh)
			{
				_lastRefreshRequest = now;
				return true;
			}
			return false;
		}
	}
}
