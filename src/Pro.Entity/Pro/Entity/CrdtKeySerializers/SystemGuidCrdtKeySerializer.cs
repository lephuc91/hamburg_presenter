using System;

namespace Pro.Entity.CrdtKeySerializers;

internal sealed class SystemGuidCrdtKeySerializer : ICrdtKeySerializer<Guid>
{
	public string Serialize(Guid key)
	{
		return key.ToString("D");
	}

	public bool TryDeserialize(string key, out Guid result)
	{
		return Guid.TryParse(key, out result);
	}
}
