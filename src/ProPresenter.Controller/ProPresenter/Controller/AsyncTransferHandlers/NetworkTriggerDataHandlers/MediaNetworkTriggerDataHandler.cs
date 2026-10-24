using Pro.SerializationInterop.RVProtoData;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.Controller.AsyncTransferHandlers.NetworkTriggerDataHandlers;

public class MediaNetworkTriggerDataHandler : INetworkTriggerDataHandler
{
	private readonly VisualPlaylistCollection _visualPlaylists;

	public MediaNetworkTriggerDataHandler(VisualPlaylistCollection visualPlaylists)
	{
		_visualPlaylists = visualPlaylists;
	}

	public NetworkTriggerDataItem? Handle(NetworkIdentifier id, ITriggerOperation op)
	{
		if (_visualPlaylists == null)
		{
			return null;
		}
		Playlist<MediaCue> matchPlaylist;
		int nextLevel;
		MediaCue mediaCue = id.FindPlaylistItem(_visualPlaylists, out matchPlaylist, out nextLevel);
		if (mediaCue != null && matchPlaylist != null)
		{
			op.AttachMediaCueInfo(CueLocation.MediaBin, mediaCue, matchPlaylist);
		}
		return mediaCue.ToTriggerDataItem(op, matchPlaylist);
	}
}
