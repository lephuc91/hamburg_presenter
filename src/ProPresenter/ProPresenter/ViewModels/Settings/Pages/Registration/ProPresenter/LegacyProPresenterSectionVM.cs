using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProPresenter.DO.Registration.Operations;
using ProPresenter.DO.Registration.State.ProPresenter;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.ProPresenter;

namespace ProPresenter.ViewModels.Settings.Pages.Registration.ProPresenter;

public abstract class LegacyProPresenterSectionVM : ObservableObject, ILegacyProPresenterSectionVM, ICanChangeSeatProPresenterVM, IProPresenterSectionVM, INotifyPropertyChanged
{
	private readonly IRegistrationOperationFactory _registrationOperationFactory;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? unregisterCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<SeatState>? changeSeatStateCommand;

	public string DeviceName { get; }

	public string UnlockCode { get; }

	public bool IsExpired { get; }

	public SeatState SeatState { get; }

	public bool CanActivateSeat { get; }

	public IRegistrationUnlockCodeVM UnlockCodeVM { get; }

	public abstract string LicenseExpiration { get; }

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand UnregisterCommand => unregisterCommand ?? (unregisterCommand = new AsyncRelayCommand(Unregister, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<SeatState> ChangeSeatStateCommand => changeSeatStateCommand ?? (changeSeatStateCommand = new AsyncRelayCommand<SeatState>(ChangeSeatState, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	protected LegacyProPresenterSectionVM(IRegistrationOperationFactory registrationOperationFactory, CodeState state, IRegistrationUnlockCodeVM registrationUnlockCodeVM)
	{
		_registrationOperationFactory = registrationOperationFactory;
		UnlockCodeVM = registrationUnlockCodeVM;
		DeviceName = state.DeviceName;
		UnlockCode = state.RegistrationKey;
		SeatState = ((!state.SeatInfo.IsActive) ? SeatState.Inactive : SeatState.Active);
		IsExpired = state.IsExpired;
		CanActivateSeat = state.IsCurrentBuildCoveredByLicense;
	}

	[RelayCommand(FlowExceptionsToTaskScheduler = true)]
	private async Task Unregister()
	{
		await _registrationOperationFactory.Unregister();
	}

	[RelayCommand(FlowExceptionsToTaskScheduler = true)]
	private async Task ChangeSeatState(SeatState value)
	{
		if (value != SeatState)
		{
			await _registrationOperationFactory.ChangeSeatType(value == SeatState.Active);
		}
	}
}
