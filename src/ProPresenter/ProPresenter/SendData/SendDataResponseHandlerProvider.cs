using System.Collections.Generic;
using System.Linq;
using Pro.Common.Dispatcher;
using Pro.Common.ErrorReporting;
using Pro.CoreApplication.Media;
using Pro.Reporting;
using Pro.SerializationInterop.RVProtoData;
using Pro.Web.Cookies;
using ProPresenter.Controller;
using ProPresenter.DO;
using ProPresenter.DO.Capture;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Repositories;
using ProPresenter.DO.Resi;
using ProPresenter.DO.Settings;
using ProPresenter.DO.TestPattern;
using ProPresenter.SendData.Props;
using ProPresenter.ViewModels.Capture;
using ProPresenterCore.ProCore.Interop;
using ProPresenterCore.ProCore.Interop.SendDataHandlers;

namespace ProPresenter.SendData;

public class SendDataResponseHandlerProvider : ISendDataResponseHandlerProvider
{
	private readonly IProCoreInstance _proCoreInstance;

	private readonly ICapturePrompt _capturePrompt;

	private readonly IEncoderValidator _encoderValidator;

	private readonly ICoreManager _coreManager;

	private readonly ICrashRecovery _crashRecovery;

	private readonly ITestPatternService _testPatternService;

	private readonly IUiDispatcher _uiDispatcher;

	private readonly IProPresenterResourceService _resourceService;

	private readonly IPropAutoClearHandler _propAutoClearResponseHandler;

	private readonly IErrorPublisher _errorPublisher;

	private readonly ICookieManagerService _cookieManagerService;

	private readonly IMediaService _mediaService;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly List<ISendDataResponseHandler> _responseHandlers = new List<ISendDataResponseHandler>();

	private readonly IApp _app;

	private readonly IOutputRepository _outputRepository;

	public SendDataResponseHandlerProvider(IProCoreInstance proCoreInstance, ICapturePrompt capturePrompt, IEncoderValidator encoderValidator, ICoreManager coreManager, ICrashRecovery crashRecovery, ITestPatternService testPatternService, IUiDispatcher uiDispatcher, IProPresenterResourceService resourceService, IApp app, IPropAutoClearHandler propAutoClearResponseHandler, IErrorPublisher errorPublisher, ICookieManagerService cookieManagerService, IMediaService mediaService, IProPresenterDOFactoryProvider factoryProvider, IOutputRepository outputRepository)
	{
		_proCoreInstance = proCoreInstance;
		_capturePrompt = capturePrompt;
		_encoderValidator = encoderValidator;
		_coreManager = coreManager;
		_crashRecovery = crashRecovery;
		_testPatternService = testPatternService;
		_uiDispatcher = uiDispatcher;
		_resourceService = resourceService;
		_app = app;
		_propAutoClearResponseHandler = propAutoClearResponseHandler;
		_errorPublisher = errorPublisher;
		_cookieManagerService = cookieManagerService;
		_mediaService = mediaService;
		_factoryProvider = factoryProvider;
		_outputRepository = outputRepository;
		RegisterHandlers();
	}

	private void RegisterHandlers()
	{
		_responseHandlers.Add(new CaptureActionSendDataResponseHandler(_proCoreInstance, _capturePrompt, _uiDispatcher, _crashRecovery));
		_responseHandlers.Add(new EncoderValidatorSendDataResponseHandler(_encoderValidator, _uiDispatcher));
		_responseHandlers.Add(new TimerSendDataResponseHandler(_coreManager));
		_responseHandlers.Add(_testPatternService);
		_responseHandlers.Add(new ExceptionLogSendDataResponseHandler(_errorPublisher));
		_responseHandlers.Add(new LeaveBreadcrumbSendDataResponseHandler(Stargazer.LeaveBreadcrumb));
		_responseHandlers.Add(new CoreManagerSendDataResponseHandler(_coreManager, _uiDispatcher, _resourceService, _app));
		_responseHandlers.Add(_propAutoClearResponseHandler);
		_responseHandlers.Add(new MediaThumbnailRequestSendDataResponseHandler(_proCoreInstance, _uiDispatcher, _app, _factoryProvider, _outputRepository));
		_responseHandlers.Add(new RequestWebFillTokenAndCookiesResponseHandler(_coreManager, _app, _cookieManagerService));
		_responseHandlers.Add(new MediaAssetTriggeredResponseHandler(_mediaService));
	}

	public IEnumerable<ISendDataResponseHandler> GetHandlers(SendDataResponse.MessageTypeOneofCase sendDataResponseType)
	{
		return _responseHandlers.Where((ISendDataResponseHandler h) => h.CanHandle(sendDataResponseType));
	}
}
