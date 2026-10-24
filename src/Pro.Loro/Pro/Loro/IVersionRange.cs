using System.Collections.Generic;

namespace Pro.Loro;

public interface IVersionRange
{
	void Clear();

	bool ContainsId(Id id);

	bool ContainsIdSpan(IdSpan span);

	bool ContainsOpsBetween(VersionVector vvA, VersionVector vvB);

	void ExtendsToIncludeIdSpan(IdSpan span);

	CounterSpan? Get(ulong peer);

	List<VersionRangeItem> GetAllRanges();

	List<ulong> GetPeers();

	bool HasOverlapWith(IdSpan span);

	void Insert(ulong peer, int start, int end);

	bool IsEmpty();
}
