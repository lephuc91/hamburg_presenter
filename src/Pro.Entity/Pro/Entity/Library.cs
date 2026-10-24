using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class Library : ILibrary, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private AtomicObservableProperty<Url> Url_;

	private UnionObservableProperty<ILibrary.Types.IChildType> ChildType_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<Url> Url => Url_;

	public IComplexObservableProperty<ILibrary.Types.IChildType> ChildType => ChildType_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Url_.UpdateMap(_map);
		ChildType_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Url_.UpdateMapOnInternalMapUpdate(_map);
		ChildType_.UpdateMapOnInternalMapUpdate(_map);
	}

	public Library()
		: this(new LoroMap())
	{
	}

	public Library(LoroMap values)
	{
		_map = values;
		Url_ = new AtomicObservableProperty<Url>("url__1", LoroMap, UrlExtension.Deserialize, UrlExtension.Serialize);
		ChildType_ = new UnionObservableProperty<ILibrary.Types.IChildType>("ChildType__union", LoroMap, new ILibrary.Types.ChildTypeFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Url_.WhenChangeHappens.Merge(ChildType_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Url_.Dispose();
		ChildType_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Url_.OnDiff(path, diff);
		ChildType_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
