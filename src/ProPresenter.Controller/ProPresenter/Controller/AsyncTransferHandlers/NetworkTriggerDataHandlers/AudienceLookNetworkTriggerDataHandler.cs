using Pro.SerializationInterop.RVProtoData;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Looks;

namespace ProPresenter.Controller.AsyncTransferHandlers.NetworkTriggerDataHandlers;

public class AudienceLookNetworkTriggerDataHandler : INetworkTriggerDataHandler
{
	private readonly IAudienceLookCollection _looks;

	public AudienceLookNetworkTriggerDataHandler(IAudienceLookCollection looks)
	{
		_looks = looks;
	}

	public NetworkTriggerDataItem? Handle(NetworkIdentifier id, ITriggerOperation op)
	{
		if (_looks == null)
		{
			return null;
		}
		return id.FindItem(_looks).ToAction(_looks)?.ToTriggerDataItem();
	}
}
