using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

public enum ReadTokenStatus
{
	[OriginalName("ReadTokenSuccess")]
	ReadTokenSuccess,
	[OriginalName("TokenNotPresent")]
	TokenNotPresent
}
