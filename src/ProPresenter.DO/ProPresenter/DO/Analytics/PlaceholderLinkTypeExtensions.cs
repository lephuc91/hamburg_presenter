using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public static class PlaceholderLinkTypeExtensions
{
	public static PlaceholderLink.Types.Type ToProto(this PlaceholderLinkType PlaceholderType)
	{
		return PlaceholderType switch
		{
			PlaceholderLinkType.Presentation => PlaceholderLink.Types.Type.Presentation, 
			PlaceholderLinkType.Media => PlaceholderLink.Types.Type.Media, 
			_ => PlaceholderLink.Types.Type.Unknown, 
		};
	}
}
