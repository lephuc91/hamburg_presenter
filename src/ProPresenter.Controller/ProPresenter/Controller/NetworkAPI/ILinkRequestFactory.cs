using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.Controller.NetworkAPI;

public interface ILinkRequestFactory
{
	ILinkRequest? Create(ProLink.Types.HandlerIn protoHandlerIn);
}
