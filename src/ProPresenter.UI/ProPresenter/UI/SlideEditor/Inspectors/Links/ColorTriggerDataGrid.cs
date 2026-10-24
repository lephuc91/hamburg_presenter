using System.Collections.Generic;
using System.Windows;
using Pro.Common.Components;
using Pro.UI;
using Pro.UI.Controls;
using ProPresenter.UI.ViewModels.Editor.Links;

namespace ProPresenter.UI.SlideEditor.Inspectors.Links;

public class ColorTriggerDataGrid : DragDropDataGrid<IColorTriggerItemVM>
{
	protected override IDragDropCollection<IColorTriggerItemVM>? SourceCollection => base.DataContext as IDragDropCollection<IColorTriggerItemVM>;

	public ColorTriggerDataGrid()
	{
		base.EnterKeySelectsNextRow = false;
		RegisterDropType();
	}

	private void RegisterDropType()
	{
		AddDropType((IEnumerable<IColorTriggerItemVM> c) => c, (IEnumerable<IColorTriggerItemVM> i, DragEventArgs e) => true, (DraggedItems<IColorTriggerItemVM> c, DragEventArgs e) => true);
	}
}
