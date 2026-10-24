using ProPresenter.DO.Workspaces;
using ProPresenter.UI.ViewModels.Workspaces;

namespace ProPresenter.ViewModels.Workspaces;

public interface IWorkspaceItemVMFactory
{
	IWorkspaceItemVM Create(IWorkspace workspace);
}
