using System;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Registration.ProPresenter;

public interface ITryoutLicenseProPresenterSectionVM : ICanChangeSeatProPresenterVM, IProPresenterSectionVM, INotifyPropertyChanged
{
	string DeviceName { get; set; }

	DateTime LicenseExpiration { get; }

	IRelayCommand PurchaseLicenseCommand { get; }
}
