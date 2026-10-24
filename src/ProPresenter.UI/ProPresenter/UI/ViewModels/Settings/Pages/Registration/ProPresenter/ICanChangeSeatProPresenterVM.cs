using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Registration.ProPresenter;

public interface ICanChangeSeatProPresenterVM : IProPresenterSectionVM, INotifyPropertyChanged
{
	SeatState SeatState { get; }

	IAsyncRelayCommand<SeatState> ChangeSeatStateCommand { get; }
}
