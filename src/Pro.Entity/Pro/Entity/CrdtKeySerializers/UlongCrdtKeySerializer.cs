using System.Globalization;

namespace Pro.Entity.CrdtKeySerializers;

internal sealed class UlongCrdtKeySerializer : ICrdtKeySerializer<ulong>
{
	public string Serialize(ulong key)
	{
		return key.ToString(CultureInfo.InvariantCulture);
	}

	public bool TryDeserialize(string key, out ulong result)
	{
		return ulong.TryParse(key, NumberStyles.Integer, CultureInfo.InvariantCulture, out result);
	}
}
