using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.HTTP;
using Pro.Web.Services;
using ProPresenter.DO.CloudOnboarding;
using ProPresenter.UI.ViewModels.Welcome;

namespace ProPresenter.ViewModels.Welcome;

public sealed class WelcomeSignInVM : ObservableObject, IWelcomeSignInVM, INotifyPropertyChanged, IDisposable
{
	private readonly ICloudOnboardingService _service;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly Uri _signInUri;

	private readonly Uri _signUpUri;

	private readonly Uri _freeTrialUri;

	private readonly IDisposable _userStateSubscription;

	private readonly Action _advanceFlow;

	private readonly Action? _continueAction;

	private readonly Action? _skipAction;

	[ObservableProperty]
	private bool _hasNoNetwork;

	[ObservableProperty]
	private bool _isSignedIn;

	[ObservableProperty]
	private bool _isWaitingForSignIn;

	[ObservableProperty]
	private bool _showSignInButtons = true;

	[ObservableProperty]
	private bool _showContinueButton;

	[ObservableProperty]
	private bool _showSkipButton = true;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? signUpCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? signInCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? startFreeTrialCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? continueCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? skipCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool HasNoNetwork
	{
		get
		{
			return _hasNoNetwork;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_hasNoNetwork, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.HasNoNetwork);
				_hasNoNetwork = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.HasNoNetwork);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsSignedIn
	{
		get
		{
			return _isSignedIn;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isSignedIn, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsSignedIn);
				_isSignedIn = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsSignedIn);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsWaitingForSignIn
	{
		get
		{
			return _isWaitingForSignIn;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isWaitingForSignIn, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsWaitingForSignIn);
				_isWaitingForSignIn = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsWaitingForSignIn);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowSignInButtons
	{
		get
		{
			return _showSignInButtons;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showSignInButtons, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ShowSignInButtons);
				_showSignInButtons = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ShowSignInButtons);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowContinueButton
	{
		get
		{
			return _showContinueButton;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showContinueButton, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ShowContinueButton);
				_showContinueButton = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ShowContinueButton);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowSkipButton
	{
		get
		{
			return _showSkipButton;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showSkipButton, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ShowSkipButton);
				_showSkipButton = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ShowSkipButton);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand SignUpCommand => signUpCommand ?? (signUpCommand = new RelayCommand(SignUp));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand SignInCommand => signInCommand ?? (signInCommand = new RelayCommand(SignIn));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand StartFreeTrialCommand => startFreeTrialCommand ?? (startFreeTrialCommand = new RelayCommand(StartFreeTrial));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ContinueCommand => continueCommand ?? (continueCommand = new RelayCommand(Continue));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand SkipCommand => skipCommand ?? (skipCommand = new RelayCommand(Skip));

	public WelcomeSignInVM(ICloudOnboardingService service, IHyperlinkService hyperlinkService, IRegistrationWebResourceService registrationWebResourceService, Action advanceFlow, Action? continueAction = null, Action? skipAction = null)
	{
		_service = service;
		_hyperlinkService = hyperlinkService;
		_signInUri = new Uri(registrationWebResourceService.GetSignIn());
		_signUpUri = new Uri(registrationWebResourceService.GetSignUp());
		_freeTrialUri = new Uri(registrationWebResourceService.GetSignUp(RegistrationType.FreeTrial));
		_advanceFlow = advanceFlow;
		_continueAction = continueAction;
		_skipAction = skipAction;
		_userStateSubscription = _service.WhenUserStateChanges.Subscribe(OnUserStateChanged);
		OnboardingUserState userState = _service.GetUserState();
		HasNoNetwork = userState == OnboardingUserState.NoNetwork;
		IsSignedIn = userState == OnboardingUserState.SignedInWithActiveSubscription || userState == OnboardingUserState.SignedInWithoutActiveSubscription;
		UpdateCallToActionButtonsVisibility();
	}

	[RelayCommand]
	public void SignUp()
	{
		IsWaitingForSignIn = true;
		_hyperlinkService.Open(_signUpUri);
	}

	[RelayCommand]
	public void SignIn()
	{
		IsWaitingForSignIn = true;
		_hyperlinkService.Open(_signInUri);
	}

	[RelayCommand]
	public void StartFreeTrial()
	{
		IsWaitingForSignIn = true;
		_hyperlinkService.Open(_freeTrialUri);
	}

	[RelayCommand]
	public void Continue()
	{
		_continueAction?.Invoke();
	}

	[RelayCommand]
	public void Skip()
	{
		_skipAction?.Invoke();
	}

	private void OnUserStateChanged(OnboardingUserState newState)
	{
		HasNoNetwork = newState == OnboardingUserState.NoNetwork;
		IsSignedIn = newState == OnboardingUserState.SignedInWithActiveSubscription || newState == OnboardingUserState.SignedInWithoutActiveSubscription;
		if (!IsWaitingForSignIn || newState == OnboardingUserState.SignedOut || newState == OnboardingUserState.NoNetwork)
		{
			UpdateCallToActionButtonsVisibility();
			return;
		}
		IsWaitingForSignIn = false;
		_advanceFlow?.Invoke();
	}

	private void UpdateCallToActionButtonsVisibility()
	{
		if (HasNoNetwork || IsSignedIn)
		{
			ShowSignInButtons = false;
			ShowContinueButton = true;
			ShowSkipButton = false;
		}
		else
		{
			ShowSignInButtons = true;
			ShowContinueButton = false;
			ShowSkipButton = true;
		}
	}

	public void Dispose()
	{
		_userStateSubscription.Dispose();
	}
}
