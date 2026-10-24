using System;
using System.Globalization;
using System.Windows.Data;
using Pro.Common.Collections;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;

namespace ProPresenter.UI.SlideEditor.Converters;

public class SlideCueLiveVideoConverter : IValueConverter
{
	public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (!(value is SlideCue slideCue))
		{
			return null;
		}
		return slideCue.Actions.FirstOrDefaultOf((MediaAction m) => m.Media is LiveVideoMedia)?.LiveVideo?.LiveVideo.Input;
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
