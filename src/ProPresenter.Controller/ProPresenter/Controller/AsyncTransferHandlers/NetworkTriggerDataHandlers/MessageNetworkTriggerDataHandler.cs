using Pro.SerializationInterop.RVProtoData;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Messages;

namespace ProPresenter.Controller.AsyncTransferHandlers.NetworkTriggerDataHandlers;

public class MessageNetworkTriggerDataHandler : INetworkTriggerDataHandler
{
	private readonly MessageCollection _messages;

	public MessageNetworkTriggerDataHandler(MessageCollection messages)
	{
		_messages = messages;
	}

	public NetworkTriggerDataItem? Handle(NetworkIdentifier id, ITriggerOperation op)
	{
		if (_messages == null)
		{
			return null;
		}
		return id.FindItem(_messages)?.ToAction()?.ToTriggerDataItem();
	}
}
