using Pro.SerializationInterop.RVProtoData;
using ProPresenter.Controller.NetworkAPI.Receive.Command;

namespace ProPresenter.Controller.NetworkAPI.Receive;

public class ReceiveHandler
{
	private readonly ICommandHandlerFactory _commandHandlerFactory;

	internal bool CanHandleCommand { get; set; } = true;

	public ReceiveHandler(IReceiveService clientService, ICommandHandlerFactory commandHandlerFactory)
	{
		_commandHandlerFactory = commandHandlerFactory;
		clientService.CommandReceived += HandleCommand;
	}

	private void HandleCommand(Pro.SerializationInterop.RVProtoData.NetworkAPI protoNetworkCommand)
	{
		if (protoNetworkCommand.CommandCase == Pro.SerializationInterop.RVProtoData.NetworkAPI.CommandOneofCase.Action && CanHandleCommand)
		{
			_commandHandlerFactory.Create(protoNetworkCommand)?.Handle(protoNetworkCommand.Action);
		}
	}
}
