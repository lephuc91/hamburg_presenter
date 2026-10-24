using System;
using Pro.Localization;

namespace ProPresenter.ViewModels.Capture;

[Flags]
public enum EncoderInvalidButtons
{
	[LocalizedString("GLOBAL_CANCEL_BUTTON_title")]
	CANCEL = 1,
	[LocalizedString("RECORDING_ENCODER_VALIDATION_FAILED_ALERT_CONTINUE_BUTTON_title")]
	CONTINUE = 2
}
