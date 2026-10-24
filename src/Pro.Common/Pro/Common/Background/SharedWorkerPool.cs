namespace Pro.Common.Background;

public static class SharedWorkerPool
{
	private const int WorkerCount = 12;

	private static readonly WorkerPool _workerPool = new WorkerPool("SharedWorkerPool");

	public static JobQueue Queue => _workerPool.JobQueue;

	public static void StartupWorkers()
	{
		_workerPool.StartWorkers(12 - _workerPool.WorkerCount);
	}

	public static void ShutdownWorkers()
	{
		_workerPool.StopAll();
	}

	public static void AbortWorkers()
	{
		_workerPool.AbortAll();
	}
}
