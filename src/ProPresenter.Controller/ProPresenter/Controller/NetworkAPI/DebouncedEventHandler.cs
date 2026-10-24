using System;
using System.CodeDom.Compiler;
using System.Timers;
using Pro.Common.SourceGenerator.Attributes;
using ProPresenter.DO.Events;

namespace ProPresenter.Controller.NetworkAPI;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_publishTimer" })]
public abstract class DebouncedEventHandler : IApplicationEventHandler, IDisposable
{
	private const double PublishIntervalMS = 50.0;

	private readonly Timer _publishTimer = new Timer(50.0)
	{
		AutoReset = false
	};

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	protected DebouncedEventHandler()
	{
		_publishTimer.Elapsed += delegate
		{
			Publish();
		};
	}

	protected abstract void Publish();

	protected virtual bool CanHandle(IApplicationEvent @event)
	{
		return true;
	}

	protected virtual EventResult OnEventReceived(IApplicationEvent @event)
	{
		return EventResult.Continue;
	}

	public void Handle(IApplicationEvent @event)
	{
		if (CanHandle(@event) && OnEventReceived(@event) == EventResult.Debounce)
		{
			_publishTimer.Stop();
			_publishTimer.Start();
		}
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
			_publishTimer.Dispose();
		}
	}
}
public abstract class DebouncedEventHandler<T> : DebouncedEventHandler where T : IApplicationEvent
{
	protected override bool CanHandle(IApplicationEvent @event)
	{
		return @event is T;
	}

	protected virtual EventResult OnEventReceived(T @event)
	{
		return EventResult.Continue;
	}

	protected sealed override EventResult OnEventReceived(IApplicationEvent @event)
	{
		return OnEventReceived((T)@event);
	}
}
