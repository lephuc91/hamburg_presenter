using Pro.SerializationInterop.RVProtoData;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO.Actions;
using ProPresenter.DO.ClearGroups;

namespace ProPresenter.Controller.AsyncTransferHandlers.NetworkTriggerDataHandlers;

public class ClearGroupNetworkTriggerDataHandler : INetworkTriggerDataHandler
{
	private readonly ClearGroupCollection _clearGroups;

	public ClearGroupNetworkTriggerDataHandler(ClearGroupCollection clearGroups)
	{
		_clearGroups = clearGroups;
	}

	public NetworkTriggerDataItem? Handle(NetworkIdentifier id, ITriggerOperation op)
	{
		if (_clearGroups == null)
		{
			return null;
		}
		return id.FindItem(_clearGroups).ToAction()?.ToTriggerDataItem();
	}
}
