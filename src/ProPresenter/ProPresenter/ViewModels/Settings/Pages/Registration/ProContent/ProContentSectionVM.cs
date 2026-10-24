using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.HTTP;
using Pro.Web.Services;
using ProPresenter.DO.Registration.State;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.ProContent;

namespace ProPresenter.ViewModels.Settings.Pages.Registration.ProContent;

public class ProContentSectionVM : ObservableObject, IProContentSectionVM, INotifyPropertyChanged
{
	private readonly IHyperlinkService _hyperlinkService;

	private readonly Uri _upgradeUrl;

	private readonly Uri _signInUrl;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? upgradeCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? signInCommand;

	public bool IsSignedIn { get; }

	public ProContentSubscriptionType SubscriptionType { get; }

	private bool CanUpgrade { get; }

	private bool CanSignIn { get; }

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand UpgradeCommand => upgradeCommand ?? (upgradeCommand = new RelayCommand(Upgrade, () => CanUpgrade));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand SignInCommand => signInCommand ?? (signInCommand = new RelayCommand(SignIn, () => CanSignIn));

	public ProContentSectionVM(ProContentRegistrationState state, bool isRegistered, IHyperlinkService hyperlinkService, IRegistrationWebResourceService registrationWebResourceService)
	{
		IsSignedIn = state != ProContentRegistrationState.NotSignedIn;
		CanSignIn = !IsSignedIn && isRegistered;
		SubscriptionType = ((state == ProContentRegistrationState.Premium) ? ProContentSubscriptionType.Premium : ProContentSubscriptionType.Free);
		CanUpgrade = IsSignedIn && SubscriptionType == ProContentSubscriptionType.Free;
		_hyperlinkService = hyperlinkService;
		_upgradeUrl = new Uri(registrationWebResourceService.GetUpgradeProContent());
		_signInUrl = new Uri(registrationWebResourceService.GetSignIn());
	}

	[RelayCommand(CanExecute = "CanUpgrade")]
	private void Upgrade()
	{
		_hyperlinkService.Open(_upgradeUrl);
	}

	[RelayCommand(CanExecute = "CanSignIn")]
	private void SignIn()
	{
		_hyperlinkService.Open(_signInUrl);
	}
}
