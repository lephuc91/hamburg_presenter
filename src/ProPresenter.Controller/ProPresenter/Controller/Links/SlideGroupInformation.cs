using Pro.Common.Dispatcher;
using Pro.Common.Utility;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Slide.Links;

namespace ProPresenter.Controller.Links;

public class SlideGroupInformation : ISlideGroupInformation
{
	private sealed record ProvidedData(CueGroup? CurrentSlideGroup, CueGroup? NextSlideGroup, CueGroup? NextArrangementGroup);

	private readonly ISlideCueInfo? _cueInfo;

	private readonly IUiDispatcher _dispatcher;

	private readonly Optional<ProvidedData> _data = new Optional<ProvidedData>();

	private ProvidedData Data
	{
		get
		{
			lock (_data)
			{
				if (!_data.HasValue && !TryGatherArrangementInformationFromTimeline())
				{
					_dispatcher.Invoke(CollectInformationFromOriginalItems);
				}
			}
			return _data.Value;
		}
	}

	public CueGroup? CurrentSlideGroup => Data.CurrentSlideGroup;

	public CueGroup? NextSlideGroup => Data.NextSlideGroup;

	public CueGroup? NextArrangementGroup => Data.NextArrangementGroup;

	public SlideGroupInformation(IUiDispatcher dispatcher, ISlideCueInfo? cueInfo)
	{
		_dispatcher = dispatcher;
		_cueInfo = cueInfo;
	}

	private void CollectInformationFromOriginalItems()
	{
		ArrangedCue arrangedCue = _cueInfo?.OriginalCurrentSlide;
		IDocumentCue documentCue = _cueInfo?.OriginalDocumentCue;
		ArrangedCue arrangedCue2 = TriggerHelper.FindNextPhysicalSlide(_cueInfo?.OriginalPlaylist, documentCue as ProPresenterCue, arrangedCue, allowLooping: true, includeNextPresentation: true, includeFirst: true);
		_data.Value = new ProvidedData(arrangedCue?.Group, arrangedCue2?.Group, TriggerHelper.FindNextCueGroup(arrangedCue, documentCue));
	}

	private bool TryGatherArrangementInformationFromTimeline()
	{
		if (_cueInfo?.TimelineSlideInfo != null)
		{
			_data.Value = new ProvidedData(_cueInfo.TimelineSlideInfo.CurrentSlide?.Group, _cueInfo.TimelineSlideInfo.NextSlide?.Group, _cueInfo.TimelineSlideInfo.NextGroup);
			return true;
		}
		return false;
	}
}
