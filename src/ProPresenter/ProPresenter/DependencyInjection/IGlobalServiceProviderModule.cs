using System;
using System.IO.Abstractions;
using System.Reflection;
using Jab;
using Microsoft.IdentityModel.JsonWebTokens;
using Pro.Common.Background;
using Pro.Common.Dispatcher;
using Pro.Common.ErrorReporting;
using Pro.Common.FeatureFlag;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.Common.OAuth.Authenticator;
using Pro.Common.Time;
using Pro.Common.Time.Timer;
using Pro.Common.ToastNotifications;
using Pro.Common.Utility;
using Pro.Common.Versioning;
using Pro.Common.Win32;
using Pro.CoreApplication;
using Pro.CoreApplication.CoreInteraction;
using Pro.CoreApplication.FeatureFlag;
using Pro.DO;
using Pro.DO.Audio;
using Pro.DxDiagReport;
using Pro.Entity;
using Pro.Entity.Merged.Factory;
using Pro.Entity.Persistence;
using Pro.Imaging;
using Pro.Interprocess;
using Pro.Localization.Services;
using Pro.UI.DialogService;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO;
using ProPresenter.DO.Audio;
using ProPresenter.DO.ChangeDirectory;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.InputActionMap;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Masks;
using ProPresenter.DO.Media;
using ProPresenter.DO.Media.Properties.File;
using ProPresenter.DO.Media.Services;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.PCO;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Repositories;
using ProPresenter.DO.Resi;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Sync.Local;
using ProPresenter.DO.Updates;
using ProPresenter.Data.Crdt;
using ProPresenter.Services;
using ProPresenter.ToastNotifications;
using ProPresenter.Updates;
using ProPresenter.Utility;
using ProPresenter.Versioning;
using ProPresenter.WhatsNew;

namespace ProPresenter.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Singleton<IInternetAccess>(Factory = "GetInternetAccessCheck")]
[Jab.Singleton<IFileSystem, FileSystem>]
[Jab.Singleton<Version>(Name = "OSVersion", Factory = "GetOsVersion")]
[Jab.Singleton<IAssemblyInfoProvider>(Factory = "GetAssemblyProvider")]
[Jab.Singleton<IVersionInfoProvider>(Factory = "GetVersionInfoProvider")]
[Jab.Singleton<IInstallFileExecutor>(Factory = "GetInstallFileExecutor")]
[Jab.Transient<IImageDecoder, ImageDecoder>]
[Jab.Singleton<IErrorPrompt>(Factory = "GetResiErrorPrompt")]
[Jab.Singleton<ICrashRecovery>(Factory = "GetResiCrashRecovery")]
[Jab.Transient<IDxDiagReaderFactory, DxDiagReaderFactory>]
[Jab.Transient<ISyncRepository<ISyncData>>(Name = "LocalFileRepositoryKey", Factory = "GetLocalFileRepository")]
[Jab.Transient<IFeatureFactory, FeatureFactory>]
[Jab.Singleton<IAppUpdateUserDialogService, AppUpdateUserDialogService>]
[Jab.Transient<IAppInstallerFactory, AppInstallerFactory>]
[Jab.Singleton<IPCOConsumer>(Factory = "GetPCOConsumer")]
[Jab.Transient<IApplicationFailureMessageService, ApplicationFailureMessageService>]
[Jab.Transient<IForcedShutdownMessageProvider, ForcedShutdownMessageProvider>]
[Jab.Singleton<ICoreApplication, CoreApplication>]
[Jab.Transient<IApplicationExceptionFactory, ApplicationExceptionFactory>]
[Jab.Singleton<IFeatureFlagService, FeatureFlagService>]
[Jab.Singleton<IRestClientFactory>(Factory = "GetRestClientFactory")]
[Jab.Singleton<IEntityFactory, EntityFactory>]
[Jab.Singleton<IMergedEntityFactory, MergedEntityFactory>]
[Jab.Singleton<IDocumentFactory, DocumentFactory>]
[Jab.Singleton<IEntityDocumentSyncerFactory, EntityDocumentSyncerFactory>]
[Jab.Transient<ICollaborationPeerIdProvider>(Factory = "GetApp")]
[Jab.Singleton<ICollectionStorage, CollectionStorage>]
[Jab.Singleton<IEntityFileLockFactory, EntityFileLockFactory>]
[Jab.Singleton<JsonWebTokenHandler>]
[Jab.Singleton<IOutputRepository>(Factory = "GetOutputRepository")]
[Jab.Singleton<IOutputConfiguration>(Factory = "CreateOutputConfiguration")]
[Jab.Singleton<IToastNotificationService, ToastNotificationService>]
[Jab.Singleton<StagePresentation>(Factory = "CreateStagePresentation")]
[Jab.Singleton<ILocalDocumentSyncerFactory, LocalDocumentSyncerFactory>]
[Jab.Transient<IMediaFactory>(Factory = "GetMediaFactory")]
internal interface IGlobalServiceProviderModule
{
	const string OSVersionKey = "OSVersion";

	static IMediaFactory GetMediaFactory(IMetadataLoader metadataLoader, IAsyncExecutor executor, ITrackedMediaHelpers mediaHelpers, IRemoteFileLoader remoteFileLoader, ILiveVideoInputCollection liveVideoInputs, IAudioSetup audioSetup, IFlagService flagService, ssAPIOutput ssAPIOutput)
	{
		return new MediaFactory(metadataLoader, executor, mediaHelpers, remoteFileLoader, liveVideoInputs, audioSetup, ssAPIOutput.AvailableEffects, flagService);
	}

	static IInternetAccess GetInternetAccessCheck(ILocalization localization)
	{
		return new InternetAccessCheck(delegate
		{
			MessageDialogService.ShowSimpleContent(localization.Get("GLOBAL_NO_INTERNET_CONNECTION_message"), localization.Get("GLOBAL_NO_INTERNET_CONNECTION_info"), canCancel: false);
		});
	}

	static Version GetOsVersion()
	{
		OSVERSIONINFOEXW versionInfo = OSVERSIONINFOEXW.Empty;
		if (WindowsFunctions.RtlGetVersion(ref versionInfo) != 0)
		{
			throw new Exception("Failed to load OS version info");
		}
		return new Version((int)versionInfo.MajorVersion, (int)versionInfo.MinorVersion, (int)versionInfo.BuildNumber);
	}

	static IInstallFileExecutor GetInstallFileExecutor(IMessages<AppMessages> messages)
	{
		return new InstallFileExecutor(CommonPaths.InstallLocation, messages);
	}

	static IAssemblyInfoProvider GetAssemblyProvider()
	{
		return new AssemblyInfoProvider(Assembly.GetExecutingAssembly());
	}

	static IVersionInfoProvider GetVersionInfoProvider(IAssemblyInfoProvider assemblyInfoProvider, [Jab.FromNamedServices("OSVersion")] Version osVersion)
	{
		return new VersionInfoProvider(assemblyInfoProvider, osVersion);
	}

	static IErrorPrompt GetResiErrorPrompt(IOutputService outputService)
	{
		return new ErrorPrompt(outputService.OutputConfiguration.CaptureSettings);
	}

	static ICrashRecovery GetResiCrashRecovery(IOutputService outputService)
	{
		return new CrashRecovery(outputService.OutputConfiguration.CaptureSettings);
	}

	static ISyncRepository<ISyncData> GetLocalFileRepository(ISyncDataProvider syncDataProvider, IOutputService outputService, IErrorReporter errorReporter, IInputActions inputActions)
	{
		return new LocalFileRepository(syncDataProvider, outputService.OutputConfiguration, errorReporter, inputActions);
	}

	static IPCOConsumer GetPCOConsumer(IAuthenticatorFactory authenticatorFactory, IRestClientFactory restClientFactory, IApp app, IStoredPcoOptions storedPcoOptions, ILogger logger, IAsyncExecutor asyncExecutor, ILocalization localization)
	{
		return new PCOConsumer(DataVault.PCOOrganization, authenticatorFactory, restClientFactory, app, storedPcoOptions, logger, asyncExecutor, localization);
	}

	static IRestClientFactory GetRestClientFactory(IVersionInfoProvider versionInfoProvider, IApp app)
	{
		return new RestClientFactory("ProPresenter Windows " + versionInfoProvider.FullDisplayAppVersion, app.ConcurrentDownloadLimit);
	}

	static IOutputRepository GetOutputRepository(ssAPIOutput ssApiOutput, IAudioInputCollection audioInputs, ILiveVideoInputCollection videoInputs, IOutputConfiguration outputConfiguration)
	{
		return new OutputRepository(ssApiOutput.AvailableTransitions, ssApiOutput.AvailableVideoInputs, ssApiOutput.AvailableVideoOutputs, ssApiOutput.AvailableAudioInputs, ssApiOutput.AvailableAudioOutputs, ssApiOutput.AvailableEffects, outputConfiguration, videoInputs, audioInputs);
	}

	static OutputConfiguration CreateOutputConfiguration(ssAPIOutput ssApiOutput, IApp app, ISyncDataFactory syncDataFactory, IProPresenterDOFactoryProvider factoryProvider, IUiScheduler uiScheduler, IFlagService flagService, IScreenArrangementFactory screenArrangementFactory, IAudioSetup audioSetup, ILiveVideoInputCollection videoInputs, IAudioInputCollection audioInputs, ICrdtProtoDirectoryFileScanner scanner, IMaskCollection masks, StagePresentation stagePresentation, ILocalDocumentSyncerFactory localConfigurationDocumentSyncerFactory, ILocalization localization)
	{
		return new OutputConfiguration(ssApiOutput.AvailableVideoOutputs, ssApiOutput.AvailableAudioInputs, ssApiOutput.AvailableVideoInputs, app, syncDataFactory, factoryProvider, uiScheduler, flagService, screenArrangementFactory, audioSetup, videoInputs, audioInputs, masks, stagePresentation, localConfigurationDocumentSyncerFactory, localization, scanner.ShouldLoadLegacy);
	}

	static IApp GetApp(IApp app)
	{
		return app;
	}

	static StagePresentation CreateStagePresentation(IApp app, ITimerFactory timerFactory, IProPresenterDOFactoryProvider factoryProvider, ssAPIOutput ssApiOutput, ISyncDataFactory syncDataFactory, IFlagService flagService, IUiScheduler scheduler, IMessageDialogService messageDialogService, ICurrentTime currentTime, ICrdtProtoDirectoryFileScanner scanner)
	{
		return new StagePresentation(app, timerFactory, factoryProvider, ssApiOutput.AvailableTransitions, syncDataFactory, flagService, scheduler, messageDialogService, currentTime, scanner.ShouldLoadLegacy);
	}
}
