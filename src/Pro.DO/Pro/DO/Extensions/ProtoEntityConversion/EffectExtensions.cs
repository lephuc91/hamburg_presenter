using System.Linq;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Extensions.ProtoEntityConversion;

public static class EffectExtensions
{
	public static Effect ToProtoEffect(this IEffect source)
	{
		Effect effect = new Effect();
		effect.Uuid = source.Uuid.Value.ToUUID();
		effect.Enabled = source.Enabled.Value;
		effect.Name = source.Name.Value;
		effect.RenderId = source.RenderId.Value;
		effect.BehaviorDescription = source.BehaviorDescription.Value;
		effect.Category = source.Category.Value;
		effect.Variables.AddRange(source.Variables.Items.Select((IEffect.Types.IEffectVariable v) => v.ToProtoVariable()));
		return effect;
	}

	public static IEffect ToEntityEffect(this Effect source, IEntityFactory entityFactory)
	{
		IEffect effect = entityFactory.Create<IEffect>();
		effect.Uuid.Set(source.Uuid.ToGuid());
		effect.Enabled.Set(source.Enabled);
		effect.Name.Set(source.Name);
		effect.RenderId.Set(source.RenderId);
		effect.BehaviorDescription.Set(source.BehaviorDescription);
		effect.Category.Set(source.Category);
		effect.Variables.Reset(source.Variables.Select((Effect.Types.EffectVariable v) => v.ToEntityVariable(entityFactory)));
		return effect;
	}
}
