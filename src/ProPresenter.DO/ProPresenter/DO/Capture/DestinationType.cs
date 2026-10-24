using Pro.Localization;

namespace ProPresenter.DO.Capture;

public enum DestinationType
{
	[LocalizedString("RECORDING_WINDOW_DESTINATION_DISK_title")]
	Disk,
	[LocalizedString("RECORDING_WINDOW_DESTINATION_RTMP_title")]
	RTMP,
	[LocalizedString("RECORDING_WINDOW_DESTINATION_RESI_title")]
	Resi
}
