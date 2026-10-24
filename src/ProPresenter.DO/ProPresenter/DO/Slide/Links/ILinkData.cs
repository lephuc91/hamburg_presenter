using System.Collections.Generic;
using System.Windows.Media;
using Pro.Common.HTTP;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Timer;

namespace ProPresenter.DO.Slide.Links;

public interface ILinkData
{
	SlideBase? CurrentSlide { get; }

	SlideBase? NextSlide { get; }

	System.Windows.Media.Color? PresentationBackgroundColor { get; }

	ICountdownInfo? CountdownInfo { get; }

	string? StageMessage { get; }

	IPCOLiveInformation? PCOLiveInformation { get; }

	ISlideGroupInformation? GroupInformation { get; }

	ISlideLabelInfo? SlideLabelInfo { get; }

	IPlaylistItemInfo? PlaylistItemInfo { get; }

	IAutoAdvanceTimeInfo? AutoAdvanceTimeInfo { get; }

	IArrangementInformation? ArrangementInformation { get; }

	IKeyInformation? KeyInformation { get; }

	IPresentationInfo? PresentationInfo { get; }

	ICaptureInformation? CaptureInformation { get; }

	IPlaybackMarkerInformation? CurrentPresentationPlaybackMarkers { get; }

	IPlaybackMarkerInformation? CurrentAnnouncementPlaybackMarkers { get; }

	IPlaybackMarkerInformation? CurrentAudioPlaybackMarkers { get; }

	ITimecodeInformation? Timecode { get; }

	IEnumerable<TimerData>? Timers { get; }

	IEnumerable<TriggerTransferRenderState.Types.TimerState>? CoreTimers { get; }

	IRestClientFactory RestClientFactory { get; }
}
