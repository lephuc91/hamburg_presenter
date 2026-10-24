using System;
using Pro.Localization;

namespace ProPresenter.ViewModels;

[Flags]
public enum RemoveScreenButtons
{
	[LocalizedString("GLOBAL_DELETE_title")]
	DELETE = 1,
	[LocalizedString("GLOBAL_CANCEL_BUTTON_title")]
	CANCEL = 2
}
