using System.ComponentModel;
using Pro.Common.Mathematics;

namespace Pro.ssAPI.Devices;

public interface IVideoOutputDevice : IDevice, INotifyPropertyChanged
{
	VideoOutputDeviceType DeviceType { get; }

	int ActiveMode { get; }

	VideoModeCollection Modes { get; }

	string Model { get; }

	string DeviceName { get; }

	string Vendor { get; }

	bool IsPrimaryMonitor { get; }

	Rect<double> SystemFrame { get; }

	bool SupportsAlphaKey { get; }

	bool SupportsInternalAlphaKey { get; }

	bool SupportsExternalAlphaKey { get; }

	bool SupportsHdrOutput { get; }
}
