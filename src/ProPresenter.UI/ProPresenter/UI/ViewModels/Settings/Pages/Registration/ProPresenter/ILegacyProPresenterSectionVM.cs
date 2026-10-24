using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Registration.ProPresenter;

public interface ILegacyProPresenterSectionVM : ICanChangeSeatProPresenterVM, IProPresenterSectionVM, INotifyPropertyChanged
{
	string DeviceName { get; }

	string UnlockCode { get; }

	string LicenseExpiration { get; }

	bool IsExpired { get; }

	bool CanActivateSeat { get; }

	IAsyncRelayCommand UnregisterCommand { get; }
}
