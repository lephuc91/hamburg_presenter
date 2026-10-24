using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class ProLabelsDocument : IProLabelsDocument, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private MapCollection<IAction.Types.ILabel> Labels_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IComplexCollection<IAction.Types.ILabel> Labels => Labels_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Labels_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Labels_.UpdateMapOnInternalMapUpdate(_map);
	}

	public ProLabelsDocument()
		: this(new LoroMap())
	{
	}

	public ProLabelsDocument(LoroMap values)
	{
		_map = values;
		Labels_ = new MapCollection<IAction.Types.ILabel>(LoroMap, "labels__1", new EntityFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Labels_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Labels_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Labels_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
