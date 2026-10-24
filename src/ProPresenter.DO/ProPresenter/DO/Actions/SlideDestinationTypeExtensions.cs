using System;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Actions;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(SlideDestinationType), typeof(Pro.SerializationInterop.RVProtoData.Action.Types.StageLayoutType.Types.SlideTarget), SourceToDestinationMethodName = "ToProtoSlideTarget", DestinationToSourceMethodName = "ToSlideDestinationType")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(SlideDestinationType), typeof(IAction.Types.IStageLayoutType.Types.SlideTarget), SourceToDestinationMethodName = "ToEntitySlideTarget", DestinationDefaultValue = "All", DestinationToSourceMethodName = "ToSlideDestinationType", SourceDefaultValue = "All")]
public static class SlideDestinationTypeExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Action.Types.StageLayoutType.Types.SlideTarget ToProtoSlideTarget(this SlideDestinationType source)
	{
		return source switch
		{
			SlideDestinationType.NoChange => Pro.SerializationInterop.RVProtoData.Action.Types.StageLayoutType.Types.SlideTarget.NoChange, 
			SlideDestinationType.StageOnly => Pro.SerializationInterop.RVProtoData.Action.Types.StageLayoutType.Types.SlideTarget.StageOnly, 
			SlideDestinationType.All => Pro.SerializationInterop.RVProtoData.Action.Types.StageLayoutType.Types.SlideTarget.All, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static SlideDestinationType ToSlideDestinationType(this Pro.SerializationInterop.RVProtoData.Action.Types.StageLayoutType.Types.SlideTarget source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Action.Types.StageLayoutType.Types.SlideTarget.NoChange => SlideDestinationType.NoChange, 
			Pro.SerializationInterop.RVProtoData.Action.Types.StageLayoutType.Types.SlideTarget.StageOnly => SlideDestinationType.StageOnly, 
			Pro.SerializationInterop.RVProtoData.Action.Types.StageLayoutType.Types.SlideTarget.All => SlideDestinationType.All, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static IAction.Types.IStageLayoutType.Types.SlideTarget ToEntitySlideTarget(this SlideDestinationType source)
	{
		return source switch
		{
			SlideDestinationType.NoChange => IAction.Types.IStageLayoutType.Types.SlideTarget.NoChange, 
			SlideDestinationType.StageOnly => IAction.Types.IStageLayoutType.Types.SlideTarget.StageOnly, 
			SlideDestinationType.All => IAction.Types.IStageLayoutType.Types.SlideTarget.All, 
			_ => IAction.Types.IStageLayoutType.Types.SlideTarget.All, 
		};
	}

	public static SlideDestinationType ToSlideDestinationType(this IAction.Types.IStageLayoutType.Types.SlideTarget source)
	{
		return source switch
		{
			IAction.Types.IStageLayoutType.Types.SlideTarget.NoChange => SlideDestinationType.NoChange, 
			IAction.Types.IStageLayoutType.Types.SlideTarget.StageOnly => SlideDestinationType.StageOnly, 
			IAction.Types.IStageLayoutType.Types.SlideTarget.All => SlideDestinationType.All, 
			_ => SlideDestinationType.All, 
		};
	}
}
