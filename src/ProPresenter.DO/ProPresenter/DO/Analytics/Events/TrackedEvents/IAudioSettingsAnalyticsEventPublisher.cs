using ProPresenter.DO.Audio;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents;

public interface IAudioSettingsAnalyticsEventPublisher
{
	void PublishAudioSettingsCustomMap(bool value);

	void PublishAudioInputModeSelection(BehaviorMode ModeType);
}
