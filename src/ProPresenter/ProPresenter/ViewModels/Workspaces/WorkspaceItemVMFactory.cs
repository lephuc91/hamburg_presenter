using ProPresenter.DO.Workspaces;
using ProPresenter.UI.ViewModels.Workspaces;

namespace ProPresenter.ViewModels.Workspaces;

public class WorkspaceItemVMFactory : IWorkspaceItemVMFactory
{
	public IWorkspaceItemVM Create(IWorkspace workspace)
	{
		return new WorkspaceItemVM(workspace);
	}
}
