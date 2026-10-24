using ProPresenter.Controller.Triggering;
using ProPresenterCore.ProCore.Interop.Triggering.AsyncTransfers;

namespace ProPresenter.Controller.AsyncTransferHandlers;

public interface INetworkTriggerDataTransferFactory
{
	void Handle(ICoreManager manager, NetworkTriggerDataTransfer networkTriggerDataTransfer, ITriggerOperation op);
}
