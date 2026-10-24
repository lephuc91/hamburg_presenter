using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Logs;

public enum DiffApplicationResult
{
	[OriginalName("SUCCESS")]
	Success,
	[OriginalName("FAILURE")]
	Failure,
	[OriginalName("AWAITING_OTHER_CHANGES")]
	AwaitingOtherChanges
}
