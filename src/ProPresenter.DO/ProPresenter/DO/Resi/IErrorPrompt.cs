using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Resi;

public interface IErrorPrompt
{
	void ShowError(ProResiTransferType proResiTransferType);

	void ShowError(ErrorCode errorCode);

	void ResetErrorCodesShown();
}
