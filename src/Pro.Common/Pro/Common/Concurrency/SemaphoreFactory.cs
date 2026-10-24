using System.Threading;

namespace Pro.Common.Concurrency;

public class SemaphoreFactory : ISemaphoreFactory
{
	public ISemaphore Create(int initialCount)
	{
		return new Semaphore(new SemaphoreSlim(initialCount));
	}
}
