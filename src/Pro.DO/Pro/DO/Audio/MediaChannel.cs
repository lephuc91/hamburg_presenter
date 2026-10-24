using System;
using Pro.Common.Time;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Audio;

public class MediaChannel : ChannelBase
{
	public override string Name
	{
		get
		{
			return LocalizedStrings.Get("AUDIO_PREFERENCES_ROUTING_CHANNEL_INDEX_label", new object[1] { base.Index + 1 });
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public override bool CanRename => false;

	public override bool TestActive
	{
		get
		{
			return false;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public override TimeSlice Delay
	{
		get
		{
			return TimeSlice.Zero;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public Media.Types.Audio.Types.Channel Serialize()
	{
		return new Media.Types.Audio.Types.Channel
		{
			Index = (uint)base.Index,
			Muted = MuteActive,
			Volume = base.Level
		};
	}

	public void Deserialize(Media.Types.Audio.Types.Channel protoMediaAudioChannel)
	{
		if (protoMediaAudioChannel != null)
		{
			MuteActive = protoMediaAudioChannel.Muted;
			base.Level = protoMediaAudioChannel.Volume;
		}
	}
}
