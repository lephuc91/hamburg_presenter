using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;
using Pro.Common.Utility;
using ProPresenter.DO.Slide.Custom.Elements.Strokes;

namespace ProPresenter.UI.SlideEditor.Inspectors.Strokes;

public class StrokeTypeToDashStyleConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is StrokeStyle value2)
		{
			IEnumerable<double> enumerable = value2.GetAttribute<StrokeStyle, StrokePatternAttribute>()?.Pattern;
			return new DashStyle(enumerable ?? Enumerable.Empty<double>(), 0.0);
		}
		return Binding.DoNothing;
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
