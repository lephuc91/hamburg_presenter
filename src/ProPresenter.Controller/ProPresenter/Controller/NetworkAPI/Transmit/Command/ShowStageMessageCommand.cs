using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.Controller.NetworkAPI.Transmit.Command;

public class ShowStageMessageCommand : INetworkCommand
{
	private readonly string _message;

	public ShowStageMessageCommand(string message)
	{
		_message = message;
	}

	public Pro.SerializationInterop.RVProtoData.NetworkAPI GetCommandProto()
	{
		return ProtoCommandExtensions.Build(delegate(Pro.SerializationInterop.RVProtoData.NetworkAPI c)
		{
			c.ShowStageMessage(_message);
		});
	}
}
