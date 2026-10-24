using System.Windows;
using Pro.Common.Components;
using Pro.UI;
using Pro.UI.Controls;
using ProPresenter.DO.Messages;

namespace ProPresenter.UI.Messages;

public class MessageListBox : DragDropListBox<Message>
{
	protected override IDragDropCollection<Message>? SourceCollection => base.ItemsSource as IDragDropCollection<Message>;

	public MessageListBox()
	{
		AddDropType(null, null, null, (DraggedItems<Message> _, DragEventArgs _) => true);
	}
}
