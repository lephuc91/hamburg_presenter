using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Pro.Common.Components;
using Pro.UI;
using Pro.UI.Controls;
using Pro.UI.Utility;
using ProPresenter.UI.ViewModels.Settings.Pages.Groups;

namespace ProPresenter.UI.Settings.PageTemplates.Groups;

public class GroupLabelDataGrid : DragDropDataGrid<IGroupLabelItemVM>
{
	protected override IDragDropCollection<IGroupLabelItemVM>? SourceCollection => base.DataContext as IDragDropCollection<IGroupLabelItemVM>;

	public GroupLabelDataGrid()
	{
		base.EnterKeySelectsNextRow = false;
		RegisterDropType();
	}

	private void RegisterDropType()
	{
		AddDropType((IEnumerable<IGroupLabelItemVM> i) => i, (IEnumerable<IGroupLabelItemVM> i, DragEventArgs e) => true, (DraggedItems<IGroupLabelItemVM> _, DragEventArgs _) => true);
	}

	protected override void OnCanExecuteDelete(CanExecuteRoutedEventArgs e)
	{
		e.CanExecute = base.DataContext is IGroupsSettingsVM groupsSettingsVM && groupsSettingsVM.RemoveGroupLabelCommand.CanExecute(null);
	}

	protected override void OnExecutedDelete(ExecutedRoutedEventArgs e)
	{
		if (base.DataContext is IGroupsSettingsVM groupsSettingsVM)
		{
			groupsSettingsVM.RemoveGroupLabelCommand?.Invoke();
		}
	}
}
