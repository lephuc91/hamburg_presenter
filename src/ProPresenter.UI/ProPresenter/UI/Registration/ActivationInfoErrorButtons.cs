using System;
using Pro.Localization;

namespace ProPresenter.UI.Registration;

[Flags]
public enum ActivationInfoErrorButtons
{
	[LocalizedString("REGISTRATION_ERROR_LOAD_DATA_CONTINUE_UNREGISTERED_BUTTON_title")]
	ContinueUnregistered = 1
}
