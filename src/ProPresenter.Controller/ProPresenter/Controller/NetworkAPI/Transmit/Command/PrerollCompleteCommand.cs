using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.Controller.NetworkAPI.Transmit.Command;

public class PrerollCompleteCommand : INetworkCommand
{
	private int _clientId;

	private bool _failed;

	public PrerollCompleteCommand(int clientId, bool failed)
	{
		_clientId = clientId;
		_failed = failed;
	}

	public Pro.SerializationInterop.RVProtoData.NetworkAPI GetCommandProto()
	{
		return ProtoCommandExtensions.Build(delegate(Pro.SerializationInterop.RVProtoData.NetworkAPI c)
		{
			c.PrerollComplete(_clientId, _failed);
		});
	}
}
