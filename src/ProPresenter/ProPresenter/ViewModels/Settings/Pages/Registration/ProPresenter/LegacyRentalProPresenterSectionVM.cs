using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.HTTP;
using Pro.Web.Services;
using ProPresenter.DO.Registration.Operations;
using ProPresenter.DO.Registration.State.ProPresenter;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.ProPresenter;

namespace ProPresenter.ViewModels.Settings.Pages.Registration.ProPresenter;

public class LegacyRentalProPresenterSectionVM : LegacyProPresenterSectionVM, ILegacyRentalProPresenterSectionVM, ILegacyProPresenterSectionVM, ICanChangeSeatProPresenterVM, IProPresenterSectionVM, INotifyPropertyChanged
{
	private readonly IHyperlinkService _hyperlinkService;

	private readonly Uri _purchaseUri;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? purchaseLicenseCommand;

	public override string LicenseExpiration { get; }

	public bool IsLicenseExpired { get; }

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand PurchaseLicenseCommand => purchaseLicenseCommand ?? (purchaseLicenseCommand = new RelayCommand(PurchaseLicense));

	public LegacyRentalProPresenterSectionVM(IRegistrationOperationFactory registrationOperationFactory, IHyperlinkService hyperlinkService, IRegistrationWebResourceService registrationWebResourceService, CodeState state, IRegistrationUnlockCodeVM registrationUnlockCodeVM)
		: base(registrationOperationFactory, state, registrationUnlockCodeVM)
	{
		_hyperlinkService = hyperlinkService;
		LicenseExpiration = state.ExpirationDate.ToLongDateString();
		IsLicenseExpired = state.MaintenanceExpirationDate < DateTime.Now;
		_purchaseUri = new Uri(registrationWebResourceService.GetUpgradeToSubscription());
	}

	[RelayCommand]
	private void PurchaseLicense()
	{
		_hyperlinkService.Open(_purchaseUri);
	}
}
