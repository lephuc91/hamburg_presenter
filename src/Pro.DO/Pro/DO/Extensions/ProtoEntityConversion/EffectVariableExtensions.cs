using System;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Extensions.ProtoEntityConversion;

public static class EffectVariableExtensions
{
	public static Effect.Types.EffectVariable ToProtoVariable(this IEffect.Types.IEffectVariable source)
	{
		Effect.Types.EffectVariable obj = new Effect.Types.EffectVariable
		{
			Name = source.Name.Value,
			Description = source.Description.Value
		};
		SerializeType(obj, source);
		return obj;
	}

	public static IEffect.Types.IEffectVariable ToEntityVariable(this Effect.Types.EffectVariable source, IEntityFactory entityFactory)
	{
		IEffect.Types.IEffectVariable effectVariable = entityFactory.Create<IEffect.Types.IEffectVariable>();
		effectVariable.Name.Set(source.Name);
		effectVariable.Description.Set(source.Description);
		effectVariable.Type.Set(GetVariableType(source, entityFactory));
		return effectVariable;
	}

	private static void SerializeType(Effect.Types.EffectVariable variable, IEffect.Types.IEffectVariable source)
	{
		IEffect.Types.IEffectVariable.Types.IType value = source.Type.Value;
		if (!(value is IEffect.Types.IEffectVariable.Types.IType.IInt @int))
		{
			if (!(value is IEffect.Types.IEffectVariable.Types.IType.IFloat @float))
			{
				if (!(value is IEffect.Types.IEffectVariable.Types.IType.IColor color))
				{
					if (!(value is IEffect.Types.IEffectVariable.Types.IType.IDirection direction))
					{
						if (value is IEffect.Types.IEffectVariable.Types.IType.IDouble @double)
						{
							variable.Double = new Effect.Types.EffectVariable.Types.EffectDouble
							{
								Value = @double.Value.Value.Value,
								DefaultValue = @double.Value.DefaultValue.Value,
								Min = @double.Value.Min.Value,
								Max = @double.Value.Max.Value
							};
						}
					}
					else
					{
						variable.Direction = new Effect.Types.EffectVariable.Types.EffectDirection
						{
							Direction = direction.Value.Direction.Value.ToProtoDirection(),
							DefaultDirection = direction.Value.DefaultDirection.Value.ToProtoDirection()
						};
					}
				}
				else
				{
					variable.Color = new Effect.Types.EffectVariable.Types.EffectColor
					{
						Color = color.Value.Color.Value.ToProtoColor(),
						DefaultColor = color.Value.DefaultColor.Value.ToProtoColor()
					};
				}
			}
			else
			{
				variable.Float = new Effect.Types.EffectVariable.Types.EffectFloat
				{
					Value = @float.Value.Value.Value,
					DefaultValue = @float.Value.DefaultValue.Value,
					Min = @float.Value.Min.Value,
					Max = @float.Value.Max.Value
				};
			}
		}
		else
		{
			variable.Int = new Effect.Types.EffectVariable.Types.EffectInt
			{
				Value = @int.Value.Value.Value,
				DefaultValue = @int.Value.DefaultValue.Value,
				Min = @int.Value.Min.Value,
				Max = @int.Value.Max.Value
			};
		}
	}

	private static IEffect.Types.IEffectVariable.Types.IType GetVariableType(Effect.Types.EffectVariable source, IEntityFactory entityFactory)
	{
		switch (source.TypeCase)
		{
		case Effect.Types.EffectVariable.TypeOneofCase.Float:
		{
			IEffect.Types.IEffectVariable.Types.IType.IFloat @float = entityFactory.Create<IEffect.Types.IEffectVariable.Types.IType.IFloat>();
			@float.Value.Value.Set(source.Float.Value);
			@float.Value.DefaultValue.Set(source.Float.DefaultValue);
			@float.Value.Min.Set(source.Float.Min);
			@float.Value.Max.Set(source.Float.Max);
			return @float;
		}
		case Effect.Types.EffectVariable.TypeOneofCase.Int:
		{
			IEffect.Types.IEffectVariable.Types.IType.IInt @int = entityFactory.Create<IEffect.Types.IEffectVariable.Types.IType.IInt>();
			@int.Value.Value.Set(source.Int.Value);
			@int.Value.DefaultValue.Set(source.Int.DefaultValue);
			@int.Value.Min.Set(source.Int.Min);
			@int.Value.Max.Set(source.Int.Max);
			return @int;
		}
		case Effect.Types.EffectVariable.TypeOneofCase.Color:
		{
			IEffect.Types.IEffectVariable.Types.IType.IColor color = entityFactory.Create<IEffect.Types.IEffectVariable.Types.IType.IColor>();
			color.Value.Color.Set(source.Color.Color.ToEntityColor());
			color.Value.DefaultColor.Set(source.Color.DefaultColor.ToEntityColor());
			return color;
		}
		case Effect.Types.EffectVariable.TypeOneofCase.Direction:
		{
			IEffect.Types.IEffectVariable.Types.IType.IDirection direction = entityFactory.Create<IEffect.Types.IEffectVariable.Types.IType.IDirection>();
			direction.Value.Direction.Set(source.Direction.Direction.ToEntityDirection());
			direction.Value.DefaultDirection.Set(source.Direction.DefaultDirection.ToEntityDirection());
			return direction;
		}
		case Effect.Types.EffectVariable.TypeOneofCase.Double:
		{
			IEffect.Types.IEffectVariable.Types.IType.IDouble @double = entityFactory.Create<IEffect.Types.IEffectVariable.Types.IType.IDouble>();
			@double.Value.Value.Set(source.Double.Value);
			@double.Value.DefaultValue.Set(source.Double.DefaultValue);
			@double.Value.Min.Set(source.Double.Min);
			@double.Value.Max.Set(source.Double.Max);
			return @double;
		}
		default:
			throw new NotSupportedException();
		}
	}
}
