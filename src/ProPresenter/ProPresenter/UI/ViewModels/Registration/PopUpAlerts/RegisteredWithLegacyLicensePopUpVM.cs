using System;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.HTTP;
using Pro.Web.Services;

namespace ProPresenter.UI.ViewModels.Registration.PopUpAlerts;

public class RegisteredWithLegacyLicensePopUpVM : IRegisteredWithLegacyLicensePopUpVM
{
	private readonly Uri _migrateUri;

	private readonly Uri _helpUri;

	private readonly IHyperlinkService _hyperlinkService;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? migrateCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? helpCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand MigrateCommand => migrateCommand ?? (migrateCommand = new RelayCommand(Migrate));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand HelpCommand => helpCommand ?? (helpCommand = new RelayCommand(Help));

	public RegisteredWithLegacyLicensePopUpVM(IRegistrationWebResourceService registrationWebResourceService, IHyperlinkService hyperlinkService, bool isSignedIn)
	{
		_hyperlinkService = hyperlinkService;
		_migrateUri = new Uri(registrationWebResourceService.GetUpgradeToSubscription());
		_helpUri = new Uri(registrationWebResourceService.GetLaunchPopUpKnowledgeBase((!isSignedIn) ? LaunchPopUp.SignedOutLegacyLicense : LaunchPopUp.SignedInActiveLegacyLicense));
	}

	[RelayCommand]
	private void Migrate()
	{
		_hyperlinkService.Open(_migrateUri);
	}

	[RelayCommand]
	private void Help()
	{
		_hyperlinkService.Open(_helpUri);
	}
}
