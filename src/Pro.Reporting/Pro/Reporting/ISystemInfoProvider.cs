using System.Threading;
using System.Threading.Tasks;

namespace Pro.Reporting;

public interface ISystemInfoProvider
{
	Task<string> CreateSystemInfoFileAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<SystemData> CreateSystemDataAsync();
}
