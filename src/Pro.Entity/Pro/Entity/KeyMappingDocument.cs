using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class KeyMappingDocument : IKeyMappingDocument, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private MapCollection<IKeyMapping> Keymappings_;

	private MapCollection<IKeyMapping> MacosKeymappings_;

	private MapCollection<IKeyMapping> WindowsKeymappings_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IComplexCollection<IKeyMapping> Keymappings => Keymappings_;

	public IComplexCollection<IKeyMapping> MacosKeymappings => MacosKeymappings_;

	public IComplexCollection<IKeyMapping> WindowsKeymappings => WindowsKeymappings_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Keymappings_.UpdateMap(_map);
		MacosKeymappings_.UpdateMap(_map);
		WindowsKeymappings_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Keymappings_.UpdateMapOnInternalMapUpdate(_map);
		MacosKeymappings_.UpdateMapOnInternalMapUpdate(_map);
		WindowsKeymappings_.UpdateMapOnInternalMapUpdate(_map);
	}

	public KeyMappingDocument()
		: this(new LoroMap())
	{
	}

	public KeyMappingDocument(LoroMap values)
	{
		_map = values;
		Keymappings_ = new MapCollection<IKeyMapping>(LoroMap, "keymappings__2", new EntityFactory());
		MacosKeymappings_ = new MapCollection<IKeyMapping>(LoroMap, "macos_keymappings__3", new EntityFactory());
		WindowsKeymappings_ = new MapCollection<IKeyMapping>(LoroMap, "windows_keymappings__4", new EntityFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Keymappings_.WhenChangeHappens, MacosKeymappings_.WhenChangeHappens, WindowsKeymappings_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Keymappings_.Dispose();
		MacosKeymappings_.Dispose();
		WindowsKeymappings_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Keymappings_.OnDiff(path, diff);
		MacosKeymappings_.OnDiff(path, diff);
		WindowsKeymappings_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
