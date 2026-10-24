using System;
using System.Globalization;
using System.Windows.Data;
using ProPresenter.DO.Media;

namespace ProPresenter.UI.MediaLibrary;

public class CheckHotFolderBehaviorConverter : IMultiValueConverter
{
	public object Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		return values.Length >= 2 && values[0] is ImportLayer importLayer && values[1] is ImportLayer importLayer2 && importLayer == importLayer2;
	}

	public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
