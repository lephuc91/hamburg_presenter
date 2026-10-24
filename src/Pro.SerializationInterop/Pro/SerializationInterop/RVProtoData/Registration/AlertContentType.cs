using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

public enum AlertContentType
{
	[OriginalName("ContentType")]
	ContentType,
	[OriginalName("Text")]
	Text,
	[OriginalName("InternalLink")]
	InternalLink,
	[OriginalName("ExternalLink")]
	ExternalLink
}
