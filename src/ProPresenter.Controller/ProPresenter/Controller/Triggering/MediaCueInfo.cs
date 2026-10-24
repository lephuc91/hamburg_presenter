using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.DO.Playlists;

namespace ProPresenter.Controller.Triggering;

public class MediaCueInfo<T> : CueInfo where T : ProPresenterCue
{
	public MediaCue OriginalMedia { get; }

	public Playlist<T>? OriginalPlaylist { get; }

	public TriggerLayer? TriggerLayer { get; }

	public MediaCueInfo(CueLocation location, MediaCue originalMedia, Playlist<T>? originalPlaylist)
		: base(location)
	{
		OriginalMedia = originalMedia;
		OriginalPlaylist = originalPlaylist;
		TriggerLayer = originalMedia.MediaAction?.TriggerLayer;
	}
}
