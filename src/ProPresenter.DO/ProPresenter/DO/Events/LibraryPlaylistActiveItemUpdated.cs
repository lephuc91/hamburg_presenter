using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Events;

public record LibraryPlaylistActiveItemUpdated(OutputDestination Destination, ProPresenterCue? PlaylistItem, Playlist<ProPresenterCue>? Playlist, ProLayerIndex Layer, ProResourceState State) : IApplicationEvent
{
	public static void Publish(OutputDestination destination, ProPresenterCue? playlistItem, Playlist<ProPresenterCue>? playlist, ProLayerIndex layer, ProResourceState state)
	{
		ApplicationEventPublisher.Publish(new LibraryPlaylistActiveItemUpdated(destination, playlistItem, playlist, layer, state));
	}
}
