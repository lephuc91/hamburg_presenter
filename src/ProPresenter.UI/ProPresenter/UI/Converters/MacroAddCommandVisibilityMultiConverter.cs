using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using Pro.Common.Collections;
using Pro.UI.Converters;
using ProPresenter.UI.ViewModels.Macros;

namespace ProPresenter.UI.Converters;

public class MacroAddCommandVisibilityMultiConverter : MultiValueConverterBase<Visibility>
{
	protected override Visibility ConvertValues(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.Length >= 2 && values[0] is IDragDropNotifyEnumerableChanged<IMacroItemVM> source)
		{
			string value = (values[1] as string) ?? string.Empty;
			if (!source.Any() && string.IsNullOrEmpty(value))
			{
				return Visibility.Visible;
			}
		}
		return Visibility.Collapsed;
	}
}
