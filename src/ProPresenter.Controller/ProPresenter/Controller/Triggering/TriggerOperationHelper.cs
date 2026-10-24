using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.DO.Triggering;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;

namespace ProPresenter.Controller.Triggering;

internal static class TriggerOperationHelper
{
	public static MediaAction? GetGraphicMediaAction(this TriggerOperation? op)
	{
		return GetMediaAction(op, (MediaAction? m) => m?.IsGraphicMedia ?? false);
	}

	public static MediaAction? GetAudioMediaAction(this TriggerOperation? op)
	{
		return GetMediaAction(op, (MediaAction? m) => m?.IsAudioMedia ?? false);
	}

	public static PlaybackMarkerCollection? GetPlaybackMarkers(this TriggerOperation? op)
	{
		return GetMediaAction(op, (MediaAction? m) => m?.PlaybackMarkers != null)?.PlaybackMarkers;
	}

	public static MediaCue? GetOriginalMediaCue(this TriggerOperation? op)
	{
		if (op == null)
		{
			return null;
		}
		if (op.CueInfo is MediaCueInfo<ProPresenterCue> mediaCueInfo)
		{
			return mediaCueInfo?.OriginalMedia;
		}
		if (op.CueInfo is MediaCueInfo<MediaCue> mediaCueInfo2)
		{
			return mediaCueInfo2?.OriginalMedia;
		}
		return null;
	}

	private static MediaAction? GetMediaAction(TriggerOperation? op, Func<MediaAction?, bool> predicate)
	{
		if (op == null)
		{
			return null;
		}
		if (op.CueInfo is MediaCueInfo<ProPresenterCue> mediaCueInfo && predicate(mediaCueInfo?.OriginalMedia?.MediaAction))
		{
			return mediaCueInfo?.OriginalMedia?.MediaAction;
		}
		if (op.CueInfo is MediaCueInfo<MediaCue> mediaCueInfo2 && predicate(mediaCueInfo2?.OriginalMedia?.MediaAction))
		{
			return mediaCueInfo2?.OriginalMedia?.MediaAction;
		}
		if (op.CueInfo is SlideCueInfo slideCueInfo)
		{
			MediaAction mediaAction = slideCueInfo?.OriginalCurrentSlide?.Source.Actions.OfType<MediaAction>().FirstOrDefault<MediaAction>(predicate);
			if (mediaAction != null)
			{
				return mediaAction;
			}
		}
		MediaAction mediaAction2 = op.MacroInfos.SelectMany(delegate(MacroInfo m)
		{
			IEnumerable<IAction> enumerable = m.OriginalMacro?.Actions;
			return enumerable ?? Enumerable.Empty<IAction>();
		}).NonNull().OfType<MediaAction>()
			.FirstOrDefault<MediaAction>(predicate);
		if (mediaAction2 != null)
		{
			return mediaAction2;
		}
		return null;
	}
}
