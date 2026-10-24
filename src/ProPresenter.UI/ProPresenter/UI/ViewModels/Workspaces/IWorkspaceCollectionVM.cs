using Pro.Common.Collections;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.UI.ViewModels.Workspaces;

public interface IWorkspaceCollectionVM
{
	INotifyEnumerableChanged<IWorkspaceItemVM> Workspaces { get; }

	void EnsureCloudWorkspaceExists(IWorkspace workspace);
}
