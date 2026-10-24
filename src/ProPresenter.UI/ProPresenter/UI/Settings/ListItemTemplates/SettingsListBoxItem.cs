using System.Windows;
using Pro.UI.Controls;
using ProPresenter.UI.ViewModels.Settings;

namespace ProPresenter.UI.Settings.ListItemTemplates;

public class SettingsListBoxItem : ListBoxItem
{
	public SettingsListBoxItem()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		base.DataContextChanged += new DependencyPropertyChangedEventHandler(SettingsListBoxItem_DataContextChanged);
	}

	private void SettingsListBoxItem_DataContextChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		base.IsHitTestVisible = !(((DependencyPropertyChangedEventArgs)(ref e)).NewValue is ISettingsHeaderItemVM);
	}
}
