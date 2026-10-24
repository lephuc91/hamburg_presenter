using System;
using System.Globalization;
using System.Windows.Media;
using Pro.Common.Nullability;
using Pro.UI.Converters;
using ProPresenter.DO.Actions.Playlist;

namespace ProPresenter.UI.Calendar;

public class LibraryPlaylistActionToThumbnailConverter : ValueConverterBase<LibraryPlaylistAction, ImageSource?>
{
	public ImageSource? PlaylistThumbnail { get; set; }

	public ImageSource? PresentationThumbnail { get; set; }

	public ICalendarService? CalendarService { get; set; }

	protected override ImageSource? ConvertValue(LibraryPlaylistAction value, Type targetType, object? parameter, CultureInfo culture)
	{
		CalendarService.ThrowWhenNull("CalendarService");
		return CalendarService.GetActionType(value) switch
		{
			ICalendarService.ActionType.Playlist => PlaylistThumbnail, 
			ICalendarService.ActionType.Presentation => PresentationThumbnail, 
			_ => null, 
		};
	}
}
