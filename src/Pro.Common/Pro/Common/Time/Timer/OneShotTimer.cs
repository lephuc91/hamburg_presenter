using System;
using System.CodeDom.Compiler;
using System.Threading;
using Pro.Common.SourceGenerator.Attributes;

namespace Pro.Common.Time.Timer;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_timer" })]
internal class OneShotTimer : IOneShotTimer, IDisposable
{
	private readonly System.Threading.Timer _timer;

	private readonly TimeSpan _timeout;

	private readonly Lock _changeLock = new Lock();

	private bool _isRunning;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public OneShotTimer(TimeSlice timeout, Action callback)
	{
		OneShotTimer oneShotTimer = this;
		_timer = new System.Threading.Timer(delegate
		{
			using (oneShotTimer._changeLock.EnterScope())
			{
				oneShotTimer._isRunning = false;
			}
			callback();
		}, null, Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
		_timeout = timeout;
	}

	public void Start()
	{
		using (_changeLock.EnterScope())
		{
			_isRunning = true;
			_timer.Change(_timeout, Timeout.InfiniteTimeSpan);
		}
	}

	public bool Stop()
	{
		using (_changeLock.EnterScope())
		{
			bool isRunning = _isRunning;
			_isRunning = false;
			_timer.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
			return isRunning;
		}
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
