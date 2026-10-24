using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pro.UI.Controls.Windowing;
using ProPresenter.UI.ViewModels.CloudOnboarding;

namespace ProPresenter.ViewModels.CloudOnboarding;

public sealed class CloudOnboardingLocalWorkspacesVM : ObservableObject, ICloudOnboardingLocalWorkspacesVM, ICloudOnboardingNavigateVM, INotifyPropertyChanged
{
	private readonly ICloudOnboardingShellNavigator _shell;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<ICloseable>? continueCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<ICloseable>? backCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<ICloseable> ContinueCommand => continueCommand ?? (continueCommand = new RelayCommand<ICloseable>(Continue));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<ICloseable> BackCommand => backCommand ?? (backCommand = new RelayCommand<ICloseable>(Back));

	public CloudOnboardingLocalWorkspacesVM(ICloudOnboardingShellNavigator shell)
	{
		_shell = shell;
	}

	[RelayCommand]
	public void Continue(ICloseable closeable)
	{
		_shell.HandleNavigationIntent(OnboardingIntent.Continue, closeable);
	}

	[RelayCommand]
	public void Back(ICloseable closeable)
	{
		_shell.HandleNavigationIntent(OnboardingIntent.Back, closeable);
	}
}
