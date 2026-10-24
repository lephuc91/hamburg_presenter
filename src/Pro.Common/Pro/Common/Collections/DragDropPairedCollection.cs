using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Pro.Common.Components;

namespace Pro.Common.Collections;

public class DragDropPairedCollection<S, T> : PairedCollection<IDragDropNotifyEnumerableChanged<S>, S, T>, IDragDropNotifyEnumerableChanged<T>, INotifyEnumerableChanged<T>, IEnumerable<T>, IEnumerable, INotifyCollectionChanged, IDragDropCollection<T> where S : class
{
	public delegate S? UnwrapTargetDelegate(T targetItem);

	private UnwrapTargetDelegate? _unwrapTarget;

	public DragDropPairedCollection(IDragDropNotifyEnumerableChanged<S>? source, GenerateTargetDelegate generateTarget, TeardownTargetDelegate? teardownTarget = null, UnwrapTargetDelegate? unwrapTargetDelegate = null)
		: base(source, generateTarget, teardownTarget)
	{
		_unwrapTarget = unwrapTargetDelegate;
	}

	public virtual void DraggedFrom(IEnumerable<T> items)
	{
		base.SourceCollection?.DraggedFrom(Map(items));
	}

	public virtual void DroppedInto(IEnumerable<T> items, int index, bool isCopy)
	{
		base.SourceCollection?.DroppedInto(UnwrapItems(items), index, isCopy);
	}

	public virtual void MoveTo(IEnumerable<T> items, int index)
	{
		base.SourceCollection?.MoveTo(Map(items), index);
	}

	private IEnumerable<S> UnwrapItems(IEnumerable<T> items)
	{
		return items.Select(delegate(T i)
		{
			UnwrapTargetDelegate? unwrapTarget = _unwrapTarget;
			return ((unwrapTarget != null) ? unwrapTarget(i) : null) ?? null;
		}).NonNull();
	}
}
