namespace Pro.Entity.CrdtKeySerializers;

internal sealed class BoolCrdtKeySerializer : ICrdtKeySerializer<bool>
{
	public string Serialize(bool key)
	{
		if (!key)
		{
			return "false";
		}
		return "true";
	}

	public bool TryDeserialize(string key, out bool result)
	{
		return bool.TryParse(key, out result);
	}
}
