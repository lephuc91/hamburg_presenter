using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public enum LogoType
{
	[OriginalName("LOGO_TYPE_NONE")]
	None,
	[OriginalName("LOGO_TYPE_PROPRESENTER")]
	Propresenter,
	[OriginalName("LOGO_TYPE_USER")]
	User
}
