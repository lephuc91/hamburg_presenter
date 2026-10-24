using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using Pro.UI.Converters;

namespace ProPresenter.UI.Converters;

public class IsLastItemToVisibilityConverter : MultiValueConverterBase<Visibility>
{
	protected override Visibility ConvertValues(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		object item = values[0];
		List<object> list = (values[1] as IEnumerable)?.Cast<object>().ToList() ?? new List<object>();
		if (list.IndexOf(item) != list.Count - 1)
		{
			return Visibility.Visible;
		}
		return Visibility.Collapsed;
	}

	protected override bool ValidateValues(object?[] values)
	{
		if (values == null || values.Length != 2)
		{
			return false;
		}
		if (values[0] != null)
		{
			return values[1] is IEnumerable;
		}
		return false;
	}
}
