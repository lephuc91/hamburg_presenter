using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Extensions.ProtoEntityConversion;

public static class CollectionTypeExtensions
{
	public static ICollectionElementType ToEntityCollectionType(this CollectionElementType type, IEntityFactory entityFactory)
	{
		ICollectionElementType collectionElementType = entityFactory.Create<ICollectionElementType>();
		collectionElementType.ParameterName.Set(type.ParameterName);
		collectionElementType.ParameterUuid.Set(type.ParameterUuid?.ToGuid());
		collectionElementType.ParentCollection.Set(type.ParentCollection?.ToEntityCollectionType(entityFactory));
		return collectionElementType;
	}

	public static CollectionElementType ToProtoCollectionType(this ICollectionElementType type)
	{
		CollectionElementType collectionElementType = new CollectionElementType
		{
			ParameterName = (type.ParameterName.Value ?? string.Empty)
		};
		if (type.ParameterUuid.Value.HasValue)
		{
			collectionElementType.ParameterUuid = type.ParameterUuid.Value?.ToUUID();
		}
		if (type.ParentCollection.Value != null)
		{
			collectionElementType.ParentCollection = type.ParentCollection.Value.ToProtoCollectionType();
		}
		return collectionElementType;
	}
}
