using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Time;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Media;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Links;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Controller;

public static class TriggerHelper
{
	private sealed class GroupData
	{
		public IArrangedCue? CurrentSlide { get; }

		public IArrangedCue? NextSlide { get; }

		public CueGroup? NextGroup { get; }

		public GroupData(IArrangedCue? currentSlide, IArrangedCue? nextSlide, CueGroup? nextGroup)
		{
			CurrentSlide = currentSlide;
			NextSlide = nextSlide;
			NextGroup = nextGroup;
		}
	}

	private sealed class SlideCountData
	{
		public int CurrentSlideNumber { get; }

		public int SlidesRemaining { get; }

		public int TotalSlides { get; }

		public SlideCountData(int currentSlideNumber, int slidesRemaining, int totalSlides)
		{
			CurrentSlideNumber = currentSlideNumber;
			SlidesRemaining = slidesRemaining;
			TotalSlides = totalSlides;
		}
	}

	public static Slide? GetSlide(this Cue cue)
	{
		return cue.Actions.FirstOrDefault((Pro.SerializationInterop.RVProtoData.Action action) => action.Slide != null).GetSlide();
	}

	public static Slide? GetSlide(this Pro.SerializationInterop.RVProtoData.Action? slideAction)
	{
		if (slideAction == null)
		{
			return null;
		}
		Pro.SerializationInterop.RVProtoData.Action.Types.SlideType slide = slideAction.Slide;
		return slide.SlideCase switch
		{
			Pro.SerializationInterop.RVProtoData.Action.Types.SlideType.SlideOneofCase.Presentation => slide.Presentation.BaseSlide, 
			Pro.SerializationInterop.RVProtoData.Action.Types.SlideType.SlideOneofCase.Prop => slide.Prop.BaseSlide, 
			_ => null, 
		};
	}

	public static PCOLiveLinkedObject? GetPCOLiveLink(this BezierPath path)
	{
		if (path is ClosedBezierPath closedBezierPath)
		{
			FillLink fillLink = closedBezierPath.FillLink;
			if (fillLink != null && fillLink.IsEnabled && closedBezierPath.FillLink.LinkedObject is PCOLiveLinkedObject result)
			{
				return result;
			}
		}
		return null;
	}

	public static ArrangedCue? FindPreviousLogicalSlide(Playlist<ProPresenterCue>? playlist, ProPresenterCue? cue, ArrangedCue? lastActiveSlide, bool forcePreviousSlide, bool allowLooping = false)
	{
		if (lastActiveSlide == null || lastActiveSlide.BuildPosition <= 0 || forcePreviousSlide)
		{
			return FindPreviousPhysicalSlide(playlist, cue, lastActiveSlide, allowLooping, includePreviousPresentation: false);
		}
		return lastActiveSlide;
	}

	public static ArrangedCue? FindPreviousPhysicalSlide(Playlist<ProPresenterCue>? playlist, ProPresenterCue? cue, ArrangedCue? lastActiveSlide, bool allowLooping, bool includePreviousPresentation)
	{
		if (!IsAvailable(cue))
		{
			return null;
		}
		IArrangement activeArrangement = GetActiveArrangement(cue);
		if (lastActiveSlide != null && activeArrangement != null)
		{
			IImmutableObservableCollection<ArrangedCue> arrangedCues = activeArrangement.ArrangedCues;
			int num = FindSlideIndex(arrangedCues, lastActiveSlide);
			if (allowLooping && IsLooping(arrangedCues, lastActiveSlide))
			{
				return arrangedCues.LastOrDefault((ArrangedCue s) => s.IsEnabled);
			}
			ArrangedCue arrangedCue = arrangedCues.Reverse().Skip(arrangedCues.Count - num).FirstOrDefault((ArrangedCue s) => s.IsEnabled);
			if (arrangedCue != null)
			{
				return arrangedCue;
			}
			if (includePreviousPresentation && playlist != null && cue != null)
			{
				ProPresenterCue proPresenterCue = FindPreviousPlaylistItem(playlist, cue);
				if (proPresenterCue != null)
				{
					return GetActiveArrangement(proPresenterCue)?.ArrangedCues.LastOrDefault((ArrangedCue s) => s.IsEnabled);
				}
			}
		}
		if (lastActiveSlide != null)
		{
			return null;
		}
		return activeArrangement?.ArrangedCues.LastOrDefault((ArrangedCue s) => s.IsEnabled);
	}

	public static ArrangedCue? FindNextLogicalSlide(Playlist<ProPresenterCue>? playlist, ProPresenterCue? cue, ArrangedCue? lastActiveSlide, bool forceFindNextSlide = false, bool allowLooping = false)
	{
		if (lastActiveSlide == null || lastActiveSlide.BuildPosition >= lastActiveSlide.BuildCount || forceFindNextSlide)
		{
			return FindNextPhysicalSlide(playlist, cue, lastActiveSlide, allowLooping, includeNextPresentation: false, includeFirst: true);
		}
		return lastActiveSlide;
	}

	public static ArrangedCue? FindNextPhysicalSlide(Playlist<ProPresenterCue>? playlist, ProPresenterCue? cue, IArrangedCue? lastActiveSlide, bool allowLooping, bool includeNextPresentation, bool includeFirst)
	{
		if (!IsAvailable(cue))
		{
			return null;
		}
		IArrangement activeArrangement = GetActiveArrangement(cue);
		if (lastActiveSlide != null && activeArrangement != null)
		{
			IImmutableObservableCollection<ArrangedCue> arrangedCues = activeArrangement.ArrangedCues;
			int num = FindSlideIndex(arrangedCues, lastActiveSlide);
			if (allowLooping && IsLooping(arrangedCues, lastActiveSlide))
			{
				return arrangedCues.FirstOrDefault((ArrangedCue s) => s.IsEnabled);
			}
			ArrangedCue arrangedCue = arrangedCues.Skip(num + 1).FirstOrDefault((ArrangedCue s) => s.IsEnabled);
			if (arrangedCue != null)
			{
				return arrangedCue;
			}
			if (includeNextPresentation && playlist != null && cue != null)
			{
				ProPresenterCue proPresenterCue = FindNextPlaylistItem(playlist, cue);
				if (proPresenterCue != null)
				{
					if (!HasDataLoaded(proPresenterCue))
					{
						return null;
					}
					return GetActiveArrangement(proPresenterCue)?.ArrangedCues.FirstOrDefault((ArrangedCue s) => s.IsEnabled);
				}
			}
		}
		if (!includeFirst || lastActiveSlide != null)
		{
			return null;
		}
		return activeArrangement?.ArrangedCues.FirstOrDefault((ArrangedCue s) => s.IsEnabled);
	}

	public static int FindSlideIndex(IEnumerable<IArrangedCue> arrangedCues, IArrangedCue cue)
	{
		int num = arrangedCues.IndexOf(cue);
		if (num < 0)
		{
			num = arrangedCues.FindIndex((IArrangedCue c) => c.Source == cue.Source);
		}
		return num;
	}

	public static ProPresenterCue? FindNextPlaylistItem(Playlist<ProPresenterCue>? playlist, ProPresenterCue? cue)
	{
		if (playlist == null || cue == null || !playlist.Contains(cue))
		{
			return null;
		}
		return playlist.GetNext(cue, (ProPresenterCue c) => !c.IsHidden);
	}

	public static ProPresenterCue? FindPreviousPlaylistItem(Playlist<ProPresenterCue>? playlist, ProPresenterCue? cue)
	{
		if (playlist == null || cue == null || !playlist.Contains(cue))
		{
			return null;
		}
		return playlist.GetPrevious(cue, (ProPresenterCue c) => !c.IsHidden);
	}

	private static bool IsAvailable(ProPresenterCue? cue)
	{
		if (cue is ILinkableCue { IsLinked: not false } linkableCue && !(linkableCue.DocumentAction?.Presentation?.IsAvailable ?? true))
		{
			return false;
		}
		if (cue is IDocumentCue documentCue && !(documentCue.DocumentAction?.Presentation?.IsAvailable ?? true))
		{
			return false;
		}
		return true;
	}

	private static bool HasDataLoaded(ProPresenterCue cue)
	{
		if (cue is ILinkableCue { IsLinked: not false } linkableCue && !(linkableCue.DocumentAction?.Presentation?.HasDataLoaded ?? true))
		{
			return false;
		}
		if (cue is IDocumentCue documentCue && !(documentCue.DocumentAction?.Presentation?.HasDataLoaded ?? true))
		{
			return false;
		}
		return true;
	}

	public static CueGroup? FindNextCueGroup(IArrangedCue? slide, IDocumentCue? documentCue)
	{
		IArrangement activeArrangement = GetActiveArrangement(documentCue);
		if (activeArrangement != null && slide != null)
		{
			if (activeArrangement.Count == 1)
			{
				return null;
			}
			IImmutableObservableCollection<ArrangedCue> arrangedCues = activeArrangement.ArrangedCues;
			int count = FindSlideIndex(arrangedCues, slide);
			CueGroup cueGroup = slide.Group;
			foreach (ArrangedCue item in from s in arrangedCues.Skip(count)
				where s.IsEnabled
				select s)
			{
				CueGroup group = item.Group;
				bool flag = IsLooping(arrangedCues, item);
				if (cueGroup != group)
				{
					return group;
				}
				if (flag)
				{
					CueGroup cueGroup2 = activeArrangement.FirstOrDefault();
					return (cueGroup2 != cueGroup) ? cueGroup2 : null;
				}
				cueGroup = group;
			}
		}
		return null;
	}

	private static bool IsLooping(IEnumerable<ArrangedCue> arrangedCues, IArrangedCue slide)
	{
		SlideCue source = slide.Source;
		if (source == null || source.GotoNext?.LoopToBeginning != true)
		{
			if (slide == arrangedCues.LastOrDefault())
			{
				SlideCue source2 = slide.Source;
				if (source2 == null)
				{
					return false;
				}
				return source2.ParentPresentation?.SlideShowEnabled == true;
			}
			return false;
		}
		return true;
	}

	public static IArrangement? GetActiveArrangement(ProPresenterCue? playlistItem)
	{
		return GetActiveArrangement(playlistItem as IDocumentCue);
	}

	public static IArrangement? GetActiveArrangement(IDocumentCue? documentCue)
	{
		return documentCue?.DocumentAction?.ActiveArrangement;
	}

	public static string GetDocumentName(ActiveCueCollection activeCues, OutputDestination destination, ITimelineManager timelineManager)
	{
		IDocumentCue activeDocument = activeCues.GetActiveDocument(destination);
		if (activeDocument == null)
		{
			return string.Empty;
		}
		IArrangement arrangement = activeDocument.DocumentAction?.ActiveArrangement;
		string text = (activeDocument.DocumentAction?.Name ?? string.Empty) ?? "";
		(bool, bool, TimeSlice) info = timelineManager.GetInfo(activeDocument);
		(bool, bool, TimeSlice) tuple = info;
		if ((tuple.Item1 || tuple.Item2 || tuple.Item3 != default(TimeSlice)) && info.Item1)
		{
			text = text + " - [" + LocalizedStrings.Get("PRESENTATION_HEADER_TIMELINE_tooltip") + "]";
		}
		else if (!string.IsNullOrEmpty(arrangement?.Name))
		{
			text = text + " - [" + arrangement.Name + "]";
		}
		return text;
	}

	public static TimelineSlideInfo? GetTimelineSlideInfo(IEnumerable<TimelineItemInfo>? timelineItems, TimeSlice timelineDuration, TimeSlice currentItemTime, IEnumerable<IArrangedCue>? arrangedCues, TimeSlice offset)
	{
		if (timelineItems == null || arrangedCues == null)
		{
			return null;
		}
		TimelineItemInfo[] array = (from i in timelineItems
			where i.Item.TimelineItemType == TimelineItemType.Slide && i.SlideTime <= timelineDuration
			orderby i.SlideTime
			select i).ToArray();
		TimelineItemInfo timelineItemInfo = array.FirstOrDefault((TimelineItemInfo t) => t.SlideTime + offset >= currentItemTime);
		int num = ((timelineItemInfo != null) ? array.IndexOf(timelineItemInfo) : 0);
		int nextItemIndex = num + 1;
		SlideCountData slideCountLinkData = GetSlideCountLinkData(array, timelineItemInfo, num);
		GroupData groupLinkData = GetGroupLinkData(array, arrangedCues, num, slideCountLinkData.CurrentSlideNumber, nextItemIndex);
		return new TimelineSlideInfo(slideCountLinkData.CurrentSlideNumber, slideCountLinkData.SlidesRemaining, slideCountLinkData.TotalSlides, groupLinkData.CurrentSlide, groupLinkData.NextSlide, groupLinkData.NextGroup);
	}

	private static SlideCountData GetSlideCountLinkData(IEnumerable<TimelineItemInfo> sortedItems, TimelineItemInfo? currentItem, int currentItemIndex)
	{
		int num = ((currentItem != null) ? (currentItemIndex + 1) : 0);
		int slidesRemaining = sortedItems.Skip(num).Count();
		int totalSlides = sortedItems.Count();
		return new SlideCountData(num, slidesRemaining, totalSlides);
	}

	private static GroupData GetGroupLinkData(IEnumerable<TimelineItemInfo> sortedItems, IEnumerable<IArrangedCue> arrangedCues, int currentItemIndex, int currentSlideNumber, int nextItemIndex)
	{
		List<IArrangedCue> list = new List<IArrangedCue>();
		foreach (SlideCue slideCue in sortedItems.Select((TimelineItemInfo i) => i.Item).OfType<SlideCue>().NonNull())
		{
			IArrangedCue arrangedCue = arrangedCues.FirstOrDefault((IArrangedCue a) => a.Source.ID == slideCue.ID);
			if (arrangedCue != null)
			{
				list.Add(arrangedCue);
			}
		}
		IArrangedCue currentArrangedCue = list.ElementAtOrDefault(currentItemIndex);
		IArrangedCue nextSlide = list.ElementAtOrDefault(nextItemIndex);
		CueGroup nextGroup = ((currentArrangedCue == null) ? null : list.Skip(currentSlideNumber).NonNull().FirstOrDefault((IArrangedCue i) => i.Group != currentArrangedCue.Group)?.Group);
		return new GroupData(currentArrangedCue, nextSlide, nextGroup);
	}

	public static PlaybackMarkerInformation GetMarkerInformation(ICoreManager coreManager, ProLayerIndex layer)
	{
		TransportStatusEntry status = coreManager.TransportStatus.GetStatus(layer);
		if ((object)status == null)
		{
			return new PlaybackMarkerInformation(null, TimeSlice.Zero, TimeSlice.Zero, TimeSlice.Zero);
		}
		TimeSlice timeSlice = TimeSlice.FromSeconds(status.Elapsed + status.Remaining);
		TimeSlice loopDuration = (status.Media as ITransportMedia)?.Transport?.InOutDuration ?? timeSlice;
		return new PlaybackMarkerInformation(status.PlaybackMarkers, TimeSlice.FromSeconds(status.Elapsed), loopDuration, timeSlice);
	}

	public static MediaAction? GetMediaFromMacro(IEnumerable<ProPresenterMacro> macros, Guid mediaResourceId)
	{
		return macros.SelectMany((ProPresenterMacro m) => m.Actions).OfType<MediaAction>().FirstOrDefault((MediaAction m) => m.Media.ID == mediaResourceId);
	}
}
