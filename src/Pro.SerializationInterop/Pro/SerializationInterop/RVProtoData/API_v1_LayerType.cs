using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public enum API_v1_LayerType
{
	[OriginalName("audio")]
	Audio,
	[OriginalName("props")]
	Props,
	[OriginalName("messages")]
	Messages,
	[OriginalName("announcements")]
	Announcements,
	[OriginalName("slide")]
	Slide,
	[OriginalName("media")]
	Media,
	[OriginalName("video_input")]
	VideoInput
}
