using System;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Collections;

internal sealed class StringCollection : ValueCollection<string>
{
	public StringCollection(LoroMap containingMap, string key)
		: base(containingMap, key, (Func<string, LoroValue>)Serialize, (Func<ValueOrContainer?, string>)Deserialize)
	{
	}

	private static LoroValue Serialize(string value)
	{
		return value.ToLoroValue();
	}

	private static string Deserialize(ValueOrContainer? value)
	{
		return value.ToStringValue();
	}
}
