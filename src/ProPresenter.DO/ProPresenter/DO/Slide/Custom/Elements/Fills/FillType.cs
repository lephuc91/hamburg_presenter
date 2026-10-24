using Pro.Localization;

namespace ProPresenter.DO.Slide.Custom.Elements.Fills;

public enum FillType
{
	[LocalizedString("GRAPHIC_FILL_COLOR_title")]
	Solid,
	[LocalizedString("GRAPHIC_FILL_GRADIENT_title")]
	Gradient,
	[LocalizedString("GRAPHIC_FILL_MEDIA_title")]
	Media,
	[LocalizedString("GRAPHIC_FILL_VIDEO_INPUT_title")]
	Live,
	[LocalizedString("GRAPHIC_FILL_WEB_title")]
	HTML,
	SlidePreview,
	OutputScreen,
	PDF,
	Bitmap,
	[LocalizedString("GRAPHIC_FILL_BACKGROUND_EFFECT_BLUR_title")]
	BackgroundEffectBlur,
	[LocalizedString("GRAPHIC_FILL_BACKGROUND_EFFECT_INVERT_title")]
	BackgroundEffectInvert
}
