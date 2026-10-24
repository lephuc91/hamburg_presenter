using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.UI.Converters;

public class PlaylistMarginConverter : IValueConverter
{
	public int StartingLevel { get; set; }

	public int Increment { get; set; } = 8;

	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		int level = StartingLevel;
		if (value is IPlaylist<ProPresenterCue> pl2)
		{
			getLevel<ProPresenterCue>(pl2);
		}
		else if (value is IPlaylist<MediaCue> pl3)
		{
			getLevel<MediaCue>(pl3);
		}
		else
		{
			level = 0;
		}
		return new Thickness(level * Increment, 0.0, 0.0, 0.0);
		void getLevel<T>(IPlaylist<T> pl) where T : notnull, ProPresenterCue
		{
			while (pl.PlaylistParent != null)
			{
				pl = pl.PlaylistParent;
				level++;
			}
		}
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
