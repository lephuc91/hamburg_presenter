using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Application;

public enum ErrorCode
{
	[OriginalName("RUNTIME")]
	Runtime,
	[OriginalName("CALL")]
	Call,
	[OriginalName("PARAMS")]
	Params,
	[OriginalName("DATA")]
	Data,
	[OriginalName("PANIC")]
	Panic,
	[OriginalName("JOIN")]
	Join,
	[OriginalName("HID")]
	Hid,
	[OriginalName("REMOTE")]
	Remote,
	[OriginalName("DEPENDENCY")]
	Dependency,
	[OriginalName("MEDIA_VERSION")]
	MediaVersion
}
