using System.ComponentModel;
using Pro.ssAPI.Devices;

namespace ProPresenter.Controller.NetworkAPI;

public interface IAirCastConfiguration : INotifyPropertyChanged
{
	bool Enabled { get; }

	string DeviceID { get; }

	string? ServiceName { get; set; }

	string? Password { get; set; }

	string PluginPath { get; }

	bool PluginExists { get; }

	bool PasswordEnabled { get; set; }

	void SetDeviceInputs(IVideoInputDeviceCollection videoInputDevices);

	void NotifyPluginInstalled();

	bool GetShouldRequirePassword();
}
