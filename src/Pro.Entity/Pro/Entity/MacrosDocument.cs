using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class MacrosDocument : IMacrosDocument, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private MapCollection<IMacrosDocument.Types.IMacroCollection> MacroCollections_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IComplexCollection<IMacrosDocument.Types.IMacroCollection> MacroCollections => MacroCollections_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		MacroCollections_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		MacroCollections_.UpdateMapOnInternalMapUpdate(_map);
	}

	public MacrosDocument()
		: this(new LoroMap())
	{
	}

	public MacrosDocument(LoroMap values)
	{
		_map = values;
		MacroCollections_ = new MapCollection<IMacrosDocument.Types.IMacroCollection>(LoroMap, "macro_collections__3", new EntityFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(MacroCollections_.WhenChangeHappens);
	}

	public void Dispose()
	{
		MacroCollections_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		MacroCollections_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
