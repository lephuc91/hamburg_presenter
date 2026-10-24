using Pro.ssAPI.Devices;

namespace ProPresenter.UI.LiveVideo;

public record SelectVideoDeviceCommandParameter(IVideoInputDevice? VideoInputDevice, IVideoMode? VideoMode)
{
	public SelectVideoDeviceCommandParameter(IVideoInputDevice? VideoInputDevice)
		: this(VideoInputDevice, null)
	{
	}
}
