using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;

namespace ProPresenter.DO.Slide.Links;

public interface IColorTriggerCollection : IDragDropCollection<IColorTrigger>, INotifyEnumerableChanged<IColorTrigger>, IEnumerable<IColorTrigger>, IEnumerable, INotifyCollectionChanged
{
	UndoStack? UndoStack { get; set; }

	void Add();

	void Add(IColorTrigger colorTrigger);

	void Add(IEnumerable<IColorTrigger> colorTriggers);

	void Clear();

	void Remove(IColorTrigger colorTrigger);

	void Remove(IEnumerable<IColorTrigger> colorTriggers);
}
