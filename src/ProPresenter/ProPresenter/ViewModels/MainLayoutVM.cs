using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.Abstractions;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Pro.Common.Animation;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.Downloads;
using Pro.Common.FeatureFlag;
using Pro.Common.FileSystem;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.Common.MessageService;
using Pro.Common.Nullability;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Startup;
using Pro.Common.Time;
using Pro.Common.Time.Timer;
using Pro.Common.ToastNotifications;
using Pro.Common.Utility;
using Pro.CoreApplication.Workspace;
using Pro.DO.Triggering;
using Pro.Localization;
using Pro.Localization.Services;
using Pro.UI.Components;
using Pro.UI.DialogService;
using Pro.UI.Utility;
using Pro.Web.Cookies;
using Pro.Web.Services;
using ProPresenter.Controller;
using ProPresenter.Controller.NetworkAPI.Receive;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Analytics.Events.Capture;
using ProPresenter.DO.Analytics.Events.ProContent;
using ProPresenter.DO.Analytics.Events.Welcome;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Bibles;
using ProPresenter.DO.Cache;
using ProPresenter.DO.Capture;
using ProPresenter.DO.CloudOnboarding;
using ProPresenter.DO.CommonPathsWrapper;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Export;
using ProPresenter.DO.Import;
using ProPresenter.DO.Indexing;
using ProPresenter.DO.InputActionMap;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Masks;
using ProPresenter.DO.Media;
using ProPresenter.DO.Messages;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.PCO;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.ProContent;
using ProPresenter.DO.Props;
using ProPresenter.DO.Registration.Operations;
using ProPresenter.DO.Registration.State;
using ProPresenter.DO.Repositories;
using ProPresenter.DO.Resi;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Sync;
using ProPresenter.DO.TestPattern;
using ProPresenter.DO.Themes;
using ProPresenter.DO.Timer;
using ProPresenter.DO.Updates;
using ProPresenter.DO.Web;
using ProPresenter.DO.Workspaces;
using ProPresenter.Rendering;
using ProPresenter.SendData.Props;
using ProPresenter.UI;
using ProPresenter.UI.Commands;
using ProPresenter.UI.Import;
using ProPresenter.UI.MediaLibrary;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Bibles;
using ProPresenter.UI.ViewModels.Downloads;
using ProPresenter.UI.ViewModels.Editor;
using ProPresenter.UI.ViewModels.FeedbackCrash;
using ProPresenter.UI.ViewModels.KeyMapping;
using ProPresenter.UI.ViewModels.Library;
using ProPresenter.UI.ViewModels.Library.Cue;
using ProPresenter.UI.ViewModels.LooksDialog;
using ProPresenter.UI.ViewModels.Macros;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.PCO;
using ProPresenter.UI.ViewModels.Preview;
using ProPresenter.UI.ViewModels.Props;
using ProPresenter.UI.ViewModels.QuickSearch;
using ProPresenter.UI.ViewModels.Registration.Banners;
using ProPresenter.UI.ViewModels.Settings.Pages;
using ProPresenter.UI.ViewModels.Settings.Pages.Devices;
using ProPresenter.UI.ViewModels.Settings.Pages.Groups;
using ProPresenter.UI.ViewModels.Settings.Pages.Inputs;
using ProPresenter.UI.ViewModels.Settings.Pages.Integrations;
using ProPresenter.UI.ViewModels.Settings.Pages.Labels;
using ProPresenter.UI.ViewModels.TestPattern;
using ProPresenter.UI.ViewModels.TransportStatus;
using ProPresenter.UI.ViewModels.Workspaces;
using ProPresenter.ViewModels.Actions;
using ProPresenter.ViewModels.Bibles;
using ProPresenter.ViewModels.Calendar;
using ProPresenter.ViewModels.Capture;
using ProPresenter.ViewModels.Downloads;
using ProPresenter.ViewModels.Editor;
using ProPresenter.ViewModels.Export;
using ProPresenter.ViewModels.KeyMapping;
using ProPresenter.ViewModels.Library;
using ProPresenter.ViewModels.LooksDialog;
using ProPresenter.ViewModels.Macros;
using ProPresenter.ViewModels.MediaLibrary;
using ProPresenter.ViewModels.OutputConfiguration;
using ProPresenter.ViewModels.PCO;
using ProPresenter.ViewModels.Preferences;
using ProPresenter.ViewModels.Presentation;
using ProPresenter.ViewModels.ProContent;
using ProPresenter.ViewModels.Props;
using ProPresenter.ViewModels.QuickEdit;
using ProPresenter.ViewModels.QuickSearch;
using ProPresenter.ViewModels.Registration.Banners;
using ProPresenter.ViewModels.Settings.Pages.General;
using ProPresenter.ViewModels.TestPattern;
using ProPresenter.ViewModels.TextStyle;
using ProPresenter.ViewModels.TransportStatus;
using ProPresenter.ViewModels.UserFeedback;

namespace ProPresenter.ViewModels;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_downloadsVM", "_screenPreviewVM" })]
public class MainLayoutVM : LinkedNotifyPropertyChangedBase, IMainLayoutVM, INotifyPropertyChanged, IDisposable
{
	private readonly ICoreManager _manager;

	private readonly IWelcomeVM _welcomeVM;

	private readonly IPresentationVM _presentationVM;

	private readonly PlaylistTemplateCollectionVM _playlistTemplatesVM;

	private readonly LibraryVM _libraryVM;

	private readonly ExportVM _exportVM;

	private readonly ImportDocumentVM _importDocumentVM;

	private readonly AudioLibraryVM _audioLibraryVM;

	private readonly MediaLibraryVM _mediaLibraryVM;

	private readonly MigrationVM _migrationVM;

	private readonly MenuLayoutVM _menuLayoutVM;

	private readonly PresentationEditorVM _presentationEditorVM;

	private readonly TemplateEditorVM _templateEditorVM;

	private readonly IPropsEditorVM _propsEditorVM;

	private readonly MaskEditorVM _maskEditorVM;

	private readonly AttachmentManagerVM _attachmentManagerVM;

	private readonly IPCOLiveVM _pcoLiveVM;

	private readonly StageVM _stageVM;

	private readonly OutputVM _outputDisplayVM;

	private readonly IScreenConfigVM _screenConfigVM;

	private readonly PropsVM _propsVM;

	private readonly IPropGroupCollectionVM _propGroupCollectionVM;

	private readonly PrintVM _printVM;

	private readonly TimerCollectionVM _timerVM;

	private readonly BiblesVM _bibleVM;

	private readonly MessagesVM _messagesVM;

	private readonly ActionDialogVM _actionDialogVM;

	private readonly TemplateVM _templateVM;

	private readonly CalendarVM _calendarVM;

	private readonly TelestratorVM _telestratorVM;

	private readonly QuickEditVM _quickEditVM;

	private readonly CueInspectorVM _cueInspectorVM;

	private readonly TextStyleVM _textStyleVM;

	private readonly TestPatternVM _testPatternVM;

	private readonly LooksDialogVM _looksDialogVM;

	private readonly ScreenPreviewVM _screenPreviewVM;

	private readonly ToolBarVM _toolBarVM;

	private readonly TransportStatusVM _transportStatusVM;

	private readonly QuickSearchVM _quickSearchVM;

	private readonly CaptureVM _captureVM;

	private readonly MacroGroupCollectionVM _macrosGroupVM;

	private readonly UtilityViewVM _utilityViewVM;

	private readonly ClearGroupCollectionVM _clearGroupsVM;

	private readonly KeyMappingVM _keyMappingVM;

	private readonly IFeedbackVM _feedbackVM;

	private readonly ICrashReportingVM _crashReportingVM;

	private InlineType _activeInlineView = InlineType.Presentation;

	private readonly Dictionary<IImportProcess, ImportProgressWindow> _importProcessWindows = new Dictionary<IImportProcess, ImportProgressWindow>();

	private string _pendingFile = string.Empty;

	private readonly IMessageService _messageService;

	private readonly IGeneral _general;

	private readonly IImportProcessFactory _importProcessFactory;

	private readonly IDownloadsVM _downloadsVM;

	private readonly IInputsSettingsVM _inputsSettingsVM;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public IApp Settings { get; }

	public ssAPIOutput OutputController { get; }

	public ICommunicationOutput CommunicationOutput { get; }

	public UtilityViewType SelectedUtilityView
	{
		get
		{
			return Settings.SelectedUtilityView;
		}
		set
		{
			OnSelectedUtilityViewChanged(value);
		}
	}

	public IWelcomeVM WelcomeVM => _welcomeVM;

	public IPlaylistTemplateCollectionVM PlaylistTemplatesVM => _playlistTemplatesVM;

	public ILibraryVM LibraryVM => _libraryVM;

	public IExportVM ExportVM => _exportVM;

	public IImportDocumentVM ImportDocumentVM => _importDocumentVM;

	public IAudioLibraryVM AudioLibraryVM => _audioLibraryVM;

	public IMediaLibraryVM MediaLibraryVM => _mediaLibraryVM;

	public IPresentationVM PresentationVM => _presentationVM;

	public IMigrationVM MigrationVM => _migrationVM;

	public IMenuLayoutVM MenuLayoutVM => _menuLayoutVM;

	public IPresentationEditorVM PresentationEditorVM => _presentationEditorVM;

	public ITemplateEditorVM TemplateEditorVM => _templateEditorVM;

	public IPropsEditorVM PropsEditorVM => _propsEditorVM;

	public IMaskEditorVM MaskEditorVM => _maskEditorVM;

	public IBiblesVM BibleVM => _bibleVM;

	public IMessagesVM MessagesVM => _messagesVM;

	public IAttachmentManagerVM PCOAttachmentManagerVM => _attachmentManagerVM;

	public IPCOLiveVM PCOLiveVM => _pcoLiveVM;

	public ITemplateVM TemplateVM => _templateVM;

	public ICalendarVM CalendarVM => _calendarVM;

	public IStageVM StageVM => _stageVM;

	public IOutputVM OutputVM => _outputDisplayVM;

	public ITimerCollectionVM TimerVM => _timerVM;

	public IScreenConfigVM ScreenConfigVM => _screenConfigVM;

	public IPropsVM PropsVM => _propsVM;

	public IPropGroupCollectionVM PropGroupCollectionVM => _propGroupCollectionVM;

	public IPrintVM PrintVM => _printVM;

	public IFeedbackVM FeedbackVM => _feedbackVM;

	public ICrashReportingVM CrashReportingVM => _crashReportingVM;

	public IQuickEditVM QuickEditVM => _quickEditVM;

	public ICueInspectorVM CueInspectorVM => _cueInspectorVM;

	public ITelestratorVM TelestratorVM => _telestratorVM;

	public ITextStyleVM TextStyleVM => _textStyleVM;

	public ITestPatternVM TestPatternVM => _testPatternVM;

	public ILooksDialogVM AudienceLookVM => _looksDialogVM;

	public IScreenPreviewVM ScreenPreviewVM => _screenPreviewVM;

	public IToolBarVM ToolBarVM => _toolBarVM;

	public ITransportStatusVM TransportStatusVM => _transportStatusVM;

	public IQuickSearchVM QuickSearchVM => _quickSearchVM;

	public ICaptureVM CaptureVM => _captureVM;

	public IMacroGroupCollectionVM MacroGroupsVM => _macrosGroupVM;

	public IUtilityViewVM UtilityViewVM => _utilityViewVM;

	public IClearGroupCollectionVM ClearGroupsVM => _clearGroupsVM;

	public IKeyMappingVM KeyMappingVM => _keyMappingVM;

	public IDownloadsVM DownloadsVM => _downloadsVM;

	public IBannersVM BannersVM { get; }

	public InlineType ActiveInlineView
	{
		get
		{
			return _activeInlineView;
		}
		set
		{
			SetValue("ActiveInlineView", ref _activeInlineView, value, delegate(InlineType o, InlineType n)
			{
				_quickEditVM.HideQuickEditWindow();
				OnInlineViewChanged(n);
			});
		}
	}

	public bool ShowFeedbackButton => false;

	public IImmutableObservableCollection<IPropCue> Props => DataVault.PropCueCollection;

	public IEnumerable<SlideCue> StageLayouts => DataVault.StagePresentation.ArrangementGroups.SelectMany((CueGroup g) => g.Cues).ToArray();

	public MessageCollection Messages => DataVault.Messages;

	public TimerCollection Timers => DataVault.TimerDocument.Timers;

	public ICommand ShutdownCommand => new RelayCommand(OnShutdownCommand);

	public ICommand<ShowSource> ShowEditorCommand => new RelayCommand<ShowSource>(delegate(ShowSource s)
	{
		OnShowEditorCommand(s, (_manager.ActivePlaylistItem as IDocumentCue)?.DocumentAction?.Presentation as CustomPresentation, EditMode.Presentation);
	}, (ShowSource s) => CanEdit());

	public ICommand<ShowSource> ShowReflowEditorCommand => new RelayCommand<ShowSource>(OnShowReflowEditorCommand, (ShowSource s) => CanEdit());

	public ICommand ToggleEditorCommand => new RelayCommand(OnToggleEditorViewCommand, CanEdit);

	public ICommand ToggleReflowEditorCommand => new RelayCommand(OnToggleReflowEditorViewCommand, CanEdit);

	public ICommand<CustomPresentation?> EditPresentationCommand => new RelayCommand<CustomPresentation>(delegate(CustomPresentation? p)
	{
		OnShowEditorCommand(ShowSource.ContextMenu, p, EditMode.Presentation);
	});

	public ICommand<EditStageLayoutCommandParameter> EditStagePresentationCommand => new RelayCommand<EditStageLayoutCommandParameter>(OnEditStagePresentationCommand);

	public ICommand<PopupType> SetSelectedViewCommand => new RelayCommand<PopupType>(OnSetSelectedViewCommand);

	public ICommand ShowRegistrationCommand => new RelayCommand(delegate
	{
		ActivateRegistrationUI();
	});

	public ICommand TriggerNextSlideCommand => new RelayCommand(delegate
	{
		TriggerNextSlide(suppress: false);
	}, CanTrigger);

	public ICommand TriggerNextSlideWithSuppressionCommand => new RelayCommand(delegate
	{
		TriggerNextSlide(suppress: true);
	}, CanTrigger);

	public ICommand TriggerPreviousSlideCommand => new RelayCommand(TriggerPreviousSlide, CanTrigger);

	public ICommand AddSlideCommand => new RelayCommand(OnAddSlideCommand, CanAddSlide);

	public ICommand<ShowSource> ShowMainViewCommand => new RelayCommand<ShowSource>(OnShowMainViewCommand);

	public ICommand CheckForUpdatesCommand { get; }

	public ICommand<ShowSource> EditCopyrightTemplateCommand
	{
		get
		{
			return new RelayCommand<ShowSource>(delegate(ShowSource source)
			{
				EditTemplates(DataVault.CCLIPresentation, EditMode.CCLITemplate);
				MainViewCopyrightEditorEvent.Publish(Convert(source));
			});
			static MainViewSource Convert(ShowSource source)
			{
				return source switch
				{
					ShowSource.Toolbar => MainViewSource.Toolbar, 
					ShowSource.Preference => MainViewSource.Preference, 
					_ => MainViewSource.ApplicationMenu, 
				};
			}
		}
	}

	public bool ShowHouseOfWorshipIntegration => _general.ShowHoW;

	public event Action<PopupType>? SetSelectedView;

	public event Action<IMainLayoutVM.CodeInfo?>? ShowRegistration;

	public event Action<SettingsPage>? ShowSettingsPage;

	private void OnEditStagePresentationCommand(EditStageLayoutCommandParameter parameters)
	{
		EditPresentation(DataVault.StagePresentation, EditMode.Stage, parameters.Slide);
		switch (parameters.Source)
		{
		case ShowSource.Toolbar:
			MainViewStageEditorEvent.Publish(MainViewSource.Toolbar);
			break;
		case ShowSource.ApplicationMenu:
			MainViewStageEditorEvent.Publish(MainViewSource.ApplicationMenu);
			break;
		case ShowSource.LowerRight:
			MainViewStageEditorEvent.Publish(MainViewSource.LowerRight);
			break;
		case ShowSource.ContextMenu:
		case ShowSource.LibraryContextMenu:
			break;
		}
	}

	public MainLayoutVM(ICoreManager manager, ssAPIOutput outputController, ICommunicationOutput communicationOutput, IRegistrationOperationFactory registrationOperationFactory, IRegistrationStateProvider registrationStateProvider, IThemeAnalyiticEvents themeAnalytics, IMessageService messageService, IEditorService editorService, ICookieManagerService cookieManagerService, IProPresenterResourceService resourceService, IThemeService themeService, IApp app, IGeneral general, IProContentProvider proContentProvider, IProContentDownloader proContentDownloader, IUriCacheService<NullableBitmapSource> thumbnailCacheService, ILocalization localizationService, IMediaImportDownloadDialogService mediaImportDownloadDialogService, IProContentAnalyticEventsPublisher proContentAnalyticEvents, ITimerFactory timerFactory, IUriCacheService<IReadOnlyList<IAnimationFrame>> previewCacheService, IDownloadManager downloadManager, IFileSelectorService fileSelectorService, IOutputService outputService, IMediaActionService mediaActionService, IMediaCueThumbnailOverlayVMFactory overlayVMFactory, IPlaybackMarkerAnalyticsEvents playbackMarkerAnalyticsEvents, IDownloadsDialogService downloadsDialogService, IDownloadVMsFactory downloadVMFactory, IImportProcessFactory importProcessFactory, IUiScheduler uiScheduler, ICapturePrompt capturePrompt, IEncoderValidator encoderValidator, IThemeRepo themeRepo, ICaptureAnalyticEventsPublisher captureAnalyticEventsPublisher, ICalendarPrompt calendarPrompt, IBibleProvider bibleProvider, ICaptureController captureController, IResiController resiController, ICrashRecovery captureCrashRecovery, IResiAuthorizationInteractor resiAuthorizationInteractor, IPhysicalDeviceProvider physicalDeviceProvider, ITestPatternService testPatternService, IFeedbackVM feedbackVM, ICrashReportingVM crashReportingVM, IFileSelectorService fileSelector, IWelcomeAnalyticEventsPublisher welcomeAnalytics, IHyperlinkService hyperlinkService, IWebSourceProvider webSourceProvider, IAttachmentUploadVM attachmentUploadVM, ITriggeringFactory triggeringFactory, IPresentationFactory presentationFactory, IIndexingService indexingService, IFileFilterProvider fileFilterProvider, IPlanningCenterSettingsVM planningCenterSettingsVM, IMultiTracksSettingsVM multiTracksSettingsVM, ISongSelectSettingsVM songSelectSettingsVM, IFlagService flagService, ITimelineManager timelineManager, IMacroPrompt macroPrompt, IImport import, IAppUpdateService appUpdateService, IUiDispatcher uiDispatcher, ISlidePreviewService slidePreviewService, IPropAutoClearService propAutoClearService, IRegistrationWebResourceService registrationWebResourceService, IInputsSettingsVM inputsSettingsVM, IServerStateHandler serverStateHandler, ITimecodeService timecodeService, IOutputRepository outputRepo, ITimecodeAnalyticsEvents timecodeAnalyticEvents, IProcessHelper processHelper, IFileSystem fileSystem, IActionsMenuVMFactory actionsMenuVMFactory, IApiService apiService, IOutputPreviewVMFactory previewControlVMFactory, IAsyncExecutor asyncExecutor, IRTMPPrompt rtmpPrompt, INetwork network, ILibraryService libraryService, ILayout layout, IPlaylistTemplatesService playlistTemplatesService, ILegacyPurchaseBiblesDialogService legacyPurchaseBiblesDialogService, IMediaProvider mediaProvider, IExportProcessFactory exportProcessFactory, IInputActions inputActions, IMediaImportService mediaImportService, IPropPrompts propPrompts, IProPresenterDOFactoryProvider factoryProvider, IChangeWorkspaceHandler supportFolderHandler, IDebouncerFactory debouncerFactory, IProPresenterCueFactory cueFactory, ILogger logger, IMessageDialogService messageDialogService, IMatchSongsInteractor matchSongsInteractor, ICurrentTime currentTime, ICloudOnboardingService cloudOnboardingService, IAfterStartupCompleteQueue afterStartupCompleteQueue, IWorkspaceService workspaceService, ICloudWorkspaceService cloudWorkspaceService, IWorkspaceDocumentOrchestrator workspaceDocumentOrchestrator, ICommonPathsWrapper commonPathsWrapper, IManageWorkspacesWindowProvider manageWorkspacesWindowProvider, IToastNotificationService toastNotificationService, IMaskCollection masks, IOutputConfiguration outputConfig, IWorkspaceCollectionVM workspaceCollectionVM, IProPresenterCueVMFactory cueVMFactory, IInternetAccess internetAccess)
	{
		_manager = manager;
		_messageService = messageService;
		OutputController = outputController;
		CommunicationOutput = communicationOutput;
		Settings = app;
		_general = general;
		_importProcessFactory = importProcessFactory;
		_inputsSettingsVM = inputsSettingsVM;
		CheckForUpdatesCommand = new RelayCommand(appUpdateService.InitiateCheckForUpgrades);
		IMediaFactory mediaFactory = factoryProvider.MediaFactory;
		Log.Info("Building VMs...");
		Log.Info("Building the playlist templates VM...");
		_playlistTemplatesVM = new PlaylistTemplateCollectionVM(resourceService, cueFactory, playlistTemplatesService, logger, factoryProvider.EntityFactory);
		Log.Info("Building the library VM...");
		PowerPointImportOptionsDialog powerPointImportOptionsDialog = new PowerPointImportOptionsDialog(messageDialogService);
		_libraryVM = new LibraryVM(manager, _playlistTemplatesVM, messageService, proContentDownloader, themeService, app, libraryService, triggeringFactory, presentationFactory, resourceService, timelineManager, new LibraryPrompt(), importProcessFactory, factoryProvider.EntityFactory, fileSelectorService, cueFactory, logger, messageDialogService, powerPointImportOptionsDialog, cueVMFactory, general, uiDispatcher, internetAccess, localizationService, initializeImportPrompt: true);
		_libraryVM.PresentationEdited += OnShowEditorCommand;
		Log.Info("Building the media library VM...");
		ProContentVM proContentVM = new ProContentVM(proContentProvider, new ProContentVMsFactory(thumbnailCacheService, proContentProvider, proContentDownloader, localizationService, previewCacheService, timerFactory), localizationService, proContentAnalyticEvents, timerFactory, app);
		_mediaLibraryVM = new MediaLibraryVM(manager, outputController, proContentDownloader, proContentVM, _messageService, app, fileSelectorService, resourceService.VisualPlaylists, outputRepo, mediaActionService, overlayVMFactory, triggeringFactory, DataVault.Transitions, factoryProvider, messageDialogService, uiDispatcher);
		Log.Info("Building the presentation VM...");
		PresentationActionRepositoryProvider provider = new PresentationActionRepositoryProvider(factoryProvider, outputRepo.AvailableTransitions);
		ActionDropOperation dropOperation = new ActionDropOperation(new MediaActionHandler(new PresentationMediaActionRepositoryProvider(factoryProvider, outputRepo.AvailableTransitions), new PresentationActionRepositoryGroupStrategy(DataVault.GroupLabels)), new PlaylistActionHandler(provider), new ActionHandler(provider), app, importProcessFactory, mediaFactory, outputRepo.AvailableTransitions);
		_presentationVM = new PresentationVM(manager, outputController, _libraryVM, _mediaLibraryVM, bibleProvider, delegate(string searchText)
		{
			_quickSearchVM.SearchText = searchText;
		}, messageService, proContentDownloader, app, triggeringFactory, uiDispatcher, dropOperation, DataVault.Transitions, actionsMenuVMFactory, resourceService, layout, inputActions, importProcessFactory, factoryProvider, supportFolderHandler, outputRepo.AvailableTransitions, flagService);
		Log.Info("Building the action dialog VM...");
		_actionDialogVM = new ActionDialogVM(new ActionDialogContentProvider(resourceService, outputService, propPrompts, GetActionDialogService()));
		Log.Info("Building the template VM...");
		_templateVM = new TemplateVM(resourceService.Themes, new SlideSelectorStrategy(this), themeService, new ThemePrompt(resourceService), _messageService, proContentProvider, exportProcessFactory, factoryProvider, flagService);
		Log.Info("Building the cue inspector VM...");
		_cueInspectorVM = new CueInspectorVM(outputController, overlayVMFactory, manager, playbackMarkerAnalyticsEvents, importProcessFactory, app, manager, actionsMenuVMFactory, previewControlVMFactory, mediaFactory, factoryProvider.EntityFactory, uiDispatcher, debouncerFactory, outputRepo.AvailableTransitions);
		_cueInspectorVM.PlaybackMarkersVM.ShowActionDialog += delegate(FrameworkElement? p, IAction? a, IActionRepository? s, IEnumerable<IActionRepository> c)
		{
			_actionDialogVM.ShowActionDialog(p, a, s, c, PlacementMode.Left, HorizontalAlignment.Left, VerticalAlignment.Center);
			_menuLayoutVM.ActiveUndoStack = a?.UndoStack;
		};
		_cueInspectorVM.PlaybackMarkersVM.UpdateDialogPlacement += _actionDialogVM.UpdatePlacementTarget;
		Log.Info("Building the print VM...");
		_printVM = new PrintVM(app, factoryProvider.ErrorReporter);
		Log.Info("Building the audio library VM...");
		_audioLibraryVM = new AudioLibraryVM(manager, app, triggeringFactory, resourceService, uiDispatcher);
		Log.Info("Building the timer collection VM...");
		_timerVM = new TimerCollectionVM(manager, app, triggeringFactory, resourceService.Timers);
		Log.Info("Building the bible VM...");
		_bibleVM = new BiblesVM(manager, outputController, registrationOperationFactory, bibleProvider, themeService, app, triggeringFactory, presentationFactory, registrationStateProvider, outputService, resourceService, registrationWebResourceService, hyperlinkService, legacyPurchaseBiblesDialogService);
		Log.Info("Building the import document VM...");
		_importDocumentVM = new ImportDocumentVM(_presentationVM, app, inputActions);
		Log.Info("Building the import multitracks dialog VM...");
		MultiTracksImportDialogVM importMultiTracksVM = new MultiTracksImportDialogVM(_presentationVM, app);
		Log.Info("Building the export VM...");
		_exportVM = new ExportVM(new ExportImagesInteractor(() => _libraryVM.SelectedActiveCues, exportProcessFactory), app);
		Log.Info("Building the attachment manager VM...");
		_attachmentManagerVM = new AttachmentManagerVM(_manager.PCOConsumer);
		Log.Info("Building the pco live VM...");
		_pcoLiveVM = new PCOLiveVM(_manager, DataVault.PCOOrganization, _libraryVM.AddPCOPlaylist, _libraryVM, _attachmentManagerVM, delegate(string searchText)
		{
			_quickSearchVM.SearchText = searchText;
		}, manager.SongSelectConsumer, cookieManagerService, app, resourceService.LibraryCollection, inputActions, importProcessFactory, mediaFactory, matchSongsInteractor);
		Log.Info("Building the presentation editor VM...");
		_presentationEditorVM = new PresentationEditorVM(editorService, messageService, overlayVMFactory, app, timerFactory, import, resourceService, processHelper, fileSystem, Advanced.Settings, flagService, General.Settings, importProcessFactory, factoryProvider, outputRepo.AvailableTransitions, messageDialogService, currentTime);
		Log.Info("Building the template editor VM...");
		_templateEditorVM = new TemplateEditorVM(editorService, themeRepo, app, timerFactory, import, resourceService, processHelper, fileSystem, Advanced.Settings, General.Settings, importProcessFactory, factoryProvider, outputRepo.AvailableTransitions, messageDialogService, flagService, currentTime);
		Log.Info("Building the props editor VM...");
		_propsEditorVM = new PropsEditorVM(DataVault.PropSource, editorService, app, timerFactory, import, resourceService, processHelper, fileSystem, Advanced.Settings, flagService, General.Settings, importProcessFactory, factoryProvider, outputRepo.AvailableTransitions, messageDialogService, currentTime);
		Log.Info("Building the mask editor VM...");
		_maskEditorVM = new MaskEditorVM(editorService, app, timerFactory, import, resourceService, processHelper, fileSystem, Advanced.Settings, flagService, General.Settings, importProcessFactory, factoryProvider, outputRepo.AvailableTransitions, messageDialogService, currentTime, masks);
		Log.Info("Building the output display VM...");
		_outputDisplayVM = new OutputVM(manager, app, triggeringFactory);
		Log.Info("Building the migration VM...");
		_migrationVM = new MigrationVM(_manager, mediaImportDownloadDialogService, app, network, importProcessFactory, powerPointImportOptionsDialog);
		Log.Info("Building the menu layout VM...");
		_menuLayoutVM = new MenuLayoutVM(manager, captureController, ActiveInlineView, registrationStateProvider, app, attachmentUploadVM, triggeringFactory, inputActions);
		Log.Info("Building the capture VM...");
		_captureVM = new CaptureVM(captureController, captureController, resiAuthorizationInteractor, capturePrompt, encoderValidator, captureAnalyticEventsPublisher, rtmpPrompt);
		new ResiWebStartVM(resiController, captureController, captureController, captureCrashRecovery);
		Log.Info("Building the screen config VM...");
		RemoveScreenOperation removeScreenOperation = new RemoveScreenOperation(new RemoveRecordingScreenValidator(captureController));
		_screenConfigVM = new ScreenConfigVM(_manager, outputController, removeScreenOperation, outputService, hyperlinkService, apiService);
		Log.Info("Building the welcome VM...");
		_welcomeVM = new WelcomeVM(manager, app, resourceService, general, welcomeAnalytics, hyperlinkService, webSourceProvider, _screenConfigVM, timerFactory, network, importProcessFactory, mediaImportService, mediaFactory, outputRepo, flagService, localizationService, cloudOnboardingService, cloudWorkspaceService, workspaceService, workspaceDocumentOrchestrator, registrationWebResourceService, afterStartupCompleteQueue, uiScheduler, manageWorkspacesWindowProvider, supportFolderHandler, logger, workspaceCollectionVM);
		Log.Info("Building the screen preview VM...");
		_screenPreviewVM = new ScreenPreviewVM(_manager, _captureVM, app, previewControlVMFactory, resourceService, outputRepo);
		Log.Info("Building toolbar VM...");
		_toolBarVM = new ToolBarVM(manager, _captureVM, triggeringFactory);
		Log.Info("Building the audience look VM...");
		_looksDialogVM = new LooksDialogVM(outputController, triggeringFactory, outputService, themeService.Themes, masks, outputConfig.AudienceArrangementScreens);
		Log.Info("Building the stage VM...");
		_stageVM = new StageVM(manager, resourceService.StagePresentation, app, new DeviceSelectorVM(_manager, physicalDeviceProvider, timerFactory), triggeringFactory, inputActions);
		Log.Info("Building the props VM...");
		_propsVM = new PropsVM(resourceService, manager, outputController, app, triggeringFactory, mediaProvider, factoryProvider, uiDispatcher);
		_propGroupCollectionVM = new PropGroupCollectionVM(manager, outputController, app, new PropGroupCollectionFactoryVM(resourceService, slidePreviewService, new PropPrompts(), triggeringFactory, propAutoClearService, timerFactory, asyncExecutor, mediaProvider, factoryProvider, uiDispatcher), resourceService);
		Log.Info("Building the event calendar VM...");
		_calendarVM = new CalendarVM(resourceService, captureController, calendarPrompt);
		Log.Info("Building the telestrator VM...");
		_telestratorVM = new TelestratorVM(manager, triggeringFactory);
		Log.Info("Building the macro collection VM...");
		_macrosGroupVM = new MacroGroupCollectionVM(manager, resourceService, fileSelectorService, overlayVMFactory, app, triggeringFactory, macroPrompt, manager, new ActionValidator(), DataVault.Calendar, actionsMenuVMFactory, importProcessFactory, factoryProvider, outputRepo.AvailableTransitions, uiDispatcher);
		_macrosGroupVM.ShowActionDialog += delegate(FrameworkElement? placement, IAction? action, IActionRepository? actionStore, IEnumerable<IActionRepository> otherActionStore)
		{
			PlacementMode placementMode = ((_macrosGroupVM.ListOrGrid == PanelViewType.Thumbnail) ? PlacementMode.Bottom : PlacementMode.Left);
			HorizontalAlignment horizontalAlignment = ((_macrosGroupVM.ListOrGrid == PanelViewType.Thumbnail) ? HorizontalAlignment.Center : HorizontalAlignment.Left);
			_actionDialogVM.ShowActionDialog(placement, action, actionStore, otherActionStore, placementMode, horizontalAlignment, VerticalAlignment.Center);
			_menuLayoutVM.ActiveUndoStack = action?.UndoStack;
		};
		_macrosGroupVM.UpdateDialogPlacement += _actionDialogVM.UpdatePlacementTarget;
		_macrosGroupVM.StackChanged += delegate(UndoStack u)
		{
			_menuLayoutVM.ActiveUndoStack = u;
		};
		Log.Info("Building the utility view VM...");
		_utilityViewVM = new UtilityViewVM(app);
		Log.Info("Building the clear groups VM...");
		_clearGroupsVM = new ClearGroupCollectionVM();
		Log.Info("Building the hotkey mapping VM...");
		KeyGesturePrompt prompt = new KeyGesturePrompt();
		_keyMappingVM = new KeyMappingVM(prompt, new InputActionGroupVMFactory(prompt), inputActions);
		_templateVM.EditTheme += delegate(Theme? t)
		{
			MainViewThemeEditorEvent.Publish((t != null) ? MainViewSource.ThemeContextMenu : MainViewSource.Toolbar);
			EditTemplates(t, EditMode.Template);
		};
		_propsVM.EditProps += EditProps;
		_propGroupCollectionVM.EditProps += EditProps;
		_looksDialogVM.EditMasks += EditMasks;
		_feedbackVM = feedbackVM;
		_crashReportingVM = crashReportingVM;
		Log.Info("Building the quick edit VM...");
		_quickEditVM = new QuickEditVM();
		Log.Info("Building the messages VM...");
		_messagesVM = new MessagesVM(manager, outputController, app, resourceService, triggeringFactory, serverStateHandler, network, toastNotificationService, themeService.Themes);
		Log.Info("Building the text style VM...");
		_textStyleVM = new TextStyleVM(new TextStyleFacade(this, themeAnalytics));
		Log.Info("Building the test pattern VM...");
		_testPatternVM = new TestPatternVM(testPatternService, new TestPatternVMFactory(testPatternService, outputService, fileSelector, outputService.OutputConfiguration.DigitalAudioSettings, fileFilterProvider));
		Log.Info("Building the transport status VM...");
		_transportStatusVM = new TransportStatusVM(_manager, playbackMarkerAnalyticsEvents, actionsMenuVMFactory, inputActions, factoryProvider.EntityFactory);
		_transportStatusVM.PresentationStatusVM.ShowActionDialog += delegate(FrameworkElement? p, IAction? a, IActionRepository? s, IEnumerable<IActionRepository> c)
		{
			_actionDialogVM.ShowActionDialog(p, a, s, c, PlacementMode.Left, HorizontalAlignment.Left, VerticalAlignment.Center);
		};
		_transportStatusVM.AnnouncementStatusVM.ShowActionDialog += delegate(FrameworkElement? p, IAction? a, IActionRepository? s, IEnumerable<IActionRepository> c)
		{
			_actionDialogVM.ShowActionDialog(p, a, s, c, PlacementMode.Left, HorizontalAlignment.Left, VerticalAlignment.Center);
		};
		_transportStatusVM.AudioStatusVM.ShowActionDialog += delegate(FrameworkElement? p, IAction? a, IActionRepository? s, IEnumerable<IActionRepository> c)
		{
			_actionDialogVM.ShowActionDialog(p, a, s, c, PlacementMode.Left, HorizontalAlignment.Left, VerticalAlignment.Center);
		};
		Log.Info("Building the quick search VM...");
		LibrarySearchService service = new LibrarySearchService(manager, _libraryVM, _presentationVM, _pcoLiveVM, indexingService);
		SongSelectSearchService songSelectSearchService = new SongSelectSearchService(_presentationVM, _pcoLiveVM, manager.SongSelectConsumer, cookieManagerService, importProcessFactory);
		MultiTracksSearchService multiTracksSearchService = new MultiTracksSearchService(manager.MultiTracksConsumer, _presentationVM, _pcoLiveVM, importMultiTracksVM, cookieManagerService, app, importProcessFactory);
		_quickSearchVM = new QuickSearchVM(app, indexingService, new LibrarySearchPageVM(service, multiTracksSearchService, app, localizationService, inputActions.ProCommon, inputActions.CommonInputActions), new SongSelectSearchPageVM(songSelectSearchService, inputActions.CommonInputActions, inputActions, general), new MultiTracksSearchPageVM(multiTracksSearchService, inputActions.CommonInputActions, inputActions, general));
		Log.Info("Building the downloads VM...");
		_downloadsVM = new DownloadsVM(downloadManager, downloadVMFactory, downloadsDialogService, uiScheduler);
		Log.Info("Building the banners VM...");
		BannersVM = new BannersVM(registrationStateProvider, localizationService, delegate
		{
			ActivateRegistrationUI();
		}, appUpdateService);
		Log.Info("Done building VMs");
		Log.Info("Hooking up VMs...");
		PresentationHeaderVM.Initialize(outputController);
		HookupLinkActions();
		HookupUndoStackChangedEvents();
		HookupMessageServiceSubscription();
		captureCrashRecovery.StartCapture += captureController.StartScreenCapture;
		if (_libraryVM.ActivePlaylist != null)
		{
			_menuLayoutVM.ActiveUndoStack = _libraryVM.Playlists.UndoStack;
		}
		else if (_libraryVM.ActiveCue is IDocumentCueVM documentCueVM && documentCueVM.Document.DocumentAction?.Presentation != null)
		{
			_menuLayoutVM.ActiveUndoStack = documentCueVM.Document.DocumentAction.Presentation.UndoStack;
		}
		ImportPrompt.SetImportStarted(OnImportStarted);
		planningCenterSettingsVM.ToggleAuthorization += _pcoLiveVM.ToggleAuthorization;
		multiTracksSettingsVM.ToggleAuthorization += multiTracksSearchService.ToggleAuthorization;
		songSelectSettingsVM.ToggleAuthorization += songSelectSearchService.ToggleAuthorization;
		_presentationEditorVM.ShapeInspectorVM.OpenLiveVideoSetup += OpenLiveVideoSetup;
		_presentationEditorVM.SlideInspectorVM.OpenLiveVideoSetup += OpenLiveVideoSetup;
		_cueInspectorVM.InfoVM.OpenVideoInputSetup += OpenLiveVideoSetup;
		_mediaLibraryVM.OpenLiveVideoSetup += OpenLiveVideoSetup;
		DataVault.StagePresentation.ArrangementGroups.DataModifed += delegate
		{
			OnPropertyChanged("StageLayouts");
		};
		_bibleVM.ShowRegistration += delegate
		{
			ActivateRegistrationUI();
		};
		_presentationEditorVM.PropertyChanged += base.RaiseLinkedValues;
		_calendarVM.CalendarVisibleChanged += delegate(bool v)
		{
			_menuLayoutVM.IsCalendarVisible = v;
		};
		_presentationVM.ShowActionDialog += delegate(FrameworkElement? p, IAction? a, IActionRepository? s, IEnumerable<IActionRepository>? c)
		{
			_actionDialogVM.ShowActionDialog(p, a, s, c ?? Enumerable.Empty<IActionRepository>());
			_menuLayoutVM.ActiveUndoStack = a?.UndoStack;
		};
		_presentationVM.UpdateDialogPlacementTarget += _actionDialogVM.UpdatePlacementTarget;
		_presentationVM.CustomSlideMenuVM.TemplateVM = _templateVM;
		_presentationVM.CustomSlideMenuVM.QuickEditVM = _quickEditVM;
		_presentationVM.CustomSlideMenuVM.EditCue += delegate(ArrangedCue? cue, IPresentation? document)
		{
			EditPresentationCommand.Invoke<CustomPresentation>(document as CustomPresentation);
		};
		_captureVM.ResiVM.ShowResiPreferences += delegate
		{
			OnShowSettingsWindow(SettingsPage.Resi);
		};
		Settings.PropertyChanged += base.RaiseLinkedValues;
		Log.Info("Done hooking up VMs");
		StartupSongSelectEvent.Publish(_manager.SongSelectConsumer.IsAuthorized);
		StartupMultiTracksEvent.Publish(app.MultiTracksChartProStatus, app.MultiTracksSlideProStatus);
		StartupNetworkLinkEvent.Publish(network.EnableNetwork && network.EnableLink, (uint)network.LinkGroup.Count);
		MediaLibraryVM.ProContentVM.PropertyChanged += ProContentVM_PropertyChanged;
	}

	public void CommitWriteQueue()
	{
		_libraryVM.Libraries.CommitAllInWriteQueue();
	}

	public void SetupSettingsStackChanged(IGeneralSettingsVM generalSettings, IGroupsSettingsVM groupsSettings, ILabelsSettingsVM labelsSettings, IDevicesSettingsVM devicesSettings, IInputsSettingsVM inputsSettings)
	{
		generalSettings.CopyrightSettingsVM.EditCopyrightTemplate += delegate(ICCLIPresentation t)
		{
			EditTemplates((Theme)t, EditMode.CCLITemplate);
		};
		generalSettings.CopyrightSettingsVM.StackChanged += delegate(UndoStack u)
		{
			_menuLayoutVM.ActiveUndoStack = u;
		};
		groupsSettings.StackChanged += delegate(UndoStack u)
		{
			_menuLayoutVM.ActiveUndoStack = u;
		};
		labelsSettings.StackChanged += delegate(UndoStack u)
		{
			_menuLayoutVM.ActiveUndoStack = u;
		};
		devicesSettings.StackChanged += delegate(UndoStack u)
		{
			_menuLayoutVM.ActiveUndoStack = u;
		};
		inputsSettings.StackChanged += delegate(UndoStack u)
		{
			_menuLayoutVM.ActiveUndoStack = u;
		};
	}

	public void ImportPendingFile(string file = "")
	{
		Window mainWindow = Application.Current.MainWindow;
		if (mainWindow != null && mainWindow.IsLoaded)
		{
			string text = (string.IsNullOrWhiteSpace(file) ? _pendingFile : file);
			if (!string.IsNullOrWhiteSpace(text))
			{
				_importProcessFactory.Create(new global::_003C_003Ez__ReadOnlySingleElementList<string>(text)).StartImport();
			}
			_pendingFile = string.Empty;
		}
		else
		{
			_pendingFile = file;
		}
	}

	public void ActivateProContent()
	{
		_mediaLibraryVM.ActivateProContent();
	}

	public void ActivateMediaBin()
	{
		_mediaLibraryVM.ActivateMediaBin();
	}

	public IActionDialogService GetActionDialogService()
	{
		return new ActionDialogService(CommunicationOutput.Devices, OpenLiveVideoSetup, ActionDialogService_ShowDialog, delegate(FrameworkElement e)
		{
			_actionDialogVM?.UpdatePlacementTarget(e);
		});
	}

	private void ActionDialogService_ShowDialog(ActionDialogParameter param)
	{
		_actionDialogVM.ShowActionDialog(param.Placement, param.Action, param.Target, param.OtherTarget, param.PlacementMode, param.HorizontalAlignment, param.VerticalAlignment);
		_menuLayoutVM.ActiveUndoStack = param.Action?.UndoStack;
	}

	private bool CanTrigger()
	{
		if (!ActiveInlineView.IsAnyOf(InlineType.Bible, InlineType.Presentation))
		{
			return false;
		}
		if ((_manager.ActivePlaylistItem as IDocumentCue)?.DocumentAction?.Presentation is CustomPresentation { IsAvailable: false })
		{
			return false;
		}
		return true;
	}

	private bool CanEdit()
	{
		if ((_manager.ActivePlaylistItem as IDocumentCue)?.DocumentAction?.Presentation is CustomPresentation customPresentation)
		{
			return customPresentation.IsAvailable;
		}
		return false;
	}

	private void OnShowSettingsWindow(SettingsPage page)
	{
		this.ShowSettingsPage?.Invoke(page);
	}

	private void HookupMessageServiceSubscription()
	{
		_messageService.SubscribeToMessage<SyncMessage>(delegate(IMessage message)
		{
			if (message is SyncMessage { FileSyncResult: { Status: IOResult.Unauthorized } } syncMessage)
			{
				MessageDialogService.ShowAlert(LocalizedStrings.Get("GLOBAL_UNAUTHORIZED_FILE_ACCESS_windows_dialog", new object[1] { syncMessage.FileSyncResult.FilePath }));
			}
		});
		_messageService.SubscribeToMessage<EditThemeTemplateMessage>(delegate(IMessage message)
		{
			if (message is EditThemeTemplateMessage editThemeTemplateMessage)
			{
				EditTemplates(editThemeTemplateMessage.TargetTheme, editThemeTemplateMessage.Mode);
			}
		});
	}

	private void HookupLinkActions()
	{
		LinkProperties("SelectedUtilityView", "SelectedUtilityView");
	}

	private void HookupUndoStackChangedEvents()
	{
		_presentationVM.StackChanged += changeStack;
		_libraryVM.StackChanged += changeStack;
		_audioLibraryVM.StackChanged += changeStack;
		_mediaLibraryVM.StackChanged += changeStack;
		_screenConfigVM.StackChanged += changeStack;
		_templateEditorVM.StackChanged += changeStack;
		_propsEditorVM.StackChanged += changeStack;
		_messagesVM.StackChanged += changeStack;
		_timerVM.StackChanged += changeStack;
		_clearGroupsVM.StackChanged += changeStack;
		_transportStatusVM.PresentationStatusVM.StackChanged += changeStack;
		_transportStatusVM.AnnouncementStatusVM.StackChanged += changeStack;
		_transportStatusVM.AudioStatusVM.StackChanged += changeStack;
		_captureVM.StackChanged += changeStack;
		_propGroupCollectionVM.StackChanged += changeStack;
		void changeStack(UndoStack? stack)
		{
			_menuLayoutVM.ActiveUndoStack = stack;
		}
	}

	private void OnImportStarted(ImportProcess process)
	{
		if (process.ShowProgressDialog)
		{
			ImportProgressWindow importProgressWindow = new ImportProgressWindow
			{
				Owner = Application.Current.MainWindow,
				WindowStartupLocation = WindowStartupLocation.CenterOwner,
				ImportProcess = process
			};
			if (!_importProcessWindows.ContainsKey(process))
			{
				_importProcessWindows.Add(process, importProgressWindow);
			}
			process.ImportComplete += Process_ImportComplete;
			importProgressWindow.ShowDialog();
		}
	}

	private void Process_ImportComplete(IImportProcess process)
	{
		if (_importProcessWindows.TryGetValue(process, out ImportProgressWindow value))
		{
			_importProcessWindows.Remove(process);
			value.Close();
		}
		process.ImportComplete -= Process_ImportComplete;
	}

	private void EditPresentation(CustomPresentation presentation, EditMode editMode, CustomSlide? selectedSlide = null)
	{
		if (ActiveInlineView != InlineType.SlideEditor || _presentationEditorVM.EditMode != editMode)
		{
			_presentationEditorVM.Presentation = null;
			_presentationEditorVM.EditMode = editMode;
			_presentationEditorVM.Presentation = presentation;
			CustomSlide selectedEditorSlide = GetSelectedEditorSlide(editMode, selectedSlide);
			if (selectedEditorSlide != null)
			{
				_presentationEditorVM.SelectSlide(selectedEditorSlide);
			}
			else if (_presentationEditorVM.SelectedSlides.Count == 0)
			{
				_presentationEditorVM.SelectSlide(_presentationEditorVM.Slides.FirstOrDefault());
			}
			ActiveInlineView = editMode switch
			{
				EditMode.Stage => InlineType.StageEditor, 
				EditMode.Prop => InlineType.PropsEditor, 
				_ => InlineType.SlideEditor, 
			};
			_menuLayoutVM.ActiveUndoStack = presentation.UndoStack;
		}
	}

	private CustomSlide? GetSelectedEditorSlide(EditMode editMode, CustomSlide? selectedSlide)
	{
		if (selectedSlide != null && _presentationEditorVM.Slides.Contains(selectedSlide))
		{
			return selectedSlide;
		}
		switch (editMode)
		{
		case EditMode.Presentation:
		{
			ObservableCollection<ArrangedCue> selectedSlides = _presentationVM.SelectedSlides;
			if ((selectedSlides.Any() ? selectedSlides[0] : _presentationVM.ActiveSlide)?.Source.SlideAction?.Slide is CustomSlide customSlide && _presentationEditorVM.Slides.Contains(customSlide))
			{
				return customSlide;
			}
			break;
		}
		case EditMode.Stage:
			if (_presentationEditorVM.StageLayoutInspectorVM.SlideCue?.SlideAction?.Slide is CustomSlide customSlide2 && _presentationEditorVM.Slides.Contains(customSlide2))
			{
				return customSlide2;
			}
			break;
		case EditMode.Prop:
			return _propsVM.SelectedItem?.SlideAction?.Slide as CustomSlide;
		}
		return null;
	}

	private void EditTemplates(Theme? theme, EditMode editMode)
	{
		ActiveInlineView = ((editMode == EditMode.CCLITemplate) ? InlineType.CCLITemplateEditor : InlineType.TemplateEditor);
		if (theme == null)
		{
			theme = _templateEditorVM.Theme;
			if (theme == null || (editMode == EditMode.Template && !DataVault.Themes.Contains(theme)))
			{
				theme = DataVault.Themes.FirstOrDefault();
			}
		}
		_templateEditorVM.EditMode = editMode;
		_templateEditorVM.Theme = theme;
	}

	private void EditProps(IPropGroupVM groupVM, IPropCueVM? propCueVM)
	{
		if (groupVM is IPropGroupVMInternal propGroupVMInternal)
		{
			EditProps(propGroupVMInternal.Source, (propCueVM as IPropCueVMInternal)?.Source);
		}
	}

	private void EditProps(IPropGroup? group, IPropCue? propCue)
	{
		ActiveInlineView = InlineType.PropsEditor;
		if (group == null)
		{
			group = _propsEditorVM.SelectedPropGroup;
		}
		_propsEditorVM.EditMode = EditMode.Prop;
		_propsEditorVM.SelectedPropGroup = group;
		_propsEditorVM.SelectedProp = propCue ?? group?.FirstOrDefault();
	}

	private void EditMasks(bool addNewMask)
	{
		IMaskCollection maskCollection = OutputVault.OutputConfiguration?.Masks;
		maskCollection.ThrowWhenNull("masks");
		if (addNewMask || maskCollection.Empty())
		{
			maskCollection.Add();
		}
		_maskEditorVM.EditMode = EditMode.Mask;
		ActiveInlineView = InlineType.MaskEditor;
		_maskEditorVM.SelectSlide(_maskEditorVM.Slides[0]);
		_menuLayoutVM.ActiveUndoStack = maskCollection.UndoStack;
	}

	private void OnInlineViewChanged(InlineType inlineType)
	{
		switch (inlineType)
		{
		case InlineType.Bible:
			_menuLayoutVM.ActiveUndoStack = BibleVM.WorkingPresentation?.UndoStack;
			break;
		case InlineType.Presentation:
			_menuLayoutVM.ActiveUndoStack = _presentationVM.ActivePresentation?.UndoStack;
			break;
		case InlineType.TemplateEditor:
		case InlineType.CCLITemplateEditor:
			_menuLayoutVM.ActiveUndoStack = _templateEditorVM.Theme?.UndoStack;
			break;
		}
		MenuLayoutVM.ActiveInlineType = inlineType;
	}

	private void OpenLiveVideoSetup(LiveVideoInput? videoInput)
	{
		OnShowSettingsWindow(SettingsPage.Input);
		_inputsSettingsVM.SelectedIndex = 0;
		_inputsSettingsVM.VideoInputsSettingsVM.ActiveLiveVideoInput = videoInput ?? _inputsSettingsVM.VideoInputsSettingsVM.LiveVideoInputs.FirstOrDefault();
	}

	private static void OnShutdownCommand()
	{
		Application.Current.MainWindow.Close();
	}

	private void OnShowEditorCommand(ShowSource source, CustomPresentation? presentation, EditMode mode)
	{
		presentation.ThrowWhenNull("presentation");
		EditPresentation(presentation, mode);
		switch (source)
		{
		case ShowSource.Toolbar:
			MainViewPresentationEditorEvent.Publish(MainViewSource.Toolbar);
			break;
		case ShowSource.ApplicationMenu:
			MainViewPresentationEditorEvent.Publish(MainViewSource.ApplicationMenu);
			break;
		case ShowSource.ContextMenu:
			MainViewPresentationEditorEvent.Publish(MainViewSource.ContextMenu);
			break;
		case ShowSource.LibraryContextMenu:
			MainViewPresentationEditorEvent.Publish(MainViewSource.LibraryContextMenu);
			break;
		}
	}

	private void OnShowReflowEditorCommand(ShowSource source)
	{
		ActiveInlineView = InlineType.Reflow;
		switch (source)
		{
		case ShowSource.Toolbar:
			MainViewReflowEditorEvent.Publish(MainViewSource.Toolbar);
			break;
		case ShowSource.ApplicationMenu:
			MainViewReflowEditorEvent.Publish(MainViewSource.ApplicationMenu);
			break;
		case ShowSource.LibraryContextMenu:
			MainViewReflowEditorEvent.Publish(MainViewSource.LibraryContextMenu);
			break;
		case ShowSource.ContextMenu:
			break;
		}
	}

	private void OnToggleEditorViewCommand()
	{
		if (ActiveInlineView == InlineType.SlideEditor && PresentationEditorVM.EditMode == EditMode.Presentation)
		{
			ShowMainViewCommand?.Invoke(ShowSource.ApplicationMenu);
		}
		else
		{
			ShowEditorCommand?.Invoke(ShowSource.ApplicationMenu);
		}
	}

	private void OnToggleReflowEditorViewCommand()
	{
		ToggleView(InlineType.Reflow);
		MainViewReflowEditorEvent.Publish(MainViewSource.ApplicationMenu);
	}

	private void ToggleView(InlineType viewType)
	{
		ActiveInlineView = ((ActiveInlineView == viewType) ? InlineType.Presentation : viewType);
	}

	private void OnSetSelectedViewCommand(PopupType popupType)
	{
		this.SetSelectedView?.Invoke(popupType);
	}

	public void ActivateRegistrationUI(IMainLayoutVM.CodeInfo? codeInfo = null)
	{
		this.ShowRegistration?.Invoke(codeInfo);
	}

	private void TriggerNextSlide(bool suppress)
	{
		if (ActiveInlineView == InlineType.Bible)
		{
			BibleVM.TriggerNextSlideCommand?.Invoke();
		}
		else if (suppress && Advanced.Settings.SuppressVideoStart)
		{
			((TransportStatusVM.PresentationStatusVM.PlaybackStatus == MediaStatus.Play) ? TransportStatusVM.PresentationStatusVM.PauseCommand : TransportStatusVM.PresentationStatusVM.PlayCommand)?.Invoke();
		}
		else
		{
			PresentationVM.TriggerNextSlideCommand?.Invoke();
		}
	}

	private void TriggerPreviousSlide()
	{
		((ActiveInlineView == InlineType.Bible) ? BibleVM.TriggerPreviousSlideCommand : PresentationVM.TriggerPreviousSlideCommand)?.Invoke();
	}

	private void OnAddSlideCommand()
	{
		GetAddSlideCommand()?.Invoke();
	}

	private bool CanAddSlide()
	{
		return GetAddSlideCommand()?.CanExecute(null) ?? false;
	}

	private ICommand? GetAddSlideCommand()
	{
		return ActiveInlineView switch
		{
			InlineType.Bible => null, 
			InlineType.Presentation => PresentationVM.DeriveAndAddSlideCommand, 
			InlineType.Web => null, 
			InlineType.InfoCenter => null, 
			InlineType.VideoTutorials => null, 
			InlineType.Reflow => PresentationVM.DeriveAndAddSlideCommand, 
			InlineType.Telestrator => null, 
			InlineType.SlideEditor => PresentationEditorVM.CreateNewSlideFromSelectedSlideCommand, 
			InlineType.TemplateEditor => TemplateEditorVM.CreateNewSlideFromSelectedSlideCommand, 
			InlineType.MaskEditor => MaskEditorVM.CreateNewSlideFromSelectedSlideCommand, 
			InlineType.StageEditor => PresentationEditorVM.CreateNewSlideFromSelectedSlideCommand, 
			InlineType.PropsEditor => PropsEditorVM.CreateNewSlideFromSelectedSlideCommand, 
			InlineType.CCLITemplateEditor => null, 
			_ => null, 
		};
	}

	private void OnSelectedUtilityViewChanged(UtilityViewType viewType)
	{
		UtilityViewVM.SelectedViewType = viewType;
	}

	private void OnShowMainViewCommand(ShowSource source)
	{
		ActiveInlineView = InlineType.Presentation;
		switch (source)
		{
		case ShowSource.Toolbar:
			MainViewShownEvent.Publish(MainViewSource.Toolbar);
			break;
		case ShowSource.ApplicationMenu:
			MainViewShownEvent.Publish(MainViewSource.ApplicationMenu);
			break;
		}
	}

	private void ProContentVM_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "CurrentGroup")
		{
			PresentationVM.SetMediaBinShowsProContent(MediaLibraryVM.ProContentVM.CurrentGroup != null);
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
			_downloadsVM.Dispose();
			_screenPreviewVM.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		Settings.PropertyChanged -= base.RaiseLinkedValues;
		MediaLibraryVM.ProContentVM.PropertyChanged -= ProContentVM_PropertyChanged;
		_presentationVM.Dispose();
	}
}
