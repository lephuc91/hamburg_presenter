using System;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.ssAPI;

public static class PlaybackBehaviorTypeExtensions
{
	public static Media.Types.TransportProperties.Types.PlaybackBehavior ToProtoPlaybackBehavior(this PlaybackBehaviorType playbackBehavior)
	{
		return playbackBehavior switch
		{
			PlaybackBehaviorType.Stop => Media.Types.TransportProperties.Types.PlaybackBehavior.Stop, 
			PlaybackBehaviorType.Loop => Media.Types.TransportProperties.Types.PlaybackBehavior.Loop, 
			PlaybackBehaviorType.LoopForCount => Media.Types.TransportProperties.Types.PlaybackBehavior.LoopForCount, 
			PlaybackBehaviorType.LoopForTime => Media.Types.TransportProperties.Types.PlaybackBehavior.LoopForTime, 
			_ => throw new NotSupportedException(), 
		};
	}
}
