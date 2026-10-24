using System;
using System.ComponentModel;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.ChangeDirectory;

public interface IChangeDirectoryProcess : INotifyPropertyChanged
{
	double CompletedPercentage { get; set; }

	IWorkspace NewWorkspace { get; }

	IWorkspace? OldWorkspace { get; }

	event Action<IChangeDirectoryProcess>? Started;

	event Action<(IChangeDirectoryProcess, bool)>? Completed;

	void Start();
}
