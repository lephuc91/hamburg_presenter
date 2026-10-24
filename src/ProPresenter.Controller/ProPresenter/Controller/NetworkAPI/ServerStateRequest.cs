using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.Controller.NetworkAPI;

public class ServerStateRequest : ILinkRequest
{
	public ProLink.Types.HandlerIn.Types.ServerState ServerState { get; }

	public ServerStateRequest(ProLink.Types.HandlerIn.Types.ServerState serverState)
	{
		ServerState = serverState;
	}
}
