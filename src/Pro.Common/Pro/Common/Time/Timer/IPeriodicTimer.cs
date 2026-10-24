using System;

namespace Pro.Common.Time.Timer;

public interface IPeriodicTimer : IDisposable
{
	void Start();

	void Stop();

	bool IsRunning();
}
