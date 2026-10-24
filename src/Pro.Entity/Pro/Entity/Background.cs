using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class Background : IBackground, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private BoolObservableProperty IsEnabled_;

	private UnionObservableProperty<IBackground.Types.IFill> Fill_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<bool> IsEnabled => IsEnabled_;

	public IComplexObservableProperty<IBackground.Types.IFill> Fill => Fill_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		IsEnabled_.UpdateMap(_map);
		Fill_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		IsEnabled_.UpdateMapOnInternalMapUpdate(_map);
		Fill_.UpdateMapOnInternalMapUpdate(_map);
	}

	public Background()
		: this(new LoroMap())
	{
	}

	public Background(LoroMap values)
	{
		_map = values;
		IsEnabled_ = new BoolObservableProperty("is_enabled__3", LoroMap);
		Fill_ = new UnionObservableProperty<IBackground.Types.IFill>("Fill__union", LoroMap, new IBackground.Types.FillFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = IsEnabled_.WhenChangeHappens.Merge(Fill_.WhenChangeHappens);
	}

	public void Dispose()
	{
		IsEnabled_.Dispose();
		Fill_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		IsEnabled_.OnDiff(path, diff);
		Fill_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
