using System.Collections.Generic;

namespace Pro.Common.Components;

public interface ICutPasteCollection<in T> : ICutCollection<T>
{
	void PasteInto(IEnumerable<T> items, int index);
}
