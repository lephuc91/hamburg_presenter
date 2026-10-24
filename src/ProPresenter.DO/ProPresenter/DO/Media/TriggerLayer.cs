using Pro.Localization;

namespace ProPresenter.DO.Media;

public enum TriggerLayer
{
	[LocalizedString("MEDIA_TRIGGER_LAYER_BACKGROUND_title")]
	Background,
	[LocalizedString("MEDIA_TRIGGER_LAYER_FOREGROUND_title")]
	Foreground,
	Fill,
	[LocalizedString("MEDIA_TRIGGER_LAYER_VIDEO_INPUT_title")]
	Input
}
