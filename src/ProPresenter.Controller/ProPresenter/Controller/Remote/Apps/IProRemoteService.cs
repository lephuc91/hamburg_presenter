using ProPresenter.Controller.Triggering;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Playlists;

namespace ProPresenter.Controller.Remote.Apps;

public interface IProRemoteService
{
	void SetActivePlaylist(Playlist<ProPresenterCue> playlist);

	void SetActivePlaylistItem(ProPresenterCue item);

	void TriggerBackground(MediaCue mediaCue, Playlist<ProPresenterCue> playlist, CueLocation cueLocation = CueLocation.MediaBin);

	void SetActiveLibrary(ILibrary library);

	void TriggerSlide(ArrangedCue slide);
}
