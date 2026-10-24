using Pro.DO.Triggering;
using ProPresenter.DO;
using ProPresenter.DO.Actions;

namespace ProPresenter.ViewModels.Actions;

public interface IMediaActionHandler
{
	(IAction? FirstAction, IActionRepository? Placement) Execute(IMediaActionProvider mediaActionProvider, IActionRepoContainer repoContainer, IActionRepository? repo, bool createNewRepo, bool insertBefore);

	void ExecuteWithGrouping(IMediaActionProvider mediaActionProvider, IActionRepoContainer repoContainer, IActionRepository? repo, bool createNewRepo, bool insertBefore);
}
