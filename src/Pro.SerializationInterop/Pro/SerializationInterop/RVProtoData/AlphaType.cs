using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public enum AlphaType
{
	[OriginalName("ALPHA_TYPE_UNKNOWN")]
	Unknown,
	[OriginalName("ALPHA_TYPE_STRAIGHT")]
	Straight,
	[OriginalName("ALPHA_TYPE_PREMULTIPLIED")]
	Premultiplied
}
