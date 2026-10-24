using Pro.SerializationInterop.RVProtoData;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.Controller.AsyncTransferHandlers.NetworkTriggerDataHandlers;

public class AudioNetworkTriggerDataHandler : INetworkTriggerDataHandler
{
	private readonly AudioPlaylistCollection _audioPlaylists;

	public AudioNetworkTriggerDataHandler(AudioPlaylistCollection audioPlaylists)
	{
		_audioPlaylists = audioPlaylists;
	}

	public NetworkTriggerDataItem? Handle(NetworkIdentifier id, ITriggerOperation op)
	{
		if (_audioPlaylists == null)
		{
			return null;
		}
		Playlist<MediaCue> matchPlaylist;
		int nextLevel;
		MediaCue mediaCue = id.FindPlaylistItem(_audioPlaylists, out matchPlaylist, out nextLevel);
		if (mediaCue != null && matchPlaylist != null)
		{
			op.AttachMediaCueInfo(CueLocation.AudioBin, mediaCue, matchPlaylist);
		}
		return mediaCue.ToTriggerDataItem(op, matchPlaylist);
	}
}
