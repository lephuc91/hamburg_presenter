using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class ClearGroupsDocument : IClearGroupsDocument, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private MapCollection<IClearGroupsDocument.Types.IClearGroup> Groups_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IComplexCollection<IClearGroupsDocument.Types.IClearGroup> Groups => Groups_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Groups_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Groups_.UpdateMapOnInternalMapUpdate(_map);
	}

	public ClearGroupsDocument()
		: this(new LoroMap())
	{
	}

	public ClearGroupsDocument(LoroMap values)
	{
		_map = values;
		Groups_ = new MapCollection<IClearGroupsDocument.Types.IClearGroup>(LoroMap, "groups__2", new EntityFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Groups_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Groups_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Groups_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
