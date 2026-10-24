using System.Collections.Generic;
using System.Linq;
using Pro.Common.Components.Reversibility;
using Pro.DO.Reversibility;
using Pro.DO.Triggering;
using ProPresenter.DO;
using ProPresenter.DO.Actions;

namespace ProPresenter.ViewModels.Actions;

public class MediaActionHandler : IMediaActionHandler
{
	private readonly IActionRepositoryProvider _provider;

	private readonly IActionRepositoryGroupStrategy? _groupStategy;

	public MediaActionHandler(IActionRepositoryProvider provider, IActionRepositoryGroupStrategy? groupStrategy)
	{
		_provider = provider;
		_groupStategy = groupStrategy;
	}

	public (IAction? FirstAction, IActionRepository? Placement) Execute(IMediaActionProvider mediaActionProvider, IActionRepoContainer repoContainer, IActionRepository? repo, bool droppedOutside, bool droppedBefore)
	{
		MediaAction[] array = mediaActionProvider.GetActions().ToArray();
		bool flag = droppedOutside || repo == null;
		if (flag)
		{
			repoContainer.UndoStack?.BeginCommit(ProPresenter.DO.UndoActionTypes.DropMediaSlides.ToAction());
		}
		else
		{
			repoContainer.UndoStack?.BeginCommit(Pro.DO.Reversibility.UndoActionTypes.AddAction.ToAction());
		}
		IActionRepository[] array2 = _provider.GenerateRepos(flag ? null : repo, array).ToArray();
		if (flag)
		{
			repoContainer.Insert(array2, repo, droppedBefore);
		}
		repoContainer.UndoStack?.EndCommit(null, null, autoFinalize: true);
		return (FirstAction: array.FirstOrDefault(), Placement: array2.FirstOrDefault());
	}

	public void ExecuteWithGrouping(IMediaActionProvider mediaActionProvider, IActionRepoContainer repoContainer, IActionRepository? repo, bool droppedOutside, bool droppedBefore)
	{
		repoContainer.UndoStack?.BeginCommit(ProPresenter.DO.UndoActionTypes.DropMediaSlides.ToAction());
		if (droppedOutside || repo == null)
		{
			foreach (var groupedAction in mediaActionProvider.GetGroupedActions())
			{
				string item = groupedAction.DirectoryName;
				IEnumerable<MediaAction> item2 = groupedAction.Actions;
				IActionRepository[] array = _provider.GenerateRepos(null, item2).ToArray();
				repoContainer.Insert(array, repo, droppedBefore);
				_groupStategy?.AssignGroup(repoContainer, item, array);
				repo = array.LastOrDefault();
			}
		}
		else
		{
			foreach (IActionRepository item3 in _provider.GenerateRepos(repo, mediaActionProvider.GetActions()))
			{
				_ = item3;
			}
		}
		repoContainer.UndoStack?.EndCommit(null, null, autoFinalize: true);
	}
}
