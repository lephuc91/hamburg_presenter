using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public enum API_v1_TimerState
{
	[OriginalName("stopped")]
	Stopped,
	[OriginalName("running")]
	Running,
	[OriginalName("complete")]
	Complete,
	[OriginalName("overrunning")]
	Overrunning,
	[OriginalName("overran")]
	Overran
}
