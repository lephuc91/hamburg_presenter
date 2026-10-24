using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.UI;

public enum Location
{
	[OriginalName("LOCATION_UNKNOWN")]
	Unknown,
	[OriginalName("PRESENTATION")]
	Presentation,
	[OriginalName("BIBLE_MODULE")]
	BibleModule
}
