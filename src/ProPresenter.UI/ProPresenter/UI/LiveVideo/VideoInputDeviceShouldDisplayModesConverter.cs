using System;
using System.Globalization;
using Pro.UI.Converters;
using Pro.ssAPI.Devices;

namespace ProPresenter.UI.LiveVideo;

public class VideoInputDeviceShouldDisplayModesConverter : ValueConverterBase<IVideoInputDevice, bool>
{
	protected override bool ConvertValue(IVideoInputDevice value, Type targetType, object? parameter, CultureInfo culture)
	{
		return value.ShouldDisplayMode();
	}
}
