using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Triggering;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(CompletionTargetType), typeof(Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionTargetType), SourceToDestinationMethodName = "ToProtoCompletionTargetType", DestinationDefaultValue = "None", DestinationToSourceMethodName = "ToCompletionTargetType", SourceDefaultValue = "None")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(CompletionTargetType), typeof(ICue.Types.CompletionTargetType), SourceToDestinationMethodName = "ToEntityCompletionTargetType", DestinationDefaultValue = "None", DestinationToSourceMethodName = "ToCompletionTargetType", SourceDefaultValue = "None")]
public static class CompletionTargetTypeExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionTargetType ToProtoCompletionTargetType(this CompletionTargetType source)
	{
		return source switch
		{
			CompletionTargetType.None => Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionTargetType.None, 
			CompletionTargetType.Next => Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionTargetType.Next, 
			CompletionTargetType.Random => Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionTargetType.Random, 
			CompletionTargetType.Cue => Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionTargetType.Cue, 
			CompletionTargetType.First => Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionTargetType.First, 
			_ => Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionTargetType.None, 
		};
	}

	public static CompletionTargetType ToCompletionTargetType(this Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionTargetType source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionTargetType.None => CompletionTargetType.None, 
			Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionTargetType.Next => CompletionTargetType.Next, 
			Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionTargetType.Random => CompletionTargetType.Random, 
			Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionTargetType.Cue => CompletionTargetType.Cue, 
			Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionTargetType.First => CompletionTargetType.First, 
			_ => CompletionTargetType.None, 
		};
	}

	public static ICue.Types.CompletionTargetType ToEntityCompletionTargetType(this CompletionTargetType source)
	{
		return source switch
		{
			CompletionTargetType.None => ICue.Types.CompletionTargetType.None, 
			CompletionTargetType.Next => ICue.Types.CompletionTargetType.Next, 
			CompletionTargetType.Random => ICue.Types.CompletionTargetType.Random, 
			CompletionTargetType.Cue => ICue.Types.CompletionTargetType.Cue, 
			CompletionTargetType.First => ICue.Types.CompletionTargetType.First, 
			_ => ICue.Types.CompletionTargetType.None, 
		};
	}

	public static CompletionTargetType ToCompletionTargetType(this ICue.Types.CompletionTargetType source)
	{
		return source switch
		{
			ICue.Types.CompletionTargetType.None => CompletionTargetType.None, 
			ICue.Types.CompletionTargetType.Next => CompletionTargetType.Next, 
			ICue.Types.CompletionTargetType.Random => CompletionTargetType.Random, 
			ICue.Types.CompletionTargetType.Cue => CompletionTargetType.Cue, 
			ICue.Types.CompletionTargetType.First => CompletionTargetType.First, 
			_ => CompletionTargetType.None, 
		};
	}
}
