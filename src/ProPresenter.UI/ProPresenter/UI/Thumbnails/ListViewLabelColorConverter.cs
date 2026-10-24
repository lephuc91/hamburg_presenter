using System;
using System.Globalization;
using System.Windows.Media;
using Pro.UI.Converters;
using ProPresenter.UI.Theming;

namespace ProPresenter.UI.Thumbnails;

public class ListViewLabelColorConverter : ValueConverterBase<Color, Brush>
{
	private static readonly Color FallbackColor = (Color)AppTheme.Active.THUMBNAILGRADIENTEND_COLOR;

	protected override Brush ConvertValue(Color value, Type targetType, object? parameter, CultureInfo culture)
	{
		return new SolidColorBrush((value.A != 0) ? value : FallbackColor);
	}
}
