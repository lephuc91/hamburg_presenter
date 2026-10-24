using Pro.Common.Dispatcher;
using Pro.Common.Utility;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;

namespace ProPresenter.DO.Slide.Links;

public class ArrangementInformation : IArrangementInformation
{
	private sealed record ProvidedData(int CurrentSlideNumber, int SlidesRemaining, int TotalSlideCount);

	private readonly IUiDispatcher _dispatcher;

	private readonly ISlideCueInfo? _cueInfo;

	private readonly Optional<ProvidedData> _data = new Optional<ProvidedData>();

	private ProvidedData Data
	{
		get
		{
			lock (_data)
			{
				if (!_data.HasValue && !TryGatherArrangementInformationFromTimeline())
				{
					_dispatcher.Invoke(GatherArrangementInformationFromOriginalDocument);
				}
				return _data.Value;
			}
		}
	}

	public int CurrentSlideNumber => Data?.CurrentSlideNumber ?? (-1);

	public int SlidesRemaining => Data?.SlidesRemaining ?? (-1);

	public int TotalSlideCount => Data?.TotalSlideCount ?? (-1);

	public ArrangementInformation(IUiDispatcher dispatcher, ISlideCueInfo? cueInfo)
	{
		_dispatcher = dispatcher;
		_cueInfo = cueInfo;
	}

	private static IArrangement? GetActiveArrangement(IDocumentCue? documentCue)
	{
		return documentCue?.DocumentAction?.ActiveArrangement;
	}

	private void GatherArrangementInformationFromOriginalDocument()
	{
		IArrangement activeArrangement = GetActiveArrangement(_cueInfo?.OriginalDocumentCue);
		if (activeArrangement == null)
		{
			_data.Value = new ProvidedData(0, 0, 0);
			return;
		}
		int count = activeArrangement.ArrangedCues.Count;
		int num = ((_cueInfo?.OriginalCurrentSlide != null) ? (activeArrangement.ArrangedCues.IndexOf(_cueInfo.OriginalCurrentSlide) + 1) : 0);
		int slidesRemaining = count - num;
		_data.Value = new ProvidedData(num, slidesRemaining, count);
	}

	private bool TryGatherArrangementInformationFromTimeline()
	{
		if (_cueInfo?.TimelineSlideInfo != null)
		{
			_data.Value = new ProvidedData(_cueInfo.TimelineSlideInfo.CurrentSlideNumber, _cueInfo.TimelineSlideInfo.SlidesRemaining, _cueInfo.TimelineSlideInfo.TotalSlidesCount);
			return true;
		}
		return false;
	}
}
