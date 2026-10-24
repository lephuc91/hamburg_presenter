using System;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.ViewModels.Settings.Pages.General;

public interface IChangeWorkspaceHandler
{
	event Action<ChangeWorkspaceCompleted> Completed;

	void ChangeWorkspace(IWorkspace newWorkspace, bool publishAfterChange = false);
}
