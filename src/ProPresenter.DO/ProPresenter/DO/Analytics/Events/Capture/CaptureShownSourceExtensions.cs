using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics.Events.Capture;

public static class CaptureShownSourceExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Analytics.UI.Capture.Types.Source ToProto(this CaptureShownSource captureSource)
	{
		return captureSource switch
		{
			CaptureShownSource.Toolbar => Pro.SerializationInterop.RVProtoData.Analytics.UI.Capture.Types.Source.Toolbar, 
			CaptureShownSource.ActionPopover => Pro.SerializationInterop.RVProtoData.Analytics.UI.Capture.Types.Source.ActionPopover, 
			CaptureShownSource.ActionContextMenu => Pro.SerializationInterop.RVProtoData.Analytics.UI.Capture.Types.Source.ActionContextualMenu, 
			CaptureShownSource.Calendar => Pro.SerializationInterop.RVProtoData.Analytics.UI.Capture.Types.Source.Calendar, 
			CaptureShownSource.PreferenceResi => Pro.SerializationInterop.RVProtoData.Analytics.UI.Capture.Types.Source.PreferencesResi, 
			_ => Pro.SerializationInterop.RVProtoData.Analytics.UI.Capture.Types.Source.Unknown, 
		};
	}
}
