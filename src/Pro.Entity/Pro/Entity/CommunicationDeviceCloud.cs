using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class CommunicationDeviceCloud : ICommunicationDeviceCloud, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private GuidObservableProperty Id_;

	private StringObservableProperty Name_;

	private EnumObservableProperty<ICommunicationDevice.Types.DeviceType> DeviceType_;

	private EnumObservableProperty<ICommunicationDevice.Types.Behavior> Behavior_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<Guid> Id => Id_;

	public IObservableProperty<string> Name => Name_;

	public IObservableProperty<ICommunicationDevice.Types.DeviceType> DeviceType => DeviceType_;

	public IObservableProperty<ICommunicationDevice.Types.Behavior> Behavior => Behavior_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Id_.UpdateMap(_map);
		Name_.UpdateMap(_map);
		DeviceType_.UpdateMap(_map);
		Behavior_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Id_.UpdateMapOnInternalMapUpdate(_map);
		Name_.UpdateMapOnInternalMapUpdate(_map);
		DeviceType_.UpdateMapOnInternalMapUpdate(_map);
		Behavior_.UpdateMapOnInternalMapUpdate(_map);
	}

	public CommunicationDeviceCloud()
		: this(new LoroMap())
	{
	}

	public CommunicationDeviceCloud(LoroMap values)
	{
		_map = values;
		Id_ = new GuidObservableProperty("id__1", LoroMap);
		Name_ = new StringObservableProperty("name__2", LoroMap);
		DeviceType_ = new EnumObservableProperty<ICommunicationDevice.Types.DeviceType>("device_type__3", LoroMap);
		Behavior_ = new EnumObservableProperty<ICommunicationDevice.Types.Behavior>("behavior__4", LoroMap);
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Id_.WhenChangeHappens, Name_.WhenChangeHappens, DeviceType_.WhenChangeHappens, Behavior_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Id_.Dispose();
		Name_.Dispose();
		DeviceType_.Dispose();
		Behavior_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Id_.OnDiff(path, diff);
		Name_.OnDiff(path, diff);
		DeviceType_.OnDiff(path, diff);
		Behavior_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
