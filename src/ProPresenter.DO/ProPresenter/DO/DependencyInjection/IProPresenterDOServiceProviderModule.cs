using System.IO.Abstractions;
using Jab;
using Pro.Common.Dispatcher;
using Pro.Common.FeatureFlag;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.Versioning;
using Pro.CoreApplication.Workspace;
using Pro.DO;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.Entity.Persistence;
using Pro.Interprocess;
using ProPresenter.DO.Actions.DependencyInjection;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Analytics.DependencyInjection;
using ProPresenter.DO.Analytics.Events.CloudDiagnostics;
using ProPresenter.DO.Audio;
using ProPresenter.DO.Bibles;
using ProPresenter.DO.Cache;
using ProPresenter.DO.Cache.DependencyInjection;
using ProPresenter.DO.Capture.DependencyInjection;
using ProPresenter.DO.ChangeDirectory;
using ProPresenter.DO.CloudOnboarding;
using ProPresenter.DO.CommonPathsWrapper;
using ProPresenter.DO.Downloads;
using ProPresenter.DO.Downloads.DependencyInjection;
using ProPresenter.DO.Export;
using ProPresenter.DO.Import;
using ProPresenter.DO.Import.DependencyInjection;
using ProPresenter.DO.Import.Results;
using ProPresenter.DO.Indexing;
using ProPresenter.DO.InputActionMap;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Masks;
using ProPresenter.DO.Media.DependencyInjection;
using ProPresenter.DO.MultiTracks;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.OutputConfiguration.DependencyInjection;
using ProPresenter.DO.PCO;
using ProPresenter.DO.PanelViewSettings;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation.DependencyInjection;
using ProPresenter.DO.ProContent.DependencyInjection;
using ProPresenter.DO.Resi.DependencyInjection;
using ProPresenter.DO.Settings.DependencyInjection;
using ProPresenter.DO.SongSelect;
using ProPresenter.DO.Sync.DependencyInjection;
using ProPresenter.DO.TestPattern.DependencyInjection;
using ProPresenter.DO.Themes;
using ProPresenter.DO.Themes.DependencyInjection;
using ProPresenter.DO.Updates.DependencyInjection;
using ProPresenter.DO.Web;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Import<IOutputConfigurationServiceProviderModule>]
[Jab.Import<IProPresenterDOImportServiceProviderModule>]
[Jab.Import<IMediaServiceProviderModule>]
[Jab.Import<ISettingsServiceProviderModule>]
[Jab.Import<IPresentationServiceProviderModule>]
[Jab.Import<IActionsServiceProviderModule>]
[Jab.Import<ICaptureServiceProviderModule>]
[Jab.Import<IThemesServiceProviderFactory>]
[Jab.Import<IAnalyticsServiceProviderModule>]
[Jab.Import<IProContentServiceProvicerModule>]
[Jab.Import<ICacheServiceProviderModule>]
[Jab.Import<IDownloadsServiceProviderModule>]
[Jab.Import<IResiServiceProviderModule>]
[Jab.Import<ITestPatternServiceProvicerModule>]
[Jab.Import<ISyncServiceProviderModule>]
[Jab.Import<IUpdatesServiceProviderModule>]
[Jab.Singleton<ICloudDiagnosticsPublisher>(Factory = "CreateCloudDiagnosticsPublisher")]
[Jab.Transient<IFileService, FileService>]
[Jab.Transient<IFileCreator, FileCreator>]
[Jab.Transient<IIndexingService, IndexingService>]
[Jab.Transient<ISyncDataFactory, SyncDataFactory>]
[Jab.Transient<IPresentationCapableSyncDataFactory, SyncDataFactory>]
[Jab.Singleton<IApplicationLaunchEventPublisher, ApplicationLaunchEventPublisher>]
[Jab.Singleton<IMessages<AppMessages>, Messages<AppMessages>>]
[Jab.Transient<IWebSourceProvider, WebSourceProvider>]
[Jab.Singleton<IBibleProvider, BibleProvider>]
[Jab.Singleton<IThemeRepo, ThemeRepo>]
[Jab.Transient<ILibraryPlaylistRepo, LibraryPlaylistRepo>]
[Jab.Transient<IVisualPlaylistRepo, VisualPlaylistRepo>]
[Jab.Transient<IProPresenterResourceService, ProPresenterResourceService>]
[Jab.Transient<IDownloadItemFactory, DownloadItemFactory>]
[Jab.Singleton<ISongSelectConsumer, SongSelectConsumer>]
[Jab.Transient<IBitmapImageDecoder, BitmapImageDecoder>]
[Jab.Singleton<IMultiTracksConsumer, MultiTracksConsumer>]
[Jab.Singleton<IPCOUpdater, PCOUpdater>]
[Jab.Transient<ThumbnailViewSettings>]
[Jab.Singleton<IExportProcessFactory, ExportProcessFactory>]
[Jab.Singleton<IInputActions>(Factory = "GetInputActions")]
[Jab.Transient<IMediaImportService, MediaImportService>]
[Jab.Singleton<IProPresenterDOFactoryProvider, ProPresenterDOFactoryProvider>]
[Jab.Singleton<ICommonPathsWrapper, ProPresenter.DO.CommonPathsWrapper.CommonPathsWrapper>]
[Jab.Singleton<IWorkspaceService, WorkspaceService>]
[Jab.Transient<IWorkspaceInspectionService, WorkspaceInspectionService>]
[Jab.Transient<IMediaFileProvider, MediaFileProvider>]
[Jab.Transient<ICloudConversionService, CloudConversionService>]
[Jab.Singleton<ICloudOnboardingService, CloudOnboardingService>]
[Jab.Transient<IProPresenterCueFactory, ProPresenterCueFactory>]
[Jab.Singleton<IScreenArrangementFactory, ScreenArrangementFactory>]
[Jab.Singleton<IBibleDataStore>(Factory = "CreateBibleDataStore")]
[Jab.Transient<IImportHelperServices, ImportHelperServices>]
[Jab.Singleton<ICrdtProtoDirectoryFileScanner, CrdtProtoDirectoryFileScanner>]
[Jab.Transient<IMatchSongsInteractor, MatchSongsInteractor>]
[Jab.Singleton<IWorkspaceDocumentOrchestrator>(Factory = "GetWorkspaceDocumentOrchestrator")]
[Jab.Singleton<ThemeCollection>(Factory = "GetThemeCollection")]
[Jab.Transient<IThemeCollection>(Factory = "GetThemeCollectionRedirect")]
[Jab.Singleton<IMaskCollection, MaskCollection>]
[Jab.Singleton<ILiveVideoInputCollection, LiveVideoInputCollection>]
[Jab.Singleton<IAudioInputCollection, AudioInputCollection>]
public interface IProPresenterDOServiceProviderModule
{
	const string WhatsNewContentProviderFromJsonFileContentKey = "WhatsNewContentProviderFromJsonFileContentKey";

	static ICloudDiagnosticsPublisher CreateCloudDiagnosticsPublisher(IFlagService flagService, ICollaborationPeerIdProvider peerIdProvider, IWorkspaceService workspaceService)
	{
		if (!flagService.IsFlagEnabled(Flag.CloudDiagnostics))
		{
			return new NullCloudDiagnosticsPublisher();
		}
		return new CloudDiagnosticsPublisher(peerIdProvider, workspaceService);
	}

	static IBibleDataStore CreateBibleDataStore()
	{
		return new BibleDataStore(CommonPaths.Bibles);
	}

	static IInputActions GetInputActions(IFlagService flagService, ISyncDataFactory syncDataFactory, IProPresenterDOFactoryProvider factoryProvider, IVersionInfoProvider versionInfoProvider, ICrdtProtoDirectoryFileScanner scanner)
	{
		return new InputActions(flagService, syncDataFactory, factoryProvider, versionInfoProvider, scanner.ShouldLoadLegacy);
	}

	static ThemeCollection GetThemeCollection(ISyncDataFactory syncDataFactory, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions, IFlagService flagService, IUiScheduler scheduler, IActionBinderFactory actionBinderFactory, ICrdtProtoDirectoryFileScanner scanner, ICommonPathsWrapper commonPathsWrapper, IFileSystem fileSystem, IFileWatcherFactory fileWatcherFactory, ICollectionStorage collectionStorage)
	{
		return new ThemeCollection(syncDataFactory, factoryProvider, transitionDescriptions, flagService, scheduler, actionBinderFactory, commonPathsWrapper, fileSystem, fileWatcherFactory, collectionStorage, scanner.ShouldLoadLegacy);
	}

	static IWorkspaceDocumentOrchestrator GetWorkspaceDocumentOrchestrator(ICloudWorkspaceService cloudWorkspaceService, IEntityDocumentRegistry entityDocumentRegistry, ICommonPathsWrapper commonPaths, IFileSystem fileSystem, ILogger logger, IInputActions keyMappings, IOutputConfiguration outputConfiguration, IProPresenterResourceService resources)
	{
		return new WorkspaceDocumentOrchestrator(cloudWorkspaceService, entityDocumentRegistry, commonPaths, fileSystem, logger, new global::_003C_003Ez__ReadOnlyArray<IDocumentProvider>(new IDocumentProvider[17]
		{
			resources.Calendar, resources.CCLIPresentation, resources.ClearGroups, resources.GroupLabels, resources.SlideLabels, keyMappings, resources.MacroGroups, resources.Messages, resources.PropGroupCollection, resources.StagePresentation,
			resources.TimerDocument, outputConfiguration, resources.LibraryCollection, resources.PlaylistTemplates, resources.AudioPlaylists, resources.LibraryPlaylists, resources.VisualPlaylists
		}));
	}

	static ThemeCollection GetThemeCollectionRedirect(ThemeCollection themes)
	{
		return themes;
	}
}
