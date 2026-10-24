using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Logs;

public enum Field
{
	[OriginalName("ID")]
	Id,
	[OriginalName("NAME")]
	Name,
	[OriginalName("PATH")]
	Path
}
