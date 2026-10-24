using System;
using Pro.DO.Triggering.CompletionTargets;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Triggering;

internal static class CompletionTargetFactory
{
	internal static CompletionTargetBase GenerateCompletionTarget(Pro.SerializationInterop.RVProtoData.Cue data)
	{
		return data.CompletionTargetType switch
		{
			Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionTargetType.None => new NoTarget(), 
			Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionTargetType.Next => new NextTarget(), 
			Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionTargetType.Random => new RandomTarget(), 
			Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionTargetType.Cue => new CueTarget(data.CompletionTargetUuid.ToGuid()), 
			Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionTargetType.First => new FirstTarget(), 
			_ => throw new NotSupportedException(), 
		};
	}

	internal static CompletionTargetBase GenerateCompletionTarget(ICue data)
	{
		return data.CompletionTargetType.Value switch
		{
			ICue.Types.CompletionTargetType.None => new NoTarget(), 
			ICue.Types.CompletionTargetType.Next => new NextTarget(), 
			ICue.Types.CompletionTargetType.Random => new RandomTarget(), 
			ICue.Types.CompletionTargetType.First => new FirstTarget(), 
			ICue.Types.CompletionTargetType.Cue => new CueTarget(data.CompletionTargetUuid.ToGuidOrEmpty()), 
			_ => throw new NotSupportedException(), 
		};
	}
}
