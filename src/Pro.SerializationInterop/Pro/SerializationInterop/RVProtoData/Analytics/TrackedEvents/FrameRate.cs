using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

public enum FrameRate
{
	[OriginalName("UNSPECIFIED")]
	Unspecified,
	[OriginalName("_24FPS")]
	_24Fps,
	[OriginalName("_25FPS")]
	_25Fps,
	[OriginalName("_2997FPS")]
	_2997Fps,
	[OriginalName("_30FPS")]
	_30Fps,
	[OriginalName("_50FPS")]
	_50Fps,
	[OriginalName("_5994FPS")]
	_5994Fps,
	[OriginalName("_60FPS")]
	_60Fps
}
