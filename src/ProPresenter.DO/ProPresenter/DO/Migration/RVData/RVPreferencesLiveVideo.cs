using Pro.Serialization.Control;

namespace ProPresenter.DO.Migration.RVData;

public class RVPreferencesLiveVideo
{
	[Child]
	[Alias("PreserveAspectRatio", typeof(bool), false)]
	public bool PreserveAspectRatio { get; internal set; }

	[Child]
	[Alias("SelectedSSAudioInputDevice", typeof(InputDevice), false)]
	public InputDevice? SelectedSSAudioInputDevice { get; internal set; }

	[Child]
	[Alias("SelectedSSVideoInputDevice", typeof(InputDevice), false)]
	public InputDevice? SelectedSSVideoInputDevice { get; internal set; }
}
