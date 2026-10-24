using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

public enum UpdateChannel
{
	[OriginalName("Beta")]
	Beta,
	[OriginalName("Production")]
	Production
}
