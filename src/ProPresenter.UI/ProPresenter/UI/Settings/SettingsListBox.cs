using System.Windows.Input;
using Pro.UI.Controls;
using ProPresenter.UI.Settings.ListItemTemplates;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings;

namespace ProPresenter.UI.Settings;

public class SettingsListBox : ListBoxBase<ISettingsListItem, SettingsListBoxItem>
{
	protected override bool CanSelect(ISettingsListItem item, MouseButtonEventArgs? e)
	{
		if (!(item is ISettingsHeaderItemVM))
		{
			return base.CanSelect(item, e);
		}
		return false;
	}

	protected override void OnUpdateSelection(ISettingsListItem item)
	{
		if (base.ActiveItem is INavigationItem navigationItem && navigationItem != item && !navigationItem.CanExit)
		{
			navigationItem.PromptUnableToExit();
		}
		else
		{
			base.OnUpdateSelection(item);
		}
	}
}
