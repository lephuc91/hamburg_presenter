using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI.OutputConfiguration;

public class DeviceCommandParameter
{
	public ScreenTargetType? ScreenTargetType { get; }

	public HardwareScreenRectangleOptions? TargetRectangle { get; }

	public IDevice? Device { get; }

	public IDeviceMode? Mode { get; }

	public DeviceCommandParameter(ScreenTargetType? screenTargetType, HardwareScreenRectangleOptions? targetRectangle, IDevice? device)
	{
		ScreenTargetType = screenTargetType;
		TargetRectangle = targetRectangle;
		Device = device;
	}

	public DeviceCommandParameter(ScreenTargetType? screenTargetType, HardwareScreenRectangleOptions? targetRectangle, IDevice? device, IDeviceMode? mode)
		: this(screenTargetType, targetRectangle, device)
	{
		Mode = mode;
	}
}
