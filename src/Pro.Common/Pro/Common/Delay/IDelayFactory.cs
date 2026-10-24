using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pro.Common.Delay;

public interface IDelayFactory
{
	Task Delay(TimeSpan delay, CancellationToken cancellation);
}
