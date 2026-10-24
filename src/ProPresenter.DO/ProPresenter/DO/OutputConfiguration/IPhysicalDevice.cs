using System.ComponentModel;
using Pro.Common.Collections;

namespace ProPresenter.DO.OutputConfiguration;

public interface IPhysicalDevice : IDevice, INotifyPropertyChanged
{
	IDeviceSpecificAlphaKeySettings? HardwareSettings { get; }

	ImmutableObservableCollection<DeviceMode> AvailableModes { get; }
}
