using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Input;

namespace ProPresenter.UI.Converters;

public class KeyToStringConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		if (value is Key val && (int)val != 0)
		{
			return ((object)(Key)(ref val)/*cast due to .constrained prefix*/).ToString();
		}
		return string.Empty;
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if (Enum.TryParse<Key>(value?.ToString() ?? string.Empty, out Key result))
		{
			return result;
		}
		return (object)(Key)0;
	}
}
