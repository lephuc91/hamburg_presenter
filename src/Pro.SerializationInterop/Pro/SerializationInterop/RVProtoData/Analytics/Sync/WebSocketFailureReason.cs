using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Sync;

public enum WebSocketFailureReason
{
	[OriginalName("UNKNOWN")]
	Unknown,
	[OriginalName("AUTHENTICATION")]
	Authentication,
	[OriginalName("TIMEOUT")]
	Timeout,
	[OriginalName("NO_INTERNET")]
	NoInternet,
	[OriginalName("SERVER_ERROR")]
	ServerError
}
