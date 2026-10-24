using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Pro.Common.Collections;
using ProPresenterCore.ProCore.Interop;

namespace Pro.ssAPI.Devices;

public class VideoInputDeviceCollection : DeviceCollection<IVideoInputDevice>, IVideoInputDeviceCollection, INotifyEnumerableChanged<IVideoInputDevice>, IEnumerable<IVideoInputDevice>, IEnumerable, INotifyCollectionChanged
{
	public IAirCastVideoInputDevice? GetOrAddAirCastVideoInputDevice()
	{
		IAirCastVideoInputDevice airCastVideoInputDevice = base.Collection.OfType<IAirCastVideoInputDevice>().FirstOrDefault();
		if (airCastVideoInputDevice == null)
		{
			using ProVideoInputDevice proVideoInputDevice = new ProVideoInputDevice();
			proVideoInputDevice.AudioChannelCount = 2;
			airCastVideoInputDevice = new AirCastVideoInputDevice(proVideoInputDevice);
			base.Collection.Add(airCastVideoInputDevice);
		}
		return airCastVideoInputDevice;
	}

	internal IVideoInputDevice? AddDevice(ProVideoInputDevice device)
	{
		if (FindDevice(device.DeviceID) is IAirCastVideoInputDevice airCastVideoInputDevice)
		{
			airCastVideoInputDevice.Update(device);
			return airCastVideoInputDevice;
		}
		VideoInputDevice videoInputDevice = new VideoInputDevice(device);
		base.Collection.Add(videoInputDevice);
		return videoInputDevice;
	}

	internal VideoInputDevice? UpdateDevice(ProVideoInputDevice device)
	{
		if (FindDevice(device.DeviceID) is VideoInputDevice videoInputDevice)
		{
			videoInputDevice.IsActive = device.IsActive;
			videoInputDevice.HasSignal = device.HasSignal;
			videoInputDevice.ModeIndex = device.CurrentMode;
			return videoInputDevice;
		}
		return null;
	}

	internal IVideoInputDevice? UpdateOrAddDevice(ProVideoInputDevice device)
	{
		IVideoInputDevice videoInputDevice = UpdateDevice(device);
		return videoInputDevice ?? AddDevice(device);
	}
}
