using Pro.Localization;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Media;

public enum ForegroundMediaAudioBehaviorInternal
{
	[LocalizedString("SETTINGS_MEDIA_FOREGROUND_MEDIA_AUDIO_BEHAVIOR_DO_NOTHING_title")]
	DoNothing,
	[LocalizedString("SETTINGS_MEDIA_FOREGROUND_MEDIA_AUDIO_BEHAVIOR_CLEAR_ALWAYS_title")]
	ClearAlways,
	[LocalizedString("SETTINGS_MEDIA_FOREGROUND_MEDIA_AUDIO_BEHAVIOR_CLEAR_IF_AUDIO_title")]
	ClearIfAudio,
	[LocalizedString("SETTINGS_MEDIA_FOREGROUND_MEDIA_AUDIO_BEHAVIOR_PAUSE_ALWAYS_title")]
	PauseAlways,
	[LocalizedString("SETTINGS_MEDIA_FOREGROUND_MEDIA_AUDIO_BEHAVIOR_PAUSE_IF_AUDIO_title")]
	PauseIfAudio
}
