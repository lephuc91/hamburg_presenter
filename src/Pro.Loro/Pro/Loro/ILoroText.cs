using System.Collections.Generic;

namespace Pro.Loro;

public interface ILoroText
{
	void ApplyDelta(List<TextDelta> delta);

	string CharAt(uint pos);

	uint? ConvertPos(uint index, PosType from, PosType to);

	void Delete(uint pos, uint len);

	void DeleteUtf16(uint pos, uint len);

	void DeleteUtf8(uint pos, uint len);

	LoroDoc? Doc();

	LoroText? GetAttached();

	Cursor? GetCursor(uint pos, Side side);

	ulong? GetEditorAtUnicodePos(uint pos);

	LoroValue GetRichtextValue();

	ContainerId Id();

	void Insert(uint pos, string s);

	void InsertUtf16(uint pos, string s);

	void InsertUtf8(uint pos, string s);

	bool IsAttached();

	bool IsDeleted();

	bool IsEmpty();

	uint LenUnicode();

	uint LenUtf16();

	uint LenUtf8();

	void Mark(uint from, uint to, string key, LoroValueLike value);

	void MarkUtf16(uint from, uint to, string key, LoroValueLike value);

	void MarkUtf8(uint from, uint to, string key, LoroValueLike value);

	void PushStr(string s);

	string Slice(uint startIndex, uint endIndex);

	List<TextDelta> SliceDelta(uint startIndex, uint endIndex, PosType posType);

	string SliceUtf16(uint startIndex, uint endIndex);

	string Splice(uint pos, uint len, string s);

	void SpliceUtf16(uint pos, uint len, string s);

	Subscription? Subscribe(Subscriber subscriber);

	List<TextDelta> ToDelta();

	void Unmark(uint from, uint to, string key);

	void UnmarkUtf16(uint from, uint to, string key);

	void Update(string s, UpdateOptions options);

	void UpdateByLine(string s, UpdateOptions options);
}
