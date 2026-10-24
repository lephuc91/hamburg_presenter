namespace Pro.ssAPI.Devices;

public static class VideoOutputDeviceTypeExtensions
{
	public static bool IsHardOutput(this VideoOutputDeviceType deviceType)
	{
		if (deviceType != VideoOutputDeviceType.DVI)
		{
			return deviceType == VideoOutputDeviceType.SDI;
		}
		return true;
	}

	public static bool IsSoftOutput(this VideoOutputDeviceType deviceType)
	{
		return !deviceType.IsHardOutput();
	}
}
