using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class PlaylistDocument : IPlaylistDocument, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private EnumObservableProperty<IPlaylistDocument.Types.Type> Type_;

	private ComplexObservableProperty<IPlaylist> RootNode_;

	private OptionalComplexObservableProperty<IPlaylist> LiveVideoPlaylist_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<IPlaylistDocument.Types.Type> Type => Type_;

	public IComplexObservableProperty<IPlaylist> RootNode => RootNode_;

	public IComplexObservableProperty<IPlaylist?> LiveVideoPlaylist => LiveVideoPlaylist_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Type_.UpdateMap(_map);
		RootNode_.UpdateMap(_map);
		LiveVideoPlaylist_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Type_.UpdateMapOnInternalMapUpdate(_map);
		RootNode_.UpdateMapOnInternalMapUpdate(_map);
		LiveVideoPlaylist_.UpdateMapOnInternalMapUpdate(_map);
	}

	public PlaylistDocument()
		: this(new LoroMap())
	{
	}

	public PlaylistDocument(LoroMap values)
	{
		_map = values;
		Type_ = new EnumObservableProperty<IPlaylistDocument.Types.Type>("type__2", LoroMap);
		RootNode_ = new ComplexObservableProperty<IPlaylist>("root_node__3", LoroMap, new EntityFactory());
		LiveVideoPlaylist_ = new OptionalComplexObservableProperty<IPlaylist>("live_video_playlist__5", LoroMap, new EntityFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Type_.WhenChangeHappens, RootNode_.WhenChangeHappens, LiveVideoPlaylist_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Type_.Dispose();
		RootNode_.Dispose();
		LiveVideoPlaylist_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Type_.OnDiff(path, diff);
		RootNode_.OnDiff(path, diff);
		LiveVideoPlaylist_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
