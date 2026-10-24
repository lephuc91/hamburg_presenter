using System;
using System.Collections.Generic;
using System.Linq;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;
using Pro.Text;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Links;

namespace ProPresenter.DO.Slide.Custom.Elements;

internal static class DataLinkFactory
{
	public static ILinkedTextObject? GenerateLinkedTextObject(IEnumerable<Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink> protoDataLinks, IEnumerable<ClosedBezierPath> otherElements)
	{
		foreach (Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink item in protoDataLinks ?? Enumerable.Empty<Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink>())
		{
			switch (item.PropertyTypeCase)
			{
			case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.PropertyTypeOneofCase.AlternateText:
				return ElementTextLinkedObject.Deserialize(item.AlternateText, otherElements);
			case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.PropertyTypeOneofCase.TimerText:
				return TimerLinkedObject.Deserialize(item.TimerText, DataVault.TimerDocument?.Timers);
			case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.PropertyTypeOneofCase.ClockText:
				return ClockTextLinkedObject.Deserialize(item.ClockText);
			case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.PropertyTypeOneofCase.StageMessage:
				return StageMessageLinkedObject.Deserialize(item.StageMessage);
			case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.PropertyTypeOneofCase.VideoCountdown:
				return VideoCountdownLinkedObject.Deserialize(item.VideoCountdown);
			case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.PropertyTypeOneofCase.AudioCountdown:
				return AudioCountdownLinkedObject.Deserialize(item.AudioCountdown);
			case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.PropertyTypeOneofCase.SlideText:
				return SlideTextLinkedObject.Deserialize(item.SlideText);
			case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.PropertyTypeOneofCase.CcliText:
				return new CCLITextLinkedObject(General.Settings);
			case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.PropertyTypeOneofCase.GroupName:
				return GroupNameLinkedObject.Deserialize(item.GroupName);
			case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.PropertyTypeOneofCase.PlaylistItem:
				return PlaylistItemLinkedObject.Deserialize(item.PlaylistItem);
			case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.PropertyTypeOneofCase.AutoAdvanceTimeRemaining:
				return AutoAdvanceLinkedObject.Deserialize(item.AutoAdvanceTimeRemaining);
			case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.PropertyTypeOneofCase.PresentationNotes:
				return new PresentationNotesLinkedObject();
			case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.PropertyTypeOneofCase.CaptureStatusText:
				return CaptureTextLinkedObject.Deserialize(item.CaptureStatusText);
			case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.PropertyTypeOneofCase.SlideCount:
				return SlideCountTextLinkedObject.Deserialize(item.SlideCount);
			case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.PropertyTypeOneofCase.SlideLabelText:
				return SlideLabelTextLinkedObject.Deserialize(item.SlideLabelText);
			case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.PropertyTypeOneofCase.Presentation:
				return PresentationNameLinkedObject.Deserialize(item.Presentation);
			case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.PropertyTypeOneofCase.FileFeed:
				return FileFeedLinkedObject.Deserialize(item.FileFeed);
			case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.PropertyTypeOneofCase.RssFeed:
				return RssFeedLinkedObject.Deserialize(item.RssFeed);
			case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.PropertyTypeOneofCase.PlaybackMarkerText:
				return PlaybackMarkerTextLinkedObject.Deserialize(item.PlaybackMarkerText);
			case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.PropertyTypeOneofCase.TimecodeText:
				return new TimecodeTextLinkedObject();
			}
		}
		return null;
	}

	public static ILinkedFillObject? GenerateLinkedFillObject(IEnumerable<Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink> protoDataLinks, IEnumerable<ClosedBezierPath> otherElements)
	{
		foreach (Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink item in protoDataLinks ?? Enumerable.Empty<Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink>())
		{
			switch (item.PropertyTypeCase)
			{
			case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.PropertyTypeOneofCase.ChordChart:
				return new ChordChartLinkedObject();
			case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.PropertyTypeOneofCase.OutputScreen:
				return OutputScreenLinkedObject.Deserialize(item.OutputScreen, OutputVault.AllScreens);
			case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.PropertyTypeOneofCase.PcoLive:
				return PCOLiveLinkedObject.Deserialize(item.PcoLive);
			case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.PropertyTypeOneofCase.AlternateFill:
				return ElementLinkedFillObject.Deserialize(item.AlternateFill, otherElements);
			case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.PropertyTypeOneofCase.SlideImage:
				return SlideImageLinkedObject.Deserialize(item.SlideImage);
			case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.PropertyTypeOneofCase.GroupColor:
				return GroupColorLinkedObject.Deserialize(item.GroupColor);
			case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.PropertyTypeOneofCase.CaptureStatusColor:
				return new CaptureStatusColorLinkedObject();
			case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.PropertyTypeOneofCase.SlideLabelColor:
				return SlideLabelColorLinkedObject.Deserialize(item.SlideLabelColor);
			case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.PropertyTypeOneofCase.PlaybackMarkerColor:
				return PlaybackMarkerColorLinkedObject.Deserialize(item.PlaybackMarkerColor);
			case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.PropertyTypeOneofCase.TimecodeStatus:
				return new TimecodeStatusColorLinkedObject();
			}
		}
		return null;
	}

	public static bool TryGetTextTransform(IEnumerable<Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink> protoDataLinks, TextTransform initialTransform, out TextTransform textTransform)
	{
		if (!initialTransform.IsSupportedByDeprecatedTextTransformOptions())
		{
			textTransform = TextTransform.None;
			return false;
		}
		TextTransform? textTransform2 = null;
		Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.AlternateElementText alternateElementText = protoDataLinks?.FirstOrDefault()?.AlternateText;
		if (alternateElementText != null)
		{
			textTransform2 = ((alternateElementText.TextTransformOptions != 0) ? ((Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.AlternateElementText.Types.TextTransformOption)alternateElementText.TextTransformOptions) : alternateElementText.TextTransform).Deserialize();
		}
		else
		{
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideText slideText = protoDataLinks?.FirstOrDefault()?.SlideText;
			if (slideText != null)
			{
				textTransform2 = slideText.ElementTextTransform.Deserialize();
			}
		}
		textTransform = textTransform2.GetValueOrDefault();
		return textTransform2.HasValue;
	}

	public static IEnumerable<VisibilityCondition> GenerateVisibilityConditions(IEnumerable<Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink> protoDataLinks, IEnumerable<SlideElementBase> otherElements, out VisibilityCriterion visibilityCriterion)
	{
		visibilityCriterion = VisibilityCriterion.All;
		foreach (Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink item in protoDataLinks ?? Enumerable.Empty<Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink>())
		{
			if (item.PropertyTypeCase == Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.PropertyTypeOneofCase.VisibilityLink)
			{
				visibilityCriterion = item.VisibilityLink.VisibilityCriterion.ToVisibilityCriterion();
				return item.VisibilityLink.Conditions.Select((Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition c) => VisibilityCondition.Deserialize(c, otherElements));
			}
		}
		return Array.Empty<VisibilityCondition>();
	}
}
