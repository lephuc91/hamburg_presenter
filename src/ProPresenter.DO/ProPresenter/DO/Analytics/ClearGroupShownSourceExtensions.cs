using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public static class ClearGroupShownSourceExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Analytics.UI.ClearGroups.Types.Source ToProto(this ClearGroupShownSource clearGroupSource)
	{
		return clearGroupSource switch
		{
			ClearGroupShownSource.ApplicationMenu => Pro.SerializationInterop.RVProtoData.Analytics.UI.ClearGroups.Types.Source.ApplicationMenu, 
			ClearGroupShownSource.PreviewMenu => Pro.SerializationInterop.RVProtoData.Analytics.UI.ClearGroups.Types.Source.PreviewMenu, 
			ClearGroupShownSource.ActionMenu => Pro.SerializationInterop.RVProtoData.Analytics.UI.ClearGroups.Types.Source.ActionMenu, 
			_ => Pro.SerializationInterop.RVProtoData.Analytics.UI.ClearGroups.Types.Source.Unknown, 
		};
	}
}
