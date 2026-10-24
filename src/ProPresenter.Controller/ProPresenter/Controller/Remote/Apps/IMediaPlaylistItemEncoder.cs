using ProPresenter.DO.Cues;

namespace ProPresenter.Controller.Remote.Apps;

public interface IMediaPlaylistItemEncoder
{
	PlaylistItem Encode(IMediaCue cue);
}
