using System;

namespace Pro.Common.ProcessSupervision;

public interface IProcessSupervisor
{
	IObservable<ProcessState> WhenStateChanges { get; }

	void Start();
}
