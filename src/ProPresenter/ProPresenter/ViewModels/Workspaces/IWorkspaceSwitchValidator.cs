using ProPresenter.DO.Workspaces;

namespace ProPresenter.ViewModels.Workspaces;

public interface IWorkspaceSwitchValidator
{
	bool Validate(IWorkspace workspace, out IWorkspace resultWorkspace, bool isOnLaunch = false);

	bool ValidateVersion(IWorkspace workspace, out IWorkspace resultWorkspace, bool isOnLaunch = false);
}
