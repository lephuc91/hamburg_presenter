using Pro.DO.Analytics;

namespace ProPresenter.DO.Analytics.Events.Capture;

public class CaptureAnalyticEventsPublisher : ICaptureAnalyticEventsPublisher
{
	public void StartupCapture(int presetCount, int diskPresetCount, int rtmpPresetCount, int resiPresetCount)
	{
		EventPublisher.Publish(new StartupCaptureEvent(presetCount, diskPresetCount, rtmpPresetCount, resiPresetCount));
	}

	public void OpenCaptureSettings(CaptureShownSource source)
	{
		EventPublisher.Publish(new OpenCaptureSettingsEvent(source));
	}
}
