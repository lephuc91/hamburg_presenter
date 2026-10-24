using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;

namespace Pro.UI;

public class ClipboardItems<T> where T : ICloneable<T>
{
	private readonly T[] _items;

	public T[] PasteableItems => _items.Collect((T i) => i.Clone()).ToArray();

	public ClipboardItems(IEnumerable<T> items)
	{
		_items = items.Collect((T i) => i.Clone()).ToArray();
	}
}
