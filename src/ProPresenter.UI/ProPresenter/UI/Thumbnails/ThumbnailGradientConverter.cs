using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using Pro.UI.Converters;
using ProPresenter.UI.Theming;

namespace ProPresenter.UI.Thumbnails;

public class ThumbnailGradientConverter : ValueConverterBase<Color, Brush>
{
	private static readonly Color FallbackColor = (Color)AppTheme.Active.THUMBNAILGRADIENTEND_COLOR;

	private const double StartPoint = 1.0;

	private const double EndPoint = 0.0;

	private const double StartingOpacity = 0.89;

	private const double EndingOpacity = 0.37;

	protected override Brush ConvertValue(Color value, Type targetType, object? parameter, CultureInfo culture)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		Color startColor;
		Color endColor = (startColor = ((value.A != 0) ? value : FallbackColor));
		startColor.A = 226;
		endColor.A = 94;
		return new LinearGradientBrush(startColor, endColor, new Point(0.0, 1.0), new Point(0.0, 0.0));
	}
}
