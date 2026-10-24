using System;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.HTTP;
using Pro.Web.Services;

namespace ProPresenter.UI.ViewModels.Registration.PopUpAlerts;

public class FullySignedOutPopUpVM : ISignedOutPopUpVM
{
	private readonly Uri _signInUri;

	private readonly Uri _signUpUri;

	private readonly Uri _helpUri;

	private readonly IHyperlinkService _hyperlinkService;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? signInCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? signUpCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? helpCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand SignInCommand => signInCommand ?? (signInCommand = new RelayCommand(SignIn));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand SignUpCommand => signUpCommand ?? (signUpCommand = new RelayCommand(SignUp));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand HelpCommand => helpCommand ?? (helpCommand = new RelayCommand(Help));

	public FullySignedOutPopUpVM(IRegistrationWebResourceService registrationWebResourceService, IHyperlinkService hyperlinkService)
	{
		_hyperlinkService = hyperlinkService;
		_signInUri = new Uri(registrationWebResourceService.GetSignIn());
		_signUpUri = new Uri(registrationWebResourceService.GetSignUp());
		_helpUri = new Uri(registrationWebResourceService.GetLaunchPopUpKnowledgeBase(LaunchPopUp.SignedOutNoLicense));
	}

	[RelayCommand]
	private void SignIn()
	{
		_hyperlinkService.Open(_signInUri);
	}

	[RelayCommand]
	private void SignUp()
	{
		_hyperlinkService.Open(_signUpUri);
	}

	[RelayCommand]
	private void Help()
	{
		_hyperlinkService.Open(_helpUri);
	}
}
