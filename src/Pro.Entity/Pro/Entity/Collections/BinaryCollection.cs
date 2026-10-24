using System;
using System.Collections.Generic;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Collections;

internal sealed class BinaryCollection : ValueCollection<byte[]>
{
	public BinaryCollection(LoroMap containingMap, string key)
		: base(containingMap, key, (Func<byte[], LoroValue>)Serialize, (Func<ValueOrContainer?, byte[]>)Deserialize)
	{
	}

	private static LoroValue Serialize(byte[] value)
	{
		return value.ToLoroValue();
	}

	private static byte[] Deserialize(ValueOrContainer? value)
	{
		return value.ToByteArray();
	}

	protected override bool Equal(IReadOnlyList<byte[]> a, IReadOnlyList<byte[]> b)
	{
		return a.SequenceBinaryEqual(b);
	}
}
