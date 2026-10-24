using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

public enum BannerMessage
{
	[OriginalName("NoBanner")]
	NoBanner,
	[OriginalName("ActivateProPresenter")]
	ActivateProPresenter
}
