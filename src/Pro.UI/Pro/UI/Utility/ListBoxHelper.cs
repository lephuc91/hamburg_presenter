using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Pro.UI.Utility;

public static class ListBoxHelper
{
	private const string FocusSelectedItem = "FocusSelectedItem";

	public static readonly DependencyProperty FocusSelectedItemProperty = DependencyProperty.RegisterAttached("FocusSelectedItem", typeof(bool), typeof(ListBoxHelper), new PropertyMetadata((object)false, new PropertyChangedCallback(FocusSelectedItemChanged)));

	private static void FocusSelectedItemChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		ListBox listBox = (ListBox)(object)callerObject;
		object newValue = ((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		OnFocusSelectedItemChanged(listBox, newValue is bool && (bool)newValue);
	}

	public static bool GetFocusSelectedItem(ListBox element)
	{
		return (bool)((DependencyObject)element).GetValue(FocusSelectedItemProperty);
	}

	public static void SetFocusSelectedItem(ListBox element, bool value)
	{
		((DependencyObject)element).SetValue(FocusSelectedItemProperty, (object)value);
	}

	private static void OnFocusSelectedItemChanged(ListBox listBox, bool focusSelectedItem)
	{
		if (focusSelectedItem)
		{
			listBox.SelectionChanged += OnListBoxSelectionChanged;
		}
		else
		{
			listBox.SelectionChanged -= OnListBoxSelectionChanged;
		}
	}

	private static void OnListBoxSelectionChanged(object? sender, SelectionChangedEventArgs e)
	{
		object obj = e.AddedItems?.Cast<object>().FirstOrDefault();
		if (obj != null && sender is ListBox listBox)
		{
			(listBox.ItemContainerGenerator.ContainerFromItem(obj) as UIElement)?.Focus();
		}
	}
}
