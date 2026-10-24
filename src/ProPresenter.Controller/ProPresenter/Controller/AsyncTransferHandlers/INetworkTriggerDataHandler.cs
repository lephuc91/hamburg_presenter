using Pro.SerializationInterop.RVProtoData;
using ProPresenter.Controller.Triggering;

namespace ProPresenter.Controller.AsyncTransferHandlers;

public interface INetworkTriggerDataHandler
{
	NetworkTriggerDataItem? Handle(NetworkIdentifier id, ITriggerOperation op);
}
