using ProPresenter.DO.Cues;

namespace ProPresenter.Controller.Remote.Apps;

public interface IHeaderPlaylistItemEncoder
{
	PlaylistItem Encode(IHeaderCue cue);
}
