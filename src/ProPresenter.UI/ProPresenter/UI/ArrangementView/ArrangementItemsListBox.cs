using System.Windows;
using Pro.Common.Components;
using Pro.UI;
using Pro.UI.Controls;
using ProPresenter.DO.Arrangements;

namespace ProPresenter.UI.ArrangementView;

public class ArrangementItemsListBox : DragDropListBox<IArrangement>
{
	protected override IDragDropCollection<IArrangement>? SourceCollection => base.DataContext as IDragDropCollection<IArrangement>;

	public ArrangementItemsListBox()
	{
		AddDropType(null, null, null, (DraggedItems<IArrangement> _, DragEventArgs _) => true);
	}
}
