using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pro.Common.Async;

public sealed class PumpingSynchronizationContextExecutor : IDisposable
{
	private readonly SynchronizationContext? _originalContext;

	private readonly PumpingSynchronizationContext _context;

	public PumpingSynchronizationContextExecutor(Func<Task> task)
	{
		_originalContext = SynchronizationContext.Current;
		_context = new PumpingSynchronizationContext(task);
		SynchronizationContext.SetSynchronizationContext(_context);
	}

	public void Run()
	{
		_context.Run();
	}

	public void Dispose()
	{
		SynchronizationContext.SetSynchronizationContext(_originalContext);
		_context.Dispose();
	}
}
