using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class LibraryItem : ILibraryItem, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private AtomicObservableProperty<Url> Url_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<Url> Url => Url_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Url_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Url_.UpdateMapOnInternalMapUpdate(_map);
	}

	public LibraryItem()
		: this(new LoroMap())
	{
	}

	public LibraryItem(LoroMap values)
	{
		_map = values;
		Url_ = new AtomicObservableProperty<Url>("url__1", LoroMap, UrlExtension.Deserialize, UrlExtension.Serialize);
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Url_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Url_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Url_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
