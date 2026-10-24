using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Pro.UI.Converters;

public class BorderClipConverter : IMultiValueConverter
{
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		if (values.Length == 3 && values[0] is double num && values[1] is double num2 && values[2] is CornerRadius cornerRadius)
		{
			if (num < double.Epsilon || num2 < double.Epsilon)
			{
				return Geometry.Empty;
			}
			CornerRadius cornerRadius2 = cornerRadius;
			RectangleGeometry rectangleGeometry = new RectangleGeometry(new Rect(1.5, 1.5, num - 3.0, num2 - 3.0), cornerRadius2.TopLeft, cornerRadius2.TopLeft);
			((Freezable)rectangleGeometry).Freeze();
			return rectangleGeometry;
		}
		return Binding.DoNothing;
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
