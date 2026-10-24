namespace ProPresenter.DO.Analytics.Events.Capture;

public interface ICaptureAnalyticEventsPublisher
{
	void StartupCapture(int presetCount, int diskPresetCount, int rtmpPresetCount, int resiPresetCount);

	void OpenCaptureSettings(CaptureShownSource source);
}
