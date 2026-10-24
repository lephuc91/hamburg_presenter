using System.Globalization;

namespace Pro.Entity.CrdtKeySerializers;

internal sealed class IntCrdtKeySerializer : ICrdtKeySerializer<int>
{
	public string Serialize(int key)
	{
		return key.ToString(CultureInfo.InvariantCulture);
	}

	public bool TryDeserialize(string key, out int result)
	{
		return int.TryParse(key, NumberStyles.Integer, CultureInfo.InvariantCulture, out result);
	}
}
