using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Pro.Common.Collections;

namespace ProPresenter.DO.Import;

public interface IMissingFontItemCollection : IImmutableObservableCollection<IMissingFontItemVM>, IReadOnlyList<IMissingFontItemVM>, IEnumerable<IMissingFontItemVM>, IEnumerable, IReadOnlyCollection<IMissingFontItemVM>, INotifyEnumerableChanged<IMissingFontItemVM>, INotifyCollectionChanged
{
	event Action<IMissingFontItemCollection>? DataModified;

	void Add(IMissingFontItemVM fontItem);

	void Add(IEnumerable<IMissingFontItemVM> fontItems);

	void Remove(IMissingFontItemVM fontItem);

	void Remove(IEnumerable<IMissingFontItemVM> fontItems);

	void Clear();
}
