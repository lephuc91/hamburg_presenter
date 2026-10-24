using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Extensions.ProtoEntityConversion;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(IMedia.Types.IVideoProperties.Types.FieldType), typeof(Media.Types.VideoProperties.Types.FieldType), SourceToDestinationMethodName = "ToProto", DestinationDefaultValue = "Unknown", DestinationToSourceMethodName = "ToEntity", SourceDefaultValue = "Unknown")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(IMedia.Types.IVideoProperties.Types.EndBehavior), typeof(Media.Types.VideoProperties.Types.EndBehavior), SourceToDestinationMethodName = "ToProto", DestinationDefaultValue = "Stop", DestinationToSourceMethodName = "ToEntity", SourceDefaultValue = "Stop")]
public static class MediaVideoPropertiesExtensions
{
	public static Media.Types.VideoProperties ToProto(this IMedia.Types.IVideoProperties source)
	{
		return new Media.Types.VideoProperties
		{
			FrameRate = source.FrameRate.Value,
			FieldType = source.FieldType.Value.ToProto(),
			ThumbnailPosition = source.ThumbnailPosition.Value,
			EndBehavior = source.EndBehavior.Value.ToProto(),
			SoftLoop = source.SoftLoop.Value,
			SoftLoopDuration = source.SoftLoopDuration.Value
		};
	}

	public static IMedia.Types.IVideoProperties ToEntity(this Media.Types.VideoProperties source, IEntityFactory entityFactory)
	{
		IMedia.Types.IVideoProperties videoProperties = entityFactory.Create<IMedia.Types.IVideoProperties>();
		videoProperties.FrameRate.Set(source.FrameRate);
		videoProperties.FieldType.Set(source.FieldType.ToEntity());
		videoProperties.ThumbnailPosition.Set(source.ThumbnailPosition);
		videoProperties.EndBehavior.Set(source.EndBehavior.ToEntity());
		videoProperties.SoftLoop.Set(source.SoftLoop);
		videoProperties.SoftLoopDuration.Set(source.SoftLoopDuration);
		return videoProperties;
	}

	public static Media.Types.VideoProperties.Types.FieldType ToProto(this IMedia.Types.IVideoProperties.Types.FieldType source)
	{
		return source switch
		{
			IMedia.Types.IVideoProperties.Types.FieldType.Unknown => Media.Types.VideoProperties.Types.FieldType.Unknown, 
			IMedia.Types.IVideoProperties.Types.FieldType.Progressive => Media.Types.VideoProperties.Types.FieldType.Progressive, 
			IMedia.Types.IVideoProperties.Types.FieldType.InterlacedUpperFirst => Media.Types.VideoProperties.Types.FieldType.InterlacedUpperFirst, 
			IMedia.Types.IVideoProperties.Types.FieldType.InterlacedLowerFirst => Media.Types.VideoProperties.Types.FieldType.InterlacedLowerFirst, 
			_ => Media.Types.VideoProperties.Types.FieldType.Unknown, 
		};
	}

	public static IMedia.Types.IVideoProperties.Types.FieldType ToEntity(this Media.Types.VideoProperties.Types.FieldType source)
	{
		return source switch
		{
			Media.Types.VideoProperties.Types.FieldType.Unknown => IMedia.Types.IVideoProperties.Types.FieldType.Unknown, 
			Media.Types.VideoProperties.Types.FieldType.Progressive => IMedia.Types.IVideoProperties.Types.FieldType.Progressive, 
			Media.Types.VideoProperties.Types.FieldType.InterlacedUpperFirst => IMedia.Types.IVideoProperties.Types.FieldType.InterlacedUpperFirst, 
			Media.Types.VideoProperties.Types.FieldType.InterlacedLowerFirst => IMedia.Types.IVideoProperties.Types.FieldType.InterlacedLowerFirst, 
			_ => IMedia.Types.IVideoProperties.Types.FieldType.Unknown, 
		};
	}

	public static Media.Types.VideoProperties.Types.EndBehavior ToProto(this IMedia.Types.IVideoProperties.Types.EndBehavior source)
	{
		return source switch
		{
			IMedia.Types.IVideoProperties.Types.EndBehavior.Stop => Media.Types.VideoProperties.Types.EndBehavior.Stop, 
			IMedia.Types.IVideoProperties.Types.EndBehavior.StopOnBlack => Media.Types.VideoProperties.Types.EndBehavior.StopOnBlack, 
			IMedia.Types.IVideoProperties.Types.EndBehavior.StopOnClear => Media.Types.VideoProperties.Types.EndBehavior.StopOnClear, 
			IMedia.Types.IVideoProperties.Types.EndBehavior.FadeToBlack => Media.Types.VideoProperties.Types.EndBehavior.FadeToBlack, 
			IMedia.Types.IVideoProperties.Types.EndBehavior.FadeToClear => Media.Types.VideoProperties.Types.EndBehavior.FadeToClear, 
			_ => Media.Types.VideoProperties.Types.EndBehavior.Stop, 
		};
	}

	public static IMedia.Types.IVideoProperties.Types.EndBehavior ToEntity(this Media.Types.VideoProperties.Types.EndBehavior source)
	{
		return source switch
		{
			Media.Types.VideoProperties.Types.EndBehavior.Stop => IMedia.Types.IVideoProperties.Types.EndBehavior.Stop, 
			Media.Types.VideoProperties.Types.EndBehavior.StopOnBlack => IMedia.Types.IVideoProperties.Types.EndBehavior.StopOnBlack, 
			Media.Types.VideoProperties.Types.EndBehavior.StopOnClear => IMedia.Types.IVideoProperties.Types.EndBehavior.StopOnClear, 
			Media.Types.VideoProperties.Types.EndBehavior.FadeToBlack => IMedia.Types.IVideoProperties.Types.EndBehavior.FadeToBlack, 
			Media.Types.VideoProperties.Types.EndBehavior.FadeToClear => IMedia.Types.IVideoProperties.Types.EndBehavior.FadeToClear, 
			_ => IMedia.Types.IVideoProperties.Types.EndBehavior.Stop, 
		};
	}
}
