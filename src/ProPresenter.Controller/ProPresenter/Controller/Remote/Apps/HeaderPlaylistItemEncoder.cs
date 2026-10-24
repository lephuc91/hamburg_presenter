using ProPresenter.DO.Cues;

namespace ProPresenter.Controller.Remote.Apps;

public class HeaderPlaylistItemEncoder : IHeaderPlaylistItemEncoder
{
	public PlaylistItem Encode(IHeaderCue cue)
	{
		return new PlaylistItem
		{
			Name = cue.Name,
			Type = PlaylistItemType.Header
		};
	}
}
