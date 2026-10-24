using System;
using System.Reactive.Concurrency;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using Pro.Common.Dispatcher;
using Pro.Common.Logging;

namespace ProPresenter.Services;

public class UiDispatcher : IUiDispatcher, IUiScheduler
{
	public Dispatcher Dispatcher { get; }

	public IScheduler Scheduler => new DispatcherScheduler(Dispatcher);

	public UiDispatcher(Dispatcher dispatcher)
	{
		Dispatcher = dispatcher;
	}

	public void Invoke(Action action)
	{
		Execute(delegate
		{
			Dispatcher.Invoke(action);
		});
	}

	public void Invoke(Action action, DispatcherPriority priority)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		Execute(delegate
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			Dispatcher.Invoke(action, priority);
		});
	}

	public T? Invoke<T>(Func<T> callback)
	{
		return Execute(() => Dispatcher.Invoke<T>(callback));
	}

	public T? Invoke<T>(Func<T> callback, DispatcherPriority priority)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		return Execute(() => Dispatcher.Invoke<T>(callback, priority));
	}

	public Task InvokeAsync(Action callback, CancellationToken cancellationToken = default(CancellationToken))
	{
		return Execute(() => Dispatcher.InvokeAsync(callback, (DispatcherPriority)9, cancellationToken));
	}

	public Task InvokeAsync(Action callback, DispatcherPriority priority, CancellationToken cancellationToken = default(CancellationToken))
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		return Execute(() => Dispatcher.InvokeAsync(callback, priority, cancellationToken));
	}

	public Task<TResult?> InvokeAsync<TResult>(Func<TResult> callback, CancellationToken cancellationToken = default(CancellationToken))
	{
		return Execute(() => Dispatcher.InvokeAsync<TResult>(callback, (DispatcherPriority)9, cancellationToken));
	}

	public Task<TResult?> InvokeAsync<TResult>(Func<TResult> callback, DispatcherPriority priority, CancellationToken cancellationToken = default(CancellationToken))
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		return Execute(() => Dispatcher.InvokeAsync<TResult>(callback, priority, cancellationToken));
	}

	private void Execute(Action action)
	{
		if (Dispatcher.HasShutdownFinished || Dispatcher.HasShutdownStarted)
		{
			return;
		}
		try
		{
			action();
		}
		catch (Exception exception)
		{
			Log.Error(exception);
		}
	}

	private T? Execute<T>(Func<T> action)
	{
		if (Dispatcher.HasShutdownFinished || Dispatcher.HasShutdownStarted)
		{
			return default(T);
		}
		try
		{
			return action();
		}
		catch (Exception exception)
		{
			Log.Error(exception);
			return default(T);
		}
	}

	private Task Execute(Func<DispatcherOperation> action)
	{
		if (Dispatcher.HasShutdownFinished || Dispatcher.HasShutdownStarted)
		{
			return Task.CompletedTask;
		}
		try
		{
			return action().Task;
		}
		catch (Exception exception)
		{
			Log.Error(exception);
			return Task.CompletedTask;
		}
	}

	private async Task<T?> Execute<T>(Func<DispatcherOperation<T>> action)
	{
		if (Dispatcher.HasShutdownFinished || Dispatcher.HasShutdownStarted)
		{
			return default(T);
		}
		try
		{
			return await action().Task;
		}
		catch (Exception exception)
		{
			Log.Error(exception);
			return default(T);
		}
	}
}
