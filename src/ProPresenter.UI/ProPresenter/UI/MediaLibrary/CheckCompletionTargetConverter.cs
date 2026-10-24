using System;
using System.Globalization;
using System.Windows.Data;
using Pro.DO.Triggering;
using ProPresenter.DO.Cues;

namespace ProPresenter.UI.MediaLibrary;

public class CheckCompletionTargetConverter : IMultiValueConverter
{
	public object Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.Length == 3 && values[1] is CompletionTargetType completionTargetType && values[2] is Guid guid)
		{
			if (values[0] is CompletionTargetType completionTargetType2)
			{
				return completionTargetType2 == completionTargetType;
			}
			if (values[0] is MediaCue mediaCue)
			{
				return completionTargetType == CompletionTargetType.Cue && mediaCue.ID == guid;
			}
		}
		return false;
	}

	public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
