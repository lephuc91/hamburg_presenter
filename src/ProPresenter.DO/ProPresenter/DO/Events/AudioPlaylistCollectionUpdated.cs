using System.Collections.Generic;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.DO.Events;

public class AudioPlaylistCollectionUpdated : PlaylistCollectionUpdated<MediaCue>, IAudioPlaylistEvent, IApplicationEvent
{
	public AudioPlaylistCollectionUpdated(IEnumerable<IPlaylist<MediaCue>> playlists)
		: base(playlists)
	{
	}

	public static void Publish(IEnumerable<IPlaylist<MediaCue>> playlists)
	{
		ApplicationEventPublisher.Publish(new AudioPlaylistCollectionUpdated(playlists));
	}
}
