using System.Reactive.Concurrency;

namespace Pro.Common.Concurrency;

public interface IThreadPoolScheduler
{
	IScheduler Scheduler { get; }
}
