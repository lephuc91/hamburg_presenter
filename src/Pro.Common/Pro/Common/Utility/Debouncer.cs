using System;
using System.CodeDom.Compiler;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Time.Timer;

namespace Pro.Common.Utility;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_timer" })]
public class Debouncer : IDebouncer, IDisposable
{
	private readonly Action _action;

	private readonly IOneShotTimer _timer;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public Debouncer(Func<Action, IOneShotTimer> createTimer, Action action)
	{
		_action = action;
		_timer = createTimer(action);
	}

	public void Invoke()
	{
		Invoke(forceImmediate: false);
	}

	public void Invoke(bool forceImmediate)
	{
		if (forceImmediate)
		{
			_timer.Stop();
			_action();
		}
		else
		{
			_timer.Start();
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
			_timer.Dispose();
		}
	}
}
[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_timer" })]
public class Debouncer<T> : IDebouncer<T>, IDisposable
{
	private readonly IOneShotTimer _timer;

	private readonly Action<T> _action;

	private T? _data;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public Debouncer(Func<Action, IOneShotTimer> createTimer, Action<T> action)
	{
		Debouncer<T> debouncer = this;
		_action = action;
		_timer = createTimer(delegate
		{
			action(debouncer._data);
		});
	}

	public void Invoke(T data)
	{
		Invoke(data, forceImmediate: false);
	}

	public void Invoke(T data, bool forceImmediate)
	{
		if (forceImmediate)
		{
			_timer.Stop();
			_action(data);
		}
		else
		{
			_timer.Stop();
			_data = data;
			_timer.Start();
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
			_timer.Dispose();
		}
	}
}
