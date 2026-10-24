using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public static class QuickSearchShownSourceExtensions
{
	public static QuickSearchShown.Types.Source ToProto(this QuickSearchShownSource source)
	{
		return source switch
		{
			QuickSearchShownSource.ApplicationMenu => QuickSearchShown.Types.Source.ApplicationMenu, 
			QuickSearchShownSource.Toolbar => QuickSearchShown.Types.Source.Toolbar, 
			QuickSearchShownSource.UnlinkedHeader => QuickSearchShown.Types.Source.UnlinkedHeader, 
			_ => QuickSearchShown.Types.Source.Unknown, 
		};
	}
}
