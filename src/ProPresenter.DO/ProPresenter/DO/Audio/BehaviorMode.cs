using System.ComponentModel;
using Pro.Localization;

namespace ProPresenter.DO.Audio;

public enum BehaviorMode
{
	[Description("on")]
	[LocalizedString("SETTINGS_INPUTS_AUDIO_INPUT_MODE_ON_definition")]
	On,
	[Description("off")]
	[LocalizedString("SETTINGS_INPUTS_AUDIO_INPUT_MODE_OFF_definition")]
	Off,
	[Description("auto_off")]
	[LocalizedString("SETTINGS_INPUTS_AUDIO_INPUT_MODE_AUTO_OFF_definition")]
	AutoOff,
	[Description("auto_on")]
	[LocalizedString("SETTINGS_INPUTS_AUDIO_INPUT_MODE_AUTO_ON_definition")]
	AutoOn
}
