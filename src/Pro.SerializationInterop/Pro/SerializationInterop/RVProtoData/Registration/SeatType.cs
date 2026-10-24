using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

public enum SeatType
{
	[OriginalName("Inactive")]
	Inactive,
	[OriginalName("Basic")]
	Basic,
	[OriginalName("Advanced")]
	Advanced
}
