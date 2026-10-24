using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public enum API_v1_CaptureStatus
{
	[OriginalName("active")]
	Active,
	[OriginalName("inactive")]
	Inactive,
	[OriginalName("caution")]
	Caution,
	[OriginalName("error")]
	Error
}
