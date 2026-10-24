using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class TimersDocument : ITimersDocument, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private MapCollection<ITimer> Timers_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IComplexCollection<ITimer> Timers => Timers_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Timers_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Timers_.UpdateMapOnInternalMapUpdate(_map);
	}

	public TimersDocument()
		: this(new LoroMap())
	{
	}

	public TimersDocument(LoroMap values)
	{
		_map = values;
		Timers_ = new MapCollection<ITimer>(LoroMap, "timers__3", new EntityFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Timers_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Timers_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Timers_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
