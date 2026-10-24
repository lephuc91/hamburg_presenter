using System;
using System.Threading.Tasks;

namespace Pro.Common.Background;

public interface IAsyncExecutor
{
	void ExecuteAsync(Func<Task> action);

	void ExecuteAsyncValueTask(Func<ValueTask> action);
}
