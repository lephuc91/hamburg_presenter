using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

public enum AlertType
{
	[OriginalName("Info")]
	Info,
	[OriginalName("Feature")]
	Feature,
	[OriginalName("Warning")]
	Warning
}
