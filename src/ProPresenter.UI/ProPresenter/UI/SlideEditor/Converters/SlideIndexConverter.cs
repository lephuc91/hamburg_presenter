using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;
using ProPresenter.DO.Slide.Custom;

namespace ProPresenter.UI.SlideEditor.Converters;

public class SlideIndexConverter : IMultiValueConverter
{
	public object Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		return (values.Length == 2 && values[0] is CustomSlide item && values[1] is ObservableCollection<CustomSlide> observableCollection) ? (observableCollection.IndexOf(item) + 1) : (-1);
	}

	public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
