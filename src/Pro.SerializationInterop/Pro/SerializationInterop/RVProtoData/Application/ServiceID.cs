using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Application;

public enum ServiceID
{
	[OriginalName("APPLICATION")]
	Application,
	[OriginalName("MEDIA")]
	Media,
	[OriginalName("FEATURE_FLAGS")]
	FeatureFlags,
	[OriginalName("REGISTRATION")]
	Registration,
	[OriginalName("DOCUMENT")]
	Document,
	[OriginalName("WORKSPACE")]
	Workspace
}
