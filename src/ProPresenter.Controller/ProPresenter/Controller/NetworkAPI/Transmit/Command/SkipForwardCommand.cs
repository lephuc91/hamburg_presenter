using Pro.SerializationInterop.RVProtoData;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Controller.NetworkAPI.Transmit.Command;

public class SkipForwardCommand : TransportCommandBase
{
	private readonly int _seconds;

	public SkipForwardCommand(ProLayerIndex layer, int seconds)
		: base(layer)
	{
		_seconds = seconds;
	}

	protected override void OnTransportCommand(Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport protoTransport)
	{
		protoTransport.SkipForward = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.Types.SkipForward
		{
			Seconds = _seconds
		};
	}
}
