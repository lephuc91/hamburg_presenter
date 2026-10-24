using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.Logging;

namespace Pro.Common.Background;

public class JobQueue : IJobQueue
{
	private readonly ConcurrentDictionary<JobPriority, ConcurrentQueue<IJob>> _jobs = new ConcurrentDictionary<JobPriority, ConcurrentQueue<IJob>>();

	private readonly JobPriority[] _priorities = (from p in Enum.GetValues<JobPriority>()
		orderby (int)p descending
		select p).ToArray();

	internal JobQueue()
	{
	}

	public void AddJob(Action executeCallback, string name = "", JobPriority priority = JobPriority.Normal)
	{
		AddJob(new CallbackJob((Func<ValueTask>)delegate
		{
			executeCallback();
			return default(ValueTask);
		}, name, priority));
	}

	public void AddJob(Func<ValueTask> executeCallback, string name = "", JobPriority priority = JobPriority.Normal)
	{
		AddJob(new CallbackJob(executeCallback, name, priority));
	}

	public void AddJob(IJob job)
	{
		Log.Debug("JobQueue | AddJob ({0})", job.Name);
		_jobs.GetOrAdd(job.Priority, (JobPriority _) => new ConcurrentQueue<IJob>()).Enqueue(job);
	}

	public void AddJobs(IEnumerable<IJob> jobs)
	{
		foreach (IJob job in jobs)
		{
			AddJob(job);
		}
	}

	internal bool TryFindJob([NotNullWhen(true)] out IJob? job, bool includeLongRunning)
	{
		IEnumerable<JobPriority> enumerable;
		if (!includeLongRunning)
		{
			enumerable = _priorities.SkipLast(1);
		}
		else
		{
			IEnumerable<JobPriority> priorities = _priorities;
			enumerable = priorities;
		}
		foreach (JobPriority item in enumerable)
		{
			if (_jobs.TryGetValue(item, out ConcurrentQueue<IJob> value) && value.TryDequeue(out job))
			{
				return true;
			}
		}
		job = null;
		return false;
	}
}
