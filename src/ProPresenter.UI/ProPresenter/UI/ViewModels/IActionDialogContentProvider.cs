using Pro.DO.Triggering;
using Pro.UI.Controls;
using ProPresenter.UI.ActionPalette.ActionDialogs;

namespace ProPresenter.UI.ViewModels;

public interface IActionDialogContentProvider
{
	ActionDialogBase? GetContent(ActionType? actionType);

	IPopup CreatePopup(ActionDialogBase content);
}
