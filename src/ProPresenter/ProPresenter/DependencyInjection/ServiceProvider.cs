using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Abstractions;
using System.Reactive.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Threading;
using Jab;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.JsonWebTokens;
using Pro.Common.Animation;
using Pro.Common.AuthenticatingApiConsumer;
using Pro.Common.AuthenticatingApiConsumer.OAuth2;
using Pro.Common.Background;
using Pro.Common.Cache.AsyncCache;
using Pro.Common.Concurrency;
using Pro.Common.DataFlow;
using Pro.Common.DataStore;
using Pro.Common.Delay;
using Pro.Common.DependencyInjection;
using Pro.Common.Dispatcher;
using Pro.Common.Downloads;
using Pro.Common.ErrorReporting;
using Pro.Common.FeatureFlag;
using Pro.Common.FileSystem;
using Pro.Common.HTTP;
using Pro.Common.Internet;
using Pro.Common.Logging;
using Pro.Common.MessageService;
using Pro.Common.Network;
using Pro.Common.Nullability;
using Pro.Common.OAuth.Authenticator;
using Pro.Common.ProcessSupervision;
using Pro.Common.Startup;
using Pro.Common.Time;
using Pro.Common.Time.Timer;
using Pro.Common.ToastNotifications;
using Pro.Common.Utility;
using Pro.Common.Utility.Zip;
using Pro.Common.Versioning;
using Pro.CoreApplication;
using Pro.CoreApplication.CoreInteraction;
using Pro.CoreApplication.Document;
using Pro.CoreApplication.FeatureFlag;
using Pro.CoreApplication.Media;
using Pro.CoreApplication.Media.V1;
using Pro.CoreApplication.Media.V2;
using Pro.CoreApplication.PowerPoint;
using Pro.CoreApplication.PowerPoint.CoreInteraction;
using Pro.CoreApplication.Registration;
using Pro.CoreApplication.Registration.Interaction;
using Pro.CoreApplication.Workspace;
using Pro.DO;
using Pro.DO.Audio;
using Pro.DO.DependencyInjection;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Data.SQLite;
using Pro.Data.SQLite.DependencyInjection;
using Pro.Data.SQLite.Migration;
using Pro.DxDiagReport;
using Pro.Entity;
using Pro.Entity.Merged.Factory;
using Pro.Entity.Persistence;
using Pro.Imaging;
using Pro.Interprocess;
using Pro.Localization.DependencyInjection;
using Pro.Localization.Services;
using Pro.Reporting;
using Pro.Reporting.BugsnagInternal;
using Pro.Reporting.DependencyInjection;
using Pro.Reporting.UserFeedback;
using Pro.Reporting.UserFeedback.AttachmentUpload;
using Pro.Serialization.DependencyInjection;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using Pro.Text;
using Pro.Text.Fills;
using Pro.UI.Controls;
using Pro.UI.Converters;
using Pro.UI.DependencyInjection;
using Pro.UI.DialogService;
using Pro.UI.Factories.LoginDialog;
using Pro.UI.Utility;
using Pro.Web.Cookies;
using Pro.Web.DependencyInjection;
using Pro.Web.Services;
using Pro.ssAPI.Devices;
using ProPresenter.Continuation;
using ProPresenter.Controller;
using ProPresenter.Controller.AsyncTransferHandlers;
using ProPresenter.Controller.DependencyInjection;
using ProPresenter.Controller.Media;
using ProPresenter.Controller.NetworkAPI;
using ProPresenter.Controller.NetworkAPI.Receive;
using ProPresenter.Controller.NetworkAPI.Transmit;
using ProPresenter.Controller.NetworkAPI.Transmit.Command;
using ProPresenter.Controller.Outputs;
using ProPresenter.Controller.RenderClockSource;
using ProPresenter.Controller.Repos;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Actions.Playlist;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Analytics.Events.Capture;
using ProPresenter.DO.Analytics.Events.CloudDiagnostics;
using ProPresenter.DO.Analytics.Events.ForceQuit;
using ProPresenter.DO.Analytics.Events.MediaManagement;
using ProPresenter.DO.Analytics.Events.PowerPoint;
using ProPresenter.DO.Analytics.Events.ProContent;
using ProPresenter.DO.Analytics.Events.Settings.CCLIReport;
using ProPresenter.DO.Analytics.Events.Startup;
using ProPresenter.DO.Analytics.Events.TestPattern;
using ProPresenter.DO.Analytics.Events.TrackedEvents;
using ProPresenter.DO.Analytics.Events.TrackedEvents.CloudOnboarding;
using ProPresenter.DO.Analytics.Events.TrackedEvents.LocalWorkspaces;
using ProPresenter.DO.Analytics.Events.TrackedEvents.MediaCleanupSize;
using ProPresenter.DO.Analytics.Events.TrackedEvents.MissingFonts;
using ProPresenter.DO.Analytics.Events.TrackedEvents.Workspace;
using ProPresenter.DO.Analytics.Events.UIPreferences;
using ProPresenter.DO.Analytics.Events.Welcome;
using ProPresenter.DO.Audio;
using ProPresenter.DO.Bibles;
using ProPresenter.DO.Cache;
using ProPresenter.DO.Capture;
using ProPresenter.DO.ChangeDirectory;
using ProPresenter.DO.CloudOnboarding;
using ProPresenter.DO.CommonPathsWrapper;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Downloads;
using ProPresenter.DO.Events;
using ProPresenter.DO.Export;
using ProPresenter.DO.Import;
using ProPresenter.DO.Import.DependencyInjection;
using ProPresenter.DO.Import.Results;
using ProPresenter.DO.Indexing;
using ProPresenter.DO.InputActionMap;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Masks;
using ProPresenter.DO.Media;
using ProPresenter.DO.Media.Properties.File;
using ProPresenter.DO.Media.Services;
using ProPresenter.DO.MultiTracks;
using ProPresenter.DO.Organization;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.PCO;
using ProPresenter.DO.PanelViewSettings;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.ProContent;
using ProPresenter.DO.ProContent.Consumer;
using ProPresenter.DO.ProContent.Downloads;
using ProPresenter.DO.Registration.Operations;
using ProPresenter.DO.Registration.State;
using ProPresenter.DO.Repositories;
using ProPresenter.DO.Resi;
using ProPresenter.DO.Resi.DependencyInjection;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Settings.DependencyInjection;
using ProPresenter.DO.Settings.GeneralSettings;
using ProPresenter.DO.SongSelect;
using ProPresenter.DO.Sync.Local;
using ProPresenter.DO.TestPattern;
using ProPresenter.DO.TestPattern.Properties;
using ProPresenter.DO.TestPattern.State;
using ProPresenter.DO.Themes;
using ProPresenter.DO.Updates;
using ProPresenter.DO.Web;
using ProPresenter.DO.WhatsNew;
using ProPresenter.DO.Workspaces;
using ProPresenter.Data;
using ProPresenter.Data.Crdt;
using ProPresenter.Data.DependencyInjection;
using ProPresenter.Data.Messages;
using ProPresenter.Data.StartupArguments;
using ProPresenter.FeatureFlag;
using ProPresenter.Registration.CallbackHandlers;
using ProPresenter.Registration.CallbackHandlers.Dialogs;
using ProPresenter.Registration.CallbackHandlers.Notifications;
using ProPresenter.Registration.CallbackHandlers.PopUpAlert;
using ProPresenter.Registration.DependencyInjection;
using ProPresenter.Registration.Operations;
using ProPresenter.Registration.Services;
using ProPresenter.Registration.UserInteraction;
using ProPresenter.Rendering;
using ProPresenter.Rendering.DependencyInjection;
using ProPresenter.Rendering.Web;
using ProPresenter.SendData;
using ProPresenter.SendData.DependencyInjection;
using ProPresenter.SendData.Props;
using ProPresenter.Services;
using ProPresenter.ToastNotifications;
using ProPresenter.UI;
using ProPresenter.UI.Calendar;
using ProPresenter.UI.CloudOnboarding;
using ProPresenter.UI.Converters;
using ProPresenter.UI.DependencyInjection;
using ProPresenter.UI.MediaLibrary;
using ProPresenter.UI.UserAttachments;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.AccountCenter;
using ProPresenter.UI.ViewModels.CloudOnboarding;
using ProPresenter.UI.ViewModels.FeedbackCrash;
using ProPresenter.UI.ViewModels.Import;
using ProPresenter.UI.ViewModels.Library.Cue;
using ProPresenter.UI.ViewModels.Macros;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.Notification;
using ProPresenter.UI.ViewModels.OutputConfiguration;
using ProPresenter.UI.ViewModels.Presentation;
using ProPresenter.UI.ViewModels.Preview;
using ProPresenter.UI.ViewModels.Props;
using ProPresenter.UI.ViewModels.Resi;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages;
using ProPresenter.UI.ViewModels.Settings.Pages.Devices;
using ProPresenter.UI.ViewModels.Settings.Pages.Groups;
using ProPresenter.UI.ViewModels.Settings.Pages.Import;
using ProPresenter.UI.ViewModels.Settings.Pages.Inputs;
using ProPresenter.UI.ViewModels.Settings.Pages.Integrations;
using ProPresenter.UI.ViewModels.Settings.Pages.Integrations.CCLI;
using ProPresenter.UI.ViewModels.Settings.Pages.Labels;
using ProPresenter.UI.ViewModels.Settings.Pages.Media;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.ProPresenter;
using ProPresenter.UI.ViewModels.Settings.Pages.Screens;
using ProPresenter.UI.ViewModels.Settings.Pages.Sync;
using ProPresenter.UI.ViewModels.Settings.Pages.Updates;
using ProPresenter.UI.ViewModels.Settings.Search;
using ProPresenter.UI.ViewModels.Themes;
using ProPresenter.UI.ViewModels.Timeline;
using ProPresenter.UI.ViewModels.WhatsNew;
using ProPresenter.UI.ViewModels.Workspaces;
using ProPresenter.UI.Web;
using ProPresenter.Updates;
using ProPresenter.Utility;
using ProPresenter.ViewModels;
using ProPresenter.ViewModels.AccountCenter;
using ProPresenter.ViewModels.ActionsMenu;
using ProPresenter.ViewModels.Bibles;
using ProPresenter.ViewModels.Calendar;
using ProPresenter.ViewModels.Capture;
using ProPresenter.ViewModels.CloudOnboarding;
using ProPresenter.ViewModels.DependencyInjection;
using ProPresenter.ViewModels.Downloads;
using ProPresenter.ViewModels.Editor;
using ProPresenter.ViewModels.FeedbackCrash;
using ProPresenter.ViewModels.Import;
using ProPresenter.ViewModels.Library;
using ProPresenter.ViewModels.Macros;
using ProPresenter.ViewModels.MediaLibrary;
using ProPresenter.ViewModels.Notification;
using ProPresenter.ViewModels.OutputConfiguration;
using ProPresenter.ViewModels.Preview;
using ProPresenter.ViewModels.ProContent.Dialog;
using ProPresenter.ViewModels.Props;
using ProPresenter.ViewModels.Resi;
using ProPresenter.ViewModels.Settings;
using ProPresenter.ViewModels.Settings.DependencyInjection;
using ProPresenter.ViewModels.Settings.Pages;
using ProPresenter.ViewModels.Settings.Pages.Devices;
using ProPresenter.ViewModels.Settings.Pages.General;
using ProPresenter.ViewModels.Settings.Pages.Groups;
using ProPresenter.ViewModels.Settings.Pages.Import;
using ProPresenter.ViewModels.Settings.Pages.Inputs;
using ProPresenter.ViewModels.Settings.Pages.Inputs.Video;
using ProPresenter.ViewModels.Settings.Pages.Integrations;
using ProPresenter.ViewModels.Settings.Pages.Integrations.CCLI;
using ProPresenter.ViewModels.Settings.Pages.Labels;
using ProPresenter.ViewModels.Settings.Pages.Media;
using ProPresenter.ViewModels.Settings.Pages.Network;
using ProPresenter.ViewModels.Settings.Pages.Registration;
using ProPresenter.ViewModels.Settings.Pages.Screens;
using ProPresenter.ViewModels.Settings.Pages.Updates;
using ProPresenter.ViewModels.Settings.Search;
using ProPresenter.ViewModels.Themes;
using ProPresenter.ViewModels.Timecode;
using ProPresenter.ViewModels.Timeline;
using ProPresenter.ViewModels.UserFeedback;
using ProPresenter.ViewModels.WhatsNew;
using ProPresenter.ViewModels.Workspaces;
using ProPresenter.WhatsNew;
using ProPresenterCore.ProCore.Interop;
using ProPresenterCore.ProCore.Interop.SendDataHandlers;

namespace ProPresenter.DependencyInjection;

[Jab.ServiceProvider(RootServices = new Type[]
{
	typeof(IEnumerable<IStartupArgumentsExecutor>),
	typeof(IEnumerable<IMessageHandler>)
})]
[Jab.Import<IProPresenterDOServiceProviderModule>]
[Jab.Import<ICommonServiceProviderModule>]
[Jab.Import<ISerializationServiceProviderModule>]
[Jab.Import<IWebServiceProviderModule>]
[Jab.Import<IViewModelsServiceProviderModule>]
[Jab.Import<IGlobalServiceProviderModule>]
[Jab.Import<IProUIServiceProviderModule>]
[Jab.Import<ILocalizationServiceProviderModule>]
[Jab.Import<IControllerServiceProviderModule>]
[Jab.Import<IRenderingServiceProviderModule>]
[Jab.Import<ISqLiteServiceProviderModule>]
[Jab.Import<IDataServiceProviderModule>]
[Jab.Import<IReportingServiceProviderModule>]
[Jab.Import<IRegistrationServiceProviderModule>]
[Jab.Import<ISendDataServiceProviderModule>]
[Jab.Import<IProPresenterUiServiceProviderModule>]
[Jab.Import<IProDOServiceProviderModule>]
[Jab.Transient<IAppContinuationService>(Factory = "GetContinuationService")]
[Jab.Singleton<RegistrationStateHandler>(Factory = "GetRegistrationStateHandler")]
[Jab.Transient<IUiDispatcher>(Factory = "GetDispatcher")]
[Jab.Transient<IUiScheduler>(Factory = "GetDispatcher")]
[Jab.Transient<IThreadPoolScheduler, ThreadPoolScheduler>]
[Jab.Transient<System.Action>(Factory = "GetShowRegistrationSettings", Name = "ShowRegistrationSettingsKey")]
[Jab.Singleton<IFlagService>(Factory = "GetFlagService")]
[Jab.Singleton<IProCoreInstance>(Factory = "GetCoreInstance")]
[Jab.Transient<Func<IMainLayoutVM>>(Factory = "GetMainLayoutVmGetter")]
[Jab.Transient<Func<IRegistrationOperationFactory>>(Factory = "GetRegistrationOperationFactoryGetter")]
[Jab.Transient<Func<bool>>(Factory = "GetShouldSuppressVisualIndication", Name = "ShouldSuppressVisualIndicationKey")]
[Jab.Transient<Func<MainWindow>>(Factory = "GetMainWindowGetter")]
[Jab.Transient<IInstanceValidator>(Factory = "GetInstanceValidator")]
[Jab.Transient<System.IO.Stream>(Factory = "GetEmbeddedWhatsNewContent", Name = "WhatsNewContentProviderFromJsonFileContentKey")]
[Jab.Singleton<MainWindow>(Factory = "GetMainWindow")]
[Jab.Singleton<ICloudOnboardingWindowProvider, CloudOnboardingWindowProvider>]
[Jab.Transient<ISystemInfoProvider>(Factory = "GetSystemInfoProvider")]
[Jab.Transient<IStartupArgumentsExecutor>(Factory = "GetUriSchemeStartupArgumentExecutor")]
[Jab.Singleton<IMediaServiceV1, MediaServiceV1>]
[Jab.Singleton<IMediaServiceV2, MediaServiceV2>]
[Jab.Singleton<IMediaService>(Factory = "GetMediaService")]
[Jab.Transient<ITrackedMediaHelpers>(Factory = "GetTrackedMediaHelpers")]
[Jab.Singleton<IMediaMetadataCacheRepository, MediaMetadataCacheRepository>]
[Jab.Singleton<IMediaMetadataCacheService, MediaMetadataCache>]
[Jab.Singleton<IMetadataLoader>(Factory = "GetMetadataLoader")]
[Jab.Singleton<IProContentConsumer>(Factory = "GetProContentConsumer")]
[Jab.Singleton<IOrganizationConsumer>(Factory = "GetOrganizationConsumer")]
[Jab.Singleton<ISyncController>(Factory = "GetSyncController")]
[Jab.Transient<IWhatsNewContentProviderFromJson>(Factory = "GetWhatsNewContentProviderFromJson")]
[Jab.Singleton<IProcessSupervisor>(Factory = "GetWorkspaceHelperSupervision", Name = "WorkspaceHelperProcessSupervisor")]
[Jab.Transient<IImportLocationSelectionDialogService>(Factory = "GetImportLocationSelectionDialogService")]
[Jab.Singleton<IActionFactoryService>(Factory = "GetActionFactory")]
[Jab.Singleton<IWorkspaceDeletedPrompt, WorkspaceDeletedPrompt>]
[Jab.Singleton<IWorkspaceInfoDumper, WorkspaceInfoDumper>]
[Jab.Singleton<IWorkspacesVM>(Factory = "CreateWorkspaceVM")]
[Jab.Transient<IProContentDownloader>(Factory = "CreateProContentDownloader")]
[Jab.Transient<IEnumerable<ISettingsListItem>>(Factory = "GetSettingsVMs")]
[Jab.Singleton<IWorkspaceCollectionVM>(Factory = "GetWorkspaceCollectionVM")]
[GeneratedCode("Jab", "0.12.0.0")]
internal sealed class ServiceProvider : IDisposable, IAsyncDisposable, IServiceProvider, IKeyedServiceProvider, IServiceScopeFactory, IServiceProviderIsService, Jab.IServiceProvider<IPhysicalDeviceProvider>, Jab.IServiceProvider<IDatabaseService>, Jab.IServiceProvider<IFileWatcherFactory>, Jab.IServiceProvider<IFileSystem>, Jab.IServiceProvider<IUiDispatcher>, Jab.IServiceProvider<ITimerFactory>, Jab.IServiceProvider<IDebouncerFactory>, Jab.IServiceProvider<IThemeRepo>, Jab.IServiceProvider<IPropsRepo>, Jab.IServiceProvider<IMacrosRepo>, Jab.IServiceProvider<ILibraryPlaylistRepo>, Jab.IServiceProvider<IVisualPlaylistRepo>, Jab.IServiceProvider<IProPresenterResourceService>, Jab.IServiceProvider<IThemeService>, Jab.IServiceProvider<IZipService>, Jab.IServiceProvider<IMessageService>, Jab.IServiceProvider<IFileService>, Jab.IServiceProvider<ILogger>, Jab.IServiceProvider<ILocalization>, Jab.IServiceProvider<IAdvanced>, Jab.IServiceProvider<IProtoService>, Jab.IServiceProvider<ISqliteMigrationService>, Jab.IServiceProvider<ICookieManagerService>, Jab.IServiceProvider<App>, Jab.IServiceProvider<IApp>, Jab.IServiceProvider<IProCoreInstance>, Jab.IServiceProvider<IFlagService>, Jab.IServiceProvider<ssAPIOutput>, Jab.IServiceProvider<ITransitionDescriptionCollection>, Jab.IServiceProvider<IImageLoader>, Jab.IServiceProvider<IMediaMetadataCacheRepository>, Jab.IServiceProvider<IMediaMetadataCacheService>, Jab.IServiceProvider<IAsyncExecutor>, Jab.IServiceProvider<IUiScheduler>, Jab.IServiceProvider<IMetadataLoader>, Jab.IServiceProvider<ITrackedMediaHelpers>, Jab.IServiceProvider<IAssemblyInfoProvider>, Jab.INamedServiceProvider<System.Version>, Jab.IServiceProvider<IVersionInfoProvider>, Jab.IServiceProvider<IRestClientFactory>, Jab.IServiceProvider<ISemaphoreFactory>, Jab.IServiceProvider<ICurrentTime>, Jab.IServiceProvider<IFileSystemUriCacheServiceFactory>, Jab.IServiceProvider<IImageDecoder>, Jab.IServiceProvider<IBitmapImageDecoder>, Jab.IServiceProvider<IUriCacheService<NullableBitmapSource>>, Jab.IServiceProvider<ICurrentTimeOffset>, Jab.IServiceProvider<IAuthenticatingApiConsumerFactory>, Jab.IServiceProvider<IApiService>, Jab.IServiceProvider<IRegistrationUserDialogService>, Jab.IServiceProvider<IApplicationExceptionFactory>, Jab.IServiceProvider<IErrorPublisher>, Jab.IServiceProvider<IErrorReporter>, Jab.IServiceProvider<ICoreApplication>, Jab.IServiceProvider<IRegistrationCallbackHandler>, Jab.IServiceProvider<NotificationCallbackHandler>, Jab.IServiceProvider<ProContentClientInformationProvider>, Jab.IServiceProvider<IInternetAccess>, Jab.IServiceProvider<IHyperlinkService>, Jab.IServiceProvider<JsonWebTokenHandler>, Jab.IServiceProvider<RegistrationStateHandler>, Jab.IServiceProvider<IRegistrationStateProvider>, Jab.IServiceProvider<IActivationKeyProvider>, Jab.IServiceProvider<IRegistrationWebResourceService>, Jab.IServiceProvider<IPopUpAlertFactory>, Jab.IServiceProvider<IAfterStartupCompleteQueue>, Jab.IServiceProvider<UserMessageHandler>, Jab.IServiceProvider<Func<IMainLayoutVM>>, Jab.INamedServiceProvider<System.Action>, Jab.IServiceProvider<IWebSourceProvider>, Jab.IServiceProvider<IRegistrationCallbackDialogProvider>, Jab.IServiceProvider<IEmbeddedResourceReader>, Jab.IServiceProvider<IForceQuitEventPublisher>, Jab.IServiceProvider<IForcedShutdownMessageProvider>, Jab.IServiceProvider<IInternetAccessCheck>, Jab.IServiceProvider<IEnumerable<IRegistrationCallbackHandler>>, Jab.IServiceProvider<RegistrationClient>, Jab.IServiceProvider<IRegistrationClient>, Jab.IServiceProvider<IRegistrationOperationFactory>, Jab.INamedServiceProvider<IOAuth2AuthorizationStore>, Jab.INamedServiceProvider<IOAuth2ClientInfoProvider>, Jab.IServiceProvider<IProContentConsumer>, Jab.IServiceProvider<IProContentDownloadFailedDialogService>, Jab.IServiceProvider<IProContentUserInteractionBehavior>, Jab.IServiceProvider<IDelayFactory>, Jab.IServiceProvider<IDownloadProcessFactory>, Jab.IServiceProvider<IDownloadItemFactory>, Jab.IServiceProvider<IProContentAnalyticEventsPublisher>, Jab.IServiceProvider<IDownloadManager>, Jab.IServiceProvider<IUnObservedProContentDownloadProcessFactory>, Jab.IServiceProvider<IProContentAssetProvider>, Jab.IServiceProvider<IRemoteFileLoader>, Jab.IServiceProvider<IAudioOutputDeviceCollection>, Jab.IServiceProvider<IAudioSetup>, Jab.IServiceProvider<IAudioMapRecallService<DeviceChannel, Bus>>, Jab.IServiceProvider<ILiveVideoInputCollection>, Jab.IServiceProvider<IMediaFactory>, Jab.IServiceProvider<ITextFillMediaFactory>, Jab.IServiceProvider<ITextDocumentFactory>, Jab.IServiceProvider<IEntityFactory>, Jab.IServiceProvider<IDocumentFactory>, Jab.IServiceProvider<IDocumentService>, Jab.IServiceProvider<IEntityFileLockFactory>, Jab.IServiceProvider<ICommonPathsWrapper>, Jab.IServiceProvider<ICollaborationPeerIdProvider>, Jab.IServiceProvider<IThreadPoolScheduler>, Jab.IServiceProvider<IMediaService>, Jab.IServiceProvider<ILocalWorkspaceStatsEventPublisher>, Jab.IServiceProvider<IZipHelper>, Jab.IServiceProvider<IWorkspaceService>, Jab.IServiceProvider<ICloudDiagnosticsPublisher>, Jab.IServiceProvider<IEntityDocumentRegistry>, Jab.IServiceProvider<IEntityDocumentSyncerFactory>, Jab.IServiceProvider<IMergedEntityFactory>, Jab.IServiceProvider<IProPresenterDOFactoryProvider>, Jab.IServiceProvider<IMessageDialogService>, Jab.IServiceProvider<IPresentationFactory>, Jab.IServiceProvider<IPowerPointImageLoader>, Jab.IServiceProvider<IPowerPointEvents>, Jab.IServiceProvider<TypefaceLibrary>, Jab.IServiceProvider<IFontDetector>, Jab.IServiceProvider<IFontDetectionSessionFactory>, Jab.IServiceProvider<IMissingFontService>, Jab.IServiceProvider<IProPresenterCueFactory>, Jab.IServiceProvider<IFontReplacementEventPublisher>, Jab.IServiceProvider<IMissingFontWindowProvider>, Jab.IServiceProvider<ICorePowerPointImportService>, Jab.IServiceProvider<IPowerPointImportService>, Jab.IServiceProvider<IImportHelperServices>, Jab.IServiceProvider<IImportLocationSelectionDialogService>, Jab.IServiceProvider<IManageMediaAutoMaticallyProvider>, Jab.IServiceProvider<IFileCreator>, Jab.IServiceProvider<ISyncDataFactory>, Jab.IServiceProvider<IScreenArrangementFactory>, Jab.IServiceProvider<IAudioSettingsAnalyticsEventPublisher>, Jab.IServiceProvider<IAudioInputCollection>, Jab.IServiceProvider<ICrdtProtoDirectoryFileScanner>, Jab.IServiceProvider<IMaskCollection>, Jab.IServiceProvider<StagePresentation>, Jab.IServiceProvider<ILocalDocumentSyncerFactory>, Jab.IServiceProvider<IOutputConfiguration>, Jab.IServiceProvider<ICollectionStorage>, Jab.IServiceProvider<IImportProcessFactory>, Jab.IServiceProvider<IAsyncFileImporter>, Jab.IServiceProvider<IMigrationSource>, Jab.IServiceProvider<INetwork>, Jab.IServiceProvider<ITimecodeSettingsRepository>, Jab.IServiceProvider<IImport>, Jab.IServiceProvider<IStoredPcoOptions>, Jab.IServiceProvider<ISongSelectConsumer>, Jab.IServiceProvider<IReportRepository>, Jab.IServiceProvider<IGeneral>, Jab.IServiceProvider<IEnableAnalyticsProvider>, Jab.IServiceProvider<IDisplay>, Jab.IServiceProvider<ISync>, Jab.IServiceProvider<ILayout>, Jab.IServiceProvider<IPlaylistActionValidatorFactory>, Jab.IServiceProvider<IActionBinderFactory>, Jab.IServiceProvider<IEncoderValidator>, Jab.IServiceProvider<IThemeImportProcessFactory>, Jab.IServiceProvider<IThemeAnalyiticEvents>, Jab.IServiceProvider<IDxDiagReaderFactory>, Jab.INamedServiceProvider<IIdProvider>, Jab.IServiceProvider<ISystemInfoProvider>, Jab.IServiceProvider<IApplicationLaunchEventPublisher>, Jab.IServiceProvider<ICaptureAnalyticEventsPublisher>, Jab.IServiceProvider<IStartupSettingsEventsPublisher>, Jab.IServiceProvider<IUiPreferencesAnalyticEventsPublisher>, Jab.IServiceProvider<ITestPatternAnalyticEventsPublisher>, Jab.IServiceProvider<IWelcomeAnalyticEventsPublisher>, Jab.IServiceProvider<ITimecodeAnalyticsEvents>, Jab.IServiceProvider<IPlaybackMarkerAnalyticsEvents>, Jab.IServiceProvider<ITimelineAnalyticsEvents>, Jab.IServiceProvider<ICCLIReportAnalyticsEvents>, Jab.IServiceProvider<IMediaCleanupSizeEventPublisher>, Jab.IServiceProvider<IMediaAnalyticsSender>, Jab.IServiceProvider<IWorkspaceAnalyticsEventPublisher>, Jab.IServiceProvider<ICloudOnboardingAnalyticsEventPublisher>, Jab.IServiceProvider<IFileDownloadObserverFactory>, Jab.IServiceProvider<IProContentDownloadProcessFactory>, Jab.IServiceProvider<IStopwatchFactory>, Jab.IServiceProvider<ICacheFactory>, Jab.IServiceProvider<IProContentProvider>, Jab.IServiceProvider<IUriCacheService<IReadOnlyList<IAnimationFrame>>>, Jab.IServiceProvider<IOutputRepository>, Jab.IServiceProvider<ICommunicationOutput>, Jab.IServiceProvider<IOutputService>, Jab.IServiceProvider<IErrorPrompt>, Jab.IServiceProvider<IResiPlugin>, Jab.IServiceProvider<IResiCustomEndpointsStore>, Jab.IServiceProvider<IResiEndpoints>, Jab.IServiceProvider<IResiWebClient>, Jab.IServiceProvider<IMessages<AppMessages>>, Jab.IServiceProvider<IUpdateClient>, Jab.IServiceProvider<ITestPatternPropertyFactory>, Jab.IServiceProvider<ITestPatternDefinitionFactory>, Jab.IServiceProvider<ITestPatternStateFactory>, Jab.IServiceProvider<ITestPatternPersistence>, Jab.IServiceProvider<ITestPatternService>, Jab.IServiceProvider<IFileProvider>, Jab.IServiceProvider<ISyncDataProvider>, Jab.INamedServiceProvider<ISyncRepository<ISyncData>>, Jab.IServiceProvider<ISyncActionProvider>, Jab.IServiceProvider<IAppContinuationService>, Jab.IServiceProvider<IAppInstallerFactory>, Jab.IServiceProvider<IAppDownloadFactory>, Jab.IServiceProvider<IAppUpdateUserDialogService>, Jab.IServiceProvider<IAppUpdateService>, Jab.IServiceProvider<IIndexingService>, Jab.IServiceProvider<IPresentationCapableSyncDataFactory>, Jab.IServiceProvider<IBibleDataStore>, Jab.IServiceProvider<IBibleProvider>, Jab.IServiceProvider<IMultiTracksConsumer>, Jab.IServiceProvider<IAuthenticatorFactory>, Jab.IServiceProvider<IPCOConsumer>, Jab.IServiceProvider<IPCOUpdater>, Jab.IServiceProvider<ThumbnailViewSettings>, Jab.IServiceProvider<IExportProcessFactory>, Jab.IServiceProvider<IInputActions>, Jab.IServiceProvider<IMediaImportService>, Jab.IServiceProvider<IMediaFileProvider>, Jab.IServiceProvider<IWorkspaceInspectionService>, Jab.IServiceProvider<ICloudWorkspaceService>, Jab.IServiceProvider<ICloudConversionService>, Jab.IServiceProvider<ICloudOnboardingService>, Jab.IServiceProvider<IMatchSongsInteractor>, Jab.IServiceProvider<IWorkspaceDocumentOrchestrator>, Jab.IServiceProvider<ThemeCollection>, Jab.IServiceProvider<IThemeCollection>, Jab.IServiceProvider<IFileFilterProvider>, Jab.IServiceProvider<IFileUtility>, Jab.IServiceProvider<IProcessHelper>, Jab.IServiceProvider<INetworkChange>, Jab.IServiceProvider<IFileObservatory>, Jab.IServiceProvider<ISettingsSearchFactory>, Jab.IServiceProvider<INetworkDialogService>, Jab.IServiceProvider<IMediaCleanupPrompt>, Jab.IServiceProvider<IMidiDeviceSettingsVM>, Jab.IServiceProvider<IMidiWindowProvider>, Jab.IServiceProvider<IFileSelectorService>, Jab.IServiceProvider<ICCLIReportPrompt>, Jab.IServiceProvider<INdiInputsSettingsDialogService>, Jab.IServiceProvider<IAirCastPrompt>, Jab.IServiceProvider<IAirCastConfiguration>, Jab.IServiceProvider<IInstallFileExecutor>, Jab.IServiceProvider<IAirCastPluginDownload>, Jab.IServiceProvider<ICCLIReportCollectionVM>, Jab.IServiceProvider<ICopyrightSettingsVM>, Jab.IServiceProvider<INetworkCommandFactory>, Jab.IServiceProvider<INetworkCommandTrigger>, Jab.IServiceProvider<INetworkTriggerDataTransferFactory>, Jab.IServiceProvider<IResiController>, Jab.IServiceProvider<ICrashRecovery>, Jab.IServiceProvider<ICapturePrompt>, Jab.IServiceProvider<CaptureController>, Jab.IServiceProvider<ICaptureService>, Jab.IServiceProvider<ITimedPlaybackRepository>, Jab.IServiceProvider<ITimelineService>, Jab.IServiceProvider<ITimecodeService>, Jab.IServiceProvider<ITimelineManager>, Jab.IServiceProvider<ITransferHandlerFactory>, Jab.IServiceProvider<CoreManager>, Jab.IServiceProvider<ICoreManager>, Jab.IServiceProvider<IGeneralSettingsVM>, Jab.IServiceProvider<ICommandSender>, Jab.IServiceProvider<IServerStateHandler>, Jab.IServiceProvider<INetworkEnvironment>, Jab.IServiceProvider<ILinkRequestFactory>, Jab.IServiceProvider<INetworkLinkService>, Jab.IServiceProvider<INetworkLinkPrompt>, Jab.IServiceProvider<INetworkLinkVM>, Jab.IServiceProvider<INetworkSettingsVM>, Jab.IServiceProvider<IRegistrationUnlockCodeVM>, Jab.IServiceProvider<IRegistrationSubpageVMFactory>, Jab.IServiceProvider<IOrganizationConsumer>, Jab.IServiceProvider<IUserAvatarProvider>, Jab.IServiceProvider<IRegistrationMainPageVM>, Jab.IServiceProvider<IAccountCenterVM>, Jab.IServiceProvider<IUpdatesSettingsVM>, Jab.IServiceProvider<IClockSourceProvider>, Jab.IServiceProvider<IClockSourceService>, Jab.IServiceProvider<IClockSourceVM>, Jab.IServiceProvider<IScreenSettingsVM>, Jab.IServiceProvider<IInputsSettingsService>, Jab.IServiceProvider<IVideoInputsSettingsVM>, Jab.IServiceProvider<IVideoInputItemVMFactory>, Jab.IServiceProvider<IAudioInputsSettingsVM>, Jab.IServiceProvider<INdiInputsSettingsVM>, Jab.IServiceProvider<IInputsSettingsVM>, Jab.IServiceProvider<IDevicesSettingsVM>, Jab.IServiceProvider<IMediaSettingsVMFactory>, Jab.IServiceProvider<IMediaSearchPathsSettingsVM>, Jab.IServiceProvider<IMediaFilesProvider>, Jab.IServiceProvider<IMediaCleanupService>, Jab.IServiceProvider<IMediaCleanupVM>, Jab.IServiceProvider<IMediaSettingsVM>, Jab.IServiceProvider<IAudioSettingsVM>, Jab.IServiceProvider<IImportSettingsVM>, Jab.IServiceProvider<IPlanningCenterSettingsVM>, Jab.IServiceProvider<IMultiTracksSettingsVM>, Jab.IServiceProvider<IAutoReportDialogPrompt>, Jab.IServiceProvider<ISongSelectSettingsVM>, Jab.IServiceProvider<IResiUpdateVM>, Jab.IServiceProvider<ILoginDialogFactory>, Jab.IServiceProvider<IResiPrompt>, Jab.IServiceProvider<IResiAuthorizationInteractor>, Jab.IServiceProvider<IResiSettingsVM>, Jab.IServiceProvider<IIntegrationsSettingsVM>, Jab.IServiceProvider<IGroupLabelItemVMFactory>, Jab.IServiceProvider<IGroupsSettingsVM>, Jab.IServiceProvider<ILabelItemVMFactory>, Jab.IServiceProvider<ILabelsSettingsVM>, Jab.IServiceProvider<ISyncController>, Jab.IServiceProvider<ISyncSettingsVM>, Jab.IServiceProvider<IEnumerable<ISettingsListItem>>, Jab.IServiceProvider<ISettingsSearchEngine>, Jab.IServiceProvider<ISettingsSearchVM>, Jab.IServiceProvider<ISettingsNavigationVM>, Jab.IServiceProvider<ISettingsVM>, Jab.IServiceProvider<INotificationVMFactory>, Jab.IServiceProvider<IRegistrationRequestSender>, Jab.IServiceProvider<INotificationCallbackHandler>, Jab.IServiceProvider<INotificationService>, Jab.IServiceProvider<INotificationCollectionVM>, Jab.IServiceProvider<IChangeDirectoryProcessFactory>, Jab.IServiceProvider<IChangeWorkspaceHandler>, Jab.IServiceProvider<CloudOnboardingVM>, Jab.IServiceProvider<ICloudOnboardingVM>, Jab.IServiceProvider<ICloudOnboardingShellNavigator>, Jab.IServiceProvider<ICloudOnboardingEligibilityVM>, Jab.IServiceProvider<ICloudOnboardingManageMediaVM>, Jab.IServiceProvider<ICloudOnboardingPricingVM>, Jab.IServiceProvider<ICloudOnboardingDoneVM>, Jab.IServiceProvider<ICloudOnboardingLocalWorkspacesVM>, Jab.IServiceProvider<ICloudTeaseVM>, Jab.IServiceProvider<ICloudTeaseWindowProvider>, Jab.IServiceProvider<IManageWorkspacesWindowProvider>, Jab.IServiceProvider<IMissingFontVM>, Jab.IServiceProvider<ICalendarPrompt>, Jab.IServiceProvider<IRTMPPrompt>, Jab.IServiceProvider<IProContentDialogService>, Jab.IServiceProvider<IMediaImportDownloadDialogService>, Jab.IServiceProvider<IDownloadsDialogService>, Jab.IServiceProvider<IMediaCueThumbnailOverlayVMFactory>, Jab.IServiceProvider<IDownloadVMsFactory>, Jab.IServiceProvider<IPropPrompts>, Jab.IServiceProvider<IHardwareAlphaConfigurationVMFactory>, Jab.IServiceProvider<IAlphaKeySettingsVMFactory>, Jab.IServiceProvider<ICaptureController>, Jab.IServiceProvider<IResiService>, Jab.IServiceProvider<IUserFeedbackConsumer>, Jab.IServiceProvider<IBuildAppMetaDataFile>, Jab.IServiceProvider<IUserAttachmentVMFactory>, Jab.IServiceProvider<IAttachmentsUploader>, Jab.IServiceProvider<IAttachmentUploadJobFactory>, Jab.IServiceProvider<IFeedbackVM>, Jab.IServiceProvider<ICrashReportingVM>, Jab.IServiceProvider<IAttachmentUploadVM>, Jab.IServiceProvider<ICrashReportUserFeedbackDialogProvider>, Jab.INamedServiceProvider<System.IO.Stream>, Jab.IServiceProvider<IWhatsNewContentProviderFromJson>, Jab.IServiceProvider<IFeatureFactory>, Jab.IServiceProvider<IWhatsNewV2VM>, Jab.IServiceProvider<IMediaActionService>, Jab.IServiceProvider<ITimelineVMFactory>, Jab.IServiceProvider<ITimelineItemVMFactory>, Jab.IServiceProvider<IWorkspaceItemVMFactory>, Jab.IServiceProvider<IActionsMenuVMFactory>, Jab.IServiceProvider<IOutputScreenVMFactory>, Jab.IServiceProvider<IScreenSelectorVM>, Jab.IServiceProvider<IWindowedOutputVM>, Jab.IServiceProvider<IOutputPreviewVMFactory>, Jab.IServiceProvider<IInternalCoreManager>, Jab.IServiceProvider<ITriggeringFactory>, Jab.IServiceProvider<ICalendarService>, Jab.IServiceProvider<IExportService>, Jab.IServiceProvider<ILibraryService>, Jab.IServiceProvider<IClipboardProvider>, Jab.IServiceProvider<IPasteStrategy>, Jab.IServiceProvider<IEditorService>, Jab.IServiceProvider<PlaylistTemplateCollection>, Jab.IServiceProvider<IPlaylistTemplatesService>, Jab.IServiceProvider<ISizeProvider>, Jab.IServiceProvider<IProPresenterCueVMFactory>, Jab.IServiceProvider<IProContentDownloader>, Jab.IServiceProvider<IMacroPrompt>, Jab.IServiceProvider<ISlidePreviewService>, Jab.IServiceProvider<PropAutoClearHandler>, Jab.IServiceProvider<IPropAutoClearService>, Jab.IServiceProvider<ILegacyPurchaseBiblesDialogService>, Jab.IServiceProvider<IMediaValidator>, Jab.IServiceProvider<IMediaProvider>, Jab.IServiceProvider<IToastNotificationService>, Jab.IServiceProvider<IWorkspaceDeletedPrompt>, Jab.IServiceProvider<IWorkspaceCollectionVM>, Jab.IServiceProvider<IMainLayoutVM>, Jab.IServiceProvider<IThemeSlideMenuVM>, Jab.IServiceProvider<IArrangementVM>, Jab.IServiceProvider<ITimecodeItemVMFactory>, Jab.IServiceProvider<ITimecodeVM>, Jab.IServiceProvider<IHeaderContentContextMenuVM>, Jab.IServiceProvider<IWorkspaceSwitchValidator>, Jab.IServiceProvider<IApplicationFailureMessageService>, Jab.IServiceProvider<IFeatureFlagService>, Jab.IServiceProvider<ISpellChecker>, Jab.IServiceProvider<IReceiveService>, Jab.IServiceProvider<IPresentationHandlerOperationService>, Jab.INamedServiceProvider<IApplicationEventHandler>, Jab.IServiceProvider<ISettingsDataToCoreSender>, Jab.IServiceProvider<IAPIv1Dependencies>, Jab.IServiceProvider<ISharedData<AppData>>, Jab.IServiceProvider<Func<IRegistrationOperationFactory>>, Jab.IServiceProvider<IStartupArgumentsExecutor>, Jab.INamedServiceProvider<Func<bool>>, Jab.IServiceProvider<IMessageHandler>, Jab.IServiceProvider<IDocumentDiagnosticsProvider>, Jab.IServiceProvider<ILaunchPopUpProvider>, Jab.IServiceProvider<IPropAutoClearHandler>, Jab.IServiceProvider<ISendDataResponseHandlerProvider>, Jab.IServiceProvider<IDataProcessor<SendDataResponse>>, Jab.IServiceProvider<MediaInspectorConverter>, Jab.IServiceProvider<WarningTooltipConverter>, Jab.IServiceProvider<WebFillBrowserFactory>, Jab.IServiceProvider<IWebFillBrowserFactory>, Jab.IServiceProvider<IActionDialogService>, Jab.IServiceProvider<ITemplateVM>, Jab.IServiceProvider<Func<MainWindow>>, Jab.IServiceProvider<IInstanceValidator>, Jab.IServiceProvider<IWorkspaceInfoDumper>, Jab.IServiceProvider<MainWindow>, Jab.IServiceProvider<ICloudOnboardingWindowProvider>, Jab.IServiceProvider<IMediaServiceV1>, Jab.IServiceProvider<IMediaServiceV2>, Jab.INamedServiceProvider<IProcessSupervisor>, Jab.IServiceProvider<IActionFactoryService>, Jab.IServiceProvider<IWorkspacesVM>, Jab.IServiceProvider<IEnumerable<IStartupArgumentsExecutor>>, Jab.IServiceProvider<IEnumerable<IMessageHandler>>, Jab.IServiceProvider<IServiceProvider>, Jab.IServiceProvider<IServiceScopeFactory>, Jab.IServiceProvider<IServiceProviderIsService>
{
	public class Scope : IDisposable, IAsyncDisposable, IServiceProvider, IKeyedServiceProvider, IServiceScope, Jab.IServiceProvider<IPhysicalDeviceProvider>, Jab.IServiceProvider<IDatabaseService>, Jab.IServiceProvider<IFileWatcherFactory>, Jab.IServiceProvider<IFileSystem>, Jab.IServiceProvider<IUiDispatcher>, Jab.IServiceProvider<ITimerFactory>, Jab.IServiceProvider<IDebouncerFactory>, Jab.IServiceProvider<IThemeRepo>, Jab.IServiceProvider<IPropsRepo>, Jab.IServiceProvider<IMacrosRepo>, Jab.IServiceProvider<ILibraryPlaylistRepo>, Jab.IServiceProvider<IVisualPlaylistRepo>, Jab.IServiceProvider<IProPresenterResourceService>, Jab.IServiceProvider<IThemeService>, Jab.IServiceProvider<IZipService>, Jab.IServiceProvider<IMessageService>, Jab.IServiceProvider<IFileService>, Jab.IServiceProvider<ILogger>, Jab.IServiceProvider<ILocalization>, Jab.IServiceProvider<IAdvanced>, Jab.IServiceProvider<IProtoService>, Jab.IServiceProvider<ISqliteMigrationService>, Jab.IServiceProvider<ICookieManagerService>, Jab.IServiceProvider<App>, Jab.IServiceProvider<IApp>, Jab.IServiceProvider<IProCoreInstance>, Jab.IServiceProvider<IFlagService>, Jab.IServiceProvider<ssAPIOutput>, Jab.IServiceProvider<ITransitionDescriptionCollection>, Jab.IServiceProvider<IImageLoader>, Jab.IServiceProvider<IMediaMetadataCacheRepository>, Jab.IServiceProvider<IMediaMetadataCacheService>, Jab.IServiceProvider<IAsyncExecutor>, Jab.IServiceProvider<IUiScheduler>, Jab.IServiceProvider<IMetadataLoader>, Jab.IServiceProvider<ITrackedMediaHelpers>, Jab.IServiceProvider<IAssemblyInfoProvider>, Jab.INamedServiceProvider<System.Version>, Jab.IServiceProvider<IVersionInfoProvider>, Jab.IServiceProvider<IRestClientFactory>, Jab.IServiceProvider<ISemaphoreFactory>, Jab.IServiceProvider<ICurrentTime>, Jab.IServiceProvider<IFileSystemUriCacheServiceFactory>, Jab.IServiceProvider<IImageDecoder>, Jab.IServiceProvider<IBitmapImageDecoder>, Jab.IServiceProvider<IUriCacheService<NullableBitmapSource>>, Jab.IServiceProvider<ICurrentTimeOffset>, Jab.IServiceProvider<IAuthenticatingApiConsumerFactory>, Jab.IServiceProvider<IApiService>, Jab.IServiceProvider<IRegistrationUserDialogService>, Jab.IServiceProvider<IApplicationExceptionFactory>, Jab.IServiceProvider<IErrorPublisher>, Jab.IServiceProvider<IErrorReporter>, Jab.IServiceProvider<ICoreApplication>, Jab.IServiceProvider<IRegistrationCallbackHandler>, Jab.IServiceProvider<NotificationCallbackHandler>, Jab.IServiceProvider<ProContentClientInformationProvider>, Jab.IServiceProvider<IInternetAccess>, Jab.IServiceProvider<IHyperlinkService>, Jab.IServiceProvider<JsonWebTokenHandler>, Jab.IServiceProvider<RegistrationStateHandler>, Jab.IServiceProvider<IRegistrationStateProvider>, Jab.IServiceProvider<IActivationKeyProvider>, Jab.IServiceProvider<IRegistrationWebResourceService>, Jab.IServiceProvider<IPopUpAlertFactory>, Jab.IServiceProvider<IAfterStartupCompleteQueue>, Jab.IServiceProvider<UserMessageHandler>, Jab.IServiceProvider<Func<IMainLayoutVM>>, Jab.INamedServiceProvider<System.Action>, Jab.IServiceProvider<IWebSourceProvider>, Jab.IServiceProvider<IRegistrationCallbackDialogProvider>, Jab.IServiceProvider<IEmbeddedResourceReader>, Jab.IServiceProvider<IForceQuitEventPublisher>, Jab.IServiceProvider<IForcedShutdownMessageProvider>, Jab.IServiceProvider<IInternetAccessCheck>, Jab.IServiceProvider<IEnumerable<IRegistrationCallbackHandler>>, Jab.IServiceProvider<RegistrationClient>, Jab.IServiceProvider<IRegistrationClient>, Jab.IServiceProvider<IRegistrationOperationFactory>, Jab.INamedServiceProvider<IOAuth2AuthorizationStore>, Jab.INamedServiceProvider<IOAuth2ClientInfoProvider>, Jab.IServiceProvider<IProContentConsumer>, Jab.IServiceProvider<IProContentDownloadFailedDialogService>, Jab.IServiceProvider<IProContentUserInteractionBehavior>, Jab.IServiceProvider<IDelayFactory>, Jab.IServiceProvider<IDownloadProcessFactory>, Jab.IServiceProvider<IDownloadItemFactory>, Jab.IServiceProvider<IProContentAnalyticEventsPublisher>, Jab.IServiceProvider<IDownloadManager>, Jab.IServiceProvider<IUnObservedProContentDownloadProcessFactory>, Jab.IServiceProvider<IProContentAssetProvider>, Jab.IServiceProvider<IRemoteFileLoader>, Jab.IServiceProvider<IAudioOutputDeviceCollection>, Jab.IServiceProvider<IAudioSetup>, Jab.IServiceProvider<IAudioMapRecallService<DeviceChannel, Bus>>, Jab.IServiceProvider<ILiveVideoInputCollection>, Jab.IServiceProvider<IMediaFactory>, Jab.IServiceProvider<ITextFillMediaFactory>, Jab.IServiceProvider<ITextDocumentFactory>, Jab.IServiceProvider<IEntityFactory>, Jab.IServiceProvider<IDocumentFactory>, Jab.IServiceProvider<IDocumentService>, Jab.IServiceProvider<IEntityFileLockFactory>, Jab.IServiceProvider<ICommonPathsWrapper>, Jab.IServiceProvider<ICollaborationPeerIdProvider>, Jab.IServiceProvider<IThreadPoolScheduler>, Jab.IServiceProvider<IMediaService>, Jab.IServiceProvider<ILocalWorkspaceStatsEventPublisher>, Jab.IServiceProvider<IZipHelper>, Jab.IServiceProvider<IWorkspaceService>, Jab.IServiceProvider<ICloudDiagnosticsPublisher>, Jab.IServiceProvider<IEntityDocumentRegistry>, Jab.IServiceProvider<IEntityDocumentSyncerFactory>, Jab.IServiceProvider<IMergedEntityFactory>, Jab.IServiceProvider<IProPresenterDOFactoryProvider>, Jab.IServiceProvider<IMessageDialogService>, Jab.IServiceProvider<IPresentationFactory>, Jab.IServiceProvider<IPowerPointImageLoader>, Jab.IServiceProvider<IPowerPointEvents>, Jab.IServiceProvider<TypefaceLibrary>, Jab.IServiceProvider<IFontDetector>, Jab.IServiceProvider<IFontDetectionSessionFactory>, Jab.IServiceProvider<IMissingFontService>, Jab.IServiceProvider<IProPresenterCueFactory>, Jab.IServiceProvider<IFontReplacementEventPublisher>, Jab.IServiceProvider<IMissingFontWindowProvider>, Jab.IServiceProvider<ICorePowerPointImportService>, Jab.IServiceProvider<IPowerPointImportService>, Jab.IServiceProvider<IImportHelperServices>, Jab.IServiceProvider<IImportLocationSelectionDialogService>, Jab.IServiceProvider<IManageMediaAutoMaticallyProvider>, Jab.IServiceProvider<IFileCreator>, Jab.IServiceProvider<ISyncDataFactory>, Jab.IServiceProvider<IScreenArrangementFactory>, Jab.IServiceProvider<IAudioSettingsAnalyticsEventPublisher>, Jab.IServiceProvider<IAudioInputCollection>, Jab.IServiceProvider<ICrdtProtoDirectoryFileScanner>, Jab.IServiceProvider<IMaskCollection>, Jab.IServiceProvider<StagePresentation>, Jab.IServiceProvider<ILocalDocumentSyncerFactory>, Jab.IServiceProvider<IOutputConfiguration>, Jab.IServiceProvider<ICollectionStorage>, Jab.IServiceProvider<IImportProcessFactory>, Jab.IServiceProvider<IAsyncFileImporter>, Jab.IServiceProvider<IMigrationSource>, Jab.IServiceProvider<INetwork>, Jab.IServiceProvider<ITimecodeSettingsRepository>, Jab.IServiceProvider<IImport>, Jab.IServiceProvider<IStoredPcoOptions>, Jab.IServiceProvider<ISongSelectConsumer>, Jab.IServiceProvider<IReportRepository>, Jab.IServiceProvider<IGeneral>, Jab.IServiceProvider<IEnableAnalyticsProvider>, Jab.IServiceProvider<IDisplay>, Jab.IServiceProvider<ISync>, Jab.IServiceProvider<ILayout>, Jab.IServiceProvider<IPlaylistActionValidatorFactory>, Jab.IServiceProvider<IActionBinderFactory>, Jab.IServiceProvider<IEncoderValidator>, Jab.IServiceProvider<IThemeImportProcessFactory>, Jab.IServiceProvider<IThemeAnalyiticEvents>, Jab.IServiceProvider<IDxDiagReaderFactory>, Jab.INamedServiceProvider<IIdProvider>, Jab.IServiceProvider<ISystemInfoProvider>, Jab.IServiceProvider<IApplicationLaunchEventPublisher>, Jab.IServiceProvider<ICaptureAnalyticEventsPublisher>, Jab.IServiceProvider<IStartupSettingsEventsPublisher>, Jab.IServiceProvider<IUiPreferencesAnalyticEventsPublisher>, Jab.IServiceProvider<ITestPatternAnalyticEventsPublisher>, Jab.IServiceProvider<IWelcomeAnalyticEventsPublisher>, Jab.IServiceProvider<ITimecodeAnalyticsEvents>, Jab.IServiceProvider<IPlaybackMarkerAnalyticsEvents>, Jab.IServiceProvider<ITimelineAnalyticsEvents>, Jab.IServiceProvider<ICCLIReportAnalyticsEvents>, Jab.IServiceProvider<IMediaCleanupSizeEventPublisher>, Jab.IServiceProvider<IMediaAnalyticsSender>, Jab.IServiceProvider<IWorkspaceAnalyticsEventPublisher>, Jab.IServiceProvider<ICloudOnboardingAnalyticsEventPublisher>, Jab.IServiceProvider<IFileDownloadObserverFactory>, Jab.IServiceProvider<IProContentDownloadProcessFactory>, Jab.IServiceProvider<IStopwatchFactory>, Jab.IServiceProvider<ICacheFactory>, Jab.IServiceProvider<IProContentProvider>, Jab.IServiceProvider<IUriCacheService<IReadOnlyList<IAnimationFrame>>>, Jab.IServiceProvider<IOutputRepository>, Jab.IServiceProvider<ICommunicationOutput>, Jab.IServiceProvider<IOutputService>, Jab.IServiceProvider<IErrorPrompt>, Jab.IServiceProvider<IResiPlugin>, Jab.IServiceProvider<IResiCustomEndpointsStore>, Jab.IServiceProvider<IResiEndpoints>, Jab.IServiceProvider<IResiWebClient>, Jab.IServiceProvider<IMessages<AppMessages>>, Jab.IServiceProvider<IUpdateClient>, Jab.IServiceProvider<ITestPatternPropertyFactory>, Jab.IServiceProvider<ITestPatternDefinitionFactory>, Jab.IServiceProvider<ITestPatternStateFactory>, Jab.IServiceProvider<ITestPatternPersistence>, Jab.IServiceProvider<ITestPatternService>, Jab.IServiceProvider<IFileProvider>, Jab.IServiceProvider<ISyncDataProvider>, Jab.INamedServiceProvider<ISyncRepository<ISyncData>>, Jab.IServiceProvider<ISyncActionProvider>, Jab.IServiceProvider<IAppContinuationService>, Jab.IServiceProvider<IAppInstallerFactory>, Jab.IServiceProvider<IAppDownloadFactory>, Jab.IServiceProvider<IAppUpdateUserDialogService>, Jab.IServiceProvider<IAppUpdateService>, Jab.IServiceProvider<IIndexingService>, Jab.IServiceProvider<IPresentationCapableSyncDataFactory>, Jab.IServiceProvider<IBibleDataStore>, Jab.IServiceProvider<IBibleProvider>, Jab.IServiceProvider<IMultiTracksConsumer>, Jab.IServiceProvider<IAuthenticatorFactory>, Jab.IServiceProvider<IPCOConsumer>, Jab.IServiceProvider<IPCOUpdater>, Jab.IServiceProvider<ThumbnailViewSettings>, Jab.IServiceProvider<IExportProcessFactory>, Jab.IServiceProvider<IInputActions>, Jab.IServiceProvider<IMediaImportService>, Jab.IServiceProvider<IMediaFileProvider>, Jab.IServiceProvider<IWorkspaceInspectionService>, Jab.IServiceProvider<ICloudWorkspaceService>, Jab.IServiceProvider<ICloudConversionService>, Jab.IServiceProvider<ICloudOnboardingService>, Jab.IServiceProvider<IMatchSongsInteractor>, Jab.IServiceProvider<IWorkspaceDocumentOrchestrator>, Jab.IServiceProvider<ThemeCollection>, Jab.IServiceProvider<IThemeCollection>, Jab.IServiceProvider<IFileFilterProvider>, Jab.IServiceProvider<IFileUtility>, Jab.IServiceProvider<IProcessHelper>, Jab.IServiceProvider<INetworkChange>, Jab.IServiceProvider<IFileObservatory>, Jab.IServiceProvider<ISettingsSearchFactory>, Jab.IServiceProvider<INetworkDialogService>, Jab.IServiceProvider<IMediaCleanupPrompt>, Jab.IServiceProvider<IMidiDeviceSettingsVM>, Jab.IServiceProvider<IMidiWindowProvider>, Jab.IServiceProvider<IFileSelectorService>, Jab.IServiceProvider<ICCLIReportPrompt>, Jab.IServiceProvider<INdiInputsSettingsDialogService>, Jab.IServiceProvider<IAirCastPrompt>, Jab.IServiceProvider<IAirCastConfiguration>, Jab.IServiceProvider<IInstallFileExecutor>, Jab.IServiceProvider<IAirCastPluginDownload>, Jab.IServiceProvider<ICCLIReportCollectionVM>, Jab.IServiceProvider<ICopyrightSettingsVM>, Jab.IServiceProvider<INetworkCommandFactory>, Jab.IServiceProvider<INetworkCommandTrigger>, Jab.IServiceProvider<INetworkTriggerDataTransferFactory>, Jab.IServiceProvider<IResiController>, Jab.IServiceProvider<ICrashRecovery>, Jab.IServiceProvider<ICapturePrompt>, Jab.IServiceProvider<CaptureController>, Jab.IServiceProvider<ICaptureService>, Jab.IServiceProvider<ITimedPlaybackRepository>, Jab.IServiceProvider<ITimelineService>, Jab.IServiceProvider<ITimecodeService>, Jab.IServiceProvider<ITimelineManager>, Jab.IServiceProvider<ITransferHandlerFactory>, Jab.IServiceProvider<CoreManager>, Jab.IServiceProvider<ICoreManager>, Jab.IServiceProvider<IGeneralSettingsVM>, Jab.IServiceProvider<ICommandSender>, Jab.IServiceProvider<IServerStateHandler>, Jab.IServiceProvider<INetworkEnvironment>, Jab.IServiceProvider<ILinkRequestFactory>, Jab.IServiceProvider<INetworkLinkService>, Jab.IServiceProvider<INetworkLinkPrompt>, Jab.IServiceProvider<INetworkLinkVM>, Jab.IServiceProvider<INetworkSettingsVM>, Jab.IServiceProvider<IRegistrationUnlockCodeVM>, Jab.IServiceProvider<IRegistrationSubpageVMFactory>, Jab.IServiceProvider<IOrganizationConsumer>, Jab.IServiceProvider<IUserAvatarProvider>, Jab.IServiceProvider<IRegistrationMainPageVM>, Jab.IServiceProvider<IAccountCenterVM>, Jab.IServiceProvider<IUpdatesSettingsVM>, Jab.IServiceProvider<IClockSourceProvider>, Jab.IServiceProvider<IClockSourceService>, Jab.IServiceProvider<IClockSourceVM>, Jab.IServiceProvider<IScreenSettingsVM>, Jab.IServiceProvider<IInputsSettingsService>, Jab.IServiceProvider<IVideoInputsSettingsVM>, Jab.IServiceProvider<IVideoInputItemVMFactory>, Jab.IServiceProvider<IAudioInputsSettingsVM>, Jab.IServiceProvider<INdiInputsSettingsVM>, Jab.IServiceProvider<IInputsSettingsVM>, Jab.IServiceProvider<IDevicesSettingsVM>, Jab.IServiceProvider<IMediaSettingsVMFactory>, Jab.IServiceProvider<IMediaSearchPathsSettingsVM>, Jab.IServiceProvider<IMediaFilesProvider>, Jab.IServiceProvider<IMediaCleanupService>, Jab.IServiceProvider<IMediaCleanupVM>, Jab.IServiceProvider<IMediaSettingsVM>, Jab.IServiceProvider<IAudioSettingsVM>, Jab.IServiceProvider<IImportSettingsVM>, Jab.IServiceProvider<IPlanningCenterSettingsVM>, Jab.IServiceProvider<IMultiTracksSettingsVM>, Jab.IServiceProvider<IAutoReportDialogPrompt>, Jab.IServiceProvider<ISongSelectSettingsVM>, Jab.IServiceProvider<IResiUpdateVM>, Jab.IServiceProvider<ILoginDialogFactory>, Jab.IServiceProvider<IResiPrompt>, Jab.IServiceProvider<IResiAuthorizationInteractor>, Jab.IServiceProvider<IResiSettingsVM>, Jab.IServiceProvider<IIntegrationsSettingsVM>, Jab.IServiceProvider<IGroupLabelItemVMFactory>, Jab.IServiceProvider<IGroupsSettingsVM>, Jab.IServiceProvider<ILabelItemVMFactory>, Jab.IServiceProvider<ILabelsSettingsVM>, Jab.IServiceProvider<ISyncController>, Jab.IServiceProvider<ISyncSettingsVM>, Jab.IServiceProvider<IEnumerable<ISettingsListItem>>, Jab.IServiceProvider<ISettingsSearchEngine>, Jab.IServiceProvider<ISettingsSearchVM>, Jab.IServiceProvider<ISettingsNavigationVM>, Jab.IServiceProvider<ISettingsVM>, Jab.IServiceProvider<INotificationVMFactory>, Jab.IServiceProvider<IRegistrationRequestSender>, Jab.IServiceProvider<INotificationCallbackHandler>, Jab.IServiceProvider<INotificationService>, Jab.IServiceProvider<INotificationCollectionVM>, Jab.IServiceProvider<IChangeDirectoryProcessFactory>, Jab.IServiceProvider<IChangeWorkspaceHandler>, Jab.IServiceProvider<CloudOnboardingVM>, Jab.IServiceProvider<ICloudOnboardingVM>, Jab.IServiceProvider<ICloudOnboardingShellNavigator>, Jab.IServiceProvider<ICloudOnboardingEligibilityVM>, Jab.IServiceProvider<ICloudOnboardingManageMediaVM>, Jab.IServiceProvider<ICloudOnboardingPricingVM>, Jab.IServiceProvider<ICloudOnboardingDoneVM>, Jab.IServiceProvider<ICloudOnboardingLocalWorkspacesVM>, Jab.IServiceProvider<ICloudTeaseVM>, Jab.IServiceProvider<ICloudTeaseWindowProvider>, Jab.IServiceProvider<IManageWorkspacesWindowProvider>, Jab.IServiceProvider<IMissingFontVM>, Jab.IServiceProvider<ICalendarPrompt>, Jab.IServiceProvider<IRTMPPrompt>, Jab.IServiceProvider<IProContentDialogService>, Jab.IServiceProvider<IMediaImportDownloadDialogService>, Jab.IServiceProvider<IDownloadsDialogService>, Jab.IServiceProvider<IMediaCueThumbnailOverlayVMFactory>, Jab.IServiceProvider<IDownloadVMsFactory>, Jab.IServiceProvider<IPropPrompts>, Jab.IServiceProvider<IHardwareAlphaConfigurationVMFactory>, Jab.IServiceProvider<IAlphaKeySettingsVMFactory>, Jab.IServiceProvider<ICaptureController>, Jab.IServiceProvider<IResiService>, Jab.IServiceProvider<IUserFeedbackConsumer>, Jab.IServiceProvider<IBuildAppMetaDataFile>, Jab.IServiceProvider<IUserAttachmentVMFactory>, Jab.IServiceProvider<IAttachmentsUploader>, Jab.IServiceProvider<IAttachmentUploadJobFactory>, Jab.IServiceProvider<IFeedbackVM>, Jab.IServiceProvider<ICrashReportingVM>, Jab.IServiceProvider<IAttachmentUploadVM>, Jab.IServiceProvider<ICrashReportUserFeedbackDialogProvider>, Jab.INamedServiceProvider<System.IO.Stream>, Jab.IServiceProvider<IWhatsNewContentProviderFromJson>, Jab.IServiceProvider<IFeatureFactory>, Jab.IServiceProvider<IWhatsNewV2VM>, Jab.IServiceProvider<IMediaActionService>, Jab.IServiceProvider<ITimelineVMFactory>, Jab.IServiceProvider<ITimelineItemVMFactory>, Jab.IServiceProvider<IWorkspaceItemVMFactory>, Jab.IServiceProvider<IActionsMenuVMFactory>, Jab.IServiceProvider<IOutputScreenVMFactory>, Jab.IServiceProvider<IScreenSelectorVM>, Jab.IServiceProvider<IWindowedOutputVM>, Jab.IServiceProvider<IOutputPreviewVMFactory>, Jab.IServiceProvider<IInternalCoreManager>, Jab.IServiceProvider<ITriggeringFactory>, Jab.IServiceProvider<ICalendarService>, Jab.IServiceProvider<IExportService>, Jab.IServiceProvider<ILibraryService>, Jab.IServiceProvider<IClipboardProvider>, Jab.IServiceProvider<IPasteStrategy>, Jab.IServiceProvider<IEditorService>, Jab.IServiceProvider<PlaylistTemplateCollection>, Jab.IServiceProvider<IPlaylistTemplatesService>, Jab.IServiceProvider<ISizeProvider>, Jab.IServiceProvider<IProPresenterCueVMFactory>, Jab.IServiceProvider<IProContentDownloader>, Jab.IServiceProvider<IMacroPrompt>, Jab.IServiceProvider<ISlidePreviewService>, Jab.IServiceProvider<PropAutoClearHandler>, Jab.IServiceProvider<IPropAutoClearService>, Jab.IServiceProvider<ILegacyPurchaseBiblesDialogService>, Jab.IServiceProvider<IMediaValidator>, Jab.IServiceProvider<IMediaProvider>, Jab.IServiceProvider<IToastNotificationService>, Jab.IServiceProvider<IWorkspaceDeletedPrompt>, Jab.IServiceProvider<IWorkspaceCollectionVM>, Jab.IServiceProvider<IMainLayoutVM>, Jab.IServiceProvider<IThemeSlideMenuVM>, Jab.IServiceProvider<IArrangementVM>, Jab.IServiceProvider<ITimecodeItemVMFactory>, Jab.IServiceProvider<ITimecodeVM>, Jab.IServiceProvider<IHeaderContentContextMenuVM>, Jab.IServiceProvider<IWorkspaceSwitchValidator>, Jab.IServiceProvider<IApplicationFailureMessageService>, Jab.IServiceProvider<IFeatureFlagService>, Jab.IServiceProvider<ISpellChecker>, Jab.IServiceProvider<IReceiveService>, Jab.IServiceProvider<IPresentationHandlerOperationService>, Jab.INamedServiceProvider<IApplicationEventHandler>, Jab.IServiceProvider<ISettingsDataToCoreSender>, Jab.IServiceProvider<IAPIv1Dependencies>, Jab.IServiceProvider<ISharedData<AppData>>, Jab.IServiceProvider<Func<IRegistrationOperationFactory>>, Jab.IServiceProvider<IStartupArgumentsExecutor>, Jab.INamedServiceProvider<Func<bool>>, Jab.IServiceProvider<IMessageHandler>, Jab.IServiceProvider<IDocumentDiagnosticsProvider>, Jab.IServiceProvider<ILaunchPopUpProvider>, Jab.IServiceProvider<IPropAutoClearHandler>, Jab.IServiceProvider<ISendDataResponseHandlerProvider>, Jab.IServiceProvider<IDataProcessor<SendDataResponse>>, Jab.IServiceProvider<MediaInspectorConverter>, Jab.IServiceProvider<WarningTooltipConverter>, Jab.IServiceProvider<WebFillBrowserFactory>, Jab.IServiceProvider<IWebFillBrowserFactory>, Jab.IServiceProvider<IActionDialogService>, Jab.IServiceProvider<ITemplateVM>, Jab.IServiceProvider<Func<MainWindow>>, Jab.IServiceProvider<IInstanceValidator>, Jab.IServiceProvider<IWorkspaceInfoDumper>, Jab.IServiceProvider<MainWindow>, Jab.IServiceProvider<ICloudOnboardingWindowProvider>, Jab.IServiceProvider<IMediaServiceV1>, Jab.IServiceProvider<IMediaServiceV2>, Jab.INamedServiceProvider<IProcessSupervisor>, Jab.IServiceProvider<IActionFactoryService>, Jab.IServiceProvider<IWorkspacesVM>, Jab.IServiceProvider<IEnumerable<IStartupArgumentsExecutor>>, Jab.IServiceProvider<IEnumerable<IMessageHandler>>, Jab.IServiceProvider<IServiceProvider>, Jab.IServiceProvider<IServiceScopeFactory>, Jab.IServiceProvider<IServiceProviderIsService>
	{
		private ServiceProvider _root;

		private List<object>? _disposables;

		IServiceProvider IServiceScope.ServiceProvider => this;

		public Scope(ServiceProvider root)
		{
			_root = root;
		}

		[DebuggerHidden]
		public T GetService<T>()
		{
			if (!(this is Jab.IServiceProvider<T> serviceProvider))
			{
				throw Jab.JabHelpers.CreateServiceNotFoundException<T>();
			}
			return serviceProvider.GetService();
		}

		[DebuggerHidden]
		public T GetService<T>(string name)
		{
			if (!(this is Jab.INamedServiceProvider<T> namedServiceProvider))
			{
				throw Jab.JabHelpers.CreateServiceNotFoundException<T>(name);
			}
			return namedServiceProvider.GetService(name);
		}

		IPhysicalDeviceProvider Jab.IServiceProvider<IPhysicalDeviceProvider>.GetService()
		{
			PhysicalDeviceProvider physicalDeviceProvider = new PhysicalDeviceProvider();
			TryAddDisposable(physicalDeviceProvider);
			return physicalDeviceProvider;
		}

		IDatabaseService Jab.IServiceProvider<IDatabaseService>.GetService()
		{
			return _root.GetService<IDatabaseService>();
		}

		IFileWatcherFactory Jab.IServiceProvider<IFileWatcherFactory>.GetService()
		{
			FileWatcherFactory fileWatcherFactory = new FileWatcherFactory();
			TryAddDisposable(fileWatcherFactory);
			return fileWatcherFactory;
		}

		IFileSystem Jab.IServiceProvider<IFileSystem>.GetService()
		{
			return _root.GetService<IFileSystem>();
		}

		IUiDispatcher Jab.IServiceProvider<IUiDispatcher>.GetService()
		{
			IUiDispatcher dispatcher = _root.GetDispatcher();
			TryAddDisposable(dispatcher);
			return dispatcher;
		}

		ITimerFactory Jab.IServiceProvider<ITimerFactory>.GetService()
		{
			TimerFactory timerFactory = new TimerFactory(GetService<IUiDispatcher>());
			TryAddDisposable(timerFactory);
			return timerFactory;
		}

		IDebouncerFactory Jab.IServiceProvider<IDebouncerFactory>.GetService()
		{
			DebouncerFactory debouncerFactory = new DebouncerFactory(GetService<ITimerFactory>());
			TryAddDisposable(debouncerFactory);
			return debouncerFactory;
		}

		IThemeRepo Jab.IServiceProvider<IThemeRepo>.GetService()
		{
			return _root.GetService<IThemeRepo>();
		}

		IPropsRepo Jab.IServiceProvider<IPropsRepo>.GetService()
		{
			PropsRepo propsRepo = new PropsRepo();
			TryAddDisposable(propsRepo);
			return propsRepo;
		}

		IMacrosRepo Jab.IServiceProvider<IMacrosRepo>.GetService()
		{
			MacrosRepo macrosRepo = new MacrosRepo();
			TryAddDisposable(macrosRepo);
			return macrosRepo;
		}

		ILibraryPlaylistRepo Jab.IServiceProvider<ILibraryPlaylistRepo>.GetService()
		{
			LibraryPlaylistRepo libraryPlaylistRepo = new LibraryPlaylistRepo();
			TryAddDisposable(libraryPlaylistRepo);
			return libraryPlaylistRepo;
		}

		IVisualPlaylistRepo Jab.IServiceProvider<IVisualPlaylistRepo>.GetService()
		{
			VisualPlaylistRepo visualPlaylistRepo = new VisualPlaylistRepo();
			TryAddDisposable(visualPlaylistRepo);
			return visualPlaylistRepo;
		}

		IProPresenterResourceService Jab.IServiceProvider<IProPresenterResourceService>.GetService()
		{
			ProPresenterResourceService proPresenterResourceService = new ProPresenterResourceService(GetService<IThemeRepo>(), GetService<IPropsRepo>(), GetService<IMacrosRepo>(), GetService<ILibraryPlaylistRepo>(), GetService<IVisualPlaylistRepo>());
			TryAddDisposable(proPresenterResourceService);
			return proPresenterResourceService;
		}

		IThemeService Jab.IServiceProvider<IThemeService>.GetService()
		{
			return _root.GetService<IThemeService>();
		}

		IZipService Jab.IServiceProvider<IZipService>.GetService()
		{
			ZipService zipService = new ZipService();
			TryAddDisposable(zipService);
			return zipService;
		}

		IMessageService Jab.IServiceProvider<IMessageService>.GetService()
		{
			return _root.GetService<IMessageService>();
		}

		IFileService Jab.IServiceProvider<IFileService>.GetService()
		{
			FileService fileService = new FileService();
			TryAddDisposable(fileService);
			return fileService;
		}

		ILogger Jab.IServiceProvider<ILogger>.GetService()
		{
			Logger logger = new Logger();
			TryAddDisposable(logger);
			return logger;
		}

		ILocalization Jab.IServiceProvider<ILocalization>.GetService()
		{
			Localization localization = new Localization();
			TryAddDisposable(localization);
			return localization;
		}

		IAdvanced Jab.IServiceProvider<IAdvanced>.GetService()
		{
			IAdvanced advanced = ISettingsServiceProviderModule.GetAdvanced();
			TryAddDisposable(advanced);
			return advanced;
		}

		IProtoService Jab.IServiceProvider<IProtoService>.GetService()
		{
			ProtoService protoService = new ProtoService();
			TryAddDisposable(protoService);
			return protoService;
		}

		ISqliteMigrationService Jab.IServiceProvider<ISqliteMigrationService>.GetService()
		{
			return _root.GetService<ISqliteMigrationService>();
		}

		ICookieManagerService Jab.IServiceProvider<ICookieManagerService>.GetService()
		{
			return _root.GetService<ICookieManagerService>();
		}

		App Jab.IServiceProvider<App>.GetService()
		{
			return _root.GetService<App>();
		}

		IApp Jab.IServiceProvider<IApp>.GetService()
		{
			IApp app = ISettingsServiceProviderModule.GetApp(GetService<App>());
			TryAddDisposable(app);
			return app;
		}

		IProCoreInstance Jab.IServiceProvider<IProCoreInstance>.GetService()
		{
			return _root.GetService<IProCoreInstance>();
		}

		IFlagService Jab.IServiceProvider<IFlagService>.GetService()
		{
			return _root.GetService<IFlagService>();
		}

		ssAPIOutput Jab.IServiceProvider<ssAPIOutput>.GetService()
		{
			return _root.GetService<ssAPIOutput>();
		}

		ITransitionDescriptionCollection Jab.IServiceProvider<ITransitionDescriptionCollection>.GetService()
		{
			ITransitionDescriptionCollection transitionDescriptionCollection = IControllerServiceProviderModule.GetTransitionDescriptionCollection(GetService<ssAPIOutput>());
			TryAddDisposable(transitionDescriptionCollection);
			return transitionDescriptionCollection;
		}

		IImageLoader Jab.IServiceProvider<IImageLoader>.GetService()
		{
			ImageLoader imageLoader = new ImageLoader();
			TryAddDisposable(imageLoader);
			return imageLoader;
		}

		IMediaMetadataCacheRepository Jab.IServiceProvider<IMediaMetadataCacheRepository>.GetService()
		{
			return _root.GetService<IMediaMetadataCacheRepository>();
		}

		IMediaMetadataCacheService Jab.IServiceProvider<IMediaMetadataCacheService>.GetService()
		{
			return _root.GetService<IMediaMetadataCacheService>();
		}

		IAsyncExecutor Jab.IServiceProvider<IAsyncExecutor>.GetService()
		{
			AsyncExecutor asyncExecutor = new AsyncExecutor();
			TryAddDisposable(asyncExecutor);
			return asyncExecutor;
		}

		IUiScheduler Jab.IServiceProvider<IUiScheduler>.GetService()
		{
			IUiScheduler dispatcher = _root.GetDispatcher();
			TryAddDisposable(dispatcher);
			return dispatcher;
		}

		IMetadataLoader Jab.IServiceProvider<IMetadataLoader>.GetService()
		{
			return _root.GetService<IMetadataLoader>();
		}

		ITrackedMediaHelpers Jab.IServiceProvider<ITrackedMediaHelpers>.GetService()
		{
			ITrackedMediaHelpers trackedMediaHelpers = _root.GetTrackedMediaHelpers(GetService<IFlagService>(), GetService<IAsyncExecutor>());
			TryAddDisposable(trackedMediaHelpers);
			return trackedMediaHelpers;
		}

		IAssemblyInfoProvider Jab.IServiceProvider<IAssemblyInfoProvider>.GetService()
		{
			return _root.GetService<IAssemblyInfoProvider>();
		}

		private System.Version GetVersion_OSVersion()
		{
			return _root.GetVersion_OSVersion();
		}

		IVersionInfoProvider Jab.IServiceProvider<IVersionInfoProvider>.GetService()
		{
			return _root.GetService<IVersionInfoProvider>();
		}

		IRestClientFactory Jab.IServiceProvider<IRestClientFactory>.GetService()
		{
			return _root.GetService<IRestClientFactory>();
		}

		ISemaphoreFactory Jab.IServiceProvider<ISemaphoreFactory>.GetService()
		{
			SemaphoreFactory semaphoreFactory = new SemaphoreFactory();
			TryAddDisposable(semaphoreFactory);
			return semaphoreFactory;
		}

		ICurrentTime Jab.IServiceProvider<ICurrentTime>.GetService()
		{
			CurrentTime currentTime = new CurrentTime();
			TryAddDisposable(currentTime);
			return currentTime;
		}

		IFileSystemUriCacheServiceFactory Jab.IServiceProvider<IFileSystemUriCacheServiceFactory>.GetService()
		{
			return _root.GetService<IFileSystemUriCacheServiceFactory>();
		}

		IImageDecoder Jab.IServiceProvider<IImageDecoder>.GetService()
		{
			ImageDecoder imageDecoder = new ImageDecoder();
			TryAddDisposable(imageDecoder);
			return imageDecoder;
		}

		IBitmapImageDecoder Jab.IServiceProvider<IBitmapImageDecoder>.GetService()
		{
			BitmapImageDecoder bitmapImageDecoder = new BitmapImageDecoder(GetService<IImageDecoder>());
			TryAddDisposable(bitmapImageDecoder);
			return bitmapImageDecoder;
		}

		IUriCacheService<NullableBitmapSource> Jab.IServiceProvider<IUriCacheService<NullableBitmapSource>>.GetService()
		{
			return _root.GetService<IUriCacheService<NullableBitmapSource>>();
		}

		ICurrentTimeOffset Jab.IServiceProvider<ICurrentTimeOffset>.GetService()
		{
			CurrentTimeOffset currentTimeOffset = new CurrentTimeOffset();
			TryAddDisposable(currentTimeOffset);
			return currentTimeOffset;
		}

		IAuthenticatingApiConsumerFactory Jab.IServiceProvider<IAuthenticatingApiConsumerFactory>.GetService()
		{
			AuthenticatingApiConsumerFactory authenticatingApiConsumerFactory = new AuthenticatingApiConsumerFactory(GetService<IRestClientFactory>(), GetService<ICurrentTimeOffset>(), GetService<ILogger>());
			TryAddDisposable(authenticatingApiConsumerFactory);
			return authenticatingApiConsumerFactory;
		}

		IApiService Jab.IServiceProvider<IApiService>.GetService()
		{
			ApiService apiService = new ApiService(GetService<IFlagService>());
			TryAddDisposable(apiService);
			return apiService;
		}

		IRegistrationUserDialogService Jab.IServiceProvider<IRegistrationUserDialogService>.GetService()
		{
			return _root.GetService<IRegistrationUserDialogService>();
		}

		IApplicationExceptionFactory Jab.IServiceProvider<IApplicationExceptionFactory>.GetService()
		{
			ApplicationExceptionFactory applicationExceptionFactory = new ApplicationExceptionFactory();
			TryAddDisposable(applicationExceptionFactory);
			return applicationExceptionFactory;
		}

		IErrorPublisher Jab.IServiceProvider<IErrorPublisher>.GetService()
		{
			return _root.GetService<IErrorPublisher>();
		}

		IErrorReporter Jab.IServiceProvider<IErrorReporter>.GetService()
		{
			ErrorReporter errorReporter = new ErrorReporter(GetService<ILogger>(), GetService<IErrorPublisher>());
			TryAddDisposable(errorReporter);
			return errorReporter;
		}

		ICoreApplication Jab.IServiceProvider<ICoreApplication>.GetService()
		{
			return _root.GetService<ICoreApplication>();
		}

		IRegistrationCallbackHandler Jab.IServiceProvider<IRegistrationCallbackHandler>.GetService()
		{
			return _root.GetService<IRegistrationCallbackHandler>();
		}

		NotificationCallbackHandler Jab.IServiceProvider<NotificationCallbackHandler>.GetService()
		{
			return _root.GetService<NotificationCallbackHandler>();
		}

		private IRegistrationCallbackHandler GetIRegistrationCallbackHandler_1()
		{
			IRegistrationCallbackHandler notificationCallbackHandler = IRegistrationServiceProviderModule.GetNotificationCallbackHandler(GetService<NotificationCallbackHandler>());
			TryAddDisposable(notificationCallbackHandler);
			return notificationCallbackHandler;
		}

		ProContentClientInformationProvider Jab.IServiceProvider<ProContentClientInformationProvider>.GetService()
		{
			return _root.GetService<ProContentClientInformationProvider>();
		}

		private IRegistrationCallbackHandler GetIRegistrationCallbackHandler_2()
		{
			IRegistrationCallbackHandler proContentClientInformationProvider = IRegistrationServiceProviderModule.GetProContentClientInformationProvider(GetService<ProContentClientInformationProvider>());
			TryAddDisposable(proContentClientInformationProvider);
			return proContentClientInformationProvider;
		}

		IInternetAccess Jab.IServiceProvider<IInternetAccess>.GetService()
		{
			return _root.GetService<IInternetAccess>();
		}

		IHyperlinkService Jab.IServiceProvider<IHyperlinkService>.GetService()
		{
			HyperlinkService hyperlinkService = new HyperlinkService(GetService<ILogger>(), GetService<IFlagService>(), GetService<IInternetAccess>());
			TryAddDisposable(hyperlinkService);
			return hyperlinkService;
		}

		JsonWebTokenHandler Jab.IServiceProvider<JsonWebTokenHandler>.GetService()
		{
			return _root.GetService<JsonWebTokenHandler>();
		}

		RegistrationStateHandler Jab.IServiceProvider<RegistrationStateHandler>.GetService()
		{
			return _root.GetService<RegistrationStateHandler>();
		}

		IRegistrationStateProvider Jab.IServiceProvider<IRegistrationStateProvider>.GetService()
		{
			IRegistrationStateProvider registrationStateHandler = IRegistrationServiceProviderModule.GetRegistrationStateHandler(GetService<RegistrationStateHandler>());
			TryAddDisposable(registrationStateHandler);
			return registrationStateHandler;
		}

		IActivationKeyProvider Jab.IServiceProvider<IActivationKeyProvider>.GetService()
		{
			ActivationKeyProvider activationKeyProvider = new ActivationKeyProvider(GetService<IRegistrationStateProvider>());
			TryAddDisposable(activationKeyProvider);
			return activationKeyProvider;
		}

		IRegistrationWebResourceService Jab.IServiceProvider<IRegistrationWebResourceService>.GetService()
		{
			RegistrationWebResourceService registrationWebResourceService = new RegistrationWebResourceService(GetService<IApiService>(), GetService<IVersionInfoProvider>(), GetService<IActivationKeyProvider>());
			TryAddDisposable(registrationWebResourceService);
			return registrationWebResourceService;
		}

		IPopUpAlertFactory Jab.IServiceProvider<IPopUpAlertFactory>.GetService()
		{
			PopUpAlertFactory popUpAlertFactory = new PopUpAlertFactory(GetService<IUiDispatcher>(), GetService<IHyperlinkService>(), GetService<IRegistrationWebResourceService>());
			TryAddDisposable(popUpAlertFactory);
			return popUpAlertFactory;
		}

		IAfterStartupCompleteQueue Jab.IServiceProvider<IAfterStartupCompleteQueue>.GetService()
		{
			return _root.GetService<IAfterStartupCompleteQueue>();
		}

		UserMessageHandler Jab.IServiceProvider<UserMessageHandler>.GetService()
		{
			return _root.GetService<UserMessageHandler>();
		}

		private IRegistrationCallbackHandler GetIRegistrationCallbackHandler_3()
		{
			IRegistrationCallbackHandler userMessageHandler = IRegistrationServiceProviderModule.GetUserMessageHandler(GetService<UserMessageHandler>());
			TryAddDisposable(userMessageHandler);
			return userMessageHandler;
		}

		Func<IMainLayoutVM> Jab.IServiceProvider<Func<IMainLayoutVM>>.GetService()
		{
			Func<IMainLayoutVM> mainLayoutVmGetter = _root.GetMainLayoutVmGetter();
			TryAddDisposable(mainLayoutVmGetter);
			return mainLayoutVmGetter;
		}

		private System.Action GetAction_ShowRegistrationSettingsKey()
		{
			System.Action showRegistrationSettings = GetShowRegistrationSettings(GetService<Func<IMainLayoutVM>>());
			TryAddDisposable(showRegistrationSettings);
			return showRegistrationSettings;
		}

		IWebSourceProvider Jab.IServiceProvider<IWebSourceProvider>.GetService()
		{
			WebSourceProvider webSourceProvider = new WebSourceProvider(GetService<IRegistrationStateProvider>(), GetService<IApiService>());
			TryAddDisposable(webSourceProvider);
			return webSourceProvider;
		}

		IRegistrationCallbackDialogProvider Jab.IServiceProvider<IRegistrationCallbackDialogProvider>.GetService()
		{
			IRegistrationCallbackDialogProvider registrationCallbackDialogProvider = IRegistrationServiceProviderModule.GetRegistrationCallbackDialogProvider(GetService<IUiDispatcher>(), GetService<ICurrentTime>(), GetAction_ShowRegistrationSettingsKey(), GetService<IAfterStartupCompleteQueue>(), GetService<IWebSourceProvider>());
			TryAddDisposable(registrationCallbackDialogProvider);
			return registrationCallbackDialogProvider;
		}

		private IRegistrationCallbackHandler GetIRegistrationCallbackHandler_4()
		{
			return _root.GetIRegistrationCallbackHandler_4();
		}

		private IRegistrationCallbackHandler GetIRegistrationCallbackHandler_5()
		{
			return _root.GetIRegistrationCallbackHandler_5();
		}

		private IRegistrationCallbackHandler GetIRegistrationCallbackHandler_6()
		{
			return _root.GetIRegistrationCallbackHandler_6();
		}

		IEmbeddedResourceReader Jab.IServiceProvider<IEmbeddedResourceReader>.GetService()
		{
			EmbeddedResourceReader embeddedResourceReader = new EmbeddedResourceReader();
			TryAddDisposable(embeddedResourceReader);
			return embeddedResourceReader;
		}

		IForceQuitEventPublisher Jab.IServiceProvider<IForceQuitEventPublisher>.GetService()
		{
			ForceQuitEventPublisher forceQuitEventPublisher = new ForceQuitEventPublisher();
			TryAddDisposable(forceQuitEventPublisher);
			return forceQuitEventPublisher;
		}

		IForcedShutdownMessageProvider Jab.IServiceProvider<IForcedShutdownMessageProvider>.GetService()
		{
			ForcedShutdownMessageProvider forcedShutdownMessageProvider = new ForcedShutdownMessageProvider(GetService<IUiDispatcher>(), GetService<IMessageService>(), GetService<IForceQuitEventPublisher>());
			TryAddDisposable(forcedShutdownMessageProvider);
			return forcedShutdownMessageProvider;
		}

		private IRegistrationCallbackHandler GetIRegistrationCallbackHandler_7()
		{
			return _root.GetIRegistrationCallbackHandler_7();
		}

		private IRegistrationCallbackHandler GetIRegistrationCallbackHandler_8()
		{
			return _root.GetIRegistrationCallbackHandler_8();
		}

		private IRegistrationCallbackHandler GetIRegistrationCallbackHandler_9()
		{
			return _root.GetIRegistrationCallbackHandler_9();
		}

		private IRegistrationCallbackHandler GetIRegistrationCallbackHandler_10()
		{
			return _root.GetIRegistrationCallbackHandler_10();
		}

		IInternetAccessCheck Jab.IServiceProvider<IInternetAccessCheck>.GetService()
		{
			return _root.GetService<IInternetAccessCheck>();
		}

		private IRegistrationCallbackHandler GetIRegistrationCallbackHandler_11()
		{
			return _root.GetIRegistrationCallbackHandler_11();
		}

		private IRegistrationCallbackHandler GetIRegistrationCallbackHandler_12()
		{
			IRegistrationCallbackHandler registrationStateHandler = IRegistrationServiceProviderModule.GetRegistrationStateHandler(GetService<RegistrationStateHandler>());
			TryAddDisposable(registrationStateHandler);
			return registrationStateHandler;
		}

		IEnumerable<IRegistrationCallbackHandler> Jab.IServiceProvider<IEnumerable<IRegistrationCallbackHandler>>.GetService()
		{
			return new IRegistrationCallbackHandler[13]
			{
				GetIRegistrationCallbackHandler_12(),
				GetIRegistrationCallbackHandler_11(),
				GetIRegistrationCallbackHandler_10(),
				GetIRegistrationCallbackHandler_9(),
				GetIRegistrationCallbackHandler_8(),
				GetIRegistrationCallbackHandler_7(),
				GetIRegistrationCallbackHandler_6(),
				GetIRegistrationCallbackHandler_5(),
				GetIRegistrationCallbackHandler_4(),
				GetIRegistrationCallbackHandler_3(),
				GetIRegistrationCallbackHandler_2(),
				GetIRegistrationCallbackHandler_1(),
				GetService<IRegistrationCallbackHandler>()
			};
		}

		RegistrationClient Jab.IServiceProvider<RegistrationClient>.GetService()
		{
			return _root.GetService<RegistrationClient>();
		}

		IRegistrationClient Jab.IServiceProvider<IRegistrationClient>.GetService()
		{
			IRegistrationClient registrationClient = IRegistrationServiceProviderModule.GetRegistrationClient(GetService<RegistrationClient>());
			TryAddDisposable(registrationClient);
			return registrationClient;
		}

		IRegistrationOperationFactory Jab.IServiceProvider<IRegistrationOperationFactory>.GetService()
		{
			return _root.GetService<IRegistrationOperationFactory>();
		}

		private IOAuth2AuthorizationStore GetIOAuth2AuthorizationStore_ProContentRegistrationAuthorizationStorageKey()
		{
			return _root.GetIOAuth2AuthorizationStore_ProContentRegistrationAuthorizationStorageKey();
		}

		private IOAuth2ClientInfoProvider GetIOAuth2ClientInfoProvider_ProContentRegistrationAuthorizationInfoProviderKey()
		{
			IOAuth2ClientInfoProvider proContentClientInformationProvider = IRegistrationServiceProviderModule.GetProContentClientInformationProvider(GetService<ProContentClientInformationProvider>());
			TryAddDisposable(proContentClientInformationProvider);
			return proContentClientInformationProvider;
		}

		IProContentConsumer Jab.IServiceProvider<IProContentConsumer>.GetService()
		{
			return _root.GetService<IProContentConsumer>();
		}

		IProContentDownloadFailedDialogService Jab.IServiceProvider<IProContentDownloadFailedDialogService>.GetService()
		{
			ProContentDownloadFailedDialogService proContentDownloadFailedDialogService = new ProContentDownloadFailedDialogService(GetService<ILocalization>(), GetService<IRegistrationWebResourceService>(), GetService<IHyperlinkService>());
			TryAddDisposable(proContentDownloadFailedDialogService);
			return proContentDownloadFailedDialogService;
		}

		IProContentUserInteractionBehavior Jab.IServiceProvider<IProContentUserInteractionBehavior>.GetService()
		{
			ProContentUserInteractionBehavior proContentUserInteractionBehavior = new ProContentUserInteractionBehavior(GetService<IProContentConsumer>(), GetService<IInternetAccessCheck>(), GetService<IProContentDownloadFailedDialogService>(), GetService<IRegistrationWebResourceService>(), GetService<IHyperlinkService>());
			TryAddDisposable(proContentUserInteractionBehavior);
			return proContentUserInteractionBehavior;
		}

		IDelayFactory Jab.IServiceProvider<IDelayFactory>.GetService()
		{
			DelayFactory delayFactory = new DelayFactory();
			TryAddDisposable(delayFactory);
			return delayFactory;
		}

		IDownloadProcessFactory Jab.IServiceProvider<IDownloadProcessFactory>.GetService()
		{
			DownloadProcessFactory downloadProcessFactory = new DownloadProcessFactory(GetService<ILogger>(), GetService<IFileSystem>(), GetService<IRestClientFactory>(), GetService<IDelayFactory>());
			TryAddDisposable(downloadProcessFactory);
			return downloadProcessFactory;
		}

		IDownloadItemFactory Jab.IServiceProvider<IDownloadItemFactory>.GetService()
		{
			DownloadItemFactory downloadItemFactory = new DownloadItemFactory(GetService<IDownloadProcessFactory>(), GetService<IFileService>(), GetService<IFileSystem>());
			TryAddDisposable(downloadItemFactory);
			return downloadItemFactory;
		}

		IProContentAnalyticEventsPublisher Jab.IServiceProvider<IProContentAnalyticEventsPublisher>.GetService()
		{
			ProContentAnalyticEventsPublisher proContentAnalyticEventsPublisher = new ProContentAnalyticEventsPublisher();
			TryAddDisposable(proContentAnalyticEventsPublisher);
			return proContentAnalyticEventsPublisher;
		}

		IDownloadManager Jab.IServiceProvider<IDownloadManager>.GetService()
		{
			return _root.GetService<IDownloadManager>();
		}

		IUnObservedProContentDownloadProcessFactory Jab.IServiceProvider<IUnObservedProContentDownloadProcessFactory>.GetService()
		{
			UnObservedProContentDownloadProcessFactory unObservedProContentDownloadProcessFactory = new UnObservedProContentDownloadProcessFactory(GetService<IDownloadItemFactory>(), GetService<IProContentConsumer>(), GetService<IProPresenterResourceService>(), GetService<IApp>(), GetService<IProContentDownloadFailedDialogService>(), GetService<IProContentAnalyticEventsPublisher>(), GetService<IDownloadManager>());
			TryAddDisposable(unObservedProContentDownloadProcessFactory);
			return unObservedProContentDownloadProcessFactory;
		}

		IProContentAssetProvider Jab.IServiceProvider<IProContentAssetProvider>.GetService()
		{
			return _root.GetService<IProContentAssetProvider>();
		}

		IRemoteFileLoader Jab.IServiceProvider<IRemoteFileLoader>.GetService()
		{
			RemoteFileLoader remoteFileLoader = new RemoteFileLoader(GetService<IUriCacheService<NullableBitmapSource>>(), GetService<IProContentAssetProvider>());
			TryAddDisposable(remoteFileLoader);
			return remoteFileLoader;
		}

		IAudioOutputDeviceCollection Jab.IServiceProvider<IAudioOutputDeviceCollection>.GetService()
		{
			IAudioOutputDeviceCollection audioOutputDeviceCollection = IControllerServiceProviderModule.GetAudioOutputDeviceCollection(GetService<ssAPIOutput>());
			TryAddDisposable(audioOutputDeviceCollection);
			return audioOutputDeviceCollection;
		}

		IAudioSetup Jab.IServiceProvider<IAudioSetup>.GetService()
		{
			return _root.GetService<IAudioSetup>();
		}

		IAudioMapRecallService<DeviceChannel, Bus> Jab.IServiceProvider<IAudioMapRecallService<DeviceChannel, Bus>>.GetService()
		{
			return _root.GetService<IAudioMapRecallService<DeviceChannel, Bus>>();
		}

		ILiveVideoInputCollection Jab.IServiceProvider<ILiveVideoInputCollection>.GetService()
		{
			return _root.GetService<ILiveVideoInputCollection>();
		}

		IMediaFactory Jab.IServiceProvider<IMediaFactory>.GetService()
		{
			IMediaFactory mediaFactory = IGlobalServiceProviderModule.GetMediaFactory(GetService<IMetadataLoader>(), GetService<IAsyncExecutor>(), GetService<ITrackedMediaHelpers>(), GetService<IRemoteFileLoader>(), GetService<ILiveVideoInputCollection>(), GetService<IAudioSetup>(), GetService<IFlagService>(), GetService<ssAPIOutput>());
			TryAddDisposable(mediaFactory);
			return mediaFactory;
		}

		ITextFillMediaFactory Jab.IServiceProvider<ITextFillMediaFactory>.GetService()
		{
			TextFillMediaFactory textFillMediaFactory = new TextFillMediaFactory(GetService<IMediaFactory>());
			TryAddDisposable(textFillMediaFactory);
			return textFillMediaFactory;
		}

		ITextDocumentFactory Jab.IServiceProvider<ITextDocumentFactory>.GetService()
		{
			return _root.GetService<ITextDocumentFactory>();
		}

		IEntityFactory Jab.IServiceProvider<IEntityFactory>.GetService()
		{
			return _root.GetService<IEntityFactory>();
		}

		IDocumentFactory Jab.IServiceProvider<IDocumentFactory>.GetService()
		{
			return _root.GetService<IDocumentFactory>();
		}

		IDocumentService Jab.IServiceProvider<IDocumentService>.GetService()
		{
			return _root.GetService<IDocumentService>();
		}

		IEntityFileLockFactory Jab.IServiceProvider<IEntityFileLockFactory>.GetService()
		{
			return _root.GetService<IEntityFileLockFactory>();
		}

		ICommonPathsWrapper Jab.IServiceProvider<ICommonPathsWrapper>.GetService()
		{
			return _root.GetService<ICommonPathsWrapper>();
		}

		ICollaborationPeerIdProvider Jab.IServiceProvider<ICollaborationPeerIdProvider>.GetService()
		{
			ICollaborationPeerIdProvider app = IGlobalServiceProviderModule.GetApp(GetService<IApp>());
			TryAddDisposable(app);
			return app;
		}

		IThreadPoolScheduler Jab.IServiceProvider<IThreadPoolScheduler>.GetService()
		{
			ThreadPoolScheduler threadPoolScheduler = new ThreadPoolScheduler();
			TryAddDisposable(threadPoolScheduler);
			return threadPoolScheduler;
		}

		IMediaService Jab.IServiceProvider<IMediaService>.GetService()
		{
			return _root.GetService<IMediaService>();
		}

		ILocalWorkspaceStatsEventPublisher Jab.IServiceProvider<ILocalWorkspaceStatsEventPublisher>.GetService()
		{
			LocalWorkspaceStatsEventPublisher localWorkspaceStatsEventPublisher = new LocalWorkspaceStatsEventPublisher();
			TryAddDisposable(localWorkspaceStatsEventPublisher);
			return localWorkspaceStatsEventPublisher;
		}

		IZipHelper Jab.IServiceProvider<IZipHelper>.GetService()
		{
			ZipHelperImpl zipHelperImpl = new ZipHelperImpl();
			TryAddDisposable(zipHelperImpl);
			return zipHelperImpl;
		}

		IWorkspaceService Jab.IServiceProvider<IWorkspaceService>.GetService()
		{
			return _root.GetService<IWorkspaceService>();
		}

		ICloudDiagnosticsPublisher Jab.IServiceProvider<ICloudDiagnosticsPublisher>.GetService()
		{
			return _root.GetService<ICloudDiagnosticsPublisher>();
		}

		IEntityDocumentRegistry Jab.IServiceProvider<IEntityDocumentRegistry>.GetService()
		{
			return _root.GetService<IEntityDocumentRegistry>();
		}

		IEntityDocumentSyncerFactory Jab.IServiceProvider<IEntityDocumentSyncerFactory>.GetService()
		{
			return _root.GetService<IEntityDocumentSyncerFactory>();
		}

		IMergedEntityFactory Jab.IServiceProvider<IMergedEntityFactory>.GetService()
		{
			return _root.GetService<IMergedEntityFactory>();
		}

		IProPresenterDOFactoryProvider Jab.IServiceProvider<IProPresenterDOFactoryProvider>.GetService()
		{
			return _root.GetService<IProPresenterDOFactoryProvider>();
		}

		IMessageDialogService Jab.IServiceProvider<IMessageDialogService>.GetService()
		{
			MessageDialogServiceInstance messageDialogServiceInstance = new MessageDialogServiceInstance();
			TryAddDisposable(messageDialogServiceInstance);
			return messageDialogServiceInstance;
		}

		IPresentationFactory Jab.IServiceProvider<IPresentationFactory>.GetService()
		{
			PresentationFactory presentationFactory = new PresentationFactory(GetService<IApp>(), GetService<ITimerFactory>(), GetService<ITransitionDescriptionCollection>(), GetService<IProPresenterDOFactoryProvider>(), GetService<IMessageDialogService>(), GetService<ICurrentTime>());
			TryAddDisposable(presentationFactory);
			return presentationFactory;
		}

		IPowerPointImageLoader Jab.IServiceProvider<IPowerPointImageLoader>.GetService()
		{
			PowerPointImageLoader powerPointImageLoader = new PowerPointImageLoader(GetService<IMediaFactory>());
			TryAddDisposable(powerPointImageLoader);
			return powerPointImageLoader;
		}

		IPowerPointEvents Jab.IServiceProvider<IPowerPointEvents>.GetService()
		{
			PowerPointEvents powerPointEvents = new PowerPointEvents();
			TryAddDisposable(powerPointEvents);
			return powerPointEvents;
		}

		TypefaceLibrary Jab.IServiceProvider<TypefaceLibrary>.GetService()
		{
			TypefaceLibrary sharedTypefaceLibrary = IProPresenterDOImportServiceProviderModule.GetSharedTypefaceLibrary();
			TryAddDisposable(sharedTypefaceLibrary);
			return sharedTypefaceLibrary;
		}

		IFontDetector Jab.IServiceProvider<IFontDetector>.GetService()
		{
			FontDetector fontDetector = new FontDetector(GetService<TypefaceLibrary>());
			TryAddDisposable(fontDetector);
			return fontDetector;
		}

		IFontDetectionSessionFactory Jab.IServiceProvider<IFontDetectionSessionFactory>.GetService()
		{
			FontDetectionSessionFactory fontDetectionSessionFactory = new FontDetectionSessionFactory(GetService<IFontDetector>(), GetService<IUiDispatcher>(), GetService<IProPresenterResourceService>());
			TryAddDisposable(fontDetectionSessionFactory);
			return fontDetectionSessionFactory;
		}

		IMissingFontService Jab.IServiceProvider<IMissingFontService>.GetService()
		{
			MissingFontService missingFontService = new MissingFontService(GetService<IFontDetector>(), GetService<IFontDetectionSessionFactory>());
			TryAddDisposable(missingFontService);
			return missingFontService;
		}

		IProPresenterCueFactory Jab.IServiceProvider<IProPresenterCueFactory>.GetService()
		{
			ProPresenterCueFactory proPresenterCueFactory = new ProPresenterCueFactory(GetService<IApp>(), GetService<IProPresenterResourceService>(), GetService<IProPresenterDOFactoryProvider>(), GetService<ITransitionDescriptionCollection>());
			TryAddDisposable(proPresenterCueFactory);
			return proPresenterCueFactory;
		}

		IFontReplacementEventPublisher Jab.IServiceProvider<IFontReplacementEventPublisher>.GetService()
		{
			FontReplacementEventPublisher fontReplacementEventPublisher = new FontReplacementEventPublisher();
			TryAddDisposable(fontReplacementEventPublisher);
			return fontReplacementEventPublisher;
		}

		IMissingFontWindowProvider Jab.IServiceProvider<IMissingFontWindowProvider>.GetService()
		{
			MissingFontWindowProvider missingFontWindowProvider = new MissingFontWindowProvider(GetService<IMissingFontService>(), GetService<ILocalization>(), GetService<IFontReplacementEventPublisher>(), GetService<IProPresenterResourceService>());
			TryAddDisposable(missingFontWindowProvider);
			return missingFontWindowProvider;
		}

		ICorePowerPointImportService Jab.IServiceProvider<ICorePowerPointImportService>.GetService()
		{
			CorePowerPointImportService corePowerPointImportService = new CorePowerPointImportService();
			TryAddDisposable(corePowerPointImportService);
			return corePowerPointImportService;
		}

		IPowerPointImportService Jab.IServiceProvider<IPowerPointImportService>.GetService()
		{
			PowerPointImportService powerPointImportService = new PowerPointImportService(GetService<ICorePowerPointImportService>(), GetService<IFileSystem>());
			TryAddDisposable(powerPointImportService);
			return powerPointImportService;
		}

		IImportHelperServices Jab.IServiceProvider<IImportHelperServices>.GetService()
		{
			ImportHelperServices importHelperServices = new ImportHelperServices();
			TryAddDisposable(importHelperServices);
			return importHelperServices;
		}

		IImportLocationSelectionDialogService Jab.IServiceProvider<IImportLocationSelectionDialogService>.GetService()
		{
			IImportLocationSelectionDialogService importLocationSelectionDialogService = _root.GetImportLocationSelectionDialogService();
			TryAddDisposable(importLocationSelectionDialogService);
			return importLocationSelectionDialogService;
		}

		IManageMediaAutoMaticallyProvider Jab.IServiceProvider<IManageMediaAutoMaticallyProvider>.GetService()
		{
			IManageMediaAutoMaticallyProvider advanced = ISettingsServiceProviderModule.GetAdvanced();
			TryAddDisposable(advanced);
			return advanced;
		}

		IFileCreator Jab.IServiceProvider<IFileCreator>.GetService()
		{
			FileCreator fileCreator = new FileCreator();
			TryAddDisposable(fileCreator);
			return fileCreator;
		}

		ISyncDataFactory Jab.IServiceProvider<ISyncDataFactory>.GetService()
		{
			SyncDataFactory syncDataFactory = new SyncDataFactory(GetService<IMessageService>(), GetService<IErrorReporter>());
			TryAddDisposable(syncDataFactory);
			return syncDataFactory;
		}

		IScreenArrangementFactory Jab.IServiceProvider<IScreenArrangementFactory>.GetService()
		{
			return _root.GetService<IScreenArrangementFactory>();
		}

		IAudioSettingsAnalyticsEventPublisher Jab.IServiceProvider<IAudioSettingsAnalyticsEventPublisher>.GetService()
		{
			AudioSettingsAnalyticsEventPublisher audioSettingsAnalyticsEventPublisher = new AudioSettingsAnalyticsEventPublisher();
			TryAddDisposable(audioSettingsAnalyticsEventPublisher);
			return audioSettingsAnalyticsEventPublisher;
		}

		IAudioInputCollection Jab.IServiceProvider<IAudioInputCollection>.GetService()
		{
			return _root.GetService<IAudioInputCollection>();
		}

		ICrdtProtoDirectoryFileScanner Jab.IServiceProvider<ICrdtProtoDirectoryFileScanner>.GetService()
		{
			return _root.GetService<ICrdtProtoDirectoryFileScanner>();
		}

		IMaskCollection Jab.IServiceProvider<IMaskCollection>.GetService()
		{
			return _root.GetService<IMaskCollection>();
		}

		StagePresentation Jab.IServiceProvider<StagePresentation>.GetService()
		{
			return _root.GetService<StagePresentation>();
		}

		ILocalDocumentSyncerFactory Jab.IServiceProvider<ILocalDocumentSyncerFactory>.GetService()
		{
			return _root.GetService<ILocalDocumentSyncerFactory>();
		}

		IOutputConfiguration Jab.IServiceProvider<IOutputConfiguration>.GetService()
		{
			return _root.GetService<IOutputConfiguration>();
		}

		ICollectionStorage Jab.IServiceProvider<ICollectionStorage>.GetService()
		{
			return _root.GetService<ICollectionStorage>();
		}

		IImportProcessFactory Jab.IServiceProvider<IImportProcessFactory>.GetService()
		{
			return _root.GetService<IImportProcessFactory>();
		}

		IAsyncFileImporter Jab.IServiceProvider<IAsyncFileImporter>.GetService()
		{
			AsyncFileImporter asyncFileImporter = new AsyncFileImporter(GetService<IImportProcessFactory>());
			TryAddDisposable(asyncFileImporter);
			return asyncFileImporter;
		}

		IMigrationSource Jab.IServiceProvider<IMigrationSource>.GetService()
		{
			IMigrationSource app = ISettingsServiceProviderModule.GetApp(GetService<App>());
			TryAddDisposable(app);
			return app;
		}

		INetwork Jab.IServiceProvider<INetwork>.GetService()
		{
			return _root.GetService<INetwork>();
		}

		ITimecodeSettingsRepository Jab.IServiceProvider<ITimecodeSettingsRepository>.GetService()
		{
			TimecodeSettingsRepository timecodeSettingsRepository = new TimecodeSettingsRepository(GetService<IApp>());
			TryAddDisposable(timecodeSettingsRepository);
			return timecodeSettingsRepository;
		}

		IImport Jab.IServiceProvider<IImport>.GetService()
		{
			IImport import = ISettingsServiceProviderModule.GetImport();
			TryAddDisposable(import);
			return import;
		}

		IStoredPcoOptions Jab.IServiceProvider<IStoredPcoOptions>.GetService()
		{
			IStoredPcoOptions storedPcoOptions = ISettingsServiceProviderModule.GetStoredPcoOptions();
			TryAddDisposable(storedPcoOptions);
			return storedPcoOptions;
		}

		ISongSelectConsumer Jab.IServiceProvider<ISongSelectConsumer>.GetService()
		{
			return _root.GetService<ISongSelectConsumer>();
		}

		IReportRepository Jab.IServiceProvider<IReportRepository>.GetService()
		{
			return _root.GetService<IReportRepository>();
		}

		IGeneral Jab.IServiceProvider<IGeneral>.GetService()
		{
			IGeneral general = ISettingsServiceProviderModule.GetGeneral();
			TryAddDisposable(general);
			return general;
		}

		IEnableAnalyticsProvider Jab.IServiceProvider<IEnableAnalyticsProvider>.GetService()
		{
			IEnableAnalyticsProvider general = ISettingsServiceProviderModule.GetGeneral();
			TryAddDisposable(general);
			return general;
		}

		IDisplay Jab.IServiceProvider<IDisplay>.GetService()
		{
			IDisplay display = ISettingsServiceProviderModule.GetDisplay();
			TryAddDisposable(display);
			return display;
		}

		ISync Jab.IServiceProvider<ISync>.GetService()
		{
			ISync sync = ISettingsServiceProviderModule.GetSync();
			TryAddDisposable(sync);
			return sync;
		}

		ILayout Jab.IServiceProvider<ILayout>.GetService()
		{
			ILayout layout = ISettingsServiceProviderModule.GetLayout();
			TryAddDisposable(layout);
			return layout;
		}

		IPlaylistActionValidatorFactory Jab.IServiceProvider<IPlaylistActionValidatorFactory>.GetService()
		{
			PlaylistActionValidatorFactory playlistActionValidatorFactory = new PlaylistActionValidatorFactory(GetService<IProPresenterResourceService>());
			TryAddDisposable(playlistActionValidatorFactory);
			return playlistActionValidatorFactory;
		}

		IActionBinderFactory Jab.IServiceProvider<IActionBinderFactory>.GetService()
		{
			return _root.GetService<IActionBinderFactory>();
		}

		IEncoderValidator Jab.IServiceProvider<IEncoderValidator>.GetService()
		{
			return _root.GetService<IEncoderValidator>();
		}

		IThemeImportProcessFactory Jab.IServiceProvider<IThemeImportProcessFactory>.GetService()
		{
			ThemeImportProcessFactory themeImportProcessFactory = new ThemeImportProcessFactory(GetService<IImportProcessFactory>());
			TryAddDisposable(themeImportProcessFactory);
			return themeImportProcessFactory;
		}

		IThemeAnalyiticEvents Jab.IServiceProvider<IThemeAnalyiticEvents>.GetService()
		{
			ThemeAnalyticEvents themeAnalyticEvents = new ThemeAnalyticEvents();
			TryAddDisposable(themeAnalyticEvents);
			return themeAnalyticEvents;
		}

		IDxDiagReaderFactory Jab.IServiceProvider<IDxDiagReaderFactory>.GetService()
		{
			DxDiagReaderFactory dxDiagReaderFactory = new DxDiagReaderFactory();
			TryAddDisposable(dxDiagReaderFactory);
			return dxDiagReaderFactory;
		}

		private IIdProvider GetIIdProvider_BugsnagIdProviderKey()
		{
			return _root.GetIIdProvider_BugsnagIdProviderKey();
		}

		ISystemInfoProvider Jab.IServiceProvider<ISystemInfoProvider>.GetService()
		{
			ISystemInfoProvider systemInfoProvider = GetSystemInfoProvider(GetService<IFileSystem>(), GetService<IDxDiagReaderFactory>(), GetIIdProvider_BugsnagIdProviderKey());
			TryAddDisposable(systemInfoProvider);
			return systemInfoProvider;
		}

		IApplicationLaunchEventPublisher Jab.IServiceProvider<IApplicationLaunchEventPublisher>.GetService()
		{
			return _root.GetService<IApplicationLaunchEventPublisher>();
		}

		ICaptureAnalyticEventsPublisher Jab.IServiceProvider<ICaptureAnalyticEventsPublisher>.GetService()
		{
			CaptureAnalyticEventsPublisher captureAnalyticEventsPublisher = new CaptureAnalyticEventsPublisher();
			TryAddDisposable(captureAnalyticEventsPublisher);
			return captureAnalyticEventsPublisher;
		}

		IStartupSettingsEventsPublisher Jab.IServiceProvider<IStartupSettingsEventsPublisher>.GetService()
		{
			StartupSettingsEventsPublisher startupSettingsEventsPublisher = new StartupSettingsEventsPublisher();
			TryAddDisposable(startupSettingsEventsPublisher);
			return startupSettingsEventsPublisher;
		}

		IUiPreferencesAnalyticEventsPublisher Jab.IServiceProvider<IUiPreferencesAnalyticEventsPublisher>.GetService()
		{
			UiPreferencesAnalyticEventsPublisher uiPreferencesAnalyticEventsPublisher = new UiPreferencesAnalyticEventsPublisher();
			TryAddDisposable(uiPreferencesAnalyticEventsPublisher);
			return uiPreferencesAnalyticEventsPublisher;
		}

		ITestPatternAnalyticEventsPublisher Jab.IServiceProvider<ITestPatternAnalyticEventsPublisher>.GetService()
		{
			TestPatternAnalyticEventsPublisher testPatternAnalyticEventsPublisher = new TestPatternAnalyticEventsPublisher();
			TryAddDisposable(testPatternAnalyticEventsPublisher);
			return testPatternAnalyticEventsPublisher;
		}

		IWelcomeAnalyticEventsPublisher Jab.IServiceProvider<IWelcomeAnalyticEventsPublisher>.GetService()
		{
			WelcomeAnalyticEventsPublisher welcomeAnalyticEventsPublisher = new WelcomeAnalyticEventsPublisher();
			TryAddDisposable(welcomeAnalyticEventsPublisher);
			return welcomeAnalyticEventsPublisher;
		}

		ITimecodeAnalyticsEvents Jab.IServiceProvider<ITimecodeAnalyticsEvents>.GetService()
		{
			TimecodeAnalyticsEvents timecodeAnalyticsEvents = new TimecodeAnalyticsEvents();
			TryAddDisposable(timecodeAnalyticsEvents);
			return timecodeAnalyticsEvents;
		}

		IPlaybackMarkerAnalyticsEvents Jab.IServiceProvider<IPlaybackMarkerAnalyticsEvents>.GetService()
		{
			PlaybackMarkerAnalyticsEvents playbackMarkerAnalyticsEvents = new PlaybackMarkerAnalyticsEvents();
			TryAddDisposable(playbackMarkerAnalyticsEvents);
			return playbackMarkerAnalyticsEvents;
		}

		ITimelineAnalyticsEvents Jab.IServiceProvider<ITimelineAnalyticsEvents>.GetService()
		{
			TimelineAnalyticsEvents timelineAnalyticsEvents = new TimelineAnalyticsEvents();
			TryAddDisposable(timelineAnalyticsEvents);
			return timelineAnalyticsEvents;
		}

		ICCLIReportAnalyticsEvents Jab.IServiceProvider<ICCLIReportAnalyticsEvents>.GetService()
		{
			CCLIReportAnalyticsEvents cCLIReportAnalyticsEvents = new CCLIReportAnalyticsEvents();
			TryAddDisposable(cCLIReportAnalyticsEvents);
			return cCLIReportAnalyticsEvents;
		}

		IMediaCleanupSizeEventPublisher Jab.IServiceProvider<IMediaCleanupSizeEventPublisher>.GetService()
		{
			MediaCleanupSizeEventPublisher mediaCleanupSizeEventPublisher = new MediaCleanupSizeEventPublisher();
			TryAddDisposable(mediaCleanupSizeEventPublisher);
			return mediaCleanupSizeEventPublisher;
		}

		IMediaAnalyticsSender Jab.IServiceProvider<IMediaAnalyticsSender>.GetService()
		{
			MediaAnalyticsSender mediaAnalyticsSender = new MediaAnalyticsSender();
			TryAddDisposable(mediaAnalyticsSender);
			return mediaAnalyticsSender;
		}

		IWorkspaceAnalyticsEventPublisher Jab.IServiceProvider<IWorkspaceAnalyticsEventPublisher>.GetService()
		{
			WorkspaceAnalyticsEventPublisher workspaceAnalyticsEventPublisher = new WorkspaceAnalyticsEventPublisher();
			TryAddDisposable(workspaceAnalyticsEventPublisher);
			return workspaceAnalyticsEventPublisher;
		}

		ICloudOnboardingAnalyticsEventPublisher Jab.IServiceProvider<ICloudOnboardingAnalyticsEventPublisher>.GetService()
		{
			CloudOnboardingAnalyticsEventPublisher cloudOnboardingAnalyticsEventPublisher = new CloudOnboardingAnalyticsEventPublisher();
			TryAddDisposable(cloudOnboardingAnalyticsEventPublisher);
			return cloudOnboardingAnalyticsEventPublisher;
		}

		IFileDownloadObserverFactory Jab.IServiceProvider<IFileDownloadObserverFactory>.GetService()
		{
			FileDownloadObserverFactory fileDownloadObserverFactory = new FileDownloadObserverFactory(GetService<IFileSystem>(), GetService<IImport>(), GetService<IApp>(), GetService<IMediaFactory>(), GetService<ITransitionDescriptionCollection>());
			TryAddDisposable(fileDownloadObserverFactory);
			return fileDownloadObserverFactory;
		}

		IProContentDownloadProcessFactory Jab.IServiceProvider<IProContentDownloadProcessFactory>.GetService()
		{
			ProContentDownloadProcessFactory proContentDownloadProcessFactory = new ProContentDownloadProcessFactory(GetService<IDownloadItemFactory>(), GetService<IProContentConsumer>(), GetService<IProPresenterResourceService>(), GetService<IApp>(), GetService<IProContentDownloadFailedDialogService>(), GetService<IProContentAnalyticEventsPublisher>(), GetService<IDownloadManager>(), GetService<IFileDownloadObserverFactory>());
			TryAddDisposable(proContentDownloadProcessFactory);
			return proContentDownloadProcessFactory;
		}

		IStopwatchFactory Jab.IServiceProvider<IStopwatchFactory>.GetService()
		{
			StopwatchFactory stopwatchFactory = new StopwatchFactory();
			TryAddDisposable(stopwatchFactory);
			return stopwatchFactory;
		}

		ICacheFactory Jab.IServiceProvider<ICacheFactory>.GetService()
		{
			CacheFactory cacheFactory = new CacheFactory(GetService<IStopwatchFactory>());
			TryAddDisposable(cacheFactory);
			return cacheFactory;
		}

		IProContentProvider Jab.IServiceProvider<IProContentProvider>.GetService()
		{
			return _root.GetService<IProContentProvider>();
		}

		IUriCacheService<IReadOnlyList<IAnimationFrame>> Jab.IServiceProvider<IUriCacheService<IReadOnlyList<IAnimationFrame>>>.GetService()
		{
			return _root.GetService<IUriCacheService<IReadOnlyList<IAnimationFrame>>>();
		}

		IOutputRepository Jab.IServiceProvider<IOutputRepository>.GetService()
		{
			return _root.GetService<IOutputRepository>();
		}

		ICommunicationOutput Jab.IServiceProvider<ICommunicationOutput>.GetService()
		{
			return _root.GetService<ICommunicationOutput>();
		}

		IOutputService Jab.IServiceProvider<IOutputService>.GetService()
		{
			OutputService outputService = new OutputService(GetService<ssAPIOutput>(), GetService<IOutputRepository>(), GetService<ICommunicationOutput>(), GetService<IOutputConfiguration>());
			TryAddDisposable(outputService);
			return outputService;
		}

		IErrorPrompt Jab.IServiceProvider<IErrorPrompt>.GetService()
		{
			return _root.GetService<IErrorPrompt>();
		}

		IResiPlugin Jab.IServiceProvider<IResiPlugin>.GetService()
		{
			return _root.GetService<IResiPlugin>();
		}

		IResiCustomEndpointsStore Jab.IServiceProvider<IResiCustomEndpointsStore>.GetService()
		{
			return _root.GetService<IResiCustomEndpointsStore>();
		}

		IResiEndpoints Jab.IServiceProvider<IResiEndpoints>.GetService()
		{
			IResiEndpoints resiEndpoints = IResiServiceProviderModule.GetResiEndpoints(GetService<IResiCustomEndpointsStore>(), GetService<IApiService>());
			TryAddDisposable(resiEndpoints);
			return resiEndpoints;
		}

		IResiWebClient Jab.IServiceProvider<IResiWebClient>.GetService()
		{
			return _root.GetService<IResiWebClient>();
		}

		IMessages<AppMessages> Jab.IServiceProvider<IMessages<AppMessages>>.GetService()
		{
			return _root.GetService<IMessages<AppMessages>>();
		}

		IUpdateClient Jab.IServiceProvider<IUpdateClient>.GetService()
		{
			return _root.GetService<IUpdateClient>();
		}

		ITestPatternPropertyFactory Jab.IServiceProvider<ITestPatternPropertyFactory>.GetService()
		{
			TestPatternPropertyFactory testPatternPropertyFactory = new TestPatternPropertyFactory();
			TryAddDisposable(testPatternPropertyFactory);
			return testPatternPropertyFactory;
		}

		ITestPatternDefinitionFactory Jab.IServiceProvider<ITestPatternDefinitionFactory>.GetService()
		{
			TestPatternDefinitionFactory testPatternDefinitionFactory = new TestPatternDefinitionFactory(GetService<ITestPatternPropertyFactory>());
			TryAddDisposable(testPatternDefinitionFactory);
			return testPatternDefinitionFactory;
		}

		ITestPatternStateFactory Jab.IServiceProvider<ITestPatternStateFactory>.GetService()
		{
			TestPatternStateFactory testPatternStateFactory = new TestPatternStateFactory();
			TryAddDisposable(testPatternStateFactory);
			return testPatternStateFactory;
		}

		ITestPatternPersistence Jab.IServiceProvider<ITestPatternPersistence>.GetService()
		{
			return _root.GetService<ITestPatternPersistence>();
		}

		ITestPatternService Jab.IServiceProvider<ITestPatternService>.GetService()
		{
			return _root.GetService<ITestPatternService>();
		}

		IFileProvider Jab.IServiceProvider<IFileProvider>.GetService()
		{
			FileProvider fileProvider = new FileProvider();
			TryAddDisposable(fileProvider);
			return fileProvider;
		}

		ISyncDataProvider Jab.IServiceProvider<ISyncDataProvider>.GetService()
		{
			SyncDataProvider syncDataProvider = new SyncDataProvider(GetService<IFileProvider>());
			TryAddDisposable(syncDataProvider);
			return syncDataProvider;
		}

		private ISyncRepository<ISyncData> GetISyncRepository_ISyncData_RemoteFileRepositoryKey()
		{
			RemoteFileRepository remoteFileRepository = new RemoteFileRepository(GetService<ISyncDataProvider>(), GetService<IErrorReporter>());
			TryAddDisposable(remoteFileRepository);
			return remoteFileRepository;
		}

		ISyncActionProvider Jab.IServiceProvider<ISyncActionProvider>.GetService()
		{
			SyncActionProvider syncActionProvider = new SyncActionProvider();
			TryAddDisposable(syncActionProvider);
			return syncActionProvider;
		}

		IAppContinuationService Jab.IServiceProvider<IAppContinuationService>.GetService()
		{
			IAppContinuationService continuationService = _root.GetContinuationService();
			TryAddDisposable(continuationService);
			return continuationService;
		}

		IAppInstallerFactory Jab.IServiceProvider<IAppInstallerFactory>.GetService()
		{
			AppInstallerFactory appInstallerFactory = new AppInstallerFactory(GetService<IMessageService>(), GetService<IAppContinuationService>());
			TryAddDisposable(appInstallerFactory);
			return appInstallerFactory;
		}

		IAppDownloadFactory Jab.IServiceProvider<IAppDownloadFactory>.GetService()
		{
			AppDownloadFactory appDownloadFactory = new AppDownloadFactory(GetService<IDownloadProcessFactory>(), GetService<IAppInstallerFactory>(), GetService<ILogger>());
			TryAddDisposable(appDownloadFactory);
			return appDownloadFactory;
		}

		IAppUpdateUserDialogService Jab.IServiceProvider<IAppUpdateUserDialogService>.GetService()
		{
			return _root.GetService<IAppUpdateUserDialogService>();
		}

		IAppUpdateService Jab.IServiceProvider<IAppUpdateService>.GetService()
		{
			return _root.GetService<IAppUpdateService>();
		}

		IIndexingService Jab.IServiceProvider<IIndexingService>.GetService()
		{
			IndexingService indexingService = new IndexingService();
			TryAddDisposable(indexingService);
			return indexingService;
		}

		IPresentationCapableSyncDataFactory Jab.IServiceProvider<IPresentationCapableSyncDataFactory>.GetService()
		{
			SyncDataFactory syncDataFactory = new SyncDataFactory(GetService<IMessageService>(), GetService<IErrorReporter>());
			TryAddDisposable(syncDataFactory);
			return syncDataFactory;
		}

		IBibleDataStore Jab.IServiceProvider<IBibleDataStore>.GetService()
		{
			return _root.GetService<IBibleDataStore>();
		}

		IBibleProvider Jab.IServiceProvider<IBibleProvider>.GetService()
		{
			return _root.GetService<IBibleProvider>();
		}

		IMultiTracksConsumer Jab.IServiceProvider<IMultiTracksConsumer>.GetService()
		{
			return _root.GetService<IMultiTracksConsumer>();
		}

		IAuthenticatorFactory Jab.IServiceProvider<IAuthenticatorFactory>.GetService()
		{
			AuthenticatorFactory authenticatorFactory = new AuthenticatorFactory(GetService<IRestClientFactory>(), GetService<ICurrentTimeOffset>(), GetService<ILogger>());
			TryAddDisposable(authenticatorFactory);
			return authenticatorFactory;
		}

		IPCOConsumer Jab.IServiceProvider<IPCOConsumer>.GetService()
		{
			return _root.GetService<IPCOConsumer>();
		}

		IPCOUpdater Jab.IServiceProvider<IPCOUpdater>.GetService()
		{
			return _root.GetService<IPCOUpdater>();
		}

		ThumbnailViewSettings Jab.IServiceProvider<ThumbnailViewSettings>.GetService()
		{
			ThumbnailViewSettings thumbnailViewSettings = new ThumbnailViewSettings(GetService<IApp>());
			TryAddDisposable(thumbnailViewSettings);
			return thumbnailViewSettings;
		}

		IExportProcessFactory Jab.IServiceProvider<IExportProcessFactory>.GetService()
		{
			return _root.GetService<IExportProcessFactory>();
		}

		IInputActions Jab.IServiceProvider<IInputActions>.GetService()
		{
			return _root.GetService<IInputActions>();
		}

		IMediaImportService Jab.IServiceProvider<IMediaImportService>.GetService()
		{
			MediaImportService mediaImportService = new MediaImportService(GetService<IImportProcessFactory>());
			TryAddDisposable(mediaImportService);
			return mediaImportService;
		}

		IMediaFileProvider Jab.IServiceProvider<IMediaFileProvider>.GetService()
		{
			MediaFileProvider mediaFileProvider = new MediaFileProvider(GetService<IProPresenterResourceService>(), GetService<IOutputConfiguration>(), GetService<IFileSystem>(), GetService<IMaskCollection>());
			TryAddDisposable(mediaFileProvider);
			return mediaFileProvider;
		}

		IWorkspaceInspectionService Jab.IServiceProvider<IWorkspaceInspectionService>.GetService()
		{
			WorkspaceInspectionService workspaceInspectionService = new WorkspaceInspectionService(GetService<IWorkspaceService>(), GetService<IVisualPlaylistRepo>(), GetService<IMediaFileProvider>(), GetService<ILogger>());
			TryAddDisposable(workspaceInspectionService);
			return workspaceInspectionService;
		}

		ICloudWorkspaceService Jab.IServiceProvider<ICloudWorkspaceService>.GetService()
		{
			return _root.GetService<ICloudWorkspaceService>();
		}

		ICloudConversionService Jab.IServiceProvider<ICloudConversionService>.GetService()
		{
			CloudConversionService cloudConversionService = new CloudConversionService(GetService<ICloudWorkspaceService>(), GetService<ILogger>(), GetService<IWorkspaceAnalyticsEventPublisher>(), GetService<IStopwatchFactory>());
			TryAddDisposable(cloudConversionService);
			return cloudConversionService;
		}

		ICloudOnboardingService Jab.IServiceProvider<ICloudOnboardingService>.GetService()
		{
			return _root.GetService<ICloudOnboardingService>();
		}

		IMatchSongsInteractor Jab.IServiceProvider<IMatchSongsInteractor>.GetService()
		{
			MatchSongsInteractor matchSongsInteractor = new MatchSongsInteractor(GetService<IPCOConsumer>());
			TryAddDisposable(matchSongsInteractor);
			return matchSongsInteractor;
		}

		IWorkspaceDocumentOrchestrator Jab.IServiceProvider<IWorkspaceDocumentOrchestrator>.GetService()
		{
			return _root.GetService<IWorkspaceDocumentOrchestrator>();
		}

		ThemeCollection Jab.IServiceProvider<ThemeCollection>.GetService()
		{
			return _root.GetService<ThemeCollection>();
		}

		IThemeCollection Jab.IServiceProvider<IThemeCollection>.GetService()
		{
			IThemeCollection themeCollectionRedirect = IProPresenterDOServiceProviderModule.GetThemeCollectionRedirect(GetService<ThemeCollection>());
			TryAddDisposable(themeCollectionRedirect);
			return themeCollectionRedirect;
		}

		IFileFilterProvider Jab.IServiceProvider<IFileFilterProvider>.GetService()
		{
			FileFilterProvider fileFilterProvider = new FileFilterProvider();
			TryAddDisposable(fileFilterProvider);
			return fileFilterProvider;
		}

		IFileUtility Jab.IServiceProvider<IFileUtility>.GetService()
		{
			FileUtility fileUtility = new FileUtility(GetService<ILogger>());
			TryAddDisposable(fileUtility);
			return fileUtility;
		}

		IProcessHelper Jab.IServiceProvider<IProcessHelper>.GetService()
		{
			return _root.GetService<IProcessHelper>();
		}

		INetworkChange Jab.IServiceProvider<INetworkChange>.GetService()
		{
			NetworkChange networkChange = new NetworkChange();
			TryAddDisposable(networkChange);
			return networkChange;
		}

		IFileObservatory Jab.IServiceProvider<IFileObservatory>.GetService()
		{
			return _root.GetService<IFileObservatory>();
		}

		ISettingsSearchFactory Jab.IServiceProvider<ISettingsSearchFactory>.GetService()
		{
			SettingsSearchFactory settingsSearchFactory = new SettingsSearchFactory(GetService<ILocalization>());
			TryAddDisposable(settingsSearchFactory);
			return settingsSearchFactory;
		}

		INetworkDialogService Jab.IServiceProvider<INetworkDialogService>.GetService()
		{
			NetworkDialogService networkDialogService = new NetworkDialogService();
			TryAddDisposable(networkDialogService);
			return networkDialogService;
		}

		IMediaCleanupPrompt Jab.IServiceProvider<IMediaCleanupPrompt>.GetService()
		{
			MediaCleanupPrompt mediaCleanupPrompt = new MediaCleanupPrompt();
			TryAddDisposable(mediaCleanupPrompt);
			return mediaCleanupPrompt;
		}

		IMidiDeviceSettingsVM Jab.IServiceProvider<IMidiDeviceSettingsVM>.GetService()
		{
			return _root.GetService<IMidiDeviceSettingsVM>();
		}

		IMidiWindowProvider Jab.IServiceProvider<IMidiWindowProvider>.GetService()
		{
			return _root.GetService<IMidiWindowProvider>();
		}

		IFileSelectorService Jab.IServiceProvider<IFileSelectorService>.GetService()
		{
			FileSelectorService fileSelectorService = new FileSelectorService();
			TryAddDisposable(fileSelectorService);
			return fileSelectorService;
		}

		ICCLIReportPrompt Jab.IServiceProvider<ICCLIReportPrompt>.GetService()
		{
			CCLIReportPrompt cCLIReportPrompt = new CCLIReportPrompt(GetService<IFileSelectorService>());
			TryAddDisposable(cCLIReportPrompt);
			return cCLIReportPrompt;
		}

		INdiInputsSettingsDialogService Jab.IServiceProvider<INdiInputsSettingsDialogService>.GetService()
		{
			NdiInputsSettingsDialogService ndiInputsSettingsDialogService = new NdiInputsSettingsDialogService(GetService<IUiDispatcher>(), GetService<ILocalization>());
			TryAddDisposable(ndiInputsSettingsDialogService);
			return ndiInputsSettingsDialogService;
		}

		IAirCastPrompt Jab.IServiceProvider<IAirCastPrompt>.GetService()
		{
			AirCastPrompt airCastPrompt = new AirCastPrompt(GetService<IWebSourceProvider>(), GetService<IHyperlinkService>());
			TryAddDisposable(airCastPrompt);
			return airCastPrompt;
		}

		IAirCastConfiguration Jab.IServiceProvider<IAirCastConfiguration>.GetService()
		{
			return _root.GetService<IAirCastConfiguration>();
		}

		IInstallFileExecutor Jab.IServiceProvider<IInstallFileExecutor>.GetService()
		{
			return _root.GetService<IInstallFileExecutor>();
		}

		IAirCastPluginDownload Jab.IServiceProvider<IAirCastPluginDownload>.GetService()
		{
			AirCastPluginDownload airCastPluginDownload = new AirCastPluginDownload(GetService<IAirCastConfiguration>(), GetService<IWebSourceProvider>(), GetService<IFileSystem>(), GetService<IInstallFileExecutor>(), GetService<IRestClientFactory>(), GetService<IAirCastPrompt>(), GetService<IZipService>());
			TryAddDisposable(airCastPluginDownload);
			return airCastPluginDownload;
		}

		ICCLIReportCollectionVM Jab.IServiceProvider<ICCLIReportCollectionVM>.GetService()
		{
			return _root.GetService<ICCLIReportCollectionVM>();
		}

		ICopyrightSettingsVM Jab.IServiceProvider<ICopyrightSettingsVM>.GetService()
		{
			return _root.GetService<ICopyrightSettingsVM>();
		}

		INetworkCommandFactory Jab.IServiceProvider<INetworkCommandFactory>.GetService()
		{
			INetworkCommandFactory networkCommandFactory = IControllerServiceProviderModule.GetNetworkCommandFactory(GetService<IOutputRepository>());
			TryAddDisposable(networkCommandFactory);
			return networkCommandFactory;
		}

		INetworkCommandTrigger Jab.IServiceProvider<INetworkCommandTrigger>.GetService()
		{
			return _root.GetService<INetworkCommandTrigger>();
		}

		INetworkTriggerDataTransferFactory Jab.IServiceProvider<INetworkTriggerDataTransferFactory>.GetService()
		{
			INetworkTriggerDataTransferFactory networkTriggerDataTransferFactory = IControllerServiceProviderModule.GetNetworkTriggerDataTransferFactory(GetService<IOutputConfiguration>());
			TryAddDisposable(networkTriggerDataTransferFactory);
			return networkTriggerDataTransferFactory;
		}

		IResiController Jab.IServiceProvider<IResiController>.GetService()
		{
			return _root.GetService<IResiController>();
		}

		ICrashRecovery Jab.IServiceProvider<ICrashRecovery>.GetService()
		{
			return _root.GetService<ICrashRecovery>();
		}

		ICapturePrompt Jab.IServiceProvider<ICapturePrompt>.GetService()
		{
			CapturePrompt capturePrompt = new CapturePrompt(GetService<ITimerFactory>(), GetService<IUiDispatcher>());
			TryAddDisposable(capturePrompt);
			return capturePrompt;
		}

		CaptureController Jab.IServiceProvider<CaptureController>.GetService()
		{
			return _root.GetService<CaptureController>();
		}

		ICaptureService Jab.IServiceProvider<ICaptureService>.GetService()
		{
			ICaptureService captureController = IViewModelsServiceProviderModule.GetCaptureController(GetService<CaptureController>());
			TryAddDisposable(captureController);
			return captureController;
		}

		ITimedPlaybackRepository Jab.IServiceProvider<ITimedPlaybackRepository>.GetService()
		{
			return _root.GetService<ITimedPlaybackRepository>();
		}

		ITimelineService Jab.IServiceProvider<ITimelineService>.GetService()
		{
			return _root.GetService<ITimelineService>();
		}

		ITimecodeService Jab.IServiceProvider<ITimecodeService>.GetService()
		{
			return _root.GetService<ITimecodeService>();
		}

		ITimelineManager Jab.IServiceProvider<ITimelineManager>.GetService()
		{
			return _root.GetService<ITimelineManager>();
		}

		ITransferHandlerFactory Jab.IServiceProvider<ITransferHandlerFactory>.GetService()
		{
			TransferHandlerFactory transferHandlerFactory = new TransferHandlerFactory(GetService<IProPresenterResourceService>(), GetService<ITimecodeService>(), GetService<IProPresenterDOFactoryProvider>(), GetService<IUiDispatcher>(), GetService<ITransitionDescriptionCollection>());
			TryAddDisposable(transferHandlerFactory);
			return transferHandlerFactory;
		}

		CoreManager Jab.IServiceProvider<CoreManager>.GetService()
		{
			return _root.GetService<CoreManager>();
		}

		ICoreManager Jab.IServiceProvider<ICoreManager>.GetService()
		{
			ICoreManager coreManager = IControllerServiceProviderModule.GetCoreManager(GetService<CoreManager>());
			TryAddDisposable(coreManager);
			return coreManager;
		}

		IGeneralSettingsVM Jab.IServiceProvider<IGeneralSettingsVM>.GetService()
		{
			return _root.GetService<IGeneralSettingsVM>();
		}

		ICommandSender Jab.IServiceProvider<ICommandSender>.GetService()
		{
			return _root.GetService<ICommandSender>();
		}

		IServerStateHandler Jab.IServiceProvider<IServerStateHandler>.GetService()
		{
			return _root.GetService<IServerStateHandler>();
		}

		INetworkEnvironment Jab.IServiceProvider<INetworkEnvironment>.GetService()
		{
			return _root.GetService<INetworkEnvironment>();
		}

		ILinkRequestFactory Jab.IServiceProvider<ILinkRequestFactory>.GetService()
		{
			LinkRequestFactory linkRequestFactory = new LinkRequestFactory();
			TryAddDisposable(linkRequestFactory);
			return linkRequestFactory;
		}

		INetworkLinkService Jab.IServiceProvider<INetworkLinkService>.GetService()
		{
			return _root.GetService<INetworkLinkService>();
		}

		INetworkLinkPrompt Jab.IServiceProvider<INetworkLinkPrompt>.GetService()
		{
			return _root.GetService<INetworkLinkPrompt>();
		}

		INetworkLinkVM Jab.IServiceProvider<INetworkLinkVM>.GetService()
		{
			return _root.GetService<INetworkLinkVM>();
		}

		INetworkSettingsVM Jab.IServiceProvider<INetworkSettingsVM>.GetService()
		{
			return _root.GetService<INetworkSettingsVM>();
		}

		IRegistrationUnlockCodeVM Jab.IServiceProvider<IRegistrationUnlockCodeVM>.GetService()
		{
			return _root.GetService<IRegistrationUnlockCodeVM>();
		}

		IRegistrationSubpageVMFactory Jab.IServiceProvider<IRegistrationSubpageVMFactory>.GetService()
		{
			RegistrationSubpageVMFactory registrationSubpageVMFactory = new RegistrationSubpageVMFactory(GetService<IHyperlinkService>(), GetService<IRegistrationWebResourceService>(), GetService<IRegistrationOperationFactory>(), GetService<IRegistrationUnlockCodeVM>(), GetService<IRegistrationUserDialogService>(), GetService<IRegistrationStateProvider>());
			TryAddDisposable(registrationSubpageVMFactory);
			return registrationSubpageVMFactory;
		}

		IOrganizationConsumer Jab.IServiceProvider<IOrganizationConsumer>.GetService()
		{
			return _root.GetService<IOrganizationConsumer>();
		}

		IUserAvatarProvider Jab.IServiceProvider<IUserAvatarProvider>.GetService()
		{
			return _root.GetService<IUserAvatarProvider>();
		}

		IRegistrationMainPageVM Jab.IServiceProvider<IRegistrationMainPageVM>.GetService()
		{
			return _root.GetService<IRegistrationMainPageVM>();
		}

		IAccountCenterVM Jab.IServiceProvider<IAccountCenterVM>.GetService()
		{
			return _root.GetService<IAccountCenterVM>();
		}

		IUpdatesSettingsVM Jab.IServiceProvider<IUpdatesSettingsVM>.GetService()
		{
			return _root.GetService<IUpdatesSettingsVM>();
		}

		IClockSourceProvider Jab.IServiceProvider<IClockSourceProvider>.GetService()
		{
			return _root.GetService<IClockSourceProvider>();
		}

		IClockSourceService Jab.IServiceProvider<IClockSourceService>.GetService()
		{
			return _root.GetService<IClockSourceService>();
		}

		IClockSourceVM Jab.IServiceProvider<IClockSourceVM>.GetService()
		{
			return _root.GetService<IClockSourceVM>();
		}

		IScreenSettingsVM Jab.IServiceProvider<IScreenSettingsVM>.GetService()
		{
			return _root.GetService<IScreenSettingsVM>();
		}

		IInputsSettingsService Jab.IServiceProvider<IInputsSettingsService>.GetService()
		{
			InputsSettingsService inputsSettingsService = new InputsSettingsService(GetService<IOutputRepository>(), GetService<IProCoreInstance>(), GetService<IApp>());
			TryAddDisposable(inputsSettingsService);
			return inputsSettingsService;
		}

		IVideoInputsSettingsVM Jab.IServiceProvider<IVideoInputsSettingsVM>.GetService()
		{
			return _root.GetService<IVideoInputsSettingsVM>();
		}

		IVideoInputItemVMFactory Jab.IServiceProvider<IVideoInputItemVMFactory>.GetService()
		{
			return _root.GetService<IVideoInputItemVMFactory>();
		}

		IAudioInputsSettingsVM Jab.IServiceProvider<IAudioInputsSettingsVM>.GetService()
		{
			return _root.GetService<IAudioInputsSettingsVM>();
		}

		INdiInputsSettingsVM Jab.IServiceProvider<INdiInputsSettingsVM>.GetService()
		{
			return _root.GetService<INdiInputsSettingsVM>();
		}

		IInputsSettingsVM Jab.IServiceProvider<IInputsSettingsVM>.GetService()
		{
			return _root.GetService<IInputsSettingsVM>();
		}

		IDevicesSettingsVM Jab.IServiceProvider<IDevicesSettingsVM>.GetService()
		{
			return _root.GetService<IDevicesSettingsVM>();
		}

		IMediaSettingsVMFactory Jab.IServiceProvider<IMediaSettingsVMFactory>.GetService()
		{
			MediaSettingsVMFactory mediaSettingsVMFactory = new MediaSettingsVMFactory(GetService<ILocalization>());
			TryAddDisposable(mediaSettingsVMFactory);
			return mediaSettingsVMFactory;
		}

		IMediaSearchPathsSettingsVM Jab.IServiceProvider<IMediaSearchPathsSettingsVM>.GetService()
		{
			return _root.GetService<IMediaSearchPathsSettingsVM>();
		}

		IMediaFilesProvider Jab.IServiceProvider<IMediaFilesProvider>.GetService()
		{
			MediaFilesProvider mediaFilesProvider = new MediaFilesProvider(GetService<IProPresenterResourceService>(), GetService<IFileSystem>(), GetService<IGeneral>(), GetService<IOutputConfiguration>(), GetService<IMaskCollection>());
			TryAddDisposable(mediaFilesProvider);
			return mediaFilesProvider;
		}

		IMediaCleanupService Jab.IServiceProvider<IMediaCleanupService>.GetService()
		{
			return _root.GetService<IMediaCleanupService>();
		}

		IMediaCleanupVM Jab.IServiceProvider<IMediaCleanupVM>.GetService()
		{
			return _root.GetService<IMediaCleanupVM>();
		}

		IMediaSettingsVM Jab.IServiceProvider<IMediaSettingsVM>.GetService()
		{
			return _root.GetService<IMediaSettingsVM>();
		}

		IAudioSettingsVM Jab.IServiceProvider<IAudioSettingsVM>.GetService()
		{
			return _root.GetService<IAudioSettingsVM>();
		}

		IImportSettingsVM Jab.IServiceProvider<IImportSettingsVM>.GetService()
		{
			return _root.GetService<IImportSettingsVM>();
		}

		IPlanningCenterSettingsVM Jab.IServiceProvider<IPlanningCenterSettingsVM>.GetService()
		{
			return _root.GetService<IPlanningCenterSettingsVM>();
		}

		IMultiTracksSettingsVM Jab.IServiceProvider<IMultiTracksSettingsVM>.GetService()
		{
			return _root.GetService<IMultiTracksSettingsVM>();
		}

		IAutoReportDialogPrompt Jab.IServiceProvider<IAutoReportDialogPrompt>.GetService()
		{
			AutoReportDialogPrompt autoReportDialogPrompt = new AutoReportDialogPrompt();
			TryAddDisposable(autoReportDialogPrompt);
			return autoReportDialogPrompt;
		}

		ISongSelectSettingsVM Jab.IServiceProvider<ISongSelectSettingsVM>.GetService()
		{
			return _root.GetService<ISongSelectSettingsVM>();
		}

		IResiUpdateVM Jab.IServiceProvider<IResiUpdateVM>.GetService()
		{
			return _root.GetService<IResiUpdateVM>();
		}

		ILoginDialogFactory Jab.IServiceProvider<ILoginDialogFactory>.GetService()
		{
			LoginDialogFactory loginDialogFactory = new LoginDialogFactory(GetService<ICookieManagerService>());
			TryAddDisposable(loginDialogFactory);
			return loginDialogFactory;
		}

		IResiPrompt Jab.IServiceProvider<IResiPrompt>.GetService()
		{
			ResiPrompt resiPrompt = new ResiPrompt();
			TryAddDisposable(resiPrompt);
			return resiPrompt;
		}

		IResiAuthorizationInteractor Jab.IServiceProvider<IResiAuthorizationInteractor>.GetService()
		{
			return _root.GetService<IResiAuthorizationInteractor>();
		}

		IResiSettingsVM Jab.IServiceProvider<IResiSettingsVM>.GetService()
		{
			return _root.GetService<IResiSettingsVM>();
		}

		IIntegrationsSettingsVM Jab.IServiceProvider<IIntegrationsSettingsVM>.GetService()
		{
			return _root.GetService<IIntegrationsSettingsVM>();
		}

		IGroupLabelItemVMFactory Jab.IServiceProvider<IGroupLabelItemVMFactory>.GetService()
		{
			GroupLabelItemVMFactory groupLabelItemVMFactory = new GroupLabelItemVMFactory();
			TryAddDisposable(groupLabelItemVMFactory);
			return groupLabelItemVMFactory;
		}

		IGroupsSettingsVM Jab.IServiceProvider<IGroupsSettingsVM>.GetService()
		{
			return _root.GetService<IGroupsSettingsVM>();
		}

		ILabelItemVMFactory Jab.IServiceProvider<ILabelItemVMFactory>.GetService()
		{
			LabelItemVMFactory labelItemVMFactory = new LabelItemVMFactory();
			TryAddDisposable(labelItemVMFactory);
			return labelItemVMFactory;
		}

		ILabelsSettingsVM Jab.IServiceProvider<ILabelsSettingsVM>.GetService()
		{
			return _root.GetService<ILabelsSettingsVM>();
		}

		private ISyncRepository<ISyncData> GetISyncRepository_ISyncData_LocalFileRepositoryKey()
		{
			ISyncRepository<ISyncData> localFileRepository = IGlobalServiceProviderModule.GetLocalFileRepository(GetService<ISyncDataProvider>(), GetService<IOutputService>(), GetService<IErrorReporter>(), GetService<IInputActions>());
			TryAddDisposable(localFileRepository);
			return localFileRepository;
		}

		ISyncController Jab.IServiceProvider<ISyncController>.GetService()
		{
			return _root.GetService<ISyncController>();
		}

		ISyncSettingsVM Jab.IServiceProvider<ISyncSettingsVM>.GetService()
		{
			return _root.GetService<ISyncSettingsVM>();
		}

		IEnumerable<ISettingsListItem> Jab.IServiceProvider<IEnumerable<ISettingsListItem>>.GetService()
		{
			IEnumerable<ISettingsListItem> settingsVMs = _root.GetSettingsVMs(GetService<IRegistrationMainPageVM>(), GetService<IGeneralSettingsVM>(), GetService<IUpdatesSettingsVM>(), GetService<IScreenSettingsVM>(), GetService<IAudioSettingsVM>(), GetService<INetworkSettingsVM>(), GetService<IInputsSettingsVM>(), GetService<IDevicesSettingsVM>(), GetService<IMediaSettingsVM>(), GetService<IImportSettingsVM>(), GetService<IIntegrationsSettingsVM>(), GetService<IGroupsSettingsVM>(), GetService<ILabelsSettingsVM>(), GetService<IFlagService>());
			TryAddDisposable(settingsVMs);
			return settingsVMs;
		}

		ISettingsSearchEngine Jab.IServiceProvider<ISettingsSearchEngine>.GetService()
		{
			return _root.GetService<ISettingsSearchEngine>();
		}

		ISettingsSearchVM Jab.IServiceProvider<ISettingsSearchVM>.GetService()
		{
			return _root.GetService<ISettingsSearchVM>();
		}

		ISettingsNavigationVM Jab.IServiceProvider<ISettingsNavigationVM>.GetService()
		{
			return _root.GetService<ISettingsNavigationVM>();
		}

		ISettingsVM Jab.IServiceProvider<ISettingsVM>.GetService()
		{
			return _root.GetService<ISettingsVM>();
		}

		INotificationVMFactory Jab.IServiceProvider<INotificationVMFactory>.GetService()
		{
			return _root.GetService<INotificationVMFactory>();
		}

		IRegistrationRequestSender Jab.IServiceProvider<IRegistrationRequestSender>.GetService()
		{
			IRegistrationRequestSender registrationClient = IRegistrationServiceProviderModule.GetRegistrationClient(GetService<RegistrationClient>());
			TryAddDisposable(registrationClient);
			return registrationClient;
		}

		INotificationCallbackHandler Jab.IServiceProvider<INotificationCallbackHandler>.GetService()
		{
			INotificationCallbackHandler notificationCallbackHandler = IRegistrationServiceProviderModule.GetNotificationCallbackHandler(GetService<NotificationCallbackHandler>());
			TryAddDisposable(notificationCallbackHandler);
			return notificationCallbackHandler;
		}

		INotificationService Jab.IServiceProvider<INotificationService>.GetService()
		{
			return _root.GetService<INotificationService>();
		}

		INotificationCollectionVM Jab.IServiceProvider<INotificationCollectionVM>.GetService()
		{
			return _root.GetService<INotificationCollectionVM>();
		}

		IChangeDirectoryProcessFactory Jab.IServiceProvider<IChangeDirectoryProcessFactory>.GetService()
		{
			ChangeDirectoryProcessFactory changeDirectoryProcessFactory = new ChangeDirectoryProcessFactory(GetService<IUiDispatcher>(), GetService<IAsyncExecutor>(), GetService<IMediaService>(), GetService<ICrdtProtoDirectoryFileScanner>());
			TryAddDisposable(changeDirectoryProcessFactory);
			return changeDirectoryProcessFactory;
		}

		IChangeWorkspaceHandler Jab.IServiceProvider<IChangeWorkspaceHandler>.GetService()
		{
			return _root.GetService<IChangeWorkspaceHandler>();
		}

		CloudOnboardingVM Jab.IServiceProvider<CloudOnboardingVM>.GetService()
		{
			return _root.GetService<CloudOnboardingVM>();
		}

		ICloudOnboardingVM Jab.IServiceProvider<ICloudOnboardingVM>.GetService()
		{
			ICloudOnboardingVM cloudOnboardingVM = ISettingsViewModelsServiceProviderModule.GetCloudOnboardingVM(GetService<CloudOnboardingVM>());
			TryAddDisposable(cloudOnboardingVM);
			return cloudOnboardingVM;
		}

		ICloudOnboardingShellNavigator Jab.IServiceProvider<ICloudOnboardingShellNavigator>.GetService()
		{
			ICloudOnboardingShellNavigator cloudOnboardingVM = ISettingsViewModelsServiceProviderModule.GetCloudOnboardingVM(GetService<CloudOnboardingVM>());
			TryAddDisposable(cloudOnboardingVM);
			return cloudOnboardingVM;
		}

		ICloudOnboardingEligibilityVM Jab.IServiceProvider<ICloudOnboardingEligibilityVM>.GetService()
		{
			CloudOnboardingEligibilityVM cloudOnboardingEligibilityVM = new CloudOnboardingEligibilityVM(GetService<ICloudOnboardingService>(), GetService<IHyperlinkService>(), GetService<IRegistrationWebResourceService>(), GetService<IUiDispatcher>(), GetService<IWebSourceProvider>(), GetService<ICloudOnboardingShellNavigator>(), GetService<IMessageDialogService>(), GetService<ILogger>());
			TryAddDisposable(cloudOnboardingEligibilityVM);
			return cloudOnboardingEligibilityVM;
		}

		ICloudOnboardingManageMediaVM Jab.IServiceProvider<ICloudOnboardingManageMediaVM>.GetService()
		{
			CloudOnboardingManageMediaVM cloudOnboardingManageMediaVM = new CloudOnboardingManageMediaVM(GetService<ICloudOnboardingShellNavigator>());
			TryAddDisposable(cloudOnboardingManageMediaVM);
			return cloudOnboardingManageMediaVM;
		}

		ICloudOnboardingPricingVM Jab.IServiceProvider<ICloudOnboardingPricingVM>.GetService()
		{
			CloudOnboardingPricingVM cloudOnboardingPricingVM = new CloudOnboardingPricingVM(GetService<ICloudOnboardingService>(), GetService<IHyperlinkService>(), GetService<IWebSourceProvider>(), GetService<ICloudOnboardingShellNavigator>());
			TryAddDisposable(cloudOnboardingPricingVM);
			return cloudOnboardingPricingVM;
		}

		ICloudOnboardingDoneVM Jab.IServiceProvider<ICloudOnboardingDoneVM>.GetService()
		{
			CloudOnboardingDoneVM cloudOnboardingDoneVM = new CloudOnboardingDoneVM(GetService<IHyperlinkService>(), GetService<IWebSourceProvider>(), GetService<ICloudOnboardingService>(), GetService<ICloudOnboardingShellNavigator>());
			TryAddDisposable(cloudOnboardingDoneVM);
			return cloudOnboardingDoneVM;
		}

		ICloudOnboardingLocalWorkspacesVM Jab.IServiceProvider<ICloudOnboardingLocalWorkspacesVM>.GetService()
		{
			CloudOnboardingLocalWorkspacesVM cloudOnboardingLocalWorkspacesVM = new CloudOnboardingLocalWorkspacesVM(GetService<ICloudOnboardingShellNavigator>());
			TryAddDisposable(cloudOnboardingLocalWorkspacesVM);
			return cloudOnboardingLocalWorkspacesVM;
		}

		ICloudTeaseVM Jab.IServiceProvider<ICloudTeaseVM>.GetService()
		{
			CloudTeaseVM cloudTeaseVM = new CloudTeaseVM(GetService<IHyperlinkService>(), GetService<IWebSourceProvider>(), GetService<ICloudOnboardingService>(), GetService<ILogger>());
			TryAddDisposable(cloudTeaseVM);
			return cloudTeaseVM;
		}

		ICloudTeaseWindowProvider Jab.IServiceProvider<ICloudTeaseWindowProvider>.GetService()
		{
			CloudTeaseWindowProvider cloudTeaseWindowProvider = new CloudTeaseWindowProvider(GetService<ICloudTeaseVM>(), GetService<ICloudOnboardingService>(), GetService<IAfterStartupCompleteQueue>());
			TryAddDisposable(cloudTeaseWindowProvider);
			return cloudTeaseWindowProvider;
		}

		IManageWorkspacesWindowProvider Jab.IServiceProvider<IManageWorkspacesWindowProvider>.GetService()
		{
			return _root.GetService<IManageWorkspacesWindowProvider>();
		}

		IMissingFontVM Jab.IServiceProvider<IMissingFontVM>.GetService()
		{
			MissingFontVM missingFontVM = new MissingFontVM(GetService<IMissingFontService>(), GetService<ILocalization>(), GetService<IFontReplacementEventPublisher>());
			TryAddDisposable(missingFontVM);
			return missingFontVM;
		}

		ICalendarPrompt Jab.IServiceProvider<ICalendarPrompt>.GetService()
		{
			CalendarPrompt calendarPrompt = new CalendarPrompt();
			TryAddDisposable(calendarPrompt);
			return calendarPrompt;
		}

		IRTMPPrompt Jab.IServiceProvider<IRTMPPrompt>.GetService()
		{
			RTMPPrompt rTMPPrompt = new RTMPPrompt();
			TryAddDisposable(rTMPPrompt);
			return rTMPPrompt;
		}

		IProContentDialogService Jab.IServiceProvider<IProContentDialogService>.GetService()
		{
			ProContentDialogService proContentDialogService = new ProContentDialogService(GetService<IProPresenterResourceService>(), GetService<IApp>(), GetService<ILocalization>(), GetService<IUriCacheService<NullableBitmapSource>>(), GetService<IUriCacheService<IReadOnlyList<IAnimationFrame>>>(), GetService<IMediaImportService>(), GetService<IMediaFactory>(), GetService<IOutputRepository>(), GetService<IFlagService>());
			TryAddDisposable(proContentDialogService);
			return proContentDialogService;
		}

		IMediaImportDownloadDialogService Jab.IServiceProvider<IMediaImportDownloadDialogService>.GetService()
		{
			MediaImportDownloadDialogService mediaImportDownloadDialogService = new MediaImportDownloadDialogService(GetService<IProPresenterResourceService>(), GetService<IApp>(), GetService<IMediaImportService>(), GetService<IMediaFactory>(), GetService<IOutputRepository>(), GetService<IFlagService>());
			TryAddDisposable(mediaImportDownloadDialogService);
			return mediaImportDownloadDialogService;
		}

		IDownloadsDialogService Jab.IServiceProvider<IDownloadsDialogService>.GetService()
		{
			DownloadsDialogService downloadsDialogService = new DownloadsDialogService();
			TryAddDisposable(downloadsDialogService);
			return downloadsDialogService;
		}

		IMediaCueThumbnailOverlayVMFactory Jab.IServiceProvider<IMediaCueThumbnailOverlayVMFactory>.GetService()
		{
			MediaCueThumbnailOverlayVMFactory mediaCueThumbnailOverlayVMFactory = new MediaCueThumbnailOverlayVMFactory(GetService<IDownloadManager>(), GetService<IFileSelectorService>(), GetService<IRemoteFileLoader>(), GetService<IImportProcessFactory>(), GetService<IUiScheduler>());
			TryAddDisposable(mediaCueThumbnailOverlayVMFactory);
			return mediaCueThumbnailOverlayVMFactory;
		}

		IDownloadVMsFactory Jab.IServiceProvider<IDownloadVMsFactory>.GetService()
		{
			DownloadVMsFactory downloadVMsFactory = new DownloadVMsFactory(GetService<ILocalization>(), GetService<IUriCacheService<NullableBitmapSource>>(), GetService<IUiScheduler>());
			TryAddDisposable(downloadVMsFactory);
			return downloadVMsFactory;
		}

		IPropPrompts Jab.IServiceProvider<IPropPrompts>.GetService()
		{
			PropPrompts propPrompts = new PropPrompts();
			TryAddDisposable(propPrompts);
			return propPrompts;
		}

		IHardwareAlphaConfigurationVMFactory Jab.IServiceProvider<IHardwareAlphaConfigurationVMFactory>.GetService()
		{
			HardwareAlphaConfigurationVMFactory hardwareAlphaConfigurationVMFactory = new HardwareAlphaConfigurationVMFactory();
			TryAddDisposable(hardwareAlphaConfigurationVMFactory);
			return hardwareAlphaConfigurationVMFactory;
		}

		IAlphaKeySettingsVMFactory Jab.IServiceProvider<IAlphaKeySettingsVMFactory>.GetService()
		{
			AlphaKeySettingsVMFactory alphaKeySettingsVMFactory = new AlphaKeySettingsVMFactory(GetService<IHardwareAlphaConfigurationVMFactory>(), GetService<IHyperlinkService>(), GetService<IApiService>());
			TryAddDisposable(alphaKeySettingsVMFactory);
			return alphaKeySettingsVMFactory;
		}

		ICaptureController Jab.IServiceProvider<ICaptureController>.GetService()
		{
			ICaptureController captureController = IViewModelsServiceProviderModule.GetCaptureController(GetService<CaptureController>());
			TryAddDisposable(captureController);
			return captureController;
		}

		IResiService Jab.IServiceProvider<IResiService>.GetService()
		{
			IResiService captureController = IViewModelsServiceProviderModule.GetCaptureController(GetService<CaptureController>());
			TryAddDisposable(captureController);
			return captureController;
		}

		IUserFeedbackConsumer Jab.IServiceProvider<IUserFeedbackConsumer>.GetService()
		{
			UserFeedbackConsumer userFeedbackConsumer = new UserFeedbackConsumer(GetService<ILogger>(), GetService<IRestClientFactory>(), GetService<IApiService>());
			TryAddDisposable(userFeedbackConsumer);
			return userFeedbackConsumer;
		}

		IBuildAppMetaDataFile Jab.IServiceProvider<IBuildAppMetaDataFile>.GetService()
		{
			ApplicationDataFileBuilder applicationDataFileBuilder = new ApplicationDataFileBuilder(GetService<IOutputService>(), GetService<IFileSystem>(), GetService<ILogger>(), GetService<IGeneral>(), GetService<IVersionInfoProvider>(), GetService<IAssemblyInfoProvider>(), GetService<IFlagService>());
			TryAddDisposable(applicationDataFileBuilder);
			return applicationDataFileBuilder;
		}

		IUserAttachmentVMFactory Jab.IServiceProvider<IUserAttachmentVMFactory>.GetService()
		{
			UserAttachmentVMFactory userAttachmentVMFactory = new UserAttachmentVMFactory(GetService<IUserFeedbackConsumer>(), GetService<ILogger>(), GetService<IFileSystem>(), GetService<IProcessHelper>(), GetService<IBuildAppMetaDataFile>(), GetService<ISystemInfoProvider>(), GetService<IWorkspaceService>(), GetService<ICommonPathsWrapper>());
			TryAddDisposable(userAttachmentVMFactory);
			return userAttachmentVMFactory;
		}

		IAttachmentsUploader Jab.IServiceProvider<IAttachmentsUploader>.GetService()
		{
			return _root.GetService<IAttachmentsUploader>();
		}

		IAttachmentUploadJobFactory Jab.IServiceProvider<IAttachmentUploadJobFactory>.GetService()
		{
			AttachmentUploadJobFactory attachmentUploadJobFactory = new AttachmentUploadJobFactory(GetService<IRestClientFactory>(), GetService<IFileSystem>(), GetService<ILogger>());
			TryAddDisposable(attachmentUploadJobFactory);
			return attachmentUploadJobFactory;
		}

		IFeedbackVM Jab.IServiceProvider<IFeedbackVM>.GetService()
		{
			return _root.GetService<IFeedbackVM>();
		}

		ICrashReportingVM Jab.IServiceProvider<ICrashReportingVM>.GetService()
		{
			return _root.GetService<ICrashReportingVM>();
		}

		IAttachmentUploadVM Jab.IServiceProvider<IAttachmentUploadVM>.GetService()
		{
			return _root.GetService<IAttachmentUploadVM>();
		}

		ICrashReportUserFeedbackDialogProvider Jab.IServiceProvider<ICrashReportUserFeedbackDialogProvider>.GetService()
		{
			CrashReportUserFeedbackDialogProvider crashReportUserFeedbackDialogProvider = new CrashReportUserFeedbackDialogProvider(GetService<ICrashReportingVM>(), GetService<IFeedbackVM>(), GetService<ILogger>(), GetService<ILocalization>());
			TryAddDisposable(crashReportUserFeedbackDialogProvider);
			return crashReportUserFeedbackDialogProvider;
		}

		private System.IO.Stream GetStream_WhatsNewContentProviderFromJsonFileContentKey()
		{
			System.IO.Stream embeddedWhatsNewContent = GetEmbeddedWhatsNewContent();
			TryAddDisposable(embeddedWhatsNewContent);
			return embeddedWhatsNewContent;
		}

		IWhatsNewContentProviderFromJson Jab.IServiceProvider<IWhatsNewContentProviderFromJson>.GetService()
		{
			IWhatsNewContentProviderFromJson whatsNewContentProviderFromJson = GetWhatsNewContentProviderFromJson(GetStream_WhatsNewContentProviderFromJsonFileContentKey());
			TryAddDisposable(whatsNewContentProviderFromJson);
			return whatsNewContentProviderFromJson;
		}

		IFeatureFactory Jab.IServiceProvider<IFeatureFactory>.GetService()
		{
			FeatureFactory featureFactory = new FeatureFactory(GetService<ILocalization>(), GetService<IFileSystem>(), GetService<IHyperlinkService>());
			TryAddDisposable(featureFactory);
			return featureFactory;
		}

		IWhatsNewV2VM Jab.IServiceProvider<IWhatsNewV2VM>.GetService()
		{
			return _root.GetService<IWhatsNewV2VM>();
		}

		IMediaActionService Jab.IServiceProvider<IMediaActionService>.GetService()
		{
			return _root.GetService<IMediaActionService>();
		}

		ITimelineVMFactory Jab.IServiceProvider<ITimelineVMFactory>.GetService()
		{
			TimelineVMFactory timelineVMFactory = new TimelineVMFactory(GetService<IMediaActionService>(), GetService<ITimecodeService>(), GetService<IApp>(), GetService<ITimelineManager>(), GetService<IInputActions>(), GetService<IImportProcessFactory>(), GetService<IMediaFactory>(), GetService<ITransitionDescriptionCollection>());
			TryAddDisposable(timelineVMFactory);
			return timelineVMFactory;
		}

		ITimelineItemVMFactory Jab.IServiceProvider<ITimelineItemVMFactory>.GetService()
		{
			TimelineVMFactory timelineVMFactory = new TimelineVMFactory(GetService<IMediaActionService>(), GetService<ITimecodeService>(), GetService<IApp>(), GetService<ITimelineManager>(), GetService<IInputActions>(), GetService<IImportProcessFactory>(), GetService<IMediaFactory>(), GetService<ITransitionDescriptionCollection>());
			TryAddDisposable(timelineVMFactory);
			return timelineVMFactory;
		}

		IWorkspaceItemVMFactory Jab.IServiceProvider<IWorkspaceItemVMFactory>.GetService()
		{
			WorkspaceItemVMFactory workspaceItemVMFactory = new WorkspaceItemVMFactory();
			TryAddDisposable(workspaceItemVMFactory);
			return workspaceItemVMFactory;
		}

		IActionsMenuVMFactory Jab.IServiceProvider<IActionsMenuVMFactory>.GetService()
		{
			ActionsMenuVMFactory actionsMenuVMFactory = new ActionsMenuVMFactory(GetService<IDownloadManager>(), GetService<IProPresenterResourceService>(), GetService<IOutputService>(), GetService<IFileSelectorService>(), GetService<IRemoteFileLoader>(), GetService<IImportProcessFactory>(), GetService<IUiScheduler>(), GetService<IApp>(), GetService<IMediaActionService>(), GetService<IProcessHelper>(), GetService<IMediaFactory>(), GetService<IOutputConfiguration>(), GetService<ITransitionDescriptionCollection>());
			TryAddDisposable(actionsMenuVMFactory);
			return actionsMenuVMFactory;
		}

		IOutputScreenVMFactory Jab.IServiceProvider<IOutputScreenVMFactory>.GetService()
		{
			OutputScreenVMFactory outputScreenVMFactory = new OutputScreenVMFactory();
			TryAddDisposable(outputScreenVMFactory);
			return outputScreenVMFactory;
		}

		IScreenSelectorVM Jab.IServiceProvider<IScreenSelectorVM>.GetService()
		{
			return _root.GetService<IScreenSelectorVM>();
		}

		IWindowedOutputVM Jab.IServiceProvider<IWindowedOutputVM>.GetService()
		{
			return _root.GetService<IWindowedOutputVM>();
		}

		IOutputPreviewVMFactory Jab.IServiceProvider<IOutputPreviewVMFactory>.GetService()
		{
			OutputPreviewVMFactory outputPreviewVMFactory = new OutputPreviewVMFactory(GetService<ICoreManager>());
			TryAddDisposable(outputPreviewVMFactory);
			return outputPreviewVMFactory;
		}

		IInternalCoreManager Jab.IServiceProvider<IInternalCoreManager>.GetService()
		{
			IInternalCoreManager coreManager = IControllerServiceProviderModule.GetCoreManager(GetService<CoreManager>());
			TryAddDisposable(coreManager);
			return coreManager;
		}

		ITriggeringFactory Jab.IServiceProvider<ITriggeringFactory>.GetService()
		{
			TriggerServiceFactory triggerServiceFactory = new TriggerServiceFactory(GetService<IInternalCoreManager>(), GetService<IMessageService>());
			TryAddDisposable(triggerServiceFactory);
			return triggerServiceFactory;
		}

		ICalendarService Jab.IServiceProvider<ICalendarService>.GetService()
		{
			return _root.GetService<ICalendarService>();
		}

		IExportService Jab.IServiceProvider<IExportService>.GetService()
		{
			ExportService exportService = new ExportService(GetService<IExportProcessFactory>());
			TryAddDisposable(exportService);
			return exportService;
		}

		ILibraryService Jab.IServiceProvider<ILibraryService>.GetService()
		{
			return _root.GetService<ILibraryService>();
		}

		IClipboardProvider Jab.IServiceProvider<IClipboardProvider>.GetService()
		{
			return _root.GetService<IClipboardProvider>();
		}

		IPasteStrategy Jab.IServiceProvider<IPasteStrategy>.GetService()
		{
			return _root.GetService<IPasteStrategy>();
		}

		IEditorService Jab.IServiceProvider<IEditorService>.GetService()
		{
			IEditorService editorService = IViewModelsServiceProviderModule.GetEditorService(GetService<IInternalCoreManager>(), GetService<IOutputService>(), GetService<IPasteStrategy>(), GetService<IMetadataLoader>(), GetService<IUiDispatcher>(), GetService<ITriggeringFactory>());
			TryAddDisposable(editorService);
			return editorService;
		}

		PlaylistTemplateCollection Jab.IServiceProvider<PlaylistTemplateCollection>.GetService()
		{
			PlaylistTemplateCollection playlistTemplateCollection = IViewModelsServiceProviderModule.GetPlaylistTemplateCollection();
			TryAddDisposable(playlistTemplateCollection);
			return playlistTemplateCollection;
		}

		IPlaylistTemplatesService Jab.IServiceProvider<IPlaylistTemplatesService>.GetService()
		{
			PlaylistTemplatesService playlistTemplatesService = new PlaylistTemplatesService(GetService<PlaylistTemplateCollection>());
			TryAddDisposable(playlistTemplatesService);
			return playlistTemplatesService;
		}

		ISizeProvider Jab.IServiceProvider<ISizeProvider>.GetService()
		{
			return _root.GetService<ISizeProvider>();
		}

		IProPresenterCueVMFactory Jab.IServiceProvider<IProPresenterCueVMFactory>.GetService()
		{
			IProPresenterCueVMFactory proPresenterCueVMFactory = IViewModelsServiceProviderModule.GetProPresenterCueVMFactory(GetService<IProPresenterResourceService>());
			TryAddDisposable(proPresenterCueVMFactory);
			return proPresenterCueVMFactory;
		}

		IProContentDownloader Jab.IServiceProvider<IProContentDownloader>.GetService()
		{
			IProContentDownloader proContentDownloader = _root.CreateProContentDownloader(GetService<IMediaService>(), GetService<IProContentDialogService>(), GetService<IApp>(), GetService<IProContentUserInteractionBehavior>());
			TryAddDisposable(proContentDownloader);
			return proContentDownloader;
		}

		IMacroPrompt Jab.IServiceProvider<IMacroPrompt>.GetService()
		{
			return _root.GetService<IMacroPrompt>();
		}

		ISlidePreviewService Jab.IServiceProvider<ISlidePreviewService>.GetService()
		{
			SlidePreviewService slidePreviewService = new SlidePreviewService();
			TryAddDisposable(slidePreviewService);
			return slidePreviewService;
		}

		PropAutoClearHandler Jab.IServiceProvider<PropAutoClearHandler>.GetService()
		{
			return _root.GetService<PropAutoClearHandler>();
		}

		IPropAutoClearService Jab.IServiceProvider<IPropAutoClearService>.GetService()
		{
			return _root.GetService<IPropAutoClearService>();
		}

		ILegacyPurchaseBiblesDialogService Jab.IServiceProvider<ILegacyPurchaseBiblesDialogService>.GetService()
		{
			LegacyPurchaseBiblesDialogService legacyPurchaseBiblesDialogService = new LegacyPurchaseBiblesDialogService(GetService<IWebSourceProvider>());
			TryAddDisposable(legacyPurchaseBiblesDialogService);
			return legacyPurchaseBiblesDialogService;
		}

		IMediaValidator Jab.IServiceProvider<IMediaValidator>.GetService()
		{
			FillMediaValidator fillMediaValidator = new FillMediaValidator();
			TryAddDisposable(fillMediaValidator);
			return fillMediaValidator;
		}

		IMediaProvider Jab.IServiceProvider<IMediaProvider>.GetService()
		{
			IMediaProvider mediaProvider = IViewModelsServiceProviderModule.GetMediaProvider(GetService<IMediaValidator>(), GetService<IAdvanced>(), GetService<IImportProcessFactory>(), GetService<IMediaFactory>());
			TryAddDisposable(mediaProvider);
			return mediaProvider;
		}

		IToastNotificationService Jab.IServiceProvider<IToastNotificationService>.GetService()
		{
			return _root.GetService<IToastNotificationService>();
		}

		IWorkspaceDeletedPrompt Jab.IServiceProvider<IWorkspaceDeletedPrompt>.GetService()
		{
			return _root.GetService<IWorkspaceDeletedPrompt>();
		}

		IWorkspaceCollectionVM Jab.IServiceProvider<IWorkspaceCollectionVM>.GetService()
		{
			return _root.GetService<IWorkspaceCollectionVM>();
		}

		IMainLayoutVM Jab.IServiceProvider<IMainLayoutVM>.GetService()
		{
			return _root.GetService<IMainLayoutVM>();
		}

		IThemeSlideMenuVM Jab.IServiceProvider<IThemeSlideMenuVM>.GetService()
		{
			ThemeSlideMenuVM themeSlideMenuVM = new ThemeSlideMenuVM(GetService<IThemeService>(), GetService<IMessageService>());
			TryAddDisposable(themeSlideMenuVM);
			return themeSlideMenuVM;
		}

		IArrangementVM Jab.IServiceProvider<IArrangementVM>.GetService()
		{
			ArrangementVM arrangementVM = new ArrangementVM(GetService<ICoreManager>());
			TryAddDisposable(arrangementVM);
			return arrangementVM;
		}

		ITimecodeItemVMFactory Jab.IServiceProvider<ITimecodeItemVMFactory>.GetService()
		{
			TimecodeItemVMFactory timecodeItemVMFactory = new TimecodeItemVMFactory(GetService<ITimecodeService>());
			TryAddDisposable(timecodeItemVMFactory);
			return timecodeItemVMFactory;
		}

		ITimecodeVM Jab.IServiceProvider<ITimecodeVM>.GetService()
		{
			return _root.GetService<ITimecodeVM>();
		}

		IHeaderContentContextMenuVM Jab.IServiceProvider<IHeaderContentContextMenuVM>.GetService()
		{
			HeaderContentContextMenuVM headerContentContextMenuVM = new HeaderContentContextMenuVM(GetService<ILocalization>());
			TryAddDisposable(headerContentContextMenuVM);
			return headerContentContextMenuVM;
		}

		IWorkspaceSwitchValidator Jab.IServiceProvider<IWorkspaceSwitchValidator>.GetService()
		{
			return _root.GetService<IWorkspaceSwitchValidator>();
		}

		IApplicationFailureMessageService Jab.IServiceProvider<IApplicationFailureMessageService>.GetService()
		{
			ApplicationFailureMessageService applicationFailureMessageService = new ApplicationFailureMessageService(GetService<IUiDispatcher>(), GetService<ILocalization>(), GetService<IVersionInfoProvider>());
			TryAddDisposable(applicationFailureMessageService);
			return applicationFailureMessageService;
		}

		IFeatureFlagService Jab.IServiceProvider<IFeatureFlagService>.GetService()
		{
			return _root.GetService<IFeatureFlagService>();
		}

		ISpellChecker Jab.IServiceProvider<ISpellChecker>.GetService()
		{
			SpellChecker spellChecker = new SpellChecker();
			TryAddDisposable(spellChecker);
			return spellChecker;
		}

		IReceiveService Jab.IServiceProvider<IReceiveService>.GetService()
		{
			return _root.GetService<IReceiveService>();
		}

		IPresentationHandlerOperationService Jab.IServiceProvider<IPresentationHandlerOperationService>.GetService()
		{
			PresentationHandlerOperationService presentationHandlerOperationService = new PresentationHandlerOperationService();
			TryAddDisposable(presentationHandlerOperationService);
			return presentationHandlerOperationService;
		}

		private IApplicationEventHandler GetIApplicationEventHandler_CoreManagerApplicationEventHandler()
		{
			IApplicationEventHandler coreManager = IControllerServiceProviderModule.GetCoreManager(GetService<CoreManager>());
			TryAddDisposable(coreManager);
			return coreManager;
		}

		ISettingsDataToCoreSender Jab.IServiceProvider<ISettingsDataToCoreSender>.GetService()
		{
			return _root.GetService<ISettingsDataToCoreSender>();
		}

		IAPIv1Dependencies Jab.IServiceProvider<IAPIv1Dependencies>.GetService()
		{
			APIv1Dependencies aPIv1Dependencies = new APIv1Dependencies(GetService<IUiDispatcher>(), GetService<IProPresenterResourceService>(), GetService<IToastNotificationService>(), GetService<ILocalization>(), GetService<IPresentationHandlerOperationService>(), GetService<ITimelineManager>(), GetService<IFlagService>(), GetService<ICaptureService>(), GetService<IResiService>(), GetService<IApp>(), GetService<IImportProcessFactory>(), GetService<ITransitionDescriptionCollection>(), GetService<IProPresenterDOFactoryProvider>(), GetService<ISlidePreviewService>(), GetService<ILogger>(), GetService<IProPresenterCueFactory>());
			TryAddDisposable(aPIv1Dependencies);
			return aPIv1Dependencies;
		}

		ISharedData<AppData> Jab.IServiceProvider<ISharedData<AppData>>.GetService()
		{
			return _root.GetService<ISharedData<AppData>>();
		}

		Func<IRegistrationOperationFactory> Jab.IServiceProvider<Func<IRegistrationOperationFactory>>.GetService()
		{
			Func<IRegistrationOperationFactory> registrationOperationFactoryGetter = _root.GetRegistrationOperationFactoryGetter();
			TryAddDisposable(registrationOperationFactoryGetter);
			return registrationOperationFactoryGetter;
		}

		IStartupArgumentsExecutor Jab.IServiceProvider<IStartupArgumentsExecutor>.GetService()
		{
			IStartupArgumentsExecutor uriSchemeStartupArgumentExecutor = _root.GetUriSchemeStartupArgumentExecutor(GetService<Func<IRegistrationOperationFactory>>(), GetService<ISharedData<AppData>>(), GetService<IMessages<AppMessages>>(), GetService<Func<IMainLayoutVM>>());
			TryAddDisposable(uriSchemeStartupArgumentExecutor);
			return uriSchemeStartupArgumentExecutor;
		}

		private Func<bool> GetFunc_Boolean_ShouldSuppressVisualIndicationKey()
		{
			Func<bool> shouldSuppressVisualIndication = _root.GetShouldSuppressVisualIndication();
			TryAddDisposable(shouldSuppressVisualIndication);
			return shouldSuppressVisualIndication;
		}

		IMessageHandler Jab.IServiceProvider<IMessageHandler>.GetService()
		{
			IMessageHandler uriMessageHandler = IDataServiceProviderModule.GetUriMessageHandler(GetService<ISharedData<AppData>>(), GetService<Func<IRegistrationOperationFactory>>(), GetFunc_Boolean_ShouldSuppressVisualIndicationKey(), GetService<Func<IMainLayoutVM>>());
			TryAddDisposable(uriMessageHandler);
			return uriMessageHandler;
		}

		IDocumentDiagnosticsProvider Jab.IServiceProvider<IDocumentDiagnosticsProvider>.GetService()
		{
			return _root.GetService<IDocumentDiagnosticsProvider>();
		}

		ILaunchPopUpProvider Jab.IServiceProvider<ILaunchPopUpProvider>.GetService()
		{
			ILaunchPopUpProvider userMessageHandler = IRegistrationServiceProviderModule.GetUserMessageHandler(GetService<UserMessageHandler>());
			TryAddDisposable(userMessageHandler);
			return userMessageHandler;
		}

		IPropAutoClearHandler Jab.IServiceProvider<IPropAutoClearHandler>.GetService()
		{
			return _root.GetService<IPropAutoClearHandler>();
		}

		ISendDataResponseHandlerProvider Jab.IServiceProvider<ISendDataResponseHandlerProvider>.GetService()
		{
			return _root.GetService<ISendDataResponseHandlerProvider>();
		}

		IDataProcessor<SendDataResponse> Jab.IServiceProvider<IDataProcessor<SendDataResponse>>.GetService()
		{
			return _root.GetService<IDataProcessor<SendDataResponse>>();
		}

		MediaInspectorConverter Jab.IServiceProvider<MediaInspectorConverter>.GetService()
		{
			MediaInspectorConverter mediaInspectorConverter = new MediaInspectorConverter(GetService<IApp>(), GetService<ITransitionDescriptionCollection>());
			TryAddDisposable(mediaInspectorConverter);
			return mediaInspectorConverter;
		}

		WarningTooltipConverter Jab.IServiceProvider<WarningTooltipConverter>.GetService()
		{
			WarningTooltipConverter warningTooltipConverter = new WarningTooltipConverter(GetService<ILocalization>());
			TryAddDisposable(warningTooltipConverter);
			return warningTooltipConverter;
		}

		WebFillBrowserFactory Jab.IServiceProvider<WebFillBrowserFactory>.GetService()
		{
			return _root.GetService<WebFillBrowserFactory>();
		}

		IWebFillBrowserFactory Jab.IServiceProvider<IWebFillBrowserFactory>.GetService()
		{
			IWebFillBrowserFactory webFillBrowserFactory = IProPresenterUiServiceProviderModule.GetWebFillBrowserFactory(GetService<WebFillBrowserFactory>());
			TryAddDisposable(webFillBrowserFactory);
			return webFillBrowserFactory;
		}

		IActionDialogService Jab.IServiceProvider<IActionDialogService>.GetService()
		{
			IActionDialogService actionDialigService = IProPresenterUiServiceProviderModule.GetActionDialigService(GetService<IMainLayoutVM>());
			TryAddDisposable(actionDialigService);
			return actionDialigService;
		}

		ITemplateVM Jab.IServiceProvider<ITemplateVM>.GetService()
		{
			ITemplateVM templateVM = IProPresenterUiServiceProviderModule.GetTemplateVM(GetService<IMainLayoutVM>());
			TryAddDisposable(templateVM);
			return templateVM;
		}

		Func<MainWindow> Jab.IServiceProvider<Func<MainWindow>>.GetService()
		{
			Func<MainWindow> mainWindowGetter = _root.GetMainWindowGetter();
			TryAddDisposable(mainWindowGetter);
			return mainWindowGetter;
		}

		IInstanceValidator Jab.IServiceProvider<IInstanceValidator>.GetService()
		{
			IInstanceValidator instanceValidator = _root.GetInstanceValidator();
			TryAddDisposable(instanceValidator);
			return instanceValidator;
		}

		IWorkspaceInfoDumper Jab.IServiceProvider<IWorkspaceInfoDumper>.GetService()
		{
			return _root.GetService<IWorkspaceInfoDumper>();
		}

		MainWindow Jab.IServiceProvider<MainWindow>.GetService()
		{
			return _root.GetService<MainWindow>();
		}

		ICloudOnboardingWindowProvider Jab.IServiceProvider<ICloudOnboardingWindowProvider>.GetService()
		{
			return _root.GetService<ICloudOnboardingWindowProvider>();
		}

		IMediaServiceV1 Jab.IServiceProvider<IMediaServiceV1>.GetService()
		{
			return _root.GetService<IMediaServiceV1>();
		}

		IMediaServiceV2 Jab.IServiceProvider<IMediaServiceV2>.GetService()
		{
			return _root.GetService<IMediaServiceV2>();
		}

		private IProcessSupervisor GetIProcessSupervisor_WorkspaceHelperProcessSupervisor()
		{
			return _root.GetIProcessSupervisor_WorkspaceHelperProcessSupervisor();
		}

		IActionFactoryService Jab.IServiceProvider<IActionFactoryService>.GetService()
		{
			return _root.GetService<IActionFactoryService>();
		}

		IWorkspacesVM Jab.IServiceProvider<IWorkspacesVM>.GetService()
		{
			return _root.GetService<IWorkspacesVM>();
		}

		private IStartupArgumentsExecutor GetIStartupArgumentsExecutor_1()
		{
			return _root.GetIStartupArgumentsExecutor_1();
		}

		IEnumerable<IStartupArgumentsExecutor> Jab.IServiceProvider<IEnumerable<IStartupArgumentsExecutor>>.GetService()
		{
			return new IStartupArgumentsExecutor[2]
			{
				GetIStartupArgumentsExecutor_1(),
				GetService<IStartupArgumentsExecutor>()
			};
		}

		private IMessageHandler GetIMessageHandler_1()
		{
			return _root.GetIMessageHandler_1();
		}

		private IMessageHandler GetIMessageHandler_2()
		{
			return _root.GetIMessageHandler_2();
		}

		IEnumerable<IMessageHandler> Jab.IServiceProvider<IEnumerable<IMessageHandler>>.GetService()
		{
			return new IMessageHandler[3]
			{
				GetIMessageHandler_2(),
				GetIMessageHandler_1(),
				GetService<IMessageHandler>()
			};
		}

		IServiceProvider Jab.IServiceProvider<IServiceProvider>.GetService()
		{
			return this;
		}

		IServiceScopeFactory Jab.IServiceProvider<IServiceScopeFactory>.GetService()
		{
			return _root;
		}

		IServiceProviderIsService Jab.IServiceProvider<IServiceProviderIsService>.GetService()
		{
			return _root;
		}

		object? IServiceProvider.GetService(Type type)
		{
			if (type == typeof(IPhysicalDeviceProvider))
			{
				return GetService<IPhysicalDeviceProvider>();
			}
			if (type == typeof(IDatabaseService))
			{
				return GetService<IDatabaseService>();
			}
			if (type == typeof(IFileWatcherFactory))
			{
				return GetService<IFileWatcherFactory>();
			}
			if (type == typeof(IFileSystem))
			{
				return GetService<IFileSystem>();
			}
			if (type == typeof(IUiDispatcher))
			{
				return GetService<IUiDispatcher>();
			}
			if (type == typeof(ITimerFactory))
			{
				return GetService<ITimerFactory>();
			}
			if (type == typeof(IDebouncerFactory))
			{
				return GetService<IDebouncerFactory>();
			}
			if (type == typeof(IThemeRepo))
			{
				return GetService<IThemeRepo>();
			}
			if (type == typeof(IPropsRepo))
			{
				return GetService<IPropsRepo>();
			}
			if (type == typeof(IMacrosRepo))
			{
				return GetService<IMacrosRepo>();
			}
			if (type == typeof(ILibraryPlaylistRepo))
			{
				return GetService<ILibraryPlaylistRepo>();
			}
			if (type == typeof(IVisualPlaylistRepo))
			{
				return GetService<IVisualPlaylistRepo>();
			}
			if (type == typeof(IProPresenterResourceService))
			{
				return GetService<IProPresenterResourceService>();
			}
			if (type == typeof(IThemeService))
			{
				return GetService<IThemeService>();
			}
			if (type == typeof(IZipService))
			{
				return GetService<IZipService>();
			}
			if (type == typeof(IMessageService))
			{
				return GetService<IMessageService>();
			}
			if (type == typeof(IFileService))
			{
				return GetService<IFileService>();
			}
			if (type == typeof(ILogger))
			{
				return GetService<ILogger>();
			}
			if (type == typeof(ILocalization))
			{
				return GetService<ILocalization>();
			}
			if (type == typeof(IAdvanced))
			{
				return GetService<IAdvanced>();
			}
			if (type == typeof(IProtoService))
			{
				return GetService<IProtoService>();
			}
			if (type == typeof(ISqliteMigrationService))
			{
				return GetService<ISqliteMigrationService>();
			}
			if (type == typeof(ICookieManagerService))
			{
				return GetService<ICookieManagerService>();
			}
			if (type == typeof(App))
			{
				return GetService<App>();
			}
			if (type == typeof(IApp))
			{
				return GetService<IApp>();
			}
			if (type == typeof(IProCoreInstance))
			{
				return GetService<IProCoreInstance>();
			}
			if (type == typeof(IFlagService))
			{
				return GetService<IFlagService>();
			}
			if (type == typeof(ssAPIOutput))
			{
				return GetService<ssAPIOutput>();
			}
			if (type == typeof(ITransitionDescriptionCollection))
			{
				return GetService<ITransitionDescriptionCollection>();
			}
			if (type == typeof(IImageLoader))
			{
				return GetService<IImageLoader>();
			}
			if (type == typeof(IMediaMetadataCacheRepository))
			{
				return GetService<IMediaMetadataCacheRepository>();
			}
			if (type == typeof(IMediaMetadataCacheService))
			{
				return GetService<IMediaMetadataCacheService>();
			}
			if (type == typeof(IAsyncExecutor))
			{
				return GetService<IAsyncExecutor>();
			}
			if (type == typeof(IUiScheduler))
			{
				return GetService<IUiScheduler>();
			}
			if (type == typeof(IMetadataLoader))
			{
				return GetService<IMetadataLoader>();
			}
			if (type == typeof(ITrackedMediaHelpers))
			{
				return GetService<ITrackedMediaHelpers>();
			}
			if (type == typeof(IAssemblyInfoProvider))
			{
				return GetService<IAssemblyInfoProvider>();
			}
			if (type == typeof(IVersionInfoProvider))
			{
				return GetService<IVersionInfoProvider>();
			}
			if (type == typeof(IRestClientFactory))
			{
				return GetService<IRestClientFactory>();
			}
			if (type == typeof(ISemaphoreFactory))
			{
				return GetService<ISemaphoreFactory>();
			}
			if (type == typeof(ICurrentTime))
			{
				return GetService<ICurrentTime>();
			}
			if (type == typeof(IFileSystemUriCacheServiceFactory))
			{
				return GetService<IFileSystemUriCacheServiceFactory>();
			}
			if (type == typeof(IImageDecoder))
			{
				return GetService<IImageDecoder>();
			}
			if (type == typeof(IBitmapImageDecoder))
			{
				return GetService<IBitmapImageDecoder>();
			}
			if (type == typeof(IUriCacheService<NullableBitmapSource>))
			{
				return GetService<IUriCacheService<NullableBitmapSource>>();
			}
			if (type == typeof(ICurrentTimeOffset))
			{
				return GetService<ICurrentTimeOffset>();
			}
			if (type == typeof(IAuthenticatingApiConsumerFactory))
			{
				return GetService<IAuthenticatingApiConsumerFactory>();
			}
			if (type == typeof(IApiService))
			{
				return GetService<IApiService>();
			}
			if (type == typeof(IRegistrationUserDialogService))
			{
				return GetService<IRegistrationUserDialogService>();
			}
			if (type == typeof(IApplicationExceptionFactory))
			{
				return GetService<IApplicationExceptionFactory>();
			}
			if (type == typeof(IErrorPublisher))
			{
				return GetService<IErrorPublisher>();
			}
			if (type == typeof(IErrorReporter))
			{
				return GetService<IErrorReporter>();
			}
			if (type == typeof(ICoreApplication))
			{
				return GetService<ICoreApplication>();
			}
			if (type == typeof(IRegistrationCallbackHandler))
			{
				return GetService<IRegistrationCallbackHandler>();
			}
			if (type == typeof(NotificationCallbackHandler))
			{
				return GetService<NotificationCallbackHandler>();
			}
			if (type == typeof(ProContentClientInformationProvider))
			{
				return GetService<ProContentClientInformationProvider>();
			}
			if (type == typeof(IInternetAccess))
			{
				return GetService<IInternetAccess>();
			}
			if (type == typeof(IHyperlinkService))
			{
				return GetService<IHyperlinkService>();
			}
			if (type == typeof(JsonWebTokenHandler))
			{
				return GetService<JsonWebTokenHandler>();
			}
			if (type == typeof(RegistrationStateHandler))
			{
				return GetService<RegistrationStateHandler>();
			}
			if (type == typeof(IRegistrationStateProvider))
			{
				return GetService<IRegistrationStateProvider>();
			}
			if (type == typeof(IActivationKeyProvider))
			{
				return GetService<IActivationKeyProvider>();
			}
			if (type == typeof(IRegistrationWebResourceService))
			{
				return GetService<IRegistrationWebResourceService>();
			}
			if (type == typeof(IPopUpAlertFactory))
			{
				return GetService<IPopUpAlertFactory>();
			}
			if (type == typeof(IAfterStartupCompleteQueue))
			{
				return GetService<IAfterStartupCompleteQueue>();
			}
			if (type == typeof(UserMessageHandler))
			{
				return GetService<UserMessageHandler>();
			}
			if (type == typeof(Func<IMainLayoutVM>))
			{
				return GetService<Func<IMainLayoutVM>>();
			}
			if (type == typeof(IWebSourceProvider))
			{
				return GetService<IWebSourceProvider>();
			}
			if (type == typeof(IRegistrationCallbackDialogProvider))
			{
				return GetService<IRegistrationCallbackDialogProvider>();
			}
			if (type == typeof(IEmbeddedResourceReader))
			{
				return GetService<IEmbeddedResourceReader>();
			}
			if (type == typeof(IForceQuitEventPublisher))
			{
				return GetService<IForceQuitEventPublisher>();
			}
			if (type == typeof(IForcedShutdownMessageProvider))
			{
				return GetService<IForcedShutdownMessageProvider>();
			}
			if (type == typeof(IInternetAccessCheck))
			{
				return GetService<IInternetAccessCheck>();
			}
			if (type == typeof(IEnumerable<IRegistrationCallbackHandler>))
			{
				return GetService<IEnumerable<IRegistrationCallbackHandler>>();
			}
			if (type == typeof(RegistrationClient))
			{
				return GetService<RegistrationClient>();
			}
			if (type == typeof(IRegistrationClient))
			{
				return GetService<IRegistrationClient>();
			}
			if (type == typeof(IRegistrationOperationFactory))
			{
				return GetService<IRegistrationOperationFactory>();
			}
			if (type == typeof(IProContentConsumer))
			{
				return GetService<IProContentConsumer>();
			}
			if (type == typeof(IProContentDownloadFailedDialogService))
			{
				return GetService<IProContentDownloadFailedDialogService>();
			}
			if (type == typeof(IProContentUserInteractionBehavior))
			{
				return GetService<IProContentUserInteractionBehavior>();
			}
			if (type == typeof(IDelayFactory))
			{
				return GetService<IDelayFactory>();
			}
			if (type == typeof(IDownloadProcessFactory))
			{
				return GetService<IDownloadProcessFactory>();
			}
			if (type == typeof(IDownloadItemFactory))
			{
				return GetService<IDownloadItemFactory>();
			}
			if (type == typeof(IProContentAnalyticEventsPublisher))
			{
				return GetService<IProContentAnalyticEventsPublisher>();
			}
			if (type == typeof(IDownloadManager))
			{
				return GetService<IDownloadManager>();
			}
			if (type == typeof(IUnObservedProContentDownloadProcessFactory))
			{
				return GetService<IUnObservedProContentDownloadProcessFactory>();
			}
			if (type == typeof(IProContentAssetProvider))
			{
				return GetService<IProContentAssetProvider>();
			}
			if (type == typeof(IRemoteFileLoader))
			{
				return GetService<IRemoteFileLoader>();
			}
			if (type == typeof(IAudioOutputDeviceCollection))
			{
				return GetService<IAudioOutputDeviceCollection>();
			}
			if (type == typeof(IAudioSetup))
			{
				return GetService<IAudioSetup>();
			}
			if (type == typeof(IAudioMapRecallService<DeviceChannel, Bus>))
			{
				return GetService<IAudioMapRecallService<DeviceChannel, Bus>>();
			}
			if (type == typeof(ILiveVideoInputCollection))
			{
				return GetService<ILiveVideoInputCollection>();
			}
			if (type == typeof(IMediaFactory))
			{
				return GetService<IMediaFactory>();
			}
			if (type == typeof(ITextFillMediaFactory))
			{
				return GetService<ITextFillMediaFactory>();
			}
			if (type == typeof(ITextDocumentFactory))
			{
				return GetService<ITextDocumentFactory>();
			}
			if (type == typeof(IEntityFactory))
			{
				return GetService<IEntityFactory>();
			}
			if (type == typeof(IDocumentFactory))
			{
				return GetService<IDocumentFactory>();
			}
			if (type == typeof(IDocumentService))
			{
				return GetService<IDocumentService>();
			}
			if (type == typeof(IEntityFileLockFactory))
			{
				return GetService<IEntityFileLockFactory>();
			}
			if (type == typeof(ICommonPathsWrapper))
			{
				return GetService<ICommonPathsWrapper>();
			}
			if (type == typeof(ICollaborationPeerIdProvider))
			{
				return GetService<ICollaborationPeerIdProvider>();
			}
			if (type == typeof(IThreadPoolScheduler))
			{
				return GetService<IThreadPoolScheduler>();
			}
			if (type == typeof(IMediaService))
			{
				return GetService<IMediaService>();
			}
			if (type == typeof(ILocalWorkspaceStatsEventPublisher))
			{
				return GetService<ILocalWorkspaceStatsEventPublisher>();
			}
			if (type == typeof(IZipHelper))
			{
				return GetService<IZipHelper>();
			}
			if (type == typeof(IWorkspaceService))
			{
				return GetService<IWorkspaceService>();
			}
			if (type == typeof(ICloudDiagnosticsPublisher))
			{
				return GetService<ICloudDiagnosticsPublisher>();
			}
			if (type == typeof(IEntityDocumentRegistry))
			{
				return GetService<IEntityDocumentRegistry>();
			}
			if (type == typeof(IEntityDocumentSyncerFactory))
			{
				return GetService<IEntityDocumentSyncerFactory>();
			}
			if (type == typeof(IMergedEntityFactory))
			{
				return GetService<IMergedEntityFactory>();
			}
			if (type == typeof(IProPresenterDOFactoryProvider))
			{
				return GetService<IProPresenterDOFactoryProvider>();
			}
			if (type == typeof(IMessageDialogService))
			{
				return GetService<IMessageDialogService>();
			}
			if (type == typeof(IPresentationFactory))
			{
				return GetService<IPresentationFactory>();
			}
			if (type == typeof(IPowerPointImageLoader))
			{
				return GetService<IPowerPointImageLoader>();
			}
			if (type == typeof(IPowerPointEvents))
			{
				return GetService<IPowerPointEvents>();
			}
			if (type == typeof(TypefaceLibrary))
			{
				return GetService<TypefaceLibrary>();
			}
			if (type == typeof(IFontDetector))
			{
				return GetService<IFontDetector>();
			}
			if (type == typeof(IFontDetectionSessionFactory))
			{
				return GetService<IFontDetectionSessionFactory>();
			}
			if (type == typeof(IMissingFontService))
			{
				return GetService<IMissingFontService>();
			}
			if (type == typeof(IProPresenterCueFactory))
			{
				return GetService<IProPresenterCueFactory>();
			}
			if (type == typeof(IFontReplacementEventPublisher))
			{
				return GetService<IFontReplacementEventPublisher>();
			}
			if (type == typeof(IMissingFontWindowProvider))
			{
				return GetService<IMissingFontWindowProvider>();
			}
			if (type == typeof(ICorePowerPointImportService))
			{
				return GetService<ICorePowerPointImportService>();
			}
			if (type == typeof(IPowerPointImportService))
			{
				return GetService<IPowerPointImportService>();
			}
			if (type == typeof(IImportHelperServices))
			{
				return GetService<IImportHelperServices>();
			}
			if (type == typeof(IImportLocationSelectionDialogService))
			{
				return GetService<IImportLocationSelectionDialogService>();
			}
			if (type == typeof(IManageMediaAutoMaticallyProvider))
			{
				return GetService<IManageMediaAutoMaticallyProvider>();
			}
			if (type == typeof(IFileCreator))
			{
				return GetService<IFileCreator>();
			}
			if (type == typeof(ISyncDataFactory))
			{
				return GetService<ISyncDataFactory>();
			}
			if (type == typeof(IScreenArrangementFactory))
			{
				return GetService<IScreenArrangementFactory>();
			}
			if (type == typeof(IAudioSettingsAnalyticsEventPublisher))
			{
				return GetService<IAudioSettingsAnalyticsEventPublisher>();
			}
			if (type == typeof(IAudioInputCollection))
			{
				return GetService<IAudioInputCollection>();
			}
			if (type == typeof(ICrdtProtoDirectoryFileScanner))
			{
				return GetService<ICrdtProtoDirectoryFileScanner>();
			}
			if (type == typeof(IMaskCollection))
			{
				return GetService<IMaskCollection>();
			}
			if (type == typeof(StagePresentation))
			{
				return GetService<StagePresentation>();
			}
			if (type == typeof(ILocalDocumentSyncerFactory))
			{
				return GetService<ILocalDocumentSyncerFactory>();
			}
			if (type == typeof(IOutputConfiguration))
			{
				return GetService<IOutputConfiguration>();
			}
			if (type == typeof(ICollectionStorage))
			{
				return GetService<ICollectionStorage>();
			}
			if (type == typeof(IImportProcessFactory))
			{
				return GetService<IImportProcessFactory>();
			}
			if (type == typeof(IAsyncFileImporter))
			{
				return GetService<IAsyncFileImporter>();
			}
			if (type == typeof(IMigrationSource))
			{
				return GetService<IMigrationSource>();
			}
			if (type == typeof(INetwork))
			{
				return GetService<INetwork>();
			}
			if (type == typeof(ITimecodeSettingsRepository))
			{
				return GetService<ITimecodeSettingsRepository>();
			}
			if (type == typeof(IImport))
			{
				return GetService<IImport>();
			}
			if (type == typeof(IStoredPcoOptions))
			{
				return GetService<IStoredPcoOptions>();
			}
			if (type == typeof(ISongSelectConsumer))
			{
				return GetService<ISongSelectConsumer>();
			}
			if (type == typeof(IReportRepository))
			{
				return GetService<IReportRepository>();
			}
			if (type == typeof(IGeneral))
			{
				return GetService<IGeneral>();
			}
			if (type == typeof(IEnableAnalyticsProvider))
			{
				return GetService<IEnableAnalyticsProvider>();
			}
			if (type == typeof(IDisplay))
			{
				return GetService<IDisplay>();
			}
			if (type == typeof(ISync))
			{
				return GetService<ISync>();
			}
			if (type == typeof(ILayout))
			{
				return GetService<ILayout>();
			}
			if (type == typeof(IPlaylistActionValidatorFactory))
			{
				return GetService<IPlaylistActionValidatorFactory>();
			}
			if (type == typeof(IActionBinderFactory))
			{
				return GetService<IActionBinderFactory>();
			}
			if (type == typeof(IEncoderValidator))
			{
				return GetService<IEncoderValidator>();
			}
			if (type == typeof(IThemeImportProcessFactory))
			{
				return GetService<IThemeImportProcessFactory>();
			}
			if (type == typeof(IThemeAnalyiticEvents))
			{
				return GetService<IThemeAnalyiticEvents>();
			}
			if (type == typeof(IDxDiagReaderFactory))
			{
				return GetService<IDxDiagReaderFactory>();
			}
			if (type == typeof(ISystemInfoProvider))
			{
				return GetService<ISystemInfoProvider>();
			}
			if (type == typeof(IApplicationLaunchEventPublisher))
			{
				return GetService<IApplicationLaunchEventPublisher>();
			}
			if (type == typeof(ICaptureAnalyticEventsPublisher))
			{
				return GetService<ICaptureAnalyticEventsPublisher>();
			}
			if (type == typeof(IStartupSettingsEventsPublisher))
			{
				return GetService<IStartupSettingsEventsPublisher>();
			}
			if (type == typeof(IUiPreferencesAnalyticEventsPublisher))
			{
				return GetService<IUiPreferencesAnalyticEventsPublisher>();
			}
			if (type == typeof(ITestPatternAnalyticEventsPublisher))
			{
				return GetService<ITestPatternAnalyticEventsPublisher>();
			}
			if (type == typeof(IWelcomeAnalyticEventsPublisher))
			{
				return GetService<IWelcomeAnalyticEventsPublisher>();
			}
			if (type == typeof(ITimecodeAnalyticsEvents))
			{
				return GetService<ITimecodeAnalyticsEvents>();
			}
			if (type == typeof(IPlaybackMarkerAnalyticsEvents))
			{
				return GetService<IPlaybackMarkerAnalyticsEvents>();
			}
			if (type == typeof(ITimelineAnalyticsEvents))
			{
				return GetService<ITimelineAnalyticsEvents>();
			}
			if (type == typeof(ICCLIReportAnalyticsEvents))
			{
				return GetService<ICCLIReportAnalyticsEvents>();
			}
			if (type == typeof(IMediaCleanupSizeEventPublisher))
			{
				return GetService<IMediaCleanupSizeEventPublisher>();
			}
			if (type == typeof(IMediaAnalyticsSender))
			{
				return GetService<IMediaAnalyticsSender>();
			}
			if (type == typeof(IWorkspaceAnalyticsEventPublisher))
			{
				return GetService<IWorkspaceAnalyticsEventPublisher>();
			}
			if (type == typeof(ICloudOnboardingAnalyticsEventPublisher))
			{
				return GetService<ICloudOnboardingAnalyticsEventPublisher>();
			}
			if (type == typeof(IFileDownloadObserverFactory))
			{
				return GetService<IFileDownloadObserverFactory>();
			}
			if (type == typeof(IProContentDownloadProcessFactory))
			{
				return GetService<IProContentDownloadProcessFactory>();
			}
			if (type == typeof(IStopwatchFactory))
			{
				return GetService<IStopwatchFactory>();
			}
			if (type == typeof(ICacheFactory))
			{
				return GetService<ICacheFactory>();
			}
			if (type == typeof(IProContentProvider))
			{
				return GetService<IProContentProvider>();
			}
			if (type == typeof(IUriCacheService<IReadOnlyList<IAnimationFrame>>))
			{
				return GetService<IUriCacheService<IReadOnlyList<IAnimationFrame>>>();
			}
			if (type == typeof(IOutputRepository))
			{
				return GetService<IOutputRepository>();
			}
			if (type == typeof(ICommunicationOutput))
			{
				return GetService<ICommunicationOutput>();
			}
			if (type == typeof(IOutputService))
			{
				return GetService<IOutputService>();
			}
			if (type == typeof(IErrorPrompt))
			{
				return GetService<IErrorPrompt>();
			}
			if (type == typeof(IResiPlugin))
			{
				return GetService<IResiPlugin>();
			}
			if (type == typeof(IResiCustomEndpointsStore))
			{
				return GetService<IResiCustomEndpointsStore>();
			}
			if (type == typeof(IResiEndpoints))
			{
				return GetService<IResiEndpoints>();
			}
			if (type == typeof(IResiWebClient))
			{
				return GetService<IResiWebClient>();
			}
			if (type == typeof(IMessages<AppMessages>))
			{
				return GetService<IMessages<AppMessages>>();
			}
			if (type == typeof(IUpdateClient))
			{
				return GetService<IUpdateClient>();
			}
			if (type == typeof(ITestPatternPropertyFactory))
			{
				return GetService<ITestPatternPropertyFactory>();
			}
			if (type == typeof(ITestPatternDefinitionFactory))
			{
				return GetService<ITestPatternDefinitionFactory>();
			}
			if (type == typeof(ITestPatternStateFactory))
			{
				return GetService<ITestPatternStateFactory>();
			}
			if (type == typeof(ITestPatternPersistence))
			{
				return GetService<ITestPatternPersistence>();
			}
			if (type == typeof(ITestPatternService))
			{
				return GetService<ITestPatternService>();
			}
			if (type == typeof(IFileProvider))
			{
				return GetService<IFileProvider>();
			}
			if (type == typeof(ISyncDataProvider))
			{
				return GetService<ISyncDataProvider>();
			}
			if (type == typeof(ISyncActionProvider))
			{
				return GetService<ISyncActionProvider>();
			}
			if (type == typeof(IAppContinuationService))
			{
				return GetService<IAppContinuationService>();
			}
			if (type == typeof(IAppInstallerFactory))
			{
				return GetService<IAppInstallerFactory>();
			}
			if (type == typeof(IAppDownloadFactory))
			{
				return GetService<IAppDownloadFactory>();
			}
			if (type == typeof(IAppUpdateUserDialogService))
			{
				return GetService<IAppUpdateUserDialogService>();
			}
			if (type == typeof(IAppUpdateService))
			{
				return GetService<IAppUpdateService>();
			}
			if (type == typeof(IIndexingService))
			{
				return GetService<IIndexingService>();
			}
			if (type == typeof(IPresentationCapableSyncDataFactory))
			{
				return GetService<IPresentationCapableSyncDataFactory>();
			}
			if (type == typeof(IBibleDataStore))
			{
				return GetService<IBibleDataStore>();
			}
			if (type == typeof(IBibleProvider))
			{
				return GetService<IBibleProvider>();
			}
			if (type == typeof(IMultiTracksConsumer))
			{
				return GetService<IMultiTracksConsumer>();
			}
			if (type == typeof(IAuthenticatorFactory))
			{
				return GetService<IAuthenticatorFactory>();
			}
			if (type == typeof(IPCOConsumer))
			{
				return GetService<IPCOConsumer>();
			}
			if (type == typeof(IPCOUpdater))
			{
				return GetService<IPCOUpdater>();
			}
			if (type == typeof(ThumbnailViewSettings))
			{
				return GetService<ThumbnailViewSettings>();
			}
			if (type == typeof(IExportProcessFactory))
			{
				return GetService<IExportProcessFactory>();
			}
			if (type == typeof(IInputActions))
			{
				return GetService<IInputActions>();
			}
			if (type == typeof(IMediaImportService))
			{
				return GetService<IMediaImportService>();
			}
			if (type == typeof(IMediaFileProvider))
			{
				return GetService<IMediaFileProvider>();
			}
			if (type == typeof(IWorkspaceInspectionService))
			{
				return GetService<IWorkspaceInspectionService>();
			}
			if (type == typeof(ICloudWorkspaceService))
			{
				return GetService<ICloudWorkspaceService>();
			}
			if (type == typeof(ICloudConversionService))
			{
				return GetService<ICloudConversionService>();
			}
			if (type == typeof(ICloudOnboardingService))
			{
				return GetService<ICloudOnboardingService>();
			}
			if (type == typeof(IMatchSongsInteractor))
			{
				return GetService<IMatchSongsInteractor>();
			}
			if (type == typeof(IWorkspaceDocumentOrchestrator))
			{
				return GetService<IWorkspaceDocumentOrchestrator>();
			}
			if (type == typeof(ThemeCollection))
			{
				return GetService<ThemeCollection>();
			}
			if (type == typeof(IThemeCollection))
			{
				return GetService<IThemeCollection>();
			}
			if (type == typeof(IFileFilterProvider))
			{
				return GetService<IFileFilterProvider>();
			}
			if (type == typeof(IFileUtility))
			{
				return GetService<IFileUtility>();
			}
			if (type == typeof(IProcessHelper))
			{
				return GetService<IProcessHelper>();
			}
			if (type == typeof(INetworkChange))
			{
				return GetService<INetworkChange>();
			}
			if (type == typeof(IFileObservatory))
			{
				return GetService<IFileObservatory>();
			}
			if (type == typeof(ISettingsSearchFactory))
			{
				return GetService<ISettingsSearchFactory>();
			}
			if (type == typeof(INetworkDialogService))
			{
				return GetService<INetworkDialogService>();
			}
			if (type == typeof(IMediaCleanupPrompt))
			{
				return GetService<IMediaCleanupPrompt>();
			}
			if (type == typeof(IMidiDeviceSettingsVM))
			{
				return GetService<IMidiDeviceSettingsVM>();
			}
			if (type == typeof(IMidiWindowProvider))
			{
				return GetService<IMidiWindowProvider>();
			}
			if (type == typeof(IFileSelectorService))
			{
				return GetService<IFileSelectorService>();
			}
			if (type == typeof(ICCLIReportPrompt))
			{
				return GetService<ICCLIReportPrompt>();
			}
			if (type == typeof(INdiInputsSettingsDialogService))
			{
				return GetService<INdiInputsSettingsDialogService>();
			}
			if (type == typeof(IAirCastPrompt))
			{
				return GetService<IAirCastPrompt>();
			}
			if (type == typeof(IAirCastConfiguration))
			{
				return GetService<IAirCastConfiguration>();
			}
			if (type == typeof(IInstallFileExecutor))
			{
				return GetService<IInstallFileExecutor>();
			}
			if (type == typeof(IAirCastPluginDownload))
			{
				return GetService<IAirCastPluginDownload>();
			}
			if (type == typeof(ICCLIReportCollectionVM))
			{
				return GetService<ICCLIReportCollectionVM>();
			}
			if (type == typeof(ICopyrightSettingsVM))
			{
				return GetService<ICopyrightSettingsVM>();
			}
			if (type == typeof(INetworkCommandFactory))
			{
				return GetService<INetworkCommandFactory>();
			}
			if (type == typeof(INetworkCommandTrigger))
			{
				return GetService<INetworkCommandTrigger>();
			}
			if (type == typeof(INetworkTriggerDataTransferFactory))
			{
				return GetService<INetworkTriggerDataTransferFactory>();
			}
			if (type == typeof(IResiController))
			{
				return GetService<IResiController>();
			}
			if (type == typeof(ICrashRecovery))
			{
				return GetService<ICrashRecovery>();
			}
			if (type == typeof(ICapturePrompt))
			{
				return GetService<ICapturePrompt>();
			}
			if (type == typeof(CaptureController))
			{
				return GetService<CaptureController>();
			}
			if (type == typeof(ICaptureService))
			{
				return GetService<ICaptureService>();
			}
			if (type == typeof(ITimedPlaybackRepository))
			{
				return GetService<ITimedPlaybackRepository>();
			}
			if (type == typeof(ITimelineService))
			{
				return GetService<ITimelineService>();
			}
			if (type == typeof(ITimecodeService))
			{
				return GetService<ITimecodeService>();
			}
			if (type == typeof(ITimelineManager))
			{
				return GetService<ITimelineManager>();
			}
			if (type == typeof(ITransferHandlerFactory))
			{
				return GetService<ITransferHandlerFactory>();
			}
			if (type == typeof(CoreManager))
			{
				return GetService<CoreManager>();
			}
			if (type == typeof(ICoreManager))
			{
				return GetService<ICoreManager>();
			}
			if (type == typeof(IGeneralSettingsVM))
			{
				return GetService<IGeneralSettingsVM>();
			}
			if (type == typeof(ICommandSender))
			{
				return GetService<ICommandSender>();
			}
			if (type == typeof(IServerStateHandler))
			{
				return GetService<IServerStateHandler>();
			}
			if (type == typeof(INetworkEnvironment))
			{
				return GetService<INetworkEnvironment>();
			}
			if (type == typeof(ILinkRequestFactory))
			{
				return GetService<ILinkRequestFactory>();
			}
			if (type == typeof(INetworkLinkService))
			{
				return GetService<INetworkLinkService>();
			}
			if (type == typeof(INetworkLinkPrompt))
			{
				return GetService<INetworkLinkPrompt>();
			}
			if (type == typeof(INetworkLinkVM))
			{
				return GetService<INetworkLinkVM>();
			}
			if (type == typeof(INetworkSettingsVM))
			{
				return GetService<INetworkSettingsVM>();
			}
			if (type == typeof(IRegistrationUnlockCodeVM))
			{
				return GetService<IRegistrationUnlockCodeVM>();
			}
			if (type == typeof(IRegistrationSubpageVMFactory))
			{
				return GetService<IRegistrationSubpageVMFactory>();
			}
			if (type == typeof(IOrganizationConsumer))
			{
				return GetService<IOrganizationConsumer>();
			}
			if (type == typeof(IUserAvatarProvider))
			{
				return GetService<IUserAvatarProvider>();
			}
			if (type == typeof(IRegistrationMainPageVM))
			{
				return GetService<IRegistrationMainPageVM>();
			}
			if (type == typeof(IAccountCenterVM))
			{
				return GetService<IAccountCenterVM>();
			}
			if (type == typeof(IUpdatesSettingsVM))
			{
				return GetService<IUpdatesSettingsVM>();
			}
			if (type == typeof(IClockSourceProvider))
			{
				return GetService<IClockSourceProvider>();
			}
			if (type == typeof(IClockSourceService))
			{
				return GetService<IClockSourceService>();
			}
			if (type == typeof(IClockSourceVM))
			{
				return GetService<IClockSourceVM>();
			}
			if (type == typeof(IScreenSettingsVM))
			{
				return GetService<IScreenSettingsVM>();
			}
			if (type == typeof(IInputsSettingsService))
			{
				return GetService<IInputsSettingsService>();
			}
			if (type == typeof(IVideoInputsSettingsVM))
			{
				return GetService<IVideoInputsSettingsVM>();
			}
			if (type == typeof(IVideoInputItemVMFactory))
			{
				return GetService<IVideoInputItemVMFactory>();
			}
			if (type == typeof(IAudioInputsSettingsVM))
			{
				return GetService<IAudioInputsSettingsVM>();
			}
			if (type == typeof(INdiInputsSettingsVM))
			{
				return GetService<INdiInputsSettingsVM>();
			}
			if (type == typeof(IInputsSettingsVM))
			{
				return GetService<IInputsSettingsVM>();
			}
			if (type == typeof(IDevicesSettingsVM))
			{
				return GetService<IDevicesSettingsVM>();
			}
			if (type == typeof(IMediaSettingsVMFactory))
			{
				return GetService<IMediaSettingsVMFactory>();
			}
			if (type == typeof(IMediaSearchPathsSettingsVM))
			{
				return GetService<IMediaSearchPathsSettingsVM>();
			}
			if (type == typeof(IMediaFilesProvider))
			{
				return GetService<IMediaFilesProvider>();
			}
			if (type == typeof(IMediaCleanupService))
			{
				return GetService<IMediaCleanupService>();
			}
			if (type == typeof(IMediaCleanupVM))
			{
				return GetService<IMediaCleanupVM>();
			}
			if (type == typeof(IMediaSettingsVM))
			{
				return GetService<IMediaSettingsVM>();
			}
			if (type == typeof(IAudioSettingsVM))
			{
				return GetService<IAudioSettingsVM>();
			}
			if (type == typeof(IImportSettingsVM))
			{
				return GetService<IImportSettingsVM>();
			}
			if (type == typeof(IPlanningCenterSettingsVM))
			{
				return GetService<IPlanningCenterSettingsVM>();
			}
			if (type == typeof(IMultiTracksSettingsVM))
			{
				return GetService<IMultiTracksSettingsVM>();
			}
			if (type == typeof(IAutoReportDialogPrompt))
			{
				return GetService<IAutoReportDialogPrompt>();
			}
			if (type == typeof(ISongSelectSettingsVM))
			{
				return GetService<ISongSelectSettingsVM>();
			}
			if (type == typeof(IResiUpdateVM))
			{
				return GetService<IResiUpdateVM>();
			}
			if (type == typeof(ILoginDialogFactory))
			{
				return GetService<ILoginDialogFactory>();
			}
			if (type == typeof(IResiPrompt))
			{
				return GetService<IResiPrompt>();
			}
			if (type == typeof(IResiAuthorizationInteractor))
			{
				return GetService<IResiAuthorizationInteractor>();
			}
			if (type == typeof(IResiSettingsVM))
			{
				return GetService<IResiSettingsVM>();
			}
			if (type == typeof(IIntegrationsSettingsVM))
			{
				return GetService<IIntegrationsSettingsVM>();
			}
			if (type == typeof(IGroupLabelItemVMFactory))
			{
				return GetService<IGroupLabelItemVMFactory>();
			}
			if (type == typeof(IGroupsSettingsVM))
			{
				return GetService<IGroupsSettingsVM>();
			}
			if (type == typeof(ILabelItemVMFactory))
			{
				return GetService<ILabelItemVMFactory>();
			}
			if (type == typeof(ILabelsSettingsVM))
			{
				return GetService<ILabelsSettingsVM>();
			}
			if (type == typeof(ISyncController))
			{
				return GetService<ISyncController>();
			}
			if (type == typeof(ISyncSettingsVM))
			{
				return GetService<ISyncSettingsVM>();
			}
			if (type == typeof(IEnumerable<ISettingsListItem>))
			{
				return GetService<IEnumerable<ISettingsListItem>>();
			}
			if (type == typeof(ISettingsSearchEngine))
			{
				return GetService<ISettingsSearchEngine>();
			}
			if (type == typeof(ISettingsSearchVM))
			{
				return GetService<ISettingsSearchVM>();
			}
			if (type == typeof(ISettingsNavigationVM))
			{
				return GetService<ISettingsNavigationVM>();
			}
			if (type == typeof(ISettingsVM))
			{
				return GetService<ISettingsVM>();
			}
			if (type == typeof(INotificationVMFactory))
			{
				return GetService<INotificationVMFactory>();
			}
			if (type == typeof(IRegistrationRequestSender))
			{
				return GetService<IRegistrationRequestSender>();
			}
			if (type == typeof(INotificationCallbackHandler))
			{
				return GetService<INotificationCallbackHandler>();
			}
			if (type == typeof(INotificationService))
			{
				return GetService<INotificationService>();
			}
			if (type == typeof(INotificationCollectionVM))
			{
				return GetService<INotificationCollectionVM>();
			}
			if (type == typeof(IChangeDirectoryProcessFactory))
			{
				return GetService<IChangeDirectoryProcessFactory>();
			}
			if (type == typeof(IChangeWorkspaceHandler))
			{
				return GetService<IChangeWorkspaceHandler>();
			}
			if (type == typeof(CloudOnboardingVM))
			{
				return GetService<CloudOnboardingVM>();
			}
			if (type == typeof(ICloudOnboardingVM))
			{
				return GetService<ICloudOnboardingVM>();
			}
			if (type == typeof(ICloudOnboardingShellNavigator))
			{
				return GetService<ICloudOnboardingShellNavigator>();
			}
			if (type == typeof(ICloudOnboardingEligibilityVM))
			{
				return GetService<ICloudOnboardingEligibilityVM>();
			}
			if (type == typeof(ICloudOnboardingManageMediaVM))
			{
				return GetService<ICloudOnboardingManageMediaVM>();
			}
			if (type == typeof(ICloudOnboardingPricingVM))
			{
				return GetService<ICloudOnboardingPricingVM>();
			}
			if (type == typeof(ICloudOnboardingDoneVM))
			{
				return GetService<ICloudOnboardingDoneVM>();
			}
			if (type == typeof(ICloudOnboardingLocalWorkspacesVM))
			{
				return GetService<ICloudOnboardingLocalWorkspacesVM>();
			}
			if (type == typeof(ICloudTeaseVM))
			{
				return GetService<ICloudTeaseVM>();
			}
			if (type == typeof(ICloudTeaseWindowProvider))
			{
				return GetService<ICloudTeaseWindowProvider>();
			}
			if (type == typeof(IManageWorkspacesWindowProvider))
			{
				return GetService<IManageWorkspacesWindowProvider>();
			}
			if (type == typeof(IMissingFontVM))
			{
				return GetService<IMissingFontVM>();
			}
			if (type == typeof(ICalendarPrompt))
			{
				return GetService<ICalendarPrompt>();
			}
			if (type == typeof(IRTMPPrompt))
			{
				return GetService<IRTMPPrompt>();
			}
			if (type == typeof(IProContentDialogService))
			{
				return GetService<IProContentDialogService>();
			}
			if (type == typeof(IMediaImportDownloadDialogService))
			{
				return GetService<IMediaImportDownloadDialogService>();
			}
			if (type == typeof(IDownloadsDialogService))
			{
				return GetService<IDownloadsDialogService>();
			}
			if (type == typeof(IMediaCueThumbnailOverlayVMFactory))
			{
				return GetService<IMediaCueThumbnailOverlayVMFactory>();
			}
			if (type == typeof(IDownloadVMsFactory))
			{
				return GetService<IDownloadVMsFactory>();
			}
			if (type == typeof(IPropPrompts))
			{
				return GetService<IPropPrompts>();
			}
			if (type == typeof(IHardwareAlphaConfigurationVMFactory))
			{
				return GetService<IHardwareAlphaConfigurationVMFactory>();
			}
			if (type == typeof(IAlphaKeySettingsVMFactory))
			{
				return GetService<IAlphaKeySettingsVMFactory>();
			}
			if (type == typeof(ICaptureController))
			{
				return GetService<ICaptureController>();
			}
			if (type == typeof(IResiService))
			{
				return GetService<IResiService>();
			}
			if (type == typeof(IUserFeedbackConsumer))
			{
				return GetService<IUserFeedbackConsumer>();
			}
			if (type == typeof(IBuildAppMetaDataFile))
			{
				return GetService<IBuildAppMetaDataFile>();
			}
			if (type == typeof(IUserAttachmentVMFactory))
			{
				return GetService<IUserAttachmentVMFactory>();
			}
			if (type == typeof(IAttachmentsUploader))
			{
				return GetService<IAttachmentsUploader>();
			}
			if (type == typeof(IAttachmentUploadJobFactory))
			{
				return GetService<IAttachmentUploadJobFactory>();
			}
			if (type == typeof(IFeedbackVM))
			{
				return GetService<IFeedbackVM>();
			}
			if (type == typeof(ICrashReportingVM))
			{
				return GetService<ICrashReportingVM>();
			}
			if (type == typeof(IAttachmentUploadVM))
			{
				return GetService<IAttachmentUploadVM>();
			}
			if (type == typeof(ICrashReportUserFeedbackDialogProvider))
			{
				return GetService<ICrashReportUserFeedbackDialogProvider>();
			}
			if (type == typeof(IWhatsNewContentProviderFromJson))
			{
				return GetService<IWhatsNewContentProviderFromJson>();
			}
			if (type == typeof(IFeatureFactory))
			{
				return GetService<IFeatureFactory>();
			}
			if (type == typeof(IWhatsNewV2VM))
			{
				return GetService<IWhatsNewV2VM>();
			}
			if (type == typeof(IMediaActionService))
			{
				return GetService<IMediaActionService>();
			}
			if (type == typeof(ITimelineVMFactory))
			{
				return GetService<ITimelineVMFactory>();
			}
			if (type == typeof(ITimelineItemVMFactory))
			{
				return GetService<ITimelineItemVMFactory>();
			}
			if (type == typeof(IWorkspaceItemVMFactory))
			{
				return GetService<IWorkspaceItemVMFactory>();
			}
			if (type == typeof(IActionsMenuVMFactory))
			{
				return GetService<IActionsMenuVMFactory>();
			}
			if (type == typeof(IOutputScreenVMFactory))
			{
				return GetService<IOutputScreenVMFactory>();
			}
			if (type == typeof(IScreenSelectorVM))
			{
				return GetService<IScreenSelectorVM>();
			}
			if (type == typeof(IWindowedOutputVM))
			{
				return GetService<IWindowedOutputVM>();
			}
			if (type == typeof(IOutputPreviewVMFactory))
			{
				return GetService<IOutputPreviewVMFactory>();
			}
			if (type == typeof(IInternalCoreManager))
			{
				return GetService<IInternalCoreManager>();
			}
			if (type == typeof(ITriggeringFactory))
			{
				return GetService<ITriggeringFactory>();
			}
			if (type == typeof(ICalendarService))
			{
				return GetService<ICalendarService>();
			}
			if (type == typeof(IExportService))
			{
				return GetService<IExportService>();
			}
			if (type == typeof(ILibraryService))
			{
				return GetService<ILibraryService>();
			}
			if (type == typeof(IClipboardProvider))
			{
				return GetService<IClipboardProvider>();
			}
			if (type == typeof(IPasteStrategy))
			{
				return GetService<IPasteStrategy>();
			}
			if (type == typeof(IEditorService))
			{
				return GetService<IEditorService>();
			}
			if (type == typeof(PlaylistTemplateCollection))
			{
				return GetService<PlaylistTemplateCollection>();
			}
			if (type == typeof(IPlaylistTemplatesService))
			{
				return GetService<IPlaylistTemplatesService>();
			}
			if (type == typeof(ISizeProvider))
			{
				return GetService<ISizeProvider>();
			}
			if (type == typeof(IProPresenterCueVMFactory))
			{
				return GetService<IProPresenterCueVMFactory>();
			}
			if (type == typeof(IProContentDownloader))
			{
				return GetService<IProContentDownloader>();
			}
			if (type == typeof(IMacroPrompt))
			{
				return GetService<IMacroPrompt>();
			}
			if (type == typeof(ISlidePreviewService))
			{
				return GetService<ISlidePreviewService>();
			}
			if (type == typeof(PropAutoClearHandler))
			{
				return GetService<PropAutoClearHandler>();
			}
			if (type == typeof(IPropAutoClearService))
			{
				return GetService<IPropAutoClearService>();
			}
			if (type == typeof(ILegacyPurchaseBiblesDialogService))
			{
				return GetService<ILegacyPurchaseBiblesDialogService>();
			}
			if (type == typeof(IMediaValidator))
			{
				return GetService<IMediaValidator>();
			}
			if (type == typeof(IMediaProvider))
			{
				return GetService<IMediaProvider>();
			}
			if (type == typeof(IToastNotificationService))
			{
				return GetService<IToastNotificationService>();
			}
			if (type == typeof(IWorkspaceDeletedPrompt))
			{
				return GetService<IWorkspaceDeletedPrompt>();
			}
			if (type == typeof(IWorkspaceCollectionVM))
			{
				return GetService<IWorkspaceCollectionVM>();
			}
			if (type == typeof(IMainLayoutVM))
			{
				return GetService<IMainLayoutVM>();
			}
			if (type == typeof(IThemeSlideMenuVM))
			{
				return GetService<IThemeSlideMenuVM>();
			}
			if (type == typeof(IArrangementVM))
			{
				return GetService<IArrangementVM>();
			}
			if (type == typeof(ITimecodeItemVMFactory))
			{
				return GetService<ITimecodeItemVMFactory>();
			}
			if (type == typeof(ITimecodeVM))
			{
				return GetService<ITimecodeVM>();
			}
			if (type == typeof(IHeaderContentContextMenuVM))
			{
				return GetService<IHeaderContentContextMenuVM>();
			}
			if (type == typeof(IWorkspaceSwitchValidator))
			{
				return GetService<IWorkspaceSwitchValidator>();
			}
			if (type == typeof(IApplicationFailureMessageService))
			{
				return GetService<IApplicationFailureMessageService>();
			}
			if (type == typeof(IFeatureFlagService))
			{
				return GetService<IFeatureFlagService>();
			}
			if (type == typeof(ISpellChecker))
			{
				return GetService<ISpellChecker>();
			}
			if (type == typeof(IReceiveService))
			{
				return GetService<IReceiveService>();
			}
			if (type == typeof(IPresentationHandlerOperationService))
			{
				return GetService<IPresentationHandlerOperationService>();
			}
			if (type == typeof(ISettingsDataToCoreSender))
			{
				return GetService<ISettingsDataToCoreSender>();
			}
			if (type == typeof(IAPIv1Dependencies))
			{
				return GetService<IAPIv1Dependencies>();
			}
			if (type == typeof(ISharedData<AppData>))
			{
				return GetService<ISharedData<AppData>>();
			}
			if (type == typeof(Func<IRegistrationOperationFactory>))
			{
				return GetService<Func<IRegistrationOperationFactory>>();
			}
			if (type == typeof(IStartupArgumentsExecutor))
			{
				return GetService<IStartupArgumentsExecutor>();
			}
			if (type == typeof(IMessageHandler))
			{
				return GetService<IMessageHandler>();
			}
			if (type == typeof(IDocumentDiagnosticsProvider))
			{
				return GetService<IDocumentDiagnosticsProvider>();
			}
			if (type == typeof(ILaunchPopUpProvider))
			{
				return GetService<ILaunchPopUpProvider>();
			}
			if (type == typeof(IPropAutoClearHandler))
			{
				return GetService<IPropAutoClearHandler>();
			}
			if (type == typeof(ISendDataResponseHandlerProvider))
			{
				return GetService<ISendDataResponseHandlerProvider>();
			}
			if (type == typeof(IDataProcessor<SendDataResponse>))
			{
				return GetService<IDataProcessor<SendDataResponse>>();
			}
			if (type == typeof(MediaInspectorConverter))
			{
				return GetService<MediaInspectorConverter>();
			}
			if (type == typeof(WarningTooltipConverter))
			{
				return GetService<WarningTooltipConverter>();
			}
			if (type == typeof(WebFillBrowserFactory))
			{
				return GetService<WebFillBrowserFactory>();
			}
			if (type == typeof(IWebFillBrowserFactory))
			{
				return GetService<IWebFillBrowserFactory>();
			}
			if (type == typeof(IActionDialogService))
			{
				return GetService<IActionDialogService>();
			}
			if (type == typeof(ITemplateVM))
			{
				return GetService<ITemplateVM>();
			}
			if (type == typeof(Func<MainWindow>))
			{
				return GetService<Func<MainWindow>>();
			}
			if (type == typeof(IInstanceValidator))
			{
				return GetService<IInstanceValidator>();
			}
			if (type == typeof(IWorkspaceInfoDumper))
			{
				return GetService<IWorkspaceInfoDumper>();
			}
			if (type == typeof(MainWindow))
			{
				return GetService<MainWindow>();
			}
			if (type == typeof(ICloudOnboardingWindowProvider))
			{
				return GetService<ICloudOnboardingWindowProvider>();
			}
			if (type == typeof(IMediaServiceV1))
			{
				return GetService<IMediaServiceV1>();
			}
			if (type == typeof(IMediaServiceV2))
			{
				return GetService<IMediaServiceV2>();
			}
			if (type == typeof(IActionFactoryService))
			{
				return GetService<IActionFactoryService>();
			}
			if (type == typeof(IWorkspacesVM))
			{
				return GetService<IWorkspacesVM>();
			}
			if (type == typeof(IEnumerable<IStartupArgumentsExecutor>))
			{
				return GetService<IEnumerable<IStartupArgumentsExecutor>>();
			}
			if (type == typeof(IEnumerable<IMessageHandler>))
			{
				return GetService<IEnumerable<IMessageHandler>>();
			}
			if (type == typeof(IServiceProvider))
			{
				return GetService<IServiceProvider>();
			}
			if (type == typeof(IServiceScopeFactory))
			{
				return GetService<IServiceScopeFactory>();
			}
			if (type == typeof(IServiceProviderIsService))
			{
				return GetService<IServiceProviderIsService>();
			}
			return null;
		}

		object? IKeyedServiceProvider.GetKeyedService(Type type, object? key)
		{
			if (type == typeof(System.Version) && key is string text && text == "OSVersion")
			{
				return GetVersion_OSVersion();
			}
			if (type == typeof(System.Action) && key is string text2 && text2 == "ShowRegistrationSettingsKey")
			{
				return GetAction_ShowRegistrationSettingsKey();
			}
			if (type == typeof(IOAuth2AuthorizationStore) && key is string text3 && text3 == "ProContentRegistrationAuthorizationStorageKey")
			{
				return GetIOAuth2AuthorizationStore_ProContentRegistrationAuthorizationStorageKey();
			}
			if (type == typeof(IOAuth2ClientInfoProvider) && key is string text4 && text4 == "ProContentRegistrationAuthorizationInfoProviderKey")
			{
				return GetIOAuth2ClientInfoProvider_ProContentRegistrationAuthorizationInfoProviderKey();
			}
			if (type == typeof(IIdProvider) && key is string text5 && text5 == "BugsnagIdProviderKey")
			{
				return GetIIdProvider_BugsnagIdProviderKey();
			}
			if (type == typeof(ISyncRepository<ISyncData>))
			{
				switch (key as string)
				{
				case "RemoteFileRepositoryKey":
					return GetISyncRepository_ISyncData_RemoteFileRepositoryKey();
				case "LocalFileRepositoryKey":
					return GetISyncRepository_ISyncData_LocalFileRepositoryKey();
				}
			}
			if (type == typeof(System.IO.Stream) && key is string text6 && text6 == "WhatsNewContentProviderFromJsonFileContentKey")
			{
				return GetStream_WhatsNewContentProviderFromJsonFileContentKey();
			}
			if (type == typeof(IApplicationEventHandler) && key is string text7 && text7 == "CoreManagerApplicationEventHandler")
			{
				return GetIApplicationEventHandler_CoreManagerApplicationEventHandler();
			}
			if (type == typeof(Func<bool>) && key is string text8 && text8 == "ShouldSuppressVisualIndicationKey")
			{
				return GetFunc_Boolean_ShouldSuppressVisualIndicationKey();
			}
			if (type == typeof(IProcessSupervisor) && key is string text9 && text9 == "WorkspaceHelperProcessSupervisor")
			{
				return GetIProcessSupervisor_WorkspaceHelperProcessSupervisor();
			}
			return null;
		}

		object IKeyedServiceProvider.GetRequiredKeyedService(Type type, object? key)
		{
			return ((IKeyedServiceProvider)this).GetKeyedService(type, key) ?? throw Jab.JabHelpers.CreateServiceNotFoundException(type, key?.ToString());
		}

		System.Version Jab.INamedServiceProvider<System.Version>.GetService(string name)
		{
			if (name == "OSVersion")
			{
				return GetVersion_OSVersion();
			}
			throw Jab.JabHelpers.CreateServiceNotFoundException<System.Version>(name);
		}

		System.Action Jab.INamedServiceProvider<System.Action>.GetService(string name)
		{
			if (name == "ShowRegistrationSettingsKey")
			{
				return GetAction_ShowRegistrationSettingsKey();
			}
			throw Jab.JabHelpers.CreateServiceNotFoundException<System.Action>(name);
		}

		IOAuth2AuthorizationStore Jab.INamedServiceProvider<IOAuth2AuthorizationStore>.GetService(string name)
		{
			if (name == "ProContentRegistrationAuthorizationStorageKey")
			{
				return GetIOAuth2AuthorizationStore_ProContentRegistrationAuthorizationStorageKey();
			}
			throw Jab.JabHelpers.CreateServiceNotFoundException<IOAuth2AuthorizationStore>(name);
		}

		IOAuth2ClientInfoProvider Jab.INamedServiceProvider<IOAuth2ClientInfoProvider>.GetService(string name)
		{
			if (name == "ProContentRegistrationAuthorizationInfoProviderKey")
			{
				return GetIOAuth2ClientInfoProvider_ProContentRegistrationAuthorizationInfoProviderKey();
			}
			throw Jab.JabHelpers.CreateServiceNotFoundException<IOAuth2ClientInfoProvider>(name);
		}

		IIdProvider Jab.INamedServiceProvider<IIdProvider>.GetService(string name)
		{
			if (name == "BugsnagIdProviderKey")
			{
				return GetIIdProvider_BugsnagIdProviderKey();
			}
			throw Jab.JabHelpers.CreateServiceNotFoundException<IIdProvider>(name);
		}

		ISyncRepository<ISyncData> Jab.INamedServiceProvider<ISyncRepository<ISyncData>>.GetService(string name)
		{
			if (!(name == "RemoteFileRepositoryKey"))
			{
				if (name == "LocalFileRepositoryKey")
				{
					return GetISyncRepository_ISyncData_LocalFileRepositoryKey();
				}
				throw Jab.JabHelpers.CreateServiceNotFoundException<ISyncRepository<ISyncData>>(name);
			}
			return GetISyncRepository_ISyncData_RemoteFileRepositoryKey();
		}

		System.IO.Stream Jab.INamedServiceProvider<System.IO.Stream>.GetService(string name)
		{
			if (name == "WhatsNewContentProviderFromJsonFileContentKey")
			{
				return GetStream_WhatsNewContentProviderFromJsonFileContentKey();
			}
			throw Jab.JabHelpers.CreateServiceNotFoundException<System.IO.Stream>(name);
		}

		IApplicationEventHandler Jab.INamedServiceProvider<IApplicationEventHandler>.GetService(string name)
		{
			if (name == "CoreManagerApplicationEventHandler")
			{
				return GetIApplicationEventHandler_CoreManagerApplicationEventHandler();
			}
			throw Jab.JabHelpers.CreateServiceNotFoundException<IApplicationEventHandler>(name);
		}

		Func<bool> Jab.INamedServiceProvider<Func<bool>>.GetService(string name)
		{
			if (name == "ShouldSuppressVisualIndicationKey")
			{
				return GetFunc_Boolean_ShouldSuppressVisualIndicationKey();
			}
			throw Jab.JabHelpers.CreateServiceNotFoundException<Func<bool>>(name);
		}

		IProcessSupervisor Jab.INamedServiceProvider<IProcessSupervisor>.GetService(string name)
		{
			if (name == "WorkspaceHelperProcessSupervisor")
			{
				return GetIProcessSupervisor_WorkspaceHelperProcessSupervisor();
			}
			throw Jab.JabHelpers.CreateServiceNotFoundException<IProcessSupervisor>(name);
		}

		private void TryAddDisposable(object? value)
		{
			if (value is IDisposable || value is IAsyncDisposable)
			{
				lock (this)
				{
					(_disposables ?? (_disposables = new List<object>())).Add(value);
				}
			}
		}

		public void Dispose()
		{
			if (_disposables == null)
			{
				return;
			}
			foreach (object disposable in _disposables)
			{
				TryDispose(disposable);
			}
			static void TryDispose(object? value)
			{
				(value as IDisposable)?.Dispose();
			}
		}

		public async ValueTask DisposeAsync()
		{
			if (_disposables == null)
			{
				return;
			}
			foreach (object disposable2 in _disposables)
			{
				await TryDispose(disposable2);
			}
			static ValueTask TryDispose(object? value)
			{
				if (value is IAsyncDisposable asyncDisposable)
				{
					return asyncDisposable.DisposeAsync();
				}
				if (value is IDisposable disposable)
				{
					disposable.Dispose();
				}
				return default(ValueTask);
			}
		}
	}

	public const string WorkspaceHelperProcessSupervisor = "WorkspaceHelperProcessSupervisor";

	private readonly IAppContinuationService _continuationService;

	private readonly string _deviceName;

	private readonly string[] _args;

	private readonly IInstanceValidator _instanceValidator;

	private IProCoreInstance? _coreInstance;

	private UiDispatcher? _dispatcher;

	private Scope? _rootScope;

	private DatabaseService? _IDatabaseService;

	private FileSystem? _IFileSystem;

	private ThemeRepo? _IThemeRepo;

	private ThemeService? _IThemeService;

	private MessageService? _IMessageService;

	private SqliteMigrationService? _ISqliteMigrationService;

	private CookieManagerService? _ICookieManagerService;

	private App? _App;

	private IProCoreInstance? _IProCoreInstance;

	private IFlagService? _IFlagService;

	private ssAPIOutput? _ssAPIOutput;

	private MediaMetadataCacheRepository? _IMediaMetadataCacheRepository;

	private MediaMetadataCache? _IMediaMetadataCacheService;

	private IMetadataLoader? _IMetadataLoader;

	private IAssemblyInfoProvider? _IAssemblyInfoProvider;

	private System.Version? _Version_OSVersion;

	private IVersionInfoProvider? _IVersionInfoProvider;

	private IRestClientFactory? _IRestClientFactory;

	private FileSystemUriCacheServiceFactory? _IFileSystemUriCacheServiceFactory;

	private UrlBitmapThumbnailCacheService? _IUriCacheService_NullableBitmapSource;

	private RegistrationUserDialogService? _IRegistrationUserDialogService;

	private HandledErrorReporter? _IErrorPublisher;

	private CoreApplication? _ICoreApplication;

	private IRegistrationCallbackHandler? _IRegistrationCallbackHandler;

	private NotificationCallbackHandler? _NotificationCallbackHandler;

	private ProContentClientInformationProvider? _ProContentClientInformationProvider;

	private IInternetAccess? _IInternetAccess;

	private JsonWebTokenHandler? _JsonWebTokenHandler;

	private RegistrationStateHandler? _RegistrationStateHandler;

	private AfterStartupCompleteQueue? _IAfterStartupCompleteQueue;

	private UserMessageHandler? _UserMessageHandler;

	private UserAlertHandler? _IRegistrationCallbackHandler_4;

	private GetProductInformationHandler? _IRegistrationCallbackHandler_5;

	private LogHandler? _IRegistrationCallbackHandler_6;

	private WatermarkHandler? _IRegistrationCallbackHandler_7;

	private IRegistrationCallbackHandler? _IRegistrationCallbackHandler_8;

	private ProContentTokenReader? _IRegistrationCallbackHandler_9;

	private HardExitHandler? _IRegistrationCallbackHandler_10;

	private InternetAccessCheckService? _IInternetAccessCheck;

	private ExpirationDialogHandler? _IRegistrationCallbackHandler_11;

	private RegistrationClient? _RegistrationClient;

	private RegistrationOperationFactory? _IRegistrationOperationFactory;

	private ProContentRegistrationAuthorizationStorage? _IOAuth2AuthorizationStore_ProContentRegistrationAuthorizationStorageKey;

	private IProContentConsumer? _IProContentConsumer;

	private DownloadManager? _IDownloadManager;

	private ProContentAssetProvider? _IProContentAssetProvider;

	private AudioSetup? _IAudioSetup;

	private IAudioMapRecallService<DeviceChannel, Bus>? _IAudioMapRecallService_DeviceChannelBus;

	private LiveVideoInputCollection? _ILiveVideoInputCollection;

	private TextDocumentFactory? _ITextDocumentFactory;

	private EntityFactory? _IEntityFactory;

	private DocumentFactory? _IDocumentFactory;

	private DocumentService? _IDocumentService;

	private EntityFileLockFactory? _IEntityFileLockFactory;

	private CommonPathsWrapper? _ICommonPathsWrapper;

	private IMediaService? _IMediaService;

	private WorkspaceService? _IWorkspaceService;

	private ICloudDiagnosticsPublisher? _ICloudDiagnosticsPublisher;

	private IEntityDocumentRegistry? _IEntityDocumentRegistry;

	private EntityDocumentSyncerFactory? _IEntityDocumentSyncerFactory;

	private MergedEntityFactory? _IMergedEntityFactory;

	private ProPresenterDOFactoryProvider? _IProPresenterDOFactoryProvider;

	private ScreenArrangementFactory? _IScreenArrangementFactory;

	private AudioInputCollection? _IAudioInputCollection;

	private CrdtProtoDirectoryFileScanner? _ICrdtProtoDirectoryFileScanner;

	private ProPresenter.DO.Masks.MaskCollection? _IMaskCollection;

	private StagePresentation? _StagePresentation;

	private LocalDocumentSyncerFactory? _ILocalDocumentSyncerFactory;

	private IOutputConfiguration? _IOutputConfiguration;

	private CollectionStorage? _ICollectionStorage;

	private ImportProcessFactory? _IImportProcessFactory;

	private Network? _INetwork;

	private SongSelectConsumer? _ISongSelectConsumer;

	private ReportRepository? _IReportRepository;

	private ActionBinderFactory? _IActionBinderFactory;

	private EncoderValidator? _IEncoderValidator;

	private BugsnagUserInfo? _IIdProvider_BugsnagIdProviderKey;

	private ApplicationLaunchEventPublisher? _IApplicationLaunchEventPublisher;

	private ProContentProvider? _IProContentProvider;

	private UrlAnimatedImageCacheService? _IUriCacheService_IReadOnlyList_IAnimationFrame;

	private IOutputRepository? _IOutputRepository;

	private CommunicationOutput? _ICommunicationOutput;

	private IErrorPrompt? _IErrorPrompt;

	private IResiPlugin? _IResiPlugin;

	private IResiCustomEndpointsStore? _IResiCustomEndpointsStore;

	private ResiWebClient? _IResiWebClient;

	private Messages<AppMessages>? _IMessages_AppMessages;

	private UpdateClient? _IUpdateClient;

	private TestPatternPersistence? _ITestPatternPersistence;

	private TestPatternService? _ITestPatternService;

	private AppUpdateUserDialogService? _IAppUpdateUserDialogService;

	private AppUpdateService? _IAppUpdateService;

	private IBibleDataStore? _IBibleDataStore;

	private BibleProvider? _IBibleProvider;

	private MultiTracksConsumer? _IMultiTracksConsumer;

	private IPCOConsumer? _IPCOConsumer;

	private PCOUpdater? _IPCOUpdater;

	private ExportProcessFactory? _IExportProcessFactory;

	private IInputActions? _IInputActions;

	private CloudWorkspaceService? _ICloudWorkspaceService;

	private CloudOnboardingService? _ICloudOnboardingService;

	private IWorkspaceDocumentOrchestrator? _IWorkspaceDocumentOrchestrator;

	private ThemeCollection? _ThemeCollection;

	private ProcessHelper? _IProcessHelper;

	private FileObservatory? _IFileObservatory;

	private MidiDeviceSettingsVM? _IMidiDeviceSettingsVM;

	private MidiWindowProvider? _IMidiWindowProvider;

	private AirCastConfiguration? _IAirCastConfiguration;

	private IInstallFileExecutor? _IInstallFileExecutor;

	private CCLIReportCollectionVM? _ICCLIReportCollectionVM;

	private CopyrightSettingsVM? _ICopyrightSettingsVM;

	private NetworkCommandTrigger? _INetworkCommandTrigger;

	private ResiController? _IResiController;

	private ICrashRecovery? _ICrashRecovery;

	private CaptureController? _CaptureController;

	private TimedPlaybackRepository? _ITimedPlaybackRepository;

	private TimelineService? _ITimelineService;

	private TimecodeService? _ITimecodeService;

	private TimelineManager? _ITimelineManager;

	private CoreManager? _CoreManager;

	private GeneralSettingsVM? _IGeneralSettingsVM;

	private CommandSender? _ICommandSender;

	private ServerStateHandler? _IServerStateHandler;

	private NetworkEnvironment? _INetworkEnvironment;

	private NetworkLinkService? _INetworkLinkService;

	private NetworkLinkPrompt? _INetworkLinkPrompt;

	private NetworkLinkVM? _INetworkLinkVM;

	private NetworkSettingsVM? _INetworkSettingsVM;

	private IRegistrationUnlockCodeVM? _IRegistrationUnlockCodeVM;

	private IOrganizationConsumer? _IOrganizationConsumer;

	private UserAvatarProvider? _IUserAvatarProvider;

	private RegistrationMainPageVM? _IRegistrationMainPageVM;

	private AccountCenterVM? _IAccountCenterVM;

	private UpdatesSettingsVM? _IUpdatesSettingsVM;

	private ClockSourceProvider? _IClockSourceProvider;

	private ClockSourceService? _IClockSourceService;

	private ClockSourceVM? _IClockSourceVM;

	private ScreenSettingsVM? _IScreenSettingsVM;

	private VideoInputsSettingsVM? _IVideoInputsSettingsVM;

	private VideoInputItemVMFactory? _IVideoInputItemVMFactory;

	private AudioInputsSettingsVM? _IAudioInputsSettingsVM;

	private NdiInputsSettingsVM? _INdiInputsSettingsVM;

	private InputsSettingsVM? _IInputsSettingsVM;

	private DevicesSettingsVM? _IDevicesSettingsVM;

	private MediaSearchPathsSettingsVM? _IMediaSearchPathsSettingsVM;

	private MediaCleanupService? _IMediaCleanupService;

	private MediaCleanupVM? _IMediaCleanupVM;

	private MediaSettingsVM? _IMediaSettingsVM;

	private AudioSettingsVM? _IAudioSettingsVM;

	private ImportSettingsVM? _IImportSettingsVM;

	private PlanningCenterSettingsVM? _IPlanningCenterSettingsVM;

	private MultiTracksSettingsVM? _IMultiTracksSettingsVM;

	private SongSelectSettingsVM? _ISongSelectSettingsVM;

	private ResiUpdateVM? _IResiUpdateVM;

	private ResiAuthorizationInteractor? _IResiAuthorizationInteractor;

	private ResiSettingsVM? _IResiSettingsVM;

	private IntegrationsSettingsVM? _IIntegrationsSettingsVM;

	private GroupsSettingsVM? _IGroupsSettingsVM;

	private LabelsSettingsVM? _ILabelsSettingsVM;

	private ISyncController? _ISyncController;

	private SyncSettingsVM? _ISyncSettingsVM;

	private ISettingsSearchEngine? _ISettingsSearchEngine;

	private SettingsSearchVM? _ISettingsSearchVM;

	private SettingsNavigationVM? _ISettingsNavigationVM;

	private SettingsVM? _ISettingsVM;

	private NotificationVMFactory? _INotificationVMFactory;

	private NotificationService? _INotificationService;

	private NotificationCollectionVM? _INotificationCollectionVM;

	private ChangeWorkspaceHandler? _IChangeWorkspaceHandler;

	private CloudOnboardingVM? _CloudOnboardingVM;

	private ManageWorkspacesWindowProvider? _IManageWorkspacesWindowProvider;

	private AttachmentsUploader? _IAttachmentsUploader;

	private FeedbackVM? _IFeedbackVM;

	private ICrashReportingVM? _ICrashReportingVM;

	private AttachmentUploadVM? _IAttachmentUploadVM;

	private WhatsNewV2VM? _IWhatsNewV2VM;

	private MediaActionService? _IMediaActionService;

	private ScreenSelectorVM? _IScreenSelectorVM;

	private IWindowedOutputVM? _IWindowedOutputVM;

	private CalendarService? _ICalendarService;

	private LibraryService? _ILibraryService;

	private ClipboardProvider? _IClipboardProvider;

	private PasteStrategy? _IPasteStrategy;

	private DefaultScreenSizeProvider? _ISizeProvider;

	private MacroPrompt? _IMacroPrompt;

	private PropAutoClearHandler? _PropAutoClearHandler;

	private IPropAutoClearService? _IPropAutoClearService;

	private ToastNotificationService? _IToastNotificationService;

	private WorkspaceDeletedPrompt? _IWorkspaceDeletedPrompt;

	private IWorkspaceCollectionVM? _IWorkspaceCollectionVM;

	private MainLayoutVM? _IMainLayoutVM;

	private TimecodeVM? _ITimecodeVM;

	private WorkspaceSwitchValidator? _IWorkspaceSwitchValidator;

	private Pro.CoreApplication.FeatureFlag.FeatureFlagService? _IFeatureFlagService;

	private ReceiveService? _IReceiveService;

	private SettingsDataToCoreSender? _ISettingsDataToCoreSender;

	private ISharedData<AppData>? _ISharedData_AppData;

	private IDocumentDiagnosticsProvider? _IDocumentDiagnosticsProvider;

	private IPropAutoClearHandler? _IPropAutoClearHandler;

	private SendDataResponseHandlerProvider? _ISendDataResponseHandlerProvider;

	private ProCoreSendDataProcessor? _IDataProcessor_SendDataResponse;

	private WebFillBrowserFactory? _WebFillBrowserFactory;

	private WorkspaceInfoDumper? _IWorkspaceInfoDumper;

	private MainWindow? _MainWindow;

	private CloudOnboardingWindowProvider? _ICloudOnboardingWindowProvider;

	private MediaServiceV1? _IMediaServiceV1;

	private MediaServiceV2? _IMediaServiceV2;

	private IProcessSupervisor? _IProcessSupervisor_WorkspaceHelperProcessSupervisor;

	private IActionFactoryService? _IActionFactoryService;

	private IWorkspacesVM? _IWorkspacesVM;

	private FileStartupArgumentExecutor? _IStartupArgumentsExecutor_1;

	private FocusWindowMessageHandler? _IMessageHandler_1;

	private FileMessageHandler? _IMessageHandler_2;

	private List<object>? _disposables;

	public IProCoreInstance? CoreInstance
	{
		get
		{
			return _coreInstance;
		}
		set
		{
			TryAddDisposable(value);
			_coreInstance = value;
		}
	}

	public bool UsedStartupArgumentToRegisterActionKey { get; private set; }

	public SplashDialog? splashDialog { get; set; }

	public ServiceProvider(IAppContinuationService continuationService, string deviceName, string[] args, IInstanceValidator instanceValidator)
	{
		_continuationService = continuationService;
		_deviceName = deviceName;
		_args = args;
		_instanceValidator = instanceValidator;
	}

	public void SetMainThreadDispatcher(Dispatcher dispatcher)
	{
		_dispatcher = new UiDispatcher(dispatcher);
	}

	public void SetSplashDialog(SplashDialog? dialog)
	{
		splashDialog = dialog;
	}

	private IAppContinuationService GetContinuationService()
	{
		return _continuationService;
	}

	private RegistrationStateHandler GetRegistrationStateHandler(IVersionInfoProvider versionInfoProvider, JsonWebTokenHandler jsonWebTokenHandler)
	{
		return new RegistrationStateHandler(versionInfoProvider.BuildDate, jsonWebTokenHandler, _deviceName);
	}

	private static System.Action GetShowRegistrationSettings(Func<IMainLayoutVM> mainLayoutVmGetter)
	{
		return delegate
		{
			mainLayoutVmGetter().ActivateRegistrationUI();
		};
	}

	private Func<IRegistrationOperationFactory> GetRegistrationOperationFactoryGetter()
	{
		return () => GetRegistrationOperationFactoryProvider(this).GetService();
	}

	private Func<bool> GetShouldSuppressVisualIndication()
	{
		return () => this.GetTypedService<ICloudOnboardingService>().IsOnboardingInProgress;
	}

	private static Jab.IServiceProvider<IRegistrationOperationFactory> GetRegistrationOperationFactoryProvider(Jab.IServiceProvider<IRegistrationOperationFactory> provider)
	{
		return provider;
	}

	private UiDispatcher GetDispatcher()
	{
		_dispatcher.ThrowWhenNull("_dispatcher");
		return _dispatcher;
	}

	private IFlagService GetFlagService(IApp app)
	{
		return new ProPresenter.FeatureFlag.FeatureFlagService(app, _args);
	}

	private IProCoreInstance GetCoreInstance()
	{
		CoreInstance.ThrowWhenNull("CoreInstance");
		return CoreInstance;
	}

	public static ISystemInfoProvider GetSystemInfoProvider(IFileSystem fileSystem, IDxDiagReaderFactory dxDiagReaderFactory, [Jab.FromNamedServices("BugsnagIdProviderKey")] IIdProvider idProvider)
	{
		return new SystemInfoProvider(fileSystem, dxDiagReaderFactory, idProvider);
	}

	public IStartupArgumentsExecutor GetUriSchemeStartupArgumentExecutor(Func<IRegistrationOperationFactory> getRegistrationOperationFactory, ISharedData<AppData> sharedData, IMessages<AppMessages> messages, Func<IMainLayoutVM> getMainLayoutVM)
	{
		return new UriSchemeStartupArgumentExecutor(getRegistrationOperationFactory, sharedData, messages, getMainLayoutVM, delegate(bool value)
		{
			UsedStartupArgumentToRegisterActionKey = value;
		});
	}

	public IMediaService GetMediaService(IFlagService flagService)
	{
		if (flagService.IsFlagEnabled(Flag.Cloud))
		{
			return this.GetTypedService<IMediaServiceV2>();
		}
		return this.GetTypedService<IMediaServiceV1>();
	}

	public ITrackedMediaHelpers GetTrackedMediaHelpers(IFlagService flagService, IAsyncExecutor asyncExecutor)
	{
		if (flagService.IsFlagEnabled(Flag.Cloud))
		{
			return new MediaManagementV2TrackedMediaHelpers(asyncExecutor, this.GetTypedService<IMediaServiceV2>());
		}
		return new MediaManagementV1TrackedMediaHelpers(asyncExecutor, this.GetTypedService<IMediaServiceV1>());
	}

	public IMetadataLoader GetMetadataLoader(IFlagService flagService, IImageLoader imageLoader, IMediaMetadataCacheService cacheService, IAsyncExecutor asyncExecutor, IFileService fileService, ILogger logger, IUiScheduler scheduler)
	{
		if (flagService.IsFlagEnabled(Flag.Cloud))
		{
			return new CoreMetadataLoaderV2(this.GetTypedService<IMediaServiceV2>(), imageLoader, cacheService, asyncExecutor, fileService, logger, scheduler);
		}
		return new CoreMetadataLoaderV1(this.GetTypedService<IMediaServiceV1>(), imageLoader, cacheService, asyncExecutor, fileService, logger, scheduler, this.GetTypedService<IFileObservatory>());
	}

	private Func<IMainLayoutVM> GetMainLayoutVmGetter()
	{
		return () => this.GetTypedService<IMainLayoutVM>();
	}

	private Func<MainWindow> GetMainWindowGetter()
	{
		return () => this.GetTypedService<MainWindow>();
	}

	private IInstanceValidator GetInstanceValidator()
	{
		return _instanceValidator;
	}

	private static IProContentConsumer GetProContentConsumer(IAuthenticatingApiConsumerFactory consumerFactory, IApp app, ILogger logger, IApiService apiService, IFlagService flagService, [Jab.FromNamedServices("ProContentRegistrationAuthorizationStorageKey")] IOAuth2AuthorizationStore authorizationStorage, [Jab.FromNamedServices("ProContentRegistrationAuthorizationInfoProviderKey")] IOAuth2ClientInfoProvider clientInfoProvider)
	{
		return new ProContentConsumer(consumerFactory, app, logger, apiService, flagService, authorizationStorage, clientInfoProvider);
	}

	private static IOrganizationConsumer GetOrganizationConsumer(IAuthenticatingApiConsumerFactory consumerFactory, IFlagService flagService, [Jab.FromNamedServices("ProContentRegistrationAuthorizationStorageKey")] IOAuth2AuthorizationStore authorizationStorage, [Jab.FromNamedServices("ProContentRegistrationAuthorizationInfoProviderKey")] IOAuth2ClientInfoProvider clientInfoProvider, IRestClientFactory restClientFactory, ILogger logger)
	{
		return new OrganizationConsumer(consumerFactory, flagService, authorizationStorage, clientInfoProvider, restClientFactory, logger);
	}

	public static ISyncController GetSyncController([Jab.FromNamedServices("RemoteFileRepositoryKey")] ISyncRepository<ISyncData> remoteRepo, [Jab.FromNamedServices("LocalFileRepositoryKey")] ISyncRepository<ISyncData> localRepo, ISyncActionProvider syncActionProvider, ISync sync, ILocalization localization)
	{
		return new SyncController(remoteRepo, localRepo, syncActionProvider, sync, (bool syncUp) => MessageDialogService.ShowDialog(localization.Get("FILE_CONFLICT_WRITE_OVER_title"), localization.Get(syncUp ? "SYNC_PREFERENCES_ALERT_REPLACE_SYNC_UP_message" : "SYNC_PREFERENCES_ALERT_REPLACE_SYNC_DOWN_message") + Environment.NewLine + Environment.NewLine + localization.Get("SYNC_PREFERENCES_ALERT_DELETE_info"), SyncOverwriteButtons.Cancel | SyncOverwriteButtons.Sync, SyncOverwriteButtons.Sync) == SyncOverwriteButtons.Sync);
	}

	public static IWhatsNewContentProviderFromJson GetWhatsNewContentProviderFromJson([Jab.FromNamedServices("WhatsNewContentProviderFromJsonFileContentKey")] System.IO.Stream jsonStream)
	{
		return new WhatsNewContentProviderFromJson(jsonStream);
	}

	public static System.IO.Stream GetEmbeddedWhatsNewContent()
	{
		System.IO.Stream? manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ProPresenter.resources.Whats_New.WhatsNewFeatures.json");
		manifestResourceStream.ThrowWhenNull("result");
		return manifestResourceStream;
	}

	private MainWindow GetMainWindow(IMessages<AppMessages> messages, ssAPIOutput outputController, IApp app, ITestPatternService testPatternService, ITestPatternAnalyticEventsPublisher testPatternAnalyticEventsPublisher, IAttachmentsUploader attachmentsUploader, ICrashReportUserFeedbackDialogProvider crashReportUserFeedbackDialogProvider, ISettingsVM settingsVM, IMessageService messageService, IAfterStartupCompleteQueue afterStartupCompleteQueue, IScreenSelectorVM screenSelectorVM, IWindowedOutputVM windowedOutputVM, INetwork network, IMainLayoutVM mainLayoutVM, IWebSourceProvider webSourceProvider, IHyperlinkService hyperlinkService, IInputActions inputActions, IWhatsNewV2VM whatsNewV2VM, IFlagService flagService, IWorkspaceInfoDumper workspaceInfoDumper)
	{
		return new MainWindow(messages, splashDialog, outputController, app, testPatternService, testPatternAnalyticEventsPublisher, attachmentsUploader, crashReportUserFeedbackDialogProvider, settingsVM, messageService, afterStartupCompleteQueue, screenSelectorVM, windowedOutputVM, network, webSourceProvider, hyperlinkService, inputActions, whatsNewV2VM, flagService, workspaceInfoDumper)
		{
			DataContext = mainLayoutVM
		};
	}

	private static IProcessSupervisor GetWorkspaceHelperSupervision(ILogger logger, ITimerFactory timerFactory, IFileSystem fileSystem)
	{
		ProcessSupervisor processSupervisor = new ProcessSupervisor(logger, "ProPresenter Helper - Workspaces", Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Workspaces\\ProPresenter Helper - Workspaces.exe"), timerFactory, fileSystem);
		(from x in processSupervisor.WhenStateChanges.DistinctUntilChanged()
			where x == ProcessState.NotRunning
			select x).Subscribe(delegate
		{
			UnexpectedlyNotRunningEvent.Publish();
		});
		processSupervisor.Start();
		return processSupervisor;
	}

	private static IActionFactoryService GetActionFactory(IOutputService outputService, IResiService resiService, IApp app, ITimerFactory timerFactory, IPlaylistActionValidatorFactory playlistActionValidatorFactory, IOutputRepository outputRepository, IProPresenterResourceService proPresenterResourceService, IProPresenterDOFactoryProvider factoryProvider, IMessageDialogService messageDialogService, ICurrentTime currentTime, IOutputConfiguration outputConfiguration)
	{
		ActionFactoryService actionFactoryService = new ActionFactoryService();
		ITransitionDescriptionCollection transitionDescriptions = outputRepository.AvailableTransitions;
		actionFactoryService.RegisterActionType(ActionType.StageLayout, (Pro.SerializationInterop.RVProtoData.Action? _, string _) => new StageAction(outputRepository.StageScreenArrangementCollection, proPresenterResourceService.StagePresentation));
		actionFactoryService.RegisterActionType(ActionType.Media, (Pro.SerializationInterop.RVProtoData.Action? proto, string containerId) => MediaAction.ConstructMediaAction(proto, app, factoryProvider.MediaFactory, transitionDescriptions, containerId));
		actionFactoryService.RegisterActionType(ActionType.Timer, (Pro.SerializationInterop.RVProtoData.Action? _, string _) => new TimerAction());
		actionFactoryService.RegisterActionType<CommunicationAction>(ActionType.Communication);
		actionFactoryService.RegisterActionType<ClearAction>(ActionType.Clear);
		actionFactoryService.RegisterActionType<PropAction>(ActionType.Prop);
		actionFactoryService.RegisterActionType(ActionType.Message, (Pro.SerializationInterop.RVProtoData.Action? a, string _) => new MessageAction(proPresenterResourceService.Messages));
		actionFactoryService.RegisterActionType(ActionType.Slide, (Pro.SerializationInterop.RVProtoData.Action? _, string containerId) => SlideAction.ConstructSlideAction(ActionType.Slide, factoryProvider, transitionDescriptions, containerId));
		actionFactoryService.RegisterActionType(ActionType.PropSlide, (Pro.SerializationInterop.RVProtoData.Action? _, string containerId) => SlideAction.ConstructSlideAction(ActionType.PropSlide, factoryProvider, transitionDescriptions, containerId));
		actionFactoryService.RegisterActionType(ActionType.Document, (Pro.SerializationInterop.RVProtoData.Action? _, string _) => new DocumentAction(new CustomPresentation(app, timerFactory, factoryProvider, transitionDescriptions, messageDialogService, currentTime), overrideProperties: false));
		actionFactoryService.RegisterActionType(ActionType.Header, (Pro.SerializationInterop.RVProtoData.Action? _, string _) => new HeaderAction());
		actionFactoryService.RegisterActionType(ActionType.AudienceLook, (Pro.SerializationInterop.RVProtoData.Action? _, string _) => new AudienceLookAction(outputConfiguration.AudienceLooks));
		actionFactoryService.RegisterActionType(ActionType.AudioInput, (Pro.SerializationInterop.RVProtoData.Action? _, string _) => new AudioInputAction(outputConfiguration.AvailableAudioInputs));
		actionFactoryService.RegisterActionType(ActionType.VisualPlaylist, (Pro.SerializationInterop.RVProtoData.Action? _, string _) => new VisualPlaylistAction(playlistActionValidatorFactory));
		actionFactoryService.RegisterActionType(ActionType.AudioPlaylist, (Pro.SerializationInterop.RVProtoData.Action? _, string _) => new AudioPlaylistAction(playlistActionValidatorFactory));
		actionFactoryService.RegisterActionType<SlideDestinationAction>(ActionType.SlideDestination);
		actionFactoryService.RegisterActionType<MacroAction>(ActionType.Macro);
		actionFactoryService.RegisterActionType<ClearGroupAction>(ActionType.ClearGroup);
		actionFactoryService.RegisterActionType(ActionType.Capture, (Pro.SerializationInterop.RVProtoData.Action? _, string _) => new CaptureAction(outputService.OutputConfiguration.CaptureSettings, resiService));
		actionFactoryService.RegisterActionType(ActionType.LibraryPlaylist, (Pro.SerializationInterop.RVProtoData.Action? _, string _) => new LibraryPlaylistAction(playlistActionValidatorFactory, null));
		return actionFactoryService;
	}

	private IImportLocationSelectionDialogService GetImportLocationSelectionDialogService()
	{
		return new ImportLocationSelectionDialogService(new Lazy<ILibraryService>(() => this.GetTypedService<ILibraryService>()));
	}

	public WorkspacesVM CreateWorkspaceVM(IChangeWorkspaceHandler changeSupportFolderHandler, IFileSelectorService fileSelectorService, ILocalization localization, IFileSystem fileSystem, IProcessHelper processHelper, IManageWorkspacesWindowProvider manageWorkspacesWindowProvider, IWorkspaceService workspaceService, IFileUtility fileUtility, ILogger logger, IFileService fileService, ICommonPathsWrapper commonPathsWrapper, IMainLayoutVM mainLayoutVm, IWorkspaceSwitchValidator workspaceSwitchValidator, IHyperlinkService hyperlinkService, IFlagService flagService, IRegistrationWebResourceService registrationWebResourceService, IRegistrationStateProvider registration, IUiScheduler uiScheduler, IMessageDialogService messageDialogService, IWorkspaceAnalyticsEventPublisher workspaceAnalytics, IVisualPlaylistRepo visualPlaylistRepo, IWorkspaceDocumentOrchestrator workspaceDocumentToCoreService, IStopwatchFactory stopwatchFactory, IAsyncExecutor asyncExecutor, IAppUpdateService appUpdateService, IMediaFileProvider mediaFileProvider, IWorkspaceCollectionVM workspaceCollectionVM)
	{
		ICloudWorkspaceService cloudWorkspaceService = (flagService.IsFlagEnabled(Flag.Cloud) ? this.GetTypedService<ICloudWorkspaceService>() : null);
		return new WorkspacesVM(changeSupportFolderHandler, fileSelectorService, localization, fileSystem, processHelper, manageWorkspacesWindowProvider, workspaceService, fileUtility, logger, fileService, commonPathsWrapper, mainLayoutVm, workspaceSwitchValidator, hyperlinkService, cloudWorkspaceService, registration, registrationWebResourceService, uiScheduler, messageDialogService, workspaceAnalytics, visualPlaylistRepo, workspaceDocumentToCoreService, stopwatchFactory, asyncExecutor, appUpdateService, mediaFileProvider, workspaceCollectionVM);
	}

	private IWorkspaceCollectionVM GetWorkspaceCollectionVM(IFlagService flagService, IWorkspaceService workspaceService, IWorkspaceItemVMFactory itemVMFactory, IUiScheduler scheduler, IFileSystem fileSystem, ICommonPathsWrapper commonPathsWrapper, IWorkspaceDeletedPrompt workspaceDeletedPrompt, IAsyncExecutor asyncExecutor)
	{
		return new WorkspaceCollectionVM(flagService.IsFlagEnabled(Flag.Cloud) ? this.GetTypedService<ICloudWorkspaceService>() : null, workspaceService, itemVMFactory, scheduler, fileSystem, commonPathsWrapper, workspaceDeletedPrompt, asyncExecutor);
	}

	public IProContentDownloader CreateProContentDownloader(IMediaService mediaService, IProContentDialogService dialogService, IApp app, IProContentUserInteractionBehavior userInteraction)
	{
		if (mediaService is IMediaServiceV2 mediaService2)
		{
			return new MediaManagementProContentDownloader(app, dialogService, userInteraction, this.GetTypedService<IProContentConsumer>(), this.GetTypedService<IProContentDownloadFailedDialogService>(), mediaService2, this.GetTypedService<ILogger>(), this.GetTypedService<IProContentAnalyticEventsPublisher>(), this.GetTypedService<IProPresenterResourceService>(), this.GetTypedService<IFileSystem>(), this.GetTypedService<IImport>(), this.GetTypedService<IMediaFactory>(), this.GetTypedService<ITransitionDescriptionCollection>());
		}
		return new ProContentDownloader(dialogService, userInteraction, this.GetTypedService<IProContentDownloadProcessFactory>());
	}

	public ISettingsListItem[] GetSettingsVMs(IRegistrationMainPageVM registrationMainPageVM, IGeneralSettingsVM generalSettingsVM, IUpdatesSettingsVM updatesSettingsVM, IScreenSettingsVM screenSettingsVM, IAudioSettingsVM audioSettingsVM, INetworkSettingsVM networkSettingsVM, IInputsSettingsVM inputsSettingsVM, IDevicesSettingsVM devicesSettingsVM, IMediaSettingsVM mediaSettingsVM, IImportSettingsVM importSettingsVM, IIntegrationsSettingsVM integrationsSettingsVM, IGroupsSettingsVM groupsSettingsVM, ILabelsSettingsVM labelsSettingsVM, IFlagService flagService)
	{
		if (!flagService.IsFlagEnabled(Flag.Cloud))
		{
			return new ISettingsListItem[18]
			{
				registrationMainPageVM,
				new SettingsHeaderItemVM(),
				generalSettingsVM,
				updatesSettingsVM,
				new SettingsHeaderItemVM(),
				screenSettingsVM,
				audioSettingsVM,
				networkSettingsVM,
				inputsSettingsVM,
				devicesSettingsVM,
				new SettingsHeaderItemVM(),
				mediaSettingsVM,
				importSettingsVM,
				integrationsSettingsVM,
				this.GetTypedService<ISyncSettingsVM>(),
				new SettingsHeaderItemVM(),
				groupsSettingsVM,
				labelsSettingsVM
			};
		}
		return new ISettingsListItem[17]
		{
			registrationMainPageVM,
			new SettingsHeaderItemVM(),
			generalSettingsVM,
			updatesSettingsVM,
			new SettingsHeaderItemVM(),
			screenSettingsVM,
			audioSettingsVM,
			networkSettingsVM,
			inputsSettingsVM,
			devicesSettingsVM,
			new SettingsHeaderItemVM(),
			mediaSettingsVM,
			importSettingsVM,
			integrationsSettingsVM,
			new SettingsHeaderItemVM(),
			groupsSettingsVM,
			labelsSettingsVM
		};
	}

	IPhysicalDeviceProvider Jab.IServiceProvider<IPhysicalDeviceProvider>.GetService()
	{
		PhysicalDeviceProvider physicalDeviceProvider = new PhysicalDeviceProvider();
		TryAddDisposable(physicalDeviceProvider);
		return physicalDeviceProvider;
	}

	IDatabaseService Jab.IServiceProvider<IDatabaseService>.GetService()
	{
		if (_IDatabaseService == null)
		{
			lock (this)
			{
				if (_IDatabaseService == null)
				{
					_IDatabaseService = new DatabaseService();
				}
			}
		}
		return _IDatabaseService;
	}

	IFileWatcherFactory Jab.IServiceProvider<IFileWatcherFactory>.GetService()
	{
		FileWatcherFactory fileWatcherFactory = new FileWatcherFactory();
		TryAddDisposable(fileWatcherFactory);
		return fileWatcherFactory;
	}

	IFileSystem Jab.IServiceProvider<IFileSystem>.GetService()
	{
		if (_IFileSystem == null)
		{
			lock (this)
			{
				if (_IFileSystem == null)
				{
					_IFileSystem = new FileSystem();
				}
			}
		}
		return _IFileSystem;
	}

	IUiDispatcher Jab.IServiceProvider<IUiDispatcher>.GetService()
	{
		IUiDispatcher dispatcher = GetDispatcher();
		TryAddDisposable(dispatcher);
		return dispatcher;
	}

	ITimerFactory Jab.IServiceProvider<ITimerFactory>.GetService()
	{
		TimerFactory timerFactory = new TimerFactory(GetService<IUiDispatcher>());
		TryAddDisposable(timerFactory);
		return timerFactory;
	}

	IDebouncerFactory Jab.IServiceProvider<IDebouncerFactory>.GetService()
	{
		DebouncerFactory debouncerFactory = new DebouncerFactory(GetService<ITimerFactory>());
		TryAddDisposable(debouncerFactory);
		return debouncerFactory;
	}

	IThemeRepo Jab.IServiceProvider<IThemeRepo>.GetService()
	{
		if (_IThemeRepo == null)
		{
			lock (this)
			{
				if (_IThemeRepo == null)
				{
					_IThemeRepo = new ThemeRepo(GetService<IDatabaseService>(), GetService<IFileWatcherFactory>(), GetService<IFileSystem>(), GetService<IDebouncerFactory>());
				}
			}
		}
		return _IThemeRepo;
	}

	IPropsRepo Jab.IServiceProvider<IPropsRepo>.GetService()
	{
		PropsRepo propsRepo = new PropsRepo();
		TryAddDisposable(propsRepo);
		return propsRepo;
	}

	IMacrosRepo Jab.IServiceProvider<IMacrosRepo>.GetService()
	{
		MacrosRepo macrosRepo = new MacrosRepo();
		TryAddDisposable(macrosRepo);
		return macrosRepo;
	}

	ILibraryPlaylistRepo Jab.IServiceProvider<ILibraryPlaylistRepo>.GetService()
	{
		LibraryPlaylistRepo libraryPlaylistRepo = new LibraryPlaylistRepo();
		TryAddDisposable(libraryPlaylistRepo);
		return libraryPlaylistRepo;
	}

	IVisualPlaylistRepo Jab.IServiceProvider<IVisualPlaylistRepo>.GetService()
	{
		VisualPlaylistRepo visualPlaylistRepo = new VisualPlaylistRepo();
		TryAddDisposable(visualPlaylistRepo);
		return visualPlaylistRepo;
	}

	IProPresenterResourceService Jab.IServiceProvider<IProPresenterResourceService>.GetService()
	{
		ProPresenterResourceService proPresenterResourceService = new ProPresenterResourceService(GetService<IThemeRepo>(), GetService<IPropsRepo>(), GetService<IMacrosRepo>(), GetService<ILibraryPlaylistRepo>(), GetService<IVisualPlaylistRepo>());
		TryAddDisposable(proPresenterResourceService);
		return proPresenterResourceService;
	}

	IThemeService Jab.IServiceProvider<IThemeService>.GetService()
	{
		if (_IThemeService == null)
		{
			lock (this)
			{
				if (_IThemeService == null)
				{
					_IThemeService = new ThemeService(GetService<IThemeRepo>());
				}
			}
		}
		return _IThemeService;
	}

	IZipService Jab.IServiceProvider<IZipService>.GetService()
	{
		ZipService zipService = new ZipService();
		TryAddDisposable(zipService);
		return zipService;
	}

	IMessageService Jab.IServiceProvider<IMessageService>.GetService()
	{
		if (_IMessageService == null)
		{
			lock (this)
			{
				if (_IMessageService == null)
				{
					_IMessageService = new MessageService();
				}
			}
		}
		return _IMessageService;
	}

	IFileService Jab.IServiceProvider<IFileService>.GetService()
	{
		FileService fileService = new FileService();
		TryAddDisposable(fileService);
		return fileService;
	}

	ILogger Jab.IServiceProvider<ILogger>.GetService()
	{
		Logger logger = new Logger();
		TryAddDisposable(logger);
		return logger;
	}

	ILocalization Jab.IServiceProvider<ILocalization>.GetService()
	{
		Localization localization = new Localization();
		TryAddDisposable(localization);
		return localization;
	}

	IAdvanced Jab.IServiceProvider<IAdvanced>.GetService()
	{
		IAdvanced advanced = ISettingsServiceProviderModule.GetAdvanced();
		TryAddDisposable(advanced);
		return advanced;
	}

	IProtoService Jab.IServiceProvider<IProtoService>.GetService()
	{
		ProtoService protoService = new ProtoService();
		TryAddDisposable(protoService);
		return protoService;
	}

	ISqliteMigrationService Jab.IServiceProvider<ISqliteMigrationService>.GetService()
	{
		if (_ISqliteMigrationService == null)
		{
			lock (this)
			{
				if (_ISqliteMigrationService == null)
				{
					_ISqliteMigrationService = new SqliteMigrationService(GetService<IDatabaseService>());
				}
			}
		}
		return _ISqliteMigrationService;
	}

	ICookieManagerService Jab.IServiceProvider<ICookieManagerService>.GetService()
	{
		if (_ICookieManagerService == null)
		{
			lock (this)
			{
				if (_ICookieManagerService == null)
				{
					_ICookieManagerService = new CookieManagerService(GetService<IDatabaseService>(), GetService<ISqliteMigrationService>());
				}
			}
		}
		return _ICookieManagerService;
	}

	App Jab.IServiceProvider<App>.GetService()
	{
		if (_App == null)
		{
			lock (this)
			{
				if (_App == null)
				{
					_App = new App(GetService<ICookieManagerService>());
				}
			}
		}
		return _App;
	}

	IApp Jab.IServiceProvider<IApp>.GetService()
	{
		IApp app = ISettingsServiceProviderModule.GetApp(GetService<App>());
		TryAddDisposable(app);
		return app;
	}

	IProCoreInstance Jab.IServiceProvider<IProCoreInstance>.GetService()
	{
		if (_IProCoreInstance == null)
		{
			lock (this)
			{
				if (_IProCoreInstance == null)
				{
					_IProCoreInstance = GetCoreInstance();
				}
			}
		}
		return _IProCoreInstance;
	}

	IFlagService Jab.IServiceProvider<IFlagService>.GetService()
	{
		if (_IFlagService == null)
		{
			lock (this)
			{
				if (_IFlagService == null)
				{
					_IFlagService = GetFlagService(GetService<IApp>());
				}
			}
		}
		return _IFlagService;
	}

	ssAPIOutput Jab.IServiceProvider<ssAPIOutput>.GetService()
	{
		if (_ssAPIOutput == null)
		{
			lock (this)
			{
				if (_ssAPIOutput == null)
				{
					_ssAPIOutput = new ssAPIOutput(GetService<IProCoreInstance>(), GetService<IFlagService>());
				}
			}
		}
		return _ssAPIOutput;
	}

	ITransitionDescriptionCollection Jab.IServiceProvider<ITransitionDescriptionCollection>.GetService()
	{
		ITransitionDescriptionCollection transitionDescriptionCollection = IControllerServiceProviderModule.GetTransitionDescriptionCollection(GetService<ssAPIOutput>());
		TryAddDisposable(transitionDescriptionCollection);
		return transitionDescriptionCollection;
	}

	IImageLoader Jab.IServiceProvider<IImageLoader>.GetService()
	{
		ImageLoader imageLoader = new ImageLoader();
		TryAddDisposable(imageLoader);
		return imageLoader;
	}

	IMediaMetadataCacheRepository Jab.IServiceProvider<IMediaMetadataCacheRepository>.GetService()
	{
		if (_IMediaMetadataCacheRepository == null)
		{
			lock (this)
			{
				if (_IMediaMetadataCacheRepository == null)
				{
					_IMediaMetadataCacheRepository = new MediaMetadataCacheRepository();
				}
			}
		}
		return _IMediaMetadataCacheRepository;
	}

	IMediaMetadataCacheService Jab.IServiceProvider<IMediaMetadataCacheService>.GetService()
	{
		if (_IMediaMetadataCacheService == null)
		{
			lock (this)
			{
				if (_IMediaMetadataCacheService == null)
				{
					_IMediaMetadataCacheService = new MediaMetadataCache(GetService<IMediaMetadataCacheRepository>());
				}
			}
		}
		return _IMediaMetadataCacheService;
	}

	IAsyncExecutor Jab.IServiceProvider<IAsyncExecutor>.GetService()
	{
		AsyncExecutor asyncExecutor = new AsyncExecutor();
		TryAddDisposable(asyncExecutor);
		return asyncExecutor;
	}

	IUiScheduler Jab.IServiceProvider<IUiScheduler>.GetService()
	{
		IUiScheduler dispatcher = GetDispatcher();
		TryAddDisposable(dispatcher);
		return dispatcher;
	}

	IMetadataLoader Jab.IServiceProvider<IMetadataLoader>.GetService()
	{
		if (_IMetadataLoader == null)
		{
			lock (this)
			{
				if (_IMetadataLoader == null)
				{
					_IMetadataLoader = GetMetadataLoader(GetService<IFlagService>(), GetService<IImageLoader>(), GetService<IMediaMetadataCacheService>(), GetService<IAsyncExecutor>(), GetService<IFileService>(), GetService<ILogger>(), GetService<IUiScheduler>());
				}
			}
		}
		return _IMetadataLoader;
	}

	ITrackedMediaHelpers Jab.IServiceProvider<ITrackedMediaHelpers>.GetService()
	{
		ITrackedMediaHelpers trackedMediaHelpers = GetTrackedMediaHelpers(GetService<IFlagService>(), GetService<IAsyncExecutor>());
		TryAddDisposable(trackedMediaHelpers);
		return trackedMediaHelpers;
	}

	IAssemblyInfoProvider Jab.IServiceProvider<IAssemblyInfoProvider>.GetService()
	{
		if (_IAssemblyInfoProvider == null)
		{
			lock (this)
			{
				if (_IAssemblyInfoProvider == null)
				{
					_IAssemblyInfoProvider = IGlobalServiceProviderModule.GetAssemblyProvider();
				}
			}
		}
		return _IAssemblyInfoProvider;
	}

	private System.Version GetVersion_OSVersion()
	{
		if (_Version_OSVersion == null)
		{
			lock (this)
			{
				if (_Version_OSVersion == null)
				{
					_Version_OSVersion = IGlobalServiceProviderModule.GetOsVersion();
				}
			}
		}
		return _Version_OSVersion;
	}

	IVersionInfoProvider Jab.IServiceProvider<IVersionInfoProvider>.GetService()
	{
		if (_IVersionInfoProvider == null)
		{
			lock (this)
			{
				if (_IVersionInfoProvider == null)
				{
					_IVersionInfoProvider = IGlobalServiceProviderModule.GetVersionInfoProvider(GetService<IAssemblyInfoProvider>(), GetVersion_OSVersion());
				}
			}
		}
		return _IVersionInfoProvider;
	}

	IRestClientFactory Jab.IServiceProvider<IRestClientFactory>.GetService()
	{
		if (_IRestClientFactory == null)
		{
			lock (this)
			{
				if (_IRestClientFactory == null)
				{
					_IRestClientFactory = IGlobalServiceProviderModule.GetRestClientFactory(GetService<IVersionInfoProvider>(), GetService<IApp>());
				}
			}
		}
		return _IRestClientFactory;
	}

	ISemaphoreFactory Jab.IServiceProvider<ISemaphoreFactory>.GetService()
	{
		SemaphoreFactory semaphoreFactory = new SemaphoreFactory();
		TryAddDisposable(semaphoreFactory);
		return semaphoreFactory;
	}

	ICurrentTime Jab.IServiceProvider<ICurrentTime>.GetService()
	{
		CurrentTime currentTime = new CurrentTime();
		TryAddDisposable(currentTime);
		return currentTime;
	}

	IFileSystemUriCacheServiceFactory Jab.IServiceProvider<IFileSystemUriCacheServiceFactory>.GetService()
	{
		if (_IFileSystemUriCacheServiceFactory == null)
		{
			lock (this)
			{
				if (_IFileSystemUriCacheServiceFactory == null)
				{
					_IFileSystemUriCacheServiceFactory = new FileSystemUriCacheServiceFactory(GetService<IRestClientFactory>(), GetService<ILogger>(), GetService<IFileSystem>(), GetService<IAsyncExecutor>(), GetService<ISemaphoreFactory>(), GetService<ICurrentTime>());
				}
			}
		}
		return _IFileSystemUriCacheServiceFactory;
	}

	IImageDecoder Jab.IServiceProvider<IImageDecoder>.GetService()
	{
		ImageDecoder imageDecoder = new ImageDecoder();
		TryAddDisposable(imageDecoder);
		return imageDecoder;
	}

	IBitmapImageDecoder Jab.IServiceProvider<IBitmapImageDecoder>.GetService()
	{
		BitmapImageDecoder bitmapImageDecoder = new BitmapImageDecoder(GetService<IImageDecoder>());
		TryAddDisposable(bitmapImageDecoder);
		return bitmapImageDecoder;
	}

	IUriCacheService<NullableBitmapSource> Jab.IServiceProvider<IUriCacheService<NullableBitmapSource>>.GetService()
	{
		if (_IUriCacheService_NullableBitmapSource == null)
		{
			lock (this)
			{
				if (_IUriCacheService_NullableBitmapSource == null)
				{
					_IUriCacheService_NullableBitmapSource = new UrlBitmapThumbnailCacheService(GetService<IFileSystemUriCacheServiceFactory>(), GetService<ILogger>(), GetService<IBitmapImageDecoder>(), GetService<IAsyncExecutor>());
				}
			}
		}
		return _IUriCacheService_NullableBitmapSource;
	}

	ICurrentTimeOffset Jab.IServiceProvider<ICurrentTimeOffset>.GetService()
	{
		CurrentTimeOffset currentTimeOffset = new CurrentTimeOffset();
		TryAddDisposable(currentTimeOffset);
		return currentTimeOffset;
	}

	IAuthenticatingApiConsumerFactory Jab.IServiceProvider<IAuthenticatingApiConsumerFactory>.GetService()
	{
		AuthenticatingApiConsumerFactory authenticatingApiConsumerFactory = new AuthenticatingApiConsumerFactory(GetService<IRestClientFactory>(), GetService<ICurrentTimeOffset>(), GetService<ILogger>());
		TryAddDisposable(authenticatingApiConsumerFactory);
		return authenticatingApiConsumerFactory;
	}

	IApiService Jab.IServiceProvider<IApiService>.GetService()
	{
		ApiService apiService = new ApiService(GetService<IFlagService>());
		TryAddDisposable(apiService);
		return apiService;
	}

	IRegistrationUserDialogService Jab.IServiceProvider<IRegistrationUserDialogService>.GetService()
	{
		if (_IRegistrationUserDialogService == null)
		{
			lock (this)
			{
				if (_IRegistrationUserDialogService == null)
				{
					_IRegistrationUserDialogService = new RegistrationUserDialogService(GetService<IUiDispatcher>());
				}
			}
		}
		return _IRegistrationUserDialogService;
	}

	IApplicationExceptionFactory Jab.IServiceProvider<IApplicationExceptionFactory>.GetService()
	{
		ApplicationExceptionFactory applicationExceptionFactory = new ApplicationExceptionFactory();
		TryAddDisposable(applicationExceptionFactory);
		return applicationExceptionFactory;
	}

	IErrorPublisher Jab.IServiceProvider<IErrorPublisher>.GetService()
	{
		if (_IErrorPublisher == null)
		{
			lock (this)
			{
				if (_IErrorPublisher == null)
				{
					_IErrorPublisher = new HandledErrorReporter();
				}
			}
		}
		return _IErrorPublisher;
	}

	IErrorReporter Jab.IServiceProvider<IErrorReporter>.GetService()
	{
		ErrorReporter errorReporter = new ErrorReporter(GetService<ILogger>(), GetService<IErrorPublisher>());
		TryAddDisposable(errorReporter);
		return errorReporter;
	}

	ICoreApplication Jab.IServiceProvider<ICoreApplication>.GetService()
	{
		if (_ICoreApplication == null)
		{
			lock (this)
			{
				if (_ICoreApplication == null)
				{
					_ICoreApplication = new CoreApplication(GetService<ILogger>(), GetService<IAsyncExecutor>(), GetService<IApplicationExceptionFactory>(), GetService<IErrorReporter>());
				}
			}
		}
		return _ICoreApplication;
	}

	IRegistrationCallbackHandler Jab.IServiceProvider<IRegistrationCallbackHandler>.GetService()
	{
		if (_IRegistrationCallbackHandler == null)
		{
			lock (this)
			{
				if (_IRegistrationCallbackHandler == null)
				{
					_IRegistrationCallbackHandler = IRegistrationServiceProviderModule.GetNotificationDataStoreHandler(GetService<ILogger>(), GetService<IFileSystem>(), GetService<IApp>(), GetService<IErrorReporter>());
				}
			}
		}
		return _IRegistrationCallbackHandler;
	}

	NotificationCallbackHandler Jab.IServiceProvider<NotificationCallbackHandler>.GetService()
	{
		if (_NotificationCallbackHandler == null)
		{
			lock (this)
			{
				if (_NotificationCallbackHandler == null)
				{
					_NotificationCallbackHandler = new NotificationCallbackHandler();
				}
			}
		}
		return _NotificationCallbackHandler;
	}

	private IRegistrationCallbackHandler GetIRegistrationCallbackHandler_1()
	{
		IRegistrationCallbackHandler notificationCallbackHandler = IRegistrationServiceProviderModule.GetNotificationCallbackHandler(GetService<NotificationCallbackHandler>());
		TryAddDisposable(notificationCallbackHandler);
		return notificationCallbackHandler;
	}

	ProContentClientInformationProvider Jab.IServiceProvider<ProContentClientInformationProvider>.GetService()
	{
		if (_ProContentClientInformationProvider == null)
		{
			lock (this)
			{
				if (_ProContentClientInformationProvider == null)
				{
					_ProContentClientInformationProvider = new ProContentClientInformationProvider();
				}
			}
		}
		return _ProContentClientInformationProvider;
	}

	private IRegistrationCallbackHandler GetIRegistrationCallbackHandler_2()
	{
		IRegistrationCallbackHandler proContentClientInformationProvider = IRegistrationServiceProviderModule.GetProContentClientInformationProvider(GetService<ProContentClientInformationProvider>());
		TryAddDisposable(proContentClientInformationProvider);
		return proContentClientInformationProvider;
	}

	IInternetAccess Jab.IServiceProvider<IInternetAccess>.GetService()
	{
		if (_IInternetAccess == null)
		{
			lock (this)
			{
				if (_IInternetAccess == null)
				{
					_IInternetAccess = IGlobalServiceProviderModule.GetInternetAccessCheck(GetService<ILocalization>());
				}
			}
		}
		return _IInternetAccess;
	}

	IHyperlinkService Jab.IServiceProvider<IHyperlinkService>.GetService()
	{
		HyperlinkService hyperlinkService = new HyperlinkService(GetService<ILogger>(), GetService<IFlagService>(), GetService<IInternetAccess>());
		TryAddDisposable(hyperlinkService);
		return hyperlinkService;
	}

	JsonWebTokenHandler Jab.IServiceProvider<JsonWebTokenHandler>.GetService()
	{
		if (_JsonWebTokenHandler == null)
		{
			lock (this)
			{
				if (_JsonWebTokenHandler == null)
				{
					_JsonWebTokenHandler = new JsonWebTokenHandler();
				}
			}
		}
		return _JsonWebTokenHandler;
	}

	RegistrationStateHandler Jab.IServiceProvider<RegistrationStateHandler>.GetService()
	{
		if (_RegistrationStateHandler == null)
		{
			lock (this)
			{
				if (_RegistrationStateHandler == null)
				{
					_RegistrationStateHandler = GetRegistrationStateHandler(GetService<IVersionInfoProvider>(), GetService<JsonWebTokenHandler>());
				}
			}
		}
		return _RegistrationStateHandler;
	}

	IRegistrationStateProvider Jab.IServiceProvider<IRegistrationStateProvider>.GetService()
	{
		IRegistrationStateProvider registrationStateHandler = IRegistrationServiceProviderModule.GetRegistrationStateHandler(GetService<RegistrationStateHandler>());
		TryAddDisposable(registrationStateHandler);
		return registrationStateHandler;
	}

	IActivationKeyProvider Jab.IServiceProvider<IActivationKeyProvider>.GetService()
	{
		ActivationKeyProvider activationKeyProvider = new ActivationKeyProvider(GetService<IRegistrationStateProvider>());
		TryAddDisposable(activationKeyProvider);
		return activationKeyProvider;
	}

	IRegistrationWebResourceService Jab.IServiceProvider<IRegistrationWebResourceService>.GetService()
	{
		RegistrationWebResourceService registrationWebResourceService = new RegistrationWebResourceService(GetService<IApiService>(), GetService<IVersionInfoProvider>(), GetService<IActivationKeyProvider>());
		TryAddDisposable(registrationWebResourceService);
		return registrationWebResourceService;
	}

	IPopUpAlertFactory Jab.IServiceProvider<IPopUpAlertFactory>.GetService()
	{
		PopUpAlertFactory popUpAlertFactory = new PopUpAlertFactory(GetService<IUiDispatcher>(), GetService<IHyperlinkService>(), GetService<IRegistrationWebResourceService>());
		TryAddDisposable(popUpAlertFactory);
		return popUpAlertFactory;
	}

	IAfterStartupCompleteQueue Jab.IServiceProvider<IAfterStartupCompleteQueue>.GetService()
	{
		if (_IAfterStartupCompleteQueue == null)
		{
			lock (this)
			{
				if (_IAfterStartupCompleteQueue == null)
				{
					_IAfterStartupCompleteQueue = new AfterStartupCompleteQueue();
				}
			}
		}
		return _IAfterStartupCompleteQueue;
	}

	UserMessageHandler Jab.IServiceProvider<UserMessageHandler>.GetService()
	{
		if (_UserMessageHandler == null)
		{
			lock (this)
			{
				if (_UserMessageHandler == null)
				{
					_UserMessageHandler = new UserMessageHandler(GetService<IPopUpAlertFactory>(), GetService<IAfterStartupCompleteQueue>());
				}
			}
		}
		return _UserMessageHandler;
	}

	private IRegistrationCallbackHandler GetIRegistrationCallbackHandler_3()
	{
		IRegistrationCallbackHandler userMessageHandler = IRegistrationServiceProviderModule.GetUserMessageHandler(GetService<UserMessageHandler>());
		TryAddDisposable(userMessageHandler);
		return userMessageHandler;
	}

	Func<IMainLayoutVM> Jab.IServiceProvider<Func<IMainLayoutVM>>.GetService()
	{
		Func<IMainLayoutVM> mainLayoutVmGetter = GetMainLayoutVmGetter();
		TryAddDisposable(mainLayoutVmGetter);
		return mainLayoutVmGetter;
	}

	private System.Action GetAction_ShowRegistrationSettingsKey()
	{
		System.Action showRegistrationSettings = GetShowRegistrationSettings(GetService<Func<IMainLayoutVM>>());
		TryAddDisposable(showRegistrationSettings);
		return showRegistrationSettings;
	}

	IWebSourceProvider Jab.IServiceProvider<IWebSourceProvider>.GetService()
	{
		WebSourceProvider webSourceProvider = new WebSourceProvider(GetService<IRegistrationStateProvider>(), GetService<IApiService>());
		TryAddDisposable(webSourceProvider);
		return webSourceProvider;
	}

	IRegistrationCallbackDialogProvider Jab.IServiceProvider<IRegistrationCallbackDialogProvider>.GetService()
	{
		IRegistrationCallbackDialogProvider registrationCallbackDialogProvider = IRegistrationServiceProviderModule.GetRegistrationCallbackDialogProvider(GetService<IUiDispatcher>(), GetService<ICurrentTime>(), GetAction_ShowRegistrationSettingsKey(), GetService<IAfterStartupCompleteQueue>(), GetService<IWebSourceProvider>());
		TryAddDisposable(registrationCallbackDialogProvider);
		return registrationCallbackDialogProvider;
	}

	private IRegistrationCallbackHandler GetIRegistrationCallbackHandler_4()
	{
		if (_IRegistrationCallbackHandler_4 == null)
		{
			lock (this)
			{
				if (_IRegistrationCallbackHandler_4 == null)
				{
					_IRegistrationCallbackHandler_4 = new UserAlertHandler(GetService<IRegistrationCallbackDialogProvider>(), GetService<IHyperlinkService>(), GetService<IRegistrationWebResourceService>());
				}
			}
		}
		return _IRegistrationCallbackHandler_4;
	}

	private IRegistrationCallbackHandler GetIRegistrationCallbackHandler_5()
	{
		if (_IRegistrationCallbackHandler_5 == null)
		{
			lock (this)
			{
				if (_IRegistrationCallbackHandler_5 == null)
				{
					_IRegistrationCallbackHandler_5 = new GetProductInformationHandler(GetService<IVersionInfoProvider>());
				}
			}
		}
		return _IRegistrationCallbackHandler_5;
	}

	private IRegistrationCallbackHandler GetIRegistrationCallbackHandler_6()
	{
		if (_IRegistrationCallbackHandler_6 == null)
		{
			lock (this)
			{
				if (_IRegistrationCallbackHandler_6 == null)
				{
					_IRegistrationCallbackHandler_6 = new LogHandler(GetService<ILogger>());
				}
			}
		}
		return _IRegistrationCallbackHandler_6;
	}

	IEmbeddedResourceReader Jab.IServiceProvider<IEmbeddedResourceReader>.GetService()
	{
		EmbeddedResourceReader embeddedResourceReader = new EmbeddedResourceReader();
		TryAddDisposable(embeddedResourceReader);
		return embeddedResourceReader;
	}

	IForceQuitEventPublisher Jab.IServiceProvider<IForceQuitEventPublisher>.GetService()
	{
		ForceQuitEventPublisher forceQuitEventPublisher = new ForceQuitEventPublisher();
		TryAddDisposable(forceQuitEventPublisher);
		return forceQuitEventPublisher;
	}

	IForcedShutdownMessageProvider Jab.IServiceProvider<IForcedShutdownMessageProvider>.GetService()
	{
		ForcedShutdownMessageProvider forcedShutdownMessageProvider = new ForcedShutdownMessageProvider(GetService<IUiDispatcher>(), GetService<IMessageService>(), GetService<IForceQuitEventPublisher>());
		TryAddDisposable(forcedShutdownMessageProvider);
		return forcedShutdownMessageProvider;
	}

	private IRegistrationCallbackHandler GetIRegistrationCallbackHandler_7()
	{
		if (_IRegistrationCallbackHandler_7 == null)
		{
			lock (this)
			{
				if (_IRegistrationCallbackHandler_7 == null)
				{
					_IRegistrationCallbackHandler_7 = new WatermarkHandler(GetService<IEmbeddedResourceReader>(), GetService<IProCoreInstance>(), GetService<ILogger>(), GetService<IForcedShutdownMessageProvider>());
				}
			}
		}
		return _IRegistrationCallbackHandler_7;
	}

	private IRegistrationCallbackHandler GetIRegistrationCallbackHandler_8()
	{
		if (_IRegistrationCallbackHandler_8 == null)
		{
			lock (this)
			{
				if (_IRegistrationCallbackHandler_8 == null)
				{
					_IRegistrationCallbackHandler_8 = IRegistrationServiceProviderModule.GetRegistrationDataStorageHandler(GetService<ILogger>(), GetService<IFileSystem>(), GetService<IApp>(), GetService<IErrorReporter>());
				}
			}
		}
		return _IRegistrationCallbackHandler_8;
	}

	private IRegistrationCallbackHandler GetIRegistrationCallbackHandler_9()
	{
		if (_IRegistrationCallbackHandler_9 == null)
		{
			lock (this)
			{
				if (_IRegistrationCallbackHandler_9 == null)
				{
					_IRegistrationCallbackHandler_9 = new ProContentTokenReader(GetService<IApp>());
				}
			}
		}
		return _IRegistrationCallbackHandler_9;
	}

	private IRegistrationCallbackHandler GetIRegistrationCallbackHandler_10()
	{
		if (_IRegistrationCallbackHandler_10 == null)
		{
			lock (this)
			{
				if (_IRegistrationCallbackHandler_10 == null)
				{
					_IRegistrationCallbackHandler_10 = new HardExitHandler(GetService<IForcedShutdownMessageProvider>());
				}
			}
		}
		return _IRegistrationCallbackHandler_10;
	}

	IInternetAccessCheck Jab.IServiceProvider<IInternetAccessCheck>.GetService()
	{
		if (_IInternetAccessCheck == null)
		{
			lock (this)
			{
				if (_IInternetAccessCheck == null)
				{
					_IInternetAccessCheck = new InternetAccessCheckService(GetService<IMessageService>(), GetService<IInternetAccess>(), GetService<IUiDispatcher>());
				}
			}
		}
		return _IInternetAccessCheck;
	}

	private IRegistrationCallbackHandler GetIRegistrationCallbackHandler_11()
	{
		if (_IRegistrationCallbackHandler_11 == null)
		{
			lock (this)
			{
				if (_IRegistrationCallbackHandler_11 == null)
				{
					_IRegistrationCallbackHandler_11 = new ExpirationDialogHandler(GetService<IRegistrationCallbackDialogProvider>(), GetService<IApp>(), GetService<IInternetAccessCheck>());
				}
			}
		}
		return _IRegistrationCallbackHandler_11;
	}

	private IRegistrationCallbackHandler GetIRegistrationCallbackHandler_12()
	{
		IRegistrationCallbackHandler registrationStateHandler = IRegistrationServiceProviderModule.GetRegistrationStateHandler(GetService<RegistrationStateHandler>());
		TryAddDisposable(registrationStateHandler);
		return registrationStateHandler;
	}

	IEnumerable<IRegistrationCallbackHandler> Jab.IServiceProvider<IEnumerable<IRegistrationCallbackHandler>>.GetService()
	{
		return new IRegistrationCallbackHandler[13]
		{
			GetIRegistrationCallbackHandler_12(),
			GetIRegistrationCallbackHandler_11(),
			GetIRegistrationCallbackHandler_10(),
			GetIRegistrationCallbackHandler_9(),
			GetIRegistrationCallbackHandler_8(),
			GetIRegistrationCallbackHandler_7(),
			GetIRegistrationCallbackHandler_6(),
			GetIRegistrationCallbackHandler_5(),
			GetIRegistrationCallbackHandler_4(),
			GetIRegistrationCallbackHandler_3(),
			GetIRegistrationCallbackHandler_2(),
			GetIRegistrationCallbackHandler_1(),
			GetService<IRegistrationCallbackHandler>()
		};
	}

	RegistrationClient Jab.IServiceProvider<RegistrationClient>.GetService()
	{
		if (_RegistrationClient == null)
		{
			lock (this)
			{
				if (_RegistrationClient == null)
				{
					_RegistrationClient = new RegistrationClient(GetService<ICoreApplication>(), GetService<ILogger>(), GetService<IFlagService>(), GetService<IErrorReporter>(), GetService<IAsyncExecutor>(), GetService<IEnumerable<IRegistrationCallbackHandler>>());
				}
			}
		}
		return _RegistrationClient;
	}

	IRegistrationClient Jab.IServiceProvider<IRegistrationClient>.GetService()
	{
		IRegistrationClient registrationClient = IRegistrationServiceProviderModule.GetRegistrationClient(GetService<RegistrationClient>());
		TryAddDisposable(registrationClient);
		return registrationClient;
	}

	IRegistrationOperationFactory Jab.IServiceProvider<IRegistrationOperationFactory>.GetService()
	{
		if (_IRegistrationOperationFactory == null)
		{
			lock (this)
			{
				if (_IRegistrationOperationFactory == null)
				{
					_IRegistrationOperationFactory = new RegistrationOperationFactory(GetService<IRegistrationUserDialogService>(), GetService<IRegistrationClient>(), GetService<IApp>(), GetService<ICurrentTime>(), GetService<IVersionInfoProvider>());
				}
			}
		}
		return _IRegistrationOperationFactory;
	}

	private IOAuth2AuthorizationStore GetIOAuth2AuthorizationStore_ProContentRegistrationAuthorizationStorageKey()
	{
		if (_IOAuth2AuthorizationStore_ProContentRegistrationAuthorizationStorageKey == null)
		{
			lock (this)
			{
				if (_IOAuth2AuthorizationStore_ProContentRegistrationAuthorizationStorageKey == null)
				{
					_IOAuth2AuthorizationStore_ProContentRegistrationAuthorizationStorageKey = new ProContentRegistrationAuthorizationStorage(GetService<IRegistrationOperationFactory>(), GetService<IRegistrationStateProvider>());
				}
			}
		}
		return _IOAuth2AuthorizationStore_ProContentRegistrationAuthorizationStorageKey;
	}

	private IOAuth2ClientInfoProvider GetIOAuth2ClientInfoProvider_ProContentRegistrationAuthorizationInfoProviderKey()
	{
		IOAuth2ClientInfoProvider proContentClientInformationProvider = IRegistrationServiceProviderModule.GetProContentClientInformationProvider(GetService<ProContentClientInformationProvider>());
		TryAddDisposable(proContentClientInformationProvider);
		return proContentClientInformationProvider;
	}

	IProContentConsumer Jab.IServiceProvider<IProContentConsumer>.GetService()
	{
		if (_IProContentConsumer == null)
		{
			lock (this)
			{
				if (_IProContentConsumer == null)
				{
					_IProContentConsumer = GetProContentConsumer(GetService<IAuthenticatingApiConsumerFactory>(), GetService<IApp>(), GetService<ILogger>(), GetService<IApiService>(), GetService<IFlagService>(), GetIOAuth2AuthorizationStore_ProContentRegistrationAuthorizationStorageKey(), GetIOAuth2ClientInfoProvider_ProContentRegistrationAuthorizationInfoProviderKey());
				}
			}
		}
		return _IProContentConsumer;
	}

	IProContentDownloadFailedDialogService Jab.IServiceProvider<IProContentDownloadFailedDialogService>.GetService()
	{
		ProContentDownloadFailedDialogService proContentDownloadFailedDialogService = new ProContentDownloadFailedDialogService(GetService<ILocalization>(), GetService<IRegistrationWebResourceService>(), GetService<IHyperlinkService>());
		TryAddDisposable(proContentDownloadFailedDialogService);
		return proContentDownloadFailedDialogService;
	}

	IProContentUserInteractionBehavior Jab.IServiceProvider<IProContentUserInteractionBehavior>.GetService()
	{
		ProContentUserInteractionBehavior proContentUserInteractionBehavior = new ProContentUserInteractionBehavior(GetService<IProContentConsumer>(), GetService<IInternetAccessCheck>(), GetService<IProContentDownloadFailedDialogService>(), GetService<IRegistrationWebResourceService>(), GetService<IHyperlinkService>());
		TryAddDisposable(proContentUserInteractionBehavior);
		return proContentUserInteractionBehavior;
	}

	IDelayFactory Jab.IServiceProvider<IDelayFactory>.GetService()
	{
		DelayFactory delayFactory = new DelayFactory();
		TryAddDisposable(delayFactory);
		return delayFactory;
	}

	IDownloadProcessFactory Jab.IServiceProvider<IDownloadProcessFactory>.GetService()
	{
		DownloadProcessFactory downloadProcessFactory = new DownloadProcessFactory(GetService<ILogger>(), GetService<IFileSystem>(), GetService<IRestClientFactory>(), GetService<IDelayFactory>());
		TryAddDisposable(downloadProcessFactory);
		return downloadProcessFactory;
	}

	IDownloadItemFactory Jab.IServiceProvider<IDownloadItemFactory>.GetService()
	{
		DownloadItemFactory downloadItemFactory = new DownloadItemFactory(GetService<IDownloadProcessFactory>(), GetService<IFileService>(), GetService<IFileSystem>());
		TryAddDisposable(downloadItemFactory);
		return downloadItemFactory;
	}

	IProContentAnalyticEventsPublisher Jab.IServiceProvider<IProContentAnalyticEventsPublisher>.GetService()
	{
		ProContentAnalyticEventsPublisher proContentAnalyticEventsPublisher = new ProContentAnalyticEventsPublisher();
		TryAddDisposable(proContentAnalyticEventsPublisher);
		return proContentAnalyticEventsPublisher;
	}

	IDownloadManager Jab.IServiceProvider<IDownloadManager>.GetService()
	{
		if (_IDownloadManager == null)
		{
			lock (this)
			{
				if (_IDownloadManager == null)
				{
					_IDownloadManager = new DownloadManager(GetService<IAsyncExecutor>());
				}
			}
		}
		return _IDownloadManager;
	}

	IUnObservedProContentDownloadProcessFactory Jab.IServiceProvider<IUnObservedProContentDownloadProcessFactory>.GetService()
	{
		UnObservedProContentDownloadProcessFactory unObservedProContentDownloadProcessFactory = new UnObservedProContentDownloadProcessFactory(GetService<IDownloadItemFactory>(), GetService<IProContentConsumer>(), GetService<IProPresenterResourceService>(), GetService<IApp>(), GetService<IProContentDownloadFailedDialogService>(), GetService<IProContentAnalyticEventsPublisher>(), GetService<IDownloadManager>());
		TryAddDisposable(unObservedProContentDownloadProcessFactory);
		return unObservedProContentDownloadProcessFactory;
	}

	IProContentAssetProvider Jab.IServiceProvider<IProContentAssetProvider>.GetService()
	{
		if (_IProContentAssetProvider == null)
		{
			lock (this)
			{
				if (_IProContentAssetProvider == null)
				{
					_IProContentAssetProvider = new ProContentAssetProvider(GetService<IProContentConsumer>(), GetService<IProContentUserInteractionBehavior>(), GetService<IUnObservedProContentDownloadProcessFactory>());
				}
			}
		}
		return _IProContentAssetProvider;
	}

	IRemoteFileLoader Jab.IServiceProvider<IRemoteFileLoader>.GetService()
	{
		RemoteFileLoader remoteFileLoader = new RemoteFileLoader(GetService<IUriCacheService<NullableBitmapSource>>(), GetService<IProContentAssetProvider>());
		TryAddDisposable(remoteFileLoader);
		return remoteFileLoader;
	}

	IAudioOutputDeviceCollection Jab.IServiceProvider<IAudioOutputDeviceCollection>.GetService()
	{
		IAudioOutputDeviceCollection audioOutputDeviceCollection = IControllerServiceProviderModule.GetAudioOutputDeviceCollection(GetService<ssAPIOutput>());
		TryAddDisposable(audioOutputDeviceCollection);
		return audioOutputDeviceCollection;
	}

	IAudioSetup Jab.IServiceProvider<IAudioSetup>.GetService()
	{
		if (_IAudioSetup == null)
		{
			lock (this)
			{
				if (_IAudioSetup == null)
				{
					_IAudioSetup = new AudioSetup(GetService<IAudioOutputDeviceCollection>());
				}
			}
		}
		return _IAudioSetup;
	}

	IAudioMapRecallService<DeviceChannel, Bus> Jab.IServiceProvider<IAudioMapRecallService<DeviceChannel, Bus>>.GetService()
	{
		if (_IAudioMapRecallService_DeviceChannelBus == null)
		{
			lock (this)
			{
				if (_IAudioMapRecallService_DeviceChannelBus == null)
				{
					_IAudioMapRecallService_DeviceChannelBus = IProDOServiceProviderModule.CreateAudioMapRecallService();
				}
			}
		}
		return _IAudioMapRecallService_DeviceChannelBus;
	}

	ILiveVideoInputCollection Jab.IServiceProvider<ILiveVideoInputCollection>.GetService()
	{
		if (_ILiveVideoInputCollection == null)
		{
			lock (this)
			{
				if (_ILiveVideoInputCollection == null)
				{
					_ILiveVideoInputCollection = new LiveVideoInputCollection(GetService<IAudioSetup>(), GetService<IAudioMapRecallService<DeviceChannel, Bus>>());
				}
			}
		}
		return _ILiveVideoInputCollection;
	}

	IMediaFactory Jab.IServiceProvider<IMediaFactory>.GetService()
	{
		IMediaFactory mediaFactory = IGlobalServiceProviderModule.GetMediaFactory(GetService<IMetadataLoader>(), GetService<IAsyncExecutor>(), GetService<ITrackedMediaHelpers>(), GetService<IRemoteFileLoader>(), GetService<ILiveVideoInputCollection>(), GetService<IAudioSetup>(), GetService<IFlagService>(), GetService<ssAPIOutput>());
		TryAddDisposable(mediaFactory);
		return mediaFactory;
	}

	ITextFillMediaFactory Jab.IServiceProvider<ITextFillMediaFactory>.GetService()
	{
		TextFillMediaFactory textFillMediaFactory = new TextFillMediaFactory(GetService<IMediaFactory>());
		TryAddDisposable(textFillMediaFactory);
		return textFillMediaFactory;
	}

	ITextDocumentFactory Jab.IServiceProvider<ITextDocumentFactory>.GetService()
	{
		if (_ITextDocumentFactory == null)
		{
			lock (this)
			{
				if (_ITextDocumentFactory == null)
				{
					_ITextDocumentFactory = new TextDocumentFactory(GetService<ITextFillMediaFactory>());
				}
			}
		}
		return _ITextDocumentFactory;
	}

	IEntityFactory Jab.IServiceProvider<IEntityFactory>.GetService()
	{
		if (_IEntityFactory == null)
		{
			lock (this)
			{
				if (_IEntityFactory == null)
				{
					_IEntityFactory = new EntityFactory();
				}
			}
		}
		return _IEntityFactory;
	}

	IDocumentFactory Jab.IServiceProvider<IDocumentFactory>.GetService()
	{
		if (_IDocumentFactory == null)
		{
			lock (this)
			{
				if (_IDocumentFactory == null)
				{
					_IDocumentFactory = new DocumentFactory();
				}
			}
		}
		return _IDocumentFactory;
	}

	IDocumentService Jab.IServiceProvider<IDocumentService>.GetService()
	{
		if (_IDocumentService == null)
		{
			lock (this)
			{
				if (_IDocumentService == null)
				{
					_IDocumentService = new DocumentService(GetService<ICoreApplication>(), GetService<ILogger>());
				}
			}
		}
		return _IDocumentService;
	}

	IEntityFileLockFactory Jab.IServiceProvider<IEntityFileLockFactory>.GetService()
	{
		if (_IEntityFileLockFactory == null)
		{
			lock (this)
			{
				if (_IEntityFileLockFactory == null)
				{
					_IEntityFileLockFactory = new EntityFileLockFactory();
				}
			}
		}
		return _IEntityFileLockFactory;
	}

	ICommonPathsWrapper Jab.IServiceProvider<ICommonPathsWrapper>.GetService()
	{
		if (_ICommonPathsWrapper == null)
		{
			lock (this)
			{
				if (_ICommonPathsWrapper == null)
				{
					_ICommonPathsWrapper = new CommonPathsWrapper();
				}
			}
		}
		return _ICommonPathsWrapper;
	}

	ICollaborationPeerIdProvider Jab.IServiceProvider<ICollaborationPeerIdProvider>.GetService()
	{
		ICollaborationPeerIdProvider app = IGlobalServiceProviderModule.GetApp(GetService<IApp>());
		TryAddDisposable(app);
		return app;
	}

	IThreadPoolScheduler Jab.IServiceProvider<IThreadPoolScheduler>.GetService()
	{
		ThreadPoolScheduler threadPoolScheduler = new ThreadPoolScheduler();
		TryAddDisposable(threadPoolScheduler);
		return threadPoolScheduler;
	}

	IMediaService Jab.IServiceProvider<IMediaService>.GetService()
	{
		if (_IMediaService == null)
		{
			lock (this)
			{
				if (_IMediaService == null)
				{
					_IMediaService = GetMediaService(GetService<IFlagService>());
				}
			}
		}
		return _IMediaService;
	}

	ILocalWorkspaceStatsEventPublisher Jab.IServiceProvider<ILocalWorkspaceStatsEventPublisher>.GetService()
	{
		LocalWorkspaceStatsEventPublisher localWorkspaceStatsEventPublisher = new LocalWorkspaceStatsEventPublisher();
		TryAddDisposable(localWorkspaceStatsEventPublisher);
		return localWorkspaceStatsEventPublisher;
	}

	IZipHelper Jab.IServiceProvider<IZipHelper>.GetService()
	{
		ZipHelperImpl zipHelperImpl = new ZipHelperImpl();
		TryAddDisposable(zipHelperImpl);
		return zipHelperImpl;
	}

	IWorkspaceService Jab.IServiceProvider<IWorkspaceService>.GetService()
	{
		if (_IWorkspaceService == null)
		{
			lock (this)
			{
				if (_IWorkspaceService == null)
				{
					_IWorkspaceService = new WorkspaceService(GetService<ICommonPathsWrapper>(), GetService<IMediaService>(), GetService<ILocalWorkspaceStatsEventPublisher>(), GetService<IMessageService>(), GetService<IFileSystem>(), GetService<IZipHelper>());
				}
			}
		}
		return _IWorkspaceService;
	}

	ICloudDiagnosticsPublisher Jab.IServiceProvider<ICloudDiagnosticsPublisher>.GetService()
	{
		if (_ICloudDiagnosticsPublisher == null)
		{
			lock (this)
			{
				if (_ICloudDiagnosticsPublisher == null)
				{
					_ICloudDiagnosticsPublisher = IProPresenterDOServiceProviderModule.CreateCloudDiagnosticsPublisher(GetService<IFlagService>(), GetService<ICollaborationPeerIdProvider>(), GetService<IWorkspaceService>());
				}
			}
		}
		return _ICloudDiagnosticsPublisher;
	}

	IEntityDocumentRegistry Jab.IServiceProvider<IEntityDocumentRegistry>.GetService()
	{
		if (_IEntityDocumentRegistry == null)
		{
			lock (this)
			{
				if (_IEntityDocumentRegistry == null)
				{
					_IEntityDocumentRegistry = IDataServiceProviderModule.GetDocumentUpdateProvider(GetService<IDocumentService>(), GetService<IAsyncExecutor>(), GetService<IFileSystem>(), GetService<IEntityFileLockFactory>(), GetService<ICommonPathsWrapper>(), GetService<IDocumentFactory>(), GetService<ICollaborationPeerIdProvider>(), GetService<IThreadPoolScheduler>(), GetService<ICloudDiagnosticsPublisher>(), GetService<IErrorReporter>());
				}
			}
		}
		return _IEntityDocumentRegistry;
	}

	IEntityDocumentSyncerFactory Jab.IServiceProvider<IEntityDocumentSyncerFactory>.GetService()
	{
		if (_IEntityDocumentSyncerFactory == null)
		{
			lock (this)
			{
				if (_IEntityDocumentSyncerFactory == null)
				{
					_IEntityDocumentSyncerFactory = new EntityDocumentSyncerFactory(GetService<IFileSystem>(), GetService<ILogger>(), GetService<IDocumentFactory>(), GetService<IEntityDocumentRegistry>(), GetService<ICollaborationPeerIdProvider>(), GetService<IEntityFileLockFactory>());
				}
			}
		}
		return _IEntityDocumentSyncerFactory;
	}

	IMergedEntityFactory Jab.IServiceProvider<IMergedEntityFactory>.GetService()
	{
		if (_IMergedEntityFactory == null)
		{
			lock (this)
			{
				if (_IMergedEntityFactory == null)
				{
					_IMergedEntityFactory = new MergedEntityFactory(GetService<IEntityFactory>(), GetService<IErrorReporter>());
				}
			}
		}
		return _IMergedEntityFactory;
	}

	IProPresenterDOFactoryProvider Jab.IServiceProvider<IProPresenterDOFactoryProvider>.GetService()
	{
		if (_IProPresenterDOFactoryProvider == null)
		{
			lock (this)
			{
				if (_IProPresenterDOFactoryProvider == null)
				{
					_IProPresenterDOFactoryProvider = new ProPresenterDOFactoryProvider(GetService<IMediaFactory>(), GetService<ITextDocumentFactory>(), GetService<IEntityFactory>(), GetService<IDocumentFactory>(), GetService<ITextFillMediaFactory>(), GetService<IEntityDocumentSyncerFactory>(), GetService<IErrorReporter>(), GetService<IMergedEntityFactory>());
				}
			}
		}
		return _IProPresenterDOFactoryProvider;
	}

	IMessageDialogService Jab.IServiceProvider<IMessageDialogService>.GetService()
	{
		MessageDialogServiceInstance messageDialogServiceInstance = new MessageDialogServiceInstance();
		TryAddDisposable(messageDialogServiceInstance);
		return messageDialogServiceInstance;
	}

	IPresentationFactory Jab.IServiceProvider<IPresentationFactory>.GetService()
	{
		PresentationFactory presentationFactory = new PresentationFactory(GetService<IApp>(), GetService<ITimerFactory>(), GetService<ITransitionDescriptionCollection>(), GetService<IProPresenterDOFactoryProvider>(), GetService<IMessageDialogService>(), GetService<ICurrentTime>());
		TryAddDisposable(presentationFactory);
		return presentationFactory;
	}

	IPowerPointImageLoader Jab.IServiceProvider<IPowerPointImageLoader>.GetService()
	{
		PowerPointImageLoader powerPointImageLoader = new PowerPointImageLoader(GetService<IMediaFactory>());
		TryAddDisposable(powerPointImageLoader);
		return powerPointImageLoader;
	}

	IPowerPointEvents Jab.IServiceProvider<IPowerPointEvents>.GetService()
	{
		PowerPointEvents powerPointEvents = new PowerPointEvents();
		TryAddDisposable(powerPointEvents);
		return powerPointEvents;
	}

	TypefaceLibrary Jab.IServiceProvider<TypefaceLibrary>.GetService()
	{
		TypefaceLibrary sharedTypefaceLibrary = IProPresenterDOImportServiceProviderModule.GetSharedTypefaceLibrary();
		TryAddDisposable(sharedTypefaceLibrary);
		return sharedTypefaceLibrary;
	}

	IFontDetector Jab.IServiceProvider<IFontDetector>.GetService()
	{
		FontDetector fontDetector = new FontDetector(GetService<TypefaceLibrary>());
		TryAddDisposable(fontDetector);
		return fontDetector;
	}

	IFontDetectionSessionFactory Jab.IServiceProvider<IFontDetectionSessionFactory>.GetService()
	{
		FontDetectionSessionFactory fontDetectionSessionFactory = new FontDetectionSessionFactory(GetService<IFontDetector>(), GetService<IUiDispatcher>(), GetService<IProPresenterResourceService>());
		TryAddDisposable(fontDetectionSessionFactory);
		return fontDetectionSessionFactory;
	}

	IMissingFontService Jab.IServiceProvider<IMissingFontService>.GetService()
	{
		MissingFontService missingFontService = new MissingFontService(GetService<IFontDetector>(), GetService<IFontDetectionSessionFactory>());
		TryAddDisposable(missingFontService);
		return missingFontService;
	}

	IProPresenterCueFactory Jab.IServiceProvider<IProPresenterCueFactory>.GetService()
	{
		ProPresenterCueFactory proPresenterCueFactory = new ProPresenterCueFactory(GetService<IApp>(), GetService<IProPresenterResourceService>(), GetService<IProPresenterDOFactoryProvider>(), GetService<ITransitionDescriptionCollection>());
		TryAddDisposable(proPresenterCueFactory);
		return proPresenterCueFactory;
	}

	IFontReplacementEventPublisher Jab.IServiceProvider<IFontReplacementEventPublisher>.GetService()
	{
		FontReplacementEventPublisher fontReplacementEventPublisher = new FontReplacementEventPublisher();
		TryAddDisposable(fontReplacementEventPublisher);
		return fontReplacementEventPublisher;
	}

	IMissingFontWindowProvider Jab.IServiceProvider<IMissingFontWindowProvider>.GetService()
	{
		MissingFontWindowProvider missingFontWindowProvider = new MissingFontWindowProvider(GetService<IMissingFontService>(), GetService<ILocalization>(), GetService<IFontReplacementEventPublisher>(), GetService<IProPresenterResourceService>());
		TryAddDisposable(missingFontWindowProvider);
		return missingFontWindowProvider;
	}

	ICorePowerPointImportService Jab.IServiceProvider<ICorePowerPointImportService>.GetService()
	{
		CorePowerPointImportService corePowerPointImportService = new CorePowerPointImportService();
		TryAddDisposable(corePowerPointImportService);
		return corePowerPointImportService;
	}

	IPowerPointImportService Jab.IServiceProvider<IPowerPointImportService>.GetService()
	{
		PowerPointImportService powerPointImportService = new PowerPointImportService(GetService<ICorePowerPointImportService>(), GetService<IFileSystem>());
		TryAddDisposable(powerPointImportService);
		return powerPointImportService;
	}

	IImportHelperServices Jab.IServiceProvider<IImportHelperServices>.GetService()
	{
		ImportHelperServices importHelperServices = new ImportHelperServices();
		TryAddDisposable(importHelperServices);
		return importHelperServices;
	}

	IImportLocationSelectionDialogService Jab.IServiceProvider<IImportLocationSelectionDialogService>.GetService()
	{
		IImportLocationSelectionDialogService importLocationSelectionDialogService = GetImportLocationSelectionDialogService();
		TryAddDisposable(importLocationSelectionDialogService);
		return importLocationSelectionDialogService;
	}

	IManageMediaAutoMaticallyProvider Jab.IServiceProvider<IManageMediaAutoMaticallyProvider>.GetService()
	{
		IManageMediaAutoMaticallyProvider advanced = ISettingsServiceProviderModule.GetAdvanced();
		TryAddDisposable(advanced);
		return advanced;
	}

	IFileCreator Jab.IServiceProvider<IFileCreator>.GetService()
	{
		FileCreator fileCreator = new FileCreator();
		TryAddDisposable(fileCreator);
		return fileCreator;
	}

	ISyncDataFactory Jab.IServiceProvider<ISyncDataFactory>.GetService()
	{
		SyncDataFactory syncDataFactory = new SyncDataFactory(GetService<IMessageService>(), GetService<IErrorReporter>());
		TryAddDisposable(syncDataFactory);
		return syncDataFactory;
	}

	IScreenArrangementFactory Jab.IServiceProvider<IScreenArrangementFactory>.GetService()
	{
		if (_IScreenArrangementFactory == null)
		{
			lock (this)
			{
				if (_IScreenArrangementFactory == null)
				{
					_IScreenArrangementFactory = new ScreenArrangementFactory();
				}
			}
		}
		return _IScreenArrangementFactory;
	}

	IAudioSettingsAnalyticsEventPublisher Jab.IServiceProvider<IAudioSettingsAnalyticsEventPublisher>.GetService()
	{
		AudioSettingsAnalyticsEventPublisher audioSettingsAnalyticsEventPublisher = new AudioSettingsAnalyticsEventPublisher();
		TryAddDisposable(audioSettingsAnalyticsEventPublisher);
		return audioSettingsAnalyticsEventPublisher;
	}

	IAudioInputCollection Jab.IServiceProvider<IAudioInputCollection>.GetService()
	{
		if (_IAudioInputCollection == null)
		{
			lock (this)
			{
				if (_IAudioInputCollection == null)
				{
					_IAudioInputCollection = new AudioInputCollection(GetService<IAudioSetup>(), GetService<IAudioMapRecallService<DeviceChannel, Bus>>(), GetService<ILocalization>(), GetService<IAudioSettingsAnalyticsEventPublisher>());
				}
			}
		}
		return _IAudioInputCollection;
	}

	ICrdtProtoDirectoryFileScanner Jab.IServiceProvider<ICrdtProtoDirectoryFileScanner>.GetService()
	{
		if (_ICrdtProtoDirectoryFileScanner == null)
		{
			lock (this)
			{
				if (_ICrdtProtoDirectoryFileScanner == null)
				{
					_ICrdtProtoDirectoryFileScanner = new CrdtProtoDirectoryFileScanner(GetService<IFileSystem>(), GetService<ILogger>());
				}
			}
		}
		return _ICrdtProtoDirectoryFileScanner;
	}

	IMaskCollection Jab.IServiceProvider<IMaskCollection>.GetService()
	{
		if (_IMaskCollection == null)
		{
			lock (this)
			{
				if (_IMaskCollection == null)
				{
					_IMaskCollection = new ProPresenter.DO.Masks.MaskCollection(GetService<IProPresenterDOFactoryProvider>(), GetService<ITransitionDescriptionCollection>());
				}
			}
		}
		return _IMaskCollection;
	}

	StagePresentation Jab.IServiceProvider<StagePresentation>.GetService()
	{
		if (_StagePresentation == null)
		{
			lock (this)
			{
				if (_StagePresentation == null)
				{
					_StagePresentation = IGlobalServiceProviderModule.CreateStagePresentation(GetService<IApp>(), GetService<ITimerFactory>(), GetService<IProPresenterDOFactoryProvider>(), GetService<ssAPIOutput>(), GetService<ISyncDataFactory>(), GetService<IFlagService>(), GetService<IUiScheduler>(), GetService<IMessageDialogService>(), GetService<ICurrentTime>(), GetService<ICrdtProtoDirectoryFileScanner>());
				}
			}
		}
		return _StagePresentation;
	}

	ILocalDocumentSyncerFactory Jab.IServiceProvider<ILocalDocumentSyncerFactory>.GetService()
	{
		if (_ILocalDocumentSyncerFactory == null)
		{
			lock (this)
			{
				if (_ILocalDocumentSyncerFactory == null)
				{
					_ILocalDocumentSyncerFactory = new LocalDocumentSyncerFactory(GetService<ICommonPathsWrapper>(), GetService<IFileSystem>(), GetService<IThreadPoolScheduler>(), GetService<ICollaborationPeerIdProvider>(), GetService<IDocumentFactory>());
				}
			}
		}
		return _ILocalDocumentSyncerFactory;
	}

	IOutputConfiguration Jab.IServiceProvider<IOutputConfiguration>.GetService()
	{
		if (_IOutputConfiguration == null)
		{
			lock (this)
			{
				if (_IOutputConfiguration == null)
				{
					_IOutputConfiguration = IGlobalServiceProviderModule.CreateOutputConfiguration(GetService<ssAPIOutput>(), GetService<IApp>(), GetService<ISyncDataFactory>(), GetService<IProPresenterDOFactoryProvider>(), GetService<IUiScheduler>(), GetService<IFlagService>(), GetService<IScreenArrangementFactory>(), GetService<IAudioSetup>(), GetService<ILiveVideoInputCollection>(), GetService<IAudioInputCollection>(), GetService<ICrdtProtoDirectoryFileScanner>(), GetService<IMaskCollection>(), GetService<StagePresentation>(), GetService<ILocalDocumentSyncerFactory>(), GetService<ILocalization>());
				}
			}
		}
		return _IOutputConfiguration;
	}

	ICollectionStorage Jab.IServiceProvider<ICollectionStorage>.GetService()
	{
		if (_ICollectionStorage == null)
		{
			lock (this)
			{
				if (_ICollectionStorage == null)
				{
					_ICollectionStorage = new CollectionStorage(GetService<IFileSystem>(), GetService<IDocumentService>(), GetService<ICommonPathsWrapper>(), GetService<IUiScheduler>(), GetService<IEntityFileLockFactory>(), GetService<IEntityDocumentRegistry>());
				}
			}
		}
		return _ICollectionStorage;
	}

	IImportProcessFactory Jab.IServiceProvider<IImportProcessFactory>.GetService()
	{
		if (_IImportProcessFactory == null)
		{
			lock (this)
			{
				if (_IImportProcessFactory == null)
				{
					_IImportProcessFactory = new ImportProcessFactory(GetService<IProPresenterResourceService>(), GetService<IThemeService>(), GetService<IZipService>(), GetService<IFileSystem>(), GetService<IMessageService>(), GetService<IFileService>(), GetService<ILogger>(), GetService<ILocalization>(), GetService<IAdvanced>(), GetService<IProtoService>(), GetService<IPresentationFactory>(), GetService<IProCoreInstance>(), GetService<IUiDispatcher>(), GetService<IProPresenterDOFactoryProvider>(), GetService<IPowerPointImageLoader>(), GetService<IEntityFactory>(), GetService<IPowerPointEvents>(), GetService<IMissingFontService>(), GetService<IProPresenterCueFactory>(), GetService<IMissingFontWindowProvider>(), GetService<IPowerPointImportService>(), GetService<IFlagService>(), GetService<IImportHelperServices>(), GetService<IImportLocationSelectionDialogService>(), GetService<IManageMediaAutoMaticallyProvider>(), GetService<IMediaService>(), GetService<IFileCreator>(), GetService<IOutputConfiguration>(), GetService<IMaskCollection>(), GetService<ICollectionStorage>());
				}
			}
		}
		return _IImportProcessFactory;
	}

	IAsyncFileImporter Jab.IServiceProvider<IAsyncFileImporter>.GetService()
	{
		AsyncFileImporter asyncFileImporter = new AsyncFileImporter(GetService<IImportProcessFactory>());
		TryAddDisposable(asyncFileImporter);
		return asyncFileImporter;
	}

	IMigrationSource Jab.IServiceProvider<IMigrationSource>.GetService()
	{
		IMigrationSource app = ISettingsServiceProviderModule.GetApp(GetService<App>());
		TryAddDisposable(app);
		return app;
	}

	INetwork Jab.IServiceProvider<INetwork>.GetService()
	{
		if (_INetwork == null)
		{
			lock (this)
			{
				if (_INetwork == null)
				{
					_INetwork = new Network();
				}
			}
		}
		return _INetwork;
	}

	ITimecodeSettingsRepository Jab.IServiceProvider<ITimecodeSettingsRepository>.GetService()
	{
		TimecodeSettingsRepository timecodeSettingsRepository = new TimecodeSettingsRepository(GetService<IApp>());
		TryAddDisposable(timecodeSettingsRepository);
		return timecodeSettingsRepository;
	}

	IImport Jab.IServiceProvider<IImport>.GetService()
	{
		IImport import = ISettingsServiceProviderModule.GetImport();
		TryAddDisposable(import);
		return import;
	}

	IStoredPcoOptions Jab.IServiceProvider<IStoredPcoOptions>.GetService()
	{
		IStoredPcoOptions storedPcoOptions = ISettingsServiceProviderModule.GetStoredPcoOptions();
		TryAddDisposable(storedPcoOptions);
		return storedPcoOptions;
	}

	ISongSelectConsumer Jab.IServiceProvider<ISongSelectConsumer>.GetService()
	{
		if (_ISongSelectConsumer == null)
		{
			lock (this)
			{
				if (_ISongSelectConsumer == null)
				{
					_ISongSelectConsumer = new SongSelectConsumer(GetService<IAuthenticatingApiConsumerFactory>(), GetService<IApp>(), GetService<ILogger>());
				}
			}
		}
		return _ISongSelectConsumer;
	}

	IReportRepository Jab.IServiceProvider<IReportRepository>.GetService()
	{
		if (_IReportRepository == null)
		{
			lock (this)
			{
				if (_IReportRepository == null)
				{
					_IReportRepository = new ReportRepository(GetService<ISongSelectConsumer>(), GetService<IFileSystem>(), GetService<IApp>(), GetService<IFileService>(), GetService<IMessageService>(), GetService<IDebouncerFactory>(), GetService<IAsyncExecutor>(), GetService<ILogger>());
				}
			}
		}
		return _IReportRepository;
	}

	IGeneral Jab.IServiceProvider<IGeneral>.GetService()
	{
		IGeneral general = ISettingsServiceProviderModule.GetGeneral();
		TryAddDisposable(general);
		return general;
	}

	IEnableAnalyticsProvider Jab.IServiceProvider<IEnableAnalyticsProvider>.GetService()
	{
		IEnableAnalyticsProvider general = ISettingsServiceProviderModule.GetGeneral();
		TryAddDisposable(general);
		return general;
	}

	IDisplay Jab.IServiceProvider<IDisplay>.GetService()
	{
		IDisplay display = ISettingsServiceProviderModule.GetDisplay();
		TryAddDisposable(display);
		return display;
	}

	ISync Jab.IServiceProvider<ISync>.GetService()
	{
		ISync sync = ISettingsServiceProviderModule.GetSync();
		TryAddDisposable(sync);
		return sync;
	}

	ILayout Jab.IServiceProvider<ILayout>.GetService()
	{
		ILayout layout = ISettingsServiceProviderModule.GetLayout();
		TryAddDisposable(layout);
		return layout;
	}

	IPlaylistActionValidatorFactory Jab.IServiceProvider<IPlaylistActionValidatorFactory>.GetService()
	{
		PlaylistActionValidatorFactory playlistActionValidatorFactory = new PlaylistActionValidatorFactory(GetService<IProPresenterResourceService>());
		TryAddDisposable(playlistActionValidatorFactory);
		return playlistActionValidatorFactory;
	}

	IActionBinderFactory Jab.IServiceProvider<IActionBinderFactory>.GetService()
	{
		if (_IActionBinderFactory == null)
		{
			lock (this)
			{
				if (_IActionBinderFactory == null)
				{
					_IActionBinderFactory = new ActionBinderFactory(GetService<ILogger>(), GetService<IProPresenterDOFactoryProvider>(), GetService<IUiScheduler>());
				}
			}
		}
		return _IActionBinderFactory;
	}

	IEncoderValidator Jab.IServiceProvider<IEncoderValidator>.GetService()
	{
		if (_IEncoderValidator == null)
		{
			lock (this)
			{
				if (_IEncoderValidator == null)
				{
					_IEncoderValidator = new EncoderValidator(GetService<IProCoreInstance>(), GetService<IDelayFactory>());
				}
			}
		}
		return _IEncoderValidator;
	}

	IThemeImportProcessFactory Jab.IServiceProvider<IThemeImportProcessFactory>.GetService()
	{
		ThemeImportProcessFactory themeImportProcessFactory = new ThemeImportProcessFactory(GetService<IImportProcessFactory>());
		TryAddDisposable(themeImportProcessFactory);
		return themeImportProcessFactory;
	}

	IThemeAnalyiticEvents Jab.IServiceProvider<IThemeAnalyiticEvents>.GetService()
	{
		ThemeAnalyticEvents themeAnalyticEvents = new ThemeAnalyticEvents();
		TryAddDisposable(themeAnalyticEvents);
		return themeAnalyticEvents;
	}

	IDxDiagReaderFactory Jab.IServiceProvider<IDxDiagReaderFactory>.GetService()
	{
		DxDiagReaderFactory dxDiagReaderFactory = new DxDiagReaderFactory();
		TryAddDisposable(dxDiagReaderFactory);
		return dxDiagReaderFactory;
	}

	private IIdProvider GetIIdProvider_BugsnagIdProviderKey()
	{
		if (_IIdProvider_BugsnagIdProviderKey == null)
		{
			lock (this)
			{
				if (_IIdProvider_BugsnagIdProviderKey == null)
				{
					_IIdProvider_BugsnagIdProviderKey = new BugsnagUserInfo();
				}
			}
		}
		return _IIdProvider_BugsnagIdProviderKey;
	}

	ISystemInfoProvider Jab.IServiceProvider<ISystemInfoProvider>.GetService()
	{
		ISystemInfoProvider systemInfoProvider = GetSystemInfoProvider(GetService<IFileSystem>(), GetService<IDxDiagReaderFactory>(), GetIIdProvider_BugsnagIdProviderKey());
		TryAddDisposable(systemInfoProvider);
		return systemInfoProvider;
	}

	IApplicationLaunchEventPublisher Jab.IServiceProvider<IApplicationLaunchEventPublisher>.GetService()
	{
		if (_IApplicationLaunchEventPublisher == null)
		{
			lock (this)
			{
				if (_IApplicationLaunchEventPublisher == null)
				{
					_IApplicationLaunchEventPublisher = new ApplicationLaunchEventPublisher(GetService<IRegistrationStateProvider>(), GetService<ISystemInfoProvider>(), GetService<IApp>(), GetService<IVersionInfoProvider>(), GetService<ILocalization>(), GetService<IFlagService>());
				}
			}
		}
		return _IApplicationLaunchEventPublisher;
	}

	ICaptureAnalyticEventsPublisher Jab.IServiceProvider<ICaptureAnalyticEventsPublisher>.GetService()
	{
		CaptureAnalyticEventsPublisher captureAnalyticEventsPublisher = new CaptureAnalyticEventsPublisher();
		TryAddDisposable(captureAnalyticEventsPublisher);
		return captureAnalyticEventsPublisher;
	}

	IStartupSettingsEventsPublisher Jab.IServiceProvider<IStartupSettingsEventsPublisher>.GetService()
	{
		StartupSettingsEventsPublisher startupSettingsEventsPublisher = new StartupSettingsEventsPublisher();
		TryAddDisposable(startupSettingsEventsPublisher);
		return startupSettingsEventsPublisher;
	}

	IUiPreferencesAnalyticEventsPublisher Jab.IServiceProvider<IUiPreferencesAnalyticEventsPublisher>.GetService()
	{
		UiPreferencesAnalyticEventsPublisher uiPreferencesAnalyticEventsPublisher = new UiPreferencesAnalyticEventsPublisher();
		TryAddDisposable(uiPreferencesAnalyticEventsPublisher);
		return uiPreferencesAnalyticEventsPublisher;
	}

	ITestPatternAnalyticEventsPublisher Jab.IServiceProvider<ITestPatternAnalyticEventsPublisher>.GetService()
	{
		TestPatternAnalyticEventsPublisher testPatternAnalyticEventsPublisher = new TestPatternAnalyticEventsPublisher();
		TryAddDisposable(testPatternAnalyticEventsPublisher);
		return testPatternAnalyticEventsPublisher;
	}

	IWelcomeAnalyticEventsPublisher Jab.IServiceProvider<IWelcomeAnalyticEventsPublisher>.GetService()
	{
		WelcomeAnalyticEventsPublisher welcomeAnalyticEventsPublisher = new WelcomeAnalyticEventsPublisher();
		TryAddDisposable(welcomeAnalyticEventsPublisher);
		return welcomeAnalyticEventsPublisher;
	}

	ITimecodeAnalyticsEvents Jab.IServiceProvider<ITimecodeAnalyticsEvents>.GetService()
	{
		TimecodeAnalyticsEvents timecodeAnalyticsEvents = new TimecodeAnalyticsEvents();
		TryAddDisposable(timecodeAnalyticsEvents);
		return timecodeAnalyticsEvents;
	}

	IPlaybackMarkerAnalyticsEvents Jab.IServiceProvider<IPlaybackMarkerAnalyticsEvents>.GetService()
	{
		PlaybackMarkerAnalyticsEvents playbackMarkerAnalyticsEvents = new PlaybackMarkerAnalyticsEvents();
		TryAddDisposable(playbackMarkerAnalyticsEvents);
		return playbackMarkerAnalyticsEvents;
	}

	ITimelineAnalyticsEvents Jab.IServiceProvider<ITimelineAnalyticsEvents>.GetService()
	{
		TimelineAnalyticsEvents timelineAnalyticsEvents = new TimelineAnalyticsEvents();
		TryAddDisposable(timelineAnalyticsEvents);
		return timelineAnalyticsEvents;
	}

	ICCLIReportAnalyticsEvents Jab.IServiceProvider<ICCLIReportAnalyticsEvents>.GetService()
	{
		CCLIReportAnalyticsEvents cCLIReportAnalyticsEvents = new CCLIReportAnalyticsEvents();
		TryAddDisposable(cCLIReportAnalyticsEvents);
		return cCLIReportAnalyticsEvents;
	}

	IMediaCleanupSizeEventPublisher Jab.IServiceProvider<IMediaCleanupSizeEventPublisher>.GetService()
	{
		MediaCleanupSizeEventPublisher mediaCleanupSizeEventPublisher = new MediaCleanupSizeEventPublisher();
		TryAddDisposable(mediaCleanupSizeEventPublisher);
		return mediaCleanupSizeEventPublisher;
	}

	IMediaAnalyticsSender Jab.IServiceProvider<IMediaAnalyticsSender>.GetService()
	{
		MediaAnalyticsSender mediaAnalyticsSender = new MediaAnalyticsSender();
		TryAddDisposable(mediaAnalyticsSender);
		return mediaAnalyticsSender;
	}

	IWorkspaceAnalyticsEventPublisher Jab.IServiceProvider<IWorkspaceAnalyticsEventPublisher>.GetService()
	{
		WorkspaceAnalyticsEventPublisher workspaceAnalyticsEventPublisher = new WorkspaceAnalyticsEventPublisher();
		TryAddDisposable(workspaceAnalyticsEventPublisher);
		return workspaceAnalyticsEventPublisher;
	}

	ICloudOnboardingAnalyticsEventPublisher Jab.IServiceProvider<ICloudOnboardingAnalyticsEventPublisher>.GetService()
	{
		CloudOnboardingAnalyticsEventPublisher cloudOnboardingAnalyticsEventPublisher = new CloudOnboardingAnalyticsEventPublisher();
		TryAddDisposable(cloudOnboardingAnalyticsEventPublisher);
		return cloudOnboardingAnalyticsEventPublisher;
	}

	IFileDownloadObserverFactory Jab.IServiceProvider<IFileDownloadObserverFactory>.GetService()
	{
		FileDownloadObserverFactory fileDownloadObserverFactory = new FileDownloadObserverFactory(GetService<IFileSystem>(), GetService<IImport>(), GetService<IApp>(), GetService<IMediaFactory>(), GetService<ITransitionDescriptionCollection>());
		TryAddDisposable(fileDownloadObserverFactory);
		return fileDownloadObserverFactory;
	}

	IProContentDownloadProcessFactory Jab.IServiceProvider<IProContentDownloadProcessFactory>.GetService()
	{
		ProContentDownloadProcessFactory proContentDownloadProcessFactory = new ProContentDownloadProcessFactory(GetService<IDownloadItemFactory>(), GetService<IProContentConsumer>(), GetService<IProPresenterResourceService>(), GetService<IApp>(), GetService<IProContentDownloadFailedDialogService>(), GetService<IProContentAnalyticEventsPublisher>(), GetService<IDownloadManager>(), GetService<IFileDownloadObserverFactory>());
		TryAddDisposable(proContentDownloadProcessFactory);
		return proContentDownloadProcessFactory;
	}

	IStopwatchFactory Jab.IServiceProvider<IStopwatchFactory>.GetService()
	{
		StopwatchFactory stopwatchFactory = new StopwatchFactory();
		TryAddDisposable(stopwatchFactory);
		return stopwatchFactory;
	}

	ICacheFactory Jab.IServiceProvider<ICacheFactory>.GetService()
	{
		CacheFactory cacheFactory = new CacheFactory(GetService<IStopwatchFactory>());
		TryAddDisposable(cacheFactory);
		return cacheFactory;
	}

	IProContentProvider Jab.IServiceProvider<IProContentProvider>.GetService()
	{
		if (_IProContentProvider == null)
		{
			lock (this)
			{
				if (_IProContentProvider == null)
				{
					_IProContentProvider = new ProContentProvider(GetService<IProContentConsumer>(), GetService<IInternetAccessCheck>(), GetService<IHyperlinkService>(), GetService<ICacheFactory>(), GetService<IApp>(), GetService<IProContentDownloadProcessFactory>(), GetService<IUiDispatcher>(), GetService<IProContentUserInteractionBehavior>());
				}
			}
		}
		return _IProContentProvider;
	}

	IUriCacheService<IReadOnlyList<IAnimationFrame>> Jab.IServiceProvider<IUriCacheService<IReadOnlyList<IAnimationFrame>>>.GetService()
	{
		if (_IUriCacheService_IReadOnlyList_IAnimationFrame == null)
		{
			lock (this)
			{
				if (_IUriCacheService_IReadOnlyList_IAnimationFrame == null)
				{
					_IUriCacheService_IReadOnlyList_IAnimationFrame = new UrlAnimatedImageCacheService(GetService<IFileSystemUriCacheServiceFactory>(), GetService<ILogger>(), GetService<IBitmapImageDecoder>(), GetService<IAsyncExecutor>());
				}
			}
		}
		return _IUriCacheService_IReadOnlyList_IAnimationFrame;
	}

	IOutputRepository Jab.IServiceProvider<IOutputRepository>.GetService()
	{
		if (_IOutputRepository == null)
		{
			lock (this)
			{
				if (_IOutputRepository == null)
				{
					_IOutputRepository = IGlobalServiceProviderModule.GetOutputRepository(GetService<ssAPIOutput>(), GetService<IAudioInputCollection>(), GetService<ILiveVideoInputCollection>(), GetService<IOutputConfiguration>());
				}
			}
		}
		return _IOutputRepository;
	}

	ICommunicationOutput Jab.IServiceProvider<ICommunicationOutput>.GetService()
	{
		if (_ICommunicationOutput == null)
		{
			lock (this)
			{
				if (_ICommunicationOutput == null)
				{
					_ICommunicationOutput = new CommunicationOutput();
				}
			}
		}
		return _ICommunicationOutput;
	}

	IOutputService Jab.IServiceProvider<IOutputService>.GetService()
	{
		OutputService outputService = new OutputService(GetService<ssAPIOutput>(), GetService<IOutputRepository>(), GetService<ICommunicationOutput>(), GetService<IOutputConfiguration>());
		TryAddDisposable(outputService);
		return outputService;
	}

	IErrorPrompt Jab.IServiceProvider<IErrorPrompt>.GetService()
	{
		if (_IErrorPrompt == null)
		{
			lock (this)
			{
				if (_IErrorPrompt == null)
				{
					_IErrorPrompt = IGlobalServiceProviderModule.GetResiErrorPrompt(GetService<IOutputService>());
				}
			}
		}
		return _IErrorPrompt;
	}

	IResiPlugin Jab.IServiceProvider<IResiPlugin>.GetService()
	{
		if (_IResiPlugin == null)
		{
			lock (this)
			{
				if (_IResiPlugin == null)
				{
					_IResiPlugin = IControllerServiceProviderModule.GetResiPlugin(GetService<IApp>(), GetService<IErrorPrompt>(), GetService<IProCoreInstance>());
				}
			}
		}
		return _IResiPlugin;
	}

	IResiCustomEndpointsStore Jab.IServiceProvider<IResiCustomEndpointsStore>.GetService()
	{
		if (_IResiCustomEndpointsStore == null)
		{
			lock (this)
			{
				if (_IResiCustomEndpointsStore == null)
				{
					_IResiCustomEndpointsStore = IResiServiceProviderModule.GetResiCustomEndpointsStore(GetService<IFileSystem>());
				}
			}
		}
		return _IResiCustomEndpointsStore;
	}

	IResiEndpoints Jab.IServiceProvider<IResiEndpoints>.GetService()
	{
		IResiEndpoints resiEndpoints = IResiServiceProviderModule.GetResiEndpoints(GetService<IResiCustomEndpointsStore>(), GetService<IApiService>());
		TryAddDisposable(resiEndpoints);
		return resiEndpoints;
	}

	IResiWebClient Jab.IServiceProvider<IResiWebClient>.GetService()
	{
		if (_IResiWebClient == null)
		{
			lock (this)
			{
				if (_IResiWebClient == null)
				{
					_IResiWebClient = new ResiWebClient(GetService<IRegistrationStateProvider>(), GetService<IResiPlugin>(), GetService<IApp>(), GetService<IFlagService>(), GetService<IRestClientFactory>(), GetService<IResiEndpoints>());
				}
			}
		}
		return _IResiWebClient;
	}

	IMessages<AppMessages> Jab.IServiceProvider<IMessages<AppMessages>>.GetService()
	{
		if (_IMessages_AppMessages == null)
		{
			lock (this)
			{
				if (_IMessages_AppMessages == null)
				{
					_IMessages_AppMessages = new Messages<AppMessages>();
				}
			}
		}
		return _IMessages_AppMessages;
	}

	IUpdateClient Jab.IServiceProvider<IUpdateClient>.GetService()
	{
		if (_IUpdateClient == null)
		{
			lock (this)
			{
				if (_IUpdateClient == null)
				{
					_IUpdateClient = new UpdateClient(GetService<IResiPlugin>(), GetService<IMessages<AppMessages>>(), GetService<IResiWebClient>(), GetService<IUiDispatcher>(), GetService<IDownloadItemFactory>());
				}
			}
		}
		return _IUpdateClient;
	}

	ITestPatternPropertyFactory Jab.IServiceProvider<ITestPatternPropertyFactory>.GetService()
	{
		TestPatternPropertyFactory testPatternPropertyFactory = new TestPatternPropertyFactory();
		TryAddDisposable(testPatternPropertyFactory);
		return testPatternPropertyFactory;
	}

	ITestPatternDefinitionFactory Jab.IServiceProvider<ITestPatternDefinitionFactory>.GetService()
	{
		TestPatternDefinitionFactory testPatternDefinitionFactory = new TestPatternDefinitionFactory(GetService<ITestPatternPropertyFactory>());
		TryAddDisposable(testPatternDefinitionFactory);
		return testPatternDefinitionFactory;
	}

	ITestPatternStateFactory Jab.IServiceProvider<ITestPatternStateFactory>.GetService()
	{
		TestPatternStateFactory testPatternStateFactory = new TestPatternStateFactory();
		TryAddDisposable(testPatternStateFactory);
		return testPatternStateFactory;
	}

	ITestPatternPersistence Jab.IServiceProvider<ITestPatternPersistence>.GetService()
	{
		if (_ITestPatternPersistence == null)
		{
			lock (this)
			{
				if (_ITestPatternPersistence == null)
				{
					_ITestPatternPersistence = new TestPatternPersistence(GetService<ISyncDataFactory>());
				}
			}
		}
		return _ITestPatternPersistence;
	}

	ITestPatternService Jab.IServiceProvider<ITestPatternService>.GetService()
	{
		if (_ITestPatternService == null)
		{
			lock (this)
			{
				if (_ITestPatternService == null)
				{
					_ITestPatternService = new TestPatternService(GetService<IProCoreInstance>(), GetService<ITestPatternDefinitionFactory>(), GetService<ITestPatternStateFactory>(), GetService<IUiDispatcher>(), GetService<ITestPatternPersistence>(), GetService<IDebouncerFactory>());
				}
			}
		}
		return _ITestPatternService;
	}

	IFileProvider Jab.IServiceProvider<IFileProvider>.GetService()
	{
		FileProvider fileProvider = new FileProvider();
		TryAddDisposable(fileProvider);
		return fileProvider;
	}

	ISyncDataProvider Jab.IServiceProvider<ISyncDataProvider>.GetService()
	{
		SyncDataProvider syncDataProvider = new SyncDataProvider(GetService<IFileProvider>());
		TryAddDisposable(syncDataProvider);
		return syncDataProvider;
	}

	private ISyncRepository<ISyncData> GetISyncRepository_ISyncData_RemoteFileRepositoryKey()
	{
		RemoteFileRepository remoteFileRepository = new RemoteFileRepository(GetService<ISyncDataProvider>(), GetService<IErrorReporter>());
		TryAddDisposable(remoteFileRepository);
		return remoteFileRepository;
	}

	ISyncActionProvider Jab.IServiceProvider<ISyncActionProvider>.GetService()
	{
		SyncActionProvider syncActionProvider = new SyncActionProvider();
		TryAddDisposable(syncActionProvider);
		return syncActionProvider;
	}

	IAppContinuationService Jab.IServiceProvider<IAppContinuationService>.GetService()
	{
		IAppContinuationService continuationService = GetContinuationService();
		TryAddDisposable(continuationService);
		return continuationService;
	}

	IAppInstallerFactory Jab.IServiceProvider<IAppInstallerFactory>.GetService()
	{
		AppInstallerFactory appInstallerFactory = new AppInstallerFactory(GetService<IMessageService>(), GetService<IAppContinuationService>());
		TryAddDisposable(appInstallerFactory);
		return appInstallerFactory;
	}

	IAppDownloadFactory Jab.IServiceProvider<IAppDownloadFactory>.GetService()
	{
		AppDownloadFactory appDownloadFactory = new AppDownloadFactory(GetService<IDownloadProcessFactory>(), GetService<IAppInstallerFactory>(), GetService<ILogger>());
		TryAddDisposable(appDownloadFactory);
		return appDownloadFactory;
	}

	IAppUpdateUserDialogService Jab.IServiceProvider<IAppUpdateUserDialogService>.GetService()
	{
		if (_IAppUpdateUserDialogService == null)
		{
			lock (this)
			{
				if (_IAppUpdateUserDialogService == null)
				{
					_IAppUpdateUserDialogService = new AppUpdateUserDialogService(GetService<IUiDispatcher>(), GetService<IVersionInfoProvider>(), GetService<IHyperlinkService>(), GetService<IRegistrationWebResourceService>(), GetService<IAfterStartupCompleteQueue>());
				}
			}
		}
		return _IAppUpdateUserDialogService;
	}

	IAppUpdateService Jab.IServiceProvider<IAppUpdateService>.GetService()
	{
		if (_IAppUpdateService == null)
		{
			lock (this)
			{
				if (_IAppUpdateService == null)
				{
					_IAppUpdateService = new AppUpdateService(GetService<IRegistrationOperationFactory>(), GetService<IApp>(), GetService<IAppDownloadFactory>(), GetService<ITimerFactory>(), GetService<IAppUpdateUserDialogService>(), GetService<IInternetAccessCheck>(), GetService<IRegistrationStateProvider>(), GetService<IAsyncExecutor>());
				}
			}
		}
		return _IAppUpdateService;
	}

	IIndexingService Jab.IServiceProvider<IIndexingService>.GetService()
	{
		IndexingService indexingService = new IndexingService();
		TryAddDisposable(indexingService);
		return indexingService;
	}

	IPresentationCapableSyncDataFactory Jab.IServiceProvider<IPresentationCapableSyncDataFactory>.GetService()
	{
		SyncDataFactory syncDataFactory = new SyncDataFactory(GetService<IMessageService>(), GetService<IErrorReporter>());
		TryAddDisposable(syncDataFactory);
		return syncDataFactory;
	}

	IBibleDataStore Jab.IServiceProvider<IBibleDataStore>.GetService()
	{
		if (_IBibleDataStore == null)
		{
			lock (this)
			{
				if (_IBibleDataStore == null)
				{
					_IBibleDataStore = IProPresenterDOServiceProviderModule.CreateBibleDataStore();
				}
			}
		}
		return _IBibleDataStore;
	}

	IBibleProvider Jab.IServiceProvider<IBibleProvider>.GetService()
	{
		if (_IBibleProvider == null)
		{
			lock (this)
			{
				if (_IBibleProvider == null)
				{
					_IBibleProvider = new BibleProvider(GetService<IRegistrationOperationFactory>(), GetService<IRegistrationStateProvider>(), GetService<IUiDispatcher>(), GetService<IBibleDataStore>());
				}
			}
		}
		return _IBibleProvider;
	}

	IMultiTracksConsumer Jab.IServiceProvider<IMultiTracksConsumer>.GetService()
	{
		if (_IMultiTracksConsumer == null)
		{
			lock (this)
			{
				if (_IMultiTracksConsumer == null)
				{
					_IMultiTracksConsumer = new MultiTracksConsumer(GetService<IApp>(), GetService<IUiDispatcher>(), GetService<IRestClientFactory>(), GetService<IPresentationFactory>());
				}
			}
		}
		return _IMultiTracksConsumer;
	}

	IAuthenticatorFactory Jab.IServiceProvider<IAuthenticatorFactory>.GetService()
	{
		AuthenticatorFactory authenticatorFactory = new AuthenticatorFactory(GetService<IRestClientFactory>(), GetService<ICurrentTimeOffset>(), GetService<ILogger>());
		TryAddDisposable(authenticatorFactory);
		return authenticatorFactory;
	}

	IPCOConsumer Jab.IServiceProvider<IPCOConsumer>.GetService()
	{
		if (_IPCOConsumer == null)
		{
			lock (this)
			{
				if (_IPCOConsumer == null)
				{
					_IPCOConsumer = IGlobalServiceProviderModule.GetPCOConsumer(GetService<IAuthenticatorFactory>(), GetService<IRestClientFactory>(), GetService<IApp>(), GetService<IStoredPcoOptions>(), GetService<ILogger>(), GetService<IAsyncExecutor>(), GetService<ILocalization>());
				}
			}
		}
		return _IPCOConsumer;
	}

	IPCOUpdater Jab.IServiceProvider<IPCOUpdater>.GetService()
	{
		if (_IPCOUpdater == null)
		{
			lock (this)
			{
				if (_IPCOUpdater == null)
				{
					_IPCOUpdater = new PCOUpdater(GetService<IPCOConsumer>(), GetService<ITimerFactory>(), GetService<IUiDispatcher>(), GetService<IAsyncExecutor>(), GetService<IProPresenterResourceService>(), GetService<IInternetAccess>(), GetService<IStoredPcoOptions>());
				}
			}
		}
		return _IPCOUpdater;
	}

	ThumbnailViewSettings Jab.IServiceProvider<ThumbnailViewSettings>.GetService()
	{
		ThumbnailViewSettings thumbnailViewSettings = new ThumbnailViewSettings(GetService<IApp>());
		TryAddDisposable(thumbnailViewSettings);
		return thumbnailViewSettings;
	}

	IExportProcessFactory Jab.IServiceProvider<IExportProcessFactory>.GetService()
	{
		if (_IExportProcessFactory == null)
		{
			lock (this)
			{
				if (_IExportProcessFactory == null)
				{
					_IExportProcessFactory = new ExportProcessFactory(GetService<IFileSystem>(), GetService<IFileService>(), GetService<IFlagService>());
				}
			}
		}
		return _IExportProcessFactory;
	}

	IInputActions Jab.IServiceProvider<IInputActions>.GetService()
	{
		if (_IInputActions == null)
		{
			lock (this)
			{
				if (_IInputActions == null)
				{
					_IInputActions = IProPresenterDOServiceProviderModule.GetInputActions(GetService<IFlagService>(), GetService<ISyncDataFactory>(), GetService<IProPresenterDOFactoryProvider>(), GetService<IVersionInfoProvider>(), GetService<ICrdtProtoDirectoryFileScanner>());
				}
			}
		}
		return _IInputActions;
	}

	IMediaImportService Jab.IServiceProvider<IMediaImportService>.GetService()
	{
		MediaImportService mediaImportService = new MediaImportService(GetService<IImportProcessFactory>());
		TryAddDisposable(mediaImportService);
		return mediaImportService;
	}

	IMediaFileProvider Jab.IServiceProvider<IMediaFileProvider>.GetService()
	{
		MediaFileProvider mediaFileProvider = new MediaFileProvider(GetService<IProPresenterResourceService>(), GetService<IOutputConfiguration>(), GetService<IFileSystem>(), GetService<IMaskCollection>());
		TryAddDisposable(mediaFileProvider);
		return mediaFileProvider;
	}

	IWorkspaceInspectionService Jab.IServiceProvider<IWorkspaceInspectionService>.GetService()
	{
		WorkspaceInspectionService workspaceInspectionService = new WorkspaceInspectionService(GetService<IWorkspaceService>(), GetService<IVisualPlaylistRepo>(), GetService<IMediaFileProvider>(), GetService<ILogger>());
		TryAddDisposable(workspaceInspectionService);
		return workspaceInspectionService;
	}

	ICloudWorkspaceService Jab.IServiceProvider<ICloudWorkspaceService>.GetService()
	{
		if (_ICloudWorkspaceService == null)
		{
			lock (this)
			{
				if (_ICloudWorkspaceService == null)
				{
					_ICloudWorkspaceService = new CloudWorkspaceService(GetService<ICoreApplication>(), GetService<ILogger>());
				}
			}
		}
		return _ICloudWorkspaceService;
	}

	ICloudConversionService Jab.IServiceProvider<ICloudConversionService>.GetService()
	{
		CloudConversionService cloudConversionService = new CloudConversionService(GetService<ICloudWorkspaceService>(), GetService<ILogger>(), GetService<IWorkspaceAnalyticsEventPublisher>(), GetService<IStopwatchFactory>());
		TryAddDisposable(cloudConversionService);
		return cloudConversionService;
	}

	ICloudOnboardingService Jab.IServiceProvider<ICloudOnboardingService>.GetService()
	{
		if (_ICloudOnboardingService == null)
		{
			lock (this)
			{
				if (_ICloudOnboardingService == null)
				{
					_ICloudOnboardingService = new CloudOnboardingService(GetService<IFlagService>(), GetService<IApp>(), GetService<IRegistrationStateProvider>(), GetService<IInternetAccessCheck>(), GetService<IWorkspaceService>(), GetService<IWorkspaceInspectionService>(), GetService<IProContentConsumer>(), GetService<ICloudConversionService>(), GetService<ILocalization>(), GetService<ILogger>());
				}
			}
		}
		return _ICloudOnboardingService;
	}

	IMatchSongsInteractor Jab.IServiceProvider<IMatchSongsInteractor>.GetService()
	{
		MatchSongsInteractor matchSongsInteractor = new MatchSongsInteractor(GetService<IPCOConsumer>());
		TryAddDisposable(matchSongsInteractor);
		return matchSongsInteractor;
	}

	IWorkspaceDocumentOrchestrator Jab.IServiceProvider<IWorkspaceDocumentOrchestrator>.GetService()
	{
		if (_IWorkspaceDocumentOrchestrator == null)
		{
			lock (this)
			{
				if (_IWorkspaceDocumentOrchestrator == null)
				{
					_IWorkspaceDocumentOrchestrator = IProPresenterDOServiceProviderModule.GetWorkspaceDocumentOrchestrator(GetService<ICloudWorkspaceService>(), GetService<IEntityDocumentRegistry>(), GetService<ICommonPathsWrapper>(), GetService<IFileSystem>(), GetService<ILogger>(), GetService<IInputActions>(), GetService<IOutputConfiguration>(), GetService<IProPresenterResourceService>());
				}
			}
		}
		return _IWorkspaceDocumentOrchestrator;
	}

	ThemeCollection Jab.IServiceProvider<ThemeCollection>.GetService()
	{
		if (_ThemeCollection == null)
		{
			lock (this)
			{
				if (_ThemeCollection == null)
				{
					_ThemeCollection = IProPresenterDOServiceProviderModule.GetThemeCollection(GetService<ISyncDataFactory>(), GetService<IProPresenterDOFactoryProvider>(), GetService<ITransitionDescriptionCollection>(), GetService<IFlagService>(), GetService<IUiScheduler>(), GetService<IActionBinderFactory>(), GetService<ICrdtProtoDirectoryFileScanner>(), GetService<ICommonPathsWrapper>(), GetService<IFileSystem>(), GetService<IFileWatcherFactory>(), GetService<ICollectionStorage>());
				}
			}
		}
		return _ThemeCollection;
	}

	IThemeCollection Jab.IServiceProvider<IThemeCollection>.GetService()
	{
		IThemeCollection themeCollectionRedirect = IProPresenterDOServiceProviderModule.GetThemeCollectionRedirect(GetService<ThemeCollection>());
		TryAddDisposable(themeCollectionRedirect);
		return themeCollectionRedirect;
	}

	IFileFilterProvider Jab.IServiceProvider<IFileFilterProvider>.GetService()
	{
		FileFilterProvider fileFilterProvider = new FileFilterProvider();
		TryAddDisposable(fileFilterProvider);
		return fileFilterProvider;
	}

	IFileUtility Jab.IServiceProvider<IFileUtility>.GetService()
	{
		FileUtility fileUtility = new FileUtility(GetService<ILogger>());
		TryAddDisposable(fileUtility);
		return fileUtility;
	}

	IProcessHelper Jab.IServiceProvider<IProcessHelper>.GetService()
	{
		if (_IProcessHelper == null)
		{
			lock (this)
			{
				if (_IProcessHelper == null)
				{
					_IProcessHelper = new ProcessHelper();
				}
			}
		}
		return _IProcessHelper;
	}

	INetworkChange Jab.IServiceProvider<INetworkChange>.GetService()
	{
		NetworkChange networkChange = new NetworkChange();
		TryAddDisposable(networkChange);
		return networkChange;
	}

	IFileObservatory Jab.IServiceProvider<IFileObservatory>.GetService()
	{
		if (_IFileObservatory == null)
		{
			lock (this)
			{
				if (_IFileObservatory == null)
				{
					_IFileObservatory = new FileObservatory();
				}
			}
		}
		return _IFileObservatory;
	}

	ISettingsSearchFactory Jab.IServiceProvider<ISettingsSearchFactory>.GetService()
	{
		SettingsSearchFactory settingsSearchFactory = new SettingsSearchFactory(GetService<ILocalization>());
		TryAddDisposable(settingsSearchFactory);
		return settingsSearchFactory;
	}

	INetworkDialogService Jab.IServiceProvider<INetworkDialogService>.GetService()
	{
		NetworkDialogService networkDialogService = new NetworkDialogService();
		TryAddDisposable(networkDialogService);
		return networkDialogService;
	}

	IMediaCleanupPrompt Jab.IServiceProvider<IMediaCleanupPrompt>.GetService()
	{
		MediaCleanupPrompt mediaCleanupPrompt = new MediaCleanupPrompt();
		TryAddDisposable(mediaCleanupPrompt);
		return mediaCleanupPrompt;
	}

	IMidiDeviceSettingsVM Jab.IServiceProvider<IMidiDeviceSettingsVM>.GetService()
	{
		if (_IMidiDeviceSettingsVM == null)
		{
			lock (this)
			{
				if (_IMidiDeviceSettingsVM == null)
				{
					_IMidiDeviceSettingsVM = new MidiDeviceSettingsVM(GetService<ICommunicationOutput>(), GetService<ILocalization>(), GetService<IHyperlinkService>(), GetService<IWebSourceProvider>(), GetService<ISettingsSearchFactory>());
				}
			}
		}
		return _IMidiDeviceSettingsVM;
	}

	IMidiWindowProvider Jab.IServiceProvider<IMidiWindowProvider>.GetService()
	{
		if (_IMidiWindowProvider == null)
		{
			lock (this)
			{
				if (_IMidiWindowProvider == null)
				{
					_IMidiWindowProvider = new MidiWindowProvider();
				}
			}
		}
		return _IMidiWindowProvider;
	}

	IFileSelectorService Jab.IServiceProvider<IFileSelectorService>.GetService()
	{
		FileSelectorService fileSelectorService = new FileSelectorService();
		TryAddDisposable(fileSelectorService);
		return fileSelectorService;
	}

	ICCLIReportPrompt Jab.IServiceProvider<ICCLIReportPrompt>.GetService()
	{
		CCLIReportPrompt cCLIReportPrompt = new CCLIReportPrompt(GetService<IFileSelectorService>());
		TryAddDisposable(cCLIReportPrompt);
		return cCLIReportPrompt;
	}

	INdiInputsSettingsDialogService Jab.IServiceProvider<INdiInputsSettingsDialogService>.GetService()
	{
		NdiInputsSettingsDialogService ndiInputsSettingsDialogService = new NdiInputsSettingsDialogService(GetService<IUiDispatcher>(), GetService<ILocalization>());
		TryAddDisposable(ndiInputsSettingsDialogService);
		return ndiInputsSettingsDialogService;
	}

	IAirCastPrompt Jab.IServiceProvider<IAirCastPrompt>.GetService()
	{
		AirCastPrompt airCastPrompt = new AirCastPrompt(GetService<IWebSourceProvider>(), GetService<IHyperlinkService>());
		TryAddDisposable(airCastPrompt);
		return airCastPrompt;
	}

	IAirCastConfiguration Jab.IServiceProvider<IAirCastConfiguration>.GetService()
	{
		if (_IAirCastConfiguration == null)
		{
			lock (this)
			{
				if (_IAirCastConfiguration == null)
				{
					_IAirCastConfiguration = new AirCastConfiguration(GetService<IFileSystem>());
				}
			}
		}
		return _IAirCastConfiguration;
	}

	IInstallFileExecutor Jab.IServiceProvider<IInstallFileExecutor>.GetService()
	{
		if (_IInstallFileExecutor == null)
		{
			lock (this)
			{
				if (_IInstallFileExecutor == null)
				{
					_IInstallFileExecutor = IGlobalServiceProviderModule.GetInstallFileExecutor(GetService<IMessages<AppMessages>>());
				}
			}
		}
		return _IInstallFileExecutor;
	}

	IAirCastPluginDownload Jab.IServiceProvider<IAirCastPluginDownload>.GetService()
	{
		AirCastPluginDownload airCastPluginDownload = new AirCastPluginDownload(GetService<IAirCastConfiguration>(), GetService<IWebSourceProvider>(), GetService<IFileSystem>(), GetService<IInstallFileExecutor>(), GetService<IRestClientFactory>(), GetService<IAirCastPrompt>(), GetService<IZipService>());
		TryAddDisposable(airCastPluginDownload);
		return airCastPluginDownload;
	}

	ICCLIReportCollectionVM Jab.IServiceProvider<ICCLIReportCollectionVM>.GetService()
	{
		if (_ICCLIReportCollectionVM == null)
		{
			lock (this)
			{
				if (_ICCLIReportCollectionVM == null)
				{
					_ICCLIReportCollectionVM = new CCLIReportCollectionVM(GetService<IReportRepository>(), GetService<IApp>(), GetService<ICCLIReportAnalyticsEvents>(), GetService<ICCLIReportPrompt>(), GetService<ISongSelectConsumer>(), GetService<IInternetAccess>());
				}
			}
		}
		return _ICCLIReportCollectionVM;
	}

	ICopyrightSettingsVM Jab.IServiceProvider<ICopyrightSettingsVM>.GetService()
	{
		if (_ICopyrightSettingsVM == null)
		{
			lock (this)
			{
				if (_ICopyrightSettingsVM == null)
				{
					_ICopyrightSettingsVM = new CopyrightSettingsVM(GetService<IProPresenterResourceService>(), GetService<ICCLIReportAnalyticsEvents>(), GetService<ICCLIReportCollectionVM>(), GetService<ILocalization>(), GetService<IHyperlinkService>(), GetService<IWebSourceProvider>(), GetService<ISettingsSearchFactory>());
				}
			}
		}
		return _ICopyrightSettingsVM;
	}

	INetworkCommandFactory Jab.IServiceProvider<INetworkCommandFactory>.GetService()
	{
		INetworkCommandFactory networkCommandFactory = IControllerServiceProviderModule.GetNetworkCommandFactory(GetService<IOutputRepository>());
		TryAddDisposable(networkCommandFactory);
		return networkCommandFactory;
	}

	INetworkCommandTrigger Jab.IServiceProvider<INetworkCommandTrigger>.GetService()
	{
		if (_INetworkCommandTrigger == null)
		{
			lock (this)
			{
				if (_INetworkCommandTrigger == null)
				{
					_INetworkCommandTrigger = new NetworkCommandTrigger(GetService<INetworkCommandFactory>());
				}
			}
		}
		return _INetworkCommandTrigger;
	}

	INetworkTriggerDataTransferFactory Jab.IServiceProvider<INetworkTriggerDataTransferFactory>.GetService()
	{
		INetworkTriggerDataTransferFactory networkTriggerDataTransferFactory = IControllerServiceProviderModule.GetNetworkTriggerDataTransferFactory(GetService<IOutputConfiguration>());
		TryAddDisposable(networkTriggerDataTransferFactory);
		return networkTriggerDataTransferFactory;
	}

	IResiController Jab.IServiceProvider<IResiController>.GetService()
	{
		if (_IResiController == null)
		{
			lock (this)
			{
				if (_IResiController == null)
				{
					_IResiController = new ResiController(GetService<IResiPlugin>(), GetService<IUpdateClient>(), GetService<IResiWebClient>(), GetService<IHyperlinkService>());
				}
			}
		}
		return _IResiController;
	}

	ICrashRecovery Jab.IServiceProvider<ICrashRecovery>.GetService()
	{
		if (_ICrashRecovery == null)
		{
			lock (this)
			{
				if (_ICrashRecovery == null)
				{
					_ICrashRecovery = IGlobalServiceProviderModule.GetResiCrashRecovery(GetService<IOutputService>());
				}
			}
		}
		return _ICrashRecovery;
	}

	ICapturePrompt Jab.IServiceProvider<ICapturePrompt>.GetService()
	{
		CapturePrompt capturePrompt = new CapturePrompt(GetService<ITimerFactory>(), GetService<IUiDispatcher>());
		TryAddDisposable(capturePrompt);
		return capturePrompt;
	}

	CaptureController Jab.IServiceProvider<CaptureController>.GetService()
	{
		if (_CaptureController == null)
		{
			lock (this)
			{
				if (_CaptureController == null)
				{
					_CaptureController = new CaptureController(GetService<IProCoreInstance>(), GetService<IOutputService>(), GetService<IResiController>(), GetService<ICrashRecovery>(), GetService<ICapturePrompt>(), GetService<IInternetAccessCheck>());
				}
			}
		}
		return _CaptureController;
	}

	ICaptureService Jab.IServiceProvider<ICaptureService>.GetService()
	{
		ICaptureService captureController = IViewModelsServiceProviderModule.GetCaptureController(GetService<CaptureController>());
		TryAddDisposable(captureController);
		return captureController;
	}

	ITimedPlaybackRepository Jab.IServiceProvider<ITimedPlaybackRepository>.GetService()
	{
		if (_ITimedPlaybackRepository == null)
		{
			lock (this)
			{
				if (_ITimedPlaybackRepository == null)
				{
					_ITimedPlaybackRepository = new TimedPlaybackRepository(GetService<IProCoreInstance>());
				}
			}
		}
		return _ITimedPlaybackRepository;
	}

	ITimelineService Jab.IServiceProvider<ITimelineService>.GetService()
	{
		if (_ITimelineService == null)
		{
			lock (this)
			{
				if (_ITimelineService == null)
				{
					_ITimelineService = new TimelineService(GetService<ITimedPlaybackRepository>());
				}
			}
		}
		return _ITimelineService;
	}

	ITimecodeService Jab.IServiceProvider<ITimecodeService>.GetService()
	{
		if (_ITimecodeService == null)
		{
			lock (this)
			{
				if (_ITimecodeService == null)
				{
					_ITimecodeService = new TimecodeService(GetService<ITimedPlaybackRepository>(), GetService<ITimecodeSettingsRepository>(), GetService<IProPresenterResourceService>());
				}
			}
		}
		return _ITimecodeService;
	}

	ITimelineManager Jab.IServiceProvider<ITimelineManager>.GetService()
	{
		if (_ITimelineManager == null)
		{
			lock (this)
			{
				if (_ITimelineManager == null)
				{
					_ITimelineManager = new TimelineManager(GetService<ITimelineService>(), GetService<IMessageService>(), GetService<ITimelineAnalyticsEvents>(), GetService<ITimecodeService>(), GetService<IEntityFactory>(), GetService<IDebouncerFactory>(), GetService<IOutputConfiguration>());
				}
			}
		}
		return _ITimelineManager;
	}

	ITransferHandlerFactory Jab.IServiceProvider<ITransferHandlerFactory>.GetService()
	{
		TransferHandlerFactory transferHandlerFactory = new TransferHandlerFactory(GetService<IProPresenterResourceService>(), GetService<ITimecodeService>(), GetService<IProPresenterDOFactoryProvider>(), GetService<IUiDispatcher>(), GetService<ITransitionDescriptionCollection>());
		TryAddDisposable(transferHandlerFactory);
		return transferHandlerFactory;
	}

	CoreManager Jab.IServiceProvider<CoreManager>.GetService()
	{
		if (_CoreManager == null)
		{
			lock (this)
			{
				if (_CoreManager == null)
				{
					_CoreManager = new CoreManager(GetService<IProCoreInstance>(), GetService<ssAPIOutput>(), GetService<INetworkCommandTrigger>(), GetService<INetworkTriggerDataTransferFactory>(), GetService<IApp>(), GetService<ITimerFactory>(), GetService<IUiDispatcher>(), GetService<ICaptureService>(), GetService<IDebouncerFactory>(), GetService<ITimelineManager>(), GetService<IGeneral>(), GetService<ISongSelectConsumer>(), GetService<ITimecodeService>(), GetService<IMessageService>(), GetService<IThemeService>(), GetService<IReportRepository>(), GetService<IProPresenterResourceService>(), GetService<IOutputService>(), GetService<IMultiTracksConsumer>(), GetService<ITransferHandlerFactory>(), GetService<IPCOConsumer>(), GetService<IStoredPcoOptions>(), GetService<IProPresenterDOFactoryProvider>(), GetService<IRestClientFactory>());
				}
			}
		}
		return _CoreManager;
	}

	ICoreManager Jab.IServiceProvider<ICoreManager>.GetService()
	{
		ICoreManager coreManager = IControllerServiceProviderModule.GetCoreManager(GetService<CoreManager>());
		TryAddDisposable(coreManager);
		return coreManager;
	}

	IGeneralSettingsVM Jab.IServiceProvider<IGeneralSettingsVM>.GetService()
	{
		if (_IGeneralSettingsVM == null)
		{
			lock (this)
			{
				if (_IGeneralSettingsVM == null)
				{
					_IGeneralSettingsVM = new GeneralSettingsVM(GetService<IGeneral>(), GetService<IApp>(), GetService<ICopyrightSettingsVM>(), GetService<ICoreManager>(), GetService<IFileSelectorService>(), GetService<IUiPreferencesAnalyticEventsPublisher>(), GetService<IProcessHelper>(), GetService<ILocalization>(), GetService<ISettingsSearchFactory>(), GetService<ILogger>(), GetService<IMediaFactory>(), GetService<IImportProcessFactory>(), GetService<IOutputRepository>(), GetService<IHyperlinkService>(), GetService<IWebSourceProvider>(), GetService<ICloudOnboardingService>());
				}
			}
		}
		return _IGeneralSettingsVM;
	}

	ICommandSender Jab.IServiceProvider<ICommandSender>.GetService()
	{
		if (_ICommandSender == null)
		{
			lock (this)
			{
				if (_ICommandSender == null)
				{
					_ICommandSender = new CommandSender(GetService<IProCoreInstance>());
				}
			}
		}
		return _ICommandSender;
	}

	IServerStateHandler Jab.IServiceProvider<IServerStateHandler>.GetService()
	{
		if (_IServerStateHandler == null)
		{
			lock (this)
			{
				if (_IServerStateHandler == null)
				{
					_IServerStateHandler = new ServerStateHandler();
				}
			}
		}
		return _IServerStateHandler;
	}

	INetworkEnvironment Jab.IServiceProvider<INetworkEnvironment>.GetService()
	{
		if (_INetworkEnvironment == null)
		{
			lock (this)
			{
				if (_INetworkEnvironment == null)
				{
					_INetworkEnvironment = new NetworkEnvironment();
				}
			}
		}
		return _INetworkEnvironment;
	}

	ILinkRequestFactory Jab.IServiceProvider<ILinkRequestFactory>.GetService()
	{
		LinkRequestFactory linkRequestFactory = new LinkRequestFactory();
		TryAddDisposable(linkRequestFactory);
		return linkRequestFactory;
	}

	INetworkLinkService Jab.IServiceProvider<INetworkLinkService>.GetService()
	{
		if (_INetworkLinkService == null)
		{
			lock (this)
			{
				if (_INetworkLinkService == null)
				{
					_INetworkLinkService = new NetworkLinkService(GetService<ICommandSender>(), GetService<IServerStateHandler>(), GetService<INetwork>(), GetService<INetworkEnvironment>(), GetService<IUiDispatcher>(), GetService<ILinkRequestFactory>(), GetService<IAirCastConfiguration>(), GetService<INetworkChange>());
				}
			}
		}
		return _INetworkLinkService;
	}

	INetworkLinkPrompt Jab.IServiceProvider<INetworkLinkPrompt>.GetService()
	{
		if (_INetworkLinkPrompt == null)
		{
			lock (this)
			{
				if (_INetworkLinkPrompt == null)
				{
					_INetworkLinkPrompt = new NetworkLinkPrompt(GetService<ILocalization>());
				}
			}
		}
		return _INetworkLinkPrompt;
	}

	INetworkLinkVM Jab.IServiceProvider<INetworkLinkVM>.GetService()
	{
		if (_INetworkLinkVM == null)
		{
			lock (this)
			{
				if (_INetworkLinkVM == null)
				{
					_INetworkLinkVM = new NetworkLinkVM(GetService<INetworkLinkService>(), GetService<INetworkLinkPrompt>(), GetService<INetwork>(), GetService<ILocalization>(), GetService<IHyperlinkService>(), GetService<IWebSourceProvider>(), GetService<ISettingsSearchFactory>());
				}
			}
		}
		return _INetworkLinkVM;
	}

	INetworkSettingsVM Jab.IServiceProvider<INetworkSettingsVM>.GetService()
	{
		if (_INetworkSettingsVM == null)
		{
			lock (this)
			{
				if (_INetworkSettingsVM == null)
				{
					_INetworkSettingsVM = new NetworkSettingsVM(GetService<INetworkLinkVM>(), GetService<ILocalization>(), GetService<INetwork>(), GetService<IHyperlinkService>(), GetService<INetworkDialogService>(), GetService<IServerStateHandler>(), GetService<IWebSourceProvider>(), GetService<ISettingsSearchFactory>());
				}
			}
		}
		return _INetworkSettingsVM;
	}

	IRegistrationUnlockCodeVM Jab.IServiceProvider<IRegistrationUnlockCodeVM>.GetService()
	{
		if (_IRegistrationUnlockCodeVM == null)
		{
			lock (this)
			{
				if (_IRegistrationUnlockCodeVM == null)
				{
					_IRegistrationUnlockCodeVM = ISettingsViewModelsServiceProviderModule.GetRegistrationUnlockCodeVM(GetService<IRegistrationOperationFactory>());
				}
			}
		}
		return _IRegistrationUnlockCodeVM;
	}

	IRegistrationSubpageVMFactory Jab.IServiceProvider<IRegistrationSubpageVMFactory>.GetService()
	{
		RegistrationSubpageVMFactory registrationSubpageVMFactory = new RegistrationSubpageVMFactory(GetService<IHyperlinkService>(), GetService<IRegistrationWebResourceService>(), GetService<IRegistrationOperationFactory>(), GetService<IRegistrationUnlockCodeVM>(), GetService<IRegistrationUserDialogService>(), GetService<IRegistrationStateProvider>());
		TryAddDisposable(registrationSubpageVMFactory);
		return registrationSubpageVMFactory;
	}

	IOrganizationConsumer Jab.IServiceProvider<IOrganizationConsumer>.GetService()
	{
		if (_IOrganizationConsumer == null)
		{
			lock (this)
			{
				if (_IOrganizationConsumer == null)
				{
					_IOrganizationConsumer = GetOrganizationConsumer(GetService<IAuthenticatingApiConsumerFactory>(), GetService<IFlagService>(), GetIOAuth2AuthorizationStore_ProContentRegistrationAuthorizationStorageKey(), GetIOAuth2ClientInfoProvider_ProContentRegistrationAuthorizationInfoProviderKey(), GetService<IRestClientFactory>(), GetService<ILogger>());
				}
			}
		}
		return _IOrganizationConsumer;
	}

	IUserAvatarProvider Jab.IServiceProvider<IUserAvatarProvider>.GetService()
	{
		if (_IUserAvatarProvider == null)
		{
			lock (this)
			{
				if (_IUserAvatarProvider == null)
				{
					_IUserAvatarProvider = new UserAvatarProvider(GetService<IRegistrationStateProvider>(), GetService<IOrganizationConsumer>());
				}
			}
		}
		return _IUserAvatarProvider;
	}

	IRegistrationMainPageVM Jab.IServiceProvider<IRegistrationMainPageVM>.GetService()
	{
		if (_IRegistrationMainPageVM == null)
		{
			lock (this)
			{
				if (_IRegistrationMainPageVM == null)
				{
					_IRegistrationMainPageVM = new RegistrationMainPageVM(GetService<ILocalization>(), GetService<IRegistrationStateProvider>(), GetService<IRegistrationSubpageVMFactory>(), GetService<IRegistrationOperationFactory>(), GetService<ISettingsSearchFactory>(), GetService<IUserAvatarProvider>());
				}
			}
		}
		return _IRegistrationMainPageVM;
	}

	IAccountCenterVM Jab.IServiceProvider<IAccountCenterVM>.GetService()
	{
		if (_IAccountCenterVM == null)
		{
			lock (this)
			{
				if (_IAccountCenterVM == null)
				{
					_IAccountCenterVM = new AccountCenterVM(GetService<IRegistrationStateProvider>(), GetService<ILocalization>(), GetService<IMediaService>(), GetService<IUiScheduler>(), GetService<IHyperlinkService>(), GetService<IWebSourceProvider>(), GetService<ICloudWorkspaceService>(), GetService<ILogger>(), GetService<ICurrentTimeOffset>(), GetService<IUserAvatarProvider>());
				}
			}
		}
		return _IAccountCenterVM;
	}

	IUpdatesSettingsVM Jab.IServiceProvider<IUpdatesSettingsVM>.GetService()
	{
		if (_IUpdatesSettingsVM == null)
		{
			lock (this)
			{
				if (_IUpdatesSettingsVM == null)
				{
					_IUpdatesSettingsVM = new UpdatesSettingsVM(GetService<IAppUpdateService>(), GetService<IApp>(), GetService<IGeneral>(), GetService<IVersionInfoProvider>(), GetService<ILocalization>(), GetService<IHyperlinkService>(), GetService<IWebSourceProvider>(), GetService<ISettingsSearchFactory>(), GetService<IRegistrationWebResourceService>());
				}
			}
		}
		return _IUpdatesSettingsVM;
	}

	IClockSourceProvider Jab.IServiceProvider<IClockSourceProvider>.GetService()
	{
		if (_IClockSourceProvider == null)
		{
			lock (this)
			{
				if (_IClockSourceProvider == null)
				{
					_IClockSourceProvider = new ClockSourceProvider(GetService<IProCoreInstance>(), GetService<IUiDispatcher>());
				}
			}
		}
		return _IClockSourceProvider;
	}

	IClockSourceService Jab.IServiceProvider<IClockSourceService>.GetService()
	{
		if (_IClockSourceService == null)
		{
			lock (this)
			{
				if (_IClockSourceService == null)
				{
					_IClockSourceService = new ClockSourceService(GetService<IClockSourceProvider>(), GetService<IProCoreInstance>(), GetService<IUiDispatcher>());
				}
			}
		}
		return _IClockSourceService;
	}

	IClockSourceVM Jab.IServiceProvider<IClockSourceVM>.GetService()
	{
		if (_IClockSourceVM == null)
		{
			lock (this)
			{
				if (_IClockSourceVM == null)
				{
					_IClockSourceVM = new ClockSourceVM(GetService<IClockSourceService>(), GetService<IDisplay>());
				}
			}
		}
		return _IClockSourceVM;
	}

	IScreenSettingsVM Jab.IServiceProvider<IScreenSettingsVM>.GetService()
	{
		if (_IScreenSettingsVM == null)
		{
			lock (this)
			{
				if (_IScreenSettingsVM == null)
				{
					_IScreenSettingsVM = new ScreenSettingsVM(GetService<ICoreManager>(), GetService<IApp>(), GetService<IAdvanced>(), GetService<IGeneral>(), GetService<ILocalization>(), GetService<IClockSourceVM>(), GetService<ISettingsSearchFactory>(), GetService<IOutputRepository>());
				}
			}
		}
		return _IScreenSettingsVM;
	}

	IInputsSettingsService Jab.IServiceProvider<IInputsSettingsService>.GetService()
	{
		InputsSettingsService inputsSettingsService = new InputsSettingsService(GetService<IOutputRepository>(), GetService<IProCoreInstance>(), GetService<IApp>());
		TryAddDisposable(inputsSettingsService);
		return inputsSettingsService;
	}

	IVideoInputsSettingsVM Jab.IServiceProvider<IVideoInputsSettingsVM>.GetService()
	{
		if (_IVideoInputsSettingsVM == null)
		{
			lock (this)
			{
				if (_IVideoInputsSettingsVM == null)
				{
					_IVideoInputsSettingsVM = new VideoInputsSettingsVM(GetService<IInputsSettingsService>(), GetService<ICoreManager>(), GetService<IFileSelectorService>(), GetService<IImportProcessFactory>(), GetService<IFlagService>(), GetService<IMediaService>(), GetService<IUiDispatcher>(), GetService<IAirCastConfiguration>(), GetService<IAirCastPluginDownload>(), GetService<IFileSystem>());
				}
			}
		}
		return _IVideoInputsSettingsVM;
	}

	IVideoInputItemVMFactory Jab.IServiceProvider<IVideoInputItemVMFactory>.GetService()
	{
		if (_IVideoInputItemVMFactory == null)
		{
			lock (this)
			{
				if (_IVideoInputItemVMFactory == null)
				{
					_IVideoInputItemVMFactory = new VideoInputItemVMFactory();
				}
			}
		}
		return _IVideoInputItemVMFactory;
	}

	IAudioInputsSettingsVM Jab.IServiceProvider<IAudioInputsSettingsVM>.GetService()
	{
		if (_IAudioInputsSettingsVM == null)
		{
			lock (this)
			{
				if (_IAudioInputsSettingsVM == null)
				{
					_IAudioInputsSettingsVM = new AudioInputsSettingsVM(GetService<IInputsSettingsService>(), GetService<ICoreManager>(), GetService<IVideoInputItemVMFactory>(), GetService<IAirCastConfiguration>(), GetService<IAirCastPluginDownload>());
				}
			}
		}
		return _IAudioInputsSettingsVM;
	}

	INdiInputsSettingsVM Jab.IServiceProvider<INdiInputsSettingsVM>.GetService()
	{
		if (_INdiInputsSettingsVM == null)
		{
			lock (this)
			{
				if (_INdiInputsSettingsVM == null)
				{
					_INdiInputsSettingsVM = new NdiInputsSettingsVM(GetService<IAdvanced>(), GetService<ILocalization>(), GetService<IHyperlinkService>(), GetService<IWebSourceProvider>(), GetService<ISettingsSearchFactory>(), GetService<ICoreManager>(), GetService<IDebouncerFactory>(), GetService<INdiInputsSettingsDialogService>());
				}
			}
		}
		return _INdiInputsSettingsVM;
	}

	IInputsSettingsVM Jab.IServiceProvider<IInputsSettingsVM>.GetService()
	{
		if (_IInputsSettingsVM == null)
		{
			lock (this)
			{
				if (_IInputsSettingsVM == null)
				{
					_IInputsSettingsVM = new InputsSettingsVM(GetService<IVideoInputsSettingsVM>(), GetService<IAudioInputsSettingsVM>(), GetService<INdiInputsSettingsVM>(), GetService<IOutputConfiguration>(), GetService<ILocalization>(), GetService<IHyperlinkService>(), GetService<IWebSourceProvider>(), GetService<ISettingsSearchFactory>(), GetService<IAirCastPluginDownload>(), GetService<IAsyncExecutor>(), GetService<IAirCastPrompt>(), GetService<IAirCastConfiguration>());
				}
			}
		}
		return _IInputsSettingsVM;
	}

	IDevicesSettingsVM Jab.IServiceProvider<IDevicesSettingsVM>.GetService()
	{
		if (_IDevicesSettingsVM == null)
		{
			lock (this)
			{
				if (_IDevicesSettingsVM == null)
				{
					_IDevicesSettingsVM = new DevicesSettingsVM(GetService<ICommunicationOutput>(), GetService<ILocalization>(), GetService<IMidiDeviceSettingsVM>(), GetService<IMidiWindowProvider>(), GetService<IHyperlinkService>(), GetService<IWebSourceProvider>(), GetService<ISettingsSearchFactory>());
				}
			}
		}
		return _IDevicesSettingsVM;
	}

	IMediaSettingsVMFactory Jab.IServiceProvider<IMediaSettingsVMFactory>.GetService()
	{
		MediaSettingsVMFactory mediaSettingsVMFactory = new MediaSettingsVMFactory(GetService<ILocalization>());
		TryAddDisposable(mediaSettingsVMFactory);
		return mediaSettingsVMFactory;
	}

	IMediaSearchPathsSettingsVM Jab.IServiceProvider<IMediaSearchPathsSettingsVM>.GetService()
	{
		if (_IMediaSearchPathsSettingsVM == null)
		{
			lock (this)
			{
				if (_IMediaSearchPathsSettingsVM == null)
				{
					_IMediaSearchPathsSettingsVM = new MediaSearchPathsSettingsVM(GetService<IAdvanced>(), GetService<ILocalization>(), GetService<IMediaSettingsVMFactory>(), GetService<IHyperlinkService>(), GetService<IWebSourceProvider>(), GetService<ISettingsSearchFactory>());
				}
			}
		}
		return _IMediaSearchPathsSettingsVM;
	}

	IMediaFilesProvider Jab.IServiceProvider<IMediaFilesProvider>.GetService()
	{
		MediaFilesProvider mediaFilesProvider = new MediaFilesProvider(GetService<IProPresenterResourceService>(), GetService<IFileSystem>(), GetService<IGeneral>(), GetService<IOutputConfiguration>(), GetService<IMaskCollection>());
		TryAddDisposable(mediaFilesProvider);
		return mediaFilesProvider;
	}

	IMediaCleanupService Jab.IServiceProvider<IMediaCleanupService>.GetService()
	{
		if (_IMediaCleanupService == null)
		{
			lock (this)
			{
				if (_IMediaCleanupService == null)
				{
					_IMediaCleanupService = new MediaCleanupService(GetService<IMediaCleanupPrompt>(), GetService<IFileSystem>(), GetService<ILogger>(), GetService<IMediaFilesProvider>(), GetService<IMediaCleanupSizeEventPublisher>(), GetService<IFileUtility>(), GetService<IFileSelectorService>());
				}
			}
		}
		return _IMediaCleanupService;
	}

	IMediaCleanupVM Jab.IServiceProvider<IMediaCleanupVM>.GetService()
	{
		if (_IMediaCleanupVM == null)
		{
			lock (this)
			{
				if (_IMediaCleanupVM == null)
				{
					_IMediaCleanupVM = new MediaCleanupVM(GetService<IMediaCleanupService>());
				}
			}
		}
		return _IMediaCleanupVM;
	}

	IMediaSettingsVM Jab.IServiceProvider<IMediaSettingsVM>.GetService()
	{
		if (_IMediaSettingsVM == null)
		{
			lock (this)
			{
				if (_IMediaSettingsVM == null)
				{
					_IMediaSettingsVM = new MediaSettingsVM(GetService<IMediaSearchPathsSettingsVM>(), GetService<IAdvanced>(), GetService<ILocalization>(), GetService<IHyperlinkService>(), GetService<IWebSourceProvider>(), GetService<ISettingsSearchFactory>(), GetService<IMediaCleanupVM>());
				}
			}
		}
		return _IMediaSettingsVM;
	}

	IAudioSettingsVM Jab.IServiceProvider<IAudioSettingsVM>.GetService()
	{
		if (_IAudioSettingsVM == null)
		{
			lock (this)
			{
				if (_IAudioSettingsVM == null)
				{
					_IAudioSettingsVM = new AudioSettingsVM(GetService<IOutputConfiguration>(), GetService<ILocalization>(), GetService<IHyperlinkService>(), GetService<IWebSourceProvider>(), GetService<ISettingsSearchFactory>(), GetService<IAudioOutputDeviceCollection>());
				}
			}
		}
		return _IAudioSettingsVM;
	}

	IImportSettingsVM Jab.IServiceProvider<IImportSettingsVM>.GetService()
	{
		if (_IImportSettingsVM == null)
		{
			lock (this)
			{
				if (_IImportSettingsVM == null)
				{
					_IImportSettingsVM = new ImportSettingsVM(GetService<IImport>(), GetService<ILocalization>(), GetService<ISettingsSearchFactory>());
				}
			}
		}
		return _IImportSettingsVM;
	}

	IPlanningCenterSettingsVM Jab.IServiceProvider<IPlanningCenterSettingsVM>.GetService()
	{
		if (_IPlanningCenterSettingsVM == null)
		{
			lock (this)
			{
				if (_IPlanningCenterSettingsVM == null)
				{
					_IPlanningCenterSettingsVM = new PlanningCenterSettingsVM(GetService<IPCOConsumer>(), GetService<IProPresenterResourceService>(), GetService<IStoredPcoOptions>(), GetService<ILocalization>(), GetService<IHyperlinkService>(), GetService<IWebSourceProvider>(), GetService<ISettingsSearchFactory>());
				}
			}
		}
		return _IPlanningCenterSettingsVM;
	}

	IMultiTracksSettingsVM Jab.IServiceProvider<IMultiTracksSettingsVM>.GetService()
	{
		if (_IMultiTracksSettingsVM == null)
		{
			lock (this)
			{
				if (_IMultiTracksSettingsVM == null)
				{
					_IMultiTracksSettingsVM = new MultiTracksSettingsVM(GetService<IMultiTracksConsumer>(), GetService<IApp>(), GetService<ILocalization>(), GetService<IUiDispatcher>(), GetService<IHyperlinkService>(), GetService<IWebSourceProvider>(), GetService<ISettingsSearchFactory>());
				}
			}
		}
		return _IMultiTracksSettingsVM;
	}

	IAutoReportDialogPrompt Jab.IServiceProvider<IAutoReportDialogPrompt>.GetService()
	{
		AutoReportDialogPrompt autoReportDialogPrompt = new AutoReportDialogPrompt();
		TryAddDisposable(autoReportDialogPrompt);
		return autoReportDialogPrompt;
	}

	ISongSelectSettingsVM Jab.IServiceProvider<ISongSelectSettingsVM>.GetService()
	{
		if (_ISongSelectSettingsVM == null)
		{
			lock (this)
			{
				if (_ISongSelectSettingsVM == null)
				{
					_ISongSelectSettingsVM = new SongSelectSettingsVM(GetService<ISongSelectConsumer>(), GetService<IApp>(), GetService<IAutoReportDialogPrompt>(), GetService<ILocalization>(), GetService<IHyperlinkService>(), GetService<IWebSourceProvider>(), GetService<ISettingsSearchFactory>());
				}
			}
		}
		return _ISongSelectSettingsVM;
	}

	IResiUpdateVM Jab.IServiceProvider<IResiUpdateVM>.GetService()
	{
		if (_IResiUpdateVM == null)
		{
			lock (this)
			{
				if (_IResiUpdateVM == null)
				{
					_IResiUpdateVM = new ResiUpdateVM(GetService<IResiController>(), GetService<IApp>(), GetService<ITimerFactory>(), GetService<IMessageService>());
				}
			}
		}
		return _IResiUpdateVM;
	}

	ILoginDialogFactory Jab.IServiceProvider<ILoginDialogFactory>.GetService()
	{
		LoginDialogFactory loginDialogFactory = new LoginDialogFactory(GetService<ICookieManagerService>());
		TryAddDisposable(loginDialogFactory);
		return loginDialogFactory;
	}

	IResiPrompt Jab.IServiceProvider<IResiPrompt>.GetService()
	{
		ResiPrompt resiPrompt = new ResiPrompt();
		TryAddDisposable(resiPrompt);
		return resiPrompt;
	}

	IResiAuthorizationInteractor Jab.IServiceProvider<IResiAuthorizationInteractor>.GetService()
	{
		if (_IResiAuthorizationInteractor == null)
		{
			lock (this)
			{
				if (_IResiAuthorizationInteractor == null)
				{
					_IResiAuthorizationInteractor = new ResiAuthorizationInteractor(GetService<IResiWebClient>(), GetService<IResiPlugin>(), GetService<ILoginDialogFactory>(), GetService<IResiPrompt>(), GetService<IMessageService>(), GetService<IInternetAccess>());
				}
			}
		}
		return _IResiAuthorizationInteractor;
	}

	IResiSettingsVM Jab.IServiceProvider<IResiSettingsVM>.GetService()
	{
		if (_IResiSettingsVM == null)
		{
			lock (this)
			{
				if (_IResiSettingsVM == null)
				{
					_IResiSettingsVM = new ResiSettingsVM(GetService<IResiController>(), GetService<IResiAuthorizationInteractor>(), GetService<IResiPrompt>(), GetService<IResiUpdateVM>(), GetService<ILocalization>(), GetService<IHyperlinkService>(), GetService<IWebSourceProvider>(), GetService<ISettingsSearchFactory>());
				}
			}
		}
		return _IResiSettingsVM;
	}

	IIntegrationsSettingsVM Jab.IServiceProvider<IIntegrationsSettingsVM>.GetService()
	{
		if (_IIntegrationsSettingsVM == null)
		{
			lock (this)
			{
				if (_IIntegrationsSettingsVM == null)
				{
					_IIntegrationsSettingsVM = new IntegrationsSettingsVM(GetService<IPlanningCenterSettingsVM>(), GetService<IMultiTracksSettingsVM>(), GetService<ISongSelectSettingsVM>(), GetService<IResiSettingsVM>(), GetService<ILocalization>(), GetService<ISettingsSearchFactory>(), GetService<IGeneral>());
				}
			}
		}
		return _IIntegrationsSettingsVM;
	}

	IGroupLabelItemVMFactory Jab.IServiceProvider<IGroupLabelItemVMFactory>.GetService()
	{
		GroupLabelItemVMFactory groupLabelItemVMFactory = new GroupLabelItemVMFactory();
		TryAddDisposable(groupLabelItemVMFactory);
		return groupLabelItemVMFactory;
	}

	IGroupsSettingsVM Jab.IServiceProvider<IGroupsSettingsVM>.GetService()
	{
		if (_IGroupsSettingsVM == null)
		{
			lock (this)
			{
				if (_IGroupsSettingsVM == null)
				{
					_IGroupsSettingsVM = new GroupsSettingsVM(GetService<IProPresenterResourceService>(), GetService<ILocalization>(), GetService<IGroupLabelItemVMFactory>(), GetService<IHyperlinkService>(), GetService<IWebSourceProvider>(), GetService<ISettingsSearchFactory>());
				}
			}
		}
		return _IGroupsSettingsVM;
	}

	ILabelItemVMFactory Jab.IServiceProvider<ILabelItemVMFactory>.GetService()
	{
		LabelItemVMFactory labelItemVMFactory = new LabelItemVMFactory();
		TryAddDisposable(labelItemVMFactory);
		return labelItemVMFactory;
	}

	ILabelsSettingsVM Jab.IServiceProvider<ILabelsSettingsVM>.GetService()
	{
		if (_ILabelsSettingsVM == null)
		{
			lock (this)
			{
				if (_ILabelsSettingsVM == null)
				{
					_ILabelsSettingsVM = new LabelsSettingsVM(GetService<IProPresenterResourceService>(), GetService<ILocalization>(), GetService<ILabelItemVMFactory>(), GetService<ISettingsSearchFactory>());
				}
			}
		}
		return _ILabelsSettingsVM;
	}

	private ISyncRepository<ISyncData> GetISyncRepository_ISyncData_LocalFileRepositoryKey()
	{
		ISyncRepository<ISyncData> localFileRepository = IGlobalServiceProviderModule.GetLocalFileRepository(GetService<ISyncDataProvider>(), GetService<IOutputService>(), GetService<IErrorReporter>(), GetService<IInputActions>());
		TryAddDisposable(localFileRepository);
		return localFileRepository;
	}

	ISyncController Jab.IServiceProvider<ISyncController>.GetService()
	{
		if (_ISyncController == null)
		{
			lock (this)
			{
				if (_ISyncController == null)
				{
					_ISyncController = GetSyncController(GetISyncRepository_ISyncData_RemoteFileRepositoryKey(), GetISyncRepository_ISyncData_LocalFileRepositoryKey(), GetService<ISyncActionProvider>(), GetService<ISync>(), GetService<ILocalization>());
				}
			}
		}
		return _ISyncController;
	}

	ISyncSettingsVM Jab.IServiceProvider<ISyncSettingsVM>.GetService()
	{
		if (_ISyncSettingsVM == null)
		{
			lock (this)
			{
				if (_ISyncSettingsVM == null)
				{
					_ISyncSettingsVM = new SyncSettingsVM(GetService<ISync>(), GetService<ISyncController>(), GetService<IFileSelectorService>(), GetService<ILocalization>(), GetService<IFileSystem>(), GetService<IHyperlinkService>(), GetService<IWebSourceProvider>(), GetService<ISettingsSearchFactory>());
				}
			}
		}
		return _ISyncSettingsVM;
	}

	IEnumerable<ISettingsListItem> Jab.IServiceProvider<IEnumerable<ISettingsListItem>>.GetService()
	{
		IEnumerable<ISettingsListItem> settingsVMs = GetSettingsVMs(GetService<IRegistrationMainPageVM>(), GetService<IGeneralSettingsVM>(), GetService<IUpdatesSettingsVM>(), GetService<IScreenSettingsVM>(), GetService<IAudioSettingsVM>(), GetService<INetworkSettingsVM>(), GetService<IInputsSettingsVM>(), GetService<IDevicesSettingsVM>(), GetService<IMediaSettingsVM>(), GetService<IImportSettingsVM>(), GetService<IIntegrationsSettingsVM>(), GetService<IGroupsSettingsVM>(), GetService<ILabelsSettingsVM>(), GetService<IFlagService>());
		TryAddDisposable(settingsVMs);
		return settingsVMs;
	}

	ISettingsSearchEngine Jab.IServiceProvider<ISettingsSearchEngine>.GetService()
	{
		if (_ISettingsSearchEngine == null)
		{
			lock (this)
			{
				if (_ISettingsSearchEngine == null)
				{
					_ISettingsSearchEngine = ISettingsViewModelsServiceProviderModule.GetSettingsSearchEngine(GetService<IEnumerable<ISettingsListItem>>(), GetService<IFileSystem>());
				}
			}
		}
		return _ISettingsSearchEngine;
	}

	ISettingsSearchVM Jab.IServiceProvider<ISettingsSearchVM>.GetService()
	{
		if (_ISettingsSearchVM == null)
		{
			lock (this)
			{
				if (_ISettingsSearchVM == null)
				{
					_ISettingsSearchVM = new SettingsSearchVM(GetService<ISettingsSearchEngine>(), GetService<ISettingsSearchFactory>());
				}
			}
		}
		return _ISettingsSearchVM;
	}

	ISettingsNavigationVM Jab.IServiceProvider<ISettingsNavigationVM>.GetService()
	{
		if (_ISettingsNavigationVM == null)
		{
			lock (this)
			{
				if (_ISettingsNavigationVM == null)
				{
					_ISettingsNavigationVM = new SettingsNavigationVM();
				}
			}
		}
		return _ISettingsNavigationVM;
	}

	ISettingsVM Jab.IServiceProvider<ISettingsVM>.GetService()
	{
		if (_ISettingsVM == null)
		{
			lock (this)
			{
				if (_ISettingsVM == null)
				{
					_ISettingsVM = new SettingsVM(GetService<IEnumerable<ISettingsListItem>>(), GetService<ISettingsSearchVM>(), GetService<ISettingsNavigationVM>(), GetService<ICoreManager>(), GetService<IMessageService>());
				}
			}
		}
		return _ISettingsVM;
	}

	INotificationVMFactory Jab.IServiceProvider<INotificationVMFactory>.GetService()
	{
		if (_INotificationVMFactory == null)
		{
			lock (this)
			{
				if (_INotificationVMFactory == null)
				{
					_INotificationVMFactory = new NotificationVMFactory();
				}
			}
		}
		return _INotificationVMFactory;
	}

	IRegistrationRequestSender Jab.IServiceProvider<IRegistrationRequestSender>.GetService()
	{
		IRegistrationRequestSender registrationClient = IRegistrationServiceProviderModule.GetRegistrationClient(GetService<RegistrationClient>());
		TryAddDisposable(registrationClient);
		return registrationClient;
	}

	INotificationCallbackHandler Jab.IServiceProvider<INotificationCallbackHandler>.GetService()
	{
		INotificationCallbackHandler notificationCallbackHandler = IRegistrationServiceProviderModule.GetNotificationCallbackHandler(GetService<NotificationCallbackHandler>());
		TryAddDisposable(notificationCallbackHandler);
		return notificationCallbackHandler;
	}

	INotificationService Jab.IServiceProvider<INotificationService>.GetService()
	{
		if (_INotificationService == null)
		{
			lock (this)
			{
				if (_INotificationService == null)
				{
					_INotificationService = new NotificationService(GetService<IRegistrationRequestSender>(), GetService<INotificationCallbackHandler>(), GetService<IUiScheduler>());
				}
			}
		}
		return _INotificationService;
	}

	INotificationCollectionVM Jab.IServiceProvider<INotificationCollectionVM>.GetService()
	{
		if (_INotificationCollectionVM == null)
		{
			lock (this)
			{
				if (_INotificationCollectionVM == null)
				{
					_INotificationCollectionVM = new NotificationCollectionVM(GetService<INotificationService>(), GetService<IHyperlinkService>(), GetService<INotificationVMFactory>(), GetService<ITimerFactory>());
				}
			}
		}
		return _INotificationCollectionVM;
	}

	IChangeDirectoryProcessFactory Jab.IServiceProvider<IChangeDirectoryProcessFactory>.GetService()
	{
		ChangeDirectoryProcessFactory changeDirectoryProcessFactory = new ChangeDirectoryProcessFactory(GetService<IUiDispatcher>(), GetService<IAsyncExecutor>(), GetService<IMediaService>(), GetService<ICrdtProtoDirectoryFileScanner>());
		TryAddDisposable(changeDirectoryProcessFactory);
		return changeDirectoryProcessFactory;
	}

	IChangeWorkspaceHandler Jab.IServiceProvider<IChangeWorkspaceHandler>.GetService()
	{
		if (_IChangeWorkspaceHandler == null)
		{
			lock (this)
			{
				if (_IChangeWorkspaceHandler == null)
				{
					_IChangeWorkspaceHandler = new ChangeWorkspaceHandler(GetService<IChangeDirectoryProcessFactory>(), GetService<ICommonPathsWrapper>(), GetService<ICoreManager>());
				}
			}
		}
		return _IChangeWorkspaceHandler;
	}

	CloudOnboardingVM Jab.IServiceProvider<CloudOnboardingVM>.GetService()
	{
		if (_CloudOnboardingVM == null)
		{
			lock (this)
			{
				if (_CloudOnboardingVM == null)
				{
					_CloudOnboardingVM = new CloudOnboardingVM(GetService<ICloudOnboardingService>(), GetService<ICloudOnboardingAnalyticsEventPublisher>());
				}
			}
		}
		return _CloudOnboardingVM;
	}

	ICloudOnboardingVM Jab.IServiceProvider<ICloudOnboardingVM>.GetService()
	{
		ICloudOnboardingVM cloudOnboardingVM = ISettingsViewModelsServiceProviderModule.GetCloudOnboardingVM(GetService<CloudOnboardingVM>());
		TryAddDisposable(cloudOnboardingVM);
		return cloudOnboardingVM;
	}

	ICloudOnboardingShellNavigator Jab.IServiceProvider<ICloudOnboardingShellNavigator>.GetService()
	{
		ICloudOnboardingShellNavigator cloudOnboardingVM = ISettingsViewModelsServiceProviderModule.GetCloudOnboardingVM(GetService<CloudOnboardingVM>());
		TryAddDisposable(cloudOnboardingVM);
		return cloudOnboardingVM;
	}

	ICloudOnboardingEligibilityVM Jab.IServiceProvider<ICloudOnboardingEligibilityVM>.GetService()
	{
		CloudOnboardingEligibilityVM cloudOnboardingEligibilityVM = new CloudOnboardingEligibilityVM(GetService<ICloudOnboardingService>(), GetService<IHyperlinkService>(), GetService<IRegistrationWebResourceService>(), GetService<IUiDispatcher>(), GetService<IWebSourceProvider>(), GetService<ICloudOnboardingShellNavigator>(), GetService<IMessageDialogService>(), GetService<ILogger>());
		TryAddDisposable(cloudOnboardingEligibilityVM);
		return cloudOnboardingEligibilityVM;
	}

	ICloudOnboardingManageMediaVM Jab.IServiceProvider<ICloudOnboardingManageMediaVM>.GetService()
	{
		CloudOnboardingManageMediaVM cloudOnboardingManageMediaVM = new CloudOnboardingManageMediaVM(GetService<ICloudOnboardingShellNavigator>());
		TryAddDisposable(cloudOnboardingManageMediaVM);
		return cloudOnboardingManageMediaVM;
	}

	ICloudOnboardingPricingVM Jab.IServiceProvider<ICloudOnboardingPricingVM>.GetService()
	{
		CloudOnboardingPricingVM cloudOnboardingPricingVM = new CloudOnboardingPricingVM(GetService<ICloudOnboardingService>(), GetService<IHyperlinkService>(), GetService<IWebSourceProvider>(), GetService<ICloudOnboardingShellNavigator>());
		TryAddDisposable(cloudOnboardingPricingVM);
		return cloudOnboardingPricingVM;
	}

	ICloudOnboardingDoneVM Jab.IServiceProvider<ICloudOnboardingDoneVM>.GetService()
	{
		CloudOnboardingDoneVM cloudOnboardingDoneVM = new CloudOnboardingDoneVM(GetService<IHyperlinkService>(), GetService<IWebSourceProvider>(), GetService<ICloudOnboardingService>(), GetService<ICloudOnboardingShellNavigator>());
		TryAddDisposable(cloudOnboardingDoneVM);
		return cloudOnboardingDoneVM;
	}

	ICloudOnboardingLocalWorkspacesVM Jab.IServiceProvider<ICloudOnboardingLocalWorkspacesVM>.GetService()
	{
		CloudOnboardingLocalWorkspacesVM cloudOnboardingLocalWorkspacesVM = new CloudOnboardingLocalWorkspacesVM(GetService<ICloudOnboardingShellNavigator>());
		TryAddDisposable(cloudOnboardingLocalWorkspacesVM);
		return cloudOnboardingLocalWorkspacesVM;
	}

	ICloudTeaseVM Jab.IServiceProvider<ICloudTeaseVM>.GetService()
	{
		CloudTeaseVM cloudTeaseVM = new CloudTeaseVM(GetService<IHyperlinkService>(), GetService<IWebSourceProvider>(), GetService<ICloudOnboardingService>(), GetService<ILogger>());
		TryAddDisposable(cloudTeaseVM);
		return cloudTeaseVM;
	}

	ICloudTeaseWindowProvider Jab.IServiceProvider<ICloudTeaseWindowProvider>.GetService()
	{
		CloudTeaseWindowProvider cloudTeaseWindowProvider = new CloudTeaseWindowProvider(GetService<ICloudTeaseVM>(), GetService<ICloudOnboardingService>(), GetService<IAfterStartupCompleteQueue>());
		TryAddDisposable(cloudTeaseWindowProvider);
		return cloudTeaseWindowProvider;
	}

	IManageWorkspacesWindowProvider Jab.IServiceProvider<IManageWorkspacesWindowProvider>.GetService()
	{
		if (_IManageWorkspacesWindowProvider == null)
		{
			lock (this)
			{
				if (_IManageWorkspacesWindowProvider == null)
				{
					_IManageWorkspacesWindowProvider = new ManageWorkspacesWindowProvider(GetService<ILocalization>(), GetService<IFileService>(), GetService<IUiDispatcher>());
				}
			}
		}
		return _IManageWorkspacesWindowProvider;
	}

	IMissingFontVM Jab.IServiceProvider<IMissingFontVM>.GetService()
	{
		MissingFontVM missingFontVM = new MissingFontVM(GetService<IMissingFontService>(), GetService<ILocalization>(), GetService<IFontReplacementEventPublisher>());
		TryAddDisposable(missingFontVM);
		return missingFontVM;
	}

	ICalendarPrompt Jab.IServiceProvider<ICalendarPrompt>.GetService()
	{
		CalendarPrompt calendarPrompt = new CalendarPrompt();
		TryAddDisposable(calendarPrompt);
		return calendarPrompt;
	}

	IRTMPPrompt Jab.IServiceProvider<IRTMPPrompt>.GetService()
	{
		RTMPPrompt rTMPPrompt = new RTMPPrompt();
		TryAddDisposable(rTMPPrompt);
		return rTMPPrompt;
	}

	IProContentDialogService Jab.IServiceProvider<IProContentDialogService>.GetService()
	{
		ProContentDialogService proContentDialogService = new ProContentDialogService(GetService<IProPresenterResourceService>(), GetService<IApp>(), GetService<ILocalization>(), GetService<IUriCacheService<NullableBitmapSource>>(), GetService<IUriCacheService<IReadOnlyList<IAnimationFrame>>>(), GetService<IMediaImportService>(), GetService<IMediaFactory>(), GetService<IOutputRepository>(), GetService<IFlagService>());
		TryAddDisposable(proContentDialogService);
		return proContentDialogService;
	}

	IMediaImportDownloadDialogService Jab.IServiceProvider<IMediaImportDownloadDialogService>.GetService()
	{
		MediaImportDownloadDialogService mediaImportDownloadDialogService = new MediaImportDownloadDialogService(GetService<IProPresenterResourceService>(), GetService<IApp>(), GetService<IMediaImportService>(), GetService<IMediaFactory>(), GetService<IOutputRepository>(), GetService<IFlagService>());
		TryAddDisposable(mediaImportDownloadDialogService);
		return mediaImportDownloadDialogService;
	}

	IDownloadsDialogService Jab.IServiceProvider<IDownloadsDialogService>.GetService()
	{
		DownloadsDialogService downloadsDialogService = new DownloadsDialogService();
		TryAddDisposable(downloadsDialogService);
		return downloadsDialogService;
	}

	IMediaCueThumbnailOverlayVMFactory Jab.IServiceProvider<IMediaCueThumbnailOverlayVMFactory>.GetService()
	{
		MediaCueThumbnailOverlayVMFactory mediaCueThumbnailOverlayVMFactory = new MediaCueThumbnailOverlayVMFactory(GetService<IDownloadManager>(), GetService<IFileSelectorService>(), GetService<IRemoteFileLoader>(), GetService<IImportProcessFactory>(), GetService<IUiScheduler>());
		TryAddDisposable(mediaCueThumbnailOverlayVMFactory);
		return mediaCueThumbnailOverlayVMFactory;
	}

	IDownloadVMsFactory Jab.IServiceProvider<IDownloadVMsFactory>.GetService()
	{
		DownloadVMsFactory downloadVMsFactory = new DownloadVMsFactory(GetService<ILocalization>(), GetService<IUriCacheService<NullableBitmapSource>>(), GetService<IUiScheduler>());
		TryAddDisposable(downloadVMsFactory);
		return downloadVMsFactory;
	}

	IPropPrompts Jab.IServiceProvider<IPropPrompts>.GetService()
	{
		PropPrompts propPrompts = new PropPrompts();
		TryAddDisposable(propPrompts);
		return propPrompts;
	}

	IHardwareAlphaConfigurationVMFactory Jab.IServiceProvider<IHardwareAlphaConfigurationVMFactory>.GetService()
	{
		HardwareAlphaConfigurationVMFactory hardwareAlphaConfigurationVMFactory = new HardwareAlphaConfigurationVMFactory();
		TryAddDisposable(hardwareAlphaConfigurationVMFactory);
		return hardwareAlphaConfigurationVMFactory;
	}

	IAlphaKeySettingsVMFactory Jab.IServiceProvider<IAlphaKeySettingsVMFactory>.GetService()
	{
		AlphaKeySettingsVMFactory alphaKeySettingsVMFactory = new AlphaKeySettingsVMFactory(GetService<IHardwareAlphaConfigurationVMFactory>(), GetService<IHyperlinkService>(), GetService<IApiService>());
		TryAddDisposable(alphaKeySettingsVMFactory);
		return alphaKeySettingsVMFactory;
	}

	ICaptureController Jab.IServiceProvider<ICaptureController>.GetService()
	{
		ICaptureController captureController = IViewModelsServiceProviderModule.GetCaptureController(GetService<CaptureController>());
		TryAddDisposable(captureController);
		return captureController;
	}

	IResiService Jab.IServiceProvider<IResiService>.GetService()
	{
		IResiService captureController = IViewModelsServiceProviderModule.GetCaptureController(GetService<CaptureController>());
		TryAddDisposable(captureController);
		return captureController;
	}

	IUserFeedbackConsumer Jab.IServiceProvider<IUserFeedbackConsumer>.GetService()
	{
		UserFeedbackConsumer userFeedbackConsumer = new UserFeedbackConsumer(GetService<ILogger>(), GetService<IRestClientFactory>(), GetService<IApiService>());
		TryAddDisposable(userFeedbackConsumer);
		return userFeedbackConsumer;
	}

	IBuildAppMetaDataFile Jab.IServiceProvider<IBuildAppMetaDataFile>.GetService()
	{
		ApplicationDataFileBuilder applicationDataFileBuilder = new ApplicationDataFileBuilder(GetService<IOutputService>(), GetService<IFileSystem>(), GetService<ILogger>(), GetService<IGeneral>(), GetService<IVersionInfoProvider>(), GetService<IAssemblyInfoProvider>(), GetService<IFlagService>());
		TryAddDisposable(applicationDataFileBuilder);
		return applicationDataFileBuilder;
	}

	IUserAttachmentVMFactory Jab.IServiceProvider<IUserAttachmentVMFactory>.GetService()
	{
		UserAttachmentVMFactory userAttachmentVMFactory = new UserAttachmentVMFactory(GetService<IUserFeedbackConsumer>(), GetService<ILogger>(), GetService<IFileSystem>(), GetService<IProcessHelper>(), GetService<IBuildAppMetaDataFile>(), GetService<ISystemInfoProvider>(), GetService<IWorkspaceService>(), GetService<ICommonPathsWrapper>());
		TryAddDisposable(userAttachmentVMFactory);
		return userAttachmentVMFactory;
	}

	IAttachmentsUploader Jab.IServiceProvider<IAttachmentsUploader>.GetService()
	{
		if (_IAttachmentsUploader == null)
		{
			lock (this)
			{
				if (_IAttachmentsUploader == null)
				{
					_IAttachmentsUploader = new AttachmentsUploader();
				}
			}
		}
		return _IAttachmentsUploader;
	}

	IAttachmentUploadJobFactory Jab.IServiceProvider<IAttachmentUploadJobFactory>.GetService()
	{
		AttachmentUploadJobFactory attachmentUploadJobFactory = new AttachmentUploadJobFactory(GetService<IRestClientFactory>(), GetService<IFileSystem>(), GetService<ILogger>());
		TryAddDisposable(attachmentUploadJobFactory);
		return attachmentUploadJobFactory;
	}

	IFeedbackVM Jab.IServiceProvider<IFeedbackVM>.GetService()
	{
		if (_IFeedbackVM == null)
		{
			lock (this)
			{
				if (_IFeedbackVM == null)
				{
					_IFeedbackVM = new FeedbackVM(GetService<ILogger>(), GetService<IUserFeedbackConsumer>(), GetService<IRegistrationStateProvider>(), GetService<IUserAttachmentVMFactory>(), GetService<IInternetAccessCheck>(), GetService<IAttachmentsUploader>(), GetService<IAttachmentUploadJobFactory>(), GetService<IHyperlinkService>(), GetService<IMessageDialogService>());
				}
			}
		}
		return _IFeedbackVM;
	}

	ICrashReportingVM Jab.IServiceProvider<ICrashReportingVM>.GetService()
	{
		if (_ICrashReportingVM == null)
		{
			lock (this)
			{
				if (_ICrashReportingVM == null)
				{
					_ICrashReportingVM = IViewModelsServiceProviderModule.GetCrashReportingVM(GetService<ILogger>(), GetService<IUserFeedbackConsumer>(), GetService<IRegistrationStateProvider>(), GetService<IFileSystem>(), GetService<IUserAttachmentVMFactory>(), GetService<IInternetAccessCheck>(), GetService<IAttachmentsUploader>(), GetService<IAttachmentUploadJobFactory>(), GetService<IGeneral>(), GetService<IHyperlinkService>(), GetService<IMessageDialogService>());
				}
			}
		}
		return _ICrashReportingVM;
	}

	IAttachmentUploadVM Jab.IServiceProvider<IAttachmentUploadVM>.GetService()
	{
		if (_IAttachmentUploadVM == null)
		{
			lock (this)
			{
				if (_IAttachmentUploadVM == null)
				{
					_IAttachmentUploadVM = new AttachmentUploadVM(GetService<IAttachmentsUploader>());
				}
			}
		}
		return _IAttachmentUploadVM;
	}

	ICrashReportUserFeedbackDialogProvider Jab.IServiceProvider<ICrashReportUserFeedbackDialogProvider>.GetService()
	{
		CrashReportUserFeedbackDialogProvider crashReportUserFeedbackDialogProvider = new CrashReportUserFeedbackDialogProvider(GetService<ICrashReportingVM>(), GetService<IFeedbackVM>(), GetService<ILogger>(), GetService<ILocalization>());
		TryAddDisposable(crashReportUserFeedbackDialogProvider);
		return crashReportUserFeedbackDialogProvider;
	}

	private System.IO.Stream GetStream_WhatsNewContentProviderFromJsonFileContentKey()
	{
		System.IO.Stream embeddedWhatsNewContent = GetEmbeddedWhatsNewContent();
		TryAddDisposable(embeddedWhatsNewContent);
		return embeddedWhatsNewContent;
	}

	IWhatsNewContentProviderFromJson Jab.IServiceProvider<IWhatsNewContentProviderFromJson>.GetService()
	{
		IWhatsNewContentProviderFromJson whatsNewContentProviderFromJson = GetWhatsNewContentProviderFromJson(GetStream_WhatsNewContentProviderFromJsonFileContentKey());
		TryAddDisposable(whatsNewContentProviderFromJson);
		return whatsNewContentProviderFromJson;
	}

	IFeatureFactory Jab.IServiceProvider<IFeatureFactory>.GetService()
	{
		FeatureFactory featureFactory = new FeatureFactory(GetService<ILocalization>(), GetService<IFileSystem>(), GetService<IHyperlinkService>());
		TryAddDisposable(featureFactory);
		return featureFactory;
	}

	IWhatsNewV2VM Jab.IServiceProvider<IWhatsNewV2VM>.GetService()
	{
		if (_IWhatsNewV2VM == null)
		{
			lock (this)
			{
				if (_IWhatsNewV2VM == null)
				{
					_IWhatsNewV2VM = new WhatsNewV2VM(GetService<IWhatsNewContentProviderFromJson>(), GetService<IFeatureFactory>(), GetService<IHyperlinkService>(), GetService<IWebSourceProvider>(), GetService<IApp>(), GetService<IFlagService>(), GetService<IVersionInfoProvider>());
				}
			}
		}
		return _IWhatsNewV2VM;
	}

	IMediaActionService Jab.IServiceProvider<IMediaActionService>.GetService()
	{
		if (_IMediaActionService == null)
		{
			lock (this)
			{
				if (_IMediaActionService == null)
				{
					_IMediaActionService = new MediaActionService(GetService<ssAPIOutput>(), GetService<IProPresenterResourceService>());
				}
			}
		}
		return _IMediaActionService;
	}

	ITimelineVMFactory Jab.IServiceProvider<ITimelineVMFactory>.GetService()
	{
		TimelineVMFactory timelineVMFactory = new TimelineVMFactory(GetService<IMediaActionService>(), GetService<ITimecodeService>(), GetService<IApp>(), GetService<ITimelineManager>(), GetService<IInputActions>(), GetService<IImportProcessFactory>(), GetService<IMediaFactory>(), GetService<ITransitionDescriptionCollection>());
		TryAddDisposable(timelineVMFactory);
		return timelineVMFactory;
	}

	ITimelineItemVMFactory Jab.IServiceProvider<ITimelineItemVMFactory>.GetService()
	{
		TimelineVMFactory timelineVMFactory = new TimelineVMFactory(GetService<IMediaActionService>(), GetService<ITimecodeService>(), GetService<IApp>(), GetService<ITimelineManager>(), GetService<IInputActions>(), GetService<IImportProcessFactory>(), GetService<IMediaFactory>(), GetService<ITransitionDescriptionCollection>());
		TryAddDisposable(timelineVMFactory);
		return timelineVMFactory;
	}

	IWorkspaceItemVMFactory Jab.IServiceProvider<IWorkspaceItemVMFactory>.GetService()
	{
		WorkspaceItemVMFactory workspaceItemVMFactory = new WorkspaceItemVMFactory();
		TryAddDisposable(workspaceItemVMFactory);
		return workspaceItemVMFactory;
	}

	IActionsMenuVMFactory Jab.IServiceProvider<IActionsMenuVMFactory>.GetService()
	{
		ActionsMenuVMFactory actionsMenuVMFactory = new ActionsMenuVMFactory(GetService<IDownloadManager>(), GetService<IProPresenterResourceService>(), GetService<IOutputService>(), GetService<IFileSelectorService>(), GetService<IRemoteFileLoader>(), GetService<IImportProcessFactory>(), GetService<IUiScheduler>(), GetService<IApp>(), GetService<IMediaActionService>(), GetService<IProcessHelper>(), GetService<IMediaFactory>(), GetService<IOutputConfiguration>(), GetService<ITransitionDescriptionCollection>());
		TryAddDisposable(actionsMenuVMFactory);
		return actionsMenuVMFactory;
	}

	IOutputScreenVMFactory Jab.IServiceProvider<IOutputScreenVMFactory>.GetService()
	{
		OutputScreenVMFactory outputScreenVMFactory = new OutputScreenVMFactory();
		TryAddDisposable(outputScreenVMFactory);
		return outputScreenVMFactory;
	}

	IScreenSelectorVM Jab.IServiceProvider<IScreenSelectorVM>.GetService()
	{
		if (_IScreenSelectorVM == null)
		{
			lock (this)
			{
				if (_IScreenSelectorVM == null)
				{
					_IScreenSelectorVM = new ScreenSelectorVM(GetService<IOutputService>(), GetService<IOutputScreenVMFactory>());
				}
			}
		}
		return _IScreenSelectorVM;
	}

	IWindowedOutputVM Jab.IServiceProvider<IWindowedOutputVM>.GetService()
	{
		if (_IWindowedOutputVM == null)
		{
			lock (this)
			{
				if (_IWindowedOutputVM == null)
				{
					_IWindowedOutputVM = IViewModelsServiceProviderModule.GetWindowdOutputVM(GetService<IProCoreInstance>(), GetService<IOutputScreenVMFactory>(), GetService<IInputActions>());
				}
			}
		}
		return _IWindowedOutputVM;
	}

	IOutputPreviewVMFactory Jab.IServiceProvider<IOutputPreviewVMFactory>.GetService()
	{
		OutputPreviewVMFactory outputPreviewVMFactory = new OutputPreviewVMFactory(GetService<ICoreManager>());
		TryAddDisposable(outputPreviewVMFactory);
		return outputPreviewVMFactory;
	}

	IInternalCoreManager Jab.IServiceProvider<IInternalCoreManager>.GetService()
	{
		IInternalCoreManager coreManager = IControllerServiceProviderModule.GetCoreManager(GetService<CoreManager>());
		TryAddDisposable(coreManager);
		return coreManager;
	}

	ITriggeringFactory Jab.IServiceProvider<ITriggeringFactory>.GetService()
	{
		TriggerServiceFactory triggerServiceFactory = new TriggerServiceFactory(GetService<IInternalCoreManager>(), GetService<IMessageService>());
		TryAddDisposable(triggerServiceFactory);
		return triggerServiceFactory;
	}

	ICalendarService Jab.IServiceProvider<ICalendarService>.GetService()
	{
		if (_ICalendarService == null)
		{
			lock (this)
			{
				if (_ICalendarService == null)
				{
					_ICalendarService = new CalendarService(GetService<ITriggeringFactory>(), GetService<IProPresenterResourceService>());
				}
			}
		}
		return _ICalendarService;
	}

	IExportService Jab.IServiceProvider<IExportService>.GetService()
	{
		ExportService exportService = new ExportService(GetService<IExportProcessFactory>());
		TryAddDisposable(exportService);
		return exportService;
	}

	ILibraryService Jab.IServiceProvider<ILibraryService>.GetService()
	{
		if (_ILibraryService == null)
		{
			lock (this)
			{
				if (_ILibraryService == null)
				{
					_ILibraryService = new LibraryService(GetService<ICoreManager>(), GetService<ICalendarService>(), GetService<IExportService>(), GetService<IMatchSongsInteractor>());
				}
			}
		}
		return _ILibraryService;
	}

	IClipboardProvider Jab.IServiceProvider<IClipboardProvider>.GetService()
	{
		if (_IClipboardProvider == null)
		{
			lock (this)
			{
				if (_IClipboardProvider == null)
				{
					_IClipboardProvider = new ClipboardProvider();
				}
			}
		}
		return _IClipboardProvider;
	}

	IPasteStrategy Jab.IServiceProvider<IPasteStrategy>.GetService()
	{
		if (_IPasteStrategy == null)
		{
			lock (this)
			{
				if (_IPasteStrategy == null)
				{
					_IPasteStrategy = new PasteStrategy(GetService<IClipboardProvider>(), GetService<IProPresenterDOFactoryProvider>());
				}
			}
		}
		return _IPasteStrategy;
	}

	IEditorService Jab.IServiceProvider<IEditorService>.GetService()
	{
		IEditorService editorService = IViewModelsServiceProviderModule.GetEditorService(GetService<IInternalCoreManager>(), GetService<IOutputService>(), GetService<IPasteStrategy>(), GetService<IMetadataLoader>(), GetService<IUiDispatcher>(), GetService<ITriggeringFactory>());
		TryAddDisposable(editorService);
		return editorService;
	}

	PlaylistTemplateCollection Jab.IServiceProvider<PlaylistTemplateCollection>.GetService()
	{
		PlaylistTemplateCollection playlistTemplateCollection = IViewModelsServiceProviderModule.GetPlaylistTemplateCollection();
		TryAddDisposable(playlistTemplateCollection);
		return playlistTemplateCollection;
	}

	IPlaylistTemplatesService Jab.IServiceProvider<IPlaylistTemplatesService>.GetService()
	{
		PlaylistTemplatesService playlistTemplatesService = new PlaylistTemplatesService(GetService<PlaylistTemplateCollection>());
		TryAddDisposable(playlistTemplatesService);
		return playlistTemplatesService;
	}

	ISizeProvider Jab.IServiceProvider<ISizeProvider>.GetService()
	{
		if (_ISizeProvider == null)
		{
			lock (this)
			{
				if (_ISizeProvider == null)
				{
					_ISizeProvider = new DefaultScreenSizeProvider(GetService<IOutputConfiguration>());
				}
			}
		}
		return _ISizeProvider;
	}

	IProPresenterCueVMFactory Jab.IServiceProvider<IProPresenterCueVMFactory>.GetService()
	{
		IProPresenterCueVMFactory proPresenterCueVMFactory = IViewModelsServiceProviderModule.GetProPresenterCueVMFactory(GetService<IProPresenterResourceService>());
		TryAddDisposable(proPresenterCueVMFactory);
		return proPresenterCueVMFactory;
	}

	IProContentDownloader Jab.IServiceProvider<IProContentDownloader>.GetService()
	{
		IProContentDownloader proContentDownloader = CreateProContentDownloader(GetService<IMediaService>(), GetService<IProContentDialogService>(), GetService<IApp>(), GetService<IProContentUserInteractionBehavior>());
		TryAddDisposable(proContentDownloader);
		return proContentDownloader;
	}

	IMacroPrompt Jab.IServiceProvider<IMacroPrompt>.GetService()
	{
		if (_IMacroPrompt == null)
		{
			lock (this)
			{
				if (_IMacroPrompt == null)
				{
					_IMacroPrompt = new MacroPrompt();
				}
			}
		}
		return _IMacroPrompt;
	}

	ISlidePreviewService Jab.IServiceProvider<ISlidePreviewService>.GetService()
	{
		SlidePreviewService slidePreviewService = new SlidePreviewService();
		TryAddDisposable(slidePreviewService);
		return slidePreviewService;
	}

	PropAutoClearHandler Jab.IServiceProvider<PropAutoClearHandler>.GetService()
	{
		if (_PropAutoClearHandler == null)
		{
			lock (this)
			{
				if (_PropAutoClearHandler == null)
				{
					_PropAutoClearHandler = new PropAutoClearHandler(GetService<IProCoreInstance>());
				}
			}
		}
		return _PropAutoClearHandler;
	}

	IPropAutoClearService Jab.IServiceProvider<IPropAutoClearService>.GetService()
	{
		if (_IPropAutoClearService == null)
		{
			lock (this)
			{
				if (_IPropAutoClearService == null)
				{
					_IPropAutoClearService = ISendDataServiceProviderModule.GetPropAutoClearHandler(GetService<PropAutoClearHandler>());
				}
			}
		}
		return _IPropAutoClearService;
	}

	ILegacyPurchaseBiblesDialogService Jab.IServiceProvider<ILegacyPurchaseBiblesDialogService>.GetService()
	{
		LegacyPurchaseBiblesDialogService legacyPurchaseBiblesDialogService = new LegacyPurchaseBiblesDialogService(GetService<IWebSourceProvider>());
		TryAddDisposable(legacyPurchaseBiblesDialogService);
		return legacyPurchaseBiblesDialogService;
	}

	IMediaValidator Jab.IServiceProvider<IMediaValidator>.GetService()
	{
		FillMediaValidator fillMediaValidator = new FillMediaValidator();
		TryAddDisposable(fillMediaValidator);
		return fillMediaValidator;
	}

	IMediaProvider Jab.IServiceProvider<IMediaProvider>.GetService()
	{
		IMediaProvider mediaProvider = IViewModelsServiceProviderModule.GetMediaProvider(GetService<IMediaValidator>(), GetService<IAdvanced>(), GetService<IImportProcessFactory>(), GetService<IMediaFactory>());
		TryAddDisposable(mediaProvider);
		return mediaProvider;
	}

	IToastNotificationService Jab.IServiceProvider<IToastNotificationService>.GetService()
	{
		if (_IToastNotificationService == null)
		{
			lock (this)
			{
				if (_IToastNotificationService == null)
				{
					_IToastNotificationService = new ToastNotificationService();
				}
			}
		}
		return _IToastNotificationService;
	}

	IWorkspaceDeletedPrompt Jab.IServiceProvider<IWorkspaceDeletedPrompt>.GetService()
	{
		if (_IWorkspaceDeletedPrompt == null)
		{
			lock (this)
			{
				if (_IWorkspaceDeletedPrompt == null)
				{
					_IWorkspaceDeletedPrompt = new WorkspaceDeletedPrompt(GetService<IMessageDialogService>(), GetService<ILocalization>());
				}
			}
		}
		return _IWorkspaceDeletedPrompt;
	}

	IWorkspaceCollectionVM Jab.IServiceProvider<IWorkspaceCollectionVM>.GetService()
	{
		if (_IWorkspaceCollectionVM == null)
		{
			lock (this)
			{
				if (_IWorkspaceCollectionVM == null)
				{
					_IWorkspaceCollectionVM = GetWorkspaceCollectionVM(GetService<IFlagService>(), GetService<IWorkspaceService>(), GetService<IWorkspaceItemVMFactory>(), GetService<IUiScheduler>(), GetService<IFileSystem>(), GetService<ICommonPathsWrapper>(), GetService<IWorkspaceDeletedPrompt>(), GetService<IAsyncExecutor>());
				}
			}
		}
		return _IWorkspaceCollectionVM;
	}

	IMainLayoutVM Jab.IServiceProvider<IMainLayoutVM>.GetService()
	{
		if (_IMainLayoutVM == null)
		{
			lock (this)
			{
				if (_IMainLayoutVM == null)
				{
					_IMainLayoutVM = new MainLayoutVM(GetService<ICoreManager>(), GetService<ssAPIOutput>(), GetService<ICommunicationOutput>(), GetService<IRegistrationOperationFactory>(), GetService<IRegistrationStateProvider>(), GetService<IThemeAnalyiticEvents>(), GetService<IMessageService>(), GetService<IEditorService>(), GetService<ICookieManagerService>(), GetService<IProPresenterResourceService>(), GetService<IThemeService>(), GetService<IApp>(), GetService<IGeneral>(), GetService<IProContentProvider>(), GetService<IProContentDownloader>(), GetService<IUriCacheService<NullableBitmapSource>>(), GetService<ILocalization>(), GetService<IMediaImportDownloadDialogService>(), GetService<IProContentAnalyticEventsPublisher>(), GetService<ITimerFactory>(), GetService<IUriCacheService<IReadOnlyList<IAnimationFrame>>>(), GetService<IDownloadManager>(), GetService<IFileSelectorService>(), GetService<IOutputService>(), GetService<IMediaActionService>(), GetService<IMediaCueThumbnailOverlayVMFactory>(), GetService<IPlaybackMarkerAnalyticsEvents>(), GetService<IDownloadsDialogService>(), GetService<IDownloadVMsFactory>(), GetService<IImportProcessFactory>(), GetService<IUiScheduler>(), GetService<ICapturePrompt>(), GetService<IEncoderValidator>(), GetService<IThemeRepo>(), GetService<ICaptureAnalyticEventsPublisher>(), GetService<ICalendarPrompt>(), GetService<IBibleProvider>(), GetService<ICaptureController>(), GetService<IResiController>(), GetService<ICrashRecovery>(), GetService<IResiAuthorizationInteractor>(), GetService<IPhysicalDeviceProvider>(), GetService<ITestPatternService>(), GetService<IFeedbackVM>(), GetService<ICrashReportingVM>(), GetService<IFileSelectorService>(), GetService<IWelcomeAnalyticEventsPublisher>(), GetService<IHyperlinkService>(), GetService<IWebSourceProvider>(), GetService<IAttachmentUploadVM>(), GetService<ITriggeringFactory>(), GetService<IPresentationFactory>(), GetService<IIndexingService>(), GetService<IFileFilterProvider>(), GetService<IPlanningCenterSettingsVM>(), GetService<IMultiTracksSettingsVM>(), GetService<ISongSelectSettingsVM>(), GetService<IFlagService>(), GetService<ITimelineManager>(), GetService<IMacroPrompt>(), GetService<IImport>(), GetService<IAppUpdateService>(), GetService<IUiDispatcher>(), GetService<ISlidePreviewService>(), GetService<IPropAutoClearService>(), GetService<IRegistrationWebResourceService>(), GetService<IInputsSettingsVM>(), GetService<IServerStateHandler>(), GetService<ITimecodeService>(), GetService<IOutputRepository>(), GetService<ITimecodeAnalyticsEvents>(), GetService<IProcessHelper>(), GetService<IFileSystem>(), GetService<IActionsMenuVMFactory>(), GetService<IApiService>(), GetService<IOutputPreviewVMFactory>(), GetService<IAsyncExecutor>(), GetService<IRTMPPrompt>(), GetService<INetwork>(), GetService<ILibraryService>(), GetService<ILayout>(), GetService<IPlaylistTemplatesService>(), GetService<ILegacyPurchaseBiblesDialogService>(), GetService<IMediaProvider>(), GetService<IExportProcessFactory>(), GetService<IInputActions>(), GetService<IMediaImportService>(), GetService<IPropPrompts>(), GetService<IProPresenterDOFactoryProvider>(), GetService<IChangeWorkspaceHandler>(), GetService<IDebouncerFactory>(), GetService<IProPresenterCueFactory>(), GetService<ILogger>(), GetService<IMessageDialogService>(), GetService<IMatchSongsInteractor>(), GetService<ICurrentTime>(), GetService<ICloudOnboardingService>(), GetService<IAfterStartupCompleteQueue>(), GetService<IWorkspaceService>(), GetService<ICloudWorkspaceService>(), GetService<IWorkspaceDocumentOrchestrator>(), GetService<ICommonPathsWrapper>(), GetService<IManageWorkspacesWindowProvider>(), GetService<IToastNotificationService>(), GetService<IMaskCollection>(), GetService<IOutputConfiguration>(), GetService<IWorkspaceCollectionVM>(), GetService<IProPresenterCueVMFactory>(), GetService<IInternetAccess>());
				}
			}
		}
		return _IMainLayoutVM;
	}

	IThemeSlideMenuVM Jab.IServiceProvider<IThemeSlideMenuVM>.GetService()
	{
		ThemeSlideMenuVM themeSlideMenuVM = new ThemeSlideMenuVM(GetService<IThemeService>(), GetService<IMessageService>());
		TryAddDisposable(themeSlideMenuVM);
		return themeSlideMenuVM;
	}

	IArrangementVM Jab.IServiceProvider<IArrangementVM>.GetService()
	{
		ArrangementVM arrangementVM = new ArrangementVM(GetService<ICoreManager>());
		TryAddDisposable(arrangementVM);
		return arrangementVM;
	}

	ITimecodeItemVMFactory Jab.IServiceProvider<ITimecodeItemVMFactory>.GetService()
	{
		TimecodeItemVMFactory timecodeItemVMFactory = new TimecodeItemVMFactory(GetService<ITimecodeService>());
		TryAddDisposable(timecodeItemVMFactory);
		return timecodeItemVMFactory;
	}

	ITimecodeVM Jab.IServiceProvider<ITimecodeVM>.GetService()
	{
		if (_ITimecodeVM == null)
		{
			lock (this)
			{
				if (_ITimecodeVM == null)
				{
					_ITimecodeVM = new TimecodeVM(GetService<ITimecodeService>(), GetService<IProPresenterResourceService>(), GetService<IOutputRepository>(), GetService<ITimecodeAnalyticsEvents>(), GetService<IDebouncerFactory>(), GetService<ITimecodeItemVMFactory>());
				}
			}
		}
		return _ITimecodeVM;
	}

	IHeaderContentContextMenuVM Jab.IServiceProvider<IHeaderContentContextMenuVM>.GetService()
	{
		HeaderContentContextMenuVM headerContentContextMenuVM = new HeaderContentContextMenuVM(GetService<ILocalization>());
		TryAddDisposable(headerContentContextMenuVM);
		return headerContentContextMenuVM;
	}

	IWorkspaceSwitchValidator Jab.IServiceProvider<IWorkspaceSwitchValidator>.GetService()
	{
		if (_IWorkspaceSwitchValidator == null)
		{
			lock (this)
			{
				if (_IWorkspaceSwitchValidator == null)
				{
					_IWorkspaceSwitchValidator = new WorkspaceSwitchValidator(GetService<ICrdtProtoDirectoryFileScanner>(), GetService<IMessageDialogService>(), GetService<IAppUpdateService>(), GetService<IFlagService>(), GetService<ILocalization>(), GetService<ICommonPathsWrapper>(), GetService<IFileSystem>());
				}
			}
		}
		return _IWorkspaceSwitchValidator;
	}

	IApplicationFailureMessageService Jab.IServiceProvider<IApplicationFailureMessageService>.GetService()
	{
		ApplicationFailureMessageService applicationFailureMessageService = new ApplicationFailureMessageService(GetService<IUiDispatcher>(), GetService<ILocalization>(), GetService<IVersionInfoProvider>());
		TryAddDisposable(applicationFailureMessageService);
		return applicationFailureMessageService;
	}

	IFeatureFlagService Jab.IServiceProvider<IFeatureFlagService>.GetService()
	{
		if (_IFeatureFlagService == null)
		{
			lock (this)
			{
				if (_IFeatureFlagService == null)
				{
					_IFeatureFlagService = new Pro.CoreApplication.FeatureFlag.FeatureFlagService(GetService<ICoreApplication>(), GetService<ILogger>());
				}
			}
		}
		return _IFeatureFlagService;
	}

	ISpellChecker Jab.IServiceProvider<ISpellChecker>.GetService()
	{
		SpellChecker spellChecker = new SpellChecker();
		TryAddDisposable(spellChecker);
		return spellChecker;
	}

	IReceiveService Jab.IServiceProvider<IReceiveService>.GetService()
	{
		if (_IReceiveService == null)
		{
			lock (this)
			{
				if (_IReceiveService == null)
				{
					_IReceiveService = new ReceiveService(GetService<IProCoreInstance>(), GetService<IUiDispatcher>());
				}
			}
		}
		return _IReceiveService;
	}

	IPresentationHandlerOperationService Jab.IServiceProvider<IPresentationHandlerOperationService>.GetService()
	{
		PresentationHandlerOperationService presentationHandlerOperationService = new PresentationHandlerOperationService();
		TryAddDisposable(presentationHandlerOperationService);
		return presentationHandlerOperationService;
	}

	private IApplicationEventHandler GetIApplicationEventHandler_CoreManagerApplicationEventHandler()
	{
		IApplicationEventHandler coreManager = IControllerServiceProviderModule.GetCoreManager(GetService<CoreManager>());
		TryAddDisposable(coreManager);
		return coreManager;
	}

	ISettingsDataToCoreSender Jab.IServiceProvider<ISettingsDataToCoreSender>.GetService()
	{
		if (_ISettingsDataToCoreSender == null)
		{
			lock (this)
			{
				if (_ISettingsDataToCoreSender == null)
				{
					_ISettingsDataToCoreSender = new SettingsDataToCoreSender(GetService<IGeneral>(), GetService<IDisplay>(), GetService<IImport>(), GetService<INetwork>(), GetService<IAdvanced>(), GetService<ISync>(), GetService<IApp>(), GetService<IProPresenterResourceService>(), GetService<ILocalization>(), GetService<ICoreManager>());
				}
			}
		}
		return _ISettingsDataToCoreSender;
	}

	IAPIv1Dependencies Jab.IServiceProvider<IAPIv1Dependencies>.GetService()
	{
		APIv1Dependencies aPIv1Dependencies = new APIv1Dependencies(GetService<IUiDispatcher>(), GetService<IProPresenterResourceService>(), GetService<IToastNotificationService>(), GetService<ILocalization>(), GetService<IPresentationHandlerOperationService>(), GetService<ITimelineManager>(), GetService<IFlagService>(), GetService<ICaptureService>(), GetService<IResiService>(), GetService<IApp>(), GetService<IImportProcessFactory>(), GetService<ITransitionDescriptionCollection>(), GetService<IProPresenterDOFactoryProvider>(), GetService<ISlidePreviewService>(), GetService<ILogger>(), GetService<IProPresenterCueFactory>());
		TryAddDisposable(aPIv1Dependencies);
		return aPIv1Dependencies;
	}

	ISharedData<AppData> Jab.IServiceProvider<ISharedData<AppData>>.GetService()
	{
		if (_ISharedData_AppData == null)
		{
			lock (this)
			{
				if (_ISharedData_AppData == null)
				{
					_ISharedData_AppData = IDataServiceProviderModule.GetSharedAppData();
				}
			}
		}
		return _ISharedData_AppData;
	}

	Func<IRegistrationOperationFactory> Jab.IServiceProvider<Func<IRegistrationOperationFactory>>.GetService()
	{
		Func<IRegistrationOperationFactory> registrationOperationFactoryGetter = GetRegistrationOperationFactoryGetter();
		TryAddDisposable(registrationOperationFactoryGetter);
		return registrationOperationFactoryGetter;
	}

	IStartupArgumentsExecutor Jab.IServiceProvider<IStartupArgumentsExecutor>.GetService()
	{
		IStartupArgumentsExecutor uriSchemeStartupArgumentExecutor = GetUriSchemeStartupArgumentExecutor(GetService<Func<IRegistrationOperationFactory>>(), GetService<ISharedData<AppData>>(), GetService<IMessages<AppMessages>>(), GetService<Func<IMainLayoutVM>>());
		TryAddDisposable(uriSchemeStartupArgumentExecutor);
		return uriSchemeStartupArgumentExecutor;
	}

	private Func<bool> GetFunc_Boolean_ShouldSuppressVisualIndicationKey()
	{
		Func<bool> shouldSuppressVisualIndication = GetShouldSuppressVisualIndication();
		TryAddDisposable(shouldSuppressVisualIndication);
		return shouldSuppressVisualIndication;
	}

	IMessageHandler Jab.IServiceProvider<IMessageHandler>.GetService()
	{
		IMessageHandler uriMessageHandler = IDataServiceProviderModule.GetUriMessageHandler(GetService<ISharedData<AppData>>(), GetService<Func<IRegistrationOperationFactory>>(), GetFunc_Boolean_ShouldSuppressVisualIndicationKey(), GetService<Func<IMainLayoutVM>>());
		TryAddDisposable(uriMessageHandler);
		return uriMessageHandler;
	}

	IDocumentDiagnosticsProvider Jab.IServiceProvider<IDocumentDiagnosticsProvider>.GetService()
	{
		if (_IDocumentDiagnosticsProvider == null)
		{
			lock (this)
			{
				if (_IDocumentDiagnosticsProvider == null)
				{
					_IDocumentDiagnosticsProvider = IDataServiceProviderModule.GetDocumentUpdateProvider(GetService<IDocumentService>(), GetService<IAsyncExecutor>(), GetService<IFileSystem>(), GetService<IEntityFileLockFactory>(), GetService<ICommonPathsWrapper>(), GetService<IDocumentFactory>(), GetService<ICollaborationPeerIdProvider>(), GetService<IThreadPoolScheduler>(), GetService<ICloudDiagnosticsPublisher>(), GetService<IErrorReporter>());
				}
			}
		}
		return _IDocumentDiagnosticsProvider;
	}

	ILaunchPopUpProvider Jab.IServiceProvider<ILaunchPopUpProvider>.GetService()
	{
		ILaunchPopUpProvider userMessageHandler = IRegistrationServiceProviderModule.GetUserMessageHandler(GetService<UserMessageHandler>());
		TryAddDisposable(userMessageHandler);
		return userMessageHandler;
	}

	IPropAutoClearHandler Jab.IServiceProvider<IPropAutoClearHandler>.GetService()
	{
		if (_IPropAutoClearHandler == null)
		{
			lock (this)
			{
				if (_IPropAutoClearHandler == null)
				{
					_IPropAutoClearHandler = ISendDataServiceProviderModule.GetPropAutoClearHandler(GetService<PropAutoClearHandler>());
				}
			}
		}
		return _IPropAutoClearHandler;
	}

	ISendDataResponseHandlerProvider Jab.IServiceProvider<ISendDataResponseHandlerProvider>.GetService()
	{
		if (_ISendDataResponseHandlerProvider == null)
		{
			lock (this)
			{
				if (_ISendDataResponseHandlerProvider == null)
				{
					_ISendDataResponseHandlerProvider = new SendDataResponseHandlerProvider(GetService<IProCoreInstance>(), GetService<ICapturePrompt>(), GetService<IEncoderValidator>(), GetService<ICoreManager>(), GetService<ICrashRecovery>(), GetService<ITestPatternService>(), GetService<IUiDispatcher>(), GetService<IProPresenterResourceService>(), GetService<IApp>(), GetService<IPropAutoClearHandler>(), GetService<IErrorPublisher>(), GetService<ICookieManagerService>(), GetService<IMediaService>(), GetService<IProPresenterDOFactoryProvider>(), GetService<IOutputRepository>());
				}
			}
		}
		return _ISendDataResponseHandlerProvider;
	}

	IDataProcessor<SendDataResponse> Jab.IServiceProvider<IDataProcessor<SendDataResponse>>.GetService()
	{
		if (_IDataProcessor_SendDataResponse == null)
		{
			lock (this)
			{
				if (_IDataProcessor_SendDataResponse == null)
				{
					_IDataProcessor_SendDataResponse = new ProCoreSendDataProcessor(GetService<ISendDataResponseHandlerProvider>(), GetService<IAsyncExecutor>());
				}
			}
		}
		return _IDataProcessor_SendDataResponse;
	}

	MediaInspectorConverter Jab.IServiceProvider<MediaInspectorConverter>.GetService()
	{
		MediaInspectorConverter mediaInspectorConverter = new MediaInspectorConverter(GetService<IApp>(), GetService<ITransitionDescriptionCollection>());
		TryAddDisposable(mediaInspectorConverter);
		return mediaInspectorConverter;
	}

	WarningTooltipConverter Jab.IServiceProvider<WarningTooltipConverter>.GetService()
	{
		WarningTooltipConverter warningTooltipConverter = new WarningTooltipConverter(GetService<ILocalization>());
		TryAddDisposable(warningTooltipConverter);
		return warningTooltipConverter;
	}

	WebFillBrowserFactory Jab.IServiceProvider<WebFillBrowserFactory>.GetService()
	{
		if (_WebFillBrowserFactory == null)
		{
			lock (this)
			{
				if (_WebFillBrowserFactory == null)
				{
					_WebFillBrowserFactory = new WebFillBrowserFactory(GetService<IUiDispatcher>());
				}
			}
		}
		return _WebFillBrowserFactory;
	}

	IWebFillBrowserFactory Jab.IServiceProvider<IWebFillBrowserFactory>.GetService()
	{
		IWebFillBrowserFactory webFillBrowserFactory = IProPresenterUiServiceProviderModule.GetWebFillBrowserFactory(GetService<WebFillBrowserFactory>());
		TryAddDisposable(webFillBrowserFactory);
		return webFillBrowserFactory;
	}

	IActionDialogService Jab.IServiceProvider<IActionDialogService>.GetService()
	{
		IActionDialogService actionDialigService = IProPresenterUiServiceProviderModule.GetActionDialigService(GetService<IMainLayoutVM>());
		TryAddDisposable(actionDialigService);
		return actionDialigService;
	}

	ITemplateVM Jab.IServiceProvider<ITemplateVM>.GetService()
	{
		ITemplateVM templateVM = IProPresenterUiServiceProviderModule.GetTemplateVM(GetService<IMainLayoutVM>());
		TryAddDisposable(templateVM);
		return templateVM;
	}

	Func<MainWindow> Jab.IServiceProvider<Func<MainWindow>>.GetService()
	{
		Func<MainWindow> mainWindowGetter = GetMainWindowGetter();
		TryAddDisposable(mainWindowGetter);
		return mainWindowGetter;
	}

	IInstanceValidator Jab.IServiceProvider<IInstanceValidator>.GetService()
	{
		IInstanceValidator instanceValidator = GetInstanceValidator();
		TryAddDisposable(instanceValidator);
		return instanceValidator;
	}

	IWorkspaceInfoDumper Jab.IServiceProvider<IWorkspaceInfoDumper>.GetService()
	{
		if (_IWorkspaceInfoDumper == null)
		{
			lock (this)
			{
				if (_IWorkspaceInfoDumper == null)
				{
					_IWorkspaceInfoDumper = new WorkspaceInfoDumper(GetService<IDocumentDiagnosticsProvider>(), GetService<ICommonPathsWrapper>(), GetService<ICloudWorkspaceService>(), GetService<ILogger>());
				}
			}
		}
		return _IWorkspaceInfoDumper;
	}

	MainWindow Jab.IServiceProvider<MainWindow>.GetService()
	{
		if (_MainWindow == null)
		{
			lock (this)
			{
				if (_MainWindow == null)
				{
					_MainWindow = GetMainWindow(GetService<IMessages<AppMessages>>(), GetService<ssAPIOutput>(), GetService<IApp>(), GetService<ITestPatternService>(), GetService<ITestPatternAnalyticEventsPublisher>(), GetService<IAttachmentsUploader>(), GetService<ICrashReportUserFeedbackDialogProvider>(), GetService<ISettingsVM>(), GetService<IMessageService>(), GetService<IAfterStartupCompleteQueue>(), GetService<IScreenSelectorVM>(), GetService<IWindowedOutputVM>(), GetService<INetwork>(), GetService<IMainLayoutVM>(), GetService<IWebSourceProvider>(), GetService<IHyperlinkService>(), GetService<IInputActions>(), GetService<IWhatsNewV2VM>(), GetService<IFlagService>(), GetService<IWorkspaceInfoDumper>());
				}
			}
		}
		return _MainWindow;
	}

	ICloudOnboardingWindowProvider Jab.IServiceProvider<ICloudOnboardingWindowProvider>.GetService()
	{
		if (_ICloudOnboardingWindowProvider == null)
		{
			lock (this)
			{
				if (_ICloudOnboardingWindowProvider == null)
				{
					_ICloudOnboardingWindowProvider = new CloudOnboardingWindowProvider(GetService<ICloudOnboardingVM>(), GetService<ICloudOnboardingService>(), GetService<IAfterStartupCompleteQueue>());
				}
			}
		}
		return _ICloudOnboardingWindowProvider;
	}

	IMediaServiceV1 Jab.IServiceProvider<IMediaServiceV1>.GetService()
	{
		if (_IMediaServiceV1 == null)
		{
			lock (this)
			{
				if (_IMediaServiceV1 == null)
				{
					_IMediaServiceV1 = new MediaServiceV1(GetService<ICoreApplication>(), GetService<ILogger>(), GetService<IMediaAnalyticsSender>(), GetService<IFlagService>());
				}
			}
		}
		return _IMediaServiceV1;
	}

	IMediaServiceV2 Jab.IServiceProvider<IMediaServiceV2>.GetService()
	{
		if (_IMediaServiceV2 == null)
		{
			lock (this)
			{
				if (_IMediaServiceV2 == null)
				{
					_IMediaServiceV2 = new MediaServiceV2(GetService<ICoreApplication>(), GetService<ILogger>(), GetService<IMediaAnalyticsSender>(), GetService<IFlagService>(), GetService<IManageMediaAutoMaticallyProvider>(), GetService<IEnableAnalyticsProvider>(), GetService<IAsyncExecutor>());
				}
			}
		}
		return _IMediaServiceV2;
	}

	private IProcessSupervisor GetIProcessSupervisor_WorkspaceHelperProcessSupervisor()
	{
		if (_IProcessSupervisor_WorkspaceHelperProcessSupervisor == null)
		{
			lock (this)
			{
				if (_IProcessSupervisor_WorkspaceHelperProcessSupervisor == null)
				{
					_IProcessSupervisor_WorkspaceHelperProcessSupervisor = GetWorkspaceHelperSupervision(GetService<ILogger>(), GetService<ITimerFactory>(), GetService<IFileSystem>());
				}
			}
		}
		return _IProcessSupervisor_WorkspaceHelperProcessSupervisor;
	}

	IActionFactoryService Jab.IServiceProvider<IActionFactoryService>.GetService()
	{
		if (_IActionFactoryService == null)
		{
			lock (this)
			{
				if (_IActionFactoryService == null)
				{
					_IActionFactoryService = GetActionFactory(GetService<IOutputService>(), GetService<IResiService>(), GetService<IApp>(), GetService<ITimerFactory>(), GetService<IPlaylistActionValidatorFactory>(), GetService<IOutputRepository>(), GetService<IProPresenterResourceService>(), GetService<IProPresenterDOFactoryProvider>(), GetService<IMessageDialogService>(), GetService<ICurrentTime>(), GetService<IOutputConfiguration>());
				}
			}
		}
		return _IActionFactoryService;
	}

	IWorkspacesVM Jab.IServiceProvider<IWorkspacesVM>.GetService()
	{
		if (_IWorkspacesVM == null)
		{
			lock (this)
			{
				if (_IWorkspacesVM == null)
				{
					_IWorkspacesVM = CreateWorkspaceVM(GetService<IChangeWorkspaceHandler>(), GetService<IFileSelectorService>(), GetService<ILocalization>(), GetService<IFileSystem>(), GetService<IProcessHelper>(), GetService<IManageWorkspacesWindowProvider>(), GetService<IWorkspaceService>(), GetService<IFileUtility>(), GetService<ILogger>(), GetService<IFileService>(), GetService<ICommonPathsWrapper>(), GetService<IMainLayoutVM>(), GetService<IWorkspaceSwitchValidator>(), GetService<IHyperlinkService>(), GetService<IFlagService>(), GetService<IRegistrationWebResourceService>(), GetService<IRegistrationStateProvider>(), GetService<IUiScheduler>(), GetService<IMessageDialogService>(), GetService<IWorkspaceAnalyticsEventPublisher>(), GetService<IVisualPlaylistRepo>(), GetService<IWorkspaceDocumentOrchestrator>(), GetService<IStopwatchFactory>(), GetService<IAsyncExecutor>(), GetService<IAppUpdateService>(), GetService<IMediaFileProvider>(), GetService<IWorkspaceCollectionVM>());
				}
			}
		}
		return _IWorkspacesVM;
	}

	private IStartupArgumentsExecutor GetIStartupArgumentsExecutor_1()
	{
		if (_IStartupArgumentsExecutor_1 == null)
		{
			lock (this)
			{
				if (_IStartupArgumentsExecutor_1 == null)
				{
					_IStartupArgumentsExecutor_1 = new FileStartupArgumentExecutor(GetService<ISharedData<AppData>>(), GetService<IMessages<AppMessages>>(), GetService<Func<IMainLayoutVM>>(), GetService<IFileSystem>());
				}
			}
		}
		return _IStartupArgumentsExecutor_1;
	}

	IEnumerable<IStartupArgumentsExecutor> Jab.IServiceProvider<IEnumerable<IStartupArgumentsExecutor>>.GetService()
	{
		return new IStartupArgumentsExecutor[2]
		{
			GetIStartupArgumentsExecutor_1(),
			GetService<IStartupArgumentsExecutor>()
		};
	}

	private IMessageHandler GetIMessageHandler_1()
	{
		if (_IMessageHandler_1 == null)
		{
			lock (this)
			{
				if (_IMessageHandler_1 == null)
				{
					_IMessageHandler_1 = new FocusWindowMessageHandler(GetService<Func<MainWindow>>());
				}
			}
		}
		return _IMessageHandler_1;
	}

	private IMessageHandler GetIMessageHandler_2()
	{
		if (_IMessageHandler_2 == null)
		{
			lock (this)
			{
				if (_IMessageHandler_2 == null)
				{
					_IMessageHandler_2 = new FileMessageHandler(GetService<ISharedData<AppData>>(), GetService<Func<IMainLayoutVM>>(), GetService<IFileSystem>());
				}
			}
		}
		return _IMessageHandler_2;
	}

	IEnumerable<IMessageHandler> Jab.IServiceProvider<IEnumerable<IMessageHandler>>.GetService()
	{
		return new IMessageHandler[3]
		{
			GetIMessageHandler_2(),
			GetIMessageHandler_1(),
			GetService<IMessageHandler>()
		};
	}

	IServiceProvider Jab.IServiceProvider<IServiceProvider>.GetService()
	{
		return this;
	}

	IServiceScopeFactory Jab.IServiceProvider<IServiceScopeFactory>.GetService()
	{
		return this;
	}

	IServiceProviderIsService Jab.IServiceProvider<IServiceProviderIsService>.GetService()
	{
		return this;
	}

	System.Version Jab.INamedServiceProvider<System.Version>.GetService(string name)
	{
		if (name == "OSVersion")
		{
			return GetVersion_OSVersion();
		}
		throw Jab.JabHelpers.CreateServiceNotFoundException<System.Version>(name);
	}

	System.Action Jab.INamedServiceProvider<System.Action>.GetService(string name)
	{
		if (name == "ShowRegistrationSettingsKey")
		{
			return GetAction_ShowRegistrationSettingsKey();
		}
		throw Jab.JabHelpers.CreateServiceNotFoundException<System.Action>(name);
	}

	IOAuth2AuthorizationStore Jab.INamedServiceProvider<IOAuth2AuthorizationStore>.GetService(string name)
	{
		if (name == "ProContentRegistrationAuthorizationStorageKey")
		{
			return GetIOAuth2AuthorizationStore_ProContentRegistrationAuthorizationStorageKey();
		}
		throw Jab.JabHelpers.CreateServiceNotFoundException<IOAuth2AuthorizationStore>(name);
	}

	IOAuth2ClientInfoProvider Jab.INamedServiceProvider<IOAuth2ClientInfoProvider>.GetService(string name)
	{
		if (name == "ProContentRegistrationAuthorizationInfoProviderKey")
		{
			return GetIOAuth2ClientInfoProvider_ProContentRegistrationAuthorizationInfoProviderKey();
		}
		throw Jab.JabHelpers.CreateServiceNotFoundException<IOAuth2ClientInfoProvider>(name);
	}

	IIdProvider Jab.INamedServiceProvider<IIdProvider>.GetService(string name)
	{
		if (name == "BugsnagIdProviderKey")
		{
			return GetIIdProvider_BugsnagIdProviderKey();
		}
		throw Jab.JabHelpers.CreateServiceNotFoundException<IIdProvider>(name);
	}

	ISyncRepository<ISyncData> Jab.INamedServiceProvider<ISyncRepository<ISyncData>>.GetService(string name)
	{
		if (!(name == "RemoteFileRepositoryKey"))
		{
			if (name == "LocalFileRepositoryKey")
			{
				return GetISyncRepository_ISyncData_LocalFileRepositoryKey();
			}
			throw Jab.JabHelpers.CreateServiceNotFoundException<ISyncRepository<ISyncData>>(name);
		}
		return GetISyncRepository_ISyncData_RemoteFileRepositoryKey();
	}

	System.IO.Stream Jab.INamedServiceProvider<System.IO.Stream>.GetService(string name)
	{
		if (name == "WhatsNewContentProviderFromJsonFileContentKey")
		{
			return GetStream_WhatsNewContentProviderFromJsonFileContentKey();
		}
		throw Jab.JabHelpers.CreateServiceNotFoundException<System.IO.Stream>(name);
	}

	IApplicationEventHandler Jab.INamedServiceProvider<IApplicationEventHandler>.GetService(string name)
	{
		if (name == "CoreManagerApplicationEventHandler")
		{
			return GetIApplicationEventHandler_CoreManagerApplicationEventHandler();
		}
		throw Jab.JabHelpers.CreateServiceNotFoundException<IApplicationEventHandler>(name);
	}

	Func<bool> Jab.INamedServiceProvider<Func<bool>>.GetService(string name)
	{
		if (name == "ShouldSuppressVisualIndicationKey")
		{
			return GetFunc_Boolean_ShouldSuppressVisualIndicationKey();
		}
		throw Jab.JabHelpers.CreateServiceNotFoundException<Func<bool>>(name);
	}

	IProcessSupervisor Jab.INamedServiceProvider<IProcessSupervisor>.GetService(string name)
	{
		if (name == "WorkspaceHelperProcessSupervisor")
		{
			return GetIProcessSupervisor_WorkspaceHelperProcessSupervisor();
		}
		throw Jab.JabHelpers.CreateServiceNotFoundException<IProcessSupervisor>(name);
	}

	object? IServiceProvider.GetService(Type type)
	{
		if (type == typeof(IPhysicalDeviceProvider))
		{
			return GetService<IPhysicalDeviceProvider>();
		}
		if (type == typeof(IDatabaseService))
		{
			return GetService<IDatabaseService>();
		}
		if (type == typeof(IFileWatcherFactory))
		{
			return GetService<IFileWatcherFactory>();
		}
		if (type == typeof(IFileSystem))
		{
			return GetService<IFileSystem>();
		}
		if (type == typeof(IUiDispatcher))
		{
			return GetService<IUiDispatcher>();
		}
		if (type == typeof(ITimerFactory))
		{
			return GetService<ITimerFactory>();
		}
		if (type == typeof(IDebouncerFactory))
		{
			return GetService<IDebouncerFactory>();
		}
		if (type == typeof(IThemeRepo))
		{
			return GetService<IThemeRepo>();
		}
		if (type == typeof(IPropsRepo))
		{
			return GetService<IPropsRepo>();
		}
		if (type == typeof(IMacrosRepo))
		{
			return GetService<IMacrosRepo>();
		}
		if (type == typeof(ILibraryPlaylistRepo))
		{
			return GetService<ILibraryPlaylistRepo>();
		}
		if (type == typeof(IVisualPlaylistRepo))
		{
			return GetService<IVisualPlaylistRepo>();
		}
		if (type == typeof(IProPresenterResourceService))
		{
			return GetService<IProPresenterResourceService>();
		}
		if (type == typeof(IThemeService))
		{
			return GetService<IThemeService>();
		}
		if (type == typeof(IZipService))
		{
			return GetService<IZipService>();
		}
		if (type == typeof(IMessageService))
		{
			return GetService<IMessageService>();
		}
		if (type == typeof(IFileService))
		{
			return GetService<IFileService>();
		}
		if (type == typeof(ILogger))
		{
			return GetService<ILogger>();
		}
		if (type == typeof(ILocalization))
		{
			return GetService<ILocalization>();
		}
		if (type == typeof(IAdvanced))
		{
			return GetService<IAdvanced>();
		}
		if (type == typeof(IProtoService))
		{
			return GetService<IProtoService>();
		}
		if (type == typeof(ISqliteMigrationService))
		{
			return GetService<ISqliteMigrationService>();
		}
		if (type == typeof(ICookieManagerService))
		{
			return GetService<ICookieManagerService>();
		}
		if (type == typeof(App))
		{
			return GetService<App>();
		}
		if (type == typeof(IApp))
		{
			return GetService<IApp>();
		}
		if (type == typeof(IProCoreInstance))
		{
			return GetService<IProCoreInstance>();
		}
		if (type == typeof(IFlagService))
		{
			return GetService<IFlagService>();
		}
		if (type == typeof(ssAPIOutput))
		{
			return GetService<ssAPIOutput>();
		}
		if (type == typeof(ITransitionDescriptionCollection))
		{
			return GetService<ITransitionDescriptionCollection>();
		}
		if (type == typeof(IImageLoader))
		{
			return GetService<IImageLoader>();
		}
		if (type == typeof(IMediaMetadataCacheRepository))
		{
			return GetService<IMediaMetadataCacheRepository>();
		}
		if (type == typeof(IMediaMetadataCacheService))
		{
			return GetService<IMediaMetadataCacheService>();
		}
		if (type == typeof(IAsyncExecutor))
		{
			return GetService<IAsyncExecutor>();
		}
		if (type == typeof(IUiScheduler))
		{
			return GetService<IUiScheduler>();
		}
		if (type == typeof(IMetadataLoader))
		{
			return GetService<IMetadataLoader>();
		}
		if (type == typeof(ITrackedMediaHelpers))
		{
			return GetService<ITrackedMediaHelpers>();
		}
		if (type == typeof(IAssemblyInfoProvider))
		{
			return GetService<IAssemblyInfoProvider>();
		}
		if (type == typeof(IVersionInfoProvider))
		{
			return GetService<IVersionInfoProvider>();
		}
		if (type == typeof(IRestClientFactory))
		{
			return GetService<IRestClientFactory>();
		}
		if (type == typeof(ISemaphoreFactory))
		{
			return GetService<ISemaphoreFactory>();
		}
		if (type == typeof(ICurrentTime))
		{
			return GetService<ICurrentTime>();
		}
		if (type == typeof(IFileSystemUriCacheServiceFactory))
		{
			return GetService<IFileSystemUriCacheServiceFactory>();
		}
		if (type == typeof(IImageDecoder))
		{
			return GetService<IImageDecoder>();
		}
		if (type == typeof(IBitmapImageDecoder))
		{
			return GetService<IBitmapImageDecoder>();
		}
		if (type == typeof(IUriCacheService<NullableBitmapSource>))
		{
			return GetService<IUriCacheService<NullableBitmapSource>>();
		}
		if (type == typeof(ICurrentTimeOffset))
		{
			return GetService<ICurrentTimeOffset>();
		}
		if (type == typeof(IAuthenticatingApiConsumerFactory))
		{
			return GetService<IAuthenticatingApiConsumerFactory>();
		}
		if (type == typeof(IApiService))
		{
			return GetService<IApiService>();
		}
		if (type == typeof(IRegistrationUserDialogService))
		{
			return GetService<IRegistrationUserDialogService>();
		}
		if (type == typeof(IApplicationExceptionFactory))
		{
			return GetService<IApplicationExceptionFactory>();
		}
		if (type == typeof(IErrorPublisher))
		{
			return GetService<IErrorPublisher>();
		}
		if (type == typeof(IErrorReporter))
		{
			return GetService<IErrorReporter>();
		}
		if (type == typeof(ICoreApplication))
		{
			return GetService<ICoreApplication>();
		}
		if (type == typeof(IRegistrationCallbackHandler))
		{
			return GetService<IRegistrationCallbackHandler>();
		}
		if (type == typeof(NotificationCallbackHandler))
		{
			return GetService<NotificationCallbackHandler>();
		}
		if (type == typeof(ProContentClientInformationProvider))
		{
			return GetService<ProContentClientInformationProvider>();
		}
		if (type == typeof(IInternetAccess))
		{
			return GetService<IInternetAccess>();
		}
		if (type == typeof(IHyperlinkService))
		{
			return GetService<IHyperlinkService>();
		}
		if (type == typeof(JsonWebTokenHandler))
		{
			return GetService<JsonWebTokenHandler>();
		}
		if (type == typeof(RegistrationStateHandler))
		{
			return GetService<RegistrationStateHandler>();
		}
		if (type == typeof(IRegistrationStateProvider))
		{
			return GetService<IRegistrationStateProvider>();
		}
		if (type == typeof(IActivationKeyProvider))
		{
			return GetService<IActivationKeyProvider>();
		}
		if (type == typeof(IRegistrationWebResourceService))
		{
			return GetService<IRegistrationWebResourceService>();
		}
		if (type == typeof(IPopUpAlertFactory))
		{
			return GetService<IPopUpAlertFactory>();
		}
		if (type == typeof(IAfterStartupCompleteQueue))
		{
			return GetService<IAfterStartupCompleteQueue>();
		}
		if (type == typeof(UserMessageHandler))
		{
			return GetService<UserMessageHandler>();
		}
		if (type == typeof(Func<IMainLayoutVM>))
		{
			return GetService<Func<IMainLayoutVM>>();
		}
		if (type == typeof(IWebSourceProvider))
		{
			return GetService<IWebSourceProvider>();
		}
		if (type == typeof(IRegistrationCallbackDialogProvider))
		{
			return GetService<IRegistrationCallbackDialogProvider>();
		}
		if (type == typeof(IEmbeddedResourceReader))
		{
			return GetService<IEmbeddedResourceReader>();
		}
		if (type == typeof(IForceQuitEventPublisher))
		{
			return GetService<IForceQuitEventPublisher>();
		}
		if (type == typeof(IForcedShutdownMessageProvider))
		{
			return GetService<IForcedShutdownMessageProvider>();
		}
		if (type == typeof(IInternetAccessCheck))
		{
			return GetService<IInternetAccessCheck>();
		}
		if (type == typeof(IEnumerable<IRegistrationCallbackHandler>))
		{
			return GetService<IEnumerable<IRegistrationCallbackHandler>>();
		}
		if (type == typeof(RegistrationClient))
		{
			return GetService<RegistrationClient>();
		}
		if (type == typeof(IRegistrationClient))
		{
			return GetService<IRegistrationClient>();
		}
		if (type == typeof(IRegistrationOperationFactory))
		{
			return GetService<IRegistrationOperationFactory>();
		}
		if (type == typeof(IProContentConsumer))
		{
			return GetService<IProContentConsumer>();
		}
		if (type == typeof(IProContentDownloadFailedDialogService))
		{
			return GetService<IProContentDownloadFailedDialogService>();
		}
		if (type == typeof(IProContentUserInteractionBehavior))
		{
			return GetService<IProContentUserInteractionBehavior>();
		}
		if (type == typeof(IDelayFactory))
		{
			return GetService<IDelayFactory>();
		}
		if (type == typeof(IDownloadProcessFactory))
		{
			return GetService<IDownloadProcessFactory>();
		}
		if (type == typeof(IDownloadItemFactory))
		{
			return GetService<IDownloadItemFactory>();
		}
		if (type == typeof(IProContentAnalyticEventsPublisher))
		{
			return GetService<IProContentAnalyticEventsPublisher>();
		}
		if (type == typeof(IDownloadManager))
		{
			return GetService<IDownloadManager>();
		}
		if (type == typeof(IUnObservedProContentDownloadProcessFactory))
		{
			return GetService<IUnObservedProContentDownloadProcessFactory>();
		}
		if (type == typeof(IProContentAssetProvider))
		{
			return GetService<IProContentAssetProvider>();
		}
		if (type == typeof(IRemoteFileLoader))
		{
			return GetService<IRemoteFileLoader>();
		}
		if (type == typeof(IAudioOutputDeviceCollection))
		{
			return GetService<IAudioOutputDeviceCollection>();
		}
		if (type == typeof(IAudioSetup))
		{
			return GetService<IAudioSetup>();
		}
		if (type == typeof(IAudioMapRecallService<DeviceChannel, Bus>))
		{
			return GetService<IAudioMapRecallService<DeviceChannel, Bus>>();
		}
		if (type == typeof(ILiveVideoInputCollection))
		{
			return GetService<ILiveVideoInputCollection>();
		}
		if (type == typeof(IMediaFactory))
		{
			return GetService<IMediaFactory>();
		}
		if (type == typeof(ITextFillMediaFactory))
		{
			return GetService<ITextFillMediaFactory>();
		}
		if (type == typeof(ITextDocumentFactory))
		{
			return GetService<ITextDocumentFactory>();
		}
		if (type == typeof(IEntityFactory))
		{
			return GetService<IEntityFactory>();
		}
		if (type == typeof(IDocumentFactory))
		{
			return GetService<IDocumentFactory>();
		}
		if (type == typeof(IDocumentService))
		{
			return GetService<IDocumentService>();
		}
		if (type == typeof(IEntityFileLockFactory))
		{
			return GetService<IEntityFileLockFactory>();
		}
		if (type == typeof(ICommonPathsWrapper))
		{
			return GetService<ICommonPathsWrapper>();
		}
		if (type == typeof(ICollaborationPeerIdProvider))
		{
			return GetService<ICollaborationPeerIdProvider>();
		}
		if (type == typeof(IThreadPoolScheduler))
		{
			return GetService<IThreadPoolScheduler>();
		}
		if (type == typeof(IMediaService))
		{
			return GetService<IMediaService>();
		}
		if (type == typeof(ILocalWorkspaceStatsEventPublisher))
		{
			return GetService<ILocalWorkspaceStatsEventPublisher>();
		}
		if (type == typeof(IZipHelper))
		{
			return GetService<IZipHelper>();
		}
		if (type == typeof(IWorkspaceService))
		{
			return GetService<IWorkspaceService>();
		}
		if (type == typeof(ICloudDiagnosticsPublisher))
		{
			return GetService<ICloudDiagnosticsPublisher>();
		}
		if (type == typeof(IEntityDocumentRegistry))
		{
			return GetService<IEntityDocumentRegistry>();
		}
		if (type == typeof(IEntityDocumentSyncerFactory))
		{
			return GetService<IEntityDocumentSyncerFactory>();
		}
		if (type == typeof(IMergedEntityFactory))
		{
			return GetService<IMergedEntityFactory>();
		}
		if (type == typeof(IProPresenterDOFactoryProvider))
		{
			return GetService<IProPresenterDOFactoryProvider>();
		}
		if (type == typeof(IMessageDialogService))
		{
			return GetService<IMessageDialogService>();
		}
		if (type == typeof(IPresentationFactory))
		{
			return GetService<IPresentationFactory>();
		}
		if (type == typeof(IPowerPointImageLoader))
		{
			return GetService<IPowerPointImageLoader>();
		}
		if (type == typeof(IPowerPointEvents))
		{
			return GetService<IPowerPointEvents>();
		}
		if (type == typeof(TypefaceLibrary))
		{
			return GetService<TypefaceLibrary>();
		}
		if (type == typeof(IFontDetector))
		{
			return GetService<IFontDetector>();
		}
		if (type == typeof(IFontDetectionSessionFactory))
		{
			return GetService<IFontDetectionSessionFactory>();
		}
		if (type == typeof(IMissingFontService))
		{
			return GetService<IMissingFontService>();
		}
		if (type == typeof(IProPresenterCueFactory))
		{
			return GetService<IProPresenterCueFactory>();
		}
		if (type == typeof(IFontReplacementEventPublisher))
		{
			return GetService<IFontReplacementEventPublisher>();
		}
		if (type == typeof(IMissingFontWindowProvider))
		{
			return GetService<IMissingFontWindowProvider>();
		}
		if (type == typeof(ICorePowerPointImportService))
		{
			return GetService<ICorePowerPointImportService>();
		}
		if (type == typeof(IPowerPointImportService))
		{
			return GetService<IPowerPointImportService>();
		}
		if (type == typeof(IImportHelperServices))
		{
			return GetService<IImportHelperServices>();
		}
		if (type == typeof(IImportLocationSelectionDialogService))
		{
			return GetService<IImportLocationSelectionDialogService>();
		}
		if (type == typeof(IManageMediaAutoMaticallyProvider))
		{
			return GetService<IManageMediaAutoMaticallyProvider>();
		}
		if (type == typeof(IFileCreator))
		{
			return GetService<IFileCreator>();
		}
		if (type == typeof(ISyncDataFactory))
		{
			return GetService<ISyncDataFactory>();
		}
		if (type == typeof(IScreenArrangementFactory))
		{
			return GetService<IScreenArrangementFactory>();
		}
		if (type == typeof(IAudioSettingsAnalyticsEventPublisher))
		{
			return GetService<IAudioSettingsAnalyticsEventPublisher>();
		}
		if (type == typeof(IAudioInputCollection))
		{
			return GetService<IAudioInputCollection>();
		}
		if (type == typeof(ICrdtProtoDirectoryFileScanner))
		{
			return GetService<ICrdtProtoDirectoryFileScanner>();
		}
		if (type == typeof(IMaskCollection))
		{
			return GetService<IMaskCollection>();
		}
		if (type == typeof(StagePresentation))
		{
			return GetService<StagePresentation>();
		}
		if (type == typeof(ILocalDocumentSyncerFactory))
		{
			return GetService<ILocalDocumentSyncerFactory>();
		}
		if (type == typeof(IOutputConfiguration))
		{
			return GetService<IOutputConfiguration>();
		}
		if (type == typeof(ICollectionStorage))
		{
			return GetService<ICollectionStorage>();
		}
		if (type == typeof(IImportProcessFactory))
		{
			return GetService<IImportProcessFactory>();
		}
		if (type == typeof(IAsyncFileImporter))
		{
			return GetService<IAsyncFileImporter>();
		}
		if (type == typeof(IMigrationSource))
		{
			return GetService<IMigrationSource>();
		}
		if (type == typeof(INetwork))
		{
			return GetService<INetwork>();
		}
		if (type == typeof(ITimecodeSettingsRepository))
		{
			return GetService<ITimecodeSettingsRepository>();
		}
		if (type == typeof(IImport))
		{
			return GetService<IImport>();
		}
		if (type == typeof(IStoredPcoOptions))
		{
			return GetService<IStoredPcoOptions>();
		}
		if (type == typeof(ISongSelectConsumer))
		{
			return GetService<ISongSelectConsumer>();
		}
		if (type == typeof(IReportRepository))
		{
			return GetService<IReportRepository>();
		}
		if (type == typeof(IGeneral))
		{
			return GetService<IGeneral>();
		}
		if (type == typeof(IEnableAnalyticsProvider))
		{
			return GetService<IEnableAnalyticsProvider>();
		}
		if (type == typeof(IDisplay))
		{
			return GetService<IDisplay>();
		}
		if (type == typeof(ISync))
		{
			return GetService<ISync>();
		}
		if (type == typeof(ILayout))
		{
			return GetService<ILayout>();
		}
		if (type == typeof(IPlaylistActionValidatorFactory))
		{
			return GetService<IPlaylistActionValidatorFactory>();
		}
		if (type == typeof(IActionBinderFactory))
		{
			return GetService<IActionBinderFactory>();
		}
		if (type == typeof(IEncoderValidator))
		{
			return GetService<IEncoderValidator>();
		}
		if (type == typeof(IThemeImportProcessFactory))
		{
			return GetService<IThemeImportProcessFactory>();
		}
		if (type == typeof(IThemeAnalyiticEvents))
		{
			return GetService<IThemeAnalyiticEvents>();
		}
		if (type == typeof(IDxDiagReaderFactory))
		{
			return GetService<IDxDiagReaderFactory>();
		}
		if (type == typeof(ISystemInfoProvider))
		{
			return GetService<ISystemInfoProvider>();
		}
		if (type == typeof(IApplicationLaunchEventPublisher))
		{
			return GetService<IApplicationLaunchEventPublisher>();
		}
		if (type == typeof(ICaptureAnalyticEventsPublisher))
		{
			return GetService<ICaptureAnalyticEventsPublisher>();
		}
		if (type == typeof(IStartupSettingsEventsPublisher))
		{
			return GetService<IStartupSettingsEventsPublisher>();
		}
		if (type == typeof(IUiPreferencesAnalyticEventsPublisher))
		{
			return GetService<IUiPreferencesAnalyticEventsPublisher>();
		}
		if (type == typeof(ITestPatternAnalyticEventsPublisher))
		{
			return GetService<ITestPatternAnalyticEventsPublisher>();
		}
		if (type == typeof(IWelcomeAnalyticEventsPublisher))
		{
			return GetService<IWelcomeAnalyticEventsPublisher>();
		}
		if (type == typeof(ITimecodeAnalyticsEvents))
		{
			return GetService<ITimecodeAnalyticsEvents>();
		}
		if (type == typeof(IPlaybackMarkerAnalyticsEvents))
		{
			return GetService<IPlaybackMarkerAnalyticsEvents>();
		}
		if (type == typeof(ITimelineAnalyticsEvents))
		{
			return GetService<ITimelineAnalyticsEvents>();
		}
		if (type == typeof(ICCLIReportAnalyticsEvents))
		{
			return GetService<ICCLIReportAnalyticsEvents>();
		}
		if (type == typeof(IMediaCleanupSizeEventPublisher))
		{
			return GetService<IMediaCleanupSizeEventPublisher>();
		}
		if (type == typeof(IMediaAnalyticsSender))
		{
			return GetService<IMediaAnalyticsSender>();
		}
		if (type == typeof(IWorkspaceAnalyticsEventPublisher))
		{
			return GetService<IWorkspaceAnalyticsEventPublisher>();
		}
		if (type == typeof(ICloudOnboardingAnalyticsEventPublisher))
		{
			return GetService<ICloudOnboardingAnalyticsEventPublisher>();
		}
		if (type == typeof(IFileDownloadObserverFactory))
		{
			return GetService<IFileDownloadObserverFactory>();
		}
		if (type == typeof(IProContentDownloadProcessFactory))
		{
			return GetService<IProContentDownloadProcessFactory>();
		}
		if (type == typeof(IStopwatchFactory))
		{
			return GetService<IStopwatchFactory>();
		}
		if (type == typeof(ICacheFactory))
		{
			return GetService<ICacheFactory>();
		}
		if (type == typeof(IProContentProvider))
		{
			return GetService<IProContentProvider>();
		}
		if (type == typeof(IUriCacheService<IReadOnlyList<IAnimationFrame>>))
		{
			return GetService<IUriCacheService<IReadOnlyList<IAnimationFrame>>>();
		}
		if (type == typeof(IOutputRepository))
		{
			return GetService<IOutputRepository>();
		}
		if (type == typeof(ICommunicationOutput))
		{
			return GetService<ICommunicationOutput>();
		}
		if (type == typeof(IOutputService))
		{
			return GetService<IOutputService>();
		}
		if (type == typeof(IErrorPrompt))
		{
			return GetService<IErrorPrompt>();
		}
		if (type == typeof(IResiPlugin))
		{
			return GetService<IResiPlugin>();
		}
		if (type == typeof(IResiCustomEndpointsStore))
		{
			return GetService<IResiCustomEndpointsStore>();
		}
		if (type == typeof(IResiEndpoints))
		{
			return GetService<IResiEndpoints>();
		}
		if (type == typeof(IResiWebClient))
		{
			return GetService<IResiWebClient>();
		}
		if (type == typeof(IMessages<AppMessages>))
		{
			return GetService<IMessages<AppMessages>>();
		}
		if (type == typeof(IUpdateClient))
		{
			return GetService<IUpdateClient>();
		}
		if (type == typeof(ITestPatternPropertyFactory))
		{
			return GetService<ITestPatternPropertyFactory>();
		}
		if (type == typeof(ITestPatternDefinitionFactory))
		{
			return GetService<ITestPatternDefinitionFactory>();
		}
		if (type == typeof(ITestPatternStateFactory))
		{
			return GetService<ITestPatternStateFactory>();
		}
		if (type == typeof(ITestPatternPersistence))
		{
			return GetService<ITestPatternPersistence>();
		}
		if (type == typeof(ITestPatternService))
		{
			return GetService<ITestPatternService>();
		}
		if (type == typeof(IFileProvider))
		{
			return GetService<IFileProvider>();
		}
		if (type == typeof(ISyncDataProvider))
		{
			return GetService<ISyncDataProvider>();
		}
		if (type == typeof(ISyncActionProvider))
		{
			return GetService<ISyncActionProvider>();
		}
		if (type == typeof(IAppContinuationService))
		{
			return GetService<IAppContinuationService>();
		}
		if (type == typeof(IAppInstallerFactory))
		{
			return GetService<IAppInstallerFactory>();
		}
		if (type == typeof(IAppDownloadFactory))
		{
			return GetService<IAppDownloadFactory>();
		}
		if (type == typeof(IAppUpdateUserDialogService))
		{
			return GetService<IAppUpdateUserDialogService>();
		}
		if (type == typeof(IAppUpdateService))
		{
			return GetService<IAppUpdateService>();
		}
		if (type == typeof(IIndexingService))
		{
			return GetService<IIndexingService>();
		}
		if (type == typeof(IPresentationCapableSyncDataFactory))
		{
			return GetService<IPresentationCapableSyncDataFactory>();
		}
		if (type == typeof(IBibleDataStore))
		{
			return GetService<IBibleDataStore>();
		}
		if (type == typeof(IBibleProvider))
		{
			return GetService<IBibleProvider>();
		}
		if (type == typeof(IMultiTracksConsumer))
		{
			return GetService<IMultiTracksConsumer>();
		}
		if (type == typeof(IAuthenticatorFactory))
		{
			return GetService<IAuthenticatorFactory>();
		}
		if (type == typeof(IPCOConsumer))
		{
			return GetService<IPCOConsumer>();
		}
		if (type == typeof(IPCOUpdater))
		{
			return GetService<IPCOUpdater>();
		}
		if (type == typeof(ThumbnailViewSettings))
		{
			return GetService<ThumbnailViewSettings>();
		}
		if (type == typeof(IExportProcessFactory))
		{
			return GetService<IExportProcessFactory>();
		}
		if (type == typeof(IInputActions))
		{
			return GetService<IInputActions>();
		}
		if (type == typeof(IMediaImportService))
		{
			return GetService<IMediaImportService>();
		}
		if (type == typeof(IMediaFileProvider))
		{
			return GetService<IMediaFileProvider>();
		}
		if (type == typeof(IWorkspaceInspectionService))
		{
			return GetService<IWorkspaceInspectionService>();
		}
		if (type == typeof(ICloudWorkspaceService))
		{
			return GetService<ICloudWorkspaceService>();
		}
		if (type == typeof(ICloudConversionService))
		{
			return GetService<ICloudConversionService>();
		}
		if (type == typeof(ICloudOnboardingService))
		{
			return GetService<ICloudOnboardingService>();
		}
		if (type == typeof(IMatchSongsInteractor))
		{
			return GetService<IMatchSongsInteractor>();
		}
		if (type == typeof(IWorkspaceDocumentOrchestrator))
		{
			return GetService<IWorkspaceDocumentOrchestrator>();
		}
		if (type == typeof(ThemeCollection))
		{
			return GetService<ThemeCollection>();
		}
		if (type == typeof(IThemeCollection))
		{
			return GetService<IThemeCollection>();
		}
		if (type == typeof(IFileFilterProvider))
		{
			return GetService<IFileFilterProvider>();
		}
		if (type == typeof(IFileUtility))
		{
			return GetService<IFileUtility>();
		}
		if (type == typeof(IProcessHelper))
		{
			return GetService<IProcessHelper>();
		}
		if (type == typeof(INetworkChange))
		{
			return GetService<INetworkChange>();
		}
		if (type == typeof(IFileObservatory))
		{
			return GetService<IFileObservatory>();
		}
		if (type == typeof(ISettingsSearchFactory))
		{
			return GetService<ISettingsSearchFactory>();
		}
		if (type == typeof(INetworkDialogService))
		{
			return GetService<INetworkDialogService>();
		}
		if (type == typeof(IMediaCleanupPrompt))
		{
			return GetService<IMediaCleanupPrompt>();
		}
		if (type == typeof(IMidiDeviceSettingsVM))
		{
			return GetService<IMidiDeviceSettingsVM>();
		}
		if (type == typeof(IMidiWindowProvider))
		{
			return GetService<IMidiWindowProvider>();
		}
		if (type == typeof(IFileSelectorService))
		{
			return GetService<IFileSelectorService>();
		}
		if (type == typeof(ICCLIReportPrompt))
		{
			return GetService<ICCLIReportPrompt>();
		}
		if (type == typeof(INdiInputsSettingsDialogService))
		{
			return GetService<INdiInputsSettingsDialogService>();
		}
		if (type == typeof(IAirCastPrompt))
		{
			return GetService<IAirCastPrompt>();
		}
		if (type == typeof(IAirCastConfiguration))
		{
			return GetService<IAirCastConfiguration>();
		}
		if (type == typeof(IInstallFileExecutor))
		{
			return GetService<IInstallFileExecutor>();
		}
		if (type == typeof(IAirCastPluginDownload))
		{
			return GetService<IAirCastPluginDownload>();
		}
		if (type == typeof(ICCLIReportCollectionVM))
		{
			return GetService<ICCLIReportCollectionVM>();
		}
		if (type == typeof(ICopyrightSettingsVM))
		{
			return GetService<ICopyrightSettingsVM>();
		}
		if (type == typeof(INetworkCommandFactory))
		{
			return GetService<INetworkCommandFactory>();
		}
		if (type == typeof(INetworkCommandTrigger))
		{
			return GetService<INetworkCommandTrigger>();
		}
		if (type == typeof(INetworkTriggerDataTransferFactory))
		{
			return GetService<INetworkTriggerDataTransferFactory>();
		}
		if (type == typeof(IResiController))
		{
			return GetService<IResiController>();
		}
		if (type == typeof(ICrashRecovery))
		{
			return GetService<ICrashRecovery>();
		}
		if (type == typeof(ICapturePrompt))
		{
			return GetService<ICapturePrompt>();
		}
		if (type == typeof(CaptureController))
		{
			return GetService<CaptureController>();
		}
		if (type == typeof(ICaptureService))
		{
			return GetService<ICaptureService>();
		}
		if (type == typeof(ITimedPlaybackRepository))
		{
			return GetService<ITimedPlaybackRepository>();
		}
		if (type == typeof(ITimelineService))
		{
			return GetService<ITimelineService>();
		}
		if (type == typeof(ITimecodeService))
		{
			return GetService<ITimecodeService>();
		}
		if (type == typeof(ITimelineManager))
		{
			return GetService<ITimelineManager>();
		}
		if (type == typeof(ITransferHandlerFactory))
		{
			return GetService<ITransferHandlerFactory>();
		}
		if (type == typeof(CoreManager))
		{
			return GetService<CoreManager>();
		}
		if (type == typeof(ICoreManager))
		{
			return GetService<ICoreManager>();
		}
		if (type == typeof(IGeneralSettingsVM))
		{
			return GetService<IGeneralSettingsVM>();
		}
		if (type == typeof(ICommandSender))
		{
			return GetService<ICommandSender>();
		}
		if (type == typeof(IServerStateHandler))
		{
			return GetService<IServerStateHandler>();
		}
		if (type == typeof(INetworkEnvironment))
		{
			return GetService<INetworkEnvironment>();
		}
		if (type == typeof(ILinkRequestFactory))
		{
			return GetService<ILinkRequestFactory>();
		}
		if (type == typeof(INetworkLinkService))
		{
			return GetService<INetworkLinkService>();
		}
		if (type == typeof(INetworkLinkPrompt))
		{
			return GetService<INetworkLinkPrompt>();
		}
		if (type == typeof(INetworkLinkVM))
		{
			return GetService<INetworkLinkVM>();
		}
		if (type == typeof(INetworkSettingsVM))
		{
			return GetService<INetworkSettingsVM>();
		}
		if (type == typeof(IRegistrationUnlockCodeVM))
		{
			return GetService<IRegistrationUnlockCodeVM>();
		}
		if (type == typeof(IRegistrationSubpageVMFactory))
		{
			return GetService<IRegistrationSubpageVMFactory>();
		}
		if (type == typeof(IOrganizationConsumer))
		{
			return GetService<IOrganizationConsumer>();
		}
		if (type == typeof(IUserAvatarProvider))
		{
			return GetService<IUserAvatarProvider>();
		}
		if (type == typeof(IRegistrationMainPageVM))
		{
			return GetService<IRegistrationMainPageVM>();
		}
		if (type == typeof(IAccountCenterVM))
		{
			return GetService<IAccountCenterVM>();
		}
		if (type == typeof(IUpdatesSettingsVM))
		{
			return GetService<IUpdatesSettingsVM>();
		}
		if (type == typeof(IClockSourceProvider))
		{
			return GetService<IClockSourceProvider>();
		}
		if (type == typeof(IClockSourceService))
		{
			return GetService<IClockSourceService>();
		}
		if (type == typeof(IClockSourceVM))
		{
			return GetService<IClockSourceVM>();
		}
		if (type == typeof(IScreenSettingsVM))
		{
			return GetService<IScreenSettingsVM>();
		}
		if (type == typeof(IInputsSettingsService))
		{
			return GetService<IInputsSettingsService>();
		}
		if (type == typeof(IVideoInputsSettingsVM))
		{
			return GetService<IVideoInputsSettingsVM>();
		}
		if (type == typeof(IVideoInputItemVMFactory))
		{
			return GetService<IVideoInputItemVMFactory>();
		}
		if (type == typeof(IAudioInputsSettingsVM))
		{
			return GetService<IAudioInputsSettingsVM>();
		}
		if (type == typeof(INdiInputsSettingsVM))
		{
			return GetService<INdiInputsSettingsVM>();
		}
		if (type == typeof(IInputsSettingsVM))
		{
			return GetService<IInputsSettingsVM>();
		}
		if (type == typeof(IDevicesSettingsVM))
		{
			return GetService<IDevicesSettingsVM>();
		}
		if (type == typeof(IMediaSettingsVMFactory))
		{
			return GetService<IMediaSettingsVMFactory>();
		}
		if (type == typeof(IMediaSearchPathsSettingsVM))
		{
			return GetService<IMediaSearchPathsSettingsVM>();
		}
		if (type == typeof(IMediaFilesProvider))
		{
			return GetService<IMediaFilesProvider>();
		}
		if (type == typeof(IMediaCleanupService))
		{
			return GetService<IMediaCleanupService>();
		}
		if (type == typeof(IMediaCleanupVM))
		{
			return GetService<IMediaCleanupVM>();
		}
		if (type == typeof(IMediaSettingsVM))
		{
			return GetService<IMediaSettingsVM>();
		}
		if (type == typeof(IAudioSettingsVM))
		{
			return GetService<IAudioSettingsVM>();
		}
		if (type == typeof(IImportSettingsVM))
		{
			return GetService<IImportSettingsVM>();
		}
		if (type == typeof(IPlanningCenterSettingsVM))
		{
			return GetService<IPlanningCenterSettingsVM>();
		}
		if (type == typeof(IMultiTracksSettingsVM))
		{
			return GetService<IMultiTracksSettingsVM>();
		}
		if (type == typeof(IAutoReportDialogPrompt))
		{
			return GetService<IAutoReportDialogPrompt>();
		}
		if (type == typeof(ISongSelectSettingsVM))
		{
			return GetService<ISongSelectSettingsVM>();
		}
		if (type == typeof(IResiUpdateVM))
		{
			return GetService<IResiUpdateVM>();
		}
		if (type == typeof(ILoginDialogFactory))
		{
			return GetService<ILoginDialogFactory>();
		}
		if (type == typeof(IResiPrompt))
		{
			return GetService<IResiPrompt>();
		}
		if (type == typeof(IResiAuthorizationInteractor))
		{
			return GetService<IResiAuthorizationInteractor>();
		}
		if (type == typeof(IResiSettingsVM))
		{
			return GetService<IResiSettingsVM>();
		}
		if (type == typeof(IIntegrationsSettingsVM))
		{
			return GetService<IIntegrationsSettingsVM>();
		}
		if (type == typeof(IGroupLabelItemVMFactory))
		{
			return GetService<IGroupLabelItemVMFactory>();
		}
		if (type == typeof(IGroupsSettingsVM))
		{
			return GetService<IGroupsSettingsVM>();
		}
		if (type == typeof(ILabelItemVMFactory))
		{
			return GetService<ILabelItemVMFactory>();
		}
		if (type == typeof(ILabelsSettingsVM))
		{
			return GetService<ILabelsSettingsVM>();
		}
		if (type == typeof(ISyncController))
		{
			return GetService<ISyncController>();
		}
		if (type == typeof(ISyncSettingsVM))
		{
			return GetService<ISyncSettingsVM>();
		}
		if (type == typeof(IEnumerable<ISettingsListItem>))
		{
			return GetService<IEnumerable<ISettingsListItem>>();
		}
		if (type == typeof(ISettingsSearchEngine))
		{
			return GetService<ISettingsSearchEngine>();
		}
		if (type == typeof(ISettingsSearchVM))
		{
			return GetService<ISettingsSearchVM>();
		}
		if (type == typeof(ISettingsNavigationVM))
		{
			return GetService<ISettingsNavigationVM>();
		}
		if (type == typeof(ISettingsVM))
		{
			return GetService<ISettingsVM>();
		}
		if (type == typeof(INotificationVMFactory))
		{
			return GetService<INotificationVMFactory>();
		}
		if (type == typeof(IRegistrationRequestSender))
		{
			return GetService<IRegistrationRequestSender>();
		}
		if (type == typeof(INotificationCallbackHandler))
		{
			return GetService<INotificationCallbackHandler>();
		}
		if (type == typeof(INotificationService))
		{
			return GetService<INotificationService>();
		}
		if (type == typeof(INotificationCollectionVM))
		{
			return GetService<INotificationCollectionVM>();
		}
		if (type == typeof(IChangeDirectoryProcessFactory))
		{
			return GetService<IChangeDirectoryProcessFactory>();
		}
		if (type == typeof(IChangeWorkspaceHandler))
		{
			return GetService<IChangeWorkspaceHandler>();
		}
		if (type == typeof(CloudOnboardingVM))
		{
			return GetService<CloudOnboardingVM>();
		}
		if (type == typeof(ICloudOnboardingVM))
		{
			return GetService<ICloudOnboardingVM>();
		}
		if (type == typeof(ICloudOnboardingShellNavigator))
		{
			return GetService<ICloudOnboardingShellNavigator>();
		}
		if (type == typeof(ICloudOnboardingEligibilityVM))
		{
			return GetService<ICloudOnboardingEligibilityVM>();
		}
		if (type == typeof(ICloudOnboardingManageMediaVM))
		{
			return GetService<ICloudOnboardingManageMediaVM>();
		}
		if (type == typeof(ICloudOnboardingPricingVM))
		{
			return GetService<ICloudOnboardingPricingVM>();
		}
		if (type == typeof(ICloudOnboardingDoneVM))
		{
			return GetService<ICloudOnboardingDoneVM>();
		}
		if (type == typeof(ICloudOnboardingLocalWorkspacesVM))
		{
			return GetService<ICloudOnboardingLocalWorkspacesVM>();
		}
		if (type == typeof(ICloudTeaseVM))
		{
			return GetService<ICloudTeaseVM>();
		}
		if (type == typeof(ICloudTeaseWindowProvider))
		{
			return GetService<ICloudTeaseWindowProvider>();
		}
		if (type == typeof(IManageWorkspacesWindowProvider))
		{
			return GetService<IManageWorkspacesWindowProvider>();
		}
		if (type == typeof(IMissingFontVM))
		{
			return GetService<IMissingFontVM>();
		}
		if (type == typeof(ICalendarPrompt))
		{
			return GetService<ICalendarPrompt>();
		}
		if (type == typeof(IRTMPPrompt))
		{
			return GetService<IRTMPPrompt>();
		}
		if (type == typeof(IProContentDialogService))
		{
			return GetService<IProContentDialogService>();
		}
		if (type == typeof(IMediaImportDownloadDialogService))
		{
			return GetService<IMediaImportDownloadDialogService>();
		}
		if (type == typeof(IDownloadsDialogService))
		{
			return GetService<IDownloadsDialogService>();
		}
		if (type == typeof(IMediaCueThumbnailOverlayVMFactory))
		{
			return GetService<IMediaCueThumbnailOverlayVMFactory>();
		}
		if (type == typeof(IDownloadVMsFactory))
		{
			return GetService<IDownloadVMsFactory>();
		}
		if (type == typeof(IPropPrompts))
		{
			return GetService<IPropPrompts>();
		}
		if (type == typeof(IHardwareAlphaConfigurationVMFactory))
		{
			return GetService<IHardwareAlphaConfigurationVMFactory>();
		}
		if (type == typeof(IAlphaKeySettingsVMFactory))
		{
			return GetService<IAlphaKeySettingsVMFactory>();
		}
		if (type == typeof(ICaptureController))
		{
			return GetService<ICaptureController>();
		}
		if (type == typeof(IResiService))
		{
			return GetService<IResiService>();
		}
		if (type == typeof(IUserFeedbackConsumer))
		{
			return GetService<IUserFeedbackConsumer>();
		}
		if (type == typeof(IBuildAppMetaDataFile))
		{
			return GetService<IBuildAppMetaDataFile>();
		}
		if (type == typeof(IUserAttachmentVMFactory))
		{
			return GetService<IUserAttachmentVMFactory>();
		}
		if (type == typeof(IAttachmentsUploader))
		{
			return GetService<IAttachmentsUploader>();
		}
		if (type == typeof(IAttachmentUploadJobFactory))
		{
			return GetService<IAttachmentUploadJobFactory>();
		}
		if (type == typeof(IFeedbackVM))
		{
			return GetService<IFeedbackVM>();
		}
		if (type == typeof(ICrashReportingVM))
		{
			return GetService<ICrashReportingVM>();
		}
		if (type == typeof(IAttachmentUploadVM))
		{
			return GetService<IAttachmentUploadVM>();
		}
		if (type == typeof(ICrashReportUserFeedbackDialogProvider))
		{
			return GetService<ICrashReportUserFeedbackDialogProvider>();
		}
		if (type == typeof(IWhatsNewContentProviderFromJson))
		{
			return GetService<IWhatsNewContentProviderFromJson>();
		}
		if (type == typeof(IFeatureFactory))
		{
			return GetService<IFeatureFactory>();
		}
		if (type == typeof(IWhatsNewV2VM))
		{
			return GetService<IWhatsNewV2VM>();
		}
		if (type == typeof(IMediaActionService))
		{
			return GetService<IMediaActionService>();
		}
		if (type == typeof(ITimelineVMFactory))
		{
			return GetService<ITimelineVMFactory>();
		}
		if (type == typeof(ITimelineItemVMFactory))
		{
			return GetService<ITimelineItemVMFactory>();
		}
		if (type == typeof(IWorkspaceItemVMFactory))
		{
			return GetService<IWorkspaceItemVMFactory>();
		}
		if (type == typeof(IActionsMenuVMFactory))
		{
			return GetService<IActionsMenuVMFactory>();
		}
		if (type == typeof(IOutputScreenVMFactory))
		{
			return GetService<IOutputScreenVMFactory>();
		}
		if (type == typeof(IScreenSelectorVM))
		{
			return GetService<IScreenSelectorVM>();
		}
		if (type == typeof(IWindowedOutputVM))
		{
			return GetService<IWindowedOutputVM>();
		}
		if (type == typeof(IOutputPreviewVMFactory))
		{
			return GetService<IOutputPreviewVMFactory>();
		}
		if (type == typeof(IInternalCoreManager))
		{
			return GetService<IInternalCoreManager>();
		}
		if (type == typeof(ITriggeringFactory))
		{
			return GetService<ITriggeringFactory>();
		}
		if (type == typeof(ICalendarService))
		{
			return GetService<ICalendarService>();
		}
		if (type == typeof(IExportService))
		{
			return GetService<IExportService>();
		}
		if (type == typeof(ILibraryService))
		{
			return GetService<ILibraryService>();
		}
		if (type == typeof(IClipboardProvider))
		{
			return GetService<IClipboardProvider>();
		}
		if (type == typeof(IPasteStrategy))
		{
			return GetService<IPasteStrategy>();
		}
		if (type == typeof(IEditorService))
		{
			return GetService<IEditorService>();
		}
		if (type == typeof(PlaylistTemplateCollection))
		{
			return GetService<PlaylistTemplateCollection>();
		}
		if (type == typeof(IPlaylistTemplatesService))
		{
			return GetService<IPlaylistTemplatesService>();
		}
		if (type == typeof(ISizeProvider))
		{
			return GetService<ISizeProvider>();
		}
		if (type == typeof(IProPresenterCueVMFactory))
		{
			return GetService<IProPresenterCueVMFactory>();
		}
		if (type == typeof(IProContentDownloader))
		{
			return GetService<IProContentDownloader>();
		}
		if (type == typeof(IMacroPrompt))
		{
			return GetService<IMacroPrompt>();
		}
		if (type == typeof(ISlidePreviewService))
		{
			return GetService<ISlidePreviewService>();
		}
		if (type == typeof(PropAutoClearHandler))
		{
			return GetService<PropAutoClearHandler>();
		}
		if (type == typeof(IPropAutoClearService))
		{
			return GetService<IPropAutoClearService>();
		}
		if (type == typeof(ILegacyPurchaseBiblesDialogService))
		{
			return GetService<ILegacyPurchaseBiblesDialogService>();
		}
		if (type == typeof(IMediaValidator))
		{
			return GetService<IMediaValidator>();
		}
		if (type == typeof(IMediaProvider))
		{
			return GetService<IMediaProvider>();
		}
		if (type == typeof(IToastNotificationService))
		{
			return GetService<IToastNotificationService>();
		}
		if (type == typeof(IWorkspaceDeletedPrompt))
		{
			return GetService<IWorkspaceDeletedPrompt>();
		}
		if (type == typeof(IWorkspaceCollectionVM))
		{
			return GetService<IWorkspaceCollectionVM>();
		}
		if (type == typeof(IMainLayoutVM))
		{
			return GetService<IMainLayoutVM>();
		}
		if (type == typeof(IThemeSlideMenuVM))
		{
			return GetService<IThemeSlideMenuVM>();
		}
		if (type == typeof(IArrangementVM))
		{
			return GetService<IArrangementVM>();
		}
		if (type == typeof(ITimecodeItemVMFactory))
		{
			return GetService<ITimecodeItemVMFactory>();
		}
		if (type == typeof(ITimecodeVM))
		{
			return GetService<ITimecodeVM>();
		}
		if (type == typeof(IHeaderContentContextMenuVM))
		{
			return GetService<IHeaderContentContextMenuVM>();
		}
		if (type == typeof(IWorkspaceSwitchValidator))
		{
			return GetService<IWorkspaceSwitchValidator>();
		}
		if (type == typeof(IApplicationFailureMessageService))
		{
			return GetService<IApplicationFailureMessageService>();
		}
		if (type == typeof(IFeatureFlagService))
		{
			return GetService<IFeatureFlagService>();
		}
		if (type == typeof(ISpellChecker))
		{
			return GetService<ISpellChecker>();
		}
		if (type == typeof(IReceiveService))
		{
			return GetService<IReceiveService>();
		}
		if (type == typeof(IPresentationHandlerOperationService))
		{
			return GetService<IPresentationHandlerOperationService>();
		}
		if (type == typeof(ISettingsDataToCoreSender))
		{
			return GetService<ISettingsDataToCoreSender>();
		}
		if (type == typeof(IAPIv1Dependencies))
		{
			return GetService<IAPIv1Dependencies>();
		}
		if (type == typeof(ISharedData<AppData>))
		{
			return GetService<ISharedData<AppData>>();
		}
		if (type == typeof(Func<IRegistrationOperationFactory>))
		{
			return GetService<Func<IRegistrationOperationFactory>>();
		}
		if (type == typeof(IStartupArgumentsExecutor))
		{
			return GetService<IStartupArgumentsExecutor>();
		}
		if (type == typeof(IMessageHandler))
		{
			return GetService<IMessageHandler>();
		}
		if (type == typeof(IDocumentDiagnosticsProvider))
		{
			return GetService<IDocumentDiagnosticsProvider>();
		}
		if (type == typeof(ILaunchPopUpProvider))
		{
			return GetService<ILaunchPopUpProvider>();
		}
		if (type == typeof(IPropAutoClearHandler))
		{
			return GetService<IPropAutoClearHandler>();
		}
		if (type == typeof(ISendDataResponseHandlerProvider))
		{
			return GetService<ISendDataResponseHandlerProvider>();
		}
		if (type == typeof(IDataProcessor<SendDataResponse>))
		{
			return GetService<IDataProcessor<SendDataResponse>>();
		}
		if (type == typeof(MediaInspectorConverter))
		{
			return GetService<MediaInspectorConverter>();
		}
		if (type == typeof(WarningTooltipConverter))
		{
			return GetService<WarningTooltipConverter>();
		}
		if (type == typeof(WebFillBrowserFactory))
		{
			return GetService<WebFillBrowserFactory>();
		}
		if (type == typeof(IWebFillBrowserFactory))
		{
			return GetService<IWebFillBrowserFactory>();
		}
		if (type == typeof(IActionDialogService))
		{
			return GetService<IActionDialogService>();
		}
		if (type == typeof(ITemplateVM))
		{
			return GetService<ITemplateVM>();
		}
		if (type == typeof(Func<MainWindow>))
		{
			return GetService<Func<MainWindow>>();
		}
		if (type == typeof(IInstanceValidator))
		{
			return GetService<IInstanceValidator>();
		}
		if (type == typeof(IWorkspaceInfoDumper))
		{
			return GetService<IWorkspaceInfoDumper>();
		}
		if (type == typeof(MainWindow))
		{
			return GetService<MainWindow>();
		}
		if (type == typeof(ICloudOnboardingWindowProvider))
		{
			return GetService<ICloudOnboardingWindowProvider>();
		}
		if (type == typeof(IMediaServiceV1))
		{
			return GetService<IMediaServiceV1>();
		}
		if (type == typeof(IMediaServiceV2))
		{
			return GetService<IMediaServiceV2>();
		}
		if (type == typeof(IActionFactoryService))
		{
			return GetService<IActionFactoryService>();
		}
		if (type == typeof(IWorkspacesVM))
		{
			return GetService<IWorkspacesVM>();
		}
		if (type == typeof(IEnumerable<IStartupArgumentsExecutor>))
		{
			return GetService<IEnumerable<IStartupArgumentsExecutor>>();
		}
		if (type == typeof(IEnumerable<IMessageHandler>))
		{
			return GetService<IEnumerable<IMessageHandler>>();
		}
		if (type == typeof(IServiceProvider))
		{
			return GetService<IServiceProvider>();
		}
		if (type == typeof(IServiceScopeFactory))
		{
			return GetService<IServiceScopeFactory>();
		}
		if (type == typeof(IServiceProviderIsService))
		{
			return GetService<IServiceProviderIsService>();
		}
		return null;
	}

	object? IKeyedServiceProvider.GetKeyedService(Type type, object? key)
	{
		if (type == typeof(System.Version) && key is string text && text == "OSVersion")
		{
			return GetVersion_OSVersion();
		}
		if (type == typeof(System.Action) && key is string text2 && text2 == "ShowRegistrationSettingsKey")
		{
			return GetAction_ShowRegistrationSettingsKey();
		}
		if (type == typeof(IOAuth2AuthorizationStore) && key is string text3 && text3 == "ProContentRegistrationAuthorizationStorageKey")
		{
			return GetIOAuth2AuthorizationStore_ProContentRegistrationAuthorizationStorageKey();
		}
		if (type == typeof(IOAuth2ClientInfoProvider) && key is string text4 && text4 == "ProContentRegistrationAuthorizationInfoProviderKey")
		{
			return GetIOAuth2ClientInfoProvider_ProContentRegistrationAuthorizationInfoProviderKey();
		}
		if (type == typeof(IIdProvider) && key is string text5 && text5 == "BugsnagIdProviderKey")
		{
			return GetIIdProvider_BugsnagIdProviderKey();
		}
		if (type == typeof(ISyncRepository<ISyncData>))
		{
			switch (key as string)
			{
			case "RemoteFileRepositoryKey":
				return GetISyncRepository_ISyncData_RemoteFileRepositoryKey();
			case "LocalFileRepositoryKey":
				return GetISyncRepository_ISyncData_LocalFileRepositoryKey();
			}
		}
		if (type == typeof(System.IO.Stream) && key is string text6 && text6 == "WhatsNewContentProviderFromJsonFileContentKey")
		{
			return GetStream_WhatsNewContentProviderFromJsonFileContentKey();
		}
		if (type == typeof(IApplicationEventHandler) && key is string text7 && text7 == "CoreManagerApplicationEventHandler")
		{
			return GetIApplicationEventHandler_CoreManagerApplicationEventHandler();
		}
		if (type == typeof(Func<bool>) && key is string text8 && text8 == "ShouldSuppressVisualIndicationKey")
		{
			return GetFunc_Boolean_ShouldSuppressVisualIndicationKey();
		}
		if (type == typeof(IProcessSupervisor) && key is string text9 && text9 == "WorkspaceHelperProcessSupervisor")
		{
			return GetIProcessSupervisor_WorkspaceHelperProcessSupervisor();
		}
		return null;
	}

	object IKeyedServiceProvider.GetRequiredKeyedService(Type type, object? key)
	{
		return ((IKeyedServiceProvider)this).GetKeyedService(type, key) ?? throw Jab.JabHelpers.CreateServiceNotFoundException(type, key?.ToString());
	}

	private void TryAddDisposable(object? value)
	{
		if (value is IDisposable || value is IAsyncDisposable)
		{
			lock (this)
			{
				(_disposables ?? (_disposables = new List<object>())).Add(value);
			}
		}
	}

	public void Dispose()
	{
		TryDispose(_IDatabaseService);
		TryDispose(_IFileSystem);
		TryDispose(_IThemeRepo);
		TryDispose(_IThemeService);
		TryDispose(_IMessageService);
		TryDispose(_ISqliteMigrationService);
		TryDispose(_ICookieManagerService);
		TryDispose(_App);
		TryDispose(_IProCoreInstance);
		TryDispose(_IFlagService);
		TryDispose(_ssAPIOutput);
		TryDispose(_IMediaMetadataCacheRepository);
		TryDispose(_IMediaMetadataCacheService);
		TryDispose(_IMetadataLoader);
		TryDispose(_IAssemblyInfoProvider);
		TryDispose(_Version_OSVersion);
		TryDispose(_IVersionInfoProvider);
		TryDispose(_IRestClientFactory);
		TryDispose(_IFileSystemUriCacheServiceFactory);
		TryDispose(_IUriCacheService_NullableBitmapSource);
		TryDispose(_IRegistrationUserDialogService);
		TryDispose(_IErrorPublisher);
		TryDispose(_ICoreApplication);
		TryDispose(_IRegistrationCallbackHandler);
		TryDispose(_NotificationCallbackHandler);
		TryDispose(_ProContentClientInformationProvider);
		TryDispose(_IInternetAccess);
		TryDispose(_JsonWebTokenHandler);
		TryDispose(_RegistrationStateHandler);
		TryDispose(_IAfterStartupCompleteQueue);
		TryDispose(_UserMessageHandler);
		TryDispose(_IRegistrationCallbackHandler_4);
		TryDispose(_IRegistrationCallbackHandler_5);
		TryDispose(_IRegistrationCallbackHandler_6);
		TryDispose(_IRegistrationCallbackHandler_7);
		TryDispose(_IRegistrationCallbackHandler_8);
		TryDispose(_IRegistrationCallbackHandler_9);
		TryDispose(_IRegistrationCallbackHandler_10);
		TryDispose(_IInternetAccessCheck);
		TryDispose(_IRegistrationCallbackHandler_11);
		TryDispose(_RegistrationClient);
		TryDispose(_IRegistrationOperationFactory);
		TryDispose(_IOAuth2AuthorizationStore_ProContentRegistrationAuthorizationStorageKey);
		TryDispose(_IProContentConsumer);
		TryDispose(_IDownloadManager);
		TryDispose(_IProContentAssetProvider);
		TryDispose(_IAudioSetup);
		TryDispose(_IAudioMapRecallService_DeviceChannelBus);
		TryDispose(_ILiveVideoInputCollection);
		TryDispose(_ITextDocumentFactory);
		TryDispose(_IEntityFactory);
		TryDispose(_IDocumentFactory);
		TryDispose(_IDocumentService);
		TryDispose(_IEntityFileLockFactory);
		TryDispose(_ICommonPathsWrapper);
		TryDispose(_IMediaService);
		TryDispose(_IWorkspaceService);
		TryDispose(_ICloudDiagnosticsPublisher);
		TryDispose(_IEntityDocumentRegistry);
		TryDispose(_IEntityDocumentSyncerFactory);
		TryDispose(_IMergedEntityFactory);
		TryDispose(_IProPresenterDOFactoryProvider);
		TryDispose(_IScreenArrangementFactory);
		TryDispose(_IAudioInputCollection);
		TryDispose(_ICrdtProtoDirectoryFileScanner);
		TryDispose(_IMaskCollection);
		TryDispose(_StagePresentation);
		TryDispose(_ILocalDocumentSyncerFactory);
		TryDispose(_IOutputConfiguration);
		TryDispose(_ICollectionStorage);
		TryDispose(_IImportProcessFactory);
		TryDispose(_INetwork);
		TryDispose(_ISongSelectConsumer);
		TryDispose(_IReportRepository);
		TryDispose(_IActionBinderFactory);
		TryDispose(_IEncoderValidator);
		TryDispose(_IIdProvider_BugsnagIdProviderKey);
		TryDispose(_IApplicationLaunchEventPublisher);
		TryDispose(_IProContentProvider);
		TryDispose(_IUriCacheService_IReadOnlyList_IAnimationFrame);
		TryDispose(_IOutputRepository);
		TryDispose(_ICommunicationOutput);
		TryDispose(_IErrorPrompt);
		TryDispose(_IResiPlugin);
		TryDispose(_IResiCustomEndpointsStore);
		TryDispose(_IResiWebClient);
		TryDispose(_IMessages_AppMessages);
		TryDispose(_IUpdateClient);
		TryDispose(_ITestPatternPersistence);
		TryDispose(_ITestPatternService);
		TryDispose(_IAppUpdateUserDialogService);
		TryDispose(_IAppUpdateService);
		TryDispose(_IBibleDataStore);
		TryDispose(_IBibleProvider);
		TryDispose(_IMultiTracksConsumer);
		TryDispose(_IPCOConsumer);
		TryDispose(_IPCOUpdater);
		TryDispose(_IExportProcessFactory);
		TryDispose(_IInputActions);
		TryDispose(_ICloudWorkspaceService);
		TryDispose(_ICloudOnboardingService);
		TryDispose(_IWorkspaceDocumentOrchestrator);
		TryDispose(_ThemeCollection);
		TryDispose(_IProcessHelper);
		TryDispose(_IFileObservatory);
		TryDispose(_IMidiDeviceSettingsVM);
		TryDispose(_IMidiWindowProvider);
		TryDispose(_IAirCastConfiguration);
		TryDispose(_IInstallFileExecutor);
		TryDispose(_ICCLIReportCollectionVM);
		TryDispose(_ICopyrightSettingsVM);
		TryDispose(_INetworkCommandTrigger);
		TryDispose(_IResiController);
		TryDispose(_ICrashRecovery);
		TryDispose(_CaptureController);
		TryDispose(_ITimedPlaybackRepository);
		TryDispose(_ITimelineService);
		TryDispose(_ITimecodeService);
		TryDispose(_ITimelineManager);
		TryDispose(_CoreManager);
		TryDispose(_IGeneralSettingsVM);
		TryDispose(_ICommandSender);
		TryDispose(_IServerStateHandler);
		TryDispose(_INetworkEnvironment);
		TryDispose(_INetworkLinkService);
		TryDispose(_INetworkLinkPrompt);
		TryDispose(_INetworkLinkVM);
		TryDispose(_INetworkSettingsVM);
		TryDispose(_IRegistrationUnlockCodeVM);
		TryDispose(_IOrganizationConsumer);
		TryDispose(_IUserAvatarProvider);
		TryDispose(_IRegistrationMainPageVM);
		TryDispose(_IAccountCenterVM);
		TryDispose(_IUpdatesSettingsVM);
		TryDispose(_IClockSourceProvider);
		TryDispose(_IClockSourceService);
		TryDispose(_IClockSourceVM);
		TryDispose(_IScreenSettingsVM);
		TryDispose(_IVideoInputsSettingsVM);
		TryDispose(_IVideoInputItemVMFactory);
		TryDispose(_IAudioInputsSettingsVM);
		TryDispose(_INdiInputsSettingsVM);
		TryDispose(_IInputsSettingsVM);
		TryDispose(_IDevicesSettingsVM);
		TryDispose(_IMediaSearchPathsSettingsVM);
		TryDispose(_IMediaCleanupService);
		TryDispose(_IMediaCleanupVM);
		TryDispose(_IMediaSettingsVM);
		TryDispose(_IAudioSettingsVM);
		TryDispose(_IImportSettingsVM);
		TryDispose(_IPlanningCenterSettingsVM);
		TryDispose(_IMultiTracksSettingsVM);
		TryDispose(_ISongSelectSettingsVM);
		TryDispose(_IResiUpdateVM);
		TryDispose(_IResiAuthorizationInteractor);
		TryDispose(_IResiSettingsVM);
		TryDispose(_IIntegrationsSettingsVM);
		TryDispose(_IGroupsSettingsVM);
		TryDispose(_ILabelsSettingsVM);
		TryDispose(_ISyncController);
		TryDispose(_ISyncSettingsVM);
		TryDispose(_ISettingsSearchEngine);
		TryDispose(_ISettingsSearchVM);
		TryDispose(_ISettingsNavigationVM);
		TryDispose(_ISettingsVM);
		TryDispose(_INotificationVMFactory);
		TryDispose(_INotificationService);
		TryDispose(_INotificationCollectionVM);
		TryDispose(_IChangeWorkspaceHandler);
		TryDispose(_CloudOnboardingVM);
		TryDispose(_IManageWorkspacesWindowProvider);
		TryDispose(_IAttachmentsUploader);
		TryDispose(_IFeedbackVM);
		TryDispose(_ICrashReportingVM);
		TryDispose(_IAttachmentUploadVM);
		TryDispose(_IWhatsNewV2VM);
		TryDispose(_IMediaActionService);
		TryDispose(_IScreenSelectorVM);
		TryDispose(_IWindowedOutputVM);
		TryDispose(_ICalendarService);
		TryDispose(_ILibraryService);
		TryDispose(_IClipboardProvider);
		TryDispose(_IPasteStrategy);
		TryDispose(_ISizeProvider);
		TryDispose(_IMacroPrompt);
		TryDispose(_PropAutoClearHandler);
		TryDispose(_IPropAutoClearService);
		TryDispose(_IToastNotificationService);
		TryDispose(_IWorkspaceDeletedPrompt);
		TryDispose(_IWorkspaceCollectionVM);
		TryDispose(_IMainLayoutVM);
		TryDispose(_ITimecodeVM);
		TryDispose(_IWorkspaceSwitchValidator);
		TryDispose(_IFeatureFlagService);
		TryDispose(_IReceiveService);
		TryDispose(_ISettingsDataToCoreSender);
		TryDispose(_ISharedData_AppData);
		TryDispose(_IDocumentDiagnosticsProvider);
		TryDispose(_IPropAutoClearHandler);
		TryDispose(_ISendDataResponseHandlerProvider);
		TryDispose(_IDataProcessor_SendDataResponse);
		TryDispose(_WebFillBrowserFactory);
		TryDispose(_IWorkspaceInfoDumper);
		TryDispose(_MainWindow);
		TryDispose(_ICloudOnboardingWindowProvider);
		TryDispose(_IMediaServiceV1);
		TryDispose(_IMediaServiceV2);
		TryDispose(_IProcessSupervisor_WorkspaceHelperProcessSupervisor);
		TryDispose(_IActionFactoryService);
		TryDispose(_IWorkspacesVM);
		TryDispose(_IStartupArgumentsExecutor_1);
		TryDispose(_IMessageHandler_1);
		TryDispose(_IMessageHandler_2);
		TryDispose(_rootScope);
		if (_disposables == null)
		{
			return;
		}
		foreach (object disposable in _disposables)
		{
			TryDispose(disposable);
		}
		static void TryDispose(object? value)
		{
			(value as IDisposable)?.Dispose();
		}
	}

	public async ValueTask DisposeAsync()
	{
		await TryDispose(_IDatabaseService);
		await TryDispose(_IFileSystem);
		await TryDispose(_IThemeRepo);
		await TryDispose(_IThemeService);
		await TryDispose(_IMessageService);
		await TryDispose(_ISqliteMigrationService);
		await TryDispose(_ICookieManagerService);
		await TryDispose(_App);
		await TryDispose(_IProCoreInstance);
		await TryDispose(_IFlagService);
		await TryDispose(_ssAPIOutput);
		await TryDispose(_IMediaMetadataCacheRepository);
		await TryDispose(_IMediaMetadataCacheService);
		await TryDispose(_IMetadataLoader);
		await TryDispose(_IAssemblyInfoProvider);
		await TryDispose(_Version_OSVersion);
		await TryDispose(_IVersionInfoProvider);
		await TryDispose(_IRestClientFactory);
		await TryDispose(_IFileSystemUriCacheServiceFactory);
		await TryDispose(_IUriCacheService_NullableBitmapSource);
		await TryDispose(_IRegistrationUserDialogService);
		await TryDispose(_IErrorPublisher);
		await TryDispose(_ICoreApplication);
		await TryDispose(_IRegistrationCallbackHandler);
		await TryDispose(_NotificationCallbackHandler);
		await TryDispose(_ProContentClientInformationProvider);
		await TryDispose(_IInternetAccess);
		await TryDispose(_JsonWebTokenHandler);
		await TryDispose(_RegistrationStateHandler);
		await TryDispose(_IAfterStartupCompleteQueue);
		await TryDispose(_UserMessageHandler);
		await TryDispose(_IRegistrationCallbackHandler_4);
		await TryDispose(_IRegistrationCallbackHandler_5);
		await TryDispose(_IRegistrationCallbackHandler_6);
		await TryDispose(_IRegistrationCallbackHandler_7);
		await TryDispose(_IRegistrationCallbackHandler_8);
		await TryDispose(_IRegistrationCallbackHandler_9);
		await TryDispose(_IRegistrationCallbackHandler_10);
		await TryDispose(_IInternetAccessCheck);
		await TryDispose(_IRegistrationCallbackHandler_11);
		await TryDispose(_RegistrationClient);
		await TryDispose(_IRegistrationOperationFactory);
		await TryDispose(_IOAuth2AuthorizationStore_ProContentRegistrationAuthorizationStorageKey);
		await TryDispose(_IProContentConsumer);
		await TryDispose(_IDownloadManager);
		await TryDispose(_IProContentAssetProvider);
		await TryDispose(_IAudioSetup);
		await TryDispose(_IAudioMapRecallService_DeviceChannelBus);
		await TryDispose(_ILiveVideoInputCollection);
		await TryDispose(_ITextDocumentFactory);
		await TryDispose(_IEntityFactory);
		await TryDispose(_IDocumentFactory);
		await TryDispose(_IDocumentService);
		await TryDispose(_IEntityFileLockFactory);
		await TryDispose(_ICommonPathsWrapper);
		await TryDispose(_IMediaService);
		await TryDispose(_IWorkspaceService);
		await TryDispose(_ICloudDiagnosticsPublisher);
		await TryDispose(_IEntityDocumentRegistry);
		await TryDispose(_IEntityDocumentSyncerFactory);
		await TryDispose(_IMergedEntityFactory);
		await TryDispose(_IProPresenterDOFactoryProvider);
		await TryDispose(_IScreenArrangementFactory);
		await TryDispose(_IAudioInputCollection);
		await TryDispose(_ICrdtProtoDirectoryFileScanner);
		await TryDispose(_IMaskCollection);
		await TryDispose(_StagePresentation);
		await TryDispose(_ILocalDocumentSyncerFactory);
		await TryDispose(_IOutputConfiguration);
		await TryDispose(_ICollectionStorage);
		await TryDispose(_IImportProcessFactory);
		await TryDispose(_INetwork);
		await TryDispose(_ISongSelectConsumer);
		await TryDispose(_IReportRepository);
		await TryDispose(_IActionBinderFactory);
		await TryDispose(_IEncoderValidator);
		await TryDispose(_IIdProvider_BugsnagIdProviderKey);
		await TryDispose(_IApplicationLaunchEventPublisher);
		await TryDispose(_IProContentProvider);
		await TryDispose(_IUriCacheService_IReadOnlyList_IAnimationFrame);
		await TryDispose(_IOutputRepository);
		await TryDispose(_ICommunicationOutput);
		await TryDispose(_IErrorPrompt);
		await TryDispose(_IResiPlugin);
		await TryDispose(_IResiCustomEndpointsStore);
		await TryDispose(_IResiWebClient);
		await TryDispose(_IMessages_AppMessages);
		await TryDispose(_IUpdateClient);
		await TryDispose(_ITestPatternPersistence);
		await TryDispose(_ITestPatternService);
		await TryDispose(_IAppUpdateUserDialogService);
		await TryDispose(_IAppUpdateService);
		await TryDispose(_IBibleDataStore);
		await TryDispose(_IBibleProvider);
		await TryDispose(_IMultiTracksConsumer);
		await TryDispose(_IPCOConsumer);
		await TryDispose(_IPCOUpdater);
		await TryDispose(_IExportProcessFactory);
		await TryDispose(_IInputActions);
		await TryDispose(_ICloudWorkspaceService);
		await TryDispose(_ICloudOnboardingService);
		await TryDispose(_IWorkspaceDocumentOrchestrator);
		await TryDispose(_ThemeCollection);
		await TryDispose(_IProcessHelper);
		await TryDispose(_IFileObservatory);
		await TryDispose(_IMidiDeviceSettingsVM);
		await TryDispose(_IMidiWindowProvider);
		await TryDispose(_IAirCastConfiguration);
		await TryDispose(_IInstallFileExecutor);
		await TryDispose(_ICCLIReportCollectionVM);
		await TryDispose(_ICopyrightSettingsVM);
		await TryDispose(_INetworkCommandTrigger);
		await TryDispose(_IResiController);
		await TryDispose(_ICrashRecovery);
		await TryDispose(_CaptureController);
		await TryDispose(_ITimedPlaybackRepository);
		await TryDispose(_ITimelineService);
		await TryDispose(_ITimecodeService);
		await TryDispose(_ITimelineManager);
		await TryDispose(_CoreManager);
		await TryDispose(_IGeneralSettingsVM);
		await TryDispose(_ICommandSender);
		await TryDispose(_IServerStateHandler);
		await TryDispose(_INetworkEnvironment);
		await TryDispose(_INetworkLinkService);
		await TryDispose(_INetworkLinkPrompt);
		await TryDispose(_INetworkLinkVM);
		await TryDispose(_INetworkSettingsVM);
		await TryDispose(_IRegistrationUnlockCodeVM);
		await TryDispose(_IOrganizationConsumer);
		await TryDispose(_IUserAvatarProvider);
		await TryDispose(_IRegistrationMainPageVM);
		await TryDispose(_IAccountCenterVM);
		await TryDispose(_IUpdatesSettingsVM);
		await TryDispose(_IClockSourceProvider);
		await TryDispose(_IClockSourceService);
		await TryDispose(_IClockSourceVM);
		await TryDispose(_IScreenSettingsVM);
		await TryDispose(_IVideoInputsSettingsVM);
		await TryDispose(_IVideoInputItemVMFactory);
		await TryDispose(_IAudioInputsSettingsVM);
		await TryDispose(_INdiInputsSettingsVM);
		await TryDispose(_IInputsSettingsVM);
		await TryDispose(_IDevicesSettingsVM);
		await TryDispose(_IMediaSearchPathsSettingsVM);
		await TryDispose(_IMediaCleanupService);
		await TryDispose(_IMediaCleanupVM);
		await TryDispose(_IMediaSettingsVM);
		await TryDispose(_IAudioSettingsVM);
		await TryDispose(_IImportSettingsVM);
		await TryDispose(_IPlanningCenterSettingsVM);
		await TryDispose(_IMultiTracksSettingsVM);
		await TryDispose(_ISongSelectSettingsVM);
		await TryDispose(_IResiUpdateVM);
		await TryDispose(_IResiAuthorizationInteractor);
		await TryDispose(_IResiSettingsVM);
		await TryDispose(_IIntegrationsSettingsVM);
		await TryDispose(_IGroupsSettingsVM);
		await TryDispose(_ILabelsSettingsVM);
		await TryDispose(_ISyncController);
		await TryDispose(_ISyncSettingsVM);
		await TryDispose(_ISettingsSearchEngine);
		await TryDispose(_ISettingsSearchVM);
		await TryDispose(_ISettingsNavigationVM);
		await TryDispose(_ISettingsVM);
		await TryDispose(_INotificationVMFactory);
		await TryDispose(_INotificationService);
		await TryDispose(_INotificationCollectionVM);
		await TryDispose(_IChangeWorkspaceHandler);
		await TryDispose(_CloudOnboardingVM);
		await TryDispose(_IManageWorkspacesWindowProvider);
		await TryDispose(_IAttachmentsUploader);
		await TryDispose(_IFeedbackVM);
		await TryDispose(_ICrashReportingVM);
		await TryDispose(_IAttachmentUploadVM);
		await TryDispose(_IWhatsNewV2VM);
		await TryDispose(_IMediaActionService);
		await TryDispose(_IScreenSelectorVM);
		await TryDispose(_IWindowedOutputVM);
		await TryDispose(_ICalendarService);
		await TryDispose(_ILibraryService);
		await TryDispose(_IClipboardProvider);
		await TryDispose(_IPasteStrategy);
		await TryDispose(_ISizeProvider);
		await TryDispose(_IMacroPrompt);
		await TryDispose(_PropAutoClearHandler);
		await TryDispose(_IPropAutoClearService);
		await TryDispose(_IToastNotificationService);
		await TryDispose(_IWorkspaceDeletedPrompt);
		await TryDispose(_IWorkspaceCollectionVM);
		await TryDispose(_IMainLayoutVM);
		await TryDispose(_ITimecodeVM);
		await TryDispose(_IWorkspaceSwitchValidator);
		await TryDispose(_IFeatureFlagService);
		await TryDispose(_IReceiveService);
		await TryDispose(_ISettingsDataToCoreSender);
		await TryDispose(_ISharedData_AppData);
		await TryDispose(_IDocumentDiagnosticsProvider);
		await TryDispose(_IPropAutoClearHandler);
		await TryDispose(_ISendDataResponseHandlerProvider);
		await TryDispose(_IDataProcessor_SendDataResponse);
		await TryDispose(_WebFillBrowserFactory);
		await TryDispose(_IWorkspaceInfoDumper);
		await TryDispose(_MainWindow);
		await TryDispose(_ICloudOnboardingWindowProvider);
		await TryDispose(_IMediaServiceV1);
		await TryDispose(_IMediaServiceV2);
		await TryDispose(_IProcessSupervisor_WorkspaceHelperProcessSupervisor);
		await TryDispose(_IActionFactoryService);
		await TryDispose(_IWorkspacesVM);
		await TryDispose(_IStartupArgumentsExecutor_1);
		await TryDispose(_IMessageHandler_1);
		await TryDispose(_IMessageHandler_2);
		await TryDispose(_rootScope);
		if (_disposables == null)
		{
			return;
		}
		foreach (object disposable2 in _disposables)
		{
			await TryDispose(disposable2);
		}
		static ValueTask TryDispose(object? value)
		{
			if (value is IAsyncDisposable asyncDisposable)
			{
				return asyncDisposable.DisposeAsync();
			}
			if (value is IDisposable disposable)
			{
				disposable.Dispose();
			}
			return default(ValueTask);
		}
	}

	[DebuggerHidden]
	public T GetService<T>()
	{
		if (!(this is Jab.IServiceProvider<T> serviceProvider))
		{
			throw Jab.JabHelpers.CreateServiceNotFoundException<T>();
		}
		return serviceProvider.GetService();
	}

	[DebuggerHidden]
	public T GetService<T>(string name)
	{
		if (!(this is Jab.INamedServiceProvider<T> namedServiceProvider))
		{
			throw Jab.JabHelpers.CreateServiceNotFoundException<T>(name);
		}
		return namedServiceProvider.GetService(name);
	}

	public Scope CreateScope()
	{
		return new Scope(this);
	}

	IServiceScope IServiceScopeFactory.CreateScope()
	{
		return CreateScope();
	}

	bool IServiceProviderIsService.IsService(Type service)
	{
		if (!(typeof(IPhysicalDeviceProvider) == service) && !(typeof(IDatabaseService) == service) && !(typeof(IFileWatcherFactory) == service) && !(typeof(IFileSystem) == service) && !(typeof(IUiDispatcher) == service) && !(typeof(ITimerFactory) == service) && !(typeof(IDebouncerFactory) == service) && !(typeof(IThemeRepo) == service) && !(typeof(IPropsRepo) == service) && !(typeof(IMacrosRepo) == service) && !(typeof(ILibraryPlaylistRepo) == service) && !(typeof(IVisualPlaylistRepo) == service) && !(typeof(IProPresenterResourceService) == service) && !(typeof(IThemeService) == service) && !(typeof(IZipService) == service) && !(typeof(IMessageService) == service) && !(typeof(IFileService) == service) && !(typeof(ILogger) == service) && !(typeof(ILocalization) == service) && !(typeof(IAdvanced) == service) && !(typeof(IProtoService) == service) && !(typeof(ISqliteMigrationService) == service) && !(typeof(ICookieManagerService) == service) && !(typeof(App) == service) && !(typeof(IApp) == service) && !(typeof(IProCoreInstance) == service) && !(typeof(IFlagService) == service) && !(typeof(ssAPIOutput) == service) && !(typeof(ITransitionDescriptionCollection) == service) && !(typeof(IImageLoader) == service) && !(typeof(IMediaMetadataCacheRepository) == service) && !(typeof(IMediaMetadataCacheService) == service) && !(typeof(IAsyncExecutor) == service) && !(typeof(IUiScheduler) == service) && !(typeof(IMetadataLoader) == service) && !(typeof(ITrackedMediaHelpers) == service) && !(typeof(IAssemblyInfoProvider) == service) && !(typeof(System.Version) == service) && !(typeof(IVersionInfoProvider) == service) && !(typeof(IRestClientFactory) == service) && !(typeof(ISemaphoreFactory) == service) && !(typeof(ICurrentTime) == service) && !(typeof(IFileSystemUriCacheServiceFactory) == service) && !(typeof(IImageDecoder) == service) && !(typeof(IBitmapImageDecoder) == service) && !(typeof(IUriCacheService<NullableBitmapSource>) == service) && !(typeof(ICurrentTimeOffset) == service) && !(typeof(IAuthenticatingApiConsumerFactory) == service) && !(typeof(IApiService) == service) && !(typeof(IRegistrationUserDialogService) == service) && !(typeof(IApplicationExceptionFactory) == service) && !(typeof(IErrorPublisher) == service) && !(typeof(IErrorReporter) == service) && !(typeof(ICoreApplication) == service) && !(typeof(IRegistrationCallbackHandler) == service) && !(typeof(NotificationCallbackHandler) == service) && !(typeof(IRegistrationCallbackHandler) == service) && !(typeof(ProContentClientInformationProvider) == service) && !(typeof(IRegistrationCallbackHandler) == service) && !(typeof(IInternetAccess) == service) && !(typeof(IHyperlinkService) == service) && !(typeof(JsonWebTokenHandler) == service) && !(typeof(RegistrationStateHandler) == service) && !(typeof(IRegistrationStateProvider) == service) && !(typeof(IActivationKeyProvider) == service) && !(typeof(IRegistrationWebResourceService) == service) && !(typeof(IPopUpAlertFactory) == service) && !(typeof(IAfterStartupCompleteQueue) == service) && !(typeof(UserMessageHandler) == service) && !(typeof(IRegistrationCallbackHandler) == service) && !(typeof(Func<IMainLayoutVM>) == service) && !(typeof(System.Action) == service) && !(typeof(IWebSourceProvider) == service) && !(typeof(IRegistrationCallbackDialogProvider) == service) && !(typeof(IRegistrationCallbackHandler) == service) && !(typeof(IRegistrationCallbackHandler) == service) && !(typeof(IRegistrationCallbackHandler) == service) && !(typeof(IEmbeddedResourceReader) == service) && !(typeof(IForceQuitEventPublisher) == service) && !(typeof(IForcedShutdownMessageProvider) == service) && !(typeof(IRegistrationCallbackHandler) == service) && !(typeof(IRegistrationCallbackHandler) == service) && !(typeof(IRegistrationCallbackHandler) == service) && !(typeof(IRegistrationCallbackHandler) == service) && !(typeof(IInternetAccessCheck) == service) && !(typeof(IRegistrationCallbackHandler) == service) && !(typeof(IRegistrationCallbackHandler) == service) && !(typeof(IEnumerable<IRegistrationCallbackHandler>) == service) && !(typeof(RegistrationClient) == service) && !(typeof(IRegistrationClient) == service) && !(typeof(IRegistrationOperationFactory) == service) && !(typeof(IOAuth2AuthorizationStore) == service) && !(typeof(IOAuth2ClientInfoProvider) == service) && !(typeof(IProContentConsumer) == service) && !(typeof(IProContentDownloadFailedDialogService) == service) && !(typeof(IProContentUserInteractionBehavior) == service) && !(typeof(IDelayFactory) == service) && !(typeof(IDownloadProcessFactory) == service) && !(typeof(IDownloadItemFactory) == service) && !(typeof(IProContentAnalyticEventsPublisher) == service) && !(typeof(IDownloadManager) == service) && !(typeof(IUnObservedProContentDownloadProcessFactory) == service) && !(typeof(IProContentAssetProvider) == service) && !(typeof(IRemoteFileLoader) == service) && !(typeof(IAudioOutputDeviceCollection) == service) && !(typeof(IAudioSetup) == service) && !(typeof(IAudioMapRecallService<DeviceChannel, Bus>) == service) && !(typeof(ILiveVideoInputCollection) == service) && !(typeof(IMediaFactory) == service) && !(typeof(ITextFillMediaFactory) == service) && !(typeof(ITextDocumentFactory) == service) && !(typeof(IEntityFactory) == service) && !(typeof(IDocumentFactory) == service) && !(typeof(IDocumentService) == service) && !(typeof(IEntityFileLockFactory) == service) && !(typeof(ICommonPathsWrapper) == service) && !(typeof(ICollaborationPeerIdProvider) == service) && !(typeof(IThreadPoolScheduler) == service) && !(typeof(IMediaService) == service) && !(typeof(ILocalWorkspaceStatsEventPublisher) == service) && !(typeof(IZipHelper) == service) && !(typeof(IWorkspaceService) == service) && !(typeof(ICloudDiagnosticsPublisher) == service) && !(typeof(IEntityDocumentRegistry) == service) && !(typeof(IEntityDocumentSyncerFactory) == service) && !(typeof(IMergedEntityFactory) == service) && !(typeof(IProPresenterDOFactoryProvider) == service) && !(typeof(IMessageDialogService) == service) && !(typeof(IPresentationFactory) == service) && !(typeof(IPowerPointImageLoader) == service) && !(typeof(IPowerPointEvents) == service) && !(typeof(TypefaceLibrary) == service) && !(typeof(IFontDetector) == service) && !(typeof(IFontDetectionSessionFactory) == service) && !(typeof(IMissingFontService) == service) && !(typeof(IProPresenterCueFactory) == service) && !(typeof(IFontReplacementEventPublisher) == service) && !(typeof(IMissingFontWindowProvider) == service) && !(typeof(ICorePowerPointImportService) == service) && !(typeof(IPowerPointImportService) == service) && !(typeof(IImportHelperServices) == service) && !(typeof(IImportLocationSelectionDialogService) == service) && !(typeof(IManageMediaAutoMaticallyProvider) == service) && !(typeof(IFileCreator) == service) && !(typeof(ISyncDataFactory) == service) && !(typeof(IScreenArrangementFactory) == service) && !(typeof(IAudioSettingsAnalyticsEventPublisher) == service) && !(typeof(IAudioInputCollection) == service) && !(typeof(ICrdtProtoDirectoryFileScanner) == service) && !(typeof(IMaskCollection) == service) && !(typeof(StagePresentation) == service) && !(typeof(ILocalDocumentSyncerFactory) == service) && !(typeof(IOutputConfiguration) == service) && !(typeof(ICollectionStorage) == service) && !(typeof(IImportProcessFactory) == service) && !(typeof(IAsyncFileImporter) == service) && !(typeof(IMigrationSource) == service) && !(typeof(INetwork) == service) && !(typeof(ITimecodeSettingsRepository) == service) && !(typeof(IImport) == service) && !(typeof(IStoredPcoOptions) == service) && !(typeof(ISongSelectConsumer) == service) && !(typeof(IReportRepository) == service) && !(typeof(IGeneral) == service) && !(typeof(IEnableAnalyticsProvider) == service) && !(typeof(IDisplay) == service) && !(typeof(ISync) == service) && !(typeof(ILayout) == service) && !(typeof(IPlaylistActionValidatorFactory) == service) && !(typeof(IActionBinderFactory) == service) && !(typeof(IEncoderValidator) == service) && !(typeof(IThemeImportProcessFactory) == service) && !(typeof(IThemeAnalyiticEvents) == service) && !(typeof(IDxDiagReaderFactory) == service) && !(typeof(IIdProvider) == service) && !(typeof(ISystemInfoProvider) == service) && !(typeof(IApplicationLaunchEventPublisher) == service) && !(typeof(ICaptureAnalyticEventsPublisher) == service) && !(typeof(IStartupSettingsEventsPublisher) == service) && !(typeof(IUiPreferencesAnalyticEventsPublisher) == service) && !(typeof(ITestPatternAnalyticEventsPublisher) == service) && !(typeof(IWelcomeAnalyticEventsPublisher) == service) && !(typeof(ITimecodeAnalyticsEvents) == service) && !(typeof(IPlaybackMarkerAnalyticsEvents) == service) && !(typeof(ITimelineAnalyticsEvents) == service) && !(typeof(ICCLIReportAnalyticsEvents) == service) && !(typeof(IMediaCleanupSizeEventPublisher) == service) && !(typeof(IMediaAnalyticsSender) == service) && !(typeof(IWorkspaceAnalyticsEventPublisher) == service) && !(typeof(ICloudOnboardingAnalyticsEventPublisher) == service) && !(typeof(IFileDownloadObserverFactory) == service) && !(typeof(IProContentDownloadProcessFactory) == service) && !(typeof(IStopwatchFactory) == service) && !(typeof(ICacheFactory) == service) && !(typeof(IProContentProvider) == service) && !(typeof(IUriCacheService<IReadOnlyList<IAnimationFrame>>) == service) && !(typeof(IOutputRepository) == service) && !(typeof(ICommunicationOutput) == service) && !(typeof(IOutputService) == service) && !(typeof(IErrorPrompt) == service) && !(typeof(IResiPlugin) == service) && !(typeof(IResiCustomEndpointsStore) == service) && !(typeof(IResiEndpoints) == service) && !(typeof(IResiWebClient) == service) && !(typeof(IMessages<AppMessages>) == service) && !(typeof(IUpdateClient) == service) && !(typeof(ITestPatternPropertyFactory) == service) && !(typeof(ITestPatternDefinitionFactory) == service) && !(typeof(ITestPatternStateFactory) == service) && !(typeof(ITestPatternPersistence) == service) && !(typeof(ITestPatternService) == service) && !(typeof(IFileProvider) == service) && !(typeof(ISyncDataProvider) == service) && !(typeof(ISyncRepository<ISyncData>) == service) && !(typeof(ISyncActionProvider) == service) && !(typeof(IAppContinuationService) == service) && !(typeof(IAppInstallerFactory) == service) && !(typeof(IAppDownloadFactory) == service) && !(typeof(IAppUpdateUserDialogService) == service) && !(typeof(IAppUpdateService) == service) && !(typeof(IIndexingService) == service) && !(typeof(IPresentationCapableSyncDataFactory) == service) && !(typeof(IBibleDataStore) == service) && !(typeof(IBibleProvider) == service) && !(typeof(IMultiTracksConsumer) == service) && !(typeof(IAuthenticatorFactory) == service) && !(typeof(IPCOConsumer) == service) && !(typeof(IPCOUpdater) == service) && !(typeof(ThumbnailViewSettings) == service) && !(typeof(IExportProcessFactory) == service) && !(typeof(IInputActions) == service) && !(typeof(IMediaImportService) == service) && !(typeof(IMediaFileProvider) == service) && !(typeof(IWorkspaceInspectionService) == service) && !(typeof(ICloudWorkspaceService) == service) && !(typeof(ICloudConversionService) == service) && !(typeof(ICloudOnboardingService) == service) && !(typeof(IMatchSongsInteractor) == service) && !(typeof(IWorkspaceDocumentOrchestrator) == service) && !(typeof(ThemeCollection) == service) && !(typeof(IThemeCollection) == service) && !(typeof(IFileFilterProvider) == service) && !(typeof(IFileUtility) == service) && !(typeof(IProcessHelper) == service) && !(typeof(INetworkChange) == service) && !(typeof(IFileObservatory) == service) && !(typeof(ISettingsSearchFactory) == service) && !(typeof(INetworkDialogService) == service) && !(typeof(IMediaCleanupPrompt) == service) && !(typeof(IMidiDeviceSettingsVM) == service) && !(typeof(IMidiWindowProvider) == service) && !(typeof(IFileSelectorService) == service) && !(typeof(ICCLIReportPrompt) == service) && !(typeof(INdiInputsSettingsDialogService) == service) && !(typeof(IAirCastPrompt) == service) && !(typeof(IAirCastConfiguration) == service) && !(typeof(IInstallFileExecutor) == service) && !(typeof(IAirCastPluginDownload) == service) && !(typeof(ICCLIReportCollectionVM) == service) && !(typeof(ICopyrightSettingsVM) == service) && !(typeof(INetworkCommandFactory) == service) && !(typeof(INetworkCommandTrigger) == service) && !(typeof(INetworkTriggerDataTransferFactory) == service) && !(typeof(IResiController) == service) && !(typeof(ICrashRecovery) == service) && !(typeof(ICapturePrompt) == service) && !(typeof(CaptureController) == service) && !(typeof(ICaptureService) == service) && !(typeof(ITimedPlaybackRepository) == service) && !(typeof(ITimelineService) == service) && !(typeof(ITimecodeService) == service) && !(typeof(ITimelineManager) == service) && !(typeof(ITransferHandlerFactory) == service) && !(typeof(CoreManager) == service) && !(typeof(ICoreManager) == service) && !(typeof(IGeneralSettingsVM) == service) && !(typeof(ICommandSender) == service) && !(typeof(IServerStateHandler) == service) && !(typeof(INetworkEnvironment) == service) && !(typeof(ILinkRequestFactory) == service) && !(typeof(INetworkLinkService) == service) && !(typeof(INetworkLinkPrompt) == service) && !(typeof(INetworkLinkVM) == service) && !(typeof(INetworkSettingsVM) == service) && !(typeof(IRegistrationUnlockCodeVM) == service) && !(typeof(IRegistrationSubpageVMFactory) == service) && !(typeof(IOrganizationConsumer) == service) && !(typeof(IUserAvatarProvider) == service) && !(typeof(IRegistrationMainPageVM) == service) && !(typeof(IAccountCenterVM) == service) && !(typeof(IUpdatesSettingsVM) == service) && !(typeof(IClockSourceProvider) == service) && !(typeof(IClockSourceService) == service) && !(typeof(IClockSourceVM) == service) && !(typeof(IScreenSettingsVM) == service) && !(typeof(IInputsSettingsService) == service) && !(typeof(IVideoInputsSettingsVM) == service) && !(typeof(IVideoInputItemVMFactory) == service) && !(typeof(IAudioInputsSettingsVM) == service) && !(typeof(INdiInputsSettingsVM) == service) && !(typeof(IInputsSettingsVM) == service) && !(typeof(IDevicesSettingsVM) == service) && !(typeof(IMediaSettingsVMFactory) == service) && !(typeof(IMediaSearchPathsSettingsVM) == service) && !(typeof(IMediaFilesProvider) == service) && !(typeof(IMediaCleanupService) == service) && !(typeof(IMediaCleanupVM) == service) && !(typeof(IMediaSettingsVM) == service) && !(typeof(IAudioSettingsVM) == service) && !(typeof(IImportSettingsVM) == service) && !(typeof(IPlanningCenterSettingsVM) == service) && !(typeof(IMultiTracksSettingsVM) == service) && !(typeof(IAutoReportDialogPrompt) == service) && !(typeof(ISongSelectSettingsVM) == service) && !(typeof(IResiUpdateVM) == service) && !(typeof(ILoginDialogFactory) == service) && !(typeof(IResiPrompt) == service) && !(typeof(IResiAuthorizationInteractor) == service) && !(typeof(IResiSettingsVM) == service) && !(typeof(IIntegrationsSettingsVM) == service) && !(typeof(IGroupLabelItemVMFactory) == service) && !(typeof(IGroupsSettingsVM) == service) && !(typeof(ILabelItemVMFactory) == service) && !(typeof(ILabelsSettingsVM) == service) && !(typeof(ISyncRepository<ISyncData>) == service) && !(typeof(ISyncController) == service) && !(typeof(ISyncSettingsVM) == service) && !(typeof(IEnumerable<ISettingsListItem>) == service) && !(typeof(ISettingsSearchEngine) == service) && !(typeof(ISettingsSearchVM) == service) && !(typeof(ISettingsNavigationVM) == service) && !(typeof(ISettingsVM) == service) && !(typeof(INotificationVMFactory) == service) && !(typeof(IRegistrationRequestSender) == service) && !(typeof(INotificationCallbackHandler) == service) && !(typeof(INotificationService) == service) && !(typeof(INotificationCollectionVM) == service) && !(typeof(IChangeDirectoryProcessFactory) == service) && !(typeof(IChangeWorkspaceHandler) == service) && !(typeof(CloudOnboardingVM) == service) && !(typeof(ICloudOnboardingVM) == service) && !(typeof(ICloudOnboardingShellNavigator) == service) && !(typeof(ICloudOnboardingEligibilityVM) == service) && !(typeof(ICloudOnboardingManageMediaVM) == service) && !(typeof(ICloudOnboardingPricingVM) == service) && !(typeof(ICloudOnboardingDoneVM) == service) && !(typeof(ICloudOnboardingLocalWorkspacesVM) == service) && !(typeof(ICloudTeaseVM) == service) && !(typeof(ICloudTeaseWindowProvider) == service) && !(typeof(IManageWorkspacesWindowProvider) == service) && !(typeof(IMissingFontVM) == service) && !(typeof(ICalendarPrompt) == service) && !(typeof(IRTMPPrompt) == service) && !(typeof(IProContentDialogService) == service) && !(typeof(IMediaImportDownloadDialogService) == service) && !(typeof(IDownloadsDialogService) == service) && !(typeof(IMediaCueThumbnailOverlayVMFactory) == service) && !(typeof(IDownloadVMsFactory) == service) && !(typeof(IPropPrompts) == service) && !(typeof(IHardwareAlphaConfigurationVMFactory) == service) && !(typeof(IAlphaKeySettingsVMFactory) == service) && !(typeof(ICaptureController) == service) && !(typeof(IResiService) == service) && !(typeof(IUserFeedbackConsumer) == service) && !(typeof(IBuildAppMetaDataFile) == service) && !(typeof(IUserAttachmentVMFactory) == service) && !(typeof(IAttachmentsUploader) == service) && !(typeof(IAttachmentUploadJobFactory) == service) && !(typeof(IFeedbackVM) == service) && !(typeof(ICrashReportingVM) == service) && !(typeof(IAttachmentUploadVM) == service) && !(typeof(ICrashReportUserFeedbackDialogProvider) == service) && !(typeof(System.IO.Stream) == service) && !(typeof(IWhatsNewContentProviderFromJson) == service) && !(typeof(IFeatureFactory) == service) && !(typeof(IWhatsNewV2VM) == service) && !(typeof(IMediaActionService) == service) && !(typeof(ITimelineVMFactory) == service) && !(typeof(ITimelineItemVMFactory) == service) && !(typeof(IWorkspaceItemVMFactory) == service) && !(typeof(IActionsMenuVMFactory) == service) && !(typeof(IOutputScreenVMFactory) == service) && !(typeof(IScreenSelectorVM) == service) && !(typeof(IWindowedOutputVM) == service) && !(typeof(IOutputPreviewVMFactory) == service) && !(typeof(IInternalCoreManager) == service) && !(typeof(ITriggeringFactory) == service) && !(typeof(ICalendarService) == service) && !(typeof(IExportService) == service) && !(typeof(ILibraryService) == service) && !(typeof(IClipboardProvider) == service) && !(typeof(IPasteStrategy) == service) && !(typeof(IEditorService) == service) && !(typeof(PlaylistTemplateCollection) == service) && !(typeof(IPlaylistTemplatesService) == service) && !(typeof(ISizeProvider) == service) && !(typeof(IProPresenterCueVMFactory) == service) && !(typeof(IProContentDownloader) == service) && !(typeof(IMacroPrompt) == service) && !(typeof(ISlidePreviewService) == service) && !(typeof(PropAutoClearHandler) == service) && !(typeof(IPropAutoClearService) == service) && !(typeof(ILegacyPurchaseBiblesDialogService) == service) && !(typeof(IMediaValidator) == service) && !(typeof(IMediaProvider) == service) && !(typeof(IToastNotificationService) == service) && !(typeof(IWorkspaceDeletedPrompt) == service) && !(typeof(IWorkspaceCollectionVM) == service) && !(typeof(IMainLayoutVM) == service) && !(typeof(IThemeSlideMenuVM) == service) && !(typeof(IArrangementVM) == service) && !(typeof(ITimecodeItemVMFactory) == service) && !(typeof(ITimecodeVM) == service) && !(typeof(IHeaderContentContextMenuVM) == service) && !(typeof(IWorkspaceSwitchValidator) == service) && !(typeof(IApplicationFailureMessageService) == service) && !(typeof(IFeatureFlagService) == service) && !(typeof(ISpellChecker) == service) && !(typeof(IReceiveService) == service) && !(typeof(IPresentationHandlerOperationService) == service) && !(typeof(IApplicationEventHandler) == service) && !(typeof(ISettingsDataToCoreSender) == service) && !(typeof(IAPIv1Dependencies) == service) && !(typeof(ISharedData<AppData>) == service) && !(typeof(Func<IRegistrationOperationFactory>) == service) && !(typeof(IStartupArgumentsExecutor) == service) && !(typeof(Func<bool>) == service) && !(typeof(IMessageHandler) == service) && !(typeof(IDocumentDiagnosticsProvider) == service) && !(typeof(ILaunchPopUpProvider) == service) && !(typeof(IPropAutoClearHandler) == service) && !(typeof(ISendDataResponseHandlerProvider) == service) && !(typeof(IDataProcessor<SendDataResponse>) == service) && !(typeof(MediaInspectorConverter) == service) && !(typeof(WarningTooltipConverter) == service) && !(typeof(WebFillBrowserFactory) == service) && !(typeof(IWebFillBrowserFactory) == service) && !(typeof(IActionDialogService) == service) && !(typeof(ITemplateVM) == service) && !(typeof(Func<MainWindow>) == service) && !(typeof(IInstanceValidator) == service) && !(typeof(IWorkspaceInfoDumper) == service) && !(typeof(MainWindow) == service) && !(typeof(ICloudOnboardingWindowProvider) == service) && !(typeof(IMediaServiceV1) == service) && !(typeof(IMediaServiceV2) == service) && !(typeof(IProcessSupervisor) == service) && !(typeof(IActionFactoryService) == service) && !(typeof(IWorkspacesVM) == service) && !(typeof(IStartupArgumentsExecutor) == service) && !(typeof(IEnumerable<IStartupArgumentsExecutor>) == service) && !(typeof(IMessageHandler) == service) && !(typeof(IMessageHandler) == service) && !(typeof(IEnumerable<IMessageHandler>) == service) && !(typeof(IServiceProvider) == service) && !(typeof(IServiceScopeFactory) == service))
		{
			return typeof(IServiceProviderIsService) == service;
		}
		return true;
	}

	private Scope GetRootScope()
	{
		if (_rootScope == null)
		{
			lock (this)
			{
				if (_rootScope == null)
				{
					_rootScope = CreateScope();
				}
			}
		}
		return _rootScope;
	}
}
