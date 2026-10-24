using Pro.Serialization.Control;

namespace ProPresenter.DO.Migration.RVData;

public class InputDevice
{
	[Child]
	[Alias("DeviceName", typeof(string), false)]
	public string? DeviceName { get; internal set; }

	[Child]
	[Alias("ModeIndex", typeof(int), false)]
	public int ModeIndex { get; internal set; }
}
