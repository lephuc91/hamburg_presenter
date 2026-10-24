using Pro.SerializationInterop.RVProtoData;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Controller.NetworkAPI.Transmit.Command;

public class PauseCommand : TransportCommandBase
{
	public PauseCommand(ProLayerIndex layer)
		: base(layer)
	{
	}

	protected override void OnTransportCommand(Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport protoTransport)
	{
		protoTransport.Pause = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.Types.Pause();
	}
}
