using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public static class PCOLiveShownWindowModeExtensions
{
	public static PlanningCenterLive.Types.WindowType ToProto(this PCOLiveShownWindowMode windowMode)
	{
		return windowMode switch
		{
			PCOLiveShownWindowMode.Docked => PlanningCenterLive.Types.WindowType.Docked, 
			PCOLiveShownWindowMode.Floating => PlanningCenterLive.Types.WindowType.Floating, 
			_ => PlanningCenterLive.Types.WindowType.Unknown, 
		};
	}
}
