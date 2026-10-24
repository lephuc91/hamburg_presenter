using System.Reactive.Concurrency;
using Pro.Common.Concurrency;

namespace ProPresenter.Services;

public class ThreadPoolScheduler : IThreadPoolScheduler
{
	public IScheduler Scheduler => System.Reactive.Concurrency.ThreadPoolScheduler.Instance;
}
