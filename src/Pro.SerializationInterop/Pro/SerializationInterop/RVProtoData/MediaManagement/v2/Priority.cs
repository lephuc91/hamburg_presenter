using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.MediaManagement.v2;

public enum Priority
{
	[OriginalName("Background")]
	Background,
	[OriginalName("UserInitiated")]
	UserInitiated
}
