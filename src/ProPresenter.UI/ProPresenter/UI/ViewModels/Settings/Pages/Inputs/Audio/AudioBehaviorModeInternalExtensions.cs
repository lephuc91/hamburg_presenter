using ProPresenter.DO.Audio;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Inputs.Audio;

public static class AudioBehaviorModeInternalExtensions
{
	public static BehaviorMode ToBehaviorMode(this AudioBehaviorModeInternal audioBehaviorMode)
	{
		return audioBehaviorMode switch
		{
			AudioBehaviorModeInternal.On => BehaviorMode.On, 
			AudioBehaviorModeInternal.Off => BehaviorMode.Off, 
			AudioBehaviorModeInternal.AutoOff => BehaviorMode.AutoOff, 
			AudioBehaviorModeInternal.AutoOn => BehaviorMode.AutoOn, 
			_ => BehaviorMode.Off, 
		};
	}

	public static AudioBehaviorModeInternal ToAudioBehaviorModeInternal(this BehaviorMode audioBehaviorMode)
	{
		return audioBehaviorMode switch
		{
			BehaviorMode.On => AudioBehaviorModeInternal.On, 
			BehaviorMode.Off => AudioBehaviorModeInternal.Off, 
			BehaviorMode.AutoOff => AudioBehaviorModeInternal.AutoOff, 
			BehaviorMode.AutoOn => AudioBehaviorModeInternal.AutoOn, 
			_ => AudioBehaviorModeInternal.Off, 
		};
	}
}
