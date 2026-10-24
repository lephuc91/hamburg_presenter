using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Pro.Common.Collections;
using ProPresenterCore.ProCore.Interop;

namespace Pro.ssAPI.Devices;

public class AudioInputDeviceCollection : DeviceCollection<IAudioInputDevice>, IAudioInputDeviceCollection, INotifyEnumerableChanged<IAudioInputDevice>, IEnumerable<IAudioInputDevice>, IEnumerable, INotifyCollectionChanged
{
	internal AudioInputDevice AddDevice(ProAudioDevice device)
	{
		AudioInputDevice audioInputDevice = new AudioInputDevice(device);
		base.Collection.Add(audioInputDevice);
		return audioInputDevice;
	}

	internal AudioInputDevice? UpdateDevice(ProAudioDevice device)
	{
		if (base.Collection.FirstOrDefault((IAudioInputDevice d) => d.UUID == device.DeviceID) is AudioInputDevice audioInputDevice)
		{
			audioInputDevice.ChannelCount = device.ChannelCount;
			return audioInputDevice;
		}
		return null;
	}

	internal AudioInputDevice UpdateOrAddDevice(ProAudioDevice device)
	{
		return UpdateDevice(device) ?? AddDevice(device);
	}
}
