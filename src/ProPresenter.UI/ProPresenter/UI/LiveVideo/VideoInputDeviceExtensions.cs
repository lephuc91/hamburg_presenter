using Pro.ssAPI.Devices;

namespace ProPresenter.UI.LiveVideo;

internal static class VideoInputDeviceExtensions
{
	public static bool ShouldDisplayMode(this IVideoInputDevice device)
	{
		if (!device.SupportsAutoModeSelection)
		{
			VideoModeCollection? modes = device.Modes;
			return modes == null || modes.Count >= 1;
		}
		return false;
	}
}
