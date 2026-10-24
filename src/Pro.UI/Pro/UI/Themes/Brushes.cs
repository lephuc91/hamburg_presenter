using System.Windows;
using System.Windows.Media;

namespace Pro.UI.Themes;

public static class Brushes
{
	public static ComponentResourceKey BadgeActive = new ComponentResourceKey(typeof(Brushes), "Brush_BadgeActive");

	public static ComponentResourceKey BadgeInactive = new ComponentResourceKey(typeof(Brushes), "Brush_BadgeInactive");

	public static ComponentResourceKey SpecialTextFill = new ComponentResourceKey(typeof(Brushes), "Brush_SpecialTextFill");

	public static ComponentResourceKey ScaleAndBlurPlaceholderFill = new ComponentResourceKey(typeof(Brushes), "Brush_ScaleAndBlurPlaceholderFill");

	public static ComponentResourceKey LargeScaleAndBlurPlaceholderFill = new ComponentResourceKey(typeof(Brushes), "Brush_LargeScaleAndBlurPlaceholderFill");

	public static ComponentResourceKey DefaultElementStroke = new ComponentResourceKey(typeof(Brushes), "Brush_DefaultElementStroke");

	public static ComponentResourceKey DottedLine = new ComponentResourceKey(typeof(Brushes), "Brush_DottedLine");

	public static ComponentResourceKey TimelineAudioMediaItem = new ComponentResourceKey(typeof(Brushes), "Brush_TimelineAudioMediaItem");

	public static ComponentResourceKey TimelineVisualMediaItem = new ComponentResourceKey(typeof(Brushes), "Brush_TimelineVisualMediaItem");

	public static ComponentResourceKey TimelineDefaultGroupItem = new ComponentResourceKey(typeof(Brushes), "Brush_TimelineDefaultGroupItem");

	public static ComponentResourceKey TimelineAudioRow = new ComponentResourceKey(typeof(Brushes), "Brush_TimelineAudioRow");

	public static ComponentResourceKey TimelineMediaRow = new ComponentResourceKey(typeof(Brushes), "Brush_TimelineMediaRow");

	public static ComponentResourceKey TimelineActionRow = new ComponentResourceKey(typeof(Brushes), "Brush_TimelineActionRow");

	public static ComponentResourceKey TimelineCuesRow = new ComponentResourceKey(typeof(Brushes), "Brush_TimelineCuesRow");

	public static ComponentResourceKey TimelineTickMark = new ComponentResourceKey(typeof(Brushes), "Brush_TimelineTickMark");

	public static ComponentResourceKey TimelinePlayheadMarker = new ComponentResourceKey(typeof(Brushes), "Brush_TimelinePlayheadMarker");

	public static ComponentResourceKey TimelineSectionBorder = new ComponentResourceKey(typeof(Brushes), "Brush_TimelineSectionBorder");

	public static ComponentResourceKey ThumbnailUngroupedBrush = new ComponentResourceKey(typeof(Brushes), "Brush_ThumbnailUngroupedBrush");

	public static ComponentResourceKey PlaybackScrubberTrimmedBackground = new ComponentResourceKey(typeof(Brushes), "Brush_PlaybackScrubberTrimmedBackground");

	public static ComponentResourceKey PlaybackScrubberEmptyBackground = new ComponentResourceKey(typeof(Brushes), "Brush_PlaybackScrubberEmptyBackground");

	public static ComponentResourceKey PlaybackScrubberDurationFill = new ComponentResourceKey(typeof(Brushes), "Brush_PlaybackScrubberDurationFill");

	public static ComponentResourceKey PlaybackScrubberElapsedFill = new ComponentResourceKey(typeof(Brushes), "Brush_PlaybackScrubberElapsedFill");

	public static ComponentResourceKey PlaybackScrubberLoopedFill = new ComponentResourceKey(typeof(Brushes), "Brush_PlaybackScrubberLoopedFill");

	public static ComponentResourceKey PlaybackScrubberPlayheadFill = new ComponentResourceKey(typeof(Brushes), "Brush_PlaybackScrubberPlayheadFill");

	public static ComponentResourceKey PlaybackScrubberInPointFill = new ComponentResourceKey(typeof(Brushes), "Brush_PlaybackScrubberInPointFill");

	public static ComponentResourceKey PlaybackScrubberOutPointFill = new ComponentResourceKey(typeof(Brushes), "Brush_PlaybackScrubberOutPointFill");

	public static ComponentResourceKey PlaybackScrubberLoopTick = new ComponentResourceKey(typeof(Brushes), "Brush_PlaybackScrubberLoopTick");

	public static ComponentResourceKey PendingMediaBackgroundGradient = new ComponentResourceKey(typeof(Brushes), "Brush_PendingMediaBackgroundGradient");

	public static ComponentResourceKey Transparent => new ComponentResourceKey(typeof(Brushes), "Brush_Transparent");

	public static ComponentResourceKey Mask => new ComponentResourceKey(typeof(Brushes), "Brush_Mask");

	public static ComponentResourceKey WindowBackground => new ComponentResourceKey(typeof(Brushes), "Brush_WindowBackground");

	public static ComponentResourceKey WindowBorder => new ComponentResourceKey(typeof(Brushes), "Brush_WindowBorder");

	public static ComponentResourceKey CheckerboardPrimary => new ComponentResourceKey(typeof(Brushes), "Brush_CheckerboardPrimary");

	public static ComponentResourceKey CheckerboardSecondary => new ComponentResourceKey(typeof(Brushes), "Brush_CheckerboardSecondary");

	public static ComponentResourceKey CheckerboardLightPrimary => new ComponentResourceKey(typeof(Brushes), "Brush_CheckerboardLightPrimary");

	public static ComponentResourceKey CheckerboardLightSecondary => new ComponentResourceKey(typeof(Brushes), "Brush_CheckerboardLightSecondary");

	public static ComponentResourceKey Checkerboard => new ComponentResourceKey(typeof(Brushes), "Brush_Checkerboard");

	public static ComponentResourceKey DropShadow => new ComponentResourceKey(typeof(Brushes), "Brush_DropShadow");

	public static ComponentResourceKey ControlBackground => new ComponentResourceKey(typeof(Brushes), "Brush_ControlBackground");

	public static ComponentResourceKey ControlAltBorder => new ComponentResourceKey(typeof(Brushes), "Brush_ControlAltBorder");

	public static ComponentResourceKey ControlBorder => new ComponentResourceKey(typeof(Brushes), "Brush_ControlBorder");

	public static ComponentResourceKey ControlForeground => new ComponentResourceKey(typeof(Brushes), "Brush_ControlForeground");

	public static ComponentResourceKey ControlForegroundSubdued => new ComponentResourceKey(typeof(Brushes), "Brush_ControlForegroundSubdued");

	public static ComponentResourceKey ControlDisabledForeground => new ComponentResourceKey(typeof(Brushes), "Brush_ControlDisabledForeground");

	public static ComponentResourceKey ControlMouseOver => new ComponentResourceKey(typeof(Brushes), "Brush_ControlMouseOver");

	public static ComponentResourceKey ControlChecked => new ComponentResourceKey(typeof(Brushes), "Brush_ControlChecked");

	public static ComponentResourceKey ControlDivider => new ComponentResourceKey(typeof(Brushes), "Brush_ControlDivider");

	public static ComponentResourceKey ControlOverlay => new ComponentResourceKey(typeof(Brushes), "Brush_ControlOverlay");

	public static ComponentResourceKey PopupBorder => new ComponentResourceKey(typeof(Brushes), "Brush_PopupBorder");

	public static ComponentResourceKey PopupBackground => new ComponentResourceKey(typeof(Brushes), "Brush_PopupBackground");

	public static ComponentResourceKey PopupForeground => new ComponentResourceKey(typeof(Brushes), "Brush_PopupForeground");

	public static ComponentResourceKey SliderTrackBackground => new ComponentResourceKey(typeof(Brushes), "Brush_SliderTrackBackground");

	public static ComponentResourceKey SliderFill => new ComponentResourceKey(typeof(Brushes), "Brush_SliderFill");

	public static ComponentResourceKey SliderThumbBackground => new ComponentResourceKey(typeof(Brushes), "Brush_SliderThumbBackground");

	public static ComponentResourceKey SliderThumbBorder => new ComponentResourceKey(typeof(Brushes), "Brush_SliderThumbBorder");

	public static ComponentResourceKey SliderThumbHoverBackground => new ComponentResourceKey(typeof(Brushes), "Brush_SliderThumbHoverBackground");

	public static ComponentResourceKey SliderThumbHoverBorder => new ComponentResourceKey(typeof(Brushes), "Brush_SliderThumbHoverBorder");

	public static ComponentResourceKey SliderThumbPressedBackground => new ComponentResourceKey(typeof(Brushes), "Brush_SliderThumbPressedBackground");

	public static ComponentResourceKey SliderThumbPressedBorder => new ComponentResourceKey(typeof(Brushes), "Brush_SliderThumbPressedBorder");

	public static ComponentResourceKey SliderThumbDisabledBackground => new ComponentResourceKey(typeof(Brushes), "Brush_SliderThumbDisabledBackground");

	public static ComponentResourceKey SliderThumbDisabledBorder => new ComponentResourceKey(typeof(Brushes), "Brush_SliderThumbDisabledBorder");

	public static ComponentResourceKey ToolTipBackground => new ComponentResourceKey(typeof(Brushes), "Brush_ToolTipBackground");

	public static ComponentResourceKey ToolTipBorder => new ComponentResourceKey(typeof(Brushes), "Brush_ToolTipBorder");

	public static ComponentResourceKey StateActive => new ComponentResourceKey(typeof(Brushes), "Brush_StateActive");

	public static ComponentResourceKey StateCaution => new ComponentResourceKey(typeof(Brushes), "Brush_StateCaution");

	public static ComponentResourceKey StateError => new ComponentResourceKey(typeof(Brushes), "Brush_StateError");

	public static Brush? GetBrush(ComponentResourceKey key)
	{
		return Application.Current?.TryFindResource(key) as Brush;
	}
}
