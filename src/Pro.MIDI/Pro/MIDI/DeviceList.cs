namespace Pro.MIDI;

public static class DeviceList
{
	public static InputDeviceCollection InputDevices { get; } = new InputDeviceCollection();

	public static OutputDeviceCollection OutputDevices { get; } = new OutputDeviceCollection();
}
