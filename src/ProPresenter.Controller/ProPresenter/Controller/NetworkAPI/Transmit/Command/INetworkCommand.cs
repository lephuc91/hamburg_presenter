using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.Controller.NetworkAPI.Transmit.Command;

public interface INetworkCommand
{
	Pro.SerializationInterop.RVProtoData.NetworkAPI GetCommandProto();
}
