using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class Calendar : ICalendar, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private MapCollection<ICalendar.Types.IEvent> Events_;

	private BoolObservableProperty Active_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IComplexCollection<ICalendar.Types.IEvent> Events => Events_;

	public IObservableProperty<bool> Active => Active_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Events_.UpdateMap(_map);
		Active_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Events_.UpdateMapOnInternalMapUpdate(_map);
		Active_.UpdateMapOnInternalMapUpdate(_map);
	}

	public Calendar()
		: this(new LoroMap())
	{
	}

	public Calendar(LoroMap values)
	{
		_map = values;
		Events_ = new MapCollection<ICalendar.Types.IEvent>(LoroMap, "events__1", new EntityFactory());
		Active_ = new BoolObservableProperty("active__2", LoroMap);
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Events_.WhenChangeHappens.Merge(Active_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Events_.Dispose();
		Active_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Events_.OnDiff(path, diff);
		Active_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
