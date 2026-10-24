using System;
using Pro.Localization;

namespace ProPresenter.UI.PresentationView.GoToNext;

[Flags]
public enum GTNTDialogButtons
{
	[LocalizedString("GLOBAL_REMOVE_title")]
	REMOVE = 1,
	[LocalizedString("GLOBAL_DONE")]
	DONE = 2,
	[LocalizedString("GLOBAL_CANCEL_BUTTON_title")]
	CANCEL = 4
}
