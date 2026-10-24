using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Pro.DO.Token;

public interface ITokenCollection<T> : IEnumerable<T>, IEnumerable, INotifyCollectionChanged where T : TokenBase
{
	bool Add(T token);

	bool Remove(T token);

	void SortTokens(IEnumerable<T> referenceItems);
}
