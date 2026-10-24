using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.UI.Converters;

public class FlattenPlaylistsConverter : IValueConverter
{
	public bool IncludePlaylistItems { get; set; }

	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is IEnumerable<IPlaylist<ProPresenterCue>> playlists)
		{
			List<object> list = new List<object>();
			{
				foreach (IPlaylist<ProPresenterCue> playlist in playlists.GetPlaylists())
				{
					list.Add(playlist);
					if (IncludePlaylistItems && playlist is Playlist<ProPresenterCue> collection)
					{
						list.AddRange(collection);
					}
				}
				return list;
			}
		}
		return Array.Empty<object>();
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
