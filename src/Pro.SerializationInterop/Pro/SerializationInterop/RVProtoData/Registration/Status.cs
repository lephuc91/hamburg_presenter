using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

public enum Status
{
	[OriginalName("Success")]
	Success,
	[OriginalName("ExpiredLicense")]
	ExpiredLicense,
	[OriginalName("DeactivatedLicense")]
	DeactivatedLicense,
	[OriginalName("DisabledLicense")]
	DisabledLicense,
	[OriginalName("NoSeats")]
	NoSeats,
	[OriginalName("NoCopies")]
	NoCopies,
	[OriginalName("MissingLicense")]
	MissingLicense,
	[OriginalName("TimeDiscrepancy")]
	TimeDiscrepancy,
	[OriginalName("BibleMissing")]
	BibleMissing,
	[OriginalName("BibleNotPurchased")]
	BibleNotPurchased,
	[OriginalName("BibleActivationMissing")]
	BibleActivationMissing,
	[OriginalName("BibleDeactivated")]
	BibleDeactivated,
	[OriginalName("NetworkError")]
	NetworkError,
	[OriginalName("IOError")]
	Ioerror,
	[OriginalName("NotInitialized")]
	NotInitialized,
	[OriginalName("TokenExpired")]
	TokenExpired,
	[OriginalName("TokenInvalid")]
	TokenInvalid,
	[OriginalName("ActivationCodeExpired")]
	ActivationCodeExpired,
	[OriginalName("ActivationCodeInvalid")]
	ActivationCodeInvalid,
	[OriginalName("UnknownError")]
	UnknownError
}
