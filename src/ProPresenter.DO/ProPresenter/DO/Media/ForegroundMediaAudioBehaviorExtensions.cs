using System;
using Pro.SerializationInterop.RVProtoData;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Media;

public static class ForegroundMediaAudioBehaviorExtensions
{
	public static ProForegroundMediaAudioBehavior ToBehavior(this ForegroundMediaAudioBehavior behavior)
	{
		return behavior switch
		{
			ForegroundMediaAudioBehavior.DoNothing => ProForegroundMediaAudioBehavior.DoNothing, 
			ForegroundMediaAudioBehavior.ClearIfAudio => ProForegroundMediaAudioBehavior.ClearIfAudio, 
			ForegroundMediaAudioBehavior.PauseAlways => ProForegroundMediaAudioBehavior.PauseAlways, 
			ForegroundMediaAudioBehavior.PauseIfAudio => ProForegroundMediaAudioBehavior.PauseIfAudio, 
			_ => ProForegroundMediaAudioBehavior.ClearAlways, 
		};
	}

	public static Preferences.Types.Advanced.Types.AudioForegroundMediaBehavior ToProtoBehavior(this ForegroundMediaAudioBehavior behavior)
	{
		return behavior switch
		{
			ForegroundMediaAudioBehavior.DoNothing => Preferences.Types.Advanced.Types.AudioForegroundMediaBehavior.IgnoreForegroundMedia, 
			ForegroundMediaAudioBehavior.ClearAlways => Preferences.Types.Advanced.Types.AudioForegroundMediaBehavior.ClearForAllMedia, 
			ForegroundMediaAudioBehavior.ClearIfAudio => Preferences.Types.Advanced.Types.AudioForegroundMediaBehavior.ClearIfAudio, 
			ForegroundMediaAudioBehavior.PauseIfAudio => Preferences.Types.Advanced.Types.AudioForegroundMediaBehavior.PauseIfAudio, 
			ForegroundMediaAudioBehavior.PauseAlways => Preferences.Types.Advanced.Types.AudioForegroundMediaBehavior.PauseForAllMedia, 
			_ => throw new NotSupportedException(), 
		};
	}
}
