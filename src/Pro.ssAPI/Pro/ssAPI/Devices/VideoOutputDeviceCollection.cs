using ProPresenterCore.ProCore.Interop;

namespace Pro.ssAPI.Devices;

public class VideoOutputDeviceCollection : DeviceCollection<IVideoOutputDevice>
{
	internal void AddDevice(ProVideoOutputDevice device)
	{
		base.Collection.Add(new VideoOutputDevice(device));
	}
}
