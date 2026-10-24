using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.DO.Triggering;
using Pro.Localization;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;

namespace ProPresenter.DO.Presentation;

public static class TimelineExtensions
{
	public static string GetSlideName(this Timeline timeline, SlideCue slideCue, Arrangement activeArrangement)
	{
		return LocalizedStrings.Get("PRESENTATION_HEADER_TIMELINE_CUE_label", new object[1] { (from a in GetCurrentPresentationSlides(timeline, slideCue, activeArrangement)
			select a.Source).IndexOf(slideCue) + 1 });
	}

	private static IEnumerable<ArrangedCue> GetCurrentPresentationSlides(Timeline timeline, SlideCue slideCue, Arrangement activeArrangement)
	{
		if (activeArrangement == null || !activeArrangement.ArrangedCues.Any((ArrangedCue a) => a.Source == slideCue))
		{
			IArrangement? activeArrangement2 = timeline.Presentation.ActiveArrangement;
			if (activeArrangement2 == null || !activeArrangement2.ArrangedCues.Any((ArrangedCue a) => a.Source == slideCue))
			{
				return timeline.Presentation.DefaultArrangement.ArrangedCues;
			}
			return timeline.Presentation.ActiveArrangement.ArrangedCues;
		}
		return activeArrangement.ArrangedCues;
	}

	public static ArrangedCue? FindSlide(this Timeline timeline, SlideCue slide, Arrangement activeArrangement)
	{
		return activeArrangement?.ArrangedCues.FirstOrDefault((ArrangedCue a) => a.Source == slide) ?? timeline.Presentation.ActiveArrangement?.ArrangedCues.FirstOrDefault((ArrangedCue a) => a.Source == slide) ?? timeline.Presentation.DefaultArrangement.ArrangedCues.FirstOrDefault((ArrangedCue a) => a.Source == slide);
	}

	public static string GetName(this ITimeTriggerable item, TimelineItemNamePattern namePattern = TimelineItemNamePattern.Timeline)
	{
		if (item == null)
		{
			return string.Empty;
		}
		Timeline obj = (item as TimelineItemInfo)?.Owner;
		string text = string.Empty;
		string text2 = item.Name ?? string.Empty;
		string text3 = obj?.Presentation.Name ?? string.Empty;
		ITriggerable item2 = item.Item;
		SlideCue cue = item2 as SlideCue;
		if (cue != null && cue.ParentPresentation != null)
		{
			ArrangedCue arrangedCue = cue.ParentPresentation.DefaultArrangement.ArrangedCues.FirstOrDefault((ArrangedCue ac) => ac.Source == cue);
			if (arrangedCue != null)
			{
				text = LocalizedStrings.Get("PRESENTATION_HEADER_TIMELINE_CUE_label", new object[1] { arrangedCue.Index });
			}
		}
		if (item is TimelineItemInfo timelineItemInfo)
		{
			switch (namePattern)
			{
			case TimelineItemNamePattern.Timeline:
				if (timelineItemInfo.Item.TimelineItemType != 0)
				{
					return text2;
				}
				return text;
			case TimelineItemNamePattern.Timecode:
			{
				string text4 = ((timelineItemInfo.Item.TimelineItemType == TimelineItemType.Slide) ? text : text2);
				return text3 + " - " + text4;
			}
			}
		}
		return string.Empty;
	}
}
