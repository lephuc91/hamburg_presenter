using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.Controller.NetworkAPI;

internal class AudioPlaylistCollectionUpdateEventHandler : PlaylistCollectionUpdateEventHandler<MediaCue>
{
	public AudioPlaylistCollectionUpdateEventHandler(AudioPlaylistCollection playlists)
		: base((PlaylistCollectionBase<MediaCue>)playlists)
	{
	}

	protected override NetworkAPI_v1 GetProto(PlaylistCollectionBase<MediaCue> playlists)
	{
		return AudioHandler.UpdatePlaylists(playlists);
	}
}
