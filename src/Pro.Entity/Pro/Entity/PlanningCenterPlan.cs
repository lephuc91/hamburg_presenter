using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class PlanningCenterPlan : IPlanningCenterPlan, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private UintObservableProperty PlanIdNum_;

	private UintObservableProperty ParentIdNum_;

	private StringObservableProperty SeriesTitle_;

	private StringObservableProperty PlanTitle_;

	private StringObservableProperty DateList_;

	private AtomicObservableProperty<Timestamp> CreatedDate_;

	private AtomicObservableProperty<Timestamp> UpdateDate_;

	private AtomicObservableProperty<Timestamp> LastUpdateCheckDate_;

	private StringObservableProperty PlanIdStr_;

	private StringObservableProperty ParentIdStr_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<uint> PlanIdNum => PlanIdNum_;

	public IObservableProperty<uint> ParentIdNum => ParentIdNum_;

	public IObservableProperty<string> SeriesTitle => SeriesTitle_;

	public IObservableProperty<string> PlanTitle => PlanTitle_;

	public IObservableProperty<string> DateList => DateList_;

	public IObservableProperty<Timestamp> CreatedDate => CreatedDate_;

	public IObservableProperty<Timestamp> UpdateDate => UpdateDate_;

	public IObservableProperty<Timestamp> LastUpdateCheckDate => LastUpdateCheckDate_;

	public IObservableProperty<string> PlanIdStr => PlanIdStr_;

	public IObservableProperty<string> ParentIdStr => ParentIdStr_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		PlanIdNum_.UpdateMap(_map);
		ParentIdNum_.UpdateMap(_map);
		SeriesTitle_.UpdateMap(_map);
		PlanTitle_.UpdateMap(_map);
		DateList_.UpdateMap(_map);
		CreatedDate_.UpdateMap(_map);
		UpdateDate_.UpdateMap(_map);
		LastUpdateCheckDate_.UpdateMap(_map);
		PlanIdStr_.UpdateMap(_map);
		ParentIdStr_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		PlanIdNum_.UpdateMapOnInternalMapUpdate(_map);
		ParentIdNum_.UpdateMapOnInternalMapUpdate(_map);
		SeriesTitle_.UpdateMapOnInternalMapUpdate(_map);
		PlanTitle_.UpdateMapOnInternalMapUpdate(_map);
		DateList_.UpdateMapOnInternalMapUpdate(_map);
		CreatedDate_.UpdateMapOnInternalMapUpdate(_map);
		UpdateDate_.UpdateMapOnInternalMapUpdate(_map);
		LastUpdateCheckDate_.UpdateMapOnInternalMapUpdate(_map);
		PlanIdStr_.UpdateMapOnInternalMapUpdate(_map);
		ParentIdStr_.UpdateMapOnInternalMapUpdate(_map);
	}

	public PlanningCenterPlan()
		: this(new LoroMap())
	{
	}

	public PlanningCenterPlan(LoroMap values)
	{
		_map = values;
		PlanIdNum_ = new UintObservableProperty("plan_id_num__1", LoroMap);
		ParentIdNum_ = new UintObservableProperty("parent_id_num__2", LoroMap);
		SeriesTitle_ = new StringObservableProperty("series_title__3", LoroMap);
		PlanTitle_ = new StringObservableProperty("plan_title__4", LoroMap);
		DateList_ = new StringObservableProperty("date_list__5", LoroMap);
		CreatedDate_ = new AtomicObservableProperty<Timestamp>("created_date__6", LoroMap, TimestampExtension.Deserialize, TimestampExtension.Serialize);
		UpdateDate_ = new AtomicObservableProperty<Timestamp>("update_date__7", LoroMap, TimestampExtension.Deserialize, TimestampExtension.Serialize);
		LastUpdateCheckDate_ = new AtomicObservableProperty<Timestamp>("last_update_check_date__8", LoroMap, TimestampExtension.Deserialize, TimestampExtension.Serialize);
		PlanIdStr_ = new StringObservableProperty("plan_id_str__9", LoroMap);
		ParentIdStr_ = new StringObservableProperty("parent_id_str__10", LoroMap);
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(PlanIdNum_.WhenChangeHappens, ParentIdNum_.WhenChangeHappens, SeriesTitle_.WhenChangeHappens, PlanTitle_.WhenChangeHappens, DateList_.WhenChangeHappens, CreatedDate_.WhenChangeHappens, UpdateDate_.WhenChangeHappens, LastUpdateCheckDate_.WhenChangeHappens, PlanIdStr_.WhenChangeHappens, ParentIdStr_.WhenChangeHappens);
	}

	public void Dispose()
	{
		PlanIdNum_.Dispose();
		ParentIdNum_.Dispose();
		SeriesTitle_.Dispose();
		PlanTitle_.Dispose();
		DateList_.Dispose();
		CreatedDate_.Dispose();
		UpdateDate_.Dispose();
		LastUpdateCheckDate_.Dispose();
		PlanIdStr_.Dispose();
		ParentIdStr_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		PlanIdNum_.OnDiff(path, diff);
		ParentIdNum_.OnDiff(path, diff);
		SeriesTitle_.OnDiff(path, diff);
		PlanTitle_.OnDiff(path, diff);
		DateList_.OnDiff(path, diff);
		CreatedDate_.OnDiff(path, diff);
		UpdateDate_.OnDiff(path, diff);
		LastUpdateCheckDate_.OnDiff(path, diff);
		PlanIdStr_.OnDiff(path, diff);
		ParentIdStr_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
