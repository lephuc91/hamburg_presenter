using System;
using System.Threading.Tasks;

namespace Pro.Common.Background;

public class CallbackJob : IJob
{
	private readonly Func<Worker, ValueTask> _executeCallback;

	public JobPriority Priority { get; }

	public string Name { get; }

	public CallbackJob(Func<ValueTask> executeCallback, string name = "", JobPriority priority = JobPriority.Normal)
		: this((Worker w) => executeCallback(), name, priority)
	{
	}

	public CallbackJob(Func<Worker, ValueTask> executeCallback, string name = "", JobPriority priority = JobPriority.Normal)
	{
		_executeCallback = executeCallback;
		Priority = priority;
		Name = ((!string.IsNullOrWhiteSpace(name)) ? name : "CallbackJob");
	}

	public ValueTask ExecuteJobAsync(Worker worker)
	{
		return _executeCallback(worker);
	}
}
