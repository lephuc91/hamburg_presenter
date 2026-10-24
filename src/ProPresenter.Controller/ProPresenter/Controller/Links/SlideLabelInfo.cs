using Pro.Common.Dispatcher;
using Pro.Common.Utility;
using Pro.DO.Label;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO.Slide.Links;

namespace ProPresenter.Controller.Links;

public class SlideLabelInfo : ISlideLabelInfo
{
	private sealed record ProvidedData(ILabel? Current, ILabel? Next);

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
					_dispatcher.Invoke(CollectInformationFromOriginalItems);
				}
			}
			return _data.Value;
		}
	}

	public ILabel? Current => Data.Current;

	public ILabel? Next => Data.Next;

	public SlideLabelInfo(IUiDispatcher dispatcher, ISlideCueInfo? cueInfo)
	{
		_dispatcher = dispatcher;
		_cueInfo = cueInfo;
	}

	private void CollectInformationFromOriginalItems()
	{
		_data.Value = new ProvidedData(_cueInfo?.OriginalCurrentSlide?.Source.SlideAction?.Label, _cueInfo?.OriginalNextSlide?.SlideAction?.Label);
	}

	private bool TryGatherArrangementInformationFromTimeline()
	{
		if (_cueInfo?.TimelineSlideInfo != null)
		{
			_data.Value = new ProvidedData(_cueInfo.TimelineSlideInfo.CurrentSlide?.Source.SlideAction?.Label, _cueInfo.TimelineSlideInfo.NextSlide?.Source.SlideAction?.Label);
			return true;
		}
		return false;
	}
}
