using Pro.Common.SourceGenerator.Attributes;
using ProPresenter.DO.Media;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Media;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(ForegroundMediaAudioBehavior), typeof(ForegroundMediaAudioBehaviorInternal), DestinationDefaultValue = "DoNothing", SourceToDestinationMethodName = "ToBehaviorInternal", SourceDefaultValue = "DoNothing", DestinationToSourceMethodName = "ToBehavior")]
public static class ForegroundMediaAudioBehaviorInternalExtensions
{
	public static ForegroundMediaAudioBehaviorInternal ToBehaviorInternal(this ForegroundMediaAudioBehavior source)
	{
		return source switch
		{
			ForegroundMediaAudioBehavior.DoNothing => ForegroundMediaAudioBehaviorInternal.DoNothing, 
			ForegroundMediaAudioBehavior.ClearAlways => ForegroundMediaAudioBehaviorInternal.ClearAlways, 
			ForegroundMediaAudioBehavior.ClearIfAudio => ForegroundMediaAudioBehaviorInternal.ClearIfAudio, 
			ForegroundMediaAudioBehavior.PauseAlways => ForegroundMediaAudioBehaviorInternal.PauseAlways, 
			ForegroundMediaAudioBehavior.PauseIfAudio => ForegroundMediaAudioBehaviorInternal.PauseIfAudio, 
			_ => ForegroundMediaAudioBehaviorInternal.DoNothing, 
		};
	}

	public static ForegroundMediaAudioBehavior ToBehavior(this ForegroundMediaAudioBehaviorInternal source)
	{
		return source switch
		{
			ForegroundMediaAudioBehaviorInternal.DoNothing => ForegroundMediaAudioBehavior.DoNothing, 
			ForegroundMediaAudioBehaviorInternal.ClearAlways => ForegroundMediaAudioBehavior.ClearAlways, 
			ForegroundMediaAudioBehaviorInternal.ClearIfAudio => ForegroundMediaAudioBehavior.ClearIfAudio, 
			ForegroundMediaAudioBehaviorInternal.PauseAlways => ForegroundMediaAudioBehavior.PauseAlways, 
			ForegroundMediaAudioBehaviorInternal.PauseIfAudio => ForegroundMediaAudioBehavior.PauseIfAudio, 
			_ => ForegroundMediaAudioBehavior.DoNothing, 
		};
	}
}
