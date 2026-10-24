using System;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.DO.Events;

public record LibraryPlaylistActivePresentationRequest(Action<Playlist<ProPresenterCue>?, ProPresenterCue?> Callback) : IApplicationEvent
{
	public static void Publish(Action<Playlist<ProPresenterCue>?, ProPresenterCue?> callback)
	{
		ApplicationEventPublisher.Publish(new LibraryPlaylistActivePresentationRequest(callback));
	}
}
