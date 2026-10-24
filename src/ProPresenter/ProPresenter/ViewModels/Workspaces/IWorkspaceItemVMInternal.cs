using ProPresenter.DO.Workspaces;
using ProPresenter.UI.ViewModels.Workspaces;

namespace ProPresenter.ViewModels.Workspaces;

public interface IWorkspaceItemVMInternal : IWorkspaceItemVM
{
	IWorkspace Workspace { get; }
}
