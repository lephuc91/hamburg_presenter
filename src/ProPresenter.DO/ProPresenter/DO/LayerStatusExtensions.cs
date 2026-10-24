using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO;

public static class LayerStatusExtensions
{
	public static LayerStatus ToLayerStatus(this ProLayerIndex proLayer)
	{
		switch (proLayer)
		{
		case ProLayerIndex.UserLayerBegin:
			return LayerStatus.VideoInput;
		case ProLayerIndex.PresentationForeground:
			return LayerStatus.Slide;
		case ProLayerIndex.PresentationBackground:
			return LayerStatus.Media;
		case ProLayerIndex.AnnouncementsBackground:
		case ProLayerIndex.AnnouncementsForeground:
			return LayerStatus.Announcements;
		case ProLayerIndex.Props:
			return LayerStatus.Prop;
		case ProLayerIndex.Messages:
			return LayerStatus.Messages;
		case ProLayerIndex.Music:
			return LayerStatus.Audio;
		default:
			return LayerStatus.None;
		}
	}
}
