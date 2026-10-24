using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Registration.ProPresenter;

public interface IProPresenterPlusProPresenterSectionVM : ILegacyProPresenterSectionVM, ICanChangeSeatProPresenterVM, IProPresenterSectionVM, INotifyPropertyChanged
{
	int AvailableSeats { get; }

	int TotalSeats { get; }

	string LatestAvailableVersion { get; }

	bool IsCurrentBuildCoveredByLicense { get; }

	IRelayCommand DowngradeCommand { get; }

	bool ShowSeatInfo { get; }
}
