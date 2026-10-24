using System.Windows;
using Pro.Common.Components;
using Pro.UI;
using Pro.UI.Controls;
using ProPresenter.DO.Looks;
using ProPresenter.UI.ViewModels.LooksDialog;

namespace ProPresenter.UI.Looks;

public class LookListBox : DragDropListBox<AudienceLookVM>
{
	protected override IDragDropCollection<AudienceLookVM>? SourceCollection => base.ItemsSource as IDragDropCollection<AudienceLookVM>;

	public LookListBox()
	{
		AddDropType(null, null, null, (DraggedItems<AudienceLook> _, DragEventArgs _) => true);
	}
}
