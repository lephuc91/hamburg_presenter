using Pro.Common.Components;
using ProPresenter.Controller.NetworkAPI.Receive;
using ProPresenter.Controller.NetworkAPI.Receive.Command;
using ProPresenter.Controller.NetworkAPI.Transmit;
using ProPresenter.DO.Settings;

namespace ProPresenter.Controller.NetworkAPI;

public class NetworkHandler : LinkedNotifyPropertyChangedBase
{
	private readonly ReceiveHandler _receiverHandler;

	private readonly TransmitHandler _transmitHandler;

	private readonly INetwork _network;

	public NetworkHandler(IReceiveService receiveService, ICommandSender commandSender, ITriggering triggering, INetworkCommandTrigger networkCommandTrigger, INetwork network)
	{
		_network = network;
		_receiverHandler = new ReceiveHandler(receiveService, new CommandHandlerFactory(triggering));
		_transmitHandler = new TransmitHandler(commandSender, networkCommandTrigger);
		LinkAction("EnableLink", OnModeChanged);
		network.PropertyChanged += base.RaiseLinkedValues;
		OnModeChanged();
	}

	private void OnModeChanged()
	{
		_receiverHandler.CanHandleCommand = _network.EnableLink;
		_transmitHandler.CanSendCommand = _network.EnableLink;
	}
}
