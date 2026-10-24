using Pro.Text;
using Pro.Text.Fills;

namespace ProPresenter.DO.Media;

public class TextFillMediaFactory : ITextFillMediaFactory
{
	private readonly IMediaFactory _mediaFactory;

	public TextFillMediaFactory(IMediaFactory mediaFactory)
	{
		_mediaFactory = mediaFactory;
	}

	public ITextFillMedia CreateImageMedia(string containerId)
	{
		VisualMedia visualMedia = _mediaFactory.CreateVisualMedia(containerId, null);
		visualMedia.SupportsAudio = false;
		visualMedia.SupportsScaleAndBlur = false;
		return visualMedia;
	}

	public ITextFillMedia CreateVideoMedia(string containerId)
	{
		VideoMedia videoMedia = _mediaFactory.CreateVideoMedia(containerId, null);
		videoMedia.SupportsAudio = false;
		videoMedia.SupportsScaleAndBlur = false;
		return videoMedia;
	}
}
