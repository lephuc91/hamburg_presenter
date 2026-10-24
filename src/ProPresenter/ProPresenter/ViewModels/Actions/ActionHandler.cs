using System.Collections.Generic;
using System.Linq;
using Pro.DO.Triggering;
using ProPresenter.DO;
using ProPresenter.DO.Actions;

namespace ProPresenter.ViewModels.Actions;

public class ActionHandler : IActionHandler
{
	private readonly IActionRepositoryProvider _provider;

	public ActionHandler(IActionRepositoryProvider provider)
	{
		_provider = provider;
	}

	public IAction? Execute(IEnumerable<IAction>? actions, IActionRepoContainer repoContainer, IActionRepository? repo, bool droppedBefore, bool droppedOutside, out IActionRepository? placement)
	{
		placement = repo;
		if (actions == null || !actions.Any())
		{
			return null;
		}
		bool flag = droppedOutside || repo == null;
		IActionRepository[] array = _provider.GenerateRepos(flag ? null : repo, actions).ToArray();
		if (flag)
		{
			repoContainer.Insert(array, repo, droppedBefore);
			placement = array.FirstOrDefault();
		}
		return actions.LastOrDefault();
	}
}
