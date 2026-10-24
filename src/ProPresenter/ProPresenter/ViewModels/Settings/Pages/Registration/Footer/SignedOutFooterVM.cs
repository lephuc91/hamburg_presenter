using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.HTTP;
using Pro.Web.Services;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.Footer;

namespace ProPresenter.ViewModels.Settings.Pages.Registration.Footer;

public class SignedOutFooterVM : ObservableObject, ISignedOutFooterVM, IFooterVM, INotifyPropertyChanged
{
	private readonly IHyperlinkService _hyperlinkService;

	private readonly Uri _helpUri;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? helpCommand;

	public IEnterConfirmationCodeVM EnterConfirmationCodeVM { get; }

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand HelpCommand => helpCommand ?? (helpCommand = new RelayCommand(Help));

	public SignedOutFooterVM(IHyperlinkService hyperlinkService, IRegistrationWebResourceService registrationWebResourceService, IEnterConfirmationCodeVM enterConfirmationCodeVM, bool isRegistered)
	{
		_hyperlinkService = hyperlinkService;
		EnterConfirmationCodeVM = enterConfirmationCodeVM;
		_helpUri = new Uri(registrationWebResourceService.GetAccountsKnowledgeBase(isRegistered ? AccountState.SignedOutLegacyLicense : AccountState.SignedOutNoLicense));
	}

	[RelayCommand]
	public void Help()
	{
		_hyperlinkService.Open(_helpUri);
	}
}
