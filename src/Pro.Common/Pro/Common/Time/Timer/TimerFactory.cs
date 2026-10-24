using System;
using System.Windows.Threading;
using Pro.Common.Dispatcher;

namespace Pro.Common.Time.Timer;

public class TimerFactory : ITimerFactory
{
	private readonly IUiDispatcher _uiDispatcher;

	public TimerFactory(IUiDispatcher uiDispatcher)
	{
		_uiDispatcher = uiDispatcher;
	}

	public IPeriodicTimer CreatePeriodic(TimeSlice period, Action callback)
	{
		return new PeriodicTimer(period, callback);
	}

	public IOneShotTimer CreateOneShot(TimeSlice timeout, Action callback)
	{
		return new OneShotTimer(timeout, callback);
	}

	public IPeriodicTimer CreatePeriodicDispatched(TimeSlice period, Action callback)
	{
		return new DispatchedPeriodicTimer(period, callback, _uiDispatcher, (DispatcherPriority)4);
	}

	public IOneShotTimer CreateOneShotDispatched(TimeSlice timeout, Action callback)
	{
		return new DispatcherOneShotTimer(timeout, callback, _uiDispatcher, (DispatcherPriority)4);
	}
}
