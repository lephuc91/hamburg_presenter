using System.Globalization;

namespace Pro.Entity.CrdtKeySerializers;

internal sealed class UintCrdtKeySerializer : ICrdtKeySerializer<uint>
{
	public string Serialize(uint key)
	{
		return key.ToString(CultureInfo.InvariantCulture);
	}

	public bool TryDeserialize(string key, out uint result)
	{
		return uint.TryParse(key, NumberStyles.Integer, CultureInfo.InvariantCulture, out result);
	}
}
