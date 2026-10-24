using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.Controller.NetworkAPI.Receive;

public interface IServerStateHandler
{
	ServerState State { get; }

	void Handle(ProLink.Types.HandlerIn.Types.ServerState serverState);
}
