using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Dispatcher;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.Localization;
using Pro.UI.Controls.Windowing;
using Pro.UI.DialogService;
using Pro.Web.Services;
using ProPresenter.DO.CloudOnboarding;
using ProPresenter.DO.Web;
using ProPresenter.UI.ViewModels.CloudOnboarding;

namespace ProPresenter.ViewModels.CloudOnboarding;

public sealed class CloudOnboardingEligibilityVM : ObservableObject, ICloudOnboardingEligibilityVM, INotifyPropertyChanged, IDisposable
{
	private readonly ICloudOnboardingService _service;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly Uri _signInUri;

	private readonly Uri _subscriptionUri;

	private readonly ICloudOnboardingShellNavigator _shell;

	private readonly IUiDispatcher _dispatcher;

	private readonly IWebSourceProvider _webSource;

	private readonly IDisposable _userStateSubscription;

	private readonly ILogger _logger;

	private readonly IMessageDialogService _messageDialogService;

	[ObservableProperty]
	private OnboardingUserState _userState;

	[ObservableProperty]
	private bool _showSignIn;

	[ObservableProperty]
	private bool _showSubscribe;

	[ObservableProperty]
	private bool _showContinue = true;

	[ObservableProperty]
	private bool _showSkip = true;

	[ObservableProperty]
	[NotifyPropertyChangedFor("IsBusy")]
	private bool _isLoadingPricing;

	[ObservableProperty]
	[NotifyPropertyChangedFor("IsBusy")]
	private bool _isSigningIn;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<ICloseable>? skipCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? openLearnMoreCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? signInOrSignUpCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? subscribeCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<ICloseable>? continueCommand;

	public bool IsBusy
	{
		get
		{
			if (!IsLoadingPricing)
			{
				return IsSigningIn;
			}
			return true;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public OnboardingUserState UserState
	{
		get
		{
			return _userState;
		}
		set
		{
			if (!EqualityComparer<OnboardingUserState>.Default.Equals(_userState, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.UserState);
				_userState = value;
				OnUserStateChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.UserState);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowSignIn
	{
		get
		{
			return _showSignIn;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showSignIn, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ShowSignIn);
				_showSignIn = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ShowSignIn);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowSubscribe
	{
		get
		{
			return _showSubscribe;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showSubscribe, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ShowSubscribe);
				_showSubscribe = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ShowSubscribe);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowContinue
	{
		get
		{
			return _showContinue;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showContinue, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ShowContinue);
				_showContinue = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ShowContinue);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowSkip
	{
		get
		{
			return _showSkip;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showSkip, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ShowSkip);
				_showSkip = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ShowSkip);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsLoadingPricing
	{
		get
		{
			return _isLoadingPricing;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isLoadingPricing, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsLoadingPricing);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsBusy);
				_isLoadingPricing = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsLoadingPricing);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsBusy);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsSigningIn
	{
		get
		{
			return _isSigningIn;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isSigningIn, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsSigningIn);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsBusy);
				_isSigningIn = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsSigningIn);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsBusy);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<ICloseable> SkipCommand => skipCommand ?? (skipCommand = new RelayCommand<ICloseable>(Skip));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand OpenLearnMoreCommand => openLearnMoreCommand ?? (openLearnMoreCommand = new RelayCommand(OpenLearnMore));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand SignInOrSignUpCommand => signInOrSignUpCommand ?? (signInOrSignUpCommand = new RelayCommand(SignInOrSignUp));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand SubscribeCommand => subscribeCommand ?? (subscribeCommand = new RelayCommand(Subscribe));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<ICloseable> ContinueCommand => continueCommand ?? (continueCommand = new AsyncRelayCommand<ICloseable>(ContinueAsync, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	public CloudOnboardingEligibilityVM(ICloudOnboardingService service, IHyperlinkService hyperlinkService, IRegistrationWebResourceService registrationWebResourceService, IUiDispatcher dispatcher, IWebSourceProvider webSourceProvider, ICloudOnboardingShellNavigator shell, IMessageDialogService messageDialogService, ILogger logger)
	{
		_service = service;
		_hyperlinkService = hyperlinkService;
		_signInUri = new Uri(registrationWebResourceService.GetSignIn());
		_subscriptionUri = new Uri(registrationWebResourceService.GetUpgradeToSubscription());
		_dispatcher = dispatcher;
		_webSource = webSourceProvider;
		_shell = shell;
		_messageDialogService = messageDialogService;
		_logger = logger;
		_userStateSubscription = _service.WhenUserStateChanges.Subscribe(delegate(OnboardingUserState newState)
		{
			_dispatcher.Invoke(delegate
			{
				if (IsSigningIn && UserState == OnboardingUserState.SignedOut && newState != OnboardingUserState.SignedOut)
				{
					IsSigningIn = false;
				}
				UserState = newState;
			});
		});
	}

	public void Initialize()
	{
		UserState = _service.GetUserState();
		IsSigningIn = false;
		IsLoadingPricing = false;
		UpdateCtaVisibility();
	}

	[RelayCommand]
	public void Skip(ICloseable closeable)
	{
		_shell.HandleNavigationIntent(OnboardingIntent.Dismiss, closeable);
	}

	[RelayCommand]
	public void OpenLearnMore()
	{
		_hyperlinkService.Open(_webSource.DiscoverCloud);
	}

	[RelayCommand]
	public void SignInOrSignUp()
	{
		IsSigningIn = true;
		_hyperlinkService.Open(_signInUri);
	}

	[RelayCommand]
	public void Subscribe()
	{
		_hyperlinkService.Open(_subscriptionUri);
	}

	[RelayCommand(FlowExceptionsToTaskScheduler = true)]
	public async Task ContinueAsync(ICloseable closeable)
	{
		if (UserState == OnboardingUserState.NoNetwork)
		{
			_shell.HandleNavigationIntent(OnboardingIntent.Dismiss, closeable);
			return;
		}
		IsLoadingPricing = true;
		try
		{
			var (value, workspaceIssueFlags) = await _service.InspectWorkspaceAsync();
			_logger.Info($"CloudOnboardingEligibilityVM: Workspace inspected - size={value}, issues={workspaceIssueFlags}");
			if (_shell is ICloudOnboardingVM cloudOnboardingVM)
			{
				cloudOnboardingVM.Issues = workspaceIssueFlags;
			}
			if (!(await _service.GetPricingOptionsAsync()).Item1)
			{
				_logger.Error("CloudOnboardingEligibilityVM: Failed to load pricing options - showing retry dialog");
				await ShowPricingFailureDialogAsync(closeable);
			}
			else
			{
				_shell.HandleNavigationIntent(OnboardingIntent.Continue, closeable);
			}
		}
		catch (Exception ex)
		{
			_logger.Error("CloudOnboardingEligibilityVM: Exception during continue process", ex);
		}
		finally
		{
			IsLoadingPricing = false;
			_logger.Info("CloudOnboardingEligibilityVM: Loading state cleared");
		}
	}

	private async Task ShowPricingFailureDialogAsync(ICloseable closeable)
	{
		IsLoadingPricing = false;
		bool retry = false;
		_dispatcher.Invoke(delegate
		{
			ButtonDescriptor[] buttons = new ButtonDescriptor[2]
			{
				new ButtonDescriptor(LocalizedStrings.Get("CLOUD_ONBOARDING_ERROR_ALERT_try_again"), IsDefault: true, IsCancel: false, delegate
				{
					retry = true;
				}),
				new ButtonDescriptor(LocalizedStrings.Get("CLOUD_ONBOARDING_ERROR_ALERT_skip"), IsDefault: false, IsCancel: false, delegate
				{
					retry = false;
				})
			};
			_messageDialogService.ShowDialog(LocalizedStrings.Get("CLOUD_ONBOARDING_ERROR_ALERT_title"), LocalizedStrings.Get("CLOUD_ONBOARDING_ERROR_ALERT_message"), buttons, DialogIcon.Default);
		});
		if (retry)
		{
			_logger.Info("User chose to retry pricing options");
			await ContinueAsync(closeable);
		}
		else
		{
			_logger.Info("User chose to skip pricing options");
			_service.HandleDismissal(UserState, skipForNow: true);
			_shell.HandleNavigationIntent(OnboardingIntent.Dismiss, closeable);
		}
	}

	private void UpdateCtaVisibility()
	{
		ShowSignIn = UserState == OnboardingUserState.SignedOut;
		ShowSubscribe = UserState == OnboardingUserState.SignedInWithoutActiveSubscription;
		OnboardingUserState userState = UserState;
		bool showContinue = ((userState == OnboardingUserState.SignedInWithActiveSubscription || userState == OnboardingUserState.NoNetwork) ? true : false);
		ShowContinue = showContinue;
		ShowSkip = UserState != OnboardingUserState.NoNetwork;
	}

	public void Dispose()
	{
		_userStateSubscription.Dispose();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnUserStateChanged(OnboardingUserState value)
	{
		UpdateCtaVisibility();
	}
}
