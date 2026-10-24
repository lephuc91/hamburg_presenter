using System;
using System.Globalization;
using System.Windows.Data;

namespace ProPresenter.UI.CueInspector;

public class SelectedMediaCheckedConverter : IMultiValueConverter
{
	public object Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		return values.Length == 2 && object.Equals(values[0], values[1]);
	}

	public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
