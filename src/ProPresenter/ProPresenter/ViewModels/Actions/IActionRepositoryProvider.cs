using System.Collections.Generic;
using Pro.DO.Triggering;
using ProPresenter.DO.Actions;

namespace ProPresenter.ViewModels.Actions;

public interface IActionRepositoryProvider
{
	IEnumerable<IActionRepository> GenerateRepos(IActionRepository? targetRepo, IEnumerable<IAction> actions);
}
