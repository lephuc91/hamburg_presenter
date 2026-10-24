using System;
using Pro.Common.Components;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

public interface ILink : IRenderEquatable<ILink>, IRenderHashable, ICloneable<ILink>
{
	LinkType LinkType { get; }

	event System.Action LinkObjectUpdated;

	event System.Action VisualInvalidated;

	Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink Serialize();
}
