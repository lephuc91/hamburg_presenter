using System.Linq;
using Pro.Common.Collections;
using Pro.DO.Triggering;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Media;

namespace ProPresenter.DO.Cues;

public static class SlideCueExtensions
{
	public static MediaBase? GetPreviewMedia(this SlideCue slideCue)
	{
		return slideCue.Actions.GetPreviewMedia();
	}

	public static MediaBase? GetPreviewMedia(this ActionCollection actions)
	{
		return actions.FirstOrDefaultOf((MediaAction a) => a.Media is VisualMedia)?.Media;
	}

	public static bool GetIncludeBackground(this SlideCue? slideCue)
	{
		if (slideCue == null)
		{
			return false;
		}
		return !slideCue.Actions.OfType<MediaAction>().Any((MediaAction m) => m.TriggerLayer == TriggerLayer.Foreground);
	}
}
