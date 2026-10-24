using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Extensions.ProtoEntityConversion;

public static class TransitionExtensions
{
	public static Transition ToProtoTransition(this ITransition source)
	{
		Transition transition = new Transition
		{
			Duration = source.Duration.Value,
			Effect = source.Effect.Value.ToProtoEffect()
		};
		if (source.FavoriteUuid.Value.HasValue)
		{
			transition.FavoriteUuid = source.FavoriteUuid.Value.Value.ToUUID();
		}
		return transition;
	}

	public static ITransition ToEntityTransition(this Transition source, IEntityFactory entityFactory)
	{
		ITransition transition = entityFactory.Create<ITransition>();
		transition.Duration.Set(source.Duration);
		transition.Effect.Set(source.Effect.ToEntityEffect(entityFactory));
		transition.FavoriteUuid.Set(source.FavoriteUuid?.ToGuid());
		return transition;
	}
}
