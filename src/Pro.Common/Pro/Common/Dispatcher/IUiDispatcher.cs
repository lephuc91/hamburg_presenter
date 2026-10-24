using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Pro.Common.Dispatcher;

public interface IUiDispatcher
{
	Dispatcher Dispatcher { get; }

	void Invoke(Action action);

	void Invoke(Action action, DispatcherPriority priority);

	T? Invoke<T>(Func<T> callback);

	T? Invoke<T>(Func<T> callback, DispatcherPriority priority);

	Task InvokeAsync(Action callback, CancellationToken cancellationToken = default(CancellationToken));

	Task InvokeAsync(Action callback, DispatcherPriority priority, CancellationToken cancellationToken = default(CancellationToken));

	Task<TResult?> InvokeAsync<TResult>(Func<TResult> callback, CancellationToken cancellationToken = default(CancellationToken));

	Task<TResult?> InvokeAsync<TResult>(Func<TResult> callback, DispatcherPriority priority, CancellationToken cancellationToken = default(CancellationToken));
}
