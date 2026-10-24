using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Controller;

public interface ITransferHandlerFactory
{
	ITransferHandler? CreateTransferHandler(ICoreManager manager, ProTriggerTransferType type);
}
