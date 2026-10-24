using Pro.SerializationInterop.RVProtoData;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Controller.NetworkAPI.Transmit.Command;

public class SkipBackwardCommand : TransportCommandBase
{
	private readonly int _seconds;

	public SkipBackwardCommand(ProLayerIndex layer, int seconds)
		: base(layer)
	{
		_seconds = seconds;
	}

	protected override void OnTransportCommand(Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport protoTransport)
	{
		protoTransport.SkipBackward = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.Types.SkipBackward
		{
			Seconds = _seconds
		};
	}
}
