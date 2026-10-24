using ProPresenter.Controller.Triggering;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Playlists;

namespace ProPresenter.Controller.Remote.Apps;

internal class ProRemoteService : IProRemoteService
{
	private readonly ICoreManager _manager;

	private readonly ITriggering _service;

	public ProRemoteService(ICoreManager manager, ITriggeringFactory triggeringFactory)
	{
		_manager = manager;
		_service = triggeringFactory.Create(TriggerSource.ProRemote);
	}

	public void SetActivePlaylist(Playlist<ProPresenterCue> playlist)
	{
		_manager.ActiveLibraryPlaylist = playlist;
	}

	public void SetActivePlaylistItem(ProPresenterCue item)
	{
		if (_manager.ActivePlaylistItem == null || _manager.ActivePlaylistItem.Type != 0 || _manager.ActivePlaylistItem != item)
		{
			_manager.ActivePlaylistItem = item;
		}
	}

	public void TriggerBackground(MediaCue mediaCue, Playlist<ProPresenterCue> playlist, CueLocation cueLocation = CueLocation.MediaBin)
	{
		_service.TriggerBackground(mediaCue, playlist, cueLocation);
	}

	public void SetActiveLibrary(ILibrary library)
	{
		_manager.ActiveLibrary = library;
	}

	public void TriggerSlide(ArrangedCue slide)
	{
		_service.TriggerSlide(slide);
	}
}
