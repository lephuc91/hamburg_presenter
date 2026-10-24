using System;
using Pro.Localization;

namespace ProPresenter.DO.Hotkey;

[Flags]
public enum HotkeyConflictButtons
{
	[LocalizedString("GLOBAL_CANCEL_BUTTON_title")]
	Cancel = 1,
	[LocalizedString("PRESENTATION_HOTKEY_DIALOG_CONFLICT_ALERT_REPLACE_BUTTON_title")]
	Replace = 2
}
