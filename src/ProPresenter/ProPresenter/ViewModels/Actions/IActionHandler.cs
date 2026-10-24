using System.Collections.Generic;
using Pro.DO.Triggering;
using ProPresenter.DO;
using ProPresenter.DO.Actions;

namespace ProPresenter.ViewModels.Actions;

public interface IActionHandler
{
	IAction? Execute(IEnumerable<IAction>? actions, IActionRepoContainer repoContainer, IActionRepository? repo, bool droppedBefore, bool droppedOutside, out IActionRepository? placement);
}
