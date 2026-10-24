using System;
using Pro.Localization;

namespace ProPresenter.DO.OutputConfiguration;

[Flags]
public enum AssignOutputButtons
{
	[LocalizedString("GLOBAL_CANCEL_BUTTON_title")]
	Cancel = 1,
	[LocalizedString("SCREEN_CONFIGURATION_CONFLICT_ALERT_ASSIGN_TO_ALL_title")]
	AssignToAll = 2,
	[LocalizedString("SCREEN_CONFIGURATION_CONFLICT_ALERT_REASSIGN_TO_NEW_title")]
	ReassignToNew = 4
}
