using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pro.Common.Concurrency;

public interface ISemaphore
{
	Task<IDisposable> AquireAsync(CancellationToken token = default(CancellationToken));
}
