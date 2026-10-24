using System;
using System.Globalization;
using System.Windows.Data;
using Pro.Common.Mathematics;

namespace ProPresenter.UI.OutputConfiguration;

public class SizeToAspectRatioConverter : IValueConverter
{
	private const double FourToThree = 1.3333333333333333;

	private const double SixteenToNine = 1.7777777777777777;

	private const double SixteenToTen = 1.6;

	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		if (value is Vector2<int> vector)
		{
			if (vector.Y == 0)
			{
				return Binding.DoNothing;
			}
			double num = (double)vector.X / (double)vector.Y;
			string arg = string.Empty;
			if (num == 1.3333333333333333)
			{
				arg = "(4:3)";
			}
			if (num == 1.7777777777777777)
			{
				arg = "(16:9)";
			}
			if (num == 1.6)
			{
				arg = "(16:10)";
			}
			return string.Format("{0} {1}", num.ToString("F2", culture), arg);
		}
		return Binding.DoNothing;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
