using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Pro.Common.Collections;
using ProPresenterCore.ProCore.Interop;

namespace Pro.ssAPI.Devices;

public class AudioOutputDeviceCollection : DeviceCollection<IAudioOutputDevice>, IAudioOutputDeviceCollection, INotifyEnumerableChanged<IAudioOutputDevice>, IEnumerable<IAudioOutputDevice>, IEnumerable, INotifyCollectionChanged
{
	internal void AddDevice(ProAudioDevice device)
	{
		base.Collection.Add(new AudioOutputDevice(device));
	}

	internal void UpdateDevice(ProAudioDevice device)
	{
		if (base.Collection.FirstOrDefault((IAudioOutputDevice d) => d.UUID == device.DeviceID) is AudioOutputDevice audioOutputDevice)
		{
			audioOutputDevice.ChannelCount = device.ChannelCount;
		}
	}
}
