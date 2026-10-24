using System.Collections.Generic;

namespace Pro.Loro;

public interface IVersionVector
{
	VersionVectorDiff Diff(VersionVector rhs);

	byte[] Encode();

	bool Eq(VersionVector other);

	void ExtendToIncludeVv(VersionVector other);

	int? GetLast(ulong peer);

	List<IdSpan> GetMissingSpan(VersionVector target);

	bool IncludesId(Id id);

	bool IncludesVv(VersionVector other);

	CounterSpan? IntersectSpan(IdSpan target);

	void Merge(VersionVector other);

	Ordering? PartialCmp(VersionVector other);

	void SetEnd(Id id);

	void SetLast(Id id);

	Dictionary<ulong, int> ToHashmap();

	bool TryUpdateLast(Id id);
}
