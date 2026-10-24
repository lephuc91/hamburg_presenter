using System;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Media;

public static class AudioTypeExtensions
{
	public static AudioType ToAudioType(this ProLayerIndex layer)
	{
		return layer switch
		{
			ProLayerIndex.Music => AudioType.AudioTrack, 
			ProLayerIndex.SoundEffects => AudioType.SoundEffect, 
			_ => throw new InvalidOperationException(), 
		};
	}

	public static ProLayerIndex ToProLayerIndex(this AudioType audioType)
	{
		return audioType switch
		{
			AudioType.AudioTrack => ProLayerIndex.Music, 
			AudioType.SoundEffect => ProLayerIndex.SoundEffects, 
			_ => throw new NotSupportedException(), 
		};
	}
}
