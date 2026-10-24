using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Triggering;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(CompletionAction), typeof(Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionActionType), SourceToDestinationMethodName = "ToProtoCompletionActionType", DestinationDefaultValue = "First", DestinationToSourceMethodName = "ToCompletionAction", SourceDefaultValue = "First")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(CompletionAction), typeof(ICue.Types.CompletionActionType), SourceToDestinationMethodName = "ToEntityCompletionActionType", DestinationDefaultValue = "First", DestinationToSourceMethodName = "ToCompletionAction", SourceDefaultValue = "First")]
public static class CompletionActionExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionActionType ToProtoCompletionActionType(this CompletionAction source)
	{
		return source switch
		{
			CompletionAction.First => Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionActionType.First, 
			CompletionAction.Last => Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionActionType.Last, 
			CompletionAction.AfterAction => Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionActionType.AfterAction, 
			CompletionAction.AfterTime => Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionActionType.AfterTime, 
			_ => Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionActionType.First, 
		};
	}

	public static CompletionAction ToCompletionAction(this Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionActionType source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionActionType.First => CompletionAction.First, 
			Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionActionType.Last => CompletionAction.Last, 
			Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionActionType.AfterAction => CompletionAction.AfterAction, 
			Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionActionType.AfterTime => CompletionAction.AfterTime, 
			_ => CompletionAction.First, 
		};
	}

	public static ICue.Types.CompletionActionType ToEntityCompletionActionType(this CompletionAction source)
	{
		return source switch
		{
			CompletionAction.First => ICue.Types.CompletionActionType.First, 
			CompletionAction.Last => ICue.Types.CompletionActionType.Last, 
			CompletionAction.AfterAction => ICue.Types.CompletionActionType.AfterAction, 
			CompletionAction.AfterTime => ICue.Types.CompletionActionType.AfterTime, 
			_ => ICue.Types.CompletionActionType.First, 
		};
	}

	public static CompletionAction ToCompletionAction(this ICue.Types.CompletionActionType source)
	{
		return source switch
		{
			ICue.Types.CompletionActionType.First => CompletionAction.First, 
			ICue.Types.CompletionActionType.Last => CompletionAction.Last, 
			ICue.Types.CompletionActionType.AfterAction => CompletionAction.AfterAction, 
			ICue.Types.CompletionActionType.AfterTime => CompletionAction.AfterTime, 
			_ => CompletionAction.First, 
		};
	}
}
