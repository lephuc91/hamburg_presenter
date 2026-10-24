using ProPresenter.DO.Media;
using ProPresenter.UI.Thumbnails;

namespace ProPresenter.UI.ActionPalette;

public class MediaActionCommandParameters
{
	public Thumbnail? TargetThumbnail { get; }

	public MediaType MediaType { get; }

	public bool DroppedBefore { get; }

	public bool DroppedOutside { get; }

	public MediaActionCommandParameters(Thumbnail? targetThumbnail, MediaType mediaType, bool droppedBefore, bool droppedOutside)
	{
		TargetThumbnail = targetThumbnail;
		MediaType = mediaType;
		DroppedBefore = droppedBefore;
		DroppedOutside = droppedOutside;
	}
}
