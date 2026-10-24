using System;
using System.Globalization;
using System.Windows.Data;

namespace ProPresenter.UI.CueInspector;

public class IndexToBoolConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		int result;
		return value is int num && int.TryParse(parameter as string, out result) && num == result;
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		bool flag = default(bool);
		int num;
		int result = default(int);
		if (value is bool)
		{
			flag = (bool)value;
			num = (int.TryParse(parameter as string, out result) ? 1 : 0);
		}
		else
		{
			num = 0;
		}
		if (((uint)num & (flag ? 1u : 0u)) == 0)
		{
			return Binding.DoNothing;
		}
		return result;
	}
}
