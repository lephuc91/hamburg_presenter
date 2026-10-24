using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Pro.Common.Background;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.FeatureFlag;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.Common.Startup;
using Pro.Common.Time.Timer;
using Pro.CoreApplication.Workspace;
using Pro.Localization.Services;
using Pro.UI.Components;
using Pro.UI.Controls.Windowing;
using Pro.Web.Services;
using ProPresenter.Controller;
using ProPresenter.DO;
using ProPresenter.DO.Analytics.Events.Welcome;
using ProPresenter.DO.CloudOnboarding;
using ProPresenter.DO.Import;
using ProPresenter.DO.Media;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Repositories;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Web;
using ProPresenter.DO.Workspaces;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Welcome;
using ProPresenter.UI.ViewModels.Workspaces;
using ProPresenter.UI.Welcome;
using ProPresenter.ViewModels.Settings.Pages.General;
using ProPresenter.ViewModels.Welcome;

namespace ProPresenter.ViewModels;

public class WelcomeVM : NotifyPropertyChangedBase, IWelcomeVM, INotifyPropertyChanged, IDisposable
{
	private readonly Lazy<IIntroVM> _introVM;

	private WelcomePage _currentPage;

	private WelcomePage? _previousPage;

	private readonly IFlagService _flagService;

	private readonly IAfterStartupCompleteQueue? _afterStartupCompleteQueue;

	private readonly IApp _app;

	private readonly ICloudOnboardingService? _cloudOnboardingService;

	private readonly ICloudWorkspaceService _cloudWorkspaceService;

	private readonly IDisposable? _workspacesChangedSubscription;

	private bool _hasReceivedWorkspaceNotification;

	private ICloseable? _welcomeWindow;

	private readonly ILogger _logger;

	private readonly IWorkspaceCollectionVM _workspaceCollectionVM;

	private bool _shouldBlockStartupPopups;

	public IWelcomeSignInVM? SignInVM { get; }

	public IWelcomeJoinWorkspaceVM? JoinWorkspaceVM { get; }

	public IWelcomeCreateWorkspaceVM? CreateWorkspaceVM { get; }

	public IIntroVM IntroVM => _introVM.Value;

	public IWelcomeMigrationVM MigrationVM { get; }

	public ISettingsVM SettingsVM { get; }

	public IScreenSetupVM ScreenSetupVM { get; }

	public IAppendixVM AppendixVM { get; }

	public ISampleContentVM SampleContentVM { get; }

	public IAdditionalResourcesVM? AdditionalResourcesVM { get; }

	public WelcomePage CurrentPage
	{
		get
		{
			return _currentPage;
		}
		set
		{
			SetValue("CurrentPage", ref _currentPage, value, (Action)delegate
			{
				OnPropertyChanged("ProgressValue");
			}, (Predicate<WelcomePage>?)null, referenceComparison: false);
		}
	}

	public WelcomePage? PreviousPage
	{
		get
		{
			return _previousPage;
		}
		private set
		{
			SetValue("PreviousPage", ref _previousPage, value);
		}
	}

	public int ProgressValue => CurrentPage switch
	{
		WelcomePage.Intro => 0, 
		WelcomePage.Migration => 1, 
		WelcomePage.ScreenConfiguration => 2, 
		WelcomePage.Settings => 3, 
		WelcomePage.SampleContent => 4, 
		WelcomePage.Appendix => 5, 
		_ => 0, 
	};

	public ICommand ContinueCommand => new RelayCommand(OnContinueCommand);

	public ICommand SkipCommand => new RelayCommand(OnSkipCommand);

	public ICommand<WelcomePage> NavigateCommand => new RelayCommand<WelcomePage>(OnNavigateCommand);

	public bool CanCloseWelcomeWindow { get; private set; }

	public bool IsCloudOnboardingEnabled => _flagService.IsFlagEnabled(Flag.Cloud);

	public WelcomeVM(ICoreManager manager, IApp app, IProPresenterResourceService resourceService, IGeneral general, IWelcomeAnalyticEventsPublisher analytics, IHyperlinkService hyperlinkService, IWebSourceProvider webSourceProvider, IScreenConfigVM screenConfigVM, ITimerFactory timerFactory, INetwork network, IImportProcessFactory importProcessFactory, IMediaImportService mediaImportService, IMediaFactory mediaFactory, IOutputRepository outputRepository, IFlagService flagService, ILocalization localization, ICloudOnboardingService cloudOnboardingService, ICloudWorkspaceService cloudWorkspaceService, IWorkspaceService workspaceService, IWorkspaceDocumentOrchestrator workspaceDocumentOrchestrator, IRegistrationWebResourceService registrationWebResourceService, IAfterStartupCompleteQueue? afterStartupCompleteQueue, IUiScheduler uiScheduler, IManageWorkspacesWindowProvider manageWorkspacesWindowProvider, IChangeWorkspaceHandler changeWorkspaceHandler, ILogger logger, IWorkspaceCollectionVM workspaceCollectionVM)
	{
		WelcomeVM welcomeVM = this;
		_flagService = flagService;
		_afterStartupCompleteQueue = afterStartupCompleteQueue;
		_app = app;
		_cloudOnboardingService = cloudOnboardingService;
		_cloudWorkspaceService = cloudWorkspaceService;
		_logger = logger;
		_workspaceCollectionVM = workspaceCollectionVM;
		OnPropertyChanged("CanCloseWelcomeWindow");
		IIntroContent[] array = Array.Empty<IntroContent>();
		IIntroContent[] contentArray = array;
		string location = Assembly.GetExecutingAssembly().Location;
		if (!string.IsNullOrEmpty(location))
		{
			location = Path.GetDirectoryName(location);
			if (!string.IsNullOrEmpty(location))
			{
				string path = Path.Combine(location, "resources\\Welcome");
				if (Directory.Exists(path))
				{
					string[] files = Directory.GetFiles(path);
					array = files.Select((string f) => new IntroContent(f)).ToArray();
					contentArray = array;
				}
			}
		}
		_introVM = new Lazy<IIntroVM>(() => new IntroVM(contentArray, timerFactory));
		if (IsCloudOnboardingEnabled)
		{
			SignInVM = new WelcomeSignInVM(cloudOnboardingService, hyperlinkService, registrationWebResourceService, delegate
			{
				ExecuteOnDispatcher(welcomeVM.OnSignInCompleted);
			}, delegate
			{
				welcomeVM.ContinueCommand.Execute(null);
			}, delegate
			{
				welcomeVM.SkipCommand.Execute(null);
			});
			JoinWorkspaceVM = new WelcomeJoinWorkspaceVM(cloudWorkspaceService, workspaceDocumentOrchestrator, changeWorkspaceHandler, delegate
			{
				ExecuteOnDispatcher(welcomeVM.OnNavigateToCreateWorkspace);
			}, delegate
			{
				ExecuteOnDispatcher(welcomeVM.OnNavigateToAdditionalResources);
			}, localization, logger, _workspaceCollectionVM);
			CreateWorkspaceVM = new WelcomeCreateWorkspaceVM(cloudOnboardingService, hyperlinkService, webSourceProvider, localization, workspaceService, workspaceDocumentOrchestrator, delegate
			{
				ExecuteOnDispatcher(welcomeVM.OnNavigateToScreenConfiguration);
			}, manageWorkspacesWindowProvider, logger);
			AdditionalResourcesVM = new AdditionalResourcesVM(analytics, hyperlinkService, webSourceProvider, cloudWorkspaceService, workspaceCollectionVM, logger);
			_workspacesChangedSubscription = cloudWorkspaceService.WhenWorkspacesChanged.ObserveOn(uiScheduler.Scheduler).Subscribe(delegate(IAvailableWorkspaces remotes)
			{
				welcomeVM._logger.Info("WelcomeVM: Received workspace notification. Type: " + remotes.GetType().Name);
				if (remotes is AvailableWorkspaces availableWorkspaces)
				{
					int count = availableWorkspaces.Workspaces.Count;
					welcomeVM._logger.Info($"WelcomeVM: After sync, found {count} cloud workspaces");
					welcomeVM._hasReceivedWorkspaceNotification = true;
					if (welcomeVM.CurrentPage == WelcomePage.SignIn)
					{
						OnboardingUserState userState = cloudOnboardingService.GetUserState();
						if (userState == OnboardingUserState.SignedInWithActiveSubscription || userState == OnboardingUserState.SignedInWithoutActiveSubscription)
						{
							welcomeVM.CheckAndNavigateAfterSignIn();
						}
					}
				}
			}, delegate(Exception error)
			{
				welcomeVM._logger.Error($"WelcomeVM: Error in workspace subscription: {error}");
			});
		}
		AppendixVM = new AppendixVM(analytics, hyperlinkService, webSourceProvider);
		SampleContentVM = new SampleContentVM(app, resourceService, analytics, webSourceProvider, hyperlinkService, importProcessFactory, mediaImportService, mediaFactory, outputRepository, cloudOnboardingService, flagService);
		MigrationVM = new WelcomeMigrationVM(manager, app, analytics, network, webSourceProvider, hyperlinkService, importProcessFactory);
		ScreenSetupVM = new ScreenSetupVM(screenConfigVM, hyperlinkService, analytics, webSourceProvider);
		SettingsVM = new SettingsVM(general);
	}

	public void ShowWelcomeDialog(Window? parentWindow, bool isFirstLaunch)
	{
		CanCloseWelcomeWindow = !isFirstLaunch;
		WelcomeDialog welcomeDialog = (WelcomeDialog)(_welcomeWindow = new WelcomeDialog
		{
			DataContext = this
		});
		if (parentWindow != null && parentWindow.IsLoaded)
		{
			welcomeDialog.Owner = parentWindow;
			welcomeDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
		}
		if (_cloudOnboardingService != null)
		{
			_cloudOnboardingService.IsOnboardingInProgress = true;
		}
		_shouldBlockStartupPopups = isFirstLaunch || (!isFirstLaunch && IsCloudOnboardingEnabled && !_app.HasSeenOnboarding);
		if (_shouldBlockStartupPopups)
		{
			_afterStartupCompleteQueue?.AddStartup();
		}
		welcomeDialog.Closed += delegate
		{
			if (_cloudOnboardingService != null)
			{
				_cloudOnboardingService.IsOnboardingInProgress = false;
			}
			if (_shouldBlockStartupPopups)
			{
				_afterStartupCompleteQueue?.CompleteStartup();
			}
			_app.IsFirstLaunch = false;
			_app.HasSeenOnboarding = true;
			_welcomeWindow = null;
		};
		if (IsCloudOnboardingEnabled)
		{
			OnNavigateCommand(WelcomePage.SignIn);
		}
		else
		{
			OnNavigateCommand(WelcomePage.Intro);
		}
		if (isFirstLaunch)
		{
			welcomeDialog.ShowDialog();
		}
		else
		{
			welcomeDialog.Show();
		}
	}

	private void OnSignInCompleted()
	{
		if (_hasReceivedWorkspaceNotification)
		{
			CheckAndNavigateAfterSignIn();
		}
	}

	private void CheckAndNavigateAfterSignIn()
	{
		if (_cloudWorkspaceService.RemoteWorkspaces.Count > 0)
		{
			OnNavigateCommand(WelcomePage.JoinWorkspace);
		}
		else
		{
			OnNavigateCommand(WelcomePage.CreateWorkspace);
		}
	}

	private void OnNavigateToCreateWorkspace()
	{
		OnNavigateCommand(WelcomePage.CreateWorkspace);
	}

	private void OnNavigateToScreenConfiguration()
	{
		OnNavigateCommand(WelcomePage.ScreenConfiguration);
	}

	private void OnNavigateToAdditionalResources()
	{
		OnNavigateCommand(WelcomePage.AdditionalResources);
	}

	private void OnContinueCommand()
	{
		switch (CurrentPage)
		{
		case WelcomePage.SignIn:
			OnSignInCompleted();
			break;
		case WelcomePage.Intro:
			if (IntroVM.CurrentPage == IntroVM.PageCount)
			{
				OnNavigateCommand(WelcomePage.Migration);
			}
			else
			{
				IntroVM.AdvanceToNextSlide();
			}
			break;
		case WelcomePage.Migration:
			if (MigrationVM.Status == MigrationStatus.Completed)
			{
				OnNavigateCommand(WelcomePage.ScreenConfiguration);
			}
			else
			{
				MigrationVM.Complete();
			}
			break;
		case WelcomePage.ScreenConfiguration:
			if (IsCloudOnboardingEnabled)
			{
				OnNavigateCommand(WelcomePage.DownloadContent);
			}
			else
			{
				OnNavigateCommand(WelcomePage.Settings);
			}
			break;
		case WelcomePage.Settings:
			OnNavigateCommand(WelcomePage.SampleContent);
			break;
		case WelcomePage.SampleContent:
			OnNavigateCommand(WelcomePage.Appendix);
			break;
		case WelcomePage.DownloadContent:
			OnNavigateCommand(WelcomePage.AdditionalResources);
			break;
		case WelcomePage.AdditionalResources:
			_welcomeWindow?.Close();
			break;
		case WelcomePage.Appendix:
			_welcomeWindow?.Close();
			break;
		default:
			throw new NotSupportedException();
		case WelcomePage.JoinWorkspace:
		case WelcomePage.CreateWorkspace:
			break;
		}
	}

	private void OnSkipCommand()
	{
		switch (CurrentPage)
		{
		case WelcomePage.SignIn:
			OnNavigateCommand(WelcomePage.CreateWorkspace);
			break;
		case WelcomePage.JoinWorkspace:
			OnNavigateCommand(WelcomePage.CreateWorkspace);
			break;
		case WelcomePage.CreateWorkspace:
			OnNavigateCommand(WelcomePage.Migration);
			break;
		case WelcomePage.Intro:
			OnNavigateCommand(WelcomePage.Migration);
			break;
		case WelcomePage.Migration:
			if (MigrationVM.Status == MigrationStatus.InProgress)
			{
				MigrationVM.Complete();
			}
			OnNavigateCommand(WelcomePage.ScreenConfiguration);
			break;
		}
	}

	private void OnNavigateCommand(WelcomePage welcomePage)
	{
		switch (welcomePage)
		{
		case WelcomePage.JoinWorkspace:
			JoinWorkspaceVM?.Initialize();
			break;
		case WelcomePage.CreateWorkspace:
			CreateWorkspaceVM?.Initialize();
			break;
		case WelcomePage.Intro:
			IntroVM.Initialize();
			break;
		case WelcomePage.Migration:
			IntroVM.Complete();
			MigrationVM.Initialize();
			if (MigrationVM.IsPro6Available)
			{
				CurrentPage = WelcomePage.Migration;
			}
			else
			{
				OnNavigateCommand(WelcomePage.ScreenConfiguration);
			}
			return;
		case WelcomePage.AdditionalResources:
			if (JoinWorkspaceVM?.SelectedWorkspace != null && AdditionalResourcesVM != null)
			{
				AdditionalResourcesVM.DownloadWorkspaceAsync(JoinWorkspaceVM.SelectedWorkspace).ExecuteAsync(delegate(Exception ex)
				{
					_logger?.Error($"Failed to download workspace: {ex}");
				});
			}
			break;
		}
		PreviousPage = CurrentPage;
		CurrentPage = welcomePage;
	}

	private static void ExecuteOnDispatcher(Action action)
	{
		Application current = Application.Current;
		Dispatcher val = ((current != null) ? ((DispatcherObject)current).Dispatcher : null);
		if (val == null || val.CheckAccess())
		{
			action();
		}
		else
		{
			val.BeginInvoke((Delegate)action, Array.Empty<object>());
		}
	}

	public void Dispose()
	{
		_workspacesChangedSubscription?.Dispose();
	}
}
