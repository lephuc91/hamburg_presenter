using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class HotKey : IHotKey, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private EnumObservableProperty<KeyCode> Code_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<KeyCode> Code => Code_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Code_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Code_.UpdateMapOnInternalMapUpdate(_map);
	}

	public HotKey()
		: this(new LoroMap())
	{
	}

	public HotKey(LoroMap values)
	{
		_map = values;
		Code_ = new EnumObservableProperty<KeyCode>("code__1", LoroMap);
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Code_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Code_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Code_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
