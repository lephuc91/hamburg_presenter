using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using Pro.DO.Effects;

namespace ProPresenter.UI.Transitions.Converters;

public class AvailableDirectionConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is Direction)
		{
			Direction allowedDirection = (Direction)value;
			return (from d in Enum.GetValues<Direction>()
				where d != 0 && allowedDirection.HasFlag(d)
				select d).ToArray();
		}
		return Array.Empty<Direction>();
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
