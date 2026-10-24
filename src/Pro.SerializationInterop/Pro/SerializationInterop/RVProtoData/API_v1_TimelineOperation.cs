using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public enum API_v1_TimelineOperation
{
	[OriginalName("play")]
	Play,
	[OriginalName("pause")]
	Pause,
	[OriginalName("rewind")]
	Rewind
}
