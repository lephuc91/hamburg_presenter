using Pro.Localization;

namespace Pro.ssAPI;

public enum ScaleBehavior
{
	[LocalizedString("MEDIA_SCALE_BEHAVIOR_SCALE_TO_FIT_title")]
	ScaleToFit,
	[LocalizedString("MEDIA_SCALE_BEHAVIOR_SCALE_TO_FILL_title")]
	ScaleToFill,
	[LocalizedString("MEDIA_SCALE_BEHAVIOR_STRETCH_TO_FILL_title")]
	StretchToFill,
	[LocalizedString("MEDIA_SCALE_BEHAVIOR_CUSTOM_FIT_title")]
	CustomFit,
	[LocalizedString("MEDIA_SCALE_BEHAVIOR_SCALE_AND_BLUR_title")]
	ScaleAndBlur
}
