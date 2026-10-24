using System;
using Pro.Localization;

namespace ProPresenter.DO.Sync.Local;

[Flags]
public enum SyncOverwriteButtons
{
	[LocalizedString("GLOBAL_CANCEL_BUTTON_title")]
	Cancel = 1,
	[LocalizedString("SYNC_PREFERENCES_SYNC_title")]
	Sync = 2
}
