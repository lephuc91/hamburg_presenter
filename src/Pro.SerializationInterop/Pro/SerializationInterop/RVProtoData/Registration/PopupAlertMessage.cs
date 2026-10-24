using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

public enum PopupAlertMessage
{
	[OriginalName("NoPopupAlert")]
	NoPopupAlert,
	[OriginalName("SeatActivated")]
	SeatActivated,
	[OriginalName("NoSeatActivated")]
	NoSeatActivated,
	[OriginalName("NoLicenseActivated")]
	NoLicenseActivated,
	[OriginalName("LegacyLicenseProContentActivated")]
	LegacyLicenseProContentActivated,
	[OriginalName("FirstLaunchLegacyLicense")]
	FirstLaunchLegacyLicense,
	[OriginalName("FullySignedOut")]
	FullySignedOut,
	[OriginalName("FirstLaunchSignedInNoSubscriptionNoLicense")]
	FirstLaunchSignedInNoSubscriptionNoLicense,
	[OriginalName("FirstLaunchSignedInNoSubscriptionLegacyLicense")]
	FirstLaunchSignedInNoSubscriptionLegacyLicense
}
