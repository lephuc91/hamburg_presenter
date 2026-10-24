using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVWebBrowserCue : RVCue, IPlaylistChild
{
	public PlaylistChildType ChildType => PlaylistChildType.Cue;

	[Trait]
	public string url { get; set; }
}
