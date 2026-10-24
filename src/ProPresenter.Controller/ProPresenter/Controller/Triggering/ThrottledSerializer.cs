using System;
using System.Windows.Threading;

namespace ProPresenter.Controller.Triggering;

internal class ThrottledSerializer<S, T>
{
	private const DispatcherPriority Priority = 4;

	private readonly DispatcherTimer _timer = new DispatcherTimer((DispatcherPriority)4);

	private readonly Dispatcher _dispatcher;

	private readonly Func<S, T> _serialize;

	private readonly TimeSpan _interval;

	private readonly S _source;

	private T _target;

	private bool _updatePending;

	private bool _fireNextEvent = true;

	private static TimeSpan DefaultUpdateInterval => TimeSpan.FromMilliseconds(100.0);

	public bool UpdateEventEnabled { get; set; }

	public T? Target
	{
		get
		{
			TimerTick(_timer, EventArgs.Empty);
			return _target;
		}
	}

	public event Action<T>? TargetUpdated;

	public ThrottledSerializer(S source, Func<S, T> serializeFunc)
		: this(source, serializeFunc, DefaultUpdateInterval)
	{
	}

	public ThrottledSerializer(S source, Func<S, T> serializeFunc, TimeSpan updateInterval)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		_serialize = serializeFunc;
		_source = source;
		_target = _serialize(source);
		_interval = updateInterval;
		_timer.Interval = updateInterval;
		_timer.Tick += TimerTick;
		_dispatcher = Dispatcher.CurrentDispatcher;
		UpdateEventEnabled = true;
	}

	public void SourceUpdated()
	{
		OnSourceUpdated();
	}

	public void SourceUpdated(object? arg0)
	{
		OnSourceUpdated();
	}

	public void SourceUpdated(object? arg0, object arg1)
	{
		OnSourceUpdated();
	}

	public void SourceUpdated(object? arg0, object arg1, object? arg2)
	{
		OnSourceUpdated();
	}

	private void OnSourceUpdated()
	{
		if (!_updatePending)
		{
			_updatePending = true;
			_fireNextEvent = UpdateEventEnabled;
		}
		if (!_timer.IsEnabled)
		{
			_timer.Interval = TimeSpan.Zero;
			_timer.Start();
		}
	}

	private void TimerTick(object? sender, EventArgs e)
	{
		if (_updatePending)
		{
			_timer.Interval = _interval;
			_updatePending = false;
			Flush();
		}
		else if (_timer.IsEnabled)
		{
			_timer.Stop();
		}
	}

	private void Flush()
	{
		_target = _serialize(_source);
		if (_fireNextEvent)
		{
			_dispatcher.InvokeAsync((Action)delegate
			{
				this.TargetUpdated?.Invoke(_target);
			}, (DispatcherPriority)4);
		}
	}
}
