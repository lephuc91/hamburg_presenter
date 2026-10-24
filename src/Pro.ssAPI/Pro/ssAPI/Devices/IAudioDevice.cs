using System;
using System.ComponentModel;

namespace Pro.ssAPI.Devices;

public interface IAudioDevice : IDevice, INotifyPropertyChanged
{
	AudioDeviceType DeviceType { get; }

	int ChannelCount { get; }

	event Action ChannelCountChanged;
}
