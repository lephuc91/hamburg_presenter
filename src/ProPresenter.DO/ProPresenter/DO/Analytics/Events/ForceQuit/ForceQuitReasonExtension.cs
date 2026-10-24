using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

namespace ProPresenter.DO.Analytics.Events.ForceQuit;

public static class ForceQuitReasonExtension
{
	public static Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.ForceQuit.Types.Reason ToProto(this ForceQuitReason reason)
	{
		return reason switch
		{
			ForceQuitReason.HostsFile => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.ForceQuit.Types.Reason.HostsFile, 
			ForceQuitReason.SystemTime => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.ForceQuit.Types.Reason.SystemTimeSkew, 
			ForceQuitReason.Watermark => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.ForceQuit.Types.Reason.InvalidWatermark, 
			ForceQuitReason.PiratedSoftware => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.ForceQuit.Types.Reason.PiratedSoftware, 
			_ => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.ForceQuit.Types.Reason.Unknown, 
		};
	}
}
