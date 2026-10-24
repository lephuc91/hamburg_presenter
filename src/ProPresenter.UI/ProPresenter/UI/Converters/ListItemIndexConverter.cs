using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Pro.UI.Utility;

namespace ProPresenter.UI.Converters;

public class ListItemIndexConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is ListBoxItem listBoxItem)
		{
			ListBox listBox = ((DependencyObject)(object)listBoxItem).FindVisualParent<ListBox>();
			if (listBox != null)
			{
				return listBox.ItemContainerGenerator.IndexFromContainer((DependencyObject)(object)listBoxItem) + 1;
			}
			return -1;
		}
		return -1;
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
