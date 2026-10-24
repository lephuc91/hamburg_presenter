using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public enum API_v1_TimerOperation
{
	[OriginalName("start")]
	Start,
	[OriginalName("stop")]
	Stop,
	[OriginalName("reset")]
	Reset
}
