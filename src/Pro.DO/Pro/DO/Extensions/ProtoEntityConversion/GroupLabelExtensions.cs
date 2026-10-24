using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Extensions.ProtoEntityConversion;

public static class GroupLabelExtensions
{
	public static Group ToProto(this IGroup group)
	{
		Group group2 = new Group
		{
			Uuid = group.Uuid.Value.ToUUID(),
			Name = group.Name.Value,
			HotKey = group.HotKey.Value.ToProto()
		};
		if ((object)group.Color.Value != null)
		{
			group2.Color = group.Color.Value.ToProtoColor();
		}
		if (group.ApplicationGroupIdentifier.Value.HasValue)
		{
			group2.ApplicationGroupIdentifier = group.ApplicationGroupIdentifier.Value.Value.ToUUID();
		}
		return group2;
	}

	public static IGroup ToEntity(this Group protoGroup, IEntityFactory entityFactory)
	{
		IGroup group = entityFactory.Create<IGroup>();
		group.Uuid.Set(protoGroup.Uuid.ToGuid());
		group.Name.Set(protoGroup.Name);
		group.Color.Set(protoGroup.Color?.ToEntityColor());
		group.HotKey.Set(protoGroup.HotKey.ToEntity(entityFactory));
		group.ApplicationGroupIdentifier.Set(protoGroup.ApplicationGroupIdentifier?.ToGuid());
		return group;
	}
}
