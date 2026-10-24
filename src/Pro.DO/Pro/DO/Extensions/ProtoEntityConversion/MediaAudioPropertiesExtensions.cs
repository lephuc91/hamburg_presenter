using System.Linq;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Extensions.ProtoEntityConversion;

public static class MediaAudioPropertiesExtensions
{
	public static Media.Types.AudioProperties ToProto(this IMedia.Types.IAudioProperties value)
	{
		Media.Types.AudioProperties audioProperties = new Media.Types.AudioProperties();
		audioProperties.Volume = value.Volume.Value;
		audioProperties.IsCustomMapping = value.IsCustomMapping.Value;
		audioProperties.AudioChannels.AddRange(value.AudioChannels.Items.Select(ToProto));
		return audioProperties;
	}

	private static Media.Types.Audio.Types.Channel ToProto(IMedia.Types.IAudio.Types.IChannel source)
	{
		Media.Types.Audio.Types.Channel channel = new Media.Types.Audio.Types.Channel();
		channel.Index = source.Index.Value;
		channel.Muted = source.Muted.Value;
		channel.Volume = source.Volume.Value;
		channel.CompressLimit = source.CompressLimit.Value;
		channel.Outputs.AddRange(source.Outputs.Items.Select(ToProto));
		return channel;
	}

	private static Media.Types.Audio.Types.Channel.Types.Output ToProto(IMedia.Types.IAudio.Types.IChannel.Types.IOutput source)
	{
		return new Media.Types.Audio.Types.Channel.Types.Output
		{
			ChannelIndex = source.ChannelIndex.Value
		};
	}

	public static IMedia.Types.IAudioProperties ToEntity(this Media.Types.AudioProperties source, IEntityFactory entityFactory)
	{
		IMedia.Types.IAudioProperties audioProperties = entityFactory.Create<IMedia.Types.IAudioProperties>();
		audioProperties.Volume.Set(source.Volume);
		audioProperties.IsCustomMapping.Set(source.IsCustomMapping);
		audioProperties.AudioChannels.Reset(source.AudioChannels.Select((Media.Types.Audio.Types.Channel c) => c.ToEntity(entityFactory)));
		return audioProperties;
	}

	private static IMedia.Types.IAudio.Types.IChannel ToEntity(this Media.Types.Audio.Types.Channel source, IEntityFactory entityFactory)
	{
		IMedia.Types.IAudio.Types.IChannel channel = entityFactory.Create<IMedia.Types.IAudio.Types.IChannel>();
		channel.Index.Set(source.Index);
		channel.Muted.Set(source.Muted);
		channel.Volume.Set(source.Volume);
		channel.CompressLimit.Set(source.CompressLimit);
		channel.Outputs.Reset(source.Outputs.Select((Media.Types.Audio.Types.Channel.Types.Output o) => o.ToEntity(entityFactory)));
		return channel;
	}

	private static IMedia.Types.IAudio.Types.IChannel.Types.IOutput ToEntity(this Media.Types.Audio.Types.Channel.Types.Output source, IEntityFactory entityFactory)
	{
		IMedia.Types.IAudio.Types.IChannel.Types.IOutput output = entityFactory.Create<IMedia.Types.IAudio.Types.IChannel.Types.IOutput>();
		output.ChannelIndex.Set(source.ChannelIndex);
		return output;
	}
}
