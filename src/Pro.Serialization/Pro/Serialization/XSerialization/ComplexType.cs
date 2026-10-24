using System.Collections.Generic;
using System.Linq;

namespace Pro.Serialization.XSerialization;

internal class ComplexType
{
	public PropertyMetadata[] Traits { get; }

	public ChildPropertyMetadata[] Children { get; }

	public CollectionPropertyMetadata[] Collections { get; }

	public PropertyMetadata? Text { get; }

	public ComplexType(IEnumerable<PropertyMetadata> traits, IEnumerable<ChildPropertyMetadata> children, IEnumerable<CollectionPropertyMetadata> collections, PropertyMetadata? text)
	{
		Traits = traits.ToArray();
		Children = children.ToArray();
		Collections = collections.ToArray();
		Text = text;
	}
}
