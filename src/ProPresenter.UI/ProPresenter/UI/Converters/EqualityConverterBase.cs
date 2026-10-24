using System;
using System.Globalization;
using System.Windows.Data;
using Pro.Common.Operations;

namespace ProPresenter.UI.Converters;

public class EqualityConverterBase<T> : IMultiValueConverter where T : class
{
	public bool IsInverted { get; set; }

	public object? Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.Length < 2)
		{
			throw new ArgumentException("EqualityConverterBase requires at least two values to compare.");
		}
		if (values[0] is T lhs && values[1] is T rhs)
		{
			return IsInverted ? (!lhs.Equal(rhs)) : lhs.Equal(rhs);
		}
		return IsInverted ? (values[0] != values[1]) : (values[0] == values[1]);
	}

	public object?[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
