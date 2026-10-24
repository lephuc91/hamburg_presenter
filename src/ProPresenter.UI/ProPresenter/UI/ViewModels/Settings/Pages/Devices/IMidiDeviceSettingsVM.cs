using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProPresenter.Controller.Outputs.Communication;
using ProPresenter.DO.Communication;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Devices;

public interface IMidiDeviceSettingsVM : IChildPageSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	DeviceCollection Devices { get; }

	IDevice? TargetDevice { get; set; }

	IRelayCommand RemoveDeviceItemCommand { get; }

	IRelayCommand<IDevice> SetTargetDeviceCommand { get; }

	IRelayCommand HelpCommand { get; }
}
