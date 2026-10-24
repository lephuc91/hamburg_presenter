using System.Diagnostics.CodeAnalysis;

namespace Pro.Entity.CrdtKeySerializers;

public interface ICrdtKeySerializer<TKey>
{
	string Serialize(TKey key);

	bool TryDeserialize(string key, [MaybeNullWhen(false)] out TKey result);
}
