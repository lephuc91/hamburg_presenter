using System.Collections.Generic;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.Controller.Remote.Apps;

public interface IPlaylistEncoder
{
	AllPlaylistResponse Encode<T>(IEnumerable<IPlaylist<T>> playlists) where T : ProPresenterCue;
}
