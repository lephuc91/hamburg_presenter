using System.Globalization;

namespace Pro.Entity.CrdtKeySerializers;

internal sealed class LongCrdtKeySerializer : ICrdtKeySerializer<long>
{
	public string Serialize(long key)
	{
		return key.ToString(CultureInfo.InvariantCulture);
	}

	public bool TryDeserialize(string key, out long result)
	{
		return long.TryParse(key, NumberStyles.Integer, CultureInfo.InvariantCulture, out result);
	}
}
