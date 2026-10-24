using System;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Media;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(TriggerLayer), typeof(Pro.SerializationInterop.RVProtoData.Action.Types.LayerType), SourceToDestinationMethodName = "ToProtoLayerType", DestinationToSourceMethodName = "ToTriggerLayer")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(TriggerLayer), typeof(IAction.Types.LayerType), SourceToDestinationMethodName = "ToEntityLayerType", DestinationToSourceMethodName = "ToTriggerLayer", SourceDefaultValue = "Background", DestinationDefaultValue = "Background")]
public static class TriggerLayerExtensions
{
	public static TriggerLayer ToTriggerLayer(this MediaType mediaType)
	{
		switch (mediaType)
		{
		case MediaType.Image:
		case MediaType.Video:
		case MediaType.Audio:
		case MediaType.Web:
			return TriggerLayer.Background;
		case MediaType.LiveVideo:
			return TriggerLayer.Input;
		default:
			throw new NotSupportedException();
		}
	}

	public static Pro.SerializationInterop.RVProtoData.Action.Types.LayerType ToProtoLayerType(this TriggerLayer source)
	{
		return source switch
		{
			TriggerLayer.Background => Pro.SerializationInterop.RVProtoData.Action.Types.LayerType.Background, 
			TriggerLayer.Foreground => Pro.SerializationInterop.RVProtoData.Action.Types.LayerType.Foreground, 
			TriggerLayer.Fill => Pro.SerializationInterop.RVProtoData.Action.Types.LayerType.Fill, 
			TriggerLayer.Input => Pro.SerializationInterop.RVProtoData.Action.Types.LayerType.Input, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static TriggerLayer ToTriggerLayer(this Pro.SerializationInterop.RVProtoData.Action.Types.LayerType source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Action.Types.LayerType.Background => TriggerLayer.Background, 
			Pro.SerializationInterop.RVProtoData.Action.Types.LayerType.Foreground => TriggerLayer.Foreground, 
			Pro.SerializationInterop.RVProtoData.Action.Types.LayerType.Fill => TriggerLayer.Fill, 
			Pro.SerializationInterop.RVProtoData.Action.Types.LayerType.Input => TriggerLayer.Input, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static IAction.Types.LayerType ToEntityLayerType(this TriggerLayer source)
	{
		return source switch
		{
			TriggerLayer.Background => IAction.Types.LayerType.Background, 
			TriggerLayer.Foreground => IAction.Types.LayerType.Foreground, 
			TriggerLayer.Fill => IAction.Types.LayerType.Fill, 
			TriggerLayer.Input => IAction.Types.LayerType.Input, 
			_ => IAction.Types.LayerType.Background, 
		};
	}

	public static TriggerLayer ToTriggerLayer(this IAction.Types.LayerType source)
	{
		return source switch
		{
			IAction.Types.LayerType.Background => TriggerLayer.Background, 
			IAction.Types.LayerType.Foreground => TriggerLayer.Foreground, 
			IAction.Types.LayerType.Fill => TriggerLayer.Fill, 
			IAction.Types.LayerType.Input => TriggerLayer.Input, 
			_ => TriggerLayer.Background, 
		};
	}
}
