using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace ProPresenter.UI.SlideEditor.Converters;

public class StartNumberToBuildIndexConverter : IMultiValueConverter
{
	public object Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		return (values.Cast<int>().Sum() + 1).ToString();
	}

	public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
