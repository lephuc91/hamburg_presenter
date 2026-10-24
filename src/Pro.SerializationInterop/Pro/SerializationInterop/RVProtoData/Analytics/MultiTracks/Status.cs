using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.MultiTracks;

public enum Status
{
	[OriginalName("DISABLED")]
	Disabled,
	[OriginalName("CANCELLED")]
	Cancelled,
	[OriginalName("ACTIVE")]
	Active
}
