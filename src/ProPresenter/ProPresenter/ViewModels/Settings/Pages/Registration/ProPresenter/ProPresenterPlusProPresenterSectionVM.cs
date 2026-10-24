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

public class ProPresenterPlusProPresenterSectionVM : LegacyProPresenterSectionVM, IProPresenterPlusProPresenterSectionVM, ILegacyProPresenterSectionVM, ICanChangeSeatProPresenterVM, IProPresenterSectionVM, INotifyPropertyChanged
{
	private readonly IHyperlinkService _hyperlinkService;

	private readonly IRegistrationWebResourceService _registrationWebResourceService;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? downgradeCommand;

	public bool ShowSeatInfo { get; }

	public int AvailableSeats { get; }

	public int TotalSeats { get; }

	public bool IsLicenseExpired { get; }

	public override string LicenseExpiration { get; }

	public string LatestAvailableVersion { get; }

	public bool IsCurrentBuildCoveredByLicense { get; }

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand DowngradeCommand => downgradeCommand ?? (downgradeCommand = new RelayCommand(Downgrade));

	public ProPresenterPlusProPresenterSectionVM(IRegistrationOperationFactory registrationOperationFactory, CodeState state, IRegistrationUnlockCodeVM registrationUnlockCodeVM, IHyperlinkService hyperlinkService, IRegistrationWebResourceService registrationWebResourceService)
		: base(registrationOperationFactory, state, registrationUnlockCodeVM)
	{
		LicenseExpiration = state.MaintenanceExpirationDate.ToLongDateString();
		IsLicenseExpired = state.MaintenanceExpirationDate < DateTime.Now;
		AvailableSeats = state.SeatInfo.AvailableSeats;
		TotalSeats = state.SeatInfo.TotalSeats;
		ShowSeatInfo = state.SeatInfo.HasSeatData;
		LatestAvailableVersion = state.LatestAvailableVersion;
		IsCurrentBuildCoveredByLicense = state.IsCurrentBuildCoveredByLicense;
		_hyperlinkService = hyperlinkService;
		_registrationWebResourceService = registrationWebResourceService;
	}

	[RelayCommand]
	private void Downgrade()
	{
		_hyperlinkService.Open(new Uri(_registrationWebResourceService.GetDownloadProPresenterVersions()));
	}
}
