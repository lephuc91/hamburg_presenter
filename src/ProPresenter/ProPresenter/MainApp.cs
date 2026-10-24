using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Microsoft.Extensions.DependencyInjection;
using Pro.Common;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.DataFlow;
using Pro.Common.Dispatcher;
using Pro.Common.ErrorReporting;
using Pro.Common.FeatureFlag;
using Pro.Common.FileSystem;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.Common.MessageService;
using Pro.Common.MessageService.AppMessages;
using Pro.Common.ProcessSupervision;
using Pro.Common.Startup;
using Pro.Common.Time;
using Pro.Common.Time.Timer;
using Pro.Common.Utility;
using Pro.Common.Versioning;
using Pro.CoreApplication.CoreInteraction;
using Pro.CoreApplication.FeatureFlag;
using Pro.CoreApplication.Media;
using Pro.CoreApplication.Workspace;
using Pro.DO.Analytics;
using Pro.DO.Triggering;
using Pro.Data.SQLite.Migration;
using Pro.Entity.Persistence;
using Pro.Interprocess;
using Pro.Localization;
using Pro.Localization.Services;
using Pro.Reporting;
using Pro.SerializationInterop.RVProtoData;
using Pro.SerializationInterop.RVProtoData.Application;
using Pro.SerializationInterop.RVProtoData.FeatureFlags;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v1;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v2;
using Pro.SerializationInterop.RVProtoData.Service.Document;
using Pro.SerializationInterop.RVProtoData.Service.Workspace;
using Pro.UI;
using Pro.UI.DialogService;
using Pro.UI.Utility;
using Pro.Web.Services;
using ProPresenter.Continuation;
using ProPresenter.Controller;
using ProPresenter.Controller.NetworkAPI;
using ProPresenter.Controller.NetworkAPI.Receive;
using ProPresenter.Controller.NetworkAPI.Transmit;
using ProPresenter.Controller.Outputs;
using ProPresenter.Controller.Outputs.Communication;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Analytics.Events.Startup;
using ProPresenter.DO.Analytics.Events.TrackedEvents.Helpers;
using ProPresenter.DO.Analytics.Events.Welcome;
using ProPresenter.DO.Capture;
using ProPresenter.DO.ChangeDirectory;
using ProPresenter.DO.CloudOnboarding;
using ProPresenter.DO.CommonPathsWrapper;
using ProPresenter.DO.Communication.MIDI;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Events;
using ProPresenter.DO.Import;
using ProPresenter.DO.Indexing;
using ProPresenter.DO.InputActionMap;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Masks;
using ProPresenter.DO.Media;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.PCO;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Registration.State;
using ProPresenter.DO.Repositories;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Settings.AppSettings;
using ProPresenter.DO.Themes;
using ProPresenter.DO.Updates;
using ProPresenter.DO.Web;
using ProPresenter.DO.Workspaces;
using ProPresenter.Data;
using ProPresenter.Data.Messages;
using ProPresenter.Data.StartupArguments;
using ProPresenter.DependencyInjection;
using ProPresenter.Registration;
using ProPresenter.Registration.CallbackHandlers;
using ProPresenter.Services;
using ProPresenter.UI;
using ProPresenter.UI.ClearGroups;
using ProPresenter.UI.CloudOnboarding;
using ProPresenter.UI.ErrorHandling;
using ProPresenter.UI.Theming;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Settings.Pages;
using ProPresenter.UI.ViewModels.Settings.Pages.Devices;
using ProPresenter.UI.ViewModels.Settings.Pages.Groups;
using ProPresenter.UI.ViewModels.Settings.Pages.Inputs;
using ProPresenter.UI.ViewModels.Settings.Pages.Labels;
using ProPresenter.UI.ViewModels.Workspaces;
using ProPresenter.ViewModels;
using ProPresenter.ViewModels.FeedbackCrash;
using ProPresenter.ViewModels.Settings.Pages.General;
using ProPresenter.ViewModels.Workspaces;
using ProPresenterCore.ProCore.Interop;
using Reactive.Bindings;
using Reactive.Bindings.Schedulers;

namespace ProPresenter;

public class MainApp : Application
{
	private sealed record ProCoreStartupResult(ProResult Result, ProCoreInstance? Instance)
	{
		[MemberNotNullWhen(true, "Instance")]
		public bool IsSuccess
		{
			[MemberNotNullWhen(true, "Instance")]
			get
			{
				return Result == ProResult.Success;
			}
		}
	}

	private const string InstallPath = "GLSL";

	private readonly ServiceProvider _serviceProvider;

	private APIv1EventHandler? _apiHandler;

	private IInternalCoreManager? _manager;

	private CancellationTokenSource? _proCoreSendDataCancellationTokenSource;

	private Task? _proSendDataTask;

	private MainWindow? _mainWindow;

	private bool _mainWindowClosed;

	private IDisposable? _actionFactoryResetter;

	internal MainApp(ServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider;
	}

	protected override void OnStartup(StartupEventArgs e)
	{
		base.OnStartup(e);
		IApp typedService = _serviceProvider.GetTypedService<IApp>();
		IFlagService flagService = _serviceProvider.GetTypedService<IFlagService>();
		Dreamcatcher.CreateFullDumps = flagService.IsFlagEnabled(Pro.Common.FeatureFlag.Flag.CreateFullMemoryDumps);
		SetupWpfAdditions(flagService, typedService);
		BindingErrorListener.Attach(_serviceProvider.GetTypedService<IErrorReporter>());
		CheckPathPermissions();
		bool firstLaunch = typedService.IsFirstLaunch;
		bool hadSeenCloudOnboarding = typedService.HasSeenOnboarding;
		IMessages<AppMessages> typedService2 = _serviceProvider.GetTypedService<IMessages<AppMessages>>();
		IStartupArgumentsExecutor[] array = _serviceProvider.GetServices<IStartupArgumentsExecutor>().ToArray();
		foreach (IMessageHandler service2 in _serviceProvider.GetServices<IMessageHandler>())
		{
			typedService2.RegisterHandler(service2.HandledMessage, service2.Handle);
		}
		IStartupArgumentsExecutor[] array2;
		if (e.Args.Any())
		{
			array2 = array;
			for (int i = 0; i < array2.Length && !array2[i].ProcessArgument(e.Args[0]); i++)
			{
			}
		}
		if (!_serviceProvider.GetTypedService<IInstanceValidator>().IsUnique)
		{
			typedService2.SendMessage(AppMessages.FocusWindow);
			array.ForEach(delegate(IStartupArgumentsExecutor executor)
			{
				executor.Send();
			});
			Shutdown();
			return;
		}
		InitializeAnalytics();
		StartSupervisoingWorkspaceHelper();
		if (!CheckDigitalSignatures())
		{
			Log.Error("Invalid digital signatures found for registration libraries, exiting.");
			_serviceProvider.GetTypedService<IForcedShutdownMessageProvider>().ShowForcedApplicationShutdownDialog(IForcedShutdownMessageProvider.ShutdownReason.PiratedSoftware);
		}
		IAfterStartupCompleteQueue typedService3 = _serviceProvider.GetTypedService<IAfterStartupCompleteQueue>();
		typedService3.Enqueue(delegate
		{
			bool flag = flagService.IsFlagEnabled(Pro.Common.FeatureFlag.Flag.Cloud);
			bool num = (firstLaunch && flag) || (!firstLaunch && flag && !hadSeenCloudOnboarding);
			bool usedStartupArgumentToRegisterActionKey = _serviceProvider.UsedStartupArgumentToRegisterActionKey;
			EnablePopUpsInstruction enablePopUpsInstruction = ((!num) ? (firstLaunch ? EnablePopUpsInstruction.IgnoreStartup : (usedStartupArgumentToRegisterActionKey ? EnablePopUpsInstruction.IgnoreStartup : EnablePopUpsInstruction.ShowAll)) : EnablePopUpsInstruction.IgnoreAll);
			EnablePopUpsInstruction showDeferredPopUpInstruction = enablePopUpsInstruction;
			_serviceProvider.GetTypedService<ILaunchPopUpProvider>().EnablePopUps(showDeferredPopUpInstruction);
		});
		IMessageService typedService4 = _serviceProvider.GetTypedService<IMessageService>();
		typedService4.SubscribeToMessage<RequestApplicationCloseMessage>(delegate
		{
			_serviceProvider.GetTypedService<IAfterStartupCompleteQueue>().Cancel();
			((DispatcherObject)this).Dispatcher.Invoke((System.Action)delegate
			{
				if (_mainWindow != null)
				{
					_mainWindow.CloseWithoutConfirmation();
				}
				else
				{
					Shutdown();
				}
			});
		});
		typedService4.SubscribeToMessage<RequestApplicationRestartMessage>(delegate
		{
			_serviceProvider.GetTypedService<IAfterStartupCompleteQueue>().Cancel();
			((DispatcherObject)this).Dispatcher.Invoke((System.Action)delegate
			{
				_serviceProvider.GetTypedService<IAppContinuationService>().Add(Application.ResourceAssembly.Location.Replace("dll", "exe"));
				if (_mainWindow != null)
				{
					_mainWindow.CloseWithoutConfirmation();
				}
				else
				{
					Shutdown();
				}
			});
		});
		Log.Info("Loading registration...");
		Stargazer.RegistrationInfoProvider = new StargazerRegistrationInfoProvider(_serviceProvider.GetTypedService<IRegistrationStateProvider>());
		SplashDialog splashDialog = ShowSplash(firstLaunch);
		_serviceProvider.SetSplashDialog(splashDialog);
		Log.Info("Creating ProPresenterCore instance...");
		ProCoreStartupResult proCoreStartupResult = StartupProCore(flagService, typedService);
		if (!proCoreStartupResult.IsSuccess)
		{
			splashDialog?.Close();
			if (proCoreStartupResult.Result == ProResult.NoGraphicsDevice)
			{
				Log.FatalError("Couldn't create DirectX context, exiting...");
				MessageDialogService.ShowDialog(string.Empty, LocalizedStrings.Get("DIRECTX_ALERT_message"), DefaultButtons.QUIT, DefaultButtons.QUIT);
			}
			else
			{
				Log.FatalError("ProCore startup error: {0}", proCoreStartupResult.Result);
			}
			Shutdown();
			return;
		}
		Log.Info("Done creating ProPresenterCore instance");
		_serviceProvider.CoreInstance = proCoreStartupResult.Instance;
		StartupCoreApplication(_serviceProvider, flagService, typedService);
		Log.Info("Setting up the services...");
		proCoreStartupResult.Instance.InitializeWSCallbacks();
		ssAPIOutput typedService5 = _serviceProvider.GetTypedService<ssAPIOutput>();
		Log.Info("Done setting up the services");
		Log.Info("Checking workspace");
		bool loadLegacy = true;
		if (flagService.IsFlagEnabled(Pro.Common.FeatureFlag.Flag.Cloud))
		{
			IWorkspaceSwitchValidator typedService6 = _serviceProvider.GetTypedService<IWorkspaceSwitchValidator>();
			IWorkspace workspace = CommonPaths.Workspaces.FirstOrDefault((IWorkspace w) => w.Active);
			if (workspace == null)
			{
				workspace = CommonPaths.Workspaces.First((IWorkspace w) => w.WorkspaceType == ProPresenter.DO.Workspaces.WorkspaceType.Local);
			}
			if (!typedService6.Validate(workspace, out IWorkspace resultWorkspace, isOnLaunch: true))
			{
				Shutdown();
				return;
			}
			loadLegacy = _serviceProvider.GetTypedService<ICrdtProtoDirectoryFileScanner>().ShouldLoadLegacy;
			CommonPaths.Base = resultWorkspace.Path;
		}
		Log.Info("Done checking workspace");
		Log.Info("Loading data...");
		if (firstLaunch)
		{
			LoadPackagedContent();
		}
		ICommunicationOutput typedService7 = _serviceProvider.GetTypedService<ICommunicationOutput>();
		OutputVault.Initialize(_serviceProvider.GetTypedService<IOutputRepository>(), _serviceProvider.GetTypedService<IOutputConfiguration>());
		_actionFactoryResetter = ActionFactory.SetFactory(_serviceProvider.GetTypedService<IActionFactoryService>());
		_serviceProvider.GetTypedService<IAirCastConfiguration>().SetDeviceInputs(typedService5.AvailableVideoInputs);
		Log.Info("Done loading data");
		try
		{
			_serviceProvider.GetTypedService<IAppUpdateService>().Start();
			MigrateSettings(_serviceProvider.GetTypedService<IMigrationSource>(), _serviceProvider.GetTypedService<ISqliteMigrationService>());
			DataVault.Initialize(_serviceProvider.GetTypedService<IPresentationFactory>(), typedService, _serviceProvider.GetTypedService<IPresentationCapableSyncDataFactory>(), _serviceProvider.GetTypedService<ITimerFactory>(), _serviceProvider.GetTypedService<IOutputService>().OutputConfiguration.CaptureSettings, _serviceProvider.GetTypedService<IResiService>(), _serviceProvider.GetTypedService<IPlaylistActionValidatorFactory>(), _serviceProvider.GetTypedService<IIndexingService>(), _serviceProvider.GetTypedService<IProPresenterResourceService>(), _serviceProvider.GetTypedService<ILocalization>(), _serviceProvider.GetTypedService<IOutputRepository>(), _serviceProvider.GetTypedService<IAsyncFileImporter>(), _serviceProvider.GetTypedService<IInputActions>(), _serviceProvider.GetTypedService<IImportProcessFactory>(), _serviceProvider.GetTypedService<IMediaImportService>(), _serviceProvider.GetTypedService<IProPresenterDOFactoryProvider>(), _serviceProvider.GetTypedService<IFileWatcherFactory>(), _serviceProvider.GetTypedService<IFileSystem>(), _serviceProvider.GetTypedService<IFlagService>(), _serviceProvider.GetTypedService<IUiScheduler>(), _serviceProvider.GetTypedService<ILogger>(), _serviceProvider.GetTypedService<IUiDispatcher>(), _serviceProvider.GetTypedService<IActionBinderFactory>(), _serviceProvider.GetTypedService<IProPresenterCueFactory>(), _serviceProvider.GetTypedService<IGeneral>(), _serviceProvider.GetTypedService<IMessageDialogService>(), _serviceProvider.GetTypedService<IMediaService>(), _serviceProvider.GetTypedService<IAsyncExecutor>(), _serviceProvider.GetTypedService<ThemeCollection>(), _serviceProvider.GetTypedService<ICollectionStorage>(), _serviceProvider.GetTypedService<ICommonPathsWrapper>(), _serviceProvider.GetTypedService<ICurrentTime>(), _serviceProvider.GetTypedService<StagePresentation>(), _serviceProvider.GetTypedService<ILocalDocumentSyncerFactory>(), loadLegacy);
		}
		catch (FileIOException ex)
		{
			Log.Error("Unable to initialize DataVault: {0}", e.ToString());
			if (!FileIOResultHandler.ShowDialog(ex.Result))
			{
				Shutdown();
				return;
			}
		}
		catch (DataVaultException ex2)
		{
			Log.Error("Unable to initialize DataVault: {0}", ex2.ToString());
			MessageDialogService.ShowDialog(string.Empty, LocalizedStrings.Get("DATA_INITIALIZATION_ERROR_message", new object[1] { Enum.Format(typeof(Pro.Common.ErrorCode), ex2.Error, "x") }), DefaultButtons.OK, DefaultButtons.OK);
			Shutdown();
			return;
		}
		Log.Info("Sending current workspace documents to core...");
		if (flagService.IsFlagEnabled(Pro.Common.FeatureFlag.Flag.Cloud))
		{
			_serviceProvider.GetTypedService<IAsyncExecutor>().ExecuteAsync(async delegate
			{
				IWorkspace workspace2 = CommonPaths.Workspaces.FirstOrDefault((IWorkspace w) => w.Active);
				if (workspace2 == null)
				{
					workspace2 = CommonPaths.Workspaces.First((IWorkspace w) => w.WorkspaceType == ProPresenter.DO.Workspaces.WorkspaceType.Local);
				}
				await _serviceProvider.GetTypedService<IWorkspaceDocumentOrchestrator>().SendWorkspaceDocumentsToCoreAsync(workspace2);
				await _serviceProvider.GetTypedService<IWorkspaceInfoDumper>().DumpWorkspaceInfoAsync();
			});
		}
		Log.Info("Sending Settings to Core...");
		_serviceProvider.GetTypedService<ISettingsDataToCoreSender>().SendSettingsToCore();
		ImportHelper.InitializeData(DataVault.GroupLabels, DataVault.Themes);
		typedService3.Enqueue(delegate
		{
			_serviceProvider.GetTypedService<IAsyncExecutor>().ExecuteAsync(() => Task.Run(delegate
			{
				_serviceProvider.GetTypedService<IProPresenterResourceService>().LibraryCollection.ForEach(delegate(ILibrary l)
				{
					l.SanitizeMediaFillMediaIDs();
				});
			}));
		});
		typedService3.Enqueue(delegate
		{
			_serviceProvider.GetTypedService<IAsyncExecutor>().ExecuteAsync(() => Task.Run(delegate
			{
				_serviceProvider.GetTypedService<IMediaMetadataCacheService>().RemoveOrphanedThumbnailFiles();
			}));
		});
		Log.Info("Assigning core manager...");
		_manager = _serviceProvider.GetTypedService<IInternalCoreManager>();
		ApplicationEventPublisher.AddHandler(_serviceProvider.GetTypedService<IApplicationEventHandler>("CoreManagerApplicationEventHandler"));
		_proCoreSendDataCancellationTokenSource = new CancellationTokenSource();
		ProCoreSendDataHandler proCoreSendDataHandler = new ProCoreSendDataHandler(_serviceProvider.GetTypedService<IProCoreInstance>(), _serviceProvider.GetTypedService<IDataProcessor<SendDataResponse>>(), _proCoreSendDataCancellationTokenSource.Token);
		_proSendDataTask = proCoreSendDataHandler.RunAsync();
		ITriggeringFactory typedService8 = _serviceProvider.GetTypedService<ITriggeringFactory>();
		ITriggering triggering = typedService8.Create(ProPresenter.Controller.TriggerSource.NetworkAPI);
		new NetworkHandler(_serviceProvider.GetTypedService<IReceiveService>(), _serviceProvider.GetTypedService<ICommandSender>(), triggering, _serviceProvider.GetTypedService<INetworkCommandTrigger>(), _serviceProvider.GetTypedService<INetwork>());
		APIv1Service service = new APIv1Service(_serviceProvider.GetTypedService<IAPIv1Dependencies>(), _serviceProvider.GetTypedService<IOutputConfiguration>(), triggering);
		_apiHandler = new APIv1EventHandler(_serviceProvider.GetTypedService<IProCoreInstance>(), service);
		ApplicationEventPublisher.AddHandler(_apiHandler);
		ClearHandler.SetGroupIconRenderer(new ClearGroupIconRenderer());
		RequestHandler @object = new RequestHandler(service);
		_serviceProvider.GetTypedService<IProCoreInstance>().APIV1Callback = @object.Handle;
		new RemoteAppOutput(_serviceProvider.GetTypedService<IProCoreInstance>(), _serviceProvider.GetTypedService<IServerStateHandler>(), _manager, typedService8, _serviceProvider.GetTypedService<ITimelineManager>(), _serviceProvider.GetTypedService<INetwork>());
		_serviceProvider.GetTypedService<IPCOUpdater>();
		typedService7.AssignManager(_manager);
		typedService7.AssignActionHandler(new MIDIActionHandler(new MIDIExecutor(_manager, typedService8, _serviceProvider.GetTypedService<ITimelineManager>())));
		ImportHelper.SetImportDelegates();
		ProcessHelper.FileNotFound += delegate
		{
			MessageDialogService.ShowAlert(LocalizedStrings.Get("GLOBAL_GENERIC_FILE_NOT_LOCATED_message"));
		};
		Log.Info("Done assigning core manager");
		Log.Info("Initializing the Main Window...");
		IMainLayoutVM typedService9 = _serviceProvider.GetTypedService<IMainLayoutVM>();
		typedService9.SetupSettingsStackChanged(_serviceProvider.GetTypedService<IGeneralSettingsVM>(), _serviceProvider.GetTypedService<IGroupsSettingsVM>(), _serviceProvider.GetTypedService<ILabelsSettingsVM>(), _serviceProvider.GetTypedService<IDevicesSettingsVM>(), _serviceProvider.GetTypedService<IInputsSettingsVM>());
		_mainWindow = _serviceProvider.GetTypedService<MainWindow>();
		_mainWindow.Closed += delegate
		{
			_mainWindowClosed = true;
			Shutdown();
		};
		_manager.SendStartupComplete();
		SharedWorkerPool.StartupWorkers();
		_serviceProvider.GetTypedService<IEntityDocumentRegistry>();
		if (firstLaunch && !flagService.IsFlagEnabled(Pro.Common.FeatureFlag.Flag.Cloud))
		{
			ShowWelcomeWindow(typedService, typedService9, typedService3);
		}
		Log.Info("Showing the Main Window...");
		if (_mainWindowClosed)
		{
			return;
		}
		_mainWindow.Show();
		if (flagService.IsFlagEnabled(Pro.Common.FeatureFlag.Flag.CloudComingSoon))
		{
			_serviceProvider.GetTypedService<ICloudTeaseWindowProvider>().Show();
		}
		else if (!firstLaunch)
		{
			if (flagService.IsFlagEnabled(Pro.Common.FeatureFlag.Flag.Cloud) && !hadSeenCloudOnboarding)
			{
				_serviceProvider.GetTypedService<ICloudOnboardingWindowProvider>().Show();
			}
		}
		else if (flagService.IsFlagEnabled(Pro.Common.FeatureFlag.Flag.Cloud))
		{
			ShowWelcomeWindow(typedService, typedService9, typedService3, _mainWindow);
		}
		array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].UseLocally();
		}
		typedService3.CompleteStartup();
		if (typedService.HighestVersion != null)
		{
			StartupVersioningEvent.Publish(typedService.HighestVersion.ToShortDisplayAppString());
		}
		typedService3.Enqueue(delegate
		{
			_serviceProvider.GetTypedService<IApplicationLaunchEventPublisher>().PublishApplicationLaunchEvent().ExecuteAsync();
		});
		typedService3.Enqueue(delegate
		{
			new DiskUsageEventHelper(_serviceProvider.GetTypedService<IProPresenterResourceService>(), _serviceProvider.GetTypedService<IFileSystem>(), _serviceProvider.GetTypedService<IOutputConfiguration>().AudienceLooks, _serviceProvider.GetTypedService<IAsyncExecutor>(), _serviceProvider.GetTypedService<IMaskCollection>()).PublishDiskUsageEvent();
		});
		if ((Stargazer.HadCrashHappened() && General.Settings.EnableCrashReporting) || flagService.IsFlagEnabled(Pro.Common.FeatureFlag.Flag.ShowCrashUiOnStartup))
		{
			Log.Info("Showing Crash Reporting dialog...");
			_serviceProvider.GetTypedService<ICrashReportUserFeedbackDialogProvider>().ShowCrashReport(_mainWindow, hasCrashed: true).ExecuteAsync();
		}
		PublishStartupSettingsEvent(typedService);
		SimulateCrashIfEnabled(flagService);
	}

	private void ShowWelcomeWindow(IApp app, IMainLayoutVM mainLayoutVM, IAfterStartupCompleteQueue? afterStartupCompleteQueue = null, Window? parentWindow = null)
	{
		if (_manager == null)
		{
			Log.Error("Cannot show welcome window: _manager is not initialized");
			return;
		}
		Log.Info("Showing welcome dialog...");
		new WelcomeVM(_manager, app, _serviceProvider.GetTypedService<IProPresenterResourceService>(), _serviceProvider.GetTypedService<IGeneral>(), _serviceProvider.GetTypedService<IWelcomeAnalyticEventsPublisher>(), _serviceProvider.GetTypedService<IHyperlinkService>(), _serviceProvider.GetTypedService<IWebSourceProvider>(), mainLayoutVM.ScreenConfigVM, _serviceProvider.GetTypedService<ITimerFactory>(), _serviceProvider.GetTypedService<INetwork>(), _serviceProvider.GetTypedService<IImportProcessFactory>(), _serviceProvider.GetTypedService<IMediaImportService>(), _serviceProvider.GetTypedService<IMediaFactory>(), _serviceProvider.GetTypedService<IOutputRepository>(), _serviceProvider.GetTypedService<IFlagService>(), _serviceProvider.GetTypedService<ILocalization>(), _serviceProvider.GetTypedService<ICloudOnboardingService>(), _serviceProvider.GetTypedService<ICloudWorkspaceService>(), _serviceProvider.GetTypedService<IWorkspaceService>(), _serviceProvider.GetTypedService<IWorkspaceDocumentOrchestrator>(), _serviceProvider.GetTypedService<IRegistrationWebResourceService>(), afterStartupCompleteQueue, _serviceProvider.GetTypedService<IUiScheduler>(), _serviceProvider.GetTypedService<IManageWorkspacesWindowProvider>(), _serviceProvider.GetTypedService<IChangeWorkspaceHandler>(), _serviceProvider.GetTypedService<ILogger>(), _serviceProvider.GetTypedService<IWorkspaceCollectionVM>()).ShowWelcomeDialog(parentWindow, isFirstLaunch: true);
	}

	protected override void OnExit(ExitEventArgs e)
	{
		Log.Info("Main Window closed");
		Log.Info("Starting shutdown...");
		((DispatcherObject)this).Dispatcher.InvokeShutdown();
		_mainWindow?.Dispose();
		_apiHandler?.Dispose();
		_manager?.Shutdown();
		_proCoreSendDataCancellationTokenSource?.Cancel();
		_proCoreSendDataCancellationTokenSource?.Dispose();
		_proSendDataTask?.Wait();
		DataVault.Cleanup();
		_actionFactoryResetter?.Dispose();
		base.OnExit(e);
	}

	private ProCoreStartupResult StartupProCore(IFlagService flagService, IApp app)
	{
		try
		{
			ProCoreRenderBitDepth proCoreRenderBitDepth = ((app.RenderBitDepth != BitDepth.Enhanced) ? ProCoreRenderBitDepth.Standard8 : ProCoreRenderBitDepth.Enhanced16);
			ProCoreRenderBitDepth renderBitDepth = proCoreRenderBitDepth;
			ProCoreInstance proCoreInstance = new ProCoreInstance(((DispatcherObject)this).Dispatcher, LogProCoreMessage, Dreamcatcher.ReportUnhandledException, flagService, "GLSL", app.ShowAdvancedOnScreenStats, Advanced.Settings.NDIShowLocalSources, Advanced.Settings.NDIInputGroups, Advanced.Settings.NDIExtraIPs, ProCoreRenderMode.DirectX, renderBitDepth);
			return (!proCoreInstance.DirectXVersionMeetsMinimumRequirements()) ? new ProCoreStartupResult(ProResult.NoGraphicsDevice, proCoreInstance) : new ProCoreStartupResult(ProResult.Success, proCoreInstance);
		}
		catch (ProResultException ex)
		{
			return new ProCoreStartupResult(ex.ProResult, null);
		}
	}

	private static void InitializeAnalytics()
	{
		Log.Info("Analytics Enabled: {0}", Stargazer.EnableAnalytics);
		Stargazer.EnableAnalytics = General.Settings.EnableAnalytics;
		Stargazer.EnableCrashReporting = General.Settings.EnableCrashReporting;
		EventPublisher.AddDefaultHandler();
	}

	private void SetupWpfAdditions(IFlagService flagService, IApp app)
	{
		Log.Info("Initializing WPF...");
		Log.Info("Loading theme...");
		AppTheme.Initialize(app);
		Log.Info("Loading localized strings...");
		CultureInfo culture = CultureInfo.CurrentUICulture;
		if (!General.Settings.SelectedLanguage.Equals(CultureInfo.InvariantCulture))
		{
			culture = General.Settings.SelectedLanguage;
		}
		string localizationFailErrorMessage;
		bool num = LoadLocalizations(flagService, culture, out localizationFailErrorMessage);
		Log.Info("Done loading localized strings");
		Log.Info("Initializing Reactive Property");
		ReactivePropertyScheduler.SetDefault(new ReactivePropertyWpfScheduler(((DispatcherObject)this).Dispatcher));
		Log.Info("Loading WPF themes...");
		base.Resources.MergedDictionaries.Add(new SharedResourceDictionary
		{
			Source = new Uri("pack://application:,,,/ProPresenter.UI;component/GlobalStyles.xaml")
		});
		base.Resources.MergedDictionaries.Add(new SharedResourceDictionary
		{
			Source = new Uri("pack://application:,,,/Pro.UI;component/Themes/generic.xaml")
		});
		if (!num)
		{
			string message = "There was an error while attempting to load localized strings:\n\n   " + localizationFailErrorMessage + "\n\nPlease see log for more information.";
			MessageDialogService.ShowSimpleContent("Error Loading Localized Strings...", message, canCancel: false);
		}
	}

	private static bool LoadLocalizations(IFlagService flagService, CultureInfo culture, out string localizationFailErrorMessage)
	{
		localizationFailErrorMessage = string.Empty;
		if (!flagService.IsFlagEnabled(Pro.Common.FeatureFlag.Flag.ShowLocalizationKeys))
		{
			return LocalizedStrings.Load("resources\\Localizations", culture, out localizationFailErrorMessage);
		}
		return true;
	}

	private SplashDialog? ShowSplash(bool isFirstLaunch)
	{
		if (isFirstLaunch)
		{
			return null;
		}
		Log.Info("Opening the splash dialog...");
		SplashDialog splashDialog = new SplashDialog();
		splashDialog.AppVersion = VersionInfo.FullDisplayAppVersion;
		splashDialog.Show();
		return splashDialog;
	}

	private static bool CheckDigitalSignatures()
	{
		return true;
	}

	private static void LogProCoreMessage(ProMessageType type, string message, nint userData)
	{
		string text = "[ProCore] ";
		switch (type)
		{
		case ProMessageType.Info:
			Log.Info(text + message);
			break;
		case ProMessageType.Warning:
			Log.Warning(text + message);
			break;
		case ProMessageType.Error:
			Log.Error(text + message);
			break;
		}
	}

	private static void LoadPackagedContent()
	{
		Log.Info("Installing bundled content...");
		FileHelper.CopyAll("resources\\Sample Content\\Themes", CommonPaths.Themes, overwrite: true);
	}

	private static void MigrateSettings(IMigrationSource migrationSource, ISqliteMigrationService migrationService)
	{
		migrationService.RegisterSource(migrationSource);
		migrationService.MigrateForward();
	}

	private void SimulateCrashIfEnabled(IFlagService flagService)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		if (flagService.IsFlagEnabled(Pro.Common.FeatureFlag.Flag.SimulateCrashOnStartup))
		{
			Log.Info("Simulating Crash flag is set.");
			DispatcherTimer val = new DispatcherTimer((DispatcherPriority)4, ((DispatcherObject)this).Dispatcher);
			val.Tick += delegate
			{
				Log.Info("Simulating Crash...Now");
				throw new ApplicationException("This is a test");
			};
			val.Interval = TimeSpan.FromSeconds(5L);
			val.Start();
		}
	}

	private void CheckPathPermissions()
	{
		initializeFolders();
		CommonPaths.BaseFolderChanged += delegate
		{
			initializeFolders(shouldExit: false);
		};
		void initializeFolders(bool shouldExit = true)
		{
			string[] requiredCommonPaths = CommonPaths.RequiredCommonPaths;
			foreach (string text in requiredCommonPaths)
			{
				if (!Directory.Exists(text))
				{
					try
					{
						Directory.CreateDirectory(text);
					}
					catch
					{
						showErrorMessage(text, shouldExit);
						break;
					}
				}
				else if (!FileHelper.CanEnumeratePath(text) || !PermissionChecker.HasReadWritePermission(text))
				{
					showErrorMessage(text, shouldExit);
					break;
				}
			}
		}
		void showErrorMessage(string commonPath, bool shouldExit = true)
		{
			if (MessageDialogService.ShowDialog(string.Empty, (DependencyObject)(object)new FolderPermissionWarning(LocalizedStrings.Get("FOLDER_PERMISSION_ALERT_message", new object[1] { commonPath })), SupportFolderAccessOption.Default | SupportFolderAccessOption.Quit, SupportFolderAccessOption.Quit) == SupportFolderAccessOption.Default)
			{
				CommonPaths.Base = CommonPaths.DefaultShowDirectoryBase;
			}
			if (shouldExit)
			{
				Shutdown();
			}
		}
	}

	private static void StartupCoreApplication(ServiceProvider serviceProvider, IFlagService flagService, ICollaborationPeerIdProvider collaborationPeerIdProvider)
	{
		IVersionInfoProvider service = serviceProvider.GetService<IVersionInfoProvider>();
		bool flag = flagService.IsFlagEnabled(Pro.Common.FeatureFlag.Flag.ServerDrivenFeatureFlags);
		ApplicationStartParams applicationStartParams = new ApplicationStartParams
		{
			Application = new ApplicationParams
			{
				ProductInfo = new Pro.SerializationInterop.RVProtoData.Application.ProductInformation
				{
					ProductName = "ProPresenter",
					MajorVersion = service.AppVersion.Major.ToString(),
					MinorVersion = service.AppVersion.Minor.ToString(),
					PatchVersion = service.AppVersion.Revision.ToString(),
					BuildNumber = service.AppVersion.Build.ToString(),
					BuildDate = service.BuildDate.ToFileTimeUtc()
				},
				PeerId = collaborationPeerIdProvider.CollaborationPeerId
			},
			Registration = new RegistrationCreationOption()
		};
		foreach (string item in from f in flagService.AllFlags.Where(flagService.IsFlagEnabled)
			select f.GetSerializationKey())
		{
			applicationStartParams.Application.EnabledFeatures.Add(item);
		}
		if (flagService.IsFlagEnabled(Pro.Common.FeatureFlag.Flag.CloudWorkspaces))
		{
			IWorkspace workspace = CommonPaths.Workspaces.First((IWorkspace w) => w.Path.IsPathEqual(CommonPaths.Base));
			applicationStartParams.Media = new Pro.SerializationInterop.RVProtoData.MediaManagement.v2.CreationOption
			{
				Name = "rv_mm",
				ShowDirectory = CommonPaths.Base
			};
			if (workspace.CloudId.HasValue)
			{
				applicationStartParams.Media.WorkspaceId = workspace.CloudId.Value.ToString();
			}
		}
		else
		{
			applicationStartParams.MediaV1 = new Pro.SerializationInterop.RVProtoData.MediaManagement.v1.CreationOption
			{
				Name = "rv_mm",
				ShowDirectory = CommonPaths.Base
			};
		}
		if (flag)
		{
			applicationStartParams.FeatureFlags = new Pro.SerializationInterop.RVProtoData.FeatureFlags.CreationOption();
			IFeatureFlagService typedService = serviceProvider.GetTypedService<IFeatureFlagService>();
			flagService.SetServerSideFeatureFlagObservable(typedService.WhenServerSideFlagsChange);
		}
		if (flagService.IsFlagEnabled(Pro.Common.FeatureFlag.Flag.Cloud))
		{
			applicationStartParams.Document = new Pro.SerializationInterop.RVProtoData.Service.Document.CreationOption();
			applicationStartParams.Workspace = new Pro.SerializationInterop.RVProtoData.Service.Workspace.CreationOption
			{
				MinProVersion = ProPresenter.DO.Workspaces.Workspace.CurrentDataModelVersion.ToString()
			};
		}
		serviceProvider.GetTypedService<ICoreApplication>().Start(applicationStartParams, serviceProvider.GetTypedService<IApplicationFailureMessageService>(), delegate
		{
			IMessageService typedService2 = serviceProvider.GetTypedService<IMessageService>();
			BootstrappingCompleteEvent.Publish("Bootstrapping failed and application closing.");
			typedService2.PublishMessage(new RequestApplicationCloseMessage());
		}, delegate
		{
			serviceProvider.GetTypedService<IAppUpdateService>().ShowUpdateViewer();
		});
	}

	private void PublishStartupSettingsEvent(IApp app)
	{
		IGeneral typedService = _serviceProvider.GetTypedService<IGeneral>();
		IProPresenterResourceService typedService2 = _serviceProvider.GetTypedService<IProPresenterResourceService>();
		IAdvanced typedService3 = _serviceProvider.GetTypedService<IAdvanced>();
		StartupSettingsEvent.Publish(typedService.ShowHoW, string.IsNullOrEmpty(typedService.LogoFilename), typedService2.CCLIPresentation.Display, typedService2.CCLIPresentation.DisplayType.ToUICopyrightStyleValue(), !string.IsNullOrEmpty(typedService2.CCLIPresentation.License), RenderModeValue.DirectX, typedService3.SuppressVideoStart, typedService3.ManageMediaAutomatically, typedService3.EnableSearchRoots, app.UpdateChannel.ToUpdateChannelValue());
	}

	private void StartSupervisoingWorkspaceHelper()
	{
		_serviceProvider.GetTypedService<IProcessSupervisor>("WorkspaceHelperProcessSupervisor");
	}
}
