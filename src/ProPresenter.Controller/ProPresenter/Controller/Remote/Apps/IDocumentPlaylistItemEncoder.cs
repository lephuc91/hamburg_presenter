using ProPresenter.DO.Cues;

namespace ProPresenter.Controller.Remote.Apps;

public interface IDocumentPlaylistItemEncoder
{
	PlaylistItem Encode(IDocumentCue cue);
}
