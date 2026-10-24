using System;
using Pro.Localization;

namespace ProPresenter.ViewModels.Settings.Pages.Media;

[Flags]
public enum MediaCleanupButtons
{
	[LocalizedString("GLOBAL_CANCEL_BUTTON_title")]
	Cancel = 1,
	[LocalizedString("SETTINGS_MEDIA_CLEANUP_MOVE_TO_TRASH_BUTTON_title")]
	MoveToTrash = 2,
	[LocalizedString("SETTINGS_MEDIA_CLEANUP_MOVE_TO_FOLDER_BUTTON_title")]
	MoveToFolder = 4
}
