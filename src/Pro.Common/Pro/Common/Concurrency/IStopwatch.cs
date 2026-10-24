using System;

namespace Pro.Common.Concurrency;

public interface IStopwatch
{
	TimeSpan Elapsed { get; }

	void Restart();
}
