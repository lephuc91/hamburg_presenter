using System;
using Pro.Localization;

namespace ProPresenter.ViewModels.Capture;

[Flags]
public enum DiskWarningButtons
{
	[LocalizedString("RECORDING_DISK_SPACE_LOW_ALERT_CONTINUE_BUTTON_title")]
	Continue = 1,
	[LocalizedString("RECORDING_DISK_SPACE_LOW_ALERT_STOP_BUTTON_title")]
	Stop = 2,
	[LocalizedString("RECORDING_DISK_SPACE_LOW_ALERT_STOP_BACKUP_BUTTON_title")]
	StopBackupOnly = 4
}
