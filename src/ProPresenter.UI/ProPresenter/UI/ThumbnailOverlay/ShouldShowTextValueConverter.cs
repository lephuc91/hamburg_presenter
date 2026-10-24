using System;
using System.Globalization;
using Pro.UI.Converters;
using ProPresenter.UI.ViewModels.Thumbnails;

namespace ProPresenter.UI.ThumbnailOverlay;

internal class ShouldShowTextValueConverter : MultiValueConverterBase<bool>
{
	protected override bool ConvertValues(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values[0] is double num && values[1] is bool flag && values[2] is InvalidMediaType invalidMediaType)
		{
			if (num > 100.0 && flag)
			{
				return invalidMediaType != InvalidMediaType.Device;
			}
			return false;
		}
		return false;
	}
}
