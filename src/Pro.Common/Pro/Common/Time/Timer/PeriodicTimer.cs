using System;
using System.CodeDom.Compiler;
using System.Threading;
using Pro.Common.SourceGenerator.Attributes;

namespace Pro.Common.Time.Timer;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_timer" })]
internal class PeriodicTimer : IPeriodicTimer, IDisposable
{
	private readonly System.Threading.Timer _timer;

	private readonly TimeSpan _period;

	private bool _isRunning;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public PeriodicTimer(TimeSlice period, Action callback)
	{
		_timer = new System.Threading.Timer(delegate
		{
			callback();
		}, null, Timeout.InfiniteTimeSpan, period);
		_period = period;
	}

	public void Start()
	{
		_isRunning = true;
		_timer.Change(_period, _period);
	}

	public void Stop()
	{
		_isRunning = false;
		_timer.Change(Timeout.InfiniteTimeSpan, _period);
	}

	public bool IsRunning()
	{
		return _isRunning;
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
			_timer.Dispose();
		}
	}
}
