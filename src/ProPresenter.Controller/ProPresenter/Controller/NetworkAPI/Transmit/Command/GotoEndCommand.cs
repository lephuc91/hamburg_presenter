using Pro.SerializationInterop.RVProtoData;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Controller.NetworkAPI.Transmit.Command;

public class GotoEndCommand : TransportCommandBase
{
	private readonly int _secondsToEnd;

	public GotoEndCommand(ProLayerIndex layer, int secondsToEnd)
		: base(layer)
	{
		_secondsToEnd = secondsToEnd;
	}

	protected override void OnTransportCommand(Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport protoTransport)
	{
		protoTransport.GoToEnd = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.Types.GoToEnd
		{
			SecondsToEnd = _secondsToEnd
		};
	}
}
