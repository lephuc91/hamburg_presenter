using Pro.DO.Analytics.Events;
using ProPresenter.DO.Audio;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents;

public class AudioSettingsAnalyticsEventPublisher : IAudioSettingsAnalyticsEventPublisher
{
	public void PublishAudioSettingsCustomMap(bool value)
	{
		AudioSettingsCustomMapEvent.Publish(value);
	}

	public void PublishAudioInputModeSelection(BehaviorMode ModeType)
	{
		AudioInputModeSelectionEvent.Publish(ModeType);
	}
}
