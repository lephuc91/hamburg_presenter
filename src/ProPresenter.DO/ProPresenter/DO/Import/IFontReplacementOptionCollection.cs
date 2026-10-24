using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Pro.Common.Collections;

namespace ProPresenter.DO.Import;

public interface IFontReplacementOptionCollection : INotifyEnumerableChanged<IFontReplacementOption>, IEnumerable<IFontReplacementOption>, IEnumerable, INotifyCollectionChanged, IReadOnlyCollection<IFontReplacementOption>
{
	event Action<FontReplacementOptionCollection>? DataModified;

	void Add(IFontReplacementOption fontOption);

	void Add(IEnumerable<IFontReplacementOption> fontOptions);

	void Remove(IFontReplacementOption fontOption);

	void Remove(IEnumerable<IFontReplacementOption> fontOptions);

	void Clear();
}
