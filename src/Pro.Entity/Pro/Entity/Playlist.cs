using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class Playlist : IPlaylist, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private GuidObservableProperty Uuid_;

	private StringObservableProperty Name_;

	private BoolObservableProperty Expanded_;

	private UnionObservableProperty<IPlaylist.Types.IChildrenType> ChildrenType_;

	private UnionObservableProperty<IPlaylist.Types.ILinkData> LinkData_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<Guid> Uuid => Uuid_;

	public IObservableProperty<string> Name => Name_;

	public IObservableProperty<bool> Expanded => Expanded_;

	public IComplexObservableProperty<IPlaylist.Types.IChildrenType> ChildrenType => ChildrenType_;

	public IComplexObservableProperty<IPlaylist.Types.ILinkData> LinkData => LinkData_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMap(_map);
		Name_.UpdateMap(_map);
		Expanded_.UpdateMap(_map);
		ChildrenType_.UpdateMap(_map);
		LinkData_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMapOnInternalMapUpdate(_map);
		Name_.UpdateMapOnInternalMapUpdate(_map);
		Expanded_.UpdateMapOnInternalMapUpdate(_map);
		ChildrenType_.UpdateMapOnInternalMapUpdate(_map);
		LinkData_.UpdateMapOnInternalMapUpdate(_map);
	}

	public Playlist()
		: this(new LoroMap())
	{
	}

	public Playlist(LoroMap values)
	{
		_map = values;
		Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
		Name_ = new StringObservableProperty("name__2", LoroMap);
		Expanded_ = new BoolObservableProperty("expanded__4", LoroMap);
		ChildrenType_ = new UnionObservableProperty<IPlaylist.Types.IChildrenType>("ChildrenType__union", LoroMap, new IPlaylist.Types.ChildrenTypeFactory());
		LinkData_ = new UnionObservableProperty<IPlaylist.Types.ILinkData>("LinkData__union", LoroMap, new IPlaylist.Types.LinkDataFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, Name_.WhenChangeHappens, Expanded_.WhenChangeHappens, ChildrenType_.WhenChangeHappens, LinkData_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Uuid_.Dispose();
		Name_.Dispose();
		Expanded_.Dispose();
		ChildrenType_.Dispose();
		LinkData_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Uuid_.OnDiff(path, diff);
		Name_.OnDiff(path, diff);
		Expanded_.OnDiff(path, diff);
		ChildrenType_.OnDiff(path, diff);
		LinkData_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
