using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Logs;

public enum LogSource
{
	[OriginalName("CLIENT")]
	Client,
	[OriginalName("CORE")]
	Core
}
