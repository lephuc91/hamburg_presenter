using System.Diagnostics.CodeAnalysis;
using Pro.Common.Collections;
using Pro.SerializationInterop.RVProtoData;
using Pro.ssAPI.Devices;

namespace ProPresenter.DO.OutputConfiguration;

public interface IPhysicalDeviceProvider
{
	INotifyEnumerableChanged<PhysicalDevice> AttachedPhysicalDevices { get; }

	bool AnySDIDevicesAttached { get; }

	void TrackRenderEngineDevices(VideoOutputDeviceCollection videoOutputs);

	PhysicalDevice FromProtoOutputDisplay(OutputDisplay protoOutputDisplay);

	bool TryGetDevice(string deviceID, [MaybeNullWhen(false)] out PhysicalDevice device);
}
