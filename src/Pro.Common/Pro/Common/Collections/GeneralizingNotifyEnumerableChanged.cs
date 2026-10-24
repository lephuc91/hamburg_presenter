using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Pro.Common.Collections;

public class GeneralizingNotifyEnumerableChanged<TConcrete, TGeneral> : INotifyEnumerableChanged<TGeneral>, IEnumerable<TGeneral>, IEnumerable, INotifyCollectionChanged where TConcrete : TGeneral
{
	private readonly INotifyEnumerableChanged<TConcrete> _baseCollection;

	public event NotifyCollectionChangedEventHandler? CollectionChanged;

	public GeneralizingNotifyEnumerableChanged(INotifyEnumerableChanged<TConcrete> baseCollection)
	{
		_baseCollection = baseCollection;
		baseCollection.CollectionChanged += BaseCollectionChanged;
	}

	private void BaseCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		this.CollectionChanged?.Invoke(sender, e);
	}

	public IEnumerator<TGeneral> GetEnumerator()
	{
		return new GeneralizingGenericEnumerator<TConcrete, TGeneral>(_baseCollection.GetEnumerator());
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable)_baseCollection).GetEnumerator();
	}
}
