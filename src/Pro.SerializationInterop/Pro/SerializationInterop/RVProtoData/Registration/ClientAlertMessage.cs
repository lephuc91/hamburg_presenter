using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

public enum ClientAlertMessage
{
	[OriginalName("NoAlert")]
	NoAlert,
	[OriginalName("ExpiredLicenseLegacy")]
	ExpiredLicenseLegacy,
	[OriginalName("ExpiredSubscription")]
	ExpiredSubscription,
	[OriginalName("InvalidLicense")]
	InvalidLicense,
	[OriginalName("NoSeatsLegacy")]
	NoSeatsLegacy,
	[OriginalName("NoSeatsSubscription")]
	NoSeatsSubscription,
	[OriginalName("SeatDeactivatedSubscription")]
	SeatDeactivatedSubscription,
	[OriginalName("TimeDiscrepancyAlert")]
	TimeDiscrepancyAlert,
	[OriginalName("NoNetwork")]
	NoNetwork,
	[OriginalName("NoBibleCopies")]
	NoBibleCopies,
	[OriginalName("BibleMissingAlert")]
	BibleMissingAlert,
	[OriginalName("BibleNotPurchasedLegacy")]
	BibleNotPurchasedLegacy,
	[OriginalName("BibleNotPurchasedSubscription")]
	BibleNotPurchasedSubscription,
	[OriginalName("UnsuccessfulBibleActivationLegacy")]
	UnsuccessfulBibleActivationLegacy,
	[OriginalName("UnsuccessfulBibleActivationSubscription")]
	UnsuccessfulBibleActivationSubscription,
	[OriginalName("IOErrorAlert")]
	IoerrorAlert,
	[OriginalName("CodeExpiredAlert")]
	CodeExpiredAlert,
	[OriginalName("CodeInvalidAlert")]
	CodeInvalidAlert,
	[OriginalName("UnsuccessfulActivation")]
	UnsuccessfulActivation,
	[OriginalName("DeviceSignedOutSubscription")]
	DeviceSignedOutSubscription,
	[OriginalName("UnknownAlert")]
	UnknownAlert
}
