using System;
using System.Globalization;
using System.Windows;

namespace Pro.UI.Converters;

public class EqualityToVisibilityConverter : ValueConverterBase<object, Visibility>
{
	public bool Invert { get; set; }

	protected override Visibility ValidationFailResult => Visibility.Collapsed;

	protected override Visibility ConvertValue(object value, Type targetType, object? parameter, CultureInfo culture)
	{
		Visibility visibility = ((!value.Equals(parameter)) ? Visibility.Collapsed : Visibility.Visible);
		if (Invert)
		{
			switch (visibility)
			{
			case Visibility.Visible:
				visibility = Visibility.Collapsed;
				break;
			case Visibility.Hidden:
			case Visibility.Collapsed:
				visibility = Visibility.Visible;
				break;
			}
		}
		return visibility;
	}
}
