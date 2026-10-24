using System.Collections.Generic;

namespace Pro.Loro;

public interface IEphemeralStore
{
	void Apply(byte[] data);

	void Delete(string key);

	byte[] Encode(string key);

	byte[] EncodeAll();

	LoroValue? Get(string key);

	Dictionary<string, LoroValue> GetAllStates();

	List<string> Keys();

	void RemoveOutdated();

	void Set(string key, LoroValueLike value);

	Subscription Subscribe(EphemeralSubscriber listener);

	Subscription SubscribeLocalUpdate(LocalEphemeralListener listener);
}
