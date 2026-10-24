using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;

namespace ProPresenter.Controller.Remote.Apps;

public class MediaPlaylistItemEncoder : IMediaPlaylistItemEncoder
{
	private readonly IImageEncoder _imageEncoder;

	public MediaPlaylistItemEncoder(IImageEncoder? imageEncoder = null)
	{
		_imageEncoder = imageEncoder ?? new ImageEncoder();
	}

	public PlaylistItem Encode(IMediaCue cue)
	{
		MediaAction mediaAction = cue.MediaAction;
		return new PlaylistItem
		{
			Name = cue.Name,
			Type = ((mediaAction != null && mediaAction.Media.MediaType == MediaType.Audio) ? PlaylistItemType.Audio : PlaylistItemType.Video),
			Thumbnail = _imageEncoder.Encode(mediaAction?.VisualMedia?.Drawing.PreviewImage),
			Artist = (mediaAction?.FileMedia?.Metadata?.Artist ?? string.Empty)
		};
	}
}
