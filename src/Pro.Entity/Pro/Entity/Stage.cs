using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class Stage : IStage, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public void UpdateMap(LoroMap value)
	{
		_map = value;
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
	}

	public Stage()
		: this(new LoroMap())
	{
	}

	public Stage(LoroMap values)
	{
		_map = values;
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge(Array.Empty<IObservable<Unit>>());
	}

	public void Dispose()
	{
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
