using System.Collections.Generic;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.DO.Events;

public class PlaylistCollectionUpdated<T> : IApplicationEvent, IPlaylistCollectionUpdatedEvent where T : ProPresenterCue
{
	public IEnumerable<IPlaylist<T>> Playlists { get; }

	public PlaylistCollectionUpdated(IEnumerable<IPlaylist<T>> playlists)
	{
		Playlists = playlists;
	}
}
