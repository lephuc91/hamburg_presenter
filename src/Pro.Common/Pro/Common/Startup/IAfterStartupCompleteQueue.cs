using System;

namespace Pro.Common.Startup;

public interface IAfterStartupCompleteQueue
{
	void Enqueue(Action action);

	void AddStartup();

	void CompleteStartup();

	void Cancel();
}
