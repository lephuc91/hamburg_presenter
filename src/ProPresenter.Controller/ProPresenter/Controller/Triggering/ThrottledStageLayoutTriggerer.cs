using System;
using System.CodeDom.Compiler;
using System.Threading;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Time;
using Pro.Common.Time.Timer;

namespace ProPresenter.Controller.Triggering;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_stageDataUpdateTimer" })]
public sealed class ThrottledStageLayoutTriggerer : IDisposable
{
	private sealed class TriggerRequestSuppression : IDisposable
	{
		private readonly ThrottledStageLayoutTriggerer _owner;

		public TriggerRequestSuppression(ThrottledStageLayoutTriggerer owner)
		{
			_owner = owner;
			Interlocked.Increment(ref owner._requestSuppressionLevel);
		}

		public void Dispose()
		{
			Interlocked.Decrement(ref _owner._requestSuppressionLevel);
		}
	}

	private readonly TimeSlice StageLayoutUpdateThrottle = TimeSlice.FromSeconds(0.5);

	private readonly IOneShotTimer _stageDataUpdateTimer;

	private readonly Action<StageDataUpdateSource> _doTrigger;

	private int _stageDataUpdateSources;

	private int _requestSuppressionLevel;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public ThrottledStageLayoutTriggerer(ITimerFactory timerFactory, Action<StageDataUpdateSource> doTrigger)
	{
		_doTrigger = doTrigger;
		_stageDataUpdateTimer = timerFactory.CreateOneShotDispatched(StageLayoutUpdateThrottle, delegate
		{
			DoTrigger();
		});
	}

	public void RequestTrigger(StageDataUpdateSource source)
	{
		if (Volatile.Read(in _requestSuppressionLevel) <= 0)
		{
			Interlocked.Or(ref _stageDataUpdateSources, (int)source);
			if (!_stageDataUpdateTimer.IsRunning() && DoTrigger())
			{
				_stageDataUpdateTimer.Start();
			}
		}
	}

	public IDisposable StartTriggerSupression()
	{
		return new TriggerRequestSuppression(this);
	}

	private bool DoTrigger()
	{
		StageDataUpdateSource stageDataUpdateSource = (StageDataUpdateSource)Interlocked.Exchange(ref _stageDataUpdateSources, 0);
		if (stageDataUpdateSource == StageDataUpdateSource.None)
		{
			return false;
		}
		_doTrigger(stageDataUpdateSource);
		return true;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			_stageDataUpdateTimer.Dispose();
		}
	}
}
