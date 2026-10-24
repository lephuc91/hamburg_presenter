using System;
using System.Linq;

namespace Pro.Serialization.XSerialization;

internal class CollectionPropertyMetadata : PropertyMetadata
{
	public bool IsMixed { get; }

	public Type ItemType { get; }

	public Type[] SubTypes { get; }

	public CollectionPropertyMetadata(PropertyMetadata metadata, bool isMixed, Type itemType, Type[]? subTypes)
		: base(metadata.NameAlias, metadata.TypeAlias, metadata.IsOptional, metadata.IsEscaped, metadata.IsNameDisplayed, metadata.StaticHeaders, metadata.Getter, metadata.Setter)
	{
		IsMixed = isMixed;
		ItemType = itemType;
		SubTypes = subTypes ?? new Type[0];
		if (SubTypes.Any((Type t) => !itemType.IsAssignableFrom(t)))
		{
			throw new Exception("One or more subtypes can not be assigned to the item type");
		}
	}
}
