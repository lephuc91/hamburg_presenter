using System.Diagnostics.CodeAnalysis;
using Pro.Common.Collections;
using Pro.SerializationInterop.RVProtoData;
using Pro.ssAPI.Devices;

namespace ProPresenter.DO.OutputConfiguration;

public class PhysicalDeviceProvider : IPhysicalDeviceProvider
{
	public INotifyEnumerableChanged<PhysicalDevice> AttachedPhysicalDevices => PhysicalDevice.AttachedPhysicalDevices;

	public bool AnySDIDevicesAttached => PhysicalDevice.AnySDIDevicesAttached;

	public PhysicalDevice FromProtoOutputDisplay(OutputDisplay protoOutputDisplay)
	{
		return PhysicalDevice.FromProtoOutputDisplay(protoOutputDisplay);
	}

	public void TrackRenderEngineDevices(VideoOutputDeviceCollection videoOutputs)
	{
		PhysicalDevice.TrackRenderEngineDevices(videoOutputs);
	}

	public bool TryGetDevice(string deviceID, [MaybeNullWhen(false)] out PhysicalDevice device)
	{
		return PhysicalDevice.TryGetDevice(deviceID, out device);
	}
}
