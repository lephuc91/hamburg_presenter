using ProPresenterCore.ProCore.Interop.Triggering.Transfers;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenter.Controller;

public interface ITransferHandler
{
	void Handle(TriggerAddress address, TriggerTransfer transfer);
}
