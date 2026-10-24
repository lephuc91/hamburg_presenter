using Pro.Common.Background;
using Pro.Common.Dispatcher;
using Pro.Common.Time.Timer;
using ProPresenter.Controller;
using ProPresenter.DO;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Media;
using ProPresenter.DO.Props;
using ProPresenter.Rendering;
using ProPresenter.SendData.Props;
using ProPresenter.UI.ViewModels.Props;

namespace ProPresenter.ViewModels.Props;

public class PropGroupCollectionFactoryVM : IPropGroupCollectionFactoryVM
{
	private readonly IProPresenterResourceService _resourceService;

	private readonly ISlidePreviewService _slidePreviewService;

	private readonly IPropPrompts _propPrompts;

	private readonly IPropAutoClearService _propAutoClearService;

	private readonly ITimerFactory _timerFactory;

	private readonly IAsyncExecutor _asyncExecutor;

	private readonly IMediaProvider _mediaProvider;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly ITriggering _triggerService;

	private readonly IUiDispatcher _uiDispatcher;

	public PropGroupCollectionFactoryVM(IProPresenterResourceService resourceService, ISlidePreviewService slidePreviewService, IPropPrompts propPrompts, ITriggeringFactory triggeringFactory, IPropAutoClearService propAutoClearService, ITimerFactory timerFactory, IAsyncExecutor asyncExecutor, IMediaProvider mediaProvider, IProPresenterDOFactoryProvider factoryProvider, IUiDispatcher uiDispatcher)
	{
		_resourceService = resourceService;
		_slidePreviewService = slidePreviewService;
		_propPrompts = propPrompts;
		_propAutoClearService = propAutoClearService;
		_timerFactory = timerFactory;
		_asyncExecutor = asyncExecutor;
		_mediaProvider = mediaProvider;
		_factoryProvider = factoryProvider;
		_triggerService = triggeringFactory.Create();
		_uiDispatcher = uiDispatcher;
	}

	public IPropGroupVM CreatePropGroupVM(IPropGroup propGroup, IPropGroupCollectionVM propGroupCollectionVM)
	{
		return new PropGroupVM(this, propGroupCollectionVM, propGroup, _propPrompts, _triggerService, _mediaProvider, _factoryProvider, _uiDispatcher);
	}

	public IPropCueVM CreatePropCueVM(IPropCue propCue, IPropGroupVM parentGroupVM)
	{
		return new PropCueVM(propCue, parentGroupVM, _resourceService, _slidePreviewService, _triggerService, _propAutoClearService, _timerFactory, _asyncExecutor);
	}
}
