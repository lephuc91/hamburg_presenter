using System.Collections.Generic;

namespace Pro.Loro;

public interface ILoroList
{
	void Clear();

	void Delete(uint pos, uint len);

	LoroDoc? Doc();

	ValueOrContainer? Get(uint index);

	LoroList? GetAttached();

	Cursor? GetCursor(uint pos, Side side);

	LoroValue GetDeepValue();

	Id? GetIdAt(uint pos);

	LoroValue GetValue();

	ContainerId Id();

	void Insert(uint pos, LoroValueLike v);

	LoroCounter InsertCounterContainer(uint pos, LoroCounter child);

	LoroList InsertListContainer(uint pos, LoroList child);

	LoroMap InsertMapContainer(uint pos, LoroMap child);

	LoroMovableList InsertMovableListContainer(uint pos, LoroMovableList child);

	LoroText InsertTextContainer(uint pos, LoroText child);

	LoroTree InsertTreeContainer(uint pos, LoroTree child);

	bool IsAttached();

	bool IsDeleted();

	bool IsEmpty();

	uint Len();

	LoroValue? Pop();

	void Push(LoroValueLike v);

	Subscription? Subscribe(Subscriber subscriber);

	List<LoroValue> ToVec();
}
