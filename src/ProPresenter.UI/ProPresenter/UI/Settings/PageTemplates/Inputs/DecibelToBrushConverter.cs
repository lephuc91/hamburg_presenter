using System;
using System.Globalization;
using System.Windows.Media;
using Pro.UI.Converters;

namespace ProPresenter.UI.Settings.PageTemplates.Inputs;

public class DecibelToBrushConverter : ValueConverterBase<double, Brush>
{
	private static readonly Brush NormalBrush = Brushes.Green;

	private static readonly Brush WarningBrush = Brushes.Yellow;

	private static readonly Brush AlertBrush = Brushes.Red;

	protected override Brush ConvertValue(double value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value >= -8.0)
		{
			return AlertBrush;
		}
		if (value >= -20.0)
		{
			return WarningBrush;
		}
		return NormalBrush;
	}
}
