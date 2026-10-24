using System;
using Pro.Localization;

namespace ProPresenter.UI.Hotkeys;

[Flags]
public enum HotkeyDialogButtons
{
	[LocalizedString("GLOBAL_OK_BUTTON_title")]
	OK = 1,
	[LocalizedString("PRESENTATION_HOTKEY_DIALOG_CLEAR_BUTTON_title")]
	CLEAR = 2,
	[LocalizedString("GLOBAL_CANCEL_BUTTON_title")]
	CANCEL = 4
}
