using Pro.Localization;

namespace ProPresenter.DO.Resi;

public enum UploadHealth
{
	[LocalizedString("RESI_STREAM_UPLOAD_HEALTH_UNKNOWN_title")]
	Unknown,
	[LocalizedString("RESI_STREAM_UPLOAD_HEALTH_HEALTHY_title")]
	Healthy,
	[LocalizedString("RESI_STREAM_UPLOAD_HEALTH_WARNING_title")]
	Warning,
	[LocalizedString("RESI_STREAM_UPLOAD_HEALTH_ERROR_title")]
	Error
}
