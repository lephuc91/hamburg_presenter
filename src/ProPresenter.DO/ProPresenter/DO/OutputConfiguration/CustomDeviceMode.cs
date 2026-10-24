using Pro.SerializationInterop.RVProtoData;
using Pro.ssAPI.Devices;

namespace ProPresenter.DO.OutputConfiguration;

public class CustomDeviceMode : DeviceMode
{
	public override int ModeIndex => -1;

	public CustomDeviceMode(IVideoMode videoMode)
		: base(videoMode)
	{
	}

	public CustomDeviceMode(Pro.SerializationInterop.RVProtoData.DisplayMode mode)
		: base(mode, -1)
	{
	}
}
