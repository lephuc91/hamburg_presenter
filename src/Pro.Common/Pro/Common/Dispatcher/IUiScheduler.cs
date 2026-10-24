using System.Reactive.Concurrency;

namespace Pro.Common.Dispatcher;

public interface IUiScheduler
{
	IScheduler Scheduler { get; }
}
