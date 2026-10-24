using System;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public static class ProtoQuickSearchEventExtensions
{
	public static QuickSearchSearch.Types.Source ToSearchSource(this QuickSearchType type)
	{
		return type switch
		{
			QuickSearchType.Library => QuickSearchSearch.Types.Source.Library, 
			QuickSearchType.SongSelect => QuickSearchSearch.Types.Source.SongSelect, 
			QuickSearchType.MultiTracks => QuickSearchSearch.Types.Source.MultiTracks, 
			_ => throw new NotSupportedException(), 
		};
	}

	public static QuickSearchOpenItems.Types.Source ToOpenItemSource(this QuickSearchType type)
	{
		return type switch
		{
			QuickSearchType.Library => QuickSearchOpenItems.Types.Source.Library, 
			QuickSearchType.SongSelect => QuickSearchOpenItems.Types.Source.SongSelect, 
			QuickSearchType.MultiTracks => QuickSearchOpenItems.Types.Source.MultiTracks, 
			_ => throw new NotSupportedException(), 
		};
	}

	public static QuickSearchOpenItems.Types.Style ToSearchStyle(this QuickSearchStyle style)
	{
		return style switch
		{
			QuickSearchStyle.Open => QuickSearchOpenItems.Types.Style.ReturnKey, 
			QuickSearchStyle.AddToPlaylist => QuickSearchOpenItems.Types.Style.CommandReturnKey, 
			QuickSearchStyle.DragDrop => QuickSearchOpenItems.Types.Style.DragDrop, 
			_ => throw new NotSupportedException(), 
		};
	}
}
