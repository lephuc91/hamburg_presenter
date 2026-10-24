using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Trigger.Media;

public enum SourceType
{
	[OriginalName("LOCAL")]
	Local,
	[OriginalName("PROCONTENT")]
	Procontent
}
