using System.Collections.Generic;

namespace Pro.Loro;

public interface IFrontiers
{
	byte[] Encode();

	bool Eq(Frontiers other);

	bool IsEmpty();

	List<Id> ToVec();
}
