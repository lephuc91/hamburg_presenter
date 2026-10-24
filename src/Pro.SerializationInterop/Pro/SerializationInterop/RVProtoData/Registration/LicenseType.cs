using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

public enum LicenseType
{
	[OriginalName("Trial")]
	Trial,
	[OriginalName("Rental")]
	Rental,
	[OriginalName("Standard")]
	Standard,
	[OriginalName("Campus")]
	Campus
}
