namespace Pro.Common.Concurrency;

public interface ISemaphoreFactory
{
	ISemaphore Create(int initialCount);
}
