using Pro.Localization;

namespace Pro.Text;

public enum ScaleMode
{
	[LocalizedString("EDITOR_PRESENTATION_TEXT_INSPECTOR_SCALING_NONE_title")]
	None,
	[LocalizedString("EDITOR_PRESENTATION_TEXT_INSPECTOR_SCALING_ADJUST_CONTAINER_HEIGHT_title")]
	AdjustContainerHeight,
	[LocalizedString("EDITOR_PRESENTATION_TEXT_INSPECTOR_SCALING_SCALE_FONT_UP_title")]
	Up,
	[LocalizedString("EDITOR_PRESENTATION_TEXT_INSPECTOR_SCALING_SCALE_FONT_DOWN_title")]
	Down,
	[LocalizedString("EDITOR_PRESENTATION_TEXT_INSPECTOR_SCALING_SCALE_FONT_UP_DOWN_title")]
	UpOrDown
}
