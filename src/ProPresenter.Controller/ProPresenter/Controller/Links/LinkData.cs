using System.Collections.Generic;
using System.Windows.Media;
using Pro.Common.Dispatcher;
using Pro.Common.HTTP;
using Pro.Common.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO.Slide;
using ProPresenter.DO.Slide.Links;
using ProPresenter.DO.Timer;

namespace ProPresenter.Controller.Links;

public class LinkData : ILinkData
{
	private readonly IUiDispatcher _dispatcher;

	private readonly ISlideCueInfo? _cueInfo;

	private readonly Optional<System.Windows.Media.Color?> _presentationBackgroundColor = new Optional<System.Windows.Media.Color?>();

	public SlideBase? CurrentSlide { get; init; }

	public SlideBase? NextSlide { get; init; }

	public System.Windows.Media.Color? PresentationBackgroundColor
	{
		get
		{
			lock (_presentationBackgroundColor)
			{
				if (!_presentationBackgroundColor.HasValue)
				{
					_presentationBackgroundColor.Value = _dispatcher.Invoke(() => (_cueInfo?.OriginalDocumentCue?.DocumentAction?.Presentation?.UseBackgroundColor != true) ? ((System.Windows.Media.Color?)null) : _cueInfo?.OriginalDocumentCue.DocumentAction.Presentation.BackgroundColor);
				}
			}
			return _presentationBackgroundColor.Value;
		}
	}

	public ICountdownInfo? CountdownInfo { get; init; }

	public string? StageMessage { get; init; }

	public IPCOLiveInformation? PCOLiveInformation { get; init; }

	public ISlideGroupInformation? GroupInformation { get; init; }

	public ISlideLabelInfo? SlideLabelInfo { get; init; }

	public IPlaylistItemInfo? PlaylistItemInfo { get; init; }

	public IAutoAdvanceTimeInfo? AutoAdvanceTimeInfo { get; init; }

	public IArrangementInformation? ArrangementInformation { get; init; }

	public IKeyInformation? KeyInformation { get; init; }

	public IPresentationInfo? PresentationInfo { get; init; }

	public ICaptureInformation? CaptureInformation { get; init; }

	public IPlaybackMarkerInformation? CurrentPresentationPlaybackMarkers { get; init; }

	public IPlaybackMarkerInformation? CurrentAnnouncementPlaybackMarkers { get; init; }

	public IPlaybackMarkerInformation? CurrentAudioPlaybackMarkers { get; init; }

	public ITimecodeInformation? Timecode { get; init; }

	public IEnumerable<TimerData>? Timers { get; init; }

	public IEnumerable<TriggerTransferRenderState.Types.TimerState>? CoreTimers { get; init; }

	public required IRestClientFactory RestClientFactory { get; init; }

	public LinkData(IUiDispatcher dispatcher, ISlideCueInfo? cueInfo)
	{
		_dispatcher = dispatcher;
		_cueInfo = cueInfo;
	}
}
