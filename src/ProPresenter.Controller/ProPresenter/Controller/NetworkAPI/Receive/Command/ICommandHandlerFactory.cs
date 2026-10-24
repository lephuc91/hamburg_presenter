using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.Controller.NetworkAPI.Receive.Command;

public interface ICommandHandlerFactory
{
	CommandHandlerBase? Create(Pro.SerializationInterop.RVProtoData.NetworkAPI protoNetworkAPI);
}
