using Pro.Localization;

namespace ProPresenter.DO.Resi;

public enum AccountStatus
{
	[LocalizedString("RESI_PREFERENCES_ACCOUNT_STATUS_ACTIVE_title")]
	Active,
	[LocalizedString("RESI_PREFERENCES_ACCOUNT_STATUS_INACTIVE_title")]
	Inactive,
	[LocalizedString("RESI_PREFERENCES_ACCOUNT_STATUS_INVALID_title")]
	Invalid,
	[LocalizedString("RESI_PREFERENCES_ACCOUNT_STATUS_UNKNOWN_title")]
	Unknown
}
