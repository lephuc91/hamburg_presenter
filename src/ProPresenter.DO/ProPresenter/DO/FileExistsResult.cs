using System;
using Pro.Localization;

namespace ProPresenter.DO;

[Flags]
public enum FileExistsResult
{
	[LocalizedString("FILE_CONFLICT_USE_EXISTING_title")]
	UseExisting = 1,
	[LocalizedString("FILE_CONFLICT_SKIP_title")]
	Skip = 2,
	[LocalizedString("FILE_CONFLICT_NEW_VERSION_title")]
	AddNewVersion = 4,
	[LocalizedString("FILE_CONFLICT_WRITE_OVER_title")]
	WriteOver = 8,
	[LocalizedString("GLOBAL_CANCEL_BUTTON_title")]
	Cancel = 0x10
}
