using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.Controller.NetworkAPI.Transmit.Command;

public class HideStageMessageCommand : INetworkCommand
{
	public Pro.SerializationInterop.RVProtoData.NetworkAPI GetCommandProto()
	{
		return ProtoCommandExtensions.Build(delegate(Pro.SerializationInterop.RVProtoData.NetworkAPI c)
		{
			c.HideStageMessage();
		});
	}
}
