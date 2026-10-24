using Pro.Common.Dispatcher;

namespace ProPresenter.DO.Import;

public class FontDetectionSessionFactory : IFontDetectionSessionFactory
{
	private readonly IFontDetector _fontDetector;

	private readonly IUiDispatcher _dispatcher;

	private readonly IProPresenterResourceService _resourceService;

	public FontDetectionSessionFactory(IFontDetector fontDetector, IUiDispatcher dispatcher, IProPresenterResourceService resourceService)
	{
		_fontDetector = fontDetector;
		_dispatcher = dispatcher;
		_resourceService = resourceService;
	}

	public IFontDetectionSession Create()
	{
		return new FontDetectionSession(_fontDetector, _dispatcher, _resourceService);
	}
}
