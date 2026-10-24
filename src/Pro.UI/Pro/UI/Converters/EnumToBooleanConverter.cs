using System;
using System.Globalization;
using System.Windows.Data;

namespace Pro.UI.Converters;

public class EnumToBooleanConverter : IValueConverter
{
	public object FalseValue { get; set; } = Binding.DoNothing;

	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return object.Equals(value, parameter);
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		if (!value.Equals(true))
		{
			return FalseValue;
		}
		return parameter;
	}
}
