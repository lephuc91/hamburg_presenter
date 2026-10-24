using Pro.Localization;

namespace Pro.Text;

public enum TextFillType
{
	[LocalizedString("EDITOR_PRESENTATION_TEXT_INSPECTOR_TEXT_FILL_SOLID_COLOR_title")]
	SolidColor,
	[LocalizedString("EDITOR_PRESENTATION_TEXT_INSPECTOR_TEXT_FILL_GRADIENT_title")]
	Gradient,
	[LocalizedString("EDITOR_PRESENTATION_TEXT_INSPECTOR_TEXT_FILL_CUT_OUT_title")]
	CutOut,
	[LocalizedString("EDITOR_PRESENTATION_TEXT_INSPECTOR_TEXT_FILL_MEDIA_title")]
	Media,
	[LocalizedString("EDITOR_PRESENTATION_TEXT_INSPECTOR_TEXT_FILL_BACKGROUND_INVERT_title")]
	BackgroundInvert,
	[LocalizedString("EDITOR_PRESENTATION_TEXT_INSPECTOR_TEXT_FILL_BACKGROUND_BLUR_title")]
	BackgroundBlur
}
