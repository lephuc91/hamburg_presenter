using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class PropSlide : IPropSlide, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private ComplexObservableProperty<ISlide> BaseSlide_;

	private OptionalComplexObservableProperty<ITransition> Transition_;

	private BoolObservableProperty AutoClearEnabled_;

	private DoubleObservableProperty AutoClearDuration_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IComplexObservableProperty<ISlide> BaseSlide => BaseSlide_;

	public IComplexObservableProperty<ITransition?> Transition => Transition_;

	public IObservableProperty<bool> AutoClearEnabled => AutoClearEnabled_;

	public IObservableProperty<double> AutoClearDuration => AutoClearDuration_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		BaseSlide_.UpdateMap(_map);
		Transition_.UpdateMap(_map);
		AutoClearEnabled_.UpdateMap(_map);
		AutoClearDuration_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		BaseSlide_.UpdateMapOnInternalMapUpdate(_map);
		Transition_.UpdateMapOnInternalMapUpdate(_map);
		AutoClearEnabled_.UpdateMapOnInternalMapUpdate(_map);
		AutoClearDuration_.UpdateMapOnInternalMapUpdate(_map);
	}

	public PropSlide()
		: this(new LoroMap())
	{
	}

	public PropSlide(LoroMap values)
	{
		_map = values;
		BaseSlide_ = new ComplexObservableProperty<ISlide>("base_slide__1", LoroMap, new EntityFactory());
		Transition_ = new OptionalComplexObservableProperty<ITransition>("transition__2", LoroMap, new EntityFactory());
		AutoClearEnabled_ = new BoolObservableProperty("auto_clear_enabled__3", LoroMap);
		AutoClearDuration_ = new DoubleObservableProperty("auto_clear_duration__4", LoroMap);
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(BaseSlide_.WhenChangeHappens, Transition_.WhenChangeHappens, AutoClearEnabled_.WhenChangeHappens, AutoClearDuration_.WhenChangeHappens);
	}

	public void Dispose()
	{
		BaseSlide_.Dispose();
		Transition_.Dispose();
		AutoClearEnabled_.Dispose();
		AutoClearDuration_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		BaseSlide_.OnDiff(path, diff);
		Transition_.OnDiff(path, diff);
		AutoClearEnabled_.OnDiff(path, diff);
		AutoClearDuration_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
