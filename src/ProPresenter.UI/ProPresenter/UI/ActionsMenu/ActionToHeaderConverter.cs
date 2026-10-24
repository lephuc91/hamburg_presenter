using System;
using System.Globalization;
using Pro.DO.Triggering;
using Pro.Localization;
using Pro.UI.Converters;
using ProPresenter.DO.Actions;

namespace ProPresenter.UI.ActionsMenu;

public class ActionToHeaderConverter : MultiValueConverterBase<string>
{
	protected override string ConvertValues(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		string text;
		if (values.Length != 0 && values[0] is ActionBase actionBase)
		{
			if (actionBase is MediaAction mediaAction)
			{
				if (mediaAction.LiveVideo == null)
				{
					goto IL_00bc;
				}
				text = mediaAction.LiveVideo.LiveVideo?.Input?.LongName ?? actionBase.Name;
			}
			else if (!(actionBase is AudioPlaylistAction audioPlaylistAction))
			{
				if (!(actionBase is VisualPlaylistAction visualPlaylistAction))
				{
					if (!(actionBase is AudienceLookAction audienceLookAction))
					{
						if (!(actionBase is PropAction propAction))
						{
							goto IL_00bc;
						}
						text = propAction.PropName;
					}
					else
					{
						text = audienceLookAction.LookName;
					}
				}
				else
				{
					text = visualPlaylistAction.PlaylistName;
				}
			}
			else
			{
				text = audioPlaylistAction.PlaylistName;
			}
			goto IL_00c4;
		}
		return string.Empty;
		IL_00c4:
		string text2 = text;
		if (parameter is MenuItemHeaderType menuItemHeaderType)
		{
			switch (menuItemHeaderType)
			{
			case MenuItemHeaderType.Edit:
				text2 = LocalizedStrings.Get("PRESENTATION_CONTEXT_MENU_EDIT_ACTION_title", new object[1] { text2 });
				break;
			case MenuItemHeaderType.Remove:
				text2 = LocalizedStrings.Get("PRESENTATION_CONTEXT_MENU_REMOVE_ACTION_title", new object[1] { text2 });
				break;
			}
		}
		return text2;
		IL_00bc:
		text = actionBase.Name;
		goto IL_00c4;
	}
}
