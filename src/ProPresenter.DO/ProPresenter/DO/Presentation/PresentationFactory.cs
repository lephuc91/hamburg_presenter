using Pro.Common.Time;
using Pro.Common.Time.Timer;
using Pro.DO.Transitions;
using Pro.UI.DialogService;
using ProPresenter.DO.Bibles;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.MultiTracks;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO.Presentation;

public class PresentationFactory : IPresentationFactory
{
	private readonly IApp _app;

	private readonly ITimerFactory _timerFactory;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly IMessageDialogService _messageDialogService;

	private readonly ICurrentTime _currentTime;

	public PresentationFactory(IApp app, ITimerFactory timerFactory, ITransitionDescriptionCollection transitionDescriptions, IProPresenterDOFactoryProvider factoryProvider, IMessageDialogService messageDialogService, ICurrentTime currentTime)
	{
		_app = app;
		_timerFactory = timerFactory;
		_transitionDescriptions = transitionDescriptions;
		_factoryProvider = factoryProvider;
		_messageDialogService = messageDialogService;
		_currentTime = currentTime;
	}

	public IPresentation Create(PresentationType type, TemplateSlide? templateSlide = null)
	{
		return type switch
		{
			PresentationType.Bible => CreateBible(templateSlide), 
			PresentationType.MultiTracks => CreateMultiTracks(templateSlide), 
			_ => CreateCustom(templateSlide), 
		};
	}

	public BiblePresentation CreateBible(TemplateSlide? templateSlide = null, BibleTranslationCollection? translations = null)
	{
		return new BiblePresentation(_app, _timerFactory, _factoryProvider, _transitionDescriptions, _messageDialogService, _currentTime, templateSlide, translations);
	}

	public CustomPresentation CreateCustom(TemplateSlide? templateSlide = null)
	{
		return new CustomPresentation(_app, _timerFactory, _factoryProvider, _transitionDescriptions, _messageDialogService, _currentTime, templateSlide);
	}

	public MultiTracksPresentation CreateMultiTracks(TemplateSlide? templateSlide = null, MultiTracksLicenseData? licenseData = null)
	{
		if (licenseData != null)
		{
			return new MultiTracksPresentation(licenseData.SongID, licenseData.CustomerID, licenseData.ExpirationDate, licenseData.LicenseExpiration, licenseData.SubscriptionLevel, _app, _timerFactory, _factoryProvider, _transitionDescriptions, _messageDialogService, _currentTime, templateSlide);
		}
		return new MultiTracksPresentation(_app, _timerFactory, _factoryProvider, _transitionDescriptions, _messageDialogService, _currentTime, templateSlide);
	}
}
