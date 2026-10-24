using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Pro.Common.SourceGenerator.Attributes;

namespace Pro.Common.Async;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_workItemsWaiting" })]
public sealed class PumpingSynchronizationContext : SynchronizationContext, IDisposable
{
	private readonly ConcurrentQueue<Tuple<SendOrPostCallback, object?>> _items = new ConcurrentQueue<Tuple<SendOrPostCallback, object>>();

	private readonly AutoResetEvent _workItemsWaiting = new AutoResetEvent(initialState: false);

	private readonly Func<Task> _task;

	private ExceptionDispatchInfo? _caughtException;

	private bool _done;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public PumpingSynchronizationContext(Func<Task> task)
	{
		_task = task ?? throw new ArgumentNullException("task", "Please remember to pass a Task to be executed");
	}

	public override void Post(SendOrPostCallback d, object? state)
	{
		_items.Enqueue(Tuple.Create(d, state));
		_workItemsWaiting.Set();
	}

	public void Run()
	{
		Post(PostCallback, null);
		while (!_done)
		{
			if (_items.TryDequeue(out Tuple<SendOrPostCallback, object> result))
			{
				result.Item1(result.Item2);
				if (_caughtException != null)
				{
					_caughtException.Throw();
				}
			}
			else
			{
				_workItemsWaiting.WaitOne();
			}
		}
		async void PostCallback(object? _)
		{
			try
			{
				await _task().ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception source)
			{
				_caughtException = ExceptionDispatchInfo.Capture(source);
				throw;
			}
			finally
			{
				Post(delegate
				{
					_done = true;
				}, null);
			}
		}
	}

	public override void Send(SendOrPostCallback d, object? state)
	{
		throw new NotSupportedException("Cannot send to same thread");
	}

	public override SynchronizationContext CreateCopy()
	{
		return this;
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
			_workItemsWaiting.Dispose();
		}
	}
}
