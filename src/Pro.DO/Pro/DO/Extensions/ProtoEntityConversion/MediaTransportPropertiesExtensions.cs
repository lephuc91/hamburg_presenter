using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Extensions.ProtoEntityConversion;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(IMedia.Types.ITransportProperties.Types.PlaybackBehavior), typeof(Media.Types.TransportProperties.Types.PlaybackBehavior), SourceToDestinationMethodName = "ToProto", DestinationDefaultValue = "Loop", DestinationToSourceMethodName = "ToEntity", SourceDefaultValue = "Loop")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(IMedia.Types.ITransportProperties.Types.RetriggerSetting), typeof(Media.Types.TransportProperties.Types.RetriggerSetting), SourceToDestinationMethodName = "ToProto", DestinationDefaultValue = "Unset", DestinationToSourceMethodName = "ToEntity", SourceDefaultValue = "Unset")]
public static class MediaTransportPropertiesExtensions
{
	public static Media.Types.TransportProperties ToProto(this IMedia.Types.ITransportProperties source)
	{
		return new Media.Types.TransportProperties
		{
			PlayRate = source.PlayRate.Value,
			InPoint = source.InPoint.Value,
			OutPoint = source.OutPoint.Value,
			FadeInDuration = source.FadeInDuration.Value,
			FadeOutDuration = source.FadeOutDuration.Value,
			EndPoint = source.EndPoint.Value,
			PlaybackBehavior = source.PlaybackBehavior.Value.ToProto(),
			LoopTime = source.LoopTime.Value,
			TimesToLoop = source.TimesToLoop.Value,
			Retrigger = source.Retrigger.Value.ToProto()
		};
	}

	public static IMedia.Types.ITransportProperties ToEntity(this Media.Types.TransportProperties source, IEntityFactory entityFactory)
	{
		IMedia.Types.ITransportProperties transportProperties = entityFactory.Create<IMedia.Types.ITransportProperties>();
		transportProperties.PlayRate.Set(source.PlayRate);
		transportProperties.InPoint.Set(source.InPoint);
		transportProperties.OutPoint.Set(source.OutPoint);
		transportProperties.FadeInDuration.Set(source.FadeInDuration);
		transportProperties.FadeOutDuration.Set(source.FadeOutDuration);
		transportProperties.EndPoint.Set(source.EndPoint);
		transportProperties.PlaybackBehavior.Set(source.PlaybackBehavior.ToEntity());
		transportProperties.LoopTime.Set(source.LoopTime);
		transportProperties.TimesToLoop.Set(source.TimesToLoop);
		transportProperties.Retrigger.Set(source.Retrigger.ToEntity());
		return transportProperties;
	}

	public static Media.Types.TransportProperties.Types.PlaybackBehavior ToProto(this IMedia.Types.ITransportProperties.Types.PlaybackBehavior source)
	{
		return source switch
		{
			IMedia.Types.ITransportProperties.Types.PlaybackBehavior.Stop => Media.Types.TransportProperties.Types.PlaybackBehavior.Stop, 
			IMedia.Types.ITransportProperties.Types.PlaybackBehavior.Loop => Media.Types.TransportProperties.Types.PlaybackBehavior.Loop, 
			IMedia.Types.ITransportProperties.Types.PlaybackBehavior.LoopForCount => Media.Types.TransportProperties.Types.PlaybackBehavior.LoopForCount, 
			IMedia.Types.ITransportProperties.Types.PlaybackBehavior.LoopForTime => Media.Types.TransportProperties.Types.PlaybackBehavior.LoopForTime, 
			_ => Media.Types.TransportProperties.Types.PlaybackBehavior.Loop, 
		};
	}

	public static IMedia.Types.ITransportProperties.Types.PlaybackBehavior ToEntity(this Media.Types.TransportProperties.Types.PlaybackBehavior source)
	{
		return source switch
		{
			Media.Types.TransportProperties.Types.PlaybackBehavior.Stop => IMedia.Types.ITransportProperties.Types.PlaybackBehavior.Stop, 
			Media.Types.TransportProperties.Types.PlaybackBehavior.Loop => IMedia.Types.ITransportProperties.Types.PlaybackBehavior.Loop, 
			Media.Types.TransportProperties.Types.PlaybackBehavior.LoopForCount => IMedia.Types.ITransportProperties.Types.PlaybackBehavior.LoopForCount, 
			Media.Types.TransportProperties.Types.PlaybackBehavior.LoopForTime => IMedia.Types.ITransportProperties.Types.PlaybackBehavior.LoopForTime, 
			_ => IMedia.Types.ITransportProperties.Types.PlaybackBehavior.Loop, 
		};
	}

	public static Media.Types.TransportProperties.Types.RetriggerSetting ToProto(this IMedia.Types.ITransportProperties.Types.RetriggerSetting source)
	{
		return source switch
		{
			IMedia.Types.ITransportProperties.Types.RetriggerSetting.Unset => Media.Types.TransportProperties.Types.RetriggerSetting.Unset, 
			IMedia.Types.ITransportProperties.Types.RetriggerSetting.Always => Media.Types.TransportProperties.Types.RetriggerSetting.Always, 
			IMedia.Types.ITransportProperties.Types.RetriggerSetting.Never => Media.Types.TransportProperties.Types.RetriggerSetting.Never, 
			IMedia.Types.ITransportProperties.Types.RetriggerSetting.Automatic => Media.Types.TransportProperties.Types.RetriggerSetting.Automatic, 
			_ => Media.Types.TransportProperties.Types.RetriggerSetting.Unset, 
		};
	}

	public static IMedia.Types.ITransportProperties.Types.RetriggerSetting ToEntity(this Media.Types.TransportProperties.Types.RetriggerSetting source)
	{
		return source switch
		{
			Media.Types.TransportProperties.Types.RetriggerSetting.Unset => IMedia.Types.ITransportProperties.Types.RetriggerSetting.Unset, 
			Media.Types.TransportProperties.Types.RetriggerSetting.Always => IMedia.Types.ITransportProperties.Types.RetriggerSetting.Always, 
			Media.Types.TransportProperties.Types.RetriggerSetting.Never => IMedia.Types.ITransportProperties.Types.RetriggerSetting.Never, 
			Media.Types.TransportProperties.Types.RetriggerSetting.Automatic => IMedia.Types.ITransportProperties.Types.RetriggerSetting.Automatic, 
			_ => IMedia.Types.ITransportProperties.Types.RetriggerSetting.Unset, 
		};
	}
}
