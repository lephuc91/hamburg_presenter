using System;
using System.Linq;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Properties;

internal class BytesObservableProperty : ValueObservableProperty<byte[]>
{
	public BytesObservableProperty(string key, LoroMap map)
		: base(key, map, (Func<LoroValue?, byte[]>)LoroValueExtensions.ToByteArray, (Func<byte[], LoroValue>)ByteArrayExtensions.ToLoroValue)
	{
	}

	public override string ToString()
	{
		return "{" + string.Join(",", base.Value.Select((byte b) => b.ToString("X2"))) + "}";
	}

	protected override bool ValueEquals(byte[] a, byte[] b)
	{
		return a.SequenceEqual(b);
	}
}
