using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Logs;

public enum ResyncCause
{
	[OriginalName("WORKSPACE")]
	Workspace,
	[OriginalName("SYNC")]
	Sync
}
