using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class Cue : ICue, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private GuidObservableProperty Uuid_;

	private OptionalStringObservableProperty Name_;

	private EnumObservableProperty<ICue.Types.CompletionTargetType> CompletionTargetType_;

	private OptionalGuidObservableProperty CompletionTargetUuid_;

	private EnumObservableProperty<ICue.Types.CompletionActionType> CompletionActionType_;

	private OptionalGuidObservableProperty CompletionActionUuid_;

	private ComplexObservableProperty<IHotKey> HotKey_;

	private MapCollection<IAction> Actions_;

	private BoolObservableProperty IsEnabled_;

	private DoubleObservableProperty CompletionTime_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<Guid> Uuid => Uuid_;

	public IObservableProperty<string?> Name => Name_;

	public IObservableProperty<ICue.Types.CompletionTargetType> CompletionTargetType => CompletionTargetType_;

	public IObservableProperty<Guid?> CompletionTargetUuid => CompletionTargetUuid_;

	public IObservableProperty<ICue.Types.CompletionActionType> CompletionActionType => CompletionActionType_;

	public IObservableProperty<Guid?> CompletionActionUuid => CompletionActionUuid_;

	public IComplexObservableProperty<IHotKey> HotKey => HotKey_;

	public IComplexCollection<IAction> Actions => Actions_;

	public IObservableProperty<bool> IsEnabled => IsEnabled_;

	public IObservableProperty<double> CompletionTime => CompletionTime_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMap(_map);
		Name_.UpdateMap(_map);
		CompletionTargetType_.UpdateMap(_map);
		CompletionTargetUuid_.UpdateMap(_map);
		CompletionActionType_.UpdateMap(_map);
		CompletionActionUuid_.UpdateMap(_map);
		HotKey_.UpdateMap(_map);
		Actions_.UpdateMap(_map);
		IsEnabled_.UpdateMap(_map);
		CompletionTime_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMapOnInternalMapUpdate(_map);
		Name_.UpdateMapOnInternalMapUpdate(_map);
		CompletionTargetType_.UpdateMapOnInternalMapUpdate(_map);
		CompletionTargetUuid_.UpdateMapOnInternalMapUpdate(_map);
		CompletionActionType_.UpdateMapOnInternalMapUpdate(_map);
		CompletionActionUuid_.UpdateMapOnInternalMapUpdate(_map);
		HotKey_.UpdateMapOnInternalMapUpdate(_map);
		Actions_.UpdateMapOnInternalMapUpdate(_map);
		IsEnabled_.UpdateMapOnInternalMapUpdate(_map);
		CompletionTime_.UpdateMapOnInternalMapUpdate(_map);
	}

	public Cue()
		: this(new LoroMap())
	{
	}

	public Cue(LoroMap values)
	{
		_map = values;
		Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
		Name_ = new OptionalStringObservableProperty("name__2", LoroMap);
		CompletionTargetType_ = new EnumObservableProperty<ICue.Types.CompletionTargetType>("completion_target_type__3", LoroMap);
		CompletionTargetUuid_ = new OptionalGuidObservableProperty("completion_target_uuid__4", LoroMap);
		CompletionActionType_ = new EnumObservableProperty<ICue.Types.CompletionActionType>("completion_action_type__5", LoroMap);
		CompletionActionUuid_ = new OptionalGuidObservableProperty("completion_action_uuid__6", LoroMap);
		HotKey_ = new ComplexObservableProperty<IHotKey>("hot_key__8", LoroMap, new EntityFactory());
		Actions_ = new MapCollection<IAction>(LoroMap, "actions__10", new EntityFactory());
		IsEnabled_ = new BoolObservableProperty("isEnabled__12", LoroMap);
		CompletionTime_ = new DoubleObservableProperty("completion_time__13", LoroMap);
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, Name_.WhenChangeHappens, CompletionTargetType_.WhenChangeHappens, CompletionTargetUuid_.WhenChangeHappens, CompletionActionType_.WhenChangeHappens, CompletionActionUuid_.WhenChangeHappens, HotKey_.WhenChangeHappens, Actions_.WhenChangeHappens, IsEnabled_.WhenChangeHappens, CompletionTime_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Uuid_.Dispose();
		Name_.Dispose();
		CompletionTargetType_.Dispose();
		CompletionTargetUuid_.Dispose();
		CompletionActionType_.Dispose();
		CompletionActionUuid_.Dispose();
		HotKey_.Dispose();
		Actions_.Dispose();
		IsEnabled_.Dispose();
		CompletionTime_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Uuid_.OnDiff(path, diff);
		Name_.OnDiff(path, diff);
		CompletionTargetType_.OnDiff(path, diff);
		CompletionTargetUuid_.OnDiff(path, diff);
		CompletionActionType_.OnDiff(path, diff);
		CompletionActionUuid_.OnDiff(path, diff);
		HotKey_.OnDiff(path, diff);
		Actions_.OnDiff(path, diff);
		IsEnabled_.OnDiff(path, diff);
		CompletionTime_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
