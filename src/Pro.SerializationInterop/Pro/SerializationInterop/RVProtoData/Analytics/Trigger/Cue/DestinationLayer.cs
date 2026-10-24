using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Trigger.Cue;

public enum DestinationLayer
{
	[OriginalName("DESTINATION_LAYER_UNKNOWN")]
	Unknown,
	[OriginalName("ANNOUNCEMENT")]
	Announcement,
	[OriginalName("PRESENTATION")]
	Presentation,
	[OriginalName("STAGE")]
	Stage,
	[OriginalName("PROPS")]
	Props,
	[OriginalName("MESSAGES")]
	Messages,
	[OriginalName("MASK")]
	Mask
}
