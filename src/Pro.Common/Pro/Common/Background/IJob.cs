using System.Threading.Tasks;

namespace Pro.Common.Background;

public interface IJob
{
	JobPriority Priority { get; }

	string Name { get; }

	ValueTask ExecuteJobAsync(Worker worker);
}
