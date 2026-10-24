using Pro.Localization;

namespace Pro.DO.Triggering;

public enum CompletionTargetType
{
	[LocalizedString("MEDIA_COMPLETION_TARGET_NONE_title")]
	None,
	[LocalizedString("MEDIA_COMPLETION_TARGET_NEXT_title")]
	Next,
	[LocalizedString("MEDIA_COMPLETION_TARGET_RANDOM_title")]
	Random,
	[LocalizedString("MEDIA_COMPLETION_TARGET_CUE_title")]
	Cue,
	[LocalizedString("MEDIA_COMPLETION_TARGET_FIRST_title")]
	First
}
