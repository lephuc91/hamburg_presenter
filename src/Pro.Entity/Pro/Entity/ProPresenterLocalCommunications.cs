using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class ProPresenterLocalCommunications : IProPresenterLocalCommunications, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private MapCollection<ICommunicationDeviceLocal> Devices_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IComplexCollection<ICommunicationDeviceLocal> Devices => Devices_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Devices_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Devices_.UpdateMapOnInternalMapUpdate(_map);
	}

	public ProPresenterLocalCommunications()
		: this(new LoroMap())
	{
	}

	public ProPresenterLocalCommunications(LoroMap values)
	{
		_map = values;
		Devices_ = new MapCollection<ICommunicationDeviceLocal>(LoroMap, "devices__1", new EntityFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Devices_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Devices_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Devices_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
