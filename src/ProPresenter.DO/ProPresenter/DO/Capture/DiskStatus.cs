using Pro.Localization;

namespace ProPresenter.DO.Capture;

public enum DiskStatus
{
	OK,
	[LocalizedString("RECORDING_DISK_SPACE_STATUS_LOW_title")]
	Low,
	[LocalizedString("RECORDING_DISK_SPACE_STATUS_CRITICAL_title")]
	Critical
}
