using System.Collections.Generic;
using Pro.DO.Triggering;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.ViewModels.Actions;

public interface IPlaylistActionHandler
{
	ActionBase? Execute<T>(IEnumerable<IPlaylist<T>> playlists, IActionRepoContainer repoContainer, IActionRepository? repo, bool droppedBefore, bool droppedOutside, out IActionRepository? placement) where T : ProPresenterCue;
}
