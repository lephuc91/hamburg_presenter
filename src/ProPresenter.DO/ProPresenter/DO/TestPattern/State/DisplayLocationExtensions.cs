using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.TestPattern.State;

public static class DisplayLocationExtensions
{
	public static Pro.SerializationInterop.RVProtoData.TestPatternState.Types.DisplayLocation ToProtoDisplayLocation(this DisplayLocation displayLocation)
	{
		return displayLocation switch
		{
			DisplayLocation.AllScreens => Pro.SerializationInterop.RVProtoData.TestPatternState.Types.DisplayLocation.AllScreens, 
			DisplayLocation.AudienceScreens => Pro.SerializationInterop.RVProtoData.TestPatternState.Types.DisplayLocation.AudienceScreens, 
			DisplayLocation.StageScreens => Pro.SerializationInterop.RVProtoData.TestPatternState.Types.DisplayLocation.StageScreens, 
			DisplayLocation.SpecificScreen => Pro.SerializationInterop.RVProtoData.TestPatternState.Types.DisplayLocation.SpecificScreen, 
			_ => Pro.SerializationInterop.RVProtoData.TestPatternState.Types.DisplayLocation.AllScreens, 
		};
	}

	public static DisplayLocation ToDisplayLocation(this Pro.SerializationInterop.RVProtoData.TestPatternState.Types.DisplayLocation protoDsplayLocation)
	{
		return protoDsplayLocation switch
		{
			Pro.SerializationInterop.RVProtoData.TestPatternState.Types.DisplayLocation.AllScreens => DisplayLocation.AllScreens, 
			Pro.SerializationInterop.RVProtoData.TestPatternState.Types.DisplayLocation.AudienceScreens => DisplayLocation.AudienceScreens, 
			Pro.SerializationInterop.RVProtoData.TestPatternState.Types.DisplayLocation.StageScreens => DisplayLocation.StageScreens, 
			Pro.SerializationInterop.RVProtoData.TestPatternState.Types.DisplayLocation.SpecificScreen => DisplayLocation.SpecificScreen, 
			_ => DisplayLocation.AllScreens, 
		};
	}
}
