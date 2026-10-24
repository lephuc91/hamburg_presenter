using System;
using System.Globalization;
using System.Windows.Data;
using ProPresenter.DO.Playlists;

namespace ProPresenter.UI.Converters;

public class PlaylistMenuItemConverter : IValueConverter
{
	public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (!(value is AudioPlaylist audioPlaylist))
		{
			if (!(value is AudioGroupPlaylist audioGroupPlaylist))
			{
				if (!(value is VisualPlaylist visualPlaylist))
				{
					if (value is VisualGroupPlaylist visualGroupPlaylist)
					{
						return visualGroupPlaylist.Name;
					}
					return value;
				}
				return visualPlaylist.Name;
			}
			return audioGroupPlaylist.Name;
		}
		return audioPlaylist.Name;
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
