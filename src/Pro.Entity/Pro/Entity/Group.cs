using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class Group : IGroup, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private GuidObservableProperty Uuid_;

	private StringObservableProperty Name_;

	private OptionalAtomicObservableProperty<Color> Color_;

	private ComplexObservableProperty<IHotKey> HotKey_;

	private OptionalGuidObservableProperty ApplicationGroupIdentifier_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<Guid> Uuid => Uuid_;

	public IObservableProperty<string> Name => Name_;

	public IObservableProperty<Color?> Color => Color_;

	public IComplexObservableProperty<IHotKey> HotKey => HotKey_;

	public IObservableProperty<Guid?> ApplicationGroupIdentifier => ApplicationGroupIdentifier_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMap(_map);
		Name_.UpdateMap(_map);
		Color_.UpdateMap(_map);
		HotKey_.UpdateMap(_map);
		ApplicationGroupIdentifier_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMapOnInternalMapUpdate(_map);
		Name_.UpdateMapOnInternalMapUpdate(_map);
		Color_.UpdateMapOnInternalMapUpdate(_map);
		HotKey_.UpdateMapOnInternalMapUpdate(_map);
		ApplicationGroupIdentifier_.UpdateMapOnInternalMapUpdate(_map);
	}

	public Group()
		: this(new LoroMap())
	{
	}

	public Group(LoroMap values)
	{
		_map = values;
		Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
		Name_ = new StringObservableProperty("name__2", LoroMap);
		Color_ = new OptionalAtomicObservableProperty<Color>("color__3", LoroMap, ColorExtension.Deserialize, ColorExtension.Serialize);
		HotKey_ = new ComplexObservableProperty<IHotKey>("hotKey__4", LoroMap, new EntityFactory());
		ApplicationGroupIdentifier_ = new OptionalGuidObservableProperty("application_group_identifier__5", LoroMap);
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, Name_.WhenChangeHappens, Color_.WhenChangeHappens, HotKey_.WhenChangeHappens, ApplicationGroupIdentifier_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Uuid_.Dispose();
		Name_.Dispose();
		Color_.Dispose();
		HotKey_.Dispose();
		ApplicationGroupIdentifier_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Uuid_.OnDiff(path, diff);
		Name_.OnDiff(path, diff);
		Color_.OnDiff(path, diff);
		HotKey_.OnDiff(path, diff);
		ApplicationGroupIdentifier_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
