namespace Pro.Entity.CrdtKeySerializers;

internal sealed class StringCrdtKeySerializer : ICrdtKeySerializer<string>
{
	public string Serialize(string key)
	{
		return key;
	}

	public bool TryDeserialize(string key, out string result)
	{
		result = key;
		return true;
	}
}
