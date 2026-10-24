using System;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Extensions.ProtoEntityConversion;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection), typeof(Effect.Types.EffectVariable.Types.EffectDirection.Types.EffectDirection), SourceToDestinationMethodName = "ToProtoDirection", DestinationToSourceMethodName = "ToEntityDirection")]
public static class EffectDirectionExtensions
{
	public static Effect.Types.EffectVariable.Types.EffectDirection.Types.EffectDirection ToProtoDirection(this IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection source)
	{
		return source switch
		{
			IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.None => Effect.Types.EffectVariable.Types.EffectDirection.Types.EffectDirection.None, 
			IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.TopLeft => Effect.Types.EffectVariable.Types.EffectDirection.Types.EffectDirection.TopLeft, 
			IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.Top => Effect.Types.EffectVariable.Types.EffectDirection.Types.EffectDirection.Top, 
			IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.TopRight => Effect.Types.EffectVariable.Types.EffectDirection.Types.EffectDirection.TopRight, 
			IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.Left => Effect.Types.EffectVariable.Types.EffectDirection.Types.EffectDirection.Left, 
			IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.Center => Effect.Types.EffectVariable.Types.EffectDirection.Types.EffectDirection.Center, 
			IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.Right => Effect.Types.EffectVariable.Types.EffectDirection.Types.EffectDirection.Right, 
			IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.BottomLeft => Effect.Types.EffectVariable.Types.EffectDirection.Types.EffectDirection.BottomLeft, 
			IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.Bottom => Effect.Types.EffectVariable.Types.EffectDirection.Types.EffectDirection.Bottom, 
			IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.BottomRight => Effect.Types.EffectVariable.Types.EffectDirection.Types.EffectDirection.BottomRight, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection ToEntityDirection(this Effect.Types.EffectVariable.Types.EffectDirection.Types.EffectDirection source)
	{
		return source switch
		{
			Effect.Types.EffectVariable.Types.EffectDirection.Types.EffectDirection.None => IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.None, 
			Effect.Types.EffectVariable.Types.EffectDirection.Types.EffectDirection.TopLeft => IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.TopLeft, 
			Effect.Types.EffectVariable.Types.EffectDirection.Types.EffectDirection.Top => IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.Top, 
			Effect.Types.EffectVariable.Types.EffectDirection.Types.EffectDirection.TopRight => IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.TopRight, 
			Effect.Types.EffectVariable.Types.EffectDirection.Types.EffectDirection.Left => IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.Left, 
			Effect.Types.EffectVariable.Types.EffectDirection.Types.EffectDirection.Center => IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.Center, 
			Effect.Types.EffectVariable.Types.EffectDirection.Types.EffectDirection.Right => IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.Right, 
			Effect.Types.EffectVariable.Types.EffectDirection.Types.EffectDirection.BottomLeft => IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.BottomLeft, 
			Effect.Types.EffectVariable.Types.EffectDirection.Types.EffectDirection.Bottom => IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.Bottom, 
			Effect.Types.EffectVariable.Types.EffectDirection.Types.EffectDirection.BottomRight => IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.BottomRight, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}
}
