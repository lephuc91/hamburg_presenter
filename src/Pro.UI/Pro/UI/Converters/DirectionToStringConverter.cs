using System;
using System.Globalization;
using System.Windows.Data;
using Pro.DO.Effects;
using Pro.Localization;

namespace Pro.UI.Converters;

public abstract class DirectionToStringConverter : IValueConverter
{
	protected abstract string KeyForValue(Direction direction);

	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is Direction direction)
		{
			return LocalizedStrings.Get(KeyForValue(direction));
		}
		return Binding.DoNothing;
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
