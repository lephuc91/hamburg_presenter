using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.Startup;

namespace ProPresenter.DO.Analytics.Events.Capture;

public record StartupCaptureEvent(int PresetCount, int DiskPresetCount, int RtmpPresetCount, int ResiPresetCount) : IAnalyticEvent
{
	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.StartupCapture = new Pro.SerializationInterop.RVProtoData.Analytics.Startup.Capture
			{
				PresetsCount = PresetCount,
				DiskPresetsCount = DiskPresetCount,
				RtmpPresetsCount = RtmpPresetCount,
				ResiPresetsCount = ResiPresetCount
			};
		});
	}
}
