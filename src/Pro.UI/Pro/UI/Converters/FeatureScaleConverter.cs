using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Pro.UI.Converters;

public class FeatureScaleConverter : DependencyObject, IValueConverter
{
	public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register("Maximum", typeof(double), typeof(FeatureScaleConverter), new PropertyMetadata((object)100.0));

	public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register("Minimum", typeof(double), typeof(FeatureScaleConverter), new PropertyMetadata((object)0.0));

	public double Maximum
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MaximumProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaximumProperty, (object)value);
		}
	}

	public double Minimum
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MinimumProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MinimumProperty, (object)value);
		}
	}

	public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
	{
		if (value is double num)
		{
			return num * (Maximum - Minimum) + Minimum;
		}
		return Binding.DoNothing;
	}

	public object ConvertBack(object? value, Type targetType, object parameter, CultureInfo culture)
	{
		if (value is double)
		{
			return ((double)value - Minimum) / (Maximum - Minimum);
		}
		return Binding.DoNothing;
	}
}
