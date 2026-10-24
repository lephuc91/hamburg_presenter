using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Logging;

public enum LogLevel
{
	[OriginalName("LevelTrace")]
	LevelTrace,
	[OriginalName("LevelDebug")]
	LevelDebug,
	[OriginalName("LevelInfo")]
	LevelInfo,
	[OriginalName("LevelWarn")]
	LevelWarn,
	[OriginalName("LevelError")]
	LevelError
}
