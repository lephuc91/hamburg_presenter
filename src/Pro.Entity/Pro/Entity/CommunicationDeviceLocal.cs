using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class CommunicationDeviceLocal : ICommunicationDeviceLocal, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private GuidObservableProperty Id_;

	private BoolObservableProperty Connected_;

	private BoolObservableProperty AutoReconnect_;

	private OptionalStringObservableProperty BundleName_;

	private OptionalStringObservableProperty BundleIdentifier_;

	private MapCollection<ICommunicationDeviceOption> Options_;

	private UnionObservableProperty<ICommunicationDeviceLocal.Types.IHardwareType> HardwareType_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<Guid> Id => Id_;

	public IObservableProperty<bool> Connected => Connected_;

	public IObservableProperty<bool> AutoReconnect => AutoReconnect_;

	public IObservableProperty<string?> BundleName => BundleName_;

	public IObservableProperty<string?> BundleIdentifier => BundleIdentifier_;

	public IComplexCollection<ICommunicationDeviceOption> Options => Options_;

	public IComplexObservableProperty<ICommunicationDeviceLocal.Types.IHardwareType> HardwareType => HardwareType_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Id_.UpdateMap(_map);
		Connected_.UpdateMap(_map);
		AutoReconnect_.UpdateMap(_map);
		BundleName_.UpdateMap(_map);
		BundleIdentifier_.UpdateMap(_map);
		Options_.UpdateMap(_map);
		HardwareType_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Id_.UpdateMapOnInternalMapUpdate(_map);
		Connected_.UpdateMapOnInternalMapUpdate(_map);
		AutoReconnect_.UpdateMapOnInternalMapUpdate(_map);
		BundleName_.UpdateMapOnInternalMapUpdate(_map);
		BundleIdentifier_.UpdateMapOnInternalMapUpdate(_map);
		Options_.UpdateMapOnInternalMapUpdate(_map);
		HardwareType_.UpdateMapOnInternalMapUpdate(_map);
	}

	public CommunicationDeviceLocal()
		: this(new LoroMap())
	{
	}

	public CommunicationDeviceLocal(LoroMap values)
	{
		_map = values;
		Id_ = new GuidObservableProperty("id__1", LoroMap);
		Connected_ = new BoolObservableProperty("connected__2", LoroMap);
		AutoReconnect_ = new BoolObservableProperty("auto_reconnect__3", LoroMap);
		BundleName_ = new OptionalStringObservableProperty("bundle_name__4", LoroMap);
		BundleIdentifier_ = new OptionalStringObservableProperty("bundle_identifier__5", LoroMap);
		Options_ = new MapCollection<ICommunicationDeviceOption>(LoroMap, "options__11", new EntityFactory());
		HardwareType_ = new UnionObservableProperty<ICommunicationDeviceLocal.Types.IHardwareType>("HardwareType__union", LoroMap, new ICommunicationDeviceLocal.Types.HardwareTypeFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Id_.WhenChangeHappens, Connected_.WhenChangeHappens, AutoReconnect_.WhenChangeHappens, BundleName_.WhenChangeHappens, BundleIdentifier_.WhenChangeHappens, Options_.WhenChangeHappens, HardwareType_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Id_.Dispose();
		Connected_.Dispose();
		AutoReconnect_.Dispose();
		BundleName_.Dispose();
		BundleIdentifier_.Dispose();
		Options_.Dispose();
		HardwareType_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Id_.OnDiff(path, diff);
		Connected_.OnDiff(path, diff);
		AutoReconnect_.OnDiff(path, diff);
		BundleName_.OnDiff(path, diff);
		BundleIdentifier_.OnDiff(path, diff);
		Options_.OnDiff(path, diff);
		HardwareType_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
