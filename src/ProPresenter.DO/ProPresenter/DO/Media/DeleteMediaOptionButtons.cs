using System;
using Pro.Localization;

namespace ProPresenter.DO.Media;

[Flags]
public enum DeleteMediaOptionButtons
{
	[LocalizedString("GLOBAL_CANCEL_BUTTON_title")]
	Cancel = 1,
	[LocalizedString("PLAYLIST_GLOBAL_MOVE_TO_TRASH_title")]
	MoveToTrash = 2,
	[LocalizedString("PLAYLIST_GLOBAL_DELETE_CUES_title")]
	DeleteCues = 4
}
