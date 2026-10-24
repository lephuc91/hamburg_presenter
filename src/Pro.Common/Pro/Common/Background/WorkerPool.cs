using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.Logging;

namespace Pro.Common.Background;

public class WorkerPool
{
	private readonly string _name;

	private readonly JobQueue _jobQueue = new JobQueue();

	private readonly List<Worker> _workers = new List<Worker>();

	public JobQueue JobQueue => _jobQueue;

	public int WorkerCount => _workers.Count;

	public WorkerPool(string name, int workerCount = 0)
	{
		_name = name;
		StartWorkers(workerCount);
	}

	public void StartWorkers(int workerCount)
	{
		Log.Debug("{0} | StartWorkers ({1})", _name, workerCount);
		for (int i = 0; i < workerCount; i++)
		{
			StartWorker();
		}
	}

	public void StartWorker()
	{
		Log.Debug("{0} | StartWorker", _name);
		Worker worker = new Worker($"{_name} Worker {_workers.Count}");
		worker.Start(_jobQueue);
		_workers.Add(worker);
	}

	public void StopAll()
	{
		Log.Debug("{0} | StopWorker", _name);
		Task.WaitAll(_workers.Select((Worker worker) => Task.Run((Action)worker.Stop)).ToArray());
		_workers.Clear();
	}

	internal void AbortAll()
	{
		Log.Debug("{0} | AbortAll", _name);
		Task.WaitAll(_workers.Select((Worker worker) => Task.Run((Action)worker.Abort)).ToArray());
		_workers.Clear();
	}
}
