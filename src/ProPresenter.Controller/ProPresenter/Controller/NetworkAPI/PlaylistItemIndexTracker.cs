using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.Controller.NetworkAPI;

public class PlaylistItemIndexTracker
{
	private int _index;

	private Playlist<ProPresenterCue>? _playlist;

	public void Update(ProPresenterCue item, Playlist<ProPresenterCue> playlist)
	{
		_index = playlist.IndexOf(item);
		_playlist = playlist;
	}

	public int NextVisibleIndex(Playlist<ProPresenterCue> playlist)
	{
		if (IsSamePlaylist(playlist))
		{
			_index = LibraryPlaylistHandler.GetProximalVisiblePlaylistItemIndex(_index, playlist, 1);
		}
		return _index;
	}

	public int PreviousVisibleIndex(Playlist<ProPresenterCue> playlist)
	{
		if (IsSamePlaylist(playlist))
		{
			_index = LibraryPlaylistHandler.GetProximalVisiblePlaylistItemIndex(_index, playlist, -1);
		}
		return _index;
	}

	private bool IsSamePlaylist(Playlist<ProPresenterCue> playlist)
	{
		if (playlist != _playlist)
		{
			_index = 0;
			_playlist = playlist;
			return false;
		}
		return true;
	}
}
