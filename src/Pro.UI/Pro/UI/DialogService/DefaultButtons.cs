using System;
using Pro.Localization;

namespace Pro.UI.DialogService;

[Flags]
public enum DefaultButtons
{
	[LocalizedString("GLOBAL_YES_BUTTON_title")]
	YES = 1,
	[LocalizedString("GLOBAL_NO_BUTTON_title")]
	NO = 2,
	[LocalizedString("GLOBAL_OK_BUTTON_title")]
	OK = 4,
	[LocalizedString("GLOBAL_RETRY_BUTTON_title")]
	RETRY = 8,
	[LocalizedString("GLOBAL_CONTINUE_BUTTON_title")]
	CONTINUE = 0x10,
	[LocalizedString("GLOBAL_CANCEL_BUTTON_title")]
	CANCEL = 0x20,
	[LocalizedString("GLOBAL_QUIT")]
	QUIT = 0x40
}
