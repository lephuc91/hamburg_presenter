using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVAudioCue : RVCue, IPlaylistChild
{
	public PlaylistChildType ChildType => PlaylistChildType.Cue;

	[Child]
	[Optional]
	public RVAudioElement element { get; set; }
}
