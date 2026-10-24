using System;
using System.Linq;

namespace Pro.Serialization.Control;

public class KnownTypesAttribute : ControlAttributeBase
{
	public Type[] KnownTypes { get; }

	public KnownTypesAttribute(Type type, params Type[] additionalTypes)
	{
		KnownTypes = additionalTypes.Concat(new Type[1] { type }).ToArray();
	}
}
