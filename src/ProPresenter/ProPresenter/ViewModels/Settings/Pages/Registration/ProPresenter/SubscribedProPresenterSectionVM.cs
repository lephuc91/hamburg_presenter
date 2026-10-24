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

public class SubscribedProPresenterSectionVM : ObservableObject, ISubscribedProPresenterSectionVM, ICanChangeSeatProPresenterVM, IProPresenterSectionVM, INotifyPropertyChanged
{
	private readonly IRegistrationOperationFactory _registrationOperationFactory;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly Uri _addSeatsUri;

	[ObservableProperty]
	private string _deviceName;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? addSeatsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<SeatState>? changeSeatStateCommand;

	public int AvailableSeats { get; }

	public int TotalSeats { get; }

	public SeatState SeatState { get; }

	public bool CanActivateSeat { get; }

	public bool ShowSeatInfo { get; }

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
	public IRelayCommand AddSeatsCommand => addSeatsCommand ?? (addSeatsCommand = new RelayCommand(AddSeats, AllowAddingSeats));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<SeatState> ChangeSeatStateCommand => changeSeatStateCommand ?? (changeSeatStateCommand = new AsyncRelayCommand<SeatState>(ChangeSeatState, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	public SubscribedProPresenterSectionVM(IRegistrationOperationFactory registrationOperationFactory, IHyperlinkService hyperlinkService, IRegistrationWebResourceService registrationWebResourceService, SubscribedState state)
	{
		_registrationOperationFactory = registrationOperationFactory;
		_hyperlinkService = hyperlinkService;
		_addSeatsUri = new Uri(registrationWebResourceService.GetAddSeats());
		_deviceName = state.DeviceName;
		AvailableSeats = state.SeatInfo.AvailableSeats;
		TotalSeats = state.SeatInfo.TotalSeats;
		SeatState = ((!state.SeatInfo.IsActive) ? SeatState.Inactive : SeatState.Active);
		CanActivateSeat = AvailableSeats > 0;
		ShowSeatInfo = state.SeatInfo.HasSeatData;
	}

	[RelayCommand(CanExecute = "AllowAddingSeats")]
	private void AddSeats()
	{
		_hyperlinkService.Open(_addSeatsUri);
	}

	private bool AllowAddingSeats()
	{
		if (!CanActivateSeat)
		{
			return SeatState == SeatState.Inactive;
		}
		return false;
	}

	[RelayCommand(FlowExceptionsToTaskScheduler = true)]
	private async Task ChangeSeatState(SeatState value)
	{
		if (value != SeatState)
		{
			await _registrationOperationFactory.ChangeSeatType(value == SeatState.Active);
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnDeviceNameChanged(string value)
	{
		_registrationOperationFactory.SetDeviceName(value);
	}
}
