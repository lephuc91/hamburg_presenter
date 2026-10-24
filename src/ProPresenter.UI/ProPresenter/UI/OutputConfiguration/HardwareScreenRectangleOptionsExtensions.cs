using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI.OutputConfiguration;

public static class HardwareScreenRectangleOptionsExtensions
{
	public static bool CanSetVideoDelay(this HardwareScreenRectangleOptions hardwareScreenRectangleOptions)
	{
		if (hardwareScreenRectangleOptions?.OutputDevice != null && hardwareScreenRectangleOptions.IsConfigured)
		{
			return hardwareScreenRectangleOptions.OutputDevice.DeviceType != DeviceType.Placeholder;
		}
		return false;
	}
}
