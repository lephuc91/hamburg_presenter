using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class Action : IAction, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private GuidObservableProperty Uuid_;

	private StringObservableProperty Name_;

	private ComplexObservableProperty<IAction.Types.ILabel> Label_;

	private DoubleObservableProperty DelayTime_;

	private BoolObservableProperty IsEnabled_;

	private DoubleObservableProperty Duration_;

	private EnumObservableProperty<IAction.Types.ActionType> Type_;

	private UnionObservableProperty<IAction.Types.IActionTypeData> ActionTypeData_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<Guid> Uuid => Uuid_;

	public IObservableProperty<string> Name => Name_;

	public IComplexObservableProperty<IAction.Types.ILabel> Label => Label_;

	public IObservableProperty<double> DelayTime => DelayTime_;

	public IObservableProperty<bool> IsEnabled => IsEnabled_;

	public IObservableProperty<double> Duration => Duration_;

	public IObservableProperty<IAction.Types.ActionType> Type => Type_;

	public IComplexObservableProperty<IAction.Types.IActionTypeData> ActionTypeData => ActionTypeData_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMap(_map);
		Name_.UpdateMap(_map);
		Label_.UpdateMap(_map);
		DelayTime_.UpdateMap(_map);
		IsEnabled_.UpdateMap(_map);
		Duration_.UpdateMap(_map);
		Type_.UpdateMap(_map);
		ActionTypeData_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMapOnInternalMapUpdate(_map);
		Name_.UpdateMapOnInternalMapUpdate(_map);
		Label_.UpdateMapOnInternalMapUpdate(_map);
		DelayTime_.UpdateMapOnInternalMapUpdate(_map);
		IsEnabled_.UpdateMapOnInternalMapUpdate(_map);
		Duration_.UpdateMapOnInternalMapUpdate(_map);
		Type_.UpdateMapOnInternalMapUpdate(_map);
		ActionTypeData_.UpdateMapOnInternalMapUpdate(_map);
	}

	public Action()
		: this(new LoroMap())
	{
	}

	public Action(LoroMap values)
	{
		_map = values;
		Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
		Name_ = new StringObservableProperty("name__2", LoroMap);
		Label_ = new ComplexObservableProperty<IAction.Types.ILabel>("label__3", LoroMap, new EntityFactory());
		DelayTime_ = new DoubleObservableProperty("delay_time__4", LoroMap);
		IsEnabled_ = new BoolObservableProperty("isEnabled__6", LoroMap);
		Duration_ = new DoubleObservableProperty("duration__8", LoroMap);
		Type_ = new EnumObservableProperty<IAction.Types.ActionType>("type__9", LoroMap);
		ActionTypeData_ = new UnionObservableProperty<IAction.Types.IActionTypeData>("ActionTypeData__union", LoroMap, new IAction.Types.ActionTypeDataFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, Name_.WhenChangeHappens, Label_.WhenChangeHappens, DelayTime_.WhenChangeHappens, IsEnabled_.WhenChangeHappens, Duration_.WhenChangeHappens, Type_.WhenChangeHappens, ActionTypeData_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Uuid_.Dispose();
		Name_.Dispose();
		Label_.Dispose();
		DelayTime_.Dispose();
		IsEnabled_.Dispose();
		Duration_.Dispose();
		Type_.Dispose();
		ActionTypeData_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Uuid_.OnDiff(path, diff);
		Name_.OnDiff(path, diff);
		Label_.OnDiff(path, diff);
		DelayTime_.OnDiff(path, diff);
		IsEnabled_.OnDiff(path, diff);
		Duration_.OnDiff(path, diff);
		Type_.OnDiff(path, diff);
		ActionTypeData_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
