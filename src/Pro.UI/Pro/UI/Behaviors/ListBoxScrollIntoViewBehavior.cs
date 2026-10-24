using System;
using System.Windows.Controls;
using System.Windows.Threading;
using Microsoft.Xaml.Behaviors;

namespace Pro.UI.Behaviors;

public class ListBoxScrollIntoViewBehavior : Behavior<ListBox>
{
	protected override void OnAttached()
	{
		base.OnAttached();
		base.AssociatedObject.SelectionChanged += AssociatedObject_SelectionChanged;
	}

	private static void AssociatedObject_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		ListBox listBox = sender as ListBox;
		if (listBox == null || listBox.SelectedItem == null)
		{
			return;
		}
		((DispatcherObject)listBox).Dispatcher.BeginInvoke((Delegate)(Action)delegate
		{
			listBox.UpdateLayout();
			if (listBox.SelectedItem != null)
			{
				listBox.ScrollIntoView(listBox.SelectedItem);
			}
		}, Array.Empty<object>());
	}

	protected override void OnDetaching()
	{
		base.OnDetaching();
		base.AssociatedObject.SelectionChanged -= AssociatedObject_SelectionChanged;
	}
}
