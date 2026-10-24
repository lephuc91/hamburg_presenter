using System;
using Pro.Common.Time;
using Pro.Common.Time.Timer;

namespace Pro.Common.Utility;

public class DebouncerFactory : IDebouncerFactory
{
	private readonly ITimerFactory _timerFactory;

	public DebouncerFactory(ITimerFactory timerFactory)
	{
		_timerFactory = timerFactory;
	}

	public IDebouncer Create(Action action, double interval = 100.0)
	{
		return new Debouncer((Action a) => _timerFactory.CreateOneShot(TimeSlice.FromMilliseconds(interval), a), action);
	}

	public IDebouncer<T> Create<T>(Action<T> action, double interval = 100.0)
	{
		return new Debouncer<T>((Action a) => _timerFactory.CreateOneShot(TimeSlice.FromMilliseconds(interval), a), action);
	}

	public IDebouncer CreateDispatched(Action action, double interval = 100.0)
	{
		return new Debouncer((Action a) => _timerFactory.CreateOneShotDispatched(TimeSlice.FromMilliseconds(interval), a), action);
	}

	public IDebouncer<T> CreateDispatched<T>(Action<T> action, double interval = 100.0)
	{
		return new Debouncer<T>((Action a) => _timerFactory.CreateOneShotDispatched(TimeSlice.FromMilliseconds(interval), a), action);
	}
}
