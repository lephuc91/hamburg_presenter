using System.Collections.Generic;

namespace Pro.Loro;

public interface ILoroMap
{
	void Clear();

	void Delete(string key);

	LoroDoc? Doc();

	ValueOrContainer? Get(string key);

	LoroMap? GetAttached();

	LoroValue GetDeepValue();

	ulong? GetLastEditor(string key);

	LoroCounter GetOrCreateCounterContainer(string key, LoroCounter child);

	LoroList GetOrCreateListContainer(string key, LoroList child);

	LoroMap GetOrCreateMapContainer(string key, LoroMap child);

	LoroMovableList GetOrCreateMovableListContainer(string key, LoroMovableList child);

	LoroText GetOrCreateTextContainer(string key, LoroText child);

	LoroTree GetOrCreateTreeContainer(string key, LoroTree child);

	LoroValue GetValue();

	ContainerId Id();

	void Insert(string key, LoroValueLike v);

	LoroCounter InsertCounterContainer(string key, LoroCounter child);

	LoroList InsertListContainer(string key, LoroList child);

	LoroMap InsertMapContainer(string key, LoroMap child);

	LoroMovableList InsertMovableListContainer(string key, LoroMovableList child);

	LoroText InsertTextContainer(string key, LoroText child);

	LoroTree InsertTreeContainer(string key, LoroTree child);

	bool IsAttached();

	bool IsDeleted();

	bool IsEmpty();

	List<string> Keys();

	uint Len();

	Subscription? Subscribe(Subscriber subscriber);

	List<ValueOrContainer> Values();
}
