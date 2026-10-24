using System;
using Pro.Localization;

namespace ProPresenter.ViewModels.Capture;

[Flags]
public enum ConfirmStopCaptureButtons
{
	[LocalizedString("GLOBAL_CANCEL_BUTTON_title")]
	CANCEL = 1,
	[LocalizedString("RECORDING_WINDOW_STOP_CAPTURE_BUTTON_label")]
	CONTINUE = 2
}
