using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Extensions.ProtoEntityConversion;

public static class MediaLiveVideoPropertiesExtensions
{
	public static Media.Types.LiveVideoProperties ToProto(this IMedia.Types.ILiveVideoProperties source)
	{
		return new Media.Types.LiveVideoProperties
		{
			LiveVideoIndex = source.LiveVideoIndex.Value
		};
	}

	public static IMedia.Types.ILiveVideoProperties ToEntity(this Media.Types.LiveVideoProperties source, IEntityFactory entityFactory)
	{
		IMedia.Types.ILiveVideoProperties liveVideoProperties = entityFactory.Create<IMedia.Types.ILiveVideoProperties>();
		liveVideoProperties.LiveVideoIndex.Set(source.LiveVideoIndex);
		return liveVideoProperties;
	}
}
