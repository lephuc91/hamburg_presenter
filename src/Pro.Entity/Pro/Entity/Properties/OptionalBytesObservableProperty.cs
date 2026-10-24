using System;
using System.Linq;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Properties;

internal class OptionalBytesObservableProperty : ValueObservableProperty<byte[]?>
{
	public OptionalBytesObservableProperty(string key, LoroMap map)
		: base(key, map, (Func<LoroValue?, byte[]>)LoroValueExtensions.ToNullableByteArray, (Func<byte[], LoroValue>)ByteArrayExtensions.ToLoroValue)
	{
	}

	public override string ToString()
	{
		if (base.Value != null)
		{
			return "{" + string.Join(",", base.Value.Select((byte b) => b.ToString("X2"))) + "}";
		}
		return "null";
	}

	protected override bool ValueEquals(byte[]? a, byte[]? b)
	{
		return a.AreSame(b);
	}
}
