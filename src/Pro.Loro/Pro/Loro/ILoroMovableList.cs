using System.Collections.Generic;

namespace Pro.Loro;

public interface ILoroMovableList
{
	void Clear();

	void Delete(uint pos, uint len);

	LoroDoc? Doc();

	ValueOrContainer? Get(uint index);

	LoroMovableList? GetAttached();

	ulong? GetCreatorAt(uint pos);

	Cursor? GetCursor(uint pos, Side side);

	LoroValue GetDeepValue();

	ulong? GetLastEditorAt(uint pos);

	ulong? GetLastMoverAt(uint pos);

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

	void Mov(uint from, uint to);

	ValueOrContainer? Pop();

	void Push(LoroValueLike v);

	void Set(uint pos, LoroValueLike value);

	LoroCounter SetCounterContainer(uint pos, LoroCounter child);

	LoroList SetListContainer(uint pos, LoroList child);

	LoroMap SetMapContainer(uint pos, LoroMap child);

	LoroMovableList SetMovableListContainer(uint pos, LoroMovableList child);

	LoroText SetTextContainer(uint pos, LoroText child);

	LoroTree SetTreeContainer(uint pos, LoroTree child);

	Subscription? Subscribe(Subscriber subscriber);

	List<LoroValue> ToVec();
}
