using System.Collections.Generic;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.DO.Events;

public class LibraryPlaylistCollectionUpdated : PlaylistCollectionUpdated<ProPresenterCue>, ILibraryPlaylistEvent, IApplicationEvent
{
	public LibraryPlaylistCollectionUpdated(IEnumerable<IPlaylist<ProPresenterCue>> playlists)
		: base(playlists)
	{
	}

	public static void Publish(IEnumerable<IPlaylist<ProPresenterCue>> playlists)
	{
		ApplicationEventPublisher.Publish(new LibraryPlaylistCollectionUpdated(playlists));
	}
}
