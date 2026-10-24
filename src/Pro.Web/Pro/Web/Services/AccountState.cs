namespace Pro.Web.Services;

public enum AccountState
{
	SignedOutNoLicense,
	SignedOutLegacyLicense,
	SignedInActiveSubscription,
	SignedInInactiveSubscription,
	SignedInTrialSubscription,
	SignedInWithLegacyLicense
}
