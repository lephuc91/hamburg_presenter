using System;
using Pro.Localization;

namespace ProPresenter.UI.ViewModels;

[Flags]
public enum ThemeConflictButtons
{
	[LocalizedString("GLOBAL_CANCEL_BUTTON_title")]
	Cancel = 1,
	[LocalizedString("FILE_CONFLICT_NEW_VERSION_title")]
	AddNewVersion = 2,
	[LocalizedString("FILE_CONFLICT_WRITE_OVER_title")]
	WriteOver = 4
}
