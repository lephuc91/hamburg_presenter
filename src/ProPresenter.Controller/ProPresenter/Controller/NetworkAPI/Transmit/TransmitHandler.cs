using Pro.SerializationInterop.RVProtoData;
using ProPresenter.Controller.NetworkAPI.Transmit.Command;

namespace ProPresenter.Controller.NetworkAPI.Transmit;

public class TransmitHandler
{
	private readonly ICommandSender _commandSender;

	private readonly INetworkCommandTrigger _networkCommandTrigger;

	internal bool CanSendCommand { get; set; } = true;

	public TransmitHandler(ICommandSender commandSender, INetworkCommandTrigger networkCommandTrigger)
	{
		_commandSender = commandSender;
		_networkCommandTrigger = networkCommandTrigger;
		_networkCommandTrigger.TriggerCommand += NetworkCommandTrigger_TriggerCommand;
	}

	private void NetworkCommandTrigger_TriggerCommand(INetworkCommand command)
	{
		OnSendCommand(command?.GetCommandProto());
	}

	private void OnSendCommand(Pro.SerializationInterop.RVProtoData.NetworkAPI? command)
	{
		if (CanSendCommand)
		{
			_commandSender.SendCommand(command);
		}
	}
}
