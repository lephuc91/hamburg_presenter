using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class PropDocument : IPropDocument, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private OptionalComplexObservableProperty<ITransition> Transition_;

	private MapCollection<IPropDocument.Types.IPropCollection> PropCollections_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IComplexObservableProperty<ITransition?> Transition => Transition_;

	public IComplexCollection<IPropDocument.Types.IPropCollection> PropCollections => PropCollections_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Transition_.UpdateMap(_map);
		PropCollections_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Transition_.UpdateMapOnInternalMapUpdate(_map);
		PropCollections_.UpdateMapOnInternalMapUpdate(_map);
	}

	public PropDocument()
		: this(new LoroMap())
	{
	}

	public PropDocument(LoroMap values)
	{
		_map = values;
		Transition_ = new OptionalComplexObservableProperty<ITransition>("transition__3", LoroMap, new EntityFactory());
		PropCollections_ = new MapCollection<IPropDocument.Types.IPropCollection>(LoroMap, "prop_collections__4", new EntityFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Transition_.WhenChangeHappens.Merge(PropCollections_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Transition_.Dispose();
		PropCollections_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Transition_.OnDiff(path, diff);
		PropCollections_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
