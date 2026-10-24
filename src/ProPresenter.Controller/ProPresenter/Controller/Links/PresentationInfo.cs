using Pro.Common.Dispatcher;
using Pro.Common.Utility;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO.Slide.Links;

namespace ProPresenter.Controller.Links;

public class PresentationInfo : IPresentationInfo
{
	private readonly ISlideCueInfo? _cueInfo;

	private readonly IUiDispatcher _dispatcher;

	private readonly Optional<string> _notes = new Optional<string>();

	public string PresentationName { get; }

	public string AnnouncementName { get; }

	public string Notes
	{
		get
		{
			lock (_notes)
			{
				if (!_notes.HasValue)
				{
					_notes.Value = _dispatcher.Invoke(() => _cueInfo?.OriginalCurrentSlide?.Source.ParentPresentation?.Notes ?? string.Empty);
				}
			}
			return _notes.Value;
		}
	}

	public PresentationInfo(string presentationName, string announcementName, ISlideCueInfo? cueInfo, IUiDispatcher dispatcher)
	{
		PresentationName = presentationName;
		AnnouncementName = announcementName;
		_cueInfo = cueInfo;
		_dispatcher = dispatcher;
	}
}
