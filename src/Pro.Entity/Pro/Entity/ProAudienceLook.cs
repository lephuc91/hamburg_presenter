using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class ProAudienceLook : IProAudienceLook, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private GuidObservableProperty Uuid_;

	private OptionalStringObservableProperty Name_;

	private MapCollection<IProAudienceLook.Types.IProScreenLook> ScreenLooks_;

	private OptionalGuidObservableProperty OriginalLookUuid_;

	private DoubleObservableProperty TransitionDuration_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<Guid> Uuid => Uuid_;

	public IObservableProperty<string?> Name => Name_;

	public IComplexCollection<IProAudienceLook.Types.IProScreenLook> ScreenLooks => ScreenLooks_;

	public IObservableProperty<Guid?> OriginalLookUuid => OriginalLookUuid_;

	public IObservableProperty<double> TransitionDuration => TransitionDuration_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMap(_map);
		Name_.UpdateMap(_map);
		ScreenLooks_.UpdateMap(_map);
		OriginalLookUuid_.UpdateMap(_map);
		TransitionDuration_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMapOnInternalMapUpdate(_map);
		Name_.UpdateMapOnInternalMapUpdate(_map);
		ScreenLooks_.UpdateMapOnInternalMapUpdate(_map);
		OriginalLookUuid_.UpdateMapOnInternalMapUpdate(_map);
		TransitionDuration_.UpdateMapOnInternalMapUpdate(_map);
	}

	public ProAudienceLook()
		: this(new LoroMap())
	{
	}

	public ProAudienceLook(LoroMap values)
	{
		_map = values;
		Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
		Name_ = new OptionalStringObservableProperty("name__2", LoroMap);
		ScreenLooks_ = new MapCollection<IProAudienceLook.Types.IProScreenLook>(LoroMap, "screen_looks__3", new EntityFactory());
		OriginalLookUuid_ = new OptionalGuidObservableProperty("original_look_uuid__4", LoroMap);
		TransitionDuration_ = new DoubleObservableProperty("transition_duration__5", LoroMap);
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, Name_.WhenChangeHappens, ScreenLooks_.WhenChangeHappens, OriginalLookUuid_.WhenChangeHappens, TransitionDuration_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Uuid_.Dispose();
		Name_.Dispose();
		ScreenLooks_.Dispose();
		OriginalLookUuid_.Dispose();
		TransitionDuration_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Uuid_.OnDiff(path, diff);
		Name_.OnDiff(path, diff);
		ScreenLooks_.OnDiff(path, diff);
		OriginalLookUuid_.OnDiff(path, diff);
		TransitionDuration_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
