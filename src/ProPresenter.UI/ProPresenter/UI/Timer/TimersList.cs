using System.Windows;
using Pro.Common.Components;
using Pro.UI;
using Pro.UI.Controls;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.UI.Timer;

public class TimersList : DragDropItemsControl<ITimerVM, TimerTemplate>
{
	protected override IDragDropCollection<ITimerVM>? SourceCollection => base.ItemsSource as IDragDropCollection<ITimerVM>;

	public TimersList()
	{
		AddDropType(null, null, null, (DraggedItems<ITimerVM> _, DragEventArgs _) => true);
	}
}
