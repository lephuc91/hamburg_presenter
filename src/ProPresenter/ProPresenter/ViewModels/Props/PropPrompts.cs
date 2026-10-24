using System.Windows;
using Pro.Localization;
using Pro.UI.DialogService;
using ProPresenter.UI.PropGroups;
using ProPresenter.UI.ViewModels.Props;

namespace ProPresenter.ViewModels.Props;

public class PropPrompts : IPropPrompts
{
	public void AlertEmptyGroupName()
	{
		MessageDialogService.ShowAlert(LocalizedStrings.Get("COLLECTIONS_CREATE_NEW_COLLECTION_ERROR_EMPTY_NAME_description"));
	}

	public double? ShowDialogAutoClearCustomTimePrompt(double Value)
	{
		PropCustomClearTime propCustomClearTime = new PropCustomClearTime();
		propCustomClearTime.CustomTime = Value;
		if (MessageDialogService.ShowDialog(string.Empty, (DependencyObject)(object)propCustomClearTime, DefaultButtons.OK | DefaultButtons.CANCEL, DefaultButtons.OK) == DefaultButtons.OK)
		{
			return propCustomClearTime.CustomTime;
		}
		return null;
	}
}
