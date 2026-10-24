using System;
using System.Globalization;
using System.Windows.Data;
using Pro.Localization;

namespace Pro.UI.Converters;

public class FormattedLocalizedStringMultiConverter : IMultiValueConverter
{
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
	{
		return LocalizedStrings.Get((parameter as string) ?? throw new NotSupportedException(), values);
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
