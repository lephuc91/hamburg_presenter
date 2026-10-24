using Pro.Serialization.Control;

namespace ProPresenter.DO.Migration.RVData;

public class RVPreferencesSDI
{
	[Child]
	[Alias("AlphaKeyBlend", typeof(int), false)]
	public int AlphaKeyBlend { get; internal set; }

	[Child]
	[Alias("AlphaKeyType", typeof(int), false)]
	public int AlphaKeyType { get; internal set; }

	[Child]
	[Alias("DeviceChecked", typeof(bool), false)]
	public bool DeviceChecked { get; internal set; }

	[Child]
	[Alias("IgnoreBackgroundColors", typeof(bool), false)]
	public bool IgnoreBackgroundColors { get; internal set; }

	[Child]
	[Alias("SelectedSSOutputDevice", typeof(InputDevice), false)]
	public InputDevice? SelectedSSOutputDevice { get; internal set; }
}
