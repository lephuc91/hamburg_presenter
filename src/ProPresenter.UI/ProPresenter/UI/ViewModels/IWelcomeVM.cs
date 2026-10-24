using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Pro.UI.Components;
using ProPresenter.UI.ViewModels.Welcome;
using ProPresenter.UI.Welcome;

namespace ProPresenter.UI.ViewModels;

public interface IWelcomeVM : INotifyPropertyChanged, IDisposable
{
	IWelcomeSignInVM? SignInVM { get; }

	IWelcomeJoinWorkspaceVM? JoinWorkspaceVM { get; }

	IAdditionalResourcesVM? AdditionalResourcesVM { get; }

	IWelcomeCreateWorkspaceVM? CreateWorkspaceVM { get; }

	IIntroVM IntroVM { get; }

	IWelcomeMigrationVM MigrationVM { get; }

	IScreenSetupVM ScreenSetupVM { get; }

	ISettingsVM SettingsVM { get; }

	IAppendixVM AppendixVM { get; }

	ISampleContentVM SampleContentVM { get; }

	WelcomePage CurrentPage { get; set; }

	int ProgressValue { get; }

	bool IsCloudOnboardingEnabled { get; }

	ICommand ContinueCommand { get; }

	ICommand<WelcomePage> NavigateCommand { get; }

	bool CanCloseWelcomeWindow { get; }

	void ShowWelcomeDialog(Window parentWindow, bool isFirstLaunch);
}
