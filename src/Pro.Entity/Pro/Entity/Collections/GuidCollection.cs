using System;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Collections;

internal sealed class GuidCollection : ValueCollection<Guid>
{
	public GuidCollection(LoroMap containingMap, string key)
		: base(containingMap, key, (Func<Guid, LoroValue>)Serialize, (Func<ValueOrContainer?, Guid>)Deserialize)
	{
	}

	private static LoroValue Serialize(Guid value)
	{
		return value.ToLoroValue();
	}

	private static Guid Deserialize(ValueOrContainer? value)
	{
		return value.ToGuidValue();
	}
}
