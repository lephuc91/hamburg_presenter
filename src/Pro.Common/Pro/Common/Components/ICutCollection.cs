using System.Collections.Generic;

namespace Pro.Common.Components;

public interface ICutCollection<in T>
{
	void CutFrom(IEnumerable<T> items);
}
