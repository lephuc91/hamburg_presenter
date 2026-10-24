using System;

namespace Pro.Common.Time.Timer;

public interface IOneShotTimer : IDisposable
{
	void Start();

	bool Stop();

	bool IsRunning();
}
