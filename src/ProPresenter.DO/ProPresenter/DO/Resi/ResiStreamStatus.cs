using Pro.Localization;

namespace ProPresenter.DO.Resi;

public enum ResiStreamStatus
{
	[LocalizedString("RESI_STREAM_STATUS_UNKNOWN_ERROR_title")]
	Unknown,
	[LocalizedString("RESI_STREAM_STATUS_STARTING_title")]
	Starting,
	[LocalizedString("RESI_STREAM_STATUS_START_CHECK_title")]
	StartCheck,
	[LocalizedString("RESI_STREAM_STATUS_STARTED_title")]
	Started,
	[LocalizedString("RESI_STREAM_STATUS_START_ERROR_title")]
	StartError,
	[LocalizedString("RESI_STREAM_STATUS_STOPPING_title")]
	Stopping,
	[LocalizedString("RESI_STREAM_STATUS_STOP_CHECK_title")]
	StopCheck,
	[LocalizedString("RESI_STREAM_STATUS_STOPPED_title")]
	Stopped,
	[LocalizedString("RESI_STREAM_STATUS_STOP_ERROR_title")]
	StopError
}
