using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class Transition : ITransition, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private DoubleObservableProperty Duration_;

	private OptionalGuidObservableProperty FavoriteUuid_;

	private ComplexObservableProperty<IEffect> Effect_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<double> Duration => Duration_;

	public IObservableProperty<Guid?> FavoriteUuid => FavoriteUuid_;

	public IComplexObservableProperty<IEffect> Effect => Effect_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Duration_.UpdateMap(_map);
		FavoriteUuid_.UpdateMap(_map);
		Effect_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Duration_.UpdateMapOnInternalMapUpdate(_map);
		FavoriteUuid_.UpdateMapOnInternalMapUpdate(_map);
		Effect_.UpdateMapOnInternalMapUpdate(_map);
	}

	public Transition()
		: this(new LoroMap())
	{
	}

	public Transition(LoroMap values)
	{
		_map = values;
		Duration_ = new DoubleObservableProperty("duration__1", LoroMap);
		FavoriteUuid_ = new OptionalGuidObservableProperty("favorite_uuid__2", LoroMap);
		Effect_ = new ComplexObservableProperty<IEffect>("effect__3", LoroMap, new EntityFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Duration_.WhenChangeHappens, FavoriteUuid_.WhenChangeHappens, Effect_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Duration_.Dispose();
		FavoriteUuid_.Dispose();
		Effect_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Duration_.OnDiff(path, diff);
		FavoriteUuid_.OnDiff(path, diff);
		Effect_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
