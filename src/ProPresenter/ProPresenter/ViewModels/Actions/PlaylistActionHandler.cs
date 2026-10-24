using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.DO.Triggering;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.ViewModels.Actions;

public class PlaylistActionHandler : IPlaylistActionHandler
{
	private readonly IActionRepositoryProvider _provider;

	public PlaylistActionHandler(IActionRepositoryProvider provider)
	{
		_provider = provider;
	}

	public ActionBase? Execute<T>(IEnumerable<IPlaylist<T>> playlists, IActionRepoContainer repoContainer, IActionRepository? repo, bool droppedBefore, bool droppedOutside, out IActionRepository? placement) where T : ProPresenterCue
	{
		placement = repo;
		PlaylistAction action = GetAction(playlists.LastOrDefault());
		bool flag = droppedOutside || repo == null;
		IActionRepository[] array = _provider.GenerateRepos(flag ? null : repo, action.ToEnumerable()).ToArray();
		if (flag)
		{
			repoContainer.Insert(array, repo, droppedBefore);
			placement = array.FirstOrDefault();
		}
		return action;
	}

	private static PlaylistAction? GetAction<T>(IPlaylist<T>? playlist) where T : ProPresenterCue
	{
		return playlist.ToAction() as PlaylistAction;
	}
}
