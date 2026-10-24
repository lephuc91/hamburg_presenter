using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class PlaylistItem : IPlaylistItem, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private GuidObservableProperty Uuid_;

	private StringObservableProperty Name_;

	private GuidCollection Tags_;

	private BoolObservableProperty IsHidden_;

	private UnionObservableProperty<IPlaylistItem.Types.IItemType> ItemType_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<Guid> Uuid => Uuid_;

	public IObservableProperty<string> Name => Name_;

	public ICollection<Guid> Tags => Tags_;

	public IObservableProperty<bool> IsHidden => IsHidden_;

	public IComplexObservableProperty<IPlaylistItem.Types.IItemType> ItemType => ItemType_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMap(_map);
		Name_.UpdateMap(_map);
		Tags_.UpdateMap(_map);
		IsHidden_.UpdateMap(_map);
		ItemType_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMapOnInternalMapUpdate(_map);
		Name_.UpdateMapOnInternalMapUpdate(_map);
		Tags_.UpdateMapOnInternalMapUpdate(_map);
		IsHidden_.UpdateMapOnInternalMapUpdate(_map);
		ItemType_.UpdateMapOnInternalMapUpdate(_map);
	}

	public PlaylistItem()
		: this(new LoroMap())
	{
	}

	public PlaylistItem(LoroMap values)
	{
		_map = values;
		Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
		Name_ = new StringObservableProperty("name__2", LoroMap);
		Tags_ = new GuidCollection(LoroMap, "tags__7");
		IsHidden_ = new BoolObservableProperty("is_hidden__9", LoroMap);
		ItemType_ = new UnionObservableProperty<IPlaylistItem.Types.IItemType>("ItemType__union", LoroMap, new IPlaylistItem.Types.ItemTypeFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, Name_.WhenChangeHappens, Tags_.WhenChangeHappens, IsHidden_.WhenChangeHappens, ItemType_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Uuid_.Dispose();
		Name_.Dispose();
		Tags_.Dispose();
		IsHidden_.Dispose();
		ItemType_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Uuid_.OnDiff(path, diff);
		Name_.OnDiff(path, diff);
		Tags_.OnDiff(path, diff);
		IsHidden_.OnDiff(path, diff);
		ItemType_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
