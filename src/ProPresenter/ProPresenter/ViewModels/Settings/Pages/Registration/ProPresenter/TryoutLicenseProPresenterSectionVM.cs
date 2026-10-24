using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.HTTP;
using Pro.Web.Services;
using ProPresenter.DO.Registration.Operations;
using ProPresenter.DO.Registration.State.ProPresenter;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.ProPresenter;

namespace ProPresenter.ViewModels.Settings.Pages.Registration.ProPresenter;

public class TryoutLicenseProPresenterSectionVM : ObservableObject, ITryoutLicenseProPresenterSectionVM, ICanChangeSeatProPresenterVM, IProPresenterSectionVM, INotifyPropertyChanged
{
	private readonly IRegistrationOperationFactory _registrationOperationFactory;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly Uri _purchaseUri;

	[ObservableProperty]
	private string _deviceName;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<SeatState>? changeSeatStateCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? purchaseLicenseCommand;

	public SeatState SeatState { get; }

	public bool CanActivateSeat => true;

	public DateTime LicenseExpiration { get; }

	public IRegistrationUnlockCodeVM? UnlockCodeVM => null;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string DeviceName
	{
		get
		{
			return _deviceName;
		}
		[MemberNotNull("_deviceName")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_deviceName, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.DeviceName);
				_deviceName = value;
				OnDeviceNameChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.DeviceName);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<SeatState> ChangeSeatStateCommand => changeSeatStateCommand ?? (changeSeatStateCommand = new AsyncRelayCommand<SeatState>(ChangeSeatState, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand PurchaseLicenseCommand => purchaseLicenseCommand ?? (purchaseLicenseCommand = new RelayCommand(PurchaseLicense));

	public TryoutLicenseProPresenterSectionVM(SubscribedState state, IRegistrationOperationFactory registrationOperationFactory, IHyperlinkService hyperlinkService, IRegistrationWebResourceService registrationWebResourceService)
	{
		_registrationOperationFactory = registrationOperationFactory;
		_hyperlinkService = hyperlinkService;
		_deviceName = state.DeviceName;
		SeatState = ((!state.SeatInfo.IsActive) ? SeatState.Inactive : SeatState.Active);
		LicenseExpiration = state.ExpirationDate;
		_purchaseUri = new Uri(registrationWebResourceService.GetPurchase(PurchaseOrigin.Trial));
	}

	[RelayCommand(FlowExceptionsToTaskScheduler = true)]
	private async Task ChangeSeatState(SeatState value)
	{
		if (value != SeatState)
		{
			await _registrationOperationFactory.ChangeSeatType(value == SeatState.Active);
		}
	}

	[RelayCommand]
	private void PurchaseLicense()
	{
		_hyperlinkService.Open(_purchaseUri);
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnDeviceNameChanged(string value)
	{
		_registrationOperationFactory.SetDeviceName(value);
	}
}
