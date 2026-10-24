using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.UI;

public enum SelectionMode
{
	[OriginalName("SELECTION_MODE_UNKNOWN")]
	Unknown,
	[OriginalName("OBJECT")]
	Object,
	[OriginalName("RANGE")]
	Range
}
