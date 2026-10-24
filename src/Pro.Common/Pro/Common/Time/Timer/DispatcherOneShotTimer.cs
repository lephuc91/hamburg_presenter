using System;
using System.CodeDom.Compiler;
using System.Windows.Threading;
using Pro.Common.Dispatcher;
using Pro.Common.SourceGenerator.Attributes;

namespace Pro.Common.Time.Timer;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
internal class DispatcherOneShotTimer : IOneShotTimer, IDisposable
{
	private readonly DispatcherTimer _timer;

	private readonly Action _callback;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public DispatcherOneShotTimer(TimeSlice period, Action callback, IUiDispatcher uiDispatcher, DispatcherPriority timerPriority = 4)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		_callback = callback;
		_timer = new DispatcherTimer(timerPriority, uiDispatcher.Dispatcher)
		{
			Interval = period
		};
		_timer.Tick += _timer_Tick;
	}

	private void _timer_Tick(object? sender, EventArgs e)
	{
		_timer.Stop();
		_callback();
	}

	public void Start()
	{
		_timer.Start();
	}

	public bool Stop()
	{
		bool isEnabled = _timer.IsEnabled;
		_timer.Stop();
		return isEnabled;
	}

	public bool IsRunning()
	{
		return _timer.IsEnabled;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		_timer.Stop();
	}
}
