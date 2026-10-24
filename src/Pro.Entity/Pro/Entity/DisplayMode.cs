using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class DisplayMode : IDisplayMode, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private StringObservableProperty Name_;

	private UintObservableProperty Width_;

	private UintObservableProperty Height_;

	private DoubleObservableProperty RefreshRate_;

	private BoolObservableProperty Interlaced_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<string> Name => Name_;

	public IObservableProperty<uint> Width => Width_;

	public IObservableProperty<uint> Height => Height_;

	public IObservableProperty<double> RefreshRate => RefreshRate_;

	public IObservableProperty<bool> Interlaced => Interlaced_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Name_.UpdateMap(_map);
		Width_.UpdateMap(_map);
		Height_.UpdateMap(_map);
		RefreshRate_.UpdateMap(_map);
		Interlaced_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Name_.UpdateMapOnInternalMapUpdate(_map);
		Width_.UpdateMapOnInternalMapUpdate(_map);
		Height_.UpdateMapOnInternalMapUpdate(_map);
		RefreshRate_.UpdateMapOnInternalMapUpdate(_map);
		Interlaced_.UpdateMapOnInternalMapUpdate(_map);
	}

	public DisplayMode()
		: this(new LoroMap())
	{
	}

	public DisplayMode(LoroMap values)
	{
		_map = values;
		Name_ = new StringObservableProperty("name__1", LoroMap);
		Width_ = new UintObservableProperty("width__2", LoroMap);
		Height_ = new UintObservableProperty("height__3", LoroMap);
		RefreshRate_ = new DoubleObservableProperty("refresh_rate__4", LoroMap);
		Interlaced_ = new BoolObservableProperty("interlaced__5", LoroMap);
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Name_.WhenChangeHappens, Width_.WhenChangeHappens, Height_.WhenChangeHappens, RefreshRate_.WhenChangeHappens, Interlaced_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Name_.Dispose();
		Width_.Dispose();
		Height_.Dispose();
		RefreshRate_.Dispose();
		Interlaced_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Name_.OnDiff(path, diff);
		Width_.OnDiff(path, diff);
		Height_.OnDiff(path, diff);
		RefreshRate_.OnDiff(path, diff);
		Interlaced_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
