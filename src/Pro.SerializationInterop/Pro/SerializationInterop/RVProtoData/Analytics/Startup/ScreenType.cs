using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Startup;

public enum ScreenType
{
	[OriginalName("SCREEN_TYPE_UNKNOWN")]
	Unknown,
	[OriginalName("AUDIENCE")]
	Audience,
	[OriginalName("STAGE")]
	Stage
}
