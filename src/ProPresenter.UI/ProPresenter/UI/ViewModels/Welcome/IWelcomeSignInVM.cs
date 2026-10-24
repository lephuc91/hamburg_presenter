using System;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.Welcome;

public interface IWelcomeSignInVM : INotifyPropertyChanged, IDisposable
{
	bool HasNoNetwork { get; }

	bool IsSignedIn { get; }

	bool IsWaitingForSignIn { get; }

	bool ShowSignInButtons { get; }

	bool ShowContinueButton { get; }

	bool ShowSkipButton { get; }

	IRelayCommand SignUpCommand { get; }

	IRelayCommand SignInCommand { get; }

	IRelayCommand StartFreeTrialCommand { get; }

	IRelayCommand ContinueCommand { get; }

	IRelayCommand SkipCommand { get; }
}
