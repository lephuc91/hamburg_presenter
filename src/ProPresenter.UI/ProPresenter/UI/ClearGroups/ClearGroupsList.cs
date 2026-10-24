using System.Windows;
using System.Windows.Input;
using Pro.Common.Components;
using Pro.UI;
using Pro.UI.Controls;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.UI.ClearGroups;

public class ClearGroupsList : DragDropListBox<IClearGroupItemVM>
{
	protected override IDragDropCollection<IClearGroupItemVM>? SourceCollection => base.ItemsSource as IDragDropCollection<IClearGroupItemVM>;

	public ClearGroupsList()
	{
		AddDropType(null, null, null, (DraggedItems<IClearGroupItemVM> s, DragEventArgs e) => true);
	}

	protected override bool ShouldDeselectOnMouseUp(MouseButtonEventArgs e)
	{
		return false;
	}
}
