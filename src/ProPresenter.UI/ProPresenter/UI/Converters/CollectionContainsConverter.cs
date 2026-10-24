using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace ProPresenter.UI.Converters;

public class CollectionContainsConverter : IMultiValueConverter
{
	public enum ConversionType
	{
		Boolean,
		Visibility
	}

	public ConversionType Type { get; set; }

	public bool IsCollapsing { get; set; } = true;

	public object Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		object obj = values[0];
		if (obj != null && values[1] is IEnumerable source)
		{
			bool flag = source.OfType<object>().Contains(obj);
			switch (Type)
			{
			case ConversionType.Boolean:
				return flag;
			case ConversionType.Visibility:
			{
				Visibility visibility = ((!flag) ? ((!IsCollapsing) ? Visibility.Hidden : Visibility.Collapsed) : Visibility.Visible);
				return visibility;
			}
			default:
				return Binding.DoNothing;
			}
		}
		return Binding.DoNothing;
	}

	public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
