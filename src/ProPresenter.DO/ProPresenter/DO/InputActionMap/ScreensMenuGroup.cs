using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Localization;
using Pro.UI.InputActions;

namespace ProPresenter.DO.InputActionMap;

public class ScreensMenuGroup : InputActionGroupBase
{
	public InputAction AudienceEnable { get; }

	public InputAction EditLooks { get; }

	public InputAction StageEnable { get; }

	public InputAction EditLayouts { get; }

	public InputAction EditSelectedLayout { get; }

	public InputAction ConfigureScreens { get; }

	public InputAction StartCapture { get; }

	public InputAction StopCapture { get; }

	public InputAction CaptureSettings { get; }

	public ScreensMenuGroup(string label, InputActionGroupCollectionBase parent)
		: base(label, parent)
	{
		AudienceEnable = Add("MAIN_MENU_SCREEN_ENABLE_AUDIENCE_title", LocalizedStrings.Get("MAIN_MENU_SCREEN_ENABLE_AUDIENCE_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.D1, (ModifierKeys)2).ToEnumerable());
		EditLooks = Add("MAIN_MENU_SCREEN_EDIT_AUDIENCE_LOOKS_title", LocalizedStrings.Get("MAIN_MENU_SCREEN_EDIT_AUDIENCE_LOOKS_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.D1, (ModifierKeys)6).ToEnumerable());
		StageEnable = Add("MAIN_MENU_SCREEN_ENABLE_STAGE_title", LocalizedStrings.Get("MAIN_MENU_SCREEN_ENABLE_STAGE_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.D2, (ModifierKeys)2).ToEnumerable());
		EditLayouts = Add("MAIN_MENU_SCREEN_EDIT_STAGE_LAYOUTS_title", LocalizedStrings.Get("MAIN_MENU_SCREEN_EDIT_STAGE_LAYOUTS_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.D4, (ModifierKeys)2).ToEnumerable());
		ConfigureScreens = Add("MAIN_MENU_SCREEN_CONFIGURE_SCREENS_title", LocalizedStrings.Get("MAIN_MENU_SCREEN_CONFIGURE_SCREENS_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.D1, (ModifierKeys)3).ToEnumerable());
		StartCapture = Add("RECORDING_BUTTON_CONTEXT_MENU_START_CAPTURE_title", LocalizedStrings.Get("RECORDING_BUTTON_CONTEXT_MENU_START_CAPTURE_title"));
		StopCapture = Add("RECORDING_BUTTON_CONTEXT_MENU_STOP_CAPTURE_title", LocalizedStrings.Get("RECORDING_BUTTON_CONTEXT_MENU_STOP_CAPTURE_title"));
		CaptureSettings = Add("RECORDING_BUTTON_CONTEXT_MENU_CAPTURE_SETTINGS_title", LocalizedStrings.Get("RECORDING_BUTTON_CONTEXT_MENU_CAPTURE_SETTINGS_title"));
		EditSelectedLayout = Add("MAIN_MENU_SCREEN_EDIT_STAGE_SELECTED_LAYOUT_title", LocalizedStrings.Get("MAIN_MENU_SCREEN_EDIT_STAGE_SELECTED_LAYOUT_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.D4, (ModifierKeys)6).ToEnumerable());
	}
}
