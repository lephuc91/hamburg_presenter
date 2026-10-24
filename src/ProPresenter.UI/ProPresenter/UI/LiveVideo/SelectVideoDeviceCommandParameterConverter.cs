using System;
using System.Globalization;
using System.Linq;
using Pro.UI.Converters;
using Pro.ssAPI.Devices;

namespace ProPresenter.UI.LiveVideo;

public class SelectVideoDeviceCommandParameterConverter : MultiValueConverterBase<SelectVideoDeviceCommandParameter>
{
	protected override SelectVideoDeviceCommandParameter? ConvertValues(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.ElementAtOrDefault(0) is IVideoInputDevice videoInputDevice)
		{
			return new SelectVideoDeviceCommandParameter(videoInputDevice, values.ElementAtOrDefault(1) as IVideoMode);
		}
		return null;
	}
}
