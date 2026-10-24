using System;
using Pro.Localization;

namespace ProPresenter.Updates;

[Flags]
public enum ProductionRestoreButtons
{
	[LocalizedString("UPDATE_CHANNEL_DIALOG_SWITCH_CHANNEL_CONTINUE_BETA_title")]
	ContinueBeta = 1,
	[LocalizedString("UPDATE_CHANNEL_DIALOG_SWITCH_CHANNEL_INSTALL_PREVIOUS_VERSION_title")]
	DownloadPreviosVersion = 2
}
