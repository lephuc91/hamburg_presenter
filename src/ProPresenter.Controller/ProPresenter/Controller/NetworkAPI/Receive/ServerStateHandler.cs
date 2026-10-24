using Pro.Common.Components;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.Controller.NetworkAPI.Receive;

public class ServerStateHandler : NotifyPropertyChangedBase, IServerStateHandler
{
	public ServerState State { get; } = new ServerState();

	public void Handle(ProLink.Types.HandlerIn.Types.ServerState serverState)
	{
		State.Deserialize(serverState);
	}
}
