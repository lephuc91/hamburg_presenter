using System.ComponentModel;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.UI.Components;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.UI.OutputConfiguration;

namespace ProPresenter.UI.ViewModels.OutputConfiguration;

public interface IDeviceSelectorVM : INotifyPropertyChanged
{
	IOutputConfiguration OutputConfiguration { get; }

	INotifyEnumerableChanged<PhysicalDevice> AttachedPhysicalDevices { get; }

	ICommand AddCombinedScreenCommand { get; }

	ICommand AddEdgeBlendScreenCommand { get; }

	ICommand<DeviceCommandParameter?> AssignDeviceCommand { get; }

	ICommand ClearScreenIdentifyCommand { get; }

	ICommand<PhysicalDevice> IdentifyScreenCommand { get; }
}
