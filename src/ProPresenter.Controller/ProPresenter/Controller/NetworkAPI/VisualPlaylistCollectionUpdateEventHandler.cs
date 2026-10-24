using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.Controller.NetworkAPI;

internal class VisualPlaylistCollectionUpdateEventHandler : PlaylistCollectionUpdateEventHandler<MediaCue>
{
	public VisualPlaylistCollectionUpdateEventHandler(VisualPlaylistCollection playlists)
		: base((PlaylistCollectionBase<MediaCue>)playlists)
	{
	}

	protected override NetworkAPI_v1 GetProto(PlaylistCollectionBase<MediaCue> playlists)
	{
		return MediaHandler.UpdatePlaylists(playlists);
	}
}
