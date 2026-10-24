using System;
using System.Globalization;
using System.Windows.Data;
using Pro.Common.Nullability;
using Pro.Localization;
using Pro.ssAPI.Devices;

namespace ProPresenter.UI.LiveVideo;

public class VideoDeviceNameConveter : IMultiValueConverter
{
	public object Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.Length < 2)
		{
			return LocalizedStrings.Get("GLOBAL_VIDEO_INPUT_NO_VIDEO_SOURCE_title");
		}
		if (values[0] is IVideoInputDevice videoInputDevice)
		{
			if (!(values[1] is IVideoMode videoMode) || !videoInputDevice.ShouldDisplayMode())
			{
				return videoInputDevice.Name;
			}
			return videoInputDevice.Name + " " + videoMode.Name;
		}
		if (values.Length < 5)
		{
			return LocalizedStrings.Get("GLOBAL_VIDEO_INPUT_NO_VIDEO_SOURCE_title");
		}
		string text = values[2] as string;
		string text2 = values[3] as string;
		string text3 = ((!text.NullableIsNullOrWhiteSpace()) ? text : text2);
		if (!text3.NullableIsNullOrWhiteSpace())
		{
			object obj = values[4];
			bool flag = default(bool);
			int num;
			if (obj is bool)
			{
				flag = (bool)obj;
				num = 1;
			}
			else
			{
				num = 0;
			}
			if (((uint)num & (flag ? 1u : 0u)) == 0)
			{
				return LocalizedStrings.Get("SETTINGS_AUDIO_DISCONNECTED_DEVICE_MENU_title", new object[1] { text3 });
			}
			return text3;
		}
		return LocalizedStrings.Get("GLOBAL_VIDEO_INPUT_NO_VIDEO_SOURCE_title");
	}

	public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
