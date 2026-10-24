using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pro.Common.Background;

public interface IJobQueue
{
	void AddJob(Action executeCallback, string name = "", JobPriority priority = JobPriority.Normal);

	void AddJob(Func<ValueTask> executeCallback, string name = "", JobPriority priority = JobPriority.Normal);

	void AddJob(IJob job);

	void AddJobs(IEnumerable<IJob> jobs);
}
