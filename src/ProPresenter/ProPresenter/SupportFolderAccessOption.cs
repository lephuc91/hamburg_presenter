using System;
using Pro.Localization;

namespace ProPresenter;

[Flags]
public enum SupportFolderAccessOption
{
	[LocalizedString("FOLDER_PERMISSION_FALLBACK_DEFAULT_BUTTON_title")]
	Default = 1,
	[LocalizedString("GLOBAL_OK_BUTTON_title")]
	Quit = 2
}
