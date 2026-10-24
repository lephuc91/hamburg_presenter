using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using ProPresenter.DO.Messages;

namespace ProPresenter.UI.Messages;

public class TimerControlsVisibilityConverter : IMultiValueConverter
{
	public object Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		int num;
		if (values.Length == 2)
		{
			object obj = values[0];
			TimerToken timerToken = obj as TimerToken;
			if (timerToken != null && values[1] is IEnumerable<Message> source)
			{
				num = (source.SelectMany((Message m) => m.Tokens).Any((MessageTokenBase t) => t == timerToken) ? 1 : 0);
				goto IL_0069;
			}
		}
		num = 0;
		goto IL_0069;
		IL_0069:
		return (byte)num != 0;
	}

	public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
