using System;
using System.Threading.Tasks;

namespace Pro.Common.Background;

public class AsyncExecutor : IAsyncExecutor
{
	public void ExecuteAsync(Func<Task> action)
	{
		action().ExecuteAsync();
	}

	public void ExecuteAsyncValueTask(Func<ValueTask> action)
	{
		action().ExecuteAsync();
	}
}
