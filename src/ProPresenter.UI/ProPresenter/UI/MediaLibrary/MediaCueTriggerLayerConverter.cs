using System;
using System.Globalization;
using Pro.UI.Converters;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;

namespace ProPresenter.UI.MediaLibrary;

public class MediaCueTriggerLayerConverter : MultiValueConverterBase<bool>
{
	protected override bool ConvertValues(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.Length == 2 && values[1] is TriggerLayer triggerLayer && values[0] is IMediaCue mediaCue)
		{
			MediaAction? mediaAction = mediaCue.MediaAction;
			if (mediaAction == null)
			{
				return false;
			}
			return mediaAction.TriggerLayer == triggerLayer;
		}
		return false;
	}
}
