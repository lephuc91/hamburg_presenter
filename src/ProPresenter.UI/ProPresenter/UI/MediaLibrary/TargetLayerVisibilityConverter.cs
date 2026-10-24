using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using ProPresenter.DO.Media;

namespace ProPresenter.UI.MediaLibrary;

public class TargetLayerVisibilityConverter : IMultiValueConverter
{
	public object Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.Length == 2 && values[0] is MediaType mediaType && values[1] is TriggerLayer triggerLayer)
		{
			switch (mediaType)
			{
			case MediaType.Image:
			case MediaType.Video:
				return (triggerLayer != 0 && triggerLayer != TriggerLayer.Foreground) ? Visibility.Collapsed : Visibility.Visible;
			case MediaType.LiveVideo:
				return Visibility.Visible;
			default:
				return Visibility.Collapsed;
			}
		}
		return Visibility.Collapsed;
	}

	public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
