using ProPresenter.DO.ChangeDirectory;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.ViewModels.Settings.Pages.General;

public interface IChangeDirectoryProcessFactory
{
	IChangeDirectoryProcess CreateChangeDirectoryProcess(IWorkspace? oldWorkspace, IWorkspace newWorkspace);
}
