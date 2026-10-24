using System.Windows.Input;
using Pro.Common.Dispatcher;
using Pro.Common.Downloads;
using Pro.Common.Utility;
using Pro.DO.Transitions;
using Pro.UI.Utility;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO;
using ProPresenter.DO.Import;
using ProPresenter.DO.Media;
using ProPresenter.DO.Media.Properties.File;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Settings;
using ProPresenter.UI.MediaLibrary;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels.ActionsMenu;

public class ActionsMenuVMFactory : IActionsMenuVMFactory
{
	private readonly IDownloadManager _downloadManager;

	private readonly IProPresenterResourceService _resourceService;

	private readonly IOutputService _outputService;

	private readonly IFileSelectorService _fileSelectorService;

	private readonly IRemoteFileLoader _remoteFileLoader;

	private readonly IImportProcessFactory _importProcessFactory;

	private readonly IUiScheduler _uiScheduler;

	private readonly IApp _app;

	private readonly IMediaActionService _mediaActionService;

	private readonly IProcessHelper _processHelper;

	private readonly IMediaFactory _mediaFactory;

	private readonly IOutputConfiguration _outputConfiguration;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	public ActionsMenuVMFactory(IDownloadManager downloadManager, IProPresenterResourceService resourceService, IOutputService outputService, IFileSelectorService fileSelectorService, IRemoteFileLoader remoteFileLoader, IImportProcessFactory importProcessFactory, IUiScheduler uiScheduler, IApp app, IMediaActionService mediaActionService, IProcessHelper processHelper, IMediaFactory mediaFactory, IOutputConfiguration outputConfiguration, ITransitionDescriptionCollection transitionDescriptions)
	{
		_downloadManager = downloadManager;
		_resourceService = resourceService;
		_outputService = outputService;
		_fileSelectorService = fileSelectorService;
		_remoteFileLoader = remoteFileLoader;
		_importProcessFactory = importProcessFactory;
		_uiScheduler = uiScheduler;
		_app = app;
		_mediaActionService = mediaActionService;
		_processHelper = processHelper;
		_mediaFactory = mediaFactory;
		_outputConfiguration = outputConfiguration;
		_transitionDescriptions = transitionDescriptions;
	}

	public IActionsMenuVM Create(IAddActionInteractor? addActionInteractor, IMediaStrategy? addMediaStategy = null, ICommand? openLiveVideoSetupCommand = null)
	{
		return new ActionsMenuVM(_downloadManager, _resourceService, _outputService, addActionInteractor, _fileSelectorService, _remoteFileLoader, _importProcessFactory, _uiScheduler, _app, _mediaActionService, _processHelper, _mediaFactory, _outputConfiguration, _transitionDescriptions, addMediaStategy, openLiveVideoSetupCommand);
	}
}
