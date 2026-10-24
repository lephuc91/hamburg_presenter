using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public static class PlaceholderLinkSourceExtensions
{
	public static PlaceholderLink.Types.Source ToProto(this PlaceholderLinkSource PlaceholderSource)
	{
		return PlaceholderSource switch
		{
			PlaceholderLinkSource.QuickSearch => PlaceholderLink.Types.Source.QuickSearch, 
			PlaceholderLinkSource.ImportButton => PlaceholderLink.Types.Source.ImportButton, 
			PlaceholderLinkSource.CreateButton => PlaceholderLink.Types.Source.CreateButton, 
			PlaceholderLinkSource.DragDrop => PlaceholderLink.Types.Source.DragDrop, 
			PlaceholderLinkSource.Automatic => PlaceholderLink.Types.Source.Automatic, 
			_ => PlaceholderLink.Types.Source.Unknown, 
		};
	}
}
