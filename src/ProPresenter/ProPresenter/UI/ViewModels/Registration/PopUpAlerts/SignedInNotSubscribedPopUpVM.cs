using System;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.HTTP;
using Pro.Web.Services;

namespace ProPresenter.UI.ViewModels.Registration.PopUpAlerts;

public class SignedInNotSubscribedPopUpVM : ISignedInNotSubscribedPopUpVM
{
	private readonly Uri _subscribeUri;

	private readonly Uri _helpUri;

	private readonly IHyperlinkService _hyperlinkService;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? subscribeCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? helpCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand SubscribeCommand => subscribeCommand ?? (subscribeCommand = new RelayCommand(Subscribe));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand HelpCommand => helpCommand ?? (helpCommand = new RelayCommand(Help));

	public SignedInNotSubscribedPopUpVM(IRegistrationWebResourceService registrationWebResourceService, IHyperlinkService hyperlinkService)
	{
		_hyperlinkService = hyperlinkService;
		_subscribeUri = new Uri(registrationWebResourceService.GetPurchase(PurchaseOrigin.Inactive));
		_helpUri = new Uri(registrationWebResourceService.GetLaunchPopUpKnowledgeBase(LaunchPopUp.SignedInNoLicense));
	}

	[RelayCommand]
	private void Subscribe()
	{
		_hyperlinkService.Open(_subscribeUri);
	}

	[RelayCommand]
	private void Help()
	{
		_hyperlinkService.Open(_helpUri);
	}
}
