using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pro.UI.Controls.Windowing;
using ProPresenter.DO.CloudOnboarding;

namespace ProPresenter.UI.ViewModels.CloudOnboarding;

public interface ICloudOnboardingEligibilityVM : INotifyPropertyChanged
{
	bool IsBusy { get; }

	OnboardingUserState UserState { get; }

	bool ShowSignIn { get; }

	bool ShowSubscribe { get; }

	bool ShowContinue { get; }

	bool ShowSkip { get; }

	IRelayCommand SubscribeCommand { get; }

	IRelayCommand OpenLearnMoreCommand { get; }

	IRelayCommand SignInOrSignUpCommand { get; }

	IAsyncRelayCommand<ICloseable> ContinueCommand { get; }

	void Initialize();
}
