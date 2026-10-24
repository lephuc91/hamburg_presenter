using System;
using System.Collections.Generic;
using System.ComponentModel;
using Pro.SerializationInterop.RVProtoData;
using Pro.ssAPI.Devices;

namespace Pro.DO.Audio;

public interface IAudioDestination : INotifyPropertyChanged
{
	IAudioOutputDevice? AudioDevice { get; set; }

	int ChannelCount { get; }

	IEnumerable<IAudioChannelLevel>? DeviceChannelLevels { get; }

	bool IsConnected { get; set; }

	string Name { get; }

	string RenderID { get; }

	IAudioRouting<Bus, DeviceChannel> Routing { get; }

	event System.Action DataModified;

	void Deserialize(DigitalAudio.Types.Device? protoAudioDevice, Func<DigitalAudio.Types.Device, IAudioOutputDevice?>? findDevice = null);

	DigitalAudio.Types.Device Serialize();
}
