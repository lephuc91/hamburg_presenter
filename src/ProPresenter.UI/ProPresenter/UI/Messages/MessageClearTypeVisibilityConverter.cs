using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using Pro.Common.Collections;
using Pro.DO.Token;
using ProPresenter.DO.Messages;

namespace ProPresenter.UI.Messages;

public class MessageClearTypeVisibilityConverter : IMultiValueConverter
{
	public object Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.Length == 2 && values[1] is IEnumerable<TokenBase> source && !source.Empty())
		{
			return (!source.Any((TokenBase t) => t is TimerToken)) ? Visibility.Collapsed : Visibility.Visible;
		}
		return Visibility.Collapsed;
	}

	public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
