using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Trigger.Media;

public enum CompletionTarget
{
	[OriginalName("NONE")]
	None,
	[OriginalName("NEXT")]
	Next,
	[OriginalName("RANDOM")]
	Random,
	[OriginalName("CUE")]
	Cue,
	[OriginalName("FIRST")]
	First
}
