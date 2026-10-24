using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pro.Common.Delay;

public class DelayFactory : IDelayFactory
{
	public Task Delay(TimeSpan delay, CancellationToken cancellation)
	{
		return Task.Delay(delay, cancellation);
	}
}
