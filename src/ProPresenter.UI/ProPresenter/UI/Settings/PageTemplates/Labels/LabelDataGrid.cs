using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Pro.Common.Components;
using Pro.UI;
using Pro.UI.Controls;
using Pro.UI.Utility;
using ProPresenter.UI.ViewModels.Settings.Pages.Labels;

namespace ProPresenter.UI.Settings.PageTemplates.Labels;

public class LabelDataGrid : DragDropDataGrid<ILabelItemVM>
{
	protected override IDragDropCollection<ILabelItemVM>? SourceCollection => base.DataContext as IDragDropCollection<ILabelItemVM>;

	public LabelDataGrid()
	{
		base.EnterKeySelectsNextRow = false;
		RegisterDropType();
	}

	private void RegisterDropType()
	{
		AddDropType((IEnumerable<ILabelItemVM> i) => i, (IEnumerable<ILabelItemVM> i, DragEventArgs e) => true, (DraggedItems<ILabelItemVM> _, DragEventArgs _) => true);
	}

	protected override void OnCanExecuteDelete(CanExecuteRoutedEventArgs e)
	{
		e.CanExecute = base.DataContext is ILabelsSettingsVM labelsSettingsVM && labelsSettingsVM.RemoveLabelCommand.CanExecute(null);
	}

	protected override void OnExecutedDelete(ExecutedRoutedEventArgs e)
	{
		if (base.DataContext is ILabelsSettingsVM labelsSettingsVM)
		{
			labelsSettingsVM.RemoveLabelCommand?.Invoke();
		}
	}
}
