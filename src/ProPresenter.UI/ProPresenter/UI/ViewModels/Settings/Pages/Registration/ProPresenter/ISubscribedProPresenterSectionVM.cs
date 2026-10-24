using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Registration.ProPresenter;

public interface ISubscribedProPresenterSectionVM : ICanChangeSeatProPresenterVM, IProPresenterSectionVM, INotifyPropertyChanged
{
	string DeviceName { get; set; }

	int AvailableSeats { get; }

	int TotalSeats { get; }

	bool CanActivateSeat { get; }

	bool ShowSeatInfo { get; }

	IRelayCommand AddSeatsCommand { get; }
}
