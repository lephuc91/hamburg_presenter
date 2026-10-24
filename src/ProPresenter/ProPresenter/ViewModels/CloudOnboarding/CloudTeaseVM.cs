using System;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.UI.Controls.Windowing;
using ProPresenter.DO.CloudOnboarding;
using ProPresenter.DO.Web;
using ProPresenter.UI.ViewModels.CloudOnboarding;

namespace ProPresenter.ViewModels.CloudOnboarding;

public class CloudTeaseVM : ObservableObject, ICloudTeaseVM
{
	private readonly IHyperlinkService _hyperlinkService;

	private readonly IWebSourceProvider _webSourceProvider;

	private readonly ICloudOnboardingService _cloudOnboardingService;

	private readonly ILogger _logger;

	private bool _isClosingFromSignUp;

	private bool _isClosingFromRemindLater;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? learnMoreCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<ICloseable?>? signUpForEarlyAccessCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<ICloseable?>? remindMeLaterCommand;

	public bool ShouldShowCloudTease => _cloudOnboardingService.ShouldShowCloudTease();

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand LearnMoreCommand => learnMoreCommand ?? (learnMoreCommand = new RelayCommand(LearnMore));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<ICloseable?> SignUpForEarlyAccessCommand => signUpForEarlyAccessCommand ?? (signUpForEarlyAccessCommand = new RelayCommand<ICloseable>(SignUpForEarlyAccess));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<ICloseable?> RemindMeLaterCommand => remindMeLaterCommand ?? (remindMeLaterCommand = new RelayCommand<ICloseable>(RemindMeLater));

	public CloudTeaseVM(IHyperlinkService hyperlinkService, IWebSourceProvider webSourceProvider, ICloudOnboardingService cloudOnboardingService, ILogger logger)
	{
		_hyperlinkService = hyperlinkService;
		_webSourceProvider = webSourceProvider;
		_cloudOnboardingService = cloudOnboardingService;
		_logger = logger;
	}

	[RelayCommand]
	private void LearnMore()
	{
		try
		{
			_hyperlinkService.Open(_webSourceProvider.DiscoverCloud);
		}
		catch (Exception ex)
		{
			_logger.Error("Failed to open Learn More link: " + ex.Message);
		}
	}

	[RelayCommand]
	private void SignUpForEarlyAccess(ICloseable? window)
	{
		try
		{
			_hyperlinkService.Open(_webSourceProvider.CloudEarlyAccess);
			_cloudOnboardingService.HandleCloudTeaseDismissal(remindLater: false);
			_isClosingFromSignUp = true;
			window?.Close();
		}
		catch (Exception ex)
		{
			_logger.Error("Failed to open Sign Up link: " + ex.Message);
		}
	}

	[RelayCommand]
	private void RemindMeLater(ICloseable? window)
	{
		_cloudOnboardingService.HandleCloudTeaseDismissal(remindLater: true);
		_isClosingFromRemindLater = true;
		window?.Close();
	}

	public void OnWindowClosed()
	{
		if (!_isClosingFromSignUp && !_isClosingFromRemindLater)
		{
			_cloudOnboardingService.HandleCloudTeaseDismissal(remindLater: false);
		}
	}
}
