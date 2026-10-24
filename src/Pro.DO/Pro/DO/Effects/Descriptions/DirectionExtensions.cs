using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;

namespace Pro.DO.Effects.Descriptions;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(Direction), typeof(IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection), SourceToDestinationMethodName = "ToEntityDirection", DestinationDefaultValue = "None", DestinationToSourceMethodName = "ToDirection", SourceDefaultValue = "None")]
public static class DirectionExtensions
{
	public static IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection ToEntityDirection(this Direction source)
	{
		return source switch
		{
			Direction.None => IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.None, 
			Direction.TopLeft => IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.TopLeft, 
			Direction.Top => IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.Top, 
			Direction.TopRight => IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.TopRight, 
			Direction.Left => IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.Left, 
			Direction.Center => IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.Center, 
			Direction.Right => IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.Right, 
			Direction.BottomLeft => IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.BottomLeft, 
			Direction.Bottom => IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.Bottom, 
			Direction.BottomRight => IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.BottomRight, 
			_ => IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.None, 
		};
	}

	public static Direction ToDirection(this IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection source)
	{
		return source switch
		{
			IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.None => Direction.None, 
			IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.TopLeft => Direction.TopLeft, 
			IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.Top => Direction.Top, 
			IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.TopRight => Direction.TopRight, 
			IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.Left => Direction.Left, 
			IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.Center => Direction.Center, 
			IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.Right => Direction.Right, 
			IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.BottomLeft => Direction.BottomLeft, 
			IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.Bottom => Direction.Bottom, 
			IEffect.Types.IEffectVariable.Types.IEffectDirection.Types.EffectDirection.BottomRight => Direction.BottomRight, 
			_ => Direction.None, 
		};
	}
}
