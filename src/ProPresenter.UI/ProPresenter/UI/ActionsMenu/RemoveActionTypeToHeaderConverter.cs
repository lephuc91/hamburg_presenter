using System;
using System.Globalization;
using System.Windows.Data;
using Pro.DO.Triggering;
using Pro.Localization;
using ProPresenter.DO.Media;

namespace ProPresenter.UI.ActionsMenu;

public class RemoveActionTypeToHeaderConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		if (value is ActionType actionType)
		{
			return LocalizedStrings.Get<ActionType>("PRESENTATION_CONTEXT_MENU_REMOVE_ALL_OF_TYPE_title", actionType);
		}
		if (value is MediaType)
		{
			string text;
			switch ((MediaType)value)
			{
			case MediaType.Image:
				text = LocalizedStrings.Get("MEDIA_FILL_TYPE_IMAGE_PLURAL");
				break;
			case MediaType.Video:
				text = LocalizedStrings.Get("MEDIA_FILL_TYPE_VIDEO_PLURAL");
				break;
			case MediaType.Audio:
				text = LocalizedStrings.Get("MEDIA_FILL_TYPE_AUDIO");
				break;
			case MediaType.LiveVideo:
				text = LocalizedStrings.Get("MEDIA_FILL_TYPE_VIDEO_INPUT_PLURAL");
				break;
			case MediaType.Web:
				text = LocalizedStrings.Get("MEDIA_FILL_TYPE_WEB");
				break;
			default:
				return string.Empty;
			}
			return LocalizedStrings.Get("PRESENTATION_CONTEXT_MENU_REMOVE_ALL_OF_TYPE_title", new object[1] { text });
		}
		return string.Empty;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
