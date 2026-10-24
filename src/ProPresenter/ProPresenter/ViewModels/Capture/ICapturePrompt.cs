using System.Windows;
using ProPresenter.UI.ViewModels.Capture;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.ViewModels.Capture;

public interface ICapturePrompt
{
	void ShowCritical();

	DiskWarningButtons ShowLowSpace(bool isStreaming);

	void ShowStartCaptureError(ProResult result, int errorCode);

	void ShowStartCaptureActionError(int errorCode, string? presetName);

	void ShowResiStartStreamError();

	bool ShowEncoderInvalid();

	bool ShowCustomEncoderDialog(ICustomEncoderVM customEncoderVM);

	void CloseCustomEncoderDialog();

	bool ShowPresetNameDialog(ICaptureNameVM captureNameVM, bool rename = false);

	void ClosePresetNameDialog();

	void SetParentWindow(Window window);

	bool ConfirmStopCapture();

	ResiDetails GetResiEventDetails();
}
