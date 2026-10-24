using System;
using System.Globalization;
using System.Windows.Media;
using Pro.DO.Application;
using Pro.UI.Themes;

namespace Pro.UI.Converters;

public class SelectedLibraryIconConverter : ValueConverterBase<LibraryItemType, ImageSource?>
{
	protected override ImageSource? ConvertValue(LibraryItemType value, Type targetType, object? parameter, CultureInfo culture)
	{
		return value switch
		{
			LibraryItemType.Library => Icons.GetIcon(Icons.Library), 
			LibraryItemType.Playlist => Icons.GetIcon(Icons.Playlist), 
			LibraryItemType.None => null, 
			_ => null, 
		};
	}
}
