using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.HTTP;
using Pro.UI.Controls.Windowing;
using ProPresenter.DO.CloudOnboarding;
using ProPresenter.DO.Web;
using ProPresenter.UI.ViewModels.CloudOnboarding;

namespace ProPresenter.ViewModels.CloudOnboarding;

public sealed class CloudOnboardingDoneVM : ObservableObject, ICloudOnboardingDoneVM, INotifyPropertyChanged
{
	private readonly IHyperlinkService _hyperlinkService;

	private readonly IWebSourceProvider _webSource;

	private readonly ICloudOnboardingService _service;

	private readonly ICloudOnboardingShellNavigator _shell;

	[ObservableProperty]
	private bool _isBusy;

	[ObservableProperty]
	private bool _showGetStarted;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<ICloseable>? getStartedCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? openUpgradePlanCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? openLearnMoreCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsBusy
	{
		get
		{
			return _isBusy;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isBusy, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsBusy);
				_isBusy = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsBusy);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowGetStarted
	{
		get
		{
			return _showGetStarted;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showGetStarted, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ShowGetStarted);
				_showGetStarted = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ShowGetStarted);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<ICloseable> GetStartedCommand => getStartedCommand ?? (getStartedCommand = new RelayCommand<ICloseable>(GetStarted));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand OpenUpgradePlanCommand => openUpgradePlanCommand ?? (openUpgradePlanCommand = new RelayCommand(OpenUpgradePlan));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand OpenLearnMoreCommand => openLearnMoreCommand ?? (openLearnMoreCommand = new RelayCommand(OpenLearnMore));

	public CloudOnboardingDoneVM(IHyperlinkService hyperlinkService, IWebSourceProvider webSourceProvider, ICloudOnboardingService service, ICloudOnboardingShellNavigator shell)
	{
		_hyperlinkService = hyperlinkService;
		_webSource = webSourceProvider;
		_service = service;
		_shell = shell;
	}

	public async Task InitializeAsync()
	{
		IsBusy = true;
		ShowGetStarted = false;
		WorkspaceIssueFlags issues = WorkspaceIssueFlags.None;
		if (_shell is ICloudOnboardingVM cloudOnboardingVM)
		{
			issues = cloudOnboardingVM.Issues;
		}
		await ConvertAndWaitAsync(issues);
	}

	private async Task ConvertAndWaitAsync(WorkspaceIssueFlags issues)
	{
		try
		{
			await _service.ConvertToCloudAsync(issues);
		}
		catch
		{
		}
		finally
		{
			OnConversionComplete();
		}
	}

	[RelayCommand]
	public void GetStarted(ICloseable closeable)
	{
		closeable.Close();
	}

	[RelayCommand]
	public void OpenUpgradePlan()
	{
		_hyperlinkService.Open(_webSource.UnlockCloud);
	}

	[RelayCommand]
	public void OpenLearnMore()
	{
		_hyperlinkService.Open(_webSource.CloudCollaboration);
	}

	public void OnConversionComplete()
	{
		IsBusy = false;
		ShowGetStarted = true;
	}
}
