using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using Pro.DO.Token;
using ProPresenter.DO.Messages;

namespace ProPresenter.UI.Messages;

public class TokensToNameConverter : IMultiValueConverter
{
	public object? Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.Length < 2 || !(values[0] is IEnumerable<TokenBase> source) || !(values[1] is IEnumerable<TimerToken> source2))
		{
			return null;
		}
		return source.Select((TokenBase d) => d.Content).Concat(source2.Select((TimerToken t) => t.Content));
	}

	public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
