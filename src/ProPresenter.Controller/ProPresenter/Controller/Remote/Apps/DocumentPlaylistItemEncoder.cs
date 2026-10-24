using ProPresenter.DO.Cues;

namespace ProPresenter.Controller.Remote.Apps;

public class DocumentPlaylistItemEncoder : IDocumentPlaylistItemEncoder
{
	public PlaylistItem Encode(IDocumentCue documentCue)
	{
		return new PlaylistItem
		{
			Name = documentCue.GetEncodedName(),
			Type = PlaylistItemType.Presentation,
			Destination = documentCue.DocumentAction?.Destination.Encode()
		};
	}
}
