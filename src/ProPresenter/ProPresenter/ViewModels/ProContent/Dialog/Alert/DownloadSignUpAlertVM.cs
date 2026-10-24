using System;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.HTTP;
using Pro.Web.Services;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.Alerts;

namespace ProPresenter.ViewModels.ProContent.Dialog.Alert;

public class DownloadSignUpAlertVM : IDownloadSignUpAlertVM
{
	private readonly IHyperlinkService _hyperlinkService;

	private readonly Uri _signUpUri;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? signUpCommand;

	public string SignInUri { get; }

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand SignUpCommand => signUpCommand ?? (signUpCommand = new RelayCommand(SignUp));

	public DownloadSignUpAlertVM(IHyperlinkService hyperlinkService, IRegistrationWebResourceService registrationWebResourceService)
	{
		_hyperlinkService = hyperlinkService;
		SignInUri = registrationWebResourceService.GetSignIn().ToString();
		_signUpUri = new Uri(registrationWebResourceService.GetSignUp());
	}

	[RelayCommand]
	private void SignUp()
	{
		_hyperlinkService.Open(_signUpUri);
	}
}
