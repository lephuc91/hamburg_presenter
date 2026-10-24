using System;
using System.Globalization;
using System.Windows.Data;
using Pro.DO.Triggering;

namespace ProPresenter.UI.AudioLibrary;

public class CheckAudioBehaviorConverter : IMultiValueConverter
{
	public object Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		return values.Length == 2 && values[0] is AudioBehaviorType audioBehaviorType && values[1] is AudioBehaviorType audioBehaviorType2 && audioBehaviorType == audioBehaviorType2;
	}

	public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
