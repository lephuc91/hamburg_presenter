using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using Pro.Common.Utility;

namespace ProPresenter.UI.Converters;

[Obsolete("Use EnumToContentConverter instead to support localization")]
public class EnumToDescriptionConverter : IValueConverter
{
	public virtual object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is Enum value2)
		{
			return value2.GetEnumDescription();
		}
		if (value is IEnumerable source)
		{
			return source.OfType<Enum>().GetDescriptions();
		}
		return null;
	}

	public virtual object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
