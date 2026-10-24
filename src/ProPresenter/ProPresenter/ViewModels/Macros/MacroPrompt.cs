using Pro.Localization;
using Pro.UI.DialogService;
using ProPresenter.UI.ViewModels.Macros;

namespace ProPresenter.ViewModels.Macros;

public class MacroPrompt : IMacroPrompt
{
	public void AlertEmptyGroupName()
	{
		MessageDialogService.ShowAlert(LocalizedStrings.Get("COLLECTIONS_CREATE_NEW_COLLECTION_ERROR_EMPTY_NAME_description"));
	}
}
